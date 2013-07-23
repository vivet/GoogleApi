using System;
using System.Net;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;

namespace GoogleApi.Engine
{
    /// <summary>
    /// A public-surface API that exposes the Google Maps API functionality.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class EngineFacade<TRequest, TResponse> where TRequest : BaseRequest, new() where TResponse : IResponseFor
    {
        internal readonly TimeSpan _defaultTimeout;
        
        internal static readonly EngineFacade<TRequest, TResponse> _instance = new EngineFacade<TRequest, TResponse>();

        private EngineFacade()
        {
            this._defaultTimeout = TimeSpan.FromSeconds(100);
        }

        /// <summary>
        /// Determines the maximum number of concurrent HTTP connections to open to this engine's host address. The default value is 2 connections.
        /// </summary>
        /// <remarks>
        /// This value is determined by the ServicePointManager and is shared across other engines that use the same host address.
        /// </remarks>
        public int HttpConnectionLimit
        {
            get
            {
                return GenericEngine<TRequest, TResponse>.HttpConnectionLimit;
            }
            set
            {
                GenericEngine<TRequest, TResponse>.HttpConnectionLimit = value;
            }
        }
	    /// <summary>
        /// Determines the maximum number of concurrent HTTPS connections to open to this engine's host address. The default value is 2 connections.
        /// </summary>
        /// <remarks>
        /// This value is determined by the ServicePointManager and is shared across other engines that use the same host address.
        /// </remarks>
        public int HttpsConnectionLimit
        {
            get
            {
                return GenericEngine<TRequest, TResponse>.HttpsConnectionLimit;
            }
            set
            {
                GenericEngine<TRequest, TResponse>.HttpsConnectionLimit = value;
            }
        }

        /// <summary>
        /// Query the Google Maps API using the provided request with the default timeout of 100,000 milliseconds (100 seconds).
        /// </summary>
        /// <param name="_request">The request that will be sent.</param>
        /// <returns>The response that was received.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the request parameter.</exception>
        /// <exception cref="AuthenticationException">Thrown when the provided Google client ID or signing key are invalid.</exception>
        /// <exception cref="TimeoutException">Thrown when the operation has exceeded the allotted time.</exception>
        /// <exception cref="WebException">Thrown when an error occurred while downloading data.</exception>
        public TResponse Query(TRequest _request)
        {
            return this.Query(_request, this._defaultTimeout);
        }
        /// <summary>
        /// Query the Google Maps API using the provided request and timeout period.
        /// </summary>
        /// <param name="_request">The request that will be sent.</param>
        /// <param name="_timeout">A TimeSpan specifying the amount of time to wait for a response before aborting the request.
        /// The specify an infinite timeout, pass a TimeSpan with a TotalMillisecond value of Timeout.Infinite.
        /// When a request is aborted due to a timeout an AggregateException will be thrown with an InnerException of type TimeoutException.</param>
        /// <returns>The response that was received.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the request parameter.</exception>
        /// <exception cref="AuthenticationException">Thrown when the provided Google client ID or signing key are invalid.</exception>
        /// <exception cref="TimeoutException">Thrown when the operation has exceeded the allotted time.</exception>
        /// <exception cref="WebException">Thrown when an error occurred while downloading data.</exception>
        public TResponse Query(TRequest _request, TimeSpan _timeout)
        {
            return GenericEngine<TRequest, TResponse>.QueryGoogleApi(_request, _timeout);
        }
        /// <summary>
        /// Asynchronously query the Google Maps API using the provided request.
        /// </summary>
        /// <param name="_request">The request that will be sent.</param>
        /// <returns>A Task with the future value of the response.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the request parameter.</exception>
        public Task<TResponse> QueryAsync(TRequest _request)
        {
            return this.QueryAsync(_request, CancellationToken.None);
        }
        /// <summary>
        /// Asynchronously query the Google Maps API using the provided request.
        /// </summary>
        /// <param name="_request">The request that will be sent.</param>
        /// <param name="_timeout">A TimeSpan specifying the amount of time to wait for a response before aborting the request.
        /// The specify an infinite timeout, pass a TimeSpan with a TotalMillisecond value of Timeout.Infinite.
        /// When a request is aborted due to a timeout the returned task will transition to the Faulted state with a TimeoutException.</param>
        /// <returns>A Task with the future value of the response.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the request parameter.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value of timeout is neither a positive value or infinite.</exception>
        public Task<TResponse> QueryAsync(TRequest _request, TimeSpan _timeout)
        {
            return this.QueryAsync(_request, _timeout, CancellationToken.None);
        }
        /// <summary>
        /// Asynchronously query the Google Maps API using the provided request.
        /// </summary>
        /// <param name="_request">The request that will be sent.</param>
        /// <param name="_token">A cancellation token that can be used to cancel the pending asynchronous task.</param>
        /// <returns>A Task with the future value of the response.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the request parameter.</exception>
        public Task<TResponse> QueryAsync(TRequest _request, CancellationToken _token)
        {
            return GenericEngine<TRequest, TResponse>.QueryGoogleApiAsync(_request, TimeSpan.FromMilliseconds(Timeout.Infinite), _token);
        }
        /// <summary>
        /// Asynchronously query the Google Maps API using the provided request.
        /// </summary>
        /// <param name="_request">The request that will be sent.</param>
        /// <param name="_timeout">A TimeSpan specifying the amount of time to wait for a response before aborting the request.
        /// The specify an infinite timeout, pass a TimeSpan with a TotalMillisecond value of Timeout.Infinite.
        /// When a request is aborted due to a timeout the returned task will transition to the Faulted state with a TimeoutException.</param>
        /// <param name="_token">A cancellation token that can be used to cancel the pending asynchronous task.</param>
        /// <returns>A Task with the future value of the response.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the request parameter.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value of timeout is neither a positive value or infinite.</exception>
        public Task<TResponse> QueryAsync(TRequest _request, TimeSpan _timeout, CancellationToken _token)
        {
            return GenericEngine<TRequest, TResponse>.QueryGoogleApiAsync(_request, _timeout, _token);
        }
    }
}