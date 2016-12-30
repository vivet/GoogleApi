using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace GoogleApi.Extensions
{
    /// <summary>
    /// Provides asynchronous extension methods based on the Task-based Asynchronous Pattern for the WebClient class.
    /// </summary>
    /// <remarks>
    /// The code below uses the guidelines outlined in the MSDN article "Simplify Asynchronous Programming with Tasks" 
    /// at http://msdn.microsoft.com/en-us/magazine/ff959203.aspx under the "Converting an Event-Based Pattern" section,
    /// and follows the general TAP guidelines found at http://www.microsoft.com/en-us/download/details.aspx?id=19957.
    /// </remarks>
    public static class WebClientExtension
    {
        private static readonly Task<byte[]> _preCancelledTask;

        /// <summary>
        /// Constant. Specified an infinite timeout duration. This is a TimeSpan of negative one (-1) milliseconds.
        /// </summary>
        public static TimeSpan DefaultTimeout => TimeSpan.FromMilliseconds(-1);

        /// <summary>
        /// Static constructor. 
        /// </summary>
        static WebClientExtension()
        {
            var _taskCompletionSource = new TaskCompletionSource<byte[]>();
            _taskCompletionSource.SetCanceled();

            WebClientExtension._preCancelledTask = _taskCompletionSource.Task;
        }

        /// <summary>
        /// Asynchronously downloads the resource with the specified URI as a Byte array limited by the specified timeout.
        /// </summary>
        /// <param name="_webClient">The client with which to download the specified resource.</param>
        /// <param name="_uri">The address of the resource to download.</param>
        /// <param name="_timeout">A TimeSpan specifying the amount of time to wait for a response before aborting the request.
        /// The specify an infinite timeout, pass a TimeSpan with a TotalMillisecond value of Timeout.Infinite.
        /// When a request is aborted due to a timeout the returned task will transition to the Faulted state with a TimeoutException.</param>
        /// <returns>A Task with the future value of the downloaded string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the client or address parameters.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value of timeout is neither a positive value or infinite.</exception>
        public static Task<byte[]> DownloadDataTaskAsync(this WebClient _webClient, Uri _uri, TimeSpan _timeout)
        {
            if (_webClient == null) 
                throw new ArgumentNullException(nameof(_webClient));
          
            if (_uri == null) 
                throw new ArgumentNullException(nameof(_uri));

            return _webClient.DownloadDataTaskAsync(_uri, _timeout, CancellationToken.None);
        }
        
        /// <summary>
        /// Asynchronously downloads the resource with the specified URI as a Byte array and allows cancelling the operation. 
        /// Note that this overload specifies an infinite timeout.
        /// </summary>
        /// <param name="_webClient">The client with which to download the specified resource.</param>
        /// <param name="_uri">The address of the resource to download.</param>
        /// <param name="_token">A cancellation token that can be used to cancel the pending asynchronous task.</param>
        /// <returns>A Task with the future value of the downloaded string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the client or address parameters.</exception>
        public static Task<byte[]> DownloadDataTaskAsync(this WebClient _webClient, Uri _uri, CancellationToken _token)
        {
            if (_webClient == null) 
                throw new ArgumentNullException(nameof(_webClient));
           
            if (_uri == null) 
                throw new ArgumentNullException(nameof(_uri));

            return _webClient.DownloadDataTaskAsync(_uri, DefaultTimeout, _token);
        }
        
        /// <summary>
        /// Asynchronously downloads the resource with the specified URI as a Byte array limited by the specified timeout and allows cancelling the operation.
        /// </summary>
        /// <param name="_webClient">The client with which to download the specified resource.</param>
        /// <param name="_uri">The address of the resource to download.</param>
        /// <param name="_timeout">A TimeSpan specifying the amount of time to wait for a response before aborting the request.
        /// The specify an infinite timeout, pass a TimeSpan with a TotalMillisecond value of Timeout.Infinite.
        /// When a request is aborted due to a timeout the returned task will transition to the Faulted state with a TimeoutException.</param>
        /// <param name="_token">A cancellation token that can be used to cancel the pending asynchronous task.</param>
        /// <returns>A Task with the future value of the downloaded string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the client or address parameters.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value of timeout is neither a positive value or infinite.</exception>
        public static Task<byte[]> DownloadDataTaskAsync(this WebClient _webClient, Uri _uri, TimeSpan _timeout, CancellationToken _token)
        {
            if (_webClient == null) 
                throw new ArgumentNullException(nameof(_webClient));
           
            if (_uri == null) 
                throw new ArgumentNullException(nameof(_uri));
           
            if (_timeout.TotalMilliseconds < 0 && _timeout != DefaultTimeout)
                throw new ArgumentOutOfRangeException(nameof(_uri), _timeout, "The timeout value must be a positive or equal to InfiniteTimeout.");

            if (_token.IsCancellationRequested)
                return _preCancelledTask;

            var _taskCompletionSource = new TaskCompletionSource<byte[]>();
            var _cancellationTokenSource = new CancellationTokenSource();

            if (_timeout != DefaultTimeout)
            {
                Task.Delay(_timeout, _cancellationTokenSource.Token).ContinueWith(_x =>
                    {
                        _taskCompletionSource.TrySetException(new TimeoutException($"The request has exceeded the timeout limit of {_timeout} and has been aborted."));
                        _webClient.CancelAsync();
                    }, TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.NotOnCanceled);
            }

            DownloadDataCompletedEventHandler _completedHandler = null;
            _completedHandler = (_sender, _args) =>
             {
                 _webClient.DownloadDataCompleted -= _completedHandler;
                 _cancellationTokenSource.Cancel();

                 if (_args.Cancelled)
                 {
                     _taskCompletionSource.TrySetCanceled();
                 }
                 else if (_args.Error != null)
                 {
                     _taskCompletionSource.TrySetException(_args.Error);
                 }
                 else
                 {
                     _taskCompletionSource.TrySetResult(_args.Result);
                 }
             };

            _webClient.DownloadDataCompleted += _completedHandler;

            try
            {
                _webClient.DownloadDataAsync(_uri);
            }
            catch
            {
                _webClient.DownloadDataCompleted -= _completedHandler;
                throw;
            }

            _token.Register(() =>
            {
                _cancellationTokenSource.Cancel();
                _webClient.CancelAsync();
            });

            return _taskCompletionSource.Task;
        }
    }
}
