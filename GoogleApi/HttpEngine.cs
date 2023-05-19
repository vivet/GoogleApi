using GoogleApi.Entities;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;
using GoogleApi.Exceptions;
using System;
using System.Net;
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
    // BUG: look at default values and nullable value types for all new Api's

    /// <summary>
    /// Json Serializer Options.
    /// </summary>
    internal static readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, // BUG "Default" instead of "Null" ignores default enums, but we defined default for enum when no integers
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

        return this.QueryAsync(request, httpEngineOptions).Result;
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

        return await this.QueryAsync(request, new HttpEngineOptions(), cancellationToken);
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

        try
        {
            using var httpResponseMessage = await this.ProcessRequestAsync(request, cancellationToken)
                .ConfigureAwait(false);

            var response = await this.ProcessResponseAsync(httpResponseMessage)
                .ConfigureAwait(false);

            switch (response.Status)
            {
                case Status.Ok:
                case Status.NotFound:
                case Status.ZeroResults:
                    return response;

                case Status.InvalidRequest:
                case Status.InvalidArgument:
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
            {
                throw;
            }

            var baseException = ex
                .GetBaseException();

            throw new GoogleApiException(baseException.Message, baseException);
        }
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

        var response = new TResponse
        {
            RawQueryString = httpResponse.RequestMessage?.RequestUri?.PathAndQuery
        };

        if (httpResponse.StatusCode == HttpStatusCode.Forbidden)
        {
            response.Status = Status.PermissionDenied;
            response.ErrorMessage = httpResponse.ReasonPhrase;

            return response;
        }

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

        response.Status = httpResponse.IsSuccessStatusCode
            ? response.Status ?? Status.Ok
            : response.Status ?? Status.HttpError;

        return response;
    }
}