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
        public static readonly TimeSpan _infiniteTimeout = TimeSpan.FromMilliseconds(-1);

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
        /// <param name="_client">The client with which to download the specified resource.</param>
        /// <param name="_address">The address of the resource to download.</param>
        /// <param name="_timeout">A TimeSpan specifying the amount of time to wait for a response before aborting the request.
        /// The specify an infinite timeout, pass a TimeSpan with a TotalMillisecond value of Timeout.Infinite.
        /// When a request is aborted due to a timeout the returned task will transition to the Faulted state with a TimeoutException.</param>
        /// <returns>A Task with the future value of the downloaded string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the client or address parameters.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value of timeout is neither a positive value or infinite.</exception>
        public static Task<byte[]> DownloadDataTaskAsync(this WebClient _client, Uri _address, TimeSpan _timeout)
        {
            if (_client == null) 
                throw new ArgumentNullException("_client");
          
            if (_address == null) 
                throw new ArgumentNullException("_address");

            return _client.DownloadDataTaskAsync(_address, _timeout, CancellationToken.None);
        }
        /// <summary>
        /// Asynchronously downloads the resource with the specified URI as a Byte array and allows cancelling the operation. 
        /// Note that this overload specifies an infinite timeout.
        /// </summary>
        /// <param name="_client">The client with which to download the specified resource.</param>
        /// <param name="_address">The address of the resource to download.</param>
        /// <param name="_token">A cancellation token that can be used to cancel the pending asynchronous task.</param>
        /// <returns>A Task with the future value of the downloaded string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the client or address parameters.</exception>
        public static Task<byte[]> DownloadDataTaskAsync(this WebClient _client, Uri _address, CancellationToken _token)
        {
            if (_client == null) 
                throw new ArgumentNullException("_client");
           
            if (_address == null) 
                throw new ArgumentNullException("_address");

            return _client.DownloadDataTaskAsync(_address, _infiniteTimeout, _token);
        }
        /// <summary>
        /// Asynchronously downloads the resource with the specified URI as a Byte array limited by the specified timeout and allows cancelling the operation.
        /// </summary>
        /// <param name="_client">The client with which to download the specified resource.</param>
        /// <param name="_address">The address of the resource to download.</param>
        /// <param name="_timeout">A TimeSpan specifying the amount of time to wait for a response before aborting the request.
        /// The specify an infinite timeout, pass a TimeSpan with a TotalMillisecond value of Timeout.Infinite.
        /// When a request is aborted due to a timeout the returned task will transition to the Faulted state with a TimeoutException.</param>
        /// <param name="_token">A cancellation token that can be used to cancel the pending asynchronous task.</param>
        /// <returns>A Task with the future value of the downloaded string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the client or address parameters.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value of timeout is neither a positive value or infinite.</exception>
        public static Task<byte[]> DownloadDataTaskAsync(this WebClient _client, Uri _address, TimeSpan _timeout, CancellationToken _token)
        {
            if (_client == null) 
                throw new ArgumentNullException("_client");
           
            if (_address == null) 
                throw new ArgumentNullException("_address");
           
            if (_timeout.TotalMilliseconds < 0 && _timeout != _infiniteTimeout)
                throw new ArgumentOutOfRangeException("_address", _timeout, "The timeout value must be a positive or equal to InfiniteTimeout.");

            if (_token.IsCancellationRequested)
                return _preCancelledTask;

            var _taskCompletionSource = new TaskCompletionSource<byte[]>();
            var _cancellationTokenSource = new CancellationTokenSource();

            if (_timeout != _infiniteTimeout)
            {
                Task.Delay(_timeout, _cancellationTokenSource.Token).ContinueWith(_x =>
                    {
                        _taskCompletionSource.TrySetException(new TimeoutException(string.Format("The request has exceeded the timeout limit of {0} and has been aborted.", _timeout)));
                        _client.CancelAsync();
                    }, TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.NotOnCanceled);
            }

            DownloadDataCompletedEventHandler _completedHandler = null;
            _completedHandler = (_sender, _args) =>
             {
                 _client.DownloadDataCompleted -= _completedHandler;
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

            _client.DownloadDataCompleted += _completedHandler;

            try
            {
                _client.DownloadDataAsync(_address);
            }
            catch
            {
                _client.DownloadDataCompleted -= _completedHandler;
                throw;
            }

            _token.Register(() =>
            {
                _cancellationTokenSource.Cancel();
                _client.CancelAsync();
            });

            return _taskCompletionSource.Task;
        }
    }
}
