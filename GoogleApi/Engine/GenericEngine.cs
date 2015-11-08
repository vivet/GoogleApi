using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Extensions;

namespace GoogleApi.Engine
{
    /// <summary>
    /// Generic base class for facade engine.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
	public abstract class GenericEngine<TRequest, TResponse> where TRequest : BaseRequest, new() where TResponse : IResponseFor
	{
        private const string AUTHENTICATION_FAILED_MESSAGE = "The request to Google API failed with HTTP error '(403) Forbidden', which usually indicates that the provided client ID or signing key is invalid or expired.";

        private static ServicePoint HttpServicePoint { get; set; }
        private static ServicePoint HttpsServicePoint { get; set; }
        
        /// <summary>
		/// Determines the maximum number of concurrent HTTP connections to open to this engine's host address. The default value is 2 connections.
		/// </summary>
		/// <remarks>
		/// This value is determined by the ServicePointManager and is shared across other engines that use the same host address.
		/// </remarks>
		public static int HttpConnectionLimit
		{
			get { return HttpServicePoint.ConnectionLimit; }
			set { HttpServicePoint.ConnectionLimit = value; }
		}
		/// <summary>
		/// Determines the maximum number of concurrent HTTPS connections to open to this engine's host address. The default value is 2 connections.
		/// </summary>
		/// <remarks>
		/// This value is determined by the ServicePointManager and is shared across other engines that use the same host address.
		/// </remarks>
		public static int HttpsConnectionLimit
		{
			get { return HttpsServicePoint.ConnectionLimit; }
			set { HttpsServicePoint.ConnectionLimit = value; }
		}

		static GenericEngine()
		{
			var _baseUrl = new TRequest().BaseUrl;
			HttpServicePoint = ServicePointManager.FindServicePoint(new Uri("http://" + _baseUrl));
			HttpsServicePoint = ServicePointManager.FindServicePoint(new Uri("https://" + _baseUrl));
		}

		protected internal static TResponse QueryGoogleApi(TRequest _request, TimeSpan _timeout)
		{
			if (_request == null)
				throw new ArgumentNullException("_request");

			try
			{
                var _uri = _request.GetUri();
                var _data = new WebClientEx(_timeout).DownloadData(_uri);

                return Deserialize(_data);
			}
			catch (WebException _ex)
			{
				if (IndicatesAuthenticationFailed(_ex))
					throw new AuthenticationException(AUTHENTICATION_FAILED_MESSAGE, _ex);

				if (_ex.Status == WebExceptionStatus.Timeout)
					throw new TimeoutException(string.Format("The request has exceeded the timeout limit of {0} and has been aborted.", _timeout));

				throw;
			}
		}
        protected internal static Task<TResponse> QueryGoogleApiAsync(TRequest _request, TimeSpan _timeout, CancellationToken _token = default(CancellationToken))
        {
            if (_request == null)
                throw new ArgumentNullException("_request");

            var _completionSource = new TaskCompletionSource<TResponse>();

            new WebClient().DownloadDataTaskAsync(_request.GetUri(), _timeout, _token)
                .ContinueWith(_t => DownloadDataComplete(_t, _completionSource), TaskContinuationOptions.ExecuteSynchronously);

            return _completionSource.Task;
        }

		protected static IAsyncResult BeginQueryGoogleApi(TRequest _request, AsyncCallback _asyncCallback, object _state)
		{
			// Must use TaskCompletionSource because in .NET 4.0 there's no overload of ContinueWith that accepts a state object (used in IAsyncResult).
			// Such overloads have been added in .NET 4.5, so this can be removed if/when the project is promoted to that version.
			// An example of such an added overload can be found at: http://msdn.microsoft.com/en-us/library/hh160386.aspx

			var _completionSource = new TaskCompletionSource<TResponse>(_state);
			QueryGoogleApiAsync(_request).ContinueWith(_t =>
														{
															if (_t.IsFaulted && _t.Exception != null)
															{
                                                                _completionSource.SetException(_t.Exception.InnerException);
															}
															else if (_t.IsCanceled)
																_completionSource.SetCanceled();
															else
																_completionSource.SetResult(_t.Result);

															_asyncCallback(_completionSource.Task);
														}, TaskContinuationOptions.ExecuteSynchronously);

			return _completionSource.Task;
		}
		protected static TResponse EndQueryGoogleApi(IAsyncResult _asyncResult)
		{
			return ((Task<TResponse>)_asyncResult).Result;
		}
		protected static Task<TResponse> QueryGoogleApiAsync(TRequest _request)
		{
			return QueryGoogleApiAsync(_request, TimeSpan.FromMilliseconds(Timeout.Infinite), CancellationToken.None);
		}

        private static void DownloadDataComplete(Task<byte[]> _task, TaskCompletionSource<TResponse> _completionSource)
		{
			if (_task.IsCanceled)
			{
				_completionSource.SetCanceled();
			}
			else if (_task.IsFaulted)
			{
				if (_task.Exception != null && IndicatesAuthenticationFailed(_task.Exception.InnerException))
					_completionSource.SetException(new AuthenticationException(AUTHENTICATION_FAILED_MESSAGE, _task.Exception.InnerException));
				else if (_task.Exception != null) _completionSource.SetException(_task.Exception.InnerException);
			}
			else
			{
				_completionSource.SetResult(Deserialize(_task.Result));
			}
		}
		private static TResponse Deserialize(byte[] _serializedObject)
		{
			var _serializer = new DataContractJsonSerializer(typeof(TResponse));
			var _stream = new MemoryStream(_serializedObject, false);

            return (TResponse)_serializer.ReadObject(_stream);
		}
		private static bool IndicatesAuthenticationFailed(Exception _ex)
		{
			var _webException = _ex as WebException;
			return _webException != null && _webException.Status == WebExceptionStatus.ProtocolError && ((HttpWebResponse)_webException.Response).StatusCode == HttpStatusCode.Forbidden;
		}
	}
}