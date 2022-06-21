using System;
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
        services
            .AddHttpClient(nameof(GoogleApi), HttpClientFactory.ConfigureDefaultHttpClient)
            .ConfigurePrimaryHttpMessageHandler(() => HttpClientFactory.GetDefaultHttpClientHandler());

        services
            .AddApi<GoogleMaps.DirectionsApi>()
            .AddApi<GoogleMaps.DistanceMatrixApi>()
            .AddApi<GoogleMaps.ElevationApi>()
            .AddApi<GoogleMaps.GeolocationApi>()
            .AddApi<GoogleMaps.Geocode.AddressGeocodeApi>()
            .AddApi<GoogleMaps.Geocode.LocationGeocodeApi>()
            .AddApi<GoogleMaps.Geocode.PlaceGeocodeApi>()
            .AddApi<GoogleMaps.Geocode.PlusCodeGeocodeApi>()
            .AddApi<GoogleMaps.Roads.SnapToRoadApi>()
            .AddApi<GoogleMaps.Roads.NearestRoadsApi>()
            .AddApi<GoogleMaps.Roads.SpeedLimitsApi>()
            .AddApi<GoogleMaps.StreetViewApi>()
            .AddApi<GoogleMaps.StaticMapsApi>()
            .AddApi<GoogleMaps.TimeZoneApi>();

        services
            .AddApi<GooglePlaces.DetailsApi>()
            .AddApi<GooglePlaces.PhotosApi>()
            .AddApi<GooglePlaces.AutoCompleteApi>()
            .AddApi<GooglePlaces.QueryAutoCompleteApi>()
            .AddApi<GooglePlaces.Search.FindSearchApi>()
            .AddApi<GooglePlaces.Search.NearBySearchApi>()
            .AddApi<GooglePlaces.Search.TextSearchApi>();

        services
            .AddApi<GoogleSearch.WebSearchApi>()
            .AddApi<GoogleSearch.ImageSearchApi>()
            .AddApi<GoogleSearch.VideoSearch.ChannelsApi>()
            .AddApi<GoogleSearch.VideoSearch.PlaylistsApi>()
            .AddApi<GoogleSearch.VideoSearch.VideosApi>();

        services
            .AddApi<GoogleTranslate.DetectApi>()
            .AddApi<GoogleTranslate.LanguagesApi>()
            .AddApi<GoogleTranslate.TranslateApi>();

        return services;
    }

    private static IServiceCollection AddApi<TClient>(this IServiceCollection services)
        where TClient : class
    {
        services
            .AddHttpClient<TClient>(HttpClientFactory.ConfigureDefaultHttpClient)
            .ConfigurePrimaryHttpMessageHandler(() => HttpClientFactory.GetDefaultHttpClientHandler())
            .SetHandlerLifetime(TimeSpan.FromMinutes(5));

        return services;
    }
}