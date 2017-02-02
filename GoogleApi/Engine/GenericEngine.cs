using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Places.Photos.Response;
using GoogleApi.Extensions;
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
        internal static Task<TResponse> QueryAsync(TRequest request, TimeSpan timeout, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var uri = request.GetUri();
            var httpClient = new HttpClient {Timeout = timeout};
            var jsonString = JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var taskCompletionSource = new TaskCompletionSource<TResponse>();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var task = request is IQueryStringRequest
                    ? httpClient.GetAsync(uri, cancellationToken)
                    : httpClient.PostAsync(uri, new StringContent(jsonString, Encoding.UTF8), cancellationToken);

            task.ContinueWith(x =>
            {
                if (x.IsCanceled)
                {
                    taskCompletionSource.SetCanceled();
                }
                else if (x.IsFaulted)
                {
                    var exception = x.Exception == null ? new NullReferenceException("task.Exception") : task.Exception?.InnerException ?? task.Exception ?? new Exception("error");
                    taskCompletionSource.SetException(exception);
                }
                else
                {
                    try
                    {
                        x.Result.EnsureSuccessStatusCode();

                        var result = x.Result;
                        var content = result.Content;
                        var data = content.ReadAsByteArrayAsync().Result;
                        var stream = new MemoryStream(data, false);
                        var response = typeof(TResponse) == typeof(PlacesPhotosResponse) ? (TResponse)(IResponseFor)new PlacesPhotosResponse { Photo = stream } : stream.JsonDeserialize<TResponse>();

                        taskCompletionSource.SetResult(response);
                    }
                    catch (Exception ex)
                    {
                        taskCompletionSource.SetException(ex);
                    }
                }
            }, TaskContinuationOptions.ExecuteSynchronously);

            return taskCompletionSource.Task;
        }
    }
}