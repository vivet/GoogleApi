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
            var baseUrl = new TRequest().BaseUrl;

            GenericEngine.HttpServicePoint = ServicePointManager.FindServicePoint(new Uri("http://" + baseUrl));
            GenericEngine.HttpsServicePoint = ServicePointManager.FindServicePoint(new Uri("https://" + baseUrl));
        }

        /// <summary>
        /// Query Google.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="timeout"></param>
        /// <returns>TResponse</returns>
		protected internal static TResponse QueryGoogleApi(TRequest request, TimeSpan timeout)
		{
			if (request == null)
				throw new ArgumentNullException(nameof(request));

            if (request is IJsonRequest)
                return GenericEngine<TRequest, TResponse>.JsonRequest(request, timeout);

            if (request is IQueryStringRequest)
                return GenericEngine<TRequest, TResponse>.QuerystringRequest(request, timeout);

            throw new InvalidOperationException("Invalid Request. Request class missing Request interface implementation.");
		}
        
        /// <summary>
        /// Query Google Async.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="timeout"></param>
        /// <param name="token"></param>
        /// <returns>Task[TResponse]</returns>
        protected internal static Task<TResponse> QueryGoogleApiAsync(TRequest request, TimeSpan timeout, CancellationToken token = default(CancellationToken))
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
   
            var uri = request.GetUri();
            var webClient = new WebClientTimeout(timeout);
            var taskCompletionSource = new TaskCompletionSource<TResponse>();

            if (request is IJsonRequest)
            {
                webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");

                var jsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
                var jsonString = JsonConvert.SerializeObject(request, jsonSerializerSettings);

                webClient.UploadStringTaskAsync(uri, WebRequestMethods.Http.Post, jsonString)
                    .ContinueWith(x => GenericEngine<TRequest, TResponse>.JsonRequestAsync(x, taskCompletionSource), TaskContinuationOptions.ExecuteSynchronously);

                return taskCompletionSource.Task;
            }
            if (request is IQueryStringRequest)
            {
                webClient.DownloadDataTaskAsync(uri, timeout, token)
                    .ContinueWith(x => GenericEngine<TRequest, TResponse>.QuerystringRequestAsync(x, taskCompletionSource), TaskContinuationOptions.ExecuteSynchronously);

                return taskCompletionSource.Task;
            }

            throw new InvalidOperationException("Invalid Request. Request class missing Request interface implementation.");
        }

        private static TResponse JsonRequest(TRequest request, TimeSpan timeout)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var webClient = new WebClientTimeout(timeout);
            webClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");

            var uri = request.GetUri();
            var jsonSerializerSettings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            var jsonString = JsonConvert.SerializeObject(request, jsonSerializerSettings);
            var uploadString = webClient.UploadString(uri, WebRequestMethods.Http.Post, jsonString);
            
            return GenericEngine<TRequest, TResponse>.Deserialize(uploadString);
        }
        private static TResponse QuerystringRequest(TRequest request, TimeSpan timeout)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var uri = request.GetUri();
            var webClient = new WebClientTimeout(timeout);
            var downloadData = webClient.DownloadData(uri);

            return GenericEngine<TRequest, TResponse>.Deserialize(downloadData);
        }  

        private static TaskCompletionSource<TResponse> JsonRequestAsync(Task<string> task, TaskCompletionSource<TResponse> taskCompletionSource)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            if (taskCompletionSource == null)
                throw new ArgumentNullException(nameof(taskCompletionSource));

            if (task.IsCanceled)
            {
                taskCompletionSource.SetCanceled();
            }
            else if (task.IsFaulted)
            {
                var exception = task.Exception == null ? new NullReferenceException("_task.Exception") : task.Exception.InnerException ?? task.Exception;
                taskCompletionSource.SetException(exception);
            }
            else
            {
                var deserialize = GenericEngine<TRequest, TResponse>.Deserialize(task.Result);
                taskCompletionSource.SetResult(deserialize);
            }

            return taskCompletionSource;
        }
        private static TaskCompletionSource<TResponse> QuerystringRequestAsync(Task<byte[]> task, TaskCompletionSource<TResponse> taskCompletionSource)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            if (taskCompletionSource == null)
                throw new ArgumentNullException(nameof(taskCompletionSource));

            if (task.IsCanceled)
            {
                taskCompletionSource.SetCanceled();
            }
            else if (task.IsFaulted)
            {
                var exception = task.Exception == null ? new NullReferenceException("_task.Exception") : task.Exception.InnerException ?? task.Exception;
                taskCompletionSource.SetException(exception);
            }
            else
            {
                var deserialize = GenericEngine<TRequest, TResponse>.Deserialize(task.Result);
                taskCompletionSource.SetResult(deserialize);
            }

            return taskCompletionSource;
        }

        private static TResponse Deserialize(byte[] serializedObject)
        {
            if (serializedObject == null)
                throw new ArgumentNullException(nameof(serializedObject));

            // TODO: Hack (PlacesPhotosResponse).
            if (typeof (TResponse) == typeof (PlacesPhotosResponse))
                return GenericEngine<TRequest, TResponse>.Deserialize("{\"photo\":\"" + Convert.ToBase64String(serializedObject) + "\"}");

            var serializer = new DataContractJsonSerializer(typeof(TResponse));
            var memoryStream = new MemoryStream(serializedObject, false);

            return (TResponse)serializer.ReadObject(memoryStream);
        }
        private static TResponse Deserialize(string serializedObject)
        {
            if (serializedObject == null)
                throw new ArgumentNullException(nameof(serializedObject));

            return JsonConvert.DeserializeObject<TResponse>(serializedObject);
        }
    }
}