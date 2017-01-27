using System;
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
    public class FacadeEngine<TRequest, TResponse>
        where TRequest : BaseRequest, new()
        where TResponse : IResponseFor
    {
        internal readonly TimeSpan defaultTimeout = new TimeSpan(0, 0, 30);
        internal static readonly FacadeEngine<TRequest, TResponse> instance = new FacadeEngine<TRequest, TResponse>();

        /// <summary>
        /// Query the Google Maps API using the provided request with the default timeout of 100,000 milliseconds (100 seconds).
        /// </summary>
        /// <param name="request">The request that will be sent.</param>
        /// <returns>The response that was received.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the request parameter.</exception>
        /// <exception cref="TaskCanceledException">Thrown when the provided Google client ID or signing key are invalid.</exception>
        public virtual TResponse Query(TRequest request)
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
        public virtual TResponse Query(TRequest request, TimeSpan timeout)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return GenericEngine<TRequest, TResponse>.Query(request, timeout);
        }

        /// <summary>
        /// Asynchronously query the Google Maps API using the provided request.
        /// </summary>
        /// <param name="request">The request that will be sent.</param>
        /// <returns>A Task with the future value of the response.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the request parameter.</exception>
        public virtual Task<TResponse> QueryAsync(TRequest request)
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
        public virtual Task<TResponse> QueryAsync(TRequest request, TimeSpan timeout)
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
        public virtual Task<TResponse> QueryAsync(TRequest request, CancellationToken token)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return GenericEngine<TRequest, TResponse>.QueryAsync(request, TimeSpan.FromMilliseconds(Timeout.Infinite),
                token);
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
        public virtual Task<TResponse> QueryAsync(TRequest request, TimeSpan timeout, CancellationToken token)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return GenericEngine<TRequest, TResponse>.QueryAsync(request, timeout, token);
        }
    }
}