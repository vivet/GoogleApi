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
        private static readonly Task<byte[]> PreCancelledTask;

        /// <summary>
        /// Constant. Specified an infinite timeout duration. This is a TimeSpan of negative one (-1) milliseconds.
        /// </summary>
        public static TimeSpan DefaultTimeout => TimeSpan.FromMilliseconds(-1);

        /// <summary>
        /// Static constructor. 
        /// </summary>
        static WebClientExtension()
        {
            var taskCompletionSource = new TaskCompletionSource<byte[]>();
            taskCompletionSource.SetCanceled();

            WebClientExtension.PreCancelledTask = taskCompletionSource.Task;
        }

        /// <summary>
        /// Asynchronously downloads the resource with the specified URI as a Byte array limited by the specified timeout.
        /// </summary>
        /// <param name="webClient">The client with which to download the specified resource.</param>
        /// <param name="uri">The address of the resource to download.</param>
        /// <param name="timeout">A TimeSpan specifying the amount of time to wait for a response before aborting the request.
        /// The specify an infinite timeout, pass a TimeSpan with a TotalMillisecond value of Timeout.Infinite.
        /// When a request is aborted due to a timeout the returned task will transition to the Faulted state with a TimeoutException.</param>
        /// <returns>A Task with the future value of the downloaded string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the client or address parameters.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value of timeout is neither a positive value or infinite.</exception>
        public static Task<byte[]> DownloadDataTaskAsync(this WebClient webClient, Uri uri, TimeSpan timeout)
        {
            if (webClient == null) 
                throw new ArgumentNullException(nameof(webClient));
          
            if (uri == null) 
                throw new ArgumentNullException(nameof(uri));

            return webClient.DownloadDataTaskAsync(uri, timeout, CancellationToken.None);
        }
        
        /// <summary>
        /// Asynchronously downloads the resource with the specified URI as a Byte array and allows cancelling the operation. 
        /// Note that this overload specifies an infinite timeout.
        /// </summary>
        /// <param name="webClient">The client with which to download the specified resource.</param>
        /// <param name="uri">The address of the resource to download.</param>
        /// <param name="token">A cancellation token that can be used to cancel the pending asynchronous task.</param>
        /// <returns>A Task with the future value of the downloaded string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the client or address parameters.</exception>
        public static Task<byte[]> DownloadDataTaskAsync(this WebClient webClient, Uri uri, CancellationToken token)
        {
            if (webClient == null) 
                throw new ArgumentNullException(nameof(webClient));
           
            if (uri == null) 
                throw new ArgumentNullException(nameof(uri));

            return webClient.DownloadDataTaskAsync(uri, DefaultTimeout, token);
        }
        
        /// <summary>
        /// Asynchronously downloads the resource with the specified URI as a Byte array limited by the specified timeout and allows cancelling the operation.
        /// </summary>
        /// <param name="webClient">The client with which to download the specified resource.</param>
        /// <param name="uri">The address of the resource to download.</param>
        /// <param name="timeout">A TimeSpan specifying the amount of time to wait for a response before aborting the request.
        /// The specify an infinite timeout, pass a TimeSpan with a TotalMillisecond value of Timeout.Infinite.
        /// When a request is aborted due to a timeout the returned task will transition to the Faulted state with a TimeoutException.</param>
        /// <param name="token">A cancellation token that can be used to cancel the pending asynchronous task.</param>
        /// <returns>A Task with the future value of the downloaded string.</returns>
        /// <exception cref="ArgumentNullException">Thrown when a null value is passed to the client or address parameters.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when the value of timeout is neither a positive value or infinite.</exception>
        public static Task<byte[]> DownloadDataTaskAsync(this WebClient webClient, Uri uri, TimeSpan timeout, CancellationToken token)
        {
            if (webClient == null) 
                throw new ArgumentNullException(nameof(webClient));
           
            if (uri == null) 
                throw new ArgumentNullException(nameof(uri));
           
            if (timeout.TotalMilliseconds < 0 && timeout != DefaultTimeout)
                throw new ArgumentOutOfRangeException(nameof(uri), timeout, "The timeout value must be a positive or equal to InfiniteTimeout.");

            if (token.IsCancellationRequested)
                return PreCancelledTask;

            var taskCompletionSource = new TaskCompletionSource<byte[]>();
            var cancellationTokenSource = new CancellationTokenSource();

            if (timeout != DefaultTimeout)
            {
                Task.Delay(timeout, cancellationTokenSource.Token).ContinueWith(x =>
                    {
                        taskCompletionSource.TrySetException(new TimeoutException($"The request has exceeded the timeout limit of {timeout} and has been aborted."));
                        webClient.CancelAsync();
                    }, TaskContinuationOptions.ExecuteSynchronously | TaskContinuationOptions.NotOnCanceled);
            }

            DownloadDataCompletedEventHandler completedHandler = null;
            completedHandler = (sender, args) =>
             {
                 webClient.DownloadDataCompleted -= completedHandler;
                 cancellationTokenSource.Cancel();

                 if (args.Cancelled)
                 {
                     taskCompletionSource.TrySetCanceled();
                 }
                 else if (args.Error != null)
                 {
                     taskCompletionSource.TrySetException(args.Error);
                 }
                 else
                 {
                     taskCompletionSource.TrySetResult(args.Result);
                 }
             };

            webClient.DownloadDataCompleted += completedHandler;

            try
            {
                webClient.DownloadDataAsync(uri);
            }
            catch
            {
                webClient.DownloadDataCompleted -= completedHandler;
                throw;
            }

            token.Register(() =>
            {
                cancellationTokenSource.Cancel();
                webClient.CancelAsync();
            });

            return taskCompletionSource.Task;
        }
    }
}
