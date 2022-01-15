using GoogleApi;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    ///
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
            services.AddHttpClient(nameof(GoogleApi), HttpClientFactory.ConfigureDefaultClient)
                .ConfigurePrimaryHttpMessageHandler(HttpClientFactory.GetPrimaryHandler);

            services.AddApi<GoogleMaps.AddressGeocodeApi>();
            services.AddApi<GoogleMaps.DirectionsApi>();
            services.AddApi<GoogleMaps.DistanceMatrixApi>();
            services.AddApi<GoogleMaps.ElevationApi>();
            services.AddApi<GoogleMaps.GeolocationApi>();
            services.AddApi<GoogleMaps.LocationGeocodeApi>();
            services.AddApi<GoogleMaps.NearestRoadsApi>();
            services.AddApi<GoogleMaps.PlusCodeGeocodeApi>();
            services.AddApi<GoogleMaps.PlaceGeoCodeApi>();
            services.AddApi<GoogleMaps.SnapToRoadApi>();
            services.AddApi<GoogleMaps.SpeedLimitsApi>();
            services.AddApi<GoogleMaps.StreetViewApi>();
            services.AddApi<GoogleMaps.StaticMapsApi>();
            services.AddApi<GoogleMaps.TimeZoneApi>();

            services.AddApi<GooglePlaces.AutoCompleteApi>();
            services.AddApi<GooglePlaces.DetailsApi>();
            services.AddApi<GooglePlaces.FindSearchApi>();
            services.AddApi<GooglePlaces.NearBySearchApi>();
            services.AddApi<GooglePlaces.PhotosApi>();
            services.AddApi<GooglePlaces.QueryAutoCompleteApi>();
            services.AddApi<GooglePlaces.TextSearchApi>();

            services.AddApi<GoogleSearch.WebSearchApi>();
            services.AddApi<GoogleSearch.ImageSearchApi>();
            services.AddApi<GoogleSearch.VideoSearch.ChannelsApi>();
            services.AddApi<GoogleSearch.VideoSearch.PlaylistsApi>();
            services.AddApi<GoogleSearch.VideoSearch.VideosApi>();

            services.AddApi<GoogleTranslate.DetectApi>();
            services.AddApi<GoogleTranslate.LanguagesApi>();
            services.AddApi<GoogleTranslate.TranslateApi>();

            return services;
        }

        private static void AddApi<TClient>(this IServiceCollection services)
              where TClient : class
        {
            services.AddHttpClient<TClient>(HttpClientFactory.ConfigureDefaultClient)
                .ConfigurePrimaryHttpMessageHandler(HttpClientFactory.GetPrimaryHandler)
                .SetHandlerLifetime(TimeSpan.FromMinutes(5));
        }
    }
}