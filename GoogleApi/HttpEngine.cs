using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Places.Photos.Response;
using GoogleApi.Exceptions;
using Newtonsoft.Json;

namespace GoogleApi
{
    /// <summary>
    /// A public-surface API that exposes the Google Maps API functionality.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public sealed class HttpEngine<TRequest, TResponse>
        where TRequest : IRequest, new()
        where TResponse : IResponse, new()
    {
        internal readonly TimeSpan defaultTimeout = new TimeSpan(0, 0, 30);
        internal static readonly HttpEngine<TRequest, TResponse> instance = new HttpEngine<TRequest, TResponse>();

        /// <summary>
        /// Query the Google Maps API using the provided request with the default timeout of 30 seconds.
        /// </summary>
        /// <param name="request">The request that will be sent.</param>
        /// <returns>The response that was received.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the request parameter.</exception>
        /// <exception cref="TaskCanceledException">Thrown when the provided Google client ID or signing key are invalid.</exception>
        public TResponse Query(TRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return this.Query(request, this.defaultTimeout);
        }

        /// <summary>
        /// Query the Google Maps API using the provided request and timeout period.
        /// </summary>
        /// <param name="request">The request that will be sent.</param>
        /// <param name="timeout">A TimeSpan specifying the amount of time to wait for a response before aborting the request.
        /// The specify an infinite timeout, pass a TimeSpan with a TotalMillisecond value of Timeout.Infinite.
        /// When a request is aborted due to a timeout an AggregateException will be thrown with an InnerException of type TimeoutException.</param>
        /// <returns>The response that was received.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the request parameter.</exception>
        /// <exception cref="TaskCanceledException">Thrown when the provided Google client ID or signing key are invalid.</exception>
        public TResponse Query(TRequest request, TimeSpan timeout)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return this.QueryAsync(request).Result;
        }

        /// <summary>
        /// Asynchronously query the Google Maps API using the provided request.
        /// </summary>
        /// <param name="request">The request that will be sent.</param>
        /// <returns>A Task with the future value of the response.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the request parameter.</exception>
        public Task<TResponse> QueryAsync(TRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return this.QueryAsync(request, CancellationToken.None);
        }

        /// <summary>
        /// Asynchronously query the Google Maps API using the provided request.
        /// </summary>
        /// <param name="request">The request that will be sent.</param>
        /// <param name="timeout">A TimeSpan specifying the amount of time to wait for a response before aborting the request.
        /// The specify an infinite timeout, pass a TimeSpan with a TotalMillisecond value of Timeout.Infinite.
        /// When a request is aborted due to a timeout the returned task will transition to the Faulted state with a TimeoutException.</param>
        /// <returns>A Task with the future value of the response.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the request parameter.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value of timeout is neither a positive value or infinite.</exception>
        public Task<TResponse> QueryAsync(TRequest request, TimeSpan timeout)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (timeout == null)
                throw new ArgumentNullException(nameof(timeout));

            return this.QueryAsync(request, timeout, CancellationToken.None);
        }

        /// <summary>
        /// Asynchronously query the Google Maps API using the provided request.
        /// </summary>
        /// <param name="request">The request that will be sent.</param>
        /// <param name="cancellationToken">A cancellation cancellationToken that can be used to cancel the pending asynchronous task.</param>
        /// <returns>A Task with the future value of the response.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the request parameter.</exception>
        public Task<TResponse> QueryAsync(TRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (cancellationToken == null)
                throw new ArgumentNullException(nameof(cancellationToken));

            return this.QueryAsync(request, TimeSpan.FromMilliseconds(Timeout.Infinite), cancellationToken);
        }

        /// <summary>
        /// Asynchronously query the Google Maps API using the provided request.
        /// </summary>
        /// <param name="request">The request that will be sent.</param>
        /// <param name="timeout">A TimeSpan specifying the amount of time to wait for a response before aborting the request.
        /// The specify an infinite timeout, pass a TimeSpan with a TotalMillisecond value of Timeout.Infinite.
        /// When a request is aborted due to a timeout the returned task will transition to the Faulted state with a TimeoutException.</param>
        /// <param name="cancellationToken">A cancellation cancellationToken that can be used to cancel the pending asynchronous task.</param>
        /// <returns>A Task with the future value of the response.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the request parameter.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value of timeout is neither a positive value or infinite.</exception>
        public Task<TResponse> QueryAsync(TRequest request, TimeSpan timeout, CancellationToken cancellationToken)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (timeout == null)
                throw new ArgumentNullException(nameof(timeout));

            if (cancellationToken == null)
                throw new ArgumentNullException(nameof(cancellationToken));

            var uri = request.GetUri();
            var httpClient = new HttpClient { Timeout = timeout };
            var taskCompletionSource = new TaskCompletionSource<TResponse>();

            if (request.IsGzip)
                httpClient.DefaultRequestHeaders.Add("Accept-Encoding", "gzip,deflate");

            Task<HttpResponseMessage> task;
            if (request is IRequestJson)
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                var serializeObject = JsonConvert.SerializeObject(request, jsonSerializerSettings);

                using (var json = new StringContent(serializeObject, Encoding.UTF8))
                {
                    var content = json.ReadAsByteArrayAsync().Result;
                    var streamContent = new StreamContent(new MemoryStream(content));

                    task = httpClient.PostAsync(uri, streamContent, cancellationToken);
                }
            }
            else
                task = httpClient.GetAsync(uri, cancellationToken);

            task.ContinueWith(x =>
            {
                var response = default(TResponse);
                try
                {
                    if (x.IsCanceled)
                    {
                        taskCompletionSource.SetCanceled();
                    }
                    else if (x.IsFaulted)
                    {
                        var exception = x.Exception == null
                            ? new NullReferenceException("task.Exception")
                            : x.Exception?.InnerException ?? x.Exception ?? new Exception("unknown error");

                        throw exception;
                    }
                    else
                    {
                        var result = x.Result;
                        var content = result.Content;
                        var rawJson = content.ReadAsStringAsync().Result;
                        var rawBuffer = content.ReadAsByteArrayAsync().Result;
           
                        if (typeof(TResponse) != typeof(PlacesPhotosResponse))
                        {
                            using (var memoryStream = new MemoryStream(rawBuffer))
                            {
                                using (var streamReader = new StreamReader(memoryStream))
                                {
                                    var jsonSerializer = new JsonSerializer();
                                    var jsonTextReader = new JsonTextReader(streamReader);

                                    try
                                    {
                                        response = jsonSerializer.Deserialize<TResponse>(jsonTextReader);
                                    }
                                    catch
                                    {
                                        response = new TResponse();
                                    }
                                }
                            }
                        }
                        else
                            response = (TResponse)(IResponse)new PlacesPhotosResponse { PhotoBuffer = rawBuffer };
                       
                        response.RawJson = rawJson;
                        response.RawQueryString = result.RequestMessage.RequestUri.PathAndQuery;
                        response.Status = result.IsSuccessStatusCode ? response.Status ?? Status.Ok : Status.HttpError;

                        result.EnsureSuccessStatusCode();

                        if (response.Status != Status.Ok && response.Status != Status.ZeroResults)
                            throw new GoogleApiException(response.ErrorMessage) { Response = response };

                        taskCompletionSource.SetResult(response);
                    }
                }
                catch (Exception ex)
                {
                    var exception = ex is GoogleApiException ? ex : new GoogleApiException(ex.Message, ex) { Response = response };

                    taskCompletionSource.SetException(exception);
                }
                finally
                {
                    httpClient.Dispose();
                }
            }, TaskContinuationOptions.ExecuteSynchronously);

            return taskCompletionSource.Task;
        }
    }
}