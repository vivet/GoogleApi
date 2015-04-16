using System;
using System.CodeDom;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Extensions;
using GoogleApi.Helpers;
using GoogleApi.Http;

namespace GoogleApi.Engine
{
	public abstract class GenericEngine<TRequest, TResponse> where TRequest : BaseRequest, new() where TResponse : IResponseFor
	{
        private const string AuthenticationFailedMessage = "The request to Google API failed with HTTP error '(403) Forbidden', which usually indicates that the provided client ID or signing key is invalid or expired.";

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
			var baseUrl = new TRequest().BaseUrl;
			HttpServicePoint = ServicePointManager.FindServicePoint(new Uri("http://" + baseUrl));
			HttpsServicePoint = ServicePointManager.FindServicePoint(new Uri("https://" + baseUrl));
		}

		protected internal static TResponse QueryGoogleApi(TRequest request, TimeSpan timeout)
		{
			if (request == null)
				throw new ArgumentNullException("request");

			try
			{
				var data = new WebClientEx(timeout).DownloadData(request.GetUri());
				return Deserialize(data);
			}
			catch (WebException ex)
			{
				if (IndicatesAuthenticationFailed(ex))
					throw new AuthenticationException(AuthenticationFailedMessage, ex);

				if (ex.Status == WebExceptionStatus.Timeout)
					throw new TimeoutException(string.Format("The request has exceeded the timeout limit of {0} and has been aborted.", timeout));

				throw;
			}
		}
        protected internal static Task<TResponse> QueryGoogleApiAsync(TRequest request, TimeSpan timeout, CancellationToken token = default(CancellationToken))
        {
            if (request == null)
                throw new ArgumentNullException("request");

            var completionSource = new TaskCompletionSource<TResponse>();

            new WebClient().DownloadDataTaskAsync(request.GetUri(), timeout, token)
                .ContinueWith(t => DownloadDataComplete(t, completionSource), TaskContinuationOptions.ExecuteSynchronously);

            return completionSource.Task;
        }

		protected static IAsyncResult BeginQueryGoogleApi(TRequest request, AsyncCallback asyncCallback, object state)
		{
			// Must use TaskCompletionSource because in .NET 4.0 there's no overload of ContinueWith that accepts a state object (used in IAsyncResult).
			// Such overloads have been added in .NET 4.5, so this can be removed if/when the project is promoted to that version.
			// An example of such an added overload can be found at: http://msdn.microsoft.com/en-us/library/hh160386.aspx

			var completionSource = new TaskCompletionSource<TResponse>(state);
			QueryGoogleApiAsync(request).ContinueWith(t =>
														{
															if (t.IsFaulted && t.Exception != null)
															{
                                                                completionSource.SetException(t.Exception.InnerException);
															}
															else if (t.IsCanceled)
																completionSource.SetCanceled();
															else
																completionSource.SetResult(t.Result);

															asyncCallback(completionSource.Task);
														}, TaskContinuationOptions.ExecuteSynchronously);

			return completionSource.Task;
		}
		protected static TResponse EndQueryGoogleApi(IAsyncResult asyncResult)
		{
			return ((Task<TResponse>)asyncResult).Result;
		}
		protected static Task<TResponse> QueryGoogleApiAsync(TRequest request)
		{
			return QueryGoogleApiAsync(request, TimeSpan.FromMilliseconds(Timeout.Infinite), CancellationToken.None);
		}

        private static void DownloadDataComplete(Task<byte[]> task, TaskCompletionSource<TResponse> completionSource)
		{
			if (task.IsCanceled)
			{
				completionSource.SetCanceled();
			}
			else if (task.IsFaulted)
			{
				if (task.Exception != null && IndicatesAuthenticationFailed(task.Exception.InnerException))
					completionSource.SetException(new AuthenticationException(AuthenticationFailedMessage, task.Exception.InnerException));
				else if (task.Exception != null) completionSource.SetException(task.Exception.InnerException);
			}
			else
			{
				completionSource.SetResult(Deserialize(task.Result));
			}
		}
		private static TResponse Deserialize(byte[] serializedObject)
		{
		    var serializer = new DataContractJsonSerializer(typeof (TResponse));

		    using (var stream = new MemoryStream(serializedObject, false))
		    {
                return (TResponse)serializer.ReadObject(stream);   
		    }
		}
		private static bool IndicatesAuthenticationFailed(Exception ex)
		{
			var webException = ex as WebException;

			return webException != null &&
				   webException.Status == WebExceptionStatus.ProtocolError &&
				   ((HttpWebResponse)webException.Response).StatusCode == HttpStatusCode.Forbidden;
		}
	}
    
}