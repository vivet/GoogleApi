using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Places.Photos.Response;
using Newtonsoft.Json;

namespace GoogleApi.Engine
{
    internal abstract class GenericEngine<TRequest, TResponse>
        where TRequest : BaseRequest, new()
        where TResponse : IResponseFor
    {
        internal static TResponse Query(TRequest request, TimeSpan timeout)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            return GenericEngine<TRequest, TResponse>.QueryAsync(request, timeout).Result;
        }

        internal static Task<TResponse> QueryAsync(TRequest request, TimeSpan timeout,
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var uri = request.GetUri();
            var httpClient = new HttpClient {Timeout = timeout};

            Task<HttpResponseMessage> task = null;
            if (request is IJsonRequest)
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonSerializerSettings = new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore};
                var jsonString = JsonConvert.SerializeObject(request, jsonSerializerSettings);

                task = httpClient.PostAsync(uri, new StringContent(jsonString, Encoding.UTF8), cancellationToken);
            }
            else if (request is IQueryStringRequest)
            {
                task = httpClient.GetAsync(uri, cancellationToken);
            }

            if (task == null)
                throw new InvalidOperationException(
                    "Invalid Request. Request class missing Request interface implementation.");

            var taskCompletionSource = new TaskCompletionSource<TResponse>();
            task.ContinueWith(
                x =>
                    GenericEngine<TRequest, TResponse>.ReadResponseAsync(x, taskCompletionSource,
                        request is IJsonRequest), TaskContinuationOptions.ExecuteSynchronously);

            return taskCompletionSource.Task;
        }

        internal static TaskCompletionSource<TResponse> ReadResponseAsync(Task<HttpResponseMessage> task,
            TaskCompletionSource<TResponse> taskCompletionSource, bool isJson)
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
                var exception = task.Exception == null
                    ? new NullReferenceException("task.Exception")
                    : task.Exception.InnerException ?? task.Exception;
                taskCompletionSource.SetException(exception);
            }
            else
            {
                try
                {
                    var result = task.Result;
                    var content = result.Content;

                    result.EnsureSuccessStatusCode();

                    var deserialize = isJson
                        ? GenericEngine<TRequest, TResponse>.Deserialize(content.ReadAsStringAsync().Result)
                        : GenericEngine<TRequest, TResponse>.Deserialize(content.ReadAsByteArrayAsync().Result);

                    taskCompletionSource.SetResult(deserialize);
                }
                catch (Exception ex)
                {
                    taskCompletionSource.SetException(ex);
                }
            }

            return taskCompletionSource;
        }

        private static TResponse Deserialize(string serializedObject)
        {
            if (serializedObject == null)
                throw new ArgumentNullException(nameof(serializedObject));

            return JsonConvert.DeserializeObject<TResponse>(serializedObject);
        }

        private static TResponse Deserialize(byte[] serializedObject)
        {
            if (serializedObject == null)
                throw new ArgumentNullException(nameof(serializedObject));

            // TODO: Hack (PlacesPhotosResponse).
            if (typeof(TResponse) == typeof(PlacesPhotosResponse))
                return
                    JsonConvert.DeserializeObject<TResponse>("{\"photo\":\"" + Convert.ToBase64String(serializedObject) +
                                                             "\"}");

            return JsonConvert.DeserializeObject<TResponse>(Convert.ToBase64String(serializedObject));
        }
    }
}