using System;
using GoogleApi.Interfaces.Maps;
using GoogleApi.Interfaces.Maps.AerialView;
using GoogleApi.Interfaces.Maps.Geocode;
using GoogleApi.Interfaces.Maps.Roads;
using GoogleApi.Interfaces.Maps.Routes;
using GoogleApi.Interfaces.Places;
using GoogleApi.Interfaces.Places.Search;
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
    /// Adds the <see cref="HttpEngine{TRequest,TResponse}"/> and related services to the <see cref="IServiceCollection"/> and configures
    /// a named <see cref="System.Net.Http.HttpClient"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/>.</param>
    /// <returns>An <see cref="IServiceCollection"/> that can be used to chain the extensions.</returns>
    /// <remarks>
    /// </remarks>
    public static IServiceCollection AddGoogleApiClients(this IServiceCollection services)
    {
        if (services == null)
            throw new ArgumentNullException(nameof(services));

        services
            .AddHttpClient(nameof(GoogleApi), HttpClientFactory.ConfigureDefaultHttpClient)
            .ConfigurePrimaryHttpMessageHandler(() => HttpClientFactory.GetDefaultHttpClientHandler());

        services
            .AddApi<IDirectionsApi, GoogleMaps.DirectionsApi>()
            .AddApi<IDistanceMatrixApi, GoogleMaps.DistanceMatrixApi>()
            .AddApi<IElevationApi, GoogleMaps.ElevationApi>()
            .AddApi<IGeolocationApi, GoogleMaps.GeolocationApi>()
            .AddApi<IAddressGeocodeApi, GoogleMaps.Geocode.AddressGeocodeApi>()
            .AddApi<ILocationGeocodeApi, GoogleMaps.Geocode.LocationGeocodeApi>()
            .AddApi<IPlaceGeocodeApi, GoogleMaps.Geocode.PlaceGeocodeApi>()
            .AddApi<IPlusCodeGeocodeApi, GoogleMaps.Geocode.PlusCodeGeocodeApi>()
            .AddApi<IAddressValidationApi, GoogleMaps.AddressValidationApi>()
            .AddApi<ISnapToRoadApi, GoogleMaps.Roads.SnapToRoadApi>()
            .AddApi<INearestRoadsApi, GoogleMaps.Roads.NearestRoadsApi>()
            .AddApi<ISpeedLimitsApi, GoogleMaps.Roads.SpeedLimitsApi>()
            .AddApi<IStreetViewApi, GoogleMaps.StreetViewApi>()
            .AddApi<IStaticMapsApi, GoogleMaps.StaticMapsApi>()
            .AddApi<ITimeZoneApi, GoogleMaps.TimeZoneApi>()
            .AddApi<IRoutesDirectionsApi, GoogleMaps.Routes.RoutesDirectionsApi>()
            .AddApi<IRoutesMatrixApi, GoogleMaps.Routes.RoutesMatrixApi>()
            .AddApi<IAerialViewGetVideoApi, GoogleMaps.AerialView.AerialViewGetVideoApi>()
            .AddApi<IAerialViewRenderVideoApi, GoogleMaps.AerialView.AerialViewRenderApi>();

        services
            .AddApi<IDetailsApi, GooglePlaces.DetailsApi>()
            .AddApi<IPhotosApi, GooglePlaces.PhotosApi>()
            .AddApi<IAutoCompleteApi, GooglePlaces.AutoCompleteApi>()
            .AddApi<IQueryAutoCompleteApi, GooglePlaces.QueryAutoCompleteApi>()
            .AddApi<IFindSearchApi, GooglePlaces.Search.FindSearchApi>()
            .AddApi<INearBySearchApi, GooglePlaces.Search.NearBySearchApi>()
            .AddApi<ITextSearchApi, GooglePlaces.Search.TextSearchApi>();

        services
            .AddApi<IWebSearchApi, GoogleSearch.WebSearchApi>()
            .AddApi<IImageSearchApi, GoogleSearch.ImageSearchApi>()
            .AddApi<IChannelsApi, GoogleSearch.VideoSearch.ChannelsApi>()
            .AddApi<IPlaylistsApi, GoogleSearch.VideoSearch.PlaylistsApi>()
            .AddApi<IVideosApi, GoogleSearch.VideoSearch.VideosApi>();

        services
            .AddApi<IDetectApi, GoogleTranslate.DetectApi>()
            .AddApi<ILanguagesApi, GoogleTranslate.LanguagesApi>()
            .AddApi<ITranslateApi, GoogleTranslate.TranslateApi>();

        return services;
    }

    private static IServiceCollection AddApi<TService, TClient>(this IServiceCollection services)
        where TClient : class, TService
        where TService : class
    {
        services
            .AddHttpClient<TClient>(HttpClientFactory.ConfigureDefaultHttpClient)
            .ConfigurePrimaryHttpMessageHandler(() => HttpClientFactory.GetDefaultHttpClientHandler())
            .SetHandlerLifetime(TimeSpan.FromMinutes(5));

        services
            .AddTransient<TService, TClient>();

        return services;
    }
}