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
    /// <returns>The <see cref="IServiceCollection"/>..</returns>
    public static IServiceCollection AddGoogleApiClients(this IServiceCollection services, bool useHttpClientHandler = true)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        services
            .AddHttpClient(nameof(GoogleApi), HttpClientFactory.ConfigureDefaultHttpClient);

        services
            .AddApi<IDirectionsApi, GoogleMaps.DirectionsApi>(useHttpClientHandler)
            .AddApi<IDistanceMatrixApi, GoogleMaps.DistanceMatrixApi>(useHttpClientHandler)
            .AddApi<IElevationApi, GoogleMaps.ElevationApi>(useHttpClientHandler)
            .AddApi<IGeolocationApi, GoogleMaps.GeolocationApi>(useHttpClientHandler)
            .AddApi<IAddressGeocodeApi, GoogleMaps.Geocode.AddressGeocodeApi>(useHttpClientHandler)
            .AddApi<ILocationGeocodeApi, GoogleMaps.Geocode.LocationGeocodeApi>(useHttpClientHandler)
            .AddApi<IPlaceGeocodeApi, GoogleMaps.Geocode.PlaceGeocodeApi>(useHttpClientHandler)
            .AddApi<IPlusCodeGeocodeApi, GoogleMaps.Geocode.PlusCodeGeocodeApi>(useHttpClientHandler)
            .AddApi<IAddressValidationApi, GoogleMaps.AddressValidationApi>(useHttpClientHandler)
            .AddApi<ISnapToRoadApi, GoogleMaps.Roads.SnapToRoadApi>(useHttpClientHandler)
            .AddApi<INearestRoadsApi, GoogleMaps.Roads.NearestRoadsApi>(useHttpClientHandler)
            .AddApi<ISpeedLimitsApi, GoogleMaps.Roads.SpeedLimitsApi>(useHttpClientHandler)
            .AddApi<IStreetViewApi, GoogleMaps.StreetViewApi>(useHttpClientHandler)
            .AddApi<IStaticMapsApi, GoogleMaps.StaticMapsApi>(useHttpClientHandler)
            .AddApi<ITimeZoneApi, GoogleMaps.TimeZoneApi>(useHttpClientHandler)
            .AddApi<IRoutesDirectionsApi, GoogleMaps.Routes.RoutesDirectionsApi>(useHttpClientHandler)
            .AddApi<IRoutesMatrixApi, GoogleMaps.Routes.RoutesMatrixApi>(useHttpClientHandler)
            .AddApi<IAerialViewGetVideoApi, GoogleMaps.AerialView.AerialViewGetVideoApi>(useHttpClientHandler)
            .AddApi<IAerialViewRenderVideoApi, GoogleMaps.AerialView.AerialViewRenderApi>(useHttpClientHandler);

        services
            .AddApi<IDetailsApi, GooglePlaces.DetailsApi>(useHttpClientHandler)
            .AddApi<IPhotosApi, GooglePlaces.PhotosApi>(useHttpClientHandler)
            .AddApi<IAutoCompleteApi, GooglePlaces.AutoCompleteApi>(useHttpClientHandler)
            .AddApi<IQueryAutoCompleteApi, GooglePlaces.QueryAutoCompleteApi>(useHttpClientHandler)
            .AddApi<IFindSearchApi, GooglePlaces.Search.FindSearchApi>(useHttpClientHandler)
            .AddApi<INearBySearchApi, GooglePlaces.Search.NearBySearchApi>(useHttpClientHandler)
            .AddApi<ITextSearchApi, GooglePlaces.Search.TextSearchApi>(useHttpClientHandler);

        services
            .AddApi<IDetailsNewApi, GooglePlacesNew.DetailsNewApi>(useHttpClientHandler)
            .AddApi<IPhotosNewApi, GooglePlacesNew.Photos.PhotosNewApi>(useHttpClientHandler)
            .AddApi<IPhotosNewSkipHttpRedirectApi, GooglePlacesNew.Photos.PhotosNewSkipHttpRedirectApi>(useHttpClientHandler)
            .AddApi<IAutoCompleteNewApi, GooglePlacesNew.AutoCompleteNewApi>(useHttpClientHandler)
            .AddApi<INearBySearchNewApi, GooglePlacesNew.Search.NearBySearchNewApi>(useHttpClientHandler)
            .AddApi<ITextSearchNewApi, GooglePlacesNew.Search.TextSearchNewApi>(useHttpClientHandler);

        services
            .AddApi<IWebSearchApi, GoogleSearch.WebSearchApi>(useHttpClientHandler)
            .AddApi<IImageSearchApi, GoogleSearch.ImageSearchApi>(useHttpClientHandler)
            .AddApi<IChannelsApi, GoogleSearch.VideoSearch.ChannelsApi>(useHttpClientHandler)
            .AddApi<IPlaylistsApi, GoogleSearch.VideoSearch.PlaylistsApi>(useHttpClientHandler)
            .AddApi<IVideosApi, GoogleSearch.VideoSearch.VideosApi>(useHttpClientHandler);

        services
            .AddApi<IDetectApi, GoogleTranslate.DetectApi>(useHttpClientHandler)
            .AddApi<ILanguagesApi, GoogleTranslate.LanguagesApi>(useHttpClientHandler)
            .AddApi<ITranslateApi, GoogleTranslate.TranslateApi>(useHttpClientHandler);

        return services;
    }

    private static IServiceCollection AddApi<TService, TClient>(this IServiceCollection services, bool useHttpClientHandler = true)
        where TClient : class, TService
        where TService : class
    {
        var httpClientBuilder = services
            .AddHttpClient<TClient>(HttpClientFactory.ConfigureDefaultHttpClient);

        if (useHttpClientHandler)
        {
            httpClientBuilder
                .ConfigurePrimaryHttpMessageHandler(() => HttpClientFactory.GetDefaultHttpClientHandler(HttpClientFactory.Proxy))
                .SetHandlerLifetime(TimeSpan.FromMinutes(5));
        }

        services
            .AddTransient<TService, TClient>();

        return services;
    }
}