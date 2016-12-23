using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Details.Response;
using GoogleApi.Entities.Places.Photos.Request;
using GoogleApi.Entities.Places.Photos.Response;
using GoogleApi.Extensions;
using Newtonsoft.Json;

namespace GoogleApi.Engine
{
    /// <summary>
    /// Generic base class for facade engine.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public abstract class GenericEngine<TRequest, TResponse> : GenericEngine
        where TRequest : BaseRequest, new()
        where TResponse : IResponseFor
	{
        /// <summary>
        /// Default static constructor.
        /// </summary>
        static GenericEngine()
        {
            var _baseUrl = new TRequest().BaseUrl;

            GenericEngine.HttpServicePoint = ServicePointManager.FindServicePoint(new Uri("http://" + _baseUrl));
            GenericEngine.HttpsServicePoint = ServicePointManager.FindServicePoint(new Uri("https://" + _baseUrl));
        }

		protected internal static TResponse QueryGoogleApi(TRequest _request, TimeSpan _timeout)
		{
			if (_request == null)
				throw new ArgumentNullException("_request");

			try
			{
                var _uri = _request.GetUri();
                var _webClientEx = new WebClientEx(_timeout);
                
                if (_request.IsJson)
			    {
                    _webClientEx.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                    var _json = JsonConvert.SerializeObject(_request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                    var _uploadString = _webClientEx.UploadString(_uri, "POST", _json);

                    return GenericEngine<TRequest, TResponse>.Deserialize(_uploadString);
			    }

                var _downloadData = _webClientEx.DownloadData(_uri);
                return GenericEngine<TRequest, TResponse>.Deserialize(_downloadData);
			}
			catch (WebException _ex)
			{
                if (GenericEngine.IndicatesAuthenticationFailed(_ex))
                    throw new AuthenticationException(GenericEngine.AUTHENTICATION_FAILED_MESSAGE, _ex);

				if (_ex.Status == WebExceptionStatus.Timeout)
					throw new TimeoutException(string.Format("The request has exceeded the timeout limit of {0} and has been aborted.", _timeout));

				throw;
			}
		}
        protected internal static Task<TResponse> QueryGoogleApiAsync(TRequest _request, TimeSpan _timeout, CancellationToken _token = default(CancellationToken))
        {
            if (_request == null)
                throw new ArgumentNullException("_request");

            var _taskCompletionSource = new TaskCompletionSource<TResponse>();

            new WebClient().DownloadDataTaskAsync(_request.GetUri(), _timeout, _token)
                .ContinueWith(_t => GenericEngine<TRequest, TResponse>.DownloadDataComplete(_t, _taskCompletionSource), TaskContinuationOptions.ExecuteSynchronously);

            return _taskCompletionSource.Task;
        }

        private static TResponse Deserialize(byte[] _serializedObject)
        {
            if (_serializedObject == null)
                throw new ArgumentNullException("_serializedObject");

            var _serializer = new DataContractJsonSerializer(typeof(TResponse));
            var _stream = new MemoryStream(_serializedObject, false);

            return (TResponse)_serializer.ReadObject(_stream);
        }
        private static TResponse Deserialize(string _serializedObject)
        {
            if (_serializedObject == null)
                throw new ArgumentNullException("_serializedObject");

            return JsonConvert.DeserializeObject<TResponse>(_serializedObject);
        }

        private static void DownloadDataComplete(Task<byte[]> _task, TaskCompletionSource<TResponse> _completionSource)
        {
            if (_task == null) 
                throw new ArgumentNullException("_task");
            
            if (_completionSource == null) 
                throw new ArgumentNullException("_completionSource");

            if (_task.IsCanceled)
			{
				_completionSource.SetCanceled();
			}
			else if (_task.IsFaulted)
			{
                if (_task.Exception != null && GenericEngine.IndicatesAuthenticationFailed(_task.Exception.InnerException))
			    {
                    _completionSource.SetException(new AuthenticationException(GenericEngine.AUTHENTICATION_FAILED_MESSAGE, _task.Exception.InnerException));
			    }
				else if (_task.Exception != null)
				{
				    _completionSource.SetException(_task.Exception.InnerException ?? _task.Exception);
				}
			}
			else
			{
                var _deserialize = GenericEngine<TRequest, TResponse>.Deserialize(_task.Result);
				_completionSource.SetResult(_deserialize);
			}
        }
	}
}