using GoogleApi.Entities;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Exceptions;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleApi
{
    /// <summary>
    /// Http Engine.
    /// Manages the http connections, and is responsible for invoking request and handling responses.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class HttpEngine<TRequest, TResponse>
        where TRequest : IRequest, new()
        where TResponse : IResponse, new()
    {
        private HttpClient HttpClient { get; }

        private static Newtonsoft.Json.JsonSerializerSettings _settings = new Newtonsoft.Json.JsonSerializerSettings
        {
            Formatting = Newtonsoft.Json.Formatting.None,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore,
            ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
            Converters = { new Newtonsoft.Json.Converters.StringEnumConverter() }
        };

        /// <summary>
        ///
        /// </summary>
        protected HttpEngine() : this(HttpClientFactory.GlobalHttpClient)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="client"></param>
        protected HttpEngine(HttpClient client)
        {
            HttpClient = client;
        }

        /// <summary>
        /// Query.
        /// </summary>
        /// <param name="request">The request that will be sent.</param>
        /// <param name="httpEngineOptions">The <see cref="HttpEngineOptions"/>.</param>
        /// <returns>The <see cref="IResponse"/>.</returns>
        public TResponse Query(TRequest request, HttpEngineOptions httpEngineOptions = null)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            try
            {
                return Task.Run(async () => await QueryAsync(request, httpEngineOptions, CancellationToken.None))
                    .Result;
            }
            catch (AggregateException ex)
            {
                if (ex.InnerException is GoogleApiException inner)
                    throw inner;

                throw;
            }
        }

        /// <summary>
        /// Query Async.
        /// </summary>
        /// <param name="request">The request that will be sent.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task{T}"/>.</returns>
        public Task<TResponse> QueryAsync(TRequest request, CancellationToken cancellationToken = default)
        {
            return QueryAsync(request, null, cancellationToken);
        }

        /// <summary>
        /// Query Async.
        /// </summary>
        /// <param name="request">The request that will be sent.</param>
        /// <param name="httpEngineOptions">The <see cref="HttpEngineOptions"/></param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task{T}"/>.</returns>
        public async Task<TResponse> QueryAsync(TRequest request, HttpEngineOptions httpEngineOptions, CancellationToken cancellationToken = default)
        {
            GuardAgainstNull(request, nameof(request));

            httpEngineOptions ??= new HttpEngineOptions();

            var taskCompletion = new TaskCompletionSource<TResponse>();

            await this.ProcessRequestAsync(request, cancellationToken)
                .ContinueWith(async x =>
                {
                    try
                    {
                        if (x.IsCanceled)
                        {
                            taskCompletion.SetCanceled();
                            return;
                        }
                        if (x.IsFaulted)
                        {
                            throw x.Exception ?? new Exception();
                        }

                        var result = await x;
                        var response = await ProcessResponseAsync(result, httpEngineOptions, cancellationToken).ConfigureAwait(false);

                        taskCompletion.SetResult(response);
                    }
                    catch (GoogleApiException ex)
                    {
                        taskCompletion.SetException(ex);
                    }
                    catch (Exception ex)
                    {
                        var baseException = ex.GetBaseException();
                        var exception = new GoogleApiException(baseException.Message, baseException);

                        taskCompletion.SetException(exception);
                    }
                }, cancellationToken)
                .ConfigureAwait(false);

            return await taskCompletion.Task;
        }

        private async Task<HttpResponseMessage> ProcessRequestAsync(TRequest request, CancellationToken cancellationToken = default)
        {
            GuardAgainstNull(request, nameof(request));

            var uri = request.GetUri();

            if (request is IRequestQueryString)
            {
                return await HttpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);
            }

            var serializeObject = Newtonsoft.Json.JsonConvert.SerializeObject(request, _settings);
            using var stringContent = new StringContent(serializeObject, System.Text.Encoding.UTF8, "application/json");

            var content = await stringContent.ReadAsStreamAsync().ConfigureAwait(false);

            using var streamContent = new StreamContent(content);
            return await HttpClient.PostAsync(uri, streamContent, cancellationToken).ConfigureAwait(false);
        }

        private async Task<TResponse> ProcessResponseAsync(HttpResponseMessage httpResponse, HttpEngineOptions httpEngineOptions = null, CancellationToken cancellationToken = default)
        {
            GuardAgainstNull(httpResponse, nameof(httpResponse));

            httpEngineOptions ??= new HttpEngineOptions();

            using (httpResponse)
            {
                httpResponse.EnsureSuccessStatusCode();

                var response = new TResponse();

                switch (response)
                {
                    case BaseResponseStream streamResponse:
                        streamResponse.Buffer = await httpResponse.Content.ReadAsByteArrayAsync();
                        response = (TResponse)(IResponse)streamResponse;
                        break;

                    default:

                        var rawJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

                        response = Newtonsoft.Json.JsonConvert.DeserializeObject<TResponse>(rawJson, _settings);

                        if (response == null)
                            throw new InvalidOperationException($"The {nameof(response)} was null");

                        response.RawJson = rawJson;
                        break;
                }

                response.RawQueryString = httpResponse.RequestMessage.RequestUri.PathAndQuery;
                response.Status = httpResponse.IsSuccessStatusCode
                    ? response.Status ?? Status.Ok
                    : Status.HttpError;

                switch (response.Status)
                {
                    case Status.Ok:
                    case Status.NotFound:
                    case Status.ZeroResults:
                        break;

                    case Status.InvalidRequest:
                        if (httpEngineOptions.ThrowOnInvalidRequest)
                        {
                            throw new GoogleApiException($"{response.Status}: {response.ErrorMessage ?? "No message"}")
                            {
                                Status = response.Status
                            };
                        }
                        break;

                    default:
                        throw new GoogleApiException($"{response.Status}: {response.ErrorMessage ?? "No message"}")
                        {
                            Status = response.Status
                        };
                }

                return response;
            }
        }

        private void GuardAgainstNull(object subject, string name)
        {
            if (subject == null)
                throw new ArgumentNullException(name);

        }
    }
}