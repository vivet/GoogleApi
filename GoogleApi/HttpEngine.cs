using GoogleApi.Entities;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Exceptions;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleApi
{
    /// <summary>
    /// Http Engine.
    /// Manges the http connections, and is responsible for invoking requst and handling responses.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class HttpEngine<TRequest, TResponse>
        where TRequest : IRequest, new()
        where TResponse : IResponse, new()
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Constructor.
        /// </summary>
        protected HttpEngine()
            : this(HttpClientFactory.CreateDefaultHttpClient())
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="httpClient">The <see cref="httpClient"/>.</param>
        protected HttpEngine(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
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

            httpEngineOptions ??= new HttpEngineOptions();

            try
            {
                var result = this.ProcessRequest(request);
                var response = this.ProcessResponse(result);

                switch (response.Status)
                {
                    case Status.Ok:
                    case Status.NotFound:
                    case Status.ZeroResults:
                        return response;

                    case Status.InvalidRequest:
                        if (!httpEngineOptions.ThrowOnInvalidRequest)
                        {
                            return response;
                        }

                        throw new GoogleApiException($"{response.Status}: {response.ErrorMessage ?? "No message"}")
                        {
                            Status = response.Status
                        };

                    default:
                        throw new GoogleApiException($"{response.Status}: {response.ErrorMessage ?? "No message"}")
                        {
                            Status = response.Status
                        };
                }
            }
            catch (Exception ex)
            {
                if (ex is GoogleApiException)
                    throw;

                throw new GoogleApiException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Query Async.
        /// </summary>
        /// <param name="request">The request that will be sent.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
        /// <returns>The <see cref="Task{T}"/>.</returns>
        public async Task<TResponse> QueryAsync(TRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var taskCompletion = new TaskCompletionSource<TResponse>();

            await this.ProcessRequestAsync(request, cancellationToken)
                .ContinueWith(async x =>
                {
                    try
                    {
                        if (x.IsCanceled)
                        {
                            taskCompletion.SetCanceled();
                        }
                        else if (x.IsFaulted)
                        {
                            throw x.Exception ?? new Exception();
                        }
                        else
                        {
                            var result = await x;
                            var response = await this.ProcessResponseAsync(result).ConfigureAwait(false);

                            switch (response.Status)
                            {
                                case Status.Ok:
                                case Status.NotFound:
                                case Status.ZeroResults:
                                    taskCompletion.SetResult(response);
                                    break;

                                default:
                                    throw new GoogleApiException($"{response.Status}: {response.ErrorMessage}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is GoogleApiException)
                        {
                            taskCompletion.SetException(ex);
                        }
                        else
                        {
                            var baseException = ex.GetBaseException();
                            var exception = new GoogleApiException(baseException.Message, baseException);

                            taskCompletion.SetException(exception);
                        }
                    }
                }, cancellationToken)
                .ConfigureAwait(false);

            return await taskCompletion.Task;
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
            if (request == null)
                throw new ArgumentNullException(nameof(request));

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
                        }
                        else if (x.IsFaulted)
                        {
                            throw x.Exception ?? new Exception();
                        }
                        else
                        {
                            var result = await x;
                            var response = await this.ProcessResponseAsync(result).ConfigureAwait(false);

                            switch (response.Status)
                            {
                                case Status.Ok:
                                case Status.NotFound:
                                case Status.ZeroResults:
                                    taskCompletion.SetResult(response);
                                    break;

                                case Status.InvalidRequest:
                                    if (!httpEngineOptions.ThrowOnInvalidRequest)
                                    {
                                        taskCompletion.SetResult(response);
                                        break;
                                    }

                                    throw new GoogleApiException($"{response.Status}: {response.ErrorMessage ?? "No message"}")
                                    {
                                        Status = response.Status
                                    };

                                default:
                                    throw new GoogleApiException($"{response.Status}: {response.ErrorMessage ?? "No message"}")
                                    {
                                        Status = response.Status
                                    };
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex is GoogleApiException)
                        {
                            taskCompletion.SetException(ex);
                        }
                        else
                        {
                            var baseException = ex.GetBaseException();
                            var exception = new GoogleApiException(baseException.Message, baseException);

                            taskCompletion.SetException(exception);
                        }
                    }
                }, cancellationToken)
                .ConfigureAwait(false);

            return await taskCompletion.Task;
        }

        private HttpResponseMessage ProcessRequest(TRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var uri = request.GetUri();

            if (request is IRequestQueryString)
            {
                return this.httpClient.GetAsync(uri).Result;
            }

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            var serializeObject = JsonConvert.SerializeObject(request, settings);

            using var stringContent = new StringContent(serializeObject, Encoding.UTF8);
            {
                var content = stringContent.ReadAsStreamAsync().Result;

                using var streamContent = new StreamContent(content);
                {
                    return this.httpClient.PostAsync(uri, streamContent).Result;
                }
            }
        }
        private TResponse ProcessResponse(HttpResponseMessage httpResponse)
        {
            if (httpResponse == null)
                throw new ArgumentNullException(nameof(httpResponse));

            using (httpResponse)
            {
                httpResponse.EnsureSuccessStatusCode();

                var response = new TResponse();

                switch (response)
                {
                    case BaseResponseStream streamResponse:
                        streamResponse.Buffer = httpResponse.Content.ReadAsByteArrayAsync().Result;
                        response = (TResponse)(IResponse)streamResponse;
                        break;

                    default:
                        var rawJson = httpResponse.Content.ReadAsStringAsync().Result;
                        response = JsonConvert.DeserializeObject<TResponse>(rawJson);

                        if (response == null)
                            throw new NullReferenceException(nameof(response));

                        response.RawJson = rawJson;
                        break;
                }

                response.RawQueryString = httpResponse.RequestMessage.RequestUri.PathAndQuery;
                response.Status = httpResponse.IsSuccessStatusCode
                    ? response.Status ?? Status.Ok
                    : Status.HttpError;

                return response;
            }
        }

        private async Task<HttpResponseMessage> ProcessRequestAsync(TRequest request, CancellationToken cancellationToken = default)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var uri = request.GetUri();

            if (request is IRequestQueryString)
            {
                return await this.httpClient.GetAsync(uri, cancellationToken).ConfigureAwait(false);
            }

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            var serializeObject = JsonConvert.SerializeObject(request, settings);

            using var stringContent = new StringContent(serializeObject, Encoding.UTF8);
            {
                var content = await stringContent.ReadAsStreamAsync().ConfigureAwait(false);

                using var streamContent = new StreamContent(content);
                {
                    return await this.httpClient.PostAsync(uri, streamContent, cancellationToken).ConfigureAwait(false);
                }
            }
        }
        private async Task<TResponse> ProcessResponseAsync(HttpResponseMessage httpResponse)
        {
            if (httpResponse == null)
                throw new ArgumentNullException(nameof(httpResponse));

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
                        response = JsonConvert.DeserializeObject<TResponse>(rawJson);

                        if (response == null)
                            throw new NullReferenceException(nameof(response));

                        response.RawJson = rawJson;
                        break;
                }

                response.RawQueryString = httpResponse.RequestMessage.RequestUri.PathAndQuery;
                response.Status = httpResponse.IsSuccessStatusCode
                    ? response.Status ?? Status.Ok
                    : Status.HttpError;

                return response;
            }
        }
    }
}