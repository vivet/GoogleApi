using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Places.Photos.Response;
using GoogleApi.Extensions;
using GoogleApi.Web;
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
        /// Determines the maximum number of concurrent HTTP connections to open to this engine's host address. The default value is 2 connections.
        /// </summary>
        /// <remarks>
        /// This value is determined by the ServicePointManager and is shared across other engines that use the same host address.
        /// </remarks>
        public static int HttpConnectionLimit
        {
            get
            {
                return GenericEngine.HttpServicePoint.ConnectionLimit;
            }
            set
            {
                GenericEngine.HttpServicePoint.ConnectionLimit = value;
            }
        }
        
        /// <summary>
        /// Determines the maximum number of concurrent HTTPS connections to open to this engine's host address. The default value is 2 connections.
        /// </summary>
        /// <remarks>
        /// This value is determined by the ServicePointManager and is shared across other engines that use the same host address.
        /// </remarks>
        public static int HttpsConnectionLimit
        {
            get
            {
                return GenericEngine.HttpsServicePoint.ConnectionLimit;
            }
            set
            {
                GenericEngine.HttpsServicePoint.ConnectionLimit = value;
            }
        }
        
        /// <summary>
        /// Default static constructor.
        /// </summary>
        static GenericEngine()
        {
            var _baseUrl = new TRequest().BaseUrl;

            GenericEngine.HttpServicePoint = ServicePointManager.FindServicePoint(new Uri("http://" + _baseUrl));
            GenericEngine.HttpsServicePoint = ServicePointManager.FindServicePoint(new Uri("https://" + _baseUrl));
        }

        /// <summary>
        /// Query Google.
        /// </summary>
        /// <param name="_request"></param>
        /// <param name="_timeout"></param>
        /// <returns>TResponse</returns>
		protected internal static TResponse QueryGoogleApi(TRequest _request, TimeSpan _timeout)
		{
			if (_request == null)
				throw new ArgumentNullException("_request");

            if (_request is IJsonRequest)
                return GenericEngine<TRequest, TResponse>.JsonRequest(_request, _timeout);

            if (_request is IQueryStringRequest)
                return GenericEngine<TRequest, TResponse>.QuerystringRequest(_request, _timeout);

            throw new InvalidOperationException("Invalid Request. Request class missing Request interface implementation.");
		}
        
        /// <summary>
        /// Query Google Async.
        /// </summary>
        /// <param name="_request"></param>
        /// <param name="_timeout"></param>
        /// <param name="_token"></param>
        /// <returns>Task[TResponse]</returns>
        protected internal static Task<TResponse> QueryGoogleApiAsync(TRequest _request, TimeSpan _timeout, CancellationToken _token = default(CancellationToken))
        {
            if (_request == null)
                throw new ArgumentNullException("_request");
   
            var _uri = _request.GetUri();
            var _webClient = new WebClientTimeout(_timeout);
            var _taskCompletionSource = new TaskCompletionSource<TResponse>();

            if (_request is IJsonRequest)
            {
                _webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                var _jsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                var _jsonString = JsonConvert.SerializeObject(_request, _jsonSerializerSettings);

                _webClient.UploadStringTaskAsync(_uri, WebRequestMethods.Http.Post, _jsonString)
                    .ContinueWith(_x => GenericEngine<TRequest, TResponse>.JsonRequestAsync(_x, _taskCompletionSource), TaskContinuationOptions.ExecuteSynchronously);

                return _taskCompletionSource.Task;
            }
            if (_request is IQueryStringRequest)
            {
                _webClient.DownloadDataTaskAsync(_uri, _timeout, _token)
                    .ContinueWith(_x => GenericEngine<TRequest, TResponse>.QuerystringRequestAsync(_x, _taskCompletionSource), TaskContinuationOptions.ExecuteSynchronously);

                return _taskCompletionSource.Task;
            }

            throw new InvalidOperationException("Invalid Request. Request class missing Request interface implementation.");
        }

        private static TResponse JsonRequest(TRequest _request, TimeSpan _timeout)
        {
            if (_request == null)
                throw new ArgumentNullException("_request");

            var _webClient = new WebClientTimeout(_timeout);
            _webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");

            var _uri = _request.GetUri();
            var _jsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            var _jsonString = JsonConvert.SerializeObject(_request, _jsonSerializerSettings);
            var _uploadString = _webClient.UploadString(_uri, WebRequestMethods.Http.Post, _jsonString);
            
            return GenericEngine<TRequest, TResponse>.Deserialize(_uploadString);
        }
        private static TResponse QuerystringRequest(TRequest _request, TimeSpan _timeout)
        {
            if (_request == null)
                throw new ArgumentNullException("_request");

            var _uri = _request.GetUri();
            var _webClient = new WebClientTimeout(_timeout);
            var _downloadData = _webClient.DownloadData(_uri);

            return GenericEngine<TRequest, TResponse>.Deserialize(_downloadData);
        }  

        private static TaskCompletionSource<TResponse> JsonRequestAsync(Task<string> _task, TaskCompletionSource<TResponse> _taskCompletionSource)
        {
            if (_task == null)
                throw new ArgumentNullException("_task");

            if (_taskCompletionSource == null)
                throw new ArgumentNullException("_taskCompletionSource");

            if (_task.IsCanceled)
            {
                _taskCompletionSource.SetCanceled();
            }
            else if (_task.IsFaulted)
            {
                var _exception = _task.Exception == null ? new NullReferenceException("_task.Exception") : _task.Exception.InnerException ?? _task.Exception;
                _taskCompletionSource.SetException(_exception);
            }
            else
            {
                var _deserialize = GenericEngine<TRequest, TResponse>.Deserialize(_task.Result);
                _taskCompletionSource.SetResult(_deserialize);
            }

            return _taskCompletionSource;
        }
        private static TaskCompletionSource<TResponse> QuerystringRequestAsync(Task<byte[]> _task, TaskCompletionSource<TResponse> _taskCompletionSource)
        {
            if (_task == null)
                throw new ArgumentNullException("_task");

            if (_taskCompletionSource == null)
                throw new ArgumentNullException("_taskCompletionSource");

            if (_task.IsCanceled)
            {
                _taskCompletionSource.SetCanceled();
            }
            else if (_task.IsFaulted)
            {
                var _exception = _task.Exception == null ? new NullReferenceException("_task.Exception") : _task.Exception.InnerException ?? _task.Exception;
                _taskCompletionSource.SetException(_exception);
            }
            else
            {
                var _deserialize = GenericEngine<TRequest, TResponse>.Deserialize(_task.Result);
                _taskCompletionSource.SetResult(_deserialize);
            }

            return _taskCompletionSource;
        }

        private static TResponse Deserialize(byte[] _serializedObject)
        {
            if (_serializedObject == null)
                throw new ArgumentNullException("_serializedObject");

            // TODO: Hack (PlacesPhotosResponse).
            if (typeof (TResponse) == typeof (PlacesPhotosResponse))
                return GenericEngine<TRequest, TResponse>.Deserialize("{\"photo\":\"" + Convert.ToBase64String(_serializedObject) + "\"}");

            var _serializer = new DataContractJsonSerializer(typeof(TResponse));
            var _memoryStream = new MemoryStream(_serializedObject, false);

            return (TResponse)_serializer.ReadObject(_memoryStream);
        }
        private static TResponse Deserialize(string _serializedObject)
        {
            if (_serializedObject == null)
                throw new ArgumentNullException("_serializedObject");

            return JsonConvert.DeserializeObject<TResponse>(_serializedObject);
        }
    }
}