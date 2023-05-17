using GoogleApi.Entities;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Exceptions;
using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.Common.Enums.Converters;
using GoogleApi.Entities.Search.Common.Converters;
using GoogleApi.Entities.Translate.Common.Enums.Converters;
using Language = GoogleApi.Entities.Translate.Common.Enums.Language;

namespace GoogleApi;

/// <summary>
/// Http Engine.
/// </summary>
public class HttpEngine
{
    /// <summary>
    /// Json Serializer Options.
    /// </summary>
    protected static readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
        Converters =
        {
            new BooleanJsonConverter(),
            new EnumJsonConverterFactory<Language, LanguageEnumConverter>(JsonNamingPolicy.CamelCase, true),
            new EnumJsonConverterFactory<PlaceLocationType, PlaceLocationTypeEnumConverter>(JsonNamingPolicy.CamelCase, true),
            new EnumJsonConverterFactory<AddressComponentType, AddressComponentTypeEnumConverter>(JsonNamingPolicy.CamelCase, true),
            new EnumJsonConverterFactory(JsonNamingPolicy.CamelCase, true),
            new SortExpressionJsonConverter(),
            new JsonStringEnumConverter()
        },
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
}

/// <summary>
/// Http Engine.
/// Manages the http connections, and is responsible for invoking request and handling responses.
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public class HttpEngine<TRequest, TResponse> : HttpEngine
    where TRequest : IRequest, new()
    where TResponse : IResponse, new()
{
    private readonly HttpClient httpClient;

    /// <summary>
    /// Constructor.
    /// </summary>
    protected HttpEngine()
        : this(HttpClientFactory.CreateDefaultHttpClient())
    {

    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="httpClient">The <see cref="httpClient"/>.</param>
    protected HttpEngine(HttpClient httpClient)
    {
        this.httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    /// <summary>
    /// Query.
    /// </summary>
    /// <param name="request">The request that will be sent.</param>
    /// <param name="httpEngineOptions">The <see cref="HttpEngineOptions"/>.</param>
    /// <returns>The <see cref="IResponse"/>.</returns>
    public TResponse Query(TRequest request, HttpEngineOptions httpEngineOptions = null)
    {
        request = request ?? throw new ArgumentNullException(nameof(request));

        httpEngineOptions ??= new HttpEngineOptions();

        try
        {
            using var result = this.ProcessRequest(request);
            var response = this.ProcessResponse(result);

            switch (response.Status)
            {
                case Status.Ok:
                case Status.NotFound:
                case Status.ZeroResults:
                    return response;

                case Status.InvalidRequest:
                case Status.InvalidArgument:
                case Status.PermissionDenied:
                    if (!httpEngineOptions.ThrowOnInvalidRequest)
                    {
                        return response;
                    }

                    throw new GoogleApiException($"{response.Status}: {response.ErrorMessage ?? "No message"}")
                    {
                        Status = response.Status
                    };

                default:
                    throw new GoogleApiException($"{response.Status}: {response.ErrorMessage ?? "No message"}")
                    {
                        Status = response.Status
                    };
            }
        }
        catch (Exception ex)
        {
            if (ex is GoogleApiException)
                throw;

            throw new GoogleApiException(ex.Message, ex)
            {
                Status = Status.UnknownError
            };
        }
    }

    /// <summary>
    /// Query Async.
    /// </summary>
    /// <param name="request">The request that will be sent.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>The <see cref="Task{T}"/>.</returns>
    public async Task<TResponse> QueryAsync(TRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var taskCompletion = new TaskCompletionSource<TResponse>();

        await this.ProcessRequestAsync(request, cancellationToken)
            .ContinueWith(async x =>
            {
                try
                {
                    if (x.IsCanceled)
                    {
                        taskCompletion
                            .SetCanceled();
                    }
                    else if (x.IsFaulted)
                    {
                        throw x.Exception ?? new Exception();
                    }
                    else
                    {
                        var result = await x;
                        var response = await this.ProcessResponseAsync(result).ConfigureAwait(false);

                        switch (response.Status)
                        {
                            case Status.Ok:
                            case Status.NotFound:
                            case Status.ZeroResults:
                                taskCompletion.SetResult(response);
                                break;

                            default:
                                throw new GoogleApiException($"{response.Status}: {response.ErrorMessage}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex is GoogleApiException)
                    {
                        taskCompletion.SetException(ex);
                    }
                    else
                    {
                        var baseException = ex.GetBaseException();
                        var exception = new GoogleApiException(baseException.Message, baseException);

                        taskCompletion.SetException(exception);
                    }
                }
            }, cancellationToken)
            .ConfigureAwait(false);

        return await taskCompletion.Task;
    }

    /// <summary>
    /// Query Async.
    /// </summary>
    /// <param name="request">The request that will be sent.</param>
    /// <param name="httpEngineOptions">The <see cref="HttpEngineOptions"/></param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>The <see cref="Task{T}"/>.</returns>
    public async Task<TResponse> QueryAsync(TRequest request, HttpEngineOptions httpEngineOptions, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        httpEngineOptions ??= new HttpEngineOptions();

        var taskCompletion = new TaskCompletionSource<TResponse>();

        await this.ProcessRequestAsync(request, cancellationToken)
            .ContinueWith(async x =>
            {
                try
                {
                    if (x.IsCanceled)
                    {
                        taskCompletion
                            .SetCanceled();
                    }
                    else if (x.IsFaulted)
                    {
                        throw x.Exception ?? new Exception();
                    }
                    else
                    {
                        var result = await x;
                        var response = await this.ProcessResponseAsync(result).ConfigureAwait(false);

                        switch (response.Status)
                        {
                            case Status.Ok:
                            case Status.NotFound:
                            case Status.ZeroResults:
                                taskCompletion.SetResult(response);
                                break;

                            case Status.InvalidRequest:
                            case Status.InvalidArgument:
                                if (!httpEngineOptions.ThrowOnInvalidRequest)
                                {
                                    taskCompletion.SetResult(response);
                                    break;
                                }

                                throw new GoogleApiException($"{response.Status}: {response.ErrorMessage ?? "No message"}")
                                {
                                    Status = response.Status
                                };

                            default:
                                throw new GoogleApiException($"{response.Status}: {response.ErrorMessage ?? "No message"}")
                                {
                                    Status = response.Status
                                };
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex is GoogleApiException)
                    {
                        taskCompletion.SetException(ex);
                    }
                    else
                    {
                        var baseException = ex.GetBaseException();
                        var exception = new GoogleApiException(baseException.Message, baseException);

                        taskCompletion.SetException(exception);
                    }
                }
            }, cancellationToken)
            .ConfigureAwait(false);

        return await taskCompletion.Task;
    }

    private HttpResponseMessage ProcessRequest(TRequest request)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        return this.ProcessRequestAsync(request).Result;
    }
    private TResponse ProcessResponse(HttpResponseMessage httpResponse)
    {
        if (httpResponse == null)
            throw new ArgumentNullException(nameof(httpResponse));

        return this.ProcessResponseAsync(httpResponse).Result;
    }
    private async Task<HttpResponseMessage> ProcessRequestAsync(TRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var uri = request
            .GetUri();

        var method = request is IRequestQueryString
            ? HttpMethod.Get
            : HttpMethod.Post;

        using var httpRequestMessage = new HttpRequestMessage(method, uri);

        switch (request)
        {
            case IRequestQueryString:
            {
                return await this.httpClient
                    .SendAsync(httpRequestMessage, cancellationToken);
            }

            case IRequestJson:
            {
                var serializeObject = JsonSerializer.Serialize(request, HttpEngine.jsonSerializerOptions);

                httpRequestMessage.Content = new StringContent(serializeObject, Encoding.UTF8);

                if (request is IRequestJsonX jsonX)
                {
                    httpRequestMessage.Headers
                        .Add(GoogleHttpHeaders.API_KEY_HEADER, request.Key);

                    httpRequestMessage.Headers
                        .Add(GoogleHttpHeaders.FIELD_MASK_HEADER, jsonX.FieldMask ?? "*");
                }

                return await this.httpClient
                    .SendAsync(httpRequestMessage, cancellationToken)
                    .ConfigureAwait(false);
            }
        }

        throw new NotSupportedException();
    }
    private async Task<TResponse> ProcessResponseAsync(HttpResponseMessage httpResponse)
    {
        if (httpResponse == null)
            throw new ArgumentNullException(nameof(httpResponse));

        var response = new TResponse();

        switch (response)
        {
            case BaseResponseStream streamResponse:
            {
                streamResponse.Buffer = await httpResponse.Content
                    .ReadAsByteArrayAsync()
                    .ConfigureAwait(false);

                response = (TResponse)(IResponse)streamResponse;

                break;
            }

            default:
            {
                var rawJson = await httpResponse.Content
                    .ReadAsStringAsync()
                    .ConfigureAwait(false);

                response = JsonSerializer.Deserialize<TResponse>(rawJson, HttpEngine.jsonSerializerOptions) ?? new TResponse();
                response.RawJson = rawJson;

                break;
            }
        }

        response.RawQueryString = httpResponse.RequestMessage?.RequestUri?.PathAndQuery;
        response.Status = httpResponse.IsSuccessStatusCode
            ? response.Status ?? Status.Ok
            : response.Status ?? Status.HttpError;

        return response;
    }
}