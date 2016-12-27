using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Places.Photos.Request;
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

            var _uri = _request.GetUri();
            var _webClientEx = new WebClientTimeout(_timeout);

            if (_request.IsJson)
            {
                _webClientEx.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                var _json = JsonConvert.SerializeObject(_request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                var _uploadString = _webClientEx.UploadString(_uri, "POST", _json);

                return GenericEngine<TRequest, TResponse>.Deserialize(_uploadString);
            }

            var _downloadData = _webClientEx.DownloadData(_uri);

            if (_request is PlacesPhotosRequest)
            {
                var _stream = new MemoryStream(_downloadData);
                var _response = new PlacesPhotosResponse
                {
                    Photo = _stream,
                    Status = Status.OK,
                    ErrorMessage = "OK"
                };
            }


            return GenericEngine<TRequest, TResponse>.Deserialize(_downloadData);
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

            if (_request.IsJson)
            {
                throw new NotImplementedException();
            }
            
            var _uri = _request.GetUri();
            var _webClientEx = new WebClient();
            var _taskCompletionSource = new TaskCompletionSource<TResponse>();

            _webClientEx.DownloadDataTaskAsync(_uri, _timeout, _token)
                .ContinueWith(_x =>
                {
                    if (_x.IsCanceled)
                    {
                        _taskCompletionSource.SetCanceled();
                    }
                    else if (_x.IsFaulted)
                    {
                        if (_x.Exception != null)
                            _taskCompletionSource.SetException(_x.Exception.InnerException ?? _x.Exception);
                    }
                    else
                    {
                        var _deserialize = GenericEngine<TRequest, TResponse>.Deserialize(_x.Result);
                        _taskCompletionSource.SetResult(_deserialize);
                    }

                }, TaskContinuationOptions.ExecuteSynchronously);

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
    }
}