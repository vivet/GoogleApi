using System;
using System.Net.Http;
using GoogleApi.Interfaces.Maps;
using GoogleApi.Interfaces.Maps.AerialView;
using GoogleApi.Interfaces.Maps.Geocode;
using GoogleApi.Interfaces.Maps.Roads;
using GoogleApi.Interfaces.Maps.Routes;
using GoogleApi.Interfaces.Places;
using GoogleApi.Interfaces.Places.Search;
using GoogleApi.Interfaces.PlacesNew;
using GoogleApi.Interfaces.PlacesNew.Search;
using GoogleApi.Interfaces.Search;
using GoogleApi.Interfaces.Search.Video;
using GoogleApi.Interfaces.Translate;
using Microsoft.Extensions.DependencyInjection;

namespace GoogleApi.Extensions;

/// <summary>
/// Service Collection Extensions.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the <see cref="HttpEngine{TRequest,TResponse}"/> and
    /// related services to the <see cref="IServiceCollection"/> and configures a named <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>.</param>
    /// <param name="useHttpClientHandler">Whether to use the <see cref="HttpMessageHandler"/> on the <see cref="HttpClient"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/>.</returns>
    [Obsolete("Use the AddGoogleApiClients(IServiceCollection, Action<IHttpClientBuilder>) overload instead. This overload will be removed in a future version.")]
    public static IServiceCollection AddGoogleApiClients(this IServiceCollection services, bool useHttpClientHandler = true)
    {
        if (useHttpClientHandler)
        {
            return services
                .AddGoogleApiClients(configureHttpClient: null);
        }

        return services
            .AddGoogleApiClients(x => x.ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler()));
    }

    /// <summary>
    /// Adds the <see cref="HttpEngine{TRequest,TResponse}"/> and
    /// related services to the <see cref="IServiceCollection"/> and configures a named <see cref="HttpClient"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>.</param>
    /// <param name="configureHttpClient">The <see cref="IHttpClientBuilder"/> delegate.</param>
    /// <returns>The <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection AddGoogleApiClients(this IServiceCollection services, Action<IHttpClientBuilder> configureHttpClient = null)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        services
            .AddHttpClient(nameof(GoogleApi), HttpClientFactory.ConfigureDefaultHttpClient);

        services
            .AddApi<IDirectionsApi, GoogleMaps.DirectionsApi>(configureHttpClient)
            .AddApi<IDistanceMatrixApi, GoogleMaps.DistanceMatrixApi>(configureHttpClient)
            .AddApi<IElevationApi, GoogleMaps.ElevationApi>(configureHttpClient)
            .AddApi<IGeolocationApi, GoogleMaps.GeolocationApi>(configureHttpClient)
            .AddApi<IAddressGeocodeApi, GoogleMaps.Geocode.AddressGeocodeApi>(configureHttpClient)
            .AddApi<ILocationGeocodeApi, GoogleMaps.Geocode.LocationGeocodeApi>(configureHttpClient)
            .AddApi<IPlaceGeocodeApi, GoogleMaps.Geocode.PlaceGeocodeApi>(configureHttpClient)
            .AddApi<IPlusCodeGeocodeApi, GoogleMaps.Geocode.PlusCodeGeocodeApi>(configureHttpClient)
            .AddApi<IAddressValidationApi, GoogleMaps.AddressValidationApi>(configureHttpClient)
            .AddApi<ISnapToRoadApi, GoogleMaps.Roads.SnapToRoadApi>(configureHttpClient)
            .AddApi<INearestRoadsApi, GoogleMaps.Roads.NearestRoadsApi>(configureHttpClient)
            .AddApi<ISpeedLimitsApi, GoogleMaps.Roads.SpeedLimitsApi>(configureHttpClient)
            .AddApi<IStreetViewApi, GoogleMaps.StreetViewApi>(configureHttpClient)
            .AddApi<IStaticMapsApi, GoogleMaps.StaticMapsApi>(configureHttpClient)
            .AddApi<ITimeZoneApi, GoogleMaps.TimeZoneApi>(configureHttpClient)
            .AddApi<IRoutesDirectionsApi, GoogleMaps.Routes.RoutesDirectionsApi>(configureHttpClient)
            .AddApi<IRoutesMatrixApi, GoogleMaps.Routes.RoutesMatrixApi>(configureHttpClient)
            .AddApi<IAerialViewGetVideoApi, GoogleMaps.AerialView.AerialViewGetVideoApi>(configureHttpClient)
            .AddApi<IAerialViewRenderVideoApi, GoogleMaps.AerialView.AerialViewRenderApi>(configureHttpClient);

        services
            .AddApi<IDetailsApi, GooglePlaces.DetailsApi>(configureHttpClient)
            .AddApi<IPhotosApi, GooglePlaces.PhotosApi>(configureHttpClient)
            .AddApi<IAutoCompleteApi, GooglePlaces.AutoCompleteApi>(configureHttpClient)
            .AddApi<IQueryAutoCompleteApi, GooglePlaces.QueryAutoCompleteApi>(configureHttpClient)
            .AddApi<IFindSearchApi, GooglePlaces.Search.FindSearchApi>(configureHttpClient)
            .AddApi<INearBySearchApi, GooglePlaces.Search.NearBySearchApi>(configureHttpClient)
            .AddApi<ITextSearchApi, GooglePlaces.Search.TextSearchApi>(configureHttpClient);

        services
            .AddApi<IDetailsNewApi, GooglePlacesNew.DetailsNewApi>(configureHttpClient)
            .AddApi<IPhotosNewApi, GooglePlacesNew.Photos.PhotosNewApi>(configureHttpClient)
            .AddApi<IPhotosNewSkipHttpRedirectApi, GooglePlacesNew.Photos.PhotosNewSkipHttpRedirectApi>(configureHttpClient)
            .AddApi<IAutoCompleteNewApi, GooglePlacesNew.AutoCompleteNewApi>(configureHttpClient)
            .AddApi<INearBySearchNewApi, GooglePlacesNew.Search.NearBySearchNewApi>(configureHttpClient)
            .AddApi<ITextSearchNewApi, GooglePlacesNew.Search.TextSearchNewApi>(configureHttpClient);

        services
            .AddApi<IWebSearchApi, GoogleSearch.WebSearchApi>(configureHttpClient)
            .AddApi<IImageSearchApi, GoogleSearch.ImageSearchApi>(configureHttpClient)
            .AddApi<IChannelsApi, GoogleSearch.VideoSearch.ChannelsApi>(configureHttpClient)
            .AddApi<IPlaylistsApi, GoogleSearch.VideoSearch.PlaylistsApi>(configureHttpClient)
            .AddApi<IVideosApi, GoogleSearch.VideoSearch.VideosApi>(configureHttpClient);

        services
            .AddApi<IDetectApi, GoogleTranslate.DetectApi>(configureHttpClient)
            .AddApi<ILanguagesApi, GoogleTranslate.LanguagesApi>(configureHttpClient)
            .AddApi<ITranslateApi, GoogleTranslate.TranslateApi>(configureHttpClient);

        return services;
    }


    private static IServiceCollection AddApi<TService, TClient>(this IServiceCollection services, Action<IHttpClientBuilder> configureHttpClient = null)
        where TClient : class, TService
        where TService : class
    {
        var httpClientBuilder = services
            .AddHttpClient<TClient>(HttpClientFactory.ConfigureDefaultHttpClient)
            .ConfigurePrimaryHttpMessageHandler(() => HttpClientFactory.GetDefaultHttpClientHandler(HttpClientFactory.Proxy))
            .SetHandlerLifetime(TimeSpan.FromMinutes(5));

        configureHttpClient?
            .Invoke(httpClientBuilder);

        services
            .AddTransient<TService>(x => x.GetRequiredService<TClient>());

        return services;
    }
}