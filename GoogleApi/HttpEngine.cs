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
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Converters.Factories;
using GoogleApi.Entities.Places.Photos.Response;
using GoogleApi.Entities.PlacesNew.Common;
using GoogleApi.Entities.PlacesNew.Details.Response;
using GoogleApi.Entities.PlacesNew.Photos.Response;

namespace GoogleApi;

/// <summary>
/// Http Engine.
/// </summary>
public class HttpEngine
{
    /// <summary>
    /// Json Serializer Options.
    /// </summary>
    internal static readonly JsonSerializerOptions jsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        Converters =
        {
            new JsonStringEnumConverterFactory()
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
    where TRequest : class, IRequest, new()
    where TResponse : class, IResponse, new()
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
    /// Query Async.
    /// </summary>
    /// <param name="request">The request that will be sent.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/>.</param>
    /// <returns>The <see cref="Task{T}"/>.</returns>
    public Task<TResponse> QueryAsync(TRequest request, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        return this.QueryAsync(request, new HttpEngineOptions(), cancellationToken);
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
            using var httpResponseMessage = await this.ProcessRequestAsync(request, httpEngineOptions, cancellationToken)
                .ConfigureAwait(false);

            var response = await this.ProcessResponseAsync(httpResponseMessage)
                .ConfigureAwait(false);

            switch (response.Status)
            {
                case Status.Ok:
                case Status.NotFound:
                case Status.ZeroResults:
                case Status.ResourceExhausted:
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

    private async Task<HttpResponseMessage> ProcessRequestAsync(TRequest request, HttpEngineOptions httpEngineOptions, CancellationToken cancellationToken = default)
    {
        if (request == null)
            throw new ArgumentNullException(nameof(request));

        var uri = request
            .GetUri();

        var method = request is IRequestQueryString or IRequestQueryStringX
            ? HttpMethod.Get
            : HttpMethod.Post;

        using var httpRequestMessage = new HttpRequestMessage(method, uri);

        if (httpEngineOptions.AdditionalHeaders != null) {
            foreach (var header in httpEngineOptions.AdditionalHeaders ) { 
                httpRequestMessage.Headers.Add(header.Key, header.Value); 
            }
        }

        if (request is IRequestX jsonX)
        {
            httpRequestMessage.Headers
                .Add(GoogleHttpHeaders.API_KEY_HEADER, request.Key);

            httpRequestMessage.Headers
                .Add(GoogleHttpHeaders.FIELD_MASK_HEADER, jsonX.FieldMask ?? "*");
        }

        switch (request)
        {
            case IRequestQueryString:
            case IRequestQueryStringX:
            {
                return await this.httpClient
                    .SendAsync(httpRequestMessage, cancellationToken);
            }

            case IRequestJson:
            case IRequestJsonX:
            {
                var serializeObject = JsonSerializer.Serialize(request, HttpEngine.jsonSerializerOptions);
                httpRequestMessage.Content = new StringContent(serializeObject, Encoding.UTF8);

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
        string rawJson = null;

        switch (response)
        {
            case IResponseStream responseStream:
            {
                if (httpResponse.IsSuccessStatusCode)
                {
                    responseStream.Buffer = await httpResponse.Content
                        .ReadAsByteArrayAsync()
                        .ConfigureAwait(false);
                }
                else
                {
                    if (responseStream is PlacesPhotosResponse placesPhotosResponse)
                    {
                        switch (httpResponse.StatusCode)
                        {
                            case HttpStatusCode.NotFound:
                                placesPhotosResponse.Status = Status.NotFound;
                                placesPhotosResponse.ErrorMessage = "The resounrce was not found.";
                                break;
                            
                            case HttpStatusCode.Forbidden:
                            case HttpStatusCode.Unauthorized:
                                placesPhotosResponse.Status = Status.InvalidKey;
                                placesPhotosResponse.ErrorMessage = "The key is invalid.";
                                break;
                            
                            default:
                                placesPhotosResponse.Status = Status.UnknownError;
                                placesPhotosResponse.ErrorMessage = "An error occurred";
                                break;
                        }
                    }
                    else
                    {
                        rawJson = await httpResponse.Content
                            .ReadAsStringAsync()
                            .ConfigureAwait(false);

                        if (string.IsNullOrEmpty(rawJson))
                        {
                            var error404 = Get404Error();

                            response = new PlacesNewPhotosResponse
                            {
                                Error = error404
                            } as TResponse ?? new TResponse();
                        }
                        else
                        {
                            response = JsonSerializer.Deserialize<TResponse>(rawJson, HttpEngine.jsonSerializerOptions) ?? new TResponse();
                        }
                    }
                }

                break;
            }

            default:
            {
                rawJson = await httpResponse.Content
                    .ReadAsStringAsync()
                    .ConfigureAwait(false);

                if (response is PlacesNewDetailsResponse)
                {
                    if (httpResponse.IsSuccessStatusCode)
                    {
                        response = new PlacesNewDetailsResponse
                        {
                            Place = JsonSerializer.Deserialize<Place>(rawJson, HttpEngine.jsonSerializerOptions)
                        } as TResponse ?? new TResponse();
                    }
                    else
                    {
                        response = JsonSerializer.Deserialize<TResponse>(rawJson, HttpEngine.jsonSerializerOptions) ?? new TResponse();
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(rawJson))
                    {
                        // BUG: It's not always PlacesNewPhotosSkipHttpRedirectResponse. 
                        // can we make this more generic, to work with all response types?

                        var error404 = Get404Error();

                        response = new PlacesNewPhotosSkipHttpRedirectResponse
                        {
                            Error = error404
                        } as TResponse ?? new TResponse();
                    }
                    else
                    {
                        response = JsonSerializer.Deserialize<TResponse>(rawJson, HttpEngine.jsonSerializerOptions) ?? new TResponse();
                    }
                }

                break;
            }
        }

        response.RawJson = rawJson;
        response.RawQueryString = httpResponse.RequestMessage?.RequestUri?.PathAndQuery;

        return response;
    }

    private static Error Get404Error()
    {
        return new Error
        {
            Status = Status.NotFound,
            Code = 404,
            Message = "The resource could not be found."
        };
    }
}