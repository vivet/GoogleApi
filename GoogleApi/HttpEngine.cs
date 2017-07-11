using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Places.Photos.Response;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;

namespace GoogleApi
{
    /// <summary>
    /// A public-surface API that exposes the Google Maps API functionality.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public sealed class HttpEngine<TRequest, TResponse>
        where TRequest : BaseRequest, new()
        where TResponse : IResponseFor
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

            return this.HttpRequest(request, timeout).Result;
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

            return this.QueryAsync(request, timeout, CancellationToken.None);
        }

        /// <summary>
        /// Asynchronously query the Google Maps API using the provided request.
        /// </summary>
        /// <param name="request">The request that will be sent.</param>
        /// <param name="token">A cancellation token that can be used to cancel the pending asynchronous task.</param>
        /// <returns>A Task with the future value of the response.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the request parameter.</exception>
        public Task<TResponse> QueryAsync(TRequest request, CancellationToken token)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return this.HttpRequest(request, TimeSpan.FromMilliseconds(Timeout.Infinite), token);
        }

        /// <summary>
        /// Asynchronously query the Google Maps API using the provided request.
        /// </summary>
        /// <param name="request">The request that will be sent.</param>
        /// <param name="timeout">A TimeSpan specifying the amount of time to wait for a response before aborting the request.
        /// The specify an infinite timeout, pass a TimeSpan with a TotalMillisecond value of Timeout.Infinite.
        /// When a request is aborted due to a timeout the returned task will transition to the Faulted state with a TimeoutException.</param>
        /// <param name="token">A cancellation token that can be used to cancel the pending asynchronous task.</param>
        /// <returns>A Task with the future value of the response.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the request parameter.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value of timeout is neither a positive value or infinite.</exception>
        public Task<TResponse> QueryAsync(TRequest request, TimeSpan timeout, CancellationToken token)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return this.HttpRequest(request, timeout, token);
        }

        // Private methods.
        private Uri GetUri(TRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var scheme = request.IsSsl ? "https://" : "http://";
            var queryString = string.Join("&", request.QueryStringParameters.Select(x => Uri.EscapeDataString(x.Name) + "=" + Uri.EscapeDataString(x.Value)));
            var uri = new Uri(scheme + request.BaseUrl + "?" + queryString);

            return request.ClientId == null ? uri : this.SignUri(request, uri);
        }
        private Uri SignUri(TRequest request, Uri uri)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (uri == null)
                throw new ArgumentNullException(nameof(uri));

            var url = uri.LocalPath + uri.Query + "&client=" + request.ClientId;
            var bytes = Encoding.UTF8.GetBytes(url);
            var privateKey = this.FromBase64UrlString(request.Key);

            var hmac = new HMac(new Sha256Digest());
            hmac.Init(new KeyParameter(privateKey));

            var signature = new byte[hmac.GetMacSize()];

            hmac.BlockUpdate(bytes, 0, bytes.Length);
            hmac.DoFinal(signature, 0);

            return new Uri(uri.Scheme + "://" + uri.Host + url + "&signature=" + this.ToBase64UrlString(signature));
        }
        private string ToBase64UrlString(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return Convert.ToBase64String(data).Replace("+", "-").Replace("/", "_");
        }
        private byte[] FromBase64UrlString(string base64UrlString)
        {
            if (base64UrlString == null)
                throw new ArgumentNullException(nameof(base64UrlString));

            return Convert.FromBase64String(base64UrlString.Replace("-", "+").Replace("_", "/"));
        }
        private Task<TResponse> HttpRequest(TRequest request, TimeSpan timeout, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var uri = this.GetUri(request);
            var httpClient = new HttpClient { Timeout = timeout };
            var jsonString = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var taskCompletionSource = new TaskCompletionSource<TResponse>();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var task = request is IQueryStringRequest
                ? httpClient.GetAsync(uri, cancellationToken)
                : httpClient.PostAsync(uri, new StringContent(jsonString, Encoding.UTF8), cancellationToken);

            task.ContinueWith(x =>
            {
                if (x.IsCanceled)
                {
                    taskCompletionSource.SetCanceled();
                }
                else if (x.IsFaulted)
                {
                    var exception = x.Exception == null ? new NullReferenceException("task.Exception") : task.Exception?.InnerException ?? task.Exception ?? new Exception("error");
                    taskCompletionSource.SetException(exception);
                }
                else
                {
                    try
                    {
                        x.Result.EnsureSuccessStatusCode();

                        var result = x.Result;
                        var content = result.Content;
                        var json = content.ReadAsStringAsync().Result;
                        var data = content.ReadAsByteArrayAsync().Result;
                        var stream = new MemoryStream(data, false);

                        TResponse response;
                        if (typeof(TResponse) == typeof(PlacesPhotosResponse))
                        {
                            response = (TResponse)(IResponseFor)new PlacesPhotosResponse { Photo = stream };
                        }
                        else
                        {
                            var jsonSerializer = new JsonSerializer();

                            using (var streamReader = new StreamReader(stream))
                            {
                                response = jsonSerializer.Deserialize<TResponse>(new JsonTextReader(streamReader));
                            }

                            response.RawJson = json;
                            response.RawQueryString = uri.PathAndQuery;
                        }

                        taskCompletionSource.SetResult(response);
                    }
                    catch (Exception ex)
                    {
                        taskCompletionSource.SetException(ex);
                    }
                }
            }, TaskContinuationOptions.ExecuteSynchronously);

            return taskCompletionSource.Task;
        }
    }
}