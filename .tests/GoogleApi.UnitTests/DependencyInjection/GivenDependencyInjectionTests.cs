#if NETCOREAPP
using FluentAssertions;
using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.Directions.Response;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using GoogleApi.Entities.Maps.DistanceMatrix.Response;
using GoogleApi.Entities.Maps.Elevation.Request;
using GoogleApi.Entities.Maps.Elevation.Response;
using GoogleApi.Entities.Maps.Geocoding;
using GoogleApi.Entities.Maps.Geocoding.Address.Request;
using GoogleApi.Entities.Maps.Geocoding.Location.Request;
using GoogleApi.Entities.Maps.Geocoding.Place.Request;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Response;
using GoogleApi.Entities.Maps.Geolocation.Request;
using GoogleApi.Entities.Maps.Geolocation.Response;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Request;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Response;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Response;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Request;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Response;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using GoogleApi.Entities.Maps.StaticMaps.Response;
using GoogleApi.Entities.Maps.StreetView.Request;
using GoogleApi.Entities.Maps.StreetView.Response;
using GoogleApi.Entities.Maps.TimeZone.Request;
using GoogleApi.Entities.Maps.TimeZone.Response;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.AutoComplete.Response;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Details.Response;
using GoogleApi.Entities.Places.Photos.Request;
using GoogleApi.Entities.Places.Photos.Response;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using GoogleApi.Entities.Places.QueryAutoComplete.Response;
using GoogleApi.Entities.Places.Search.Find.Request;
using GoogleApi.Entities.Places.Search.Find.Response;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.NearBy.Response;
using GoogleApi.Entities.Places.Search.Text.Request;
using GoogleApi.Entities.Places.Search.Text.Response;
using GoogleApi.Entities.Search;
using GoogleApi.Entities.Search.Image.Request;
using GoogleApi.Entities.Search.Video.Channels.Request;
using GoogleApi.Entities.Search.Video.Channels.Response;
using GoogleApi.Entities.Search.Video.Playlists.Request;
using GoogleApi.Entities.Search.Video.Playlists.Response;
using GoogleApi.Entities.Search.Video.Videos.Request;
using GoogleApi.Entities.Search.Video.Videos.Response;
using GoogleApi.Entities.Search.Web.Request;
using GoogleApi.Entities.Translate.Detect.Request;
using GoogleApi.Entities.Translate.Detect.Response;
using GoogleApi.Entities.Translate.Languages.Request;
using GoogleApi.Entities.Translate.Languages.Response;
using GoogleApi.Entities.Translate.Translate.Request;
using GoogleApi.Entities.Translate.Translate.Response;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;

namespace GoogleApi.UnitTests.DependencyInjection
{
    [TestFixture]
    public class GivenDependencyInjectionTests
    {
        private static IServiceProvider _provider;

        [OneTimeSetUp]
        public void BeforeAll()
        {
            var services = new ServiceCollection();

            services.AddGoogleApiClients();

            _provider = services.BuildServiceProvider();
        }

        [Test]
        public void CanResolve_GoogleApi_client()
        {

            var factory = _provider.GetRequiredService<IHttpClientFactory>();

            var result = factory.CreateClient(nameof(GoogleApi));

            result.Should().BeOfType<HttpClient>();
        }

        [Test]
        public void HttpClientFactory_ConfigureDefaultClient_client_configured_to_accept_json()
        {
            var factory = _provider.GetRequiredService<IHttpClientFactory>();

            var result = factory.CreateClient(nameof(GoogleApi));

            result.Should().BeOfType<HttpClient>();

            result.DefaultRequestHeaders.Accept
                .Should().ContainEquivalentOf(
                    new MediaTypeWithQualityHeaderValue("application/json")); //System.Net.Mime.MediaTypeNames.Application.Json

            ShowResult(result.DefaultRequestHeaders.Select(h => new { h.Key, Value = string.Join(",", h.Value) }));
        }

        [Test]
        public void HttpClientFactory_GetPrimaryHandler_handler_configured_to_use_compression()
        {
            var handler = HttpClientFactory.GetPrimaryHandler(null);

            handler.Should().BeOfType<HttpClientHandler>();

            var httpHandler = handler as HttpClientHandler;
            httpHandler.AutomaticDecompression.Should()
                .HaveFlag(DecompressionMethods.Deflate)
                .And.HaveFlag(DecompressionMethods.GZip);
        }

        [Test]
        public void HttpClientFactory_GetPrimaryHandler_handler_configured_to_use_tls()
        {
            var handler = HttpClientFactory.GetPrimaryHandler(null);

            handler.Should().BeOfType<HttpClientHandler>();

            var httpHandler = handler as HttpClientHandler;

            var expected = SslProtocols.None;

            httpHandler .SslProtocols.Should().HaveFlag(expected);
        }
        #region GoogleMaps
        [Test]
        public void CanResolve_GoogleMaps_AddressGeocodeApi()
        {

            var result = _provider.GetRequiredService<GoogleMaps.AddressGeocodeApi>();
            result.Should().BeAssignableTo<HttpEngine<AddressGeocodeRequest, GeocodeResponse>>();
        }

        [Test]
        public void CanResolve_GoogleMaps_DirectionsApi()
        {

            var result = _provider.GetRequiredService<GoogleMaps.DirectionsApi>();
            result.Should().BeAssignableTo<HttpEngine<DirectionsRequest, DirectionsResponse>>();
        }

        [Test]
        public void CanResolve_GoogleMaps_DistanceMatrixApi()
        {

            var result = _provider.GetRequiredService<GoogleMaps.DistanceMatrixApi>();
            result.Should().BeAssignableTo<HttpEngine<DistanceMatrixRequest, DistanceMatrixResponse>>();
        }

        [Test]
        public void CanResolve_GoogleMaps_ElevationApi()
        {

            var result = _provider.GetRequiredService<GoogleMaps.ElevationApi>();
            result.Should().BeAssignableTo<HttpEngine<ElevationRequest, ElevationResponse>>();
        }

        [Test]
        public void CanResolve_GoogleMaps_GeolocationApi()
        {

            var result = _provider.GetRequiredService<GoogleMaps.GeolocationApi>();
            result.Should().BeAssignableTo<HttpEngine<GeolocationRequest, GeolocationResponse>>();
        }

        [Test]
        public void CanResolve_GoogleMaps_NearestRoadsApi()
        {

            var result = _provider.GetRequiredService<GoogleMaps.NearestRoadsApi>();
            result.Should().BeAssignableTo<HttpEngine<NearestRoadsRequest, NearestRoadsResponse>>();
        }

        [Test]
        public void CanResolve_GoogleMaps_LocationGeocodeApi()
        {

            var result = _provider.GetRequiredService<GoogleMaps.LocationGeocodeApi>();
            result.Should().BeAssignableTo<HttpEngine<LocationGeocodeRequest, GeocodeResponse>>();
        }

        [Test]
        public void CanResolve_GoogleMaps_PlaceGeoCodeApi()
        {

            var result = _provider.GetRequiredService<GoogleMaps.PlaceGeoCodeApi>();
            result.Should().BeAssignableTo<HttpEngine<PlaceGeocodeRequest, GeocodeResponse>>();
        }

        [Test]
        public void CanResolve_GoogleMaps_PlusCodeGeocodeApi()
        {

            var result = _provider.GetRequiredService<GoogleMaps.PlusCodeGeocodeApi>();
            result.Should().BeAssignableTo<HttpEngine<PlusCodeGeocodeRequest, PlusCodeGeocodeResponse>>();
        }

        [Test]
        public void CanResolve_GoogleMaps_SnapToRoadApi()
        {

            var result = _provider.GetRequiredService<GoogleMaps.SnapToRoadApi>();
            result.Should().BeAssignableTo<HttpEngine<SnapToRoadsRequest, SnapToRoadsResponse>>();
        }

        [Test]
        public void CanResolve_GoogleMaps_SpeedLimitsApi()
        {

            var result = _provider.GetRequiredService<GoogleMaps.SpeedLimitsApi>();
            result.Should().BeAssignableTo<HttpEngine<SpeedLimitsRequest, SpeedLimitsResponse>>();
        }

        [Test]
        public void CanResolve_GoogleMaps_StreetViewApi()
        {

            var result = _provider.GetRequiredService<GoogleMaps.StreetViewApi>();
            result.Should().BeAssignableTo<HttpEngine<StreetViewRequest, StreetViewResponse>>();
        }

        [Test]
        public void CanResolve_GoogleMaps_StaticMapsApi()
        {

            var result = _provider.GetRequiredService<GoogleMaps.StaticMapsApi>();
            result.Should().BeAssignableTo<HttpEngine<StaticMapsRequest, StaticMapsResponse>>();
        }

        [Test]
        public void CanResolve_GoogleMaps_TimeZoneApi()
        {

            var result = _provider.GetRequiredService<GoogleMaps.TimeZoneApi>();
            result.Should().BeAssignableTo<HttpEngine<TimeZoneRequest, TimeZoneResponse>>();
        }
        #endregion

        #region GooglePlaces
        [Test]
        public void CanResolve_GooglePlaces_AutoCompleteApi()
        {

            var result = _provider.GetRequiredService<GooglePlaces.AutoCompleteApi>();
            result.Should().BeAssignableTo<HttpEngine<PlacesAutoCompleteRequest, PlacesAutoCompleteResponse>>();
        }

        [Test]
        public void CanResolve_GooglePlaces_DetailsApi()
        {

            var result = _provider.GetRequiredService<GooglePlaces.DetailsApi>();
            result.Should().BeAssignableTo<HttpEngine<PlacesDetailsRequest, PlacesDetailsResponse>>();
        }

        [Test]
        public void CanResolve_GooglePlaces_FindSearchApi()
        {

            var result = _provider.GetRequiredService<GooglePlaces.FindSearchApi>();
            result.Should().BeAssignableTo<HttpEngine<PlacesFindSearchRequest, PlacesFindSearchResponse>>();
        }

        [Test]
        public void CanResolve_GooglePlaces_NearBySearchApi()
        {

            var result = _provider.GetRequiredService<GooglePlaces.NearBySearchApi>();
            result.Should().BeAssignableTo<HttpEngine<PlacesNearBySearchRequest, PlacesNearbySearchResponse>>();
        }

        [Test]
        public void CanResolve_GooglePlaces_PhotosApi()
        {

            var result = _provider.GetRequiredService<GooglePlaces.PhotosApi>();
            result.Should().BeAssignableTo<HttpEngine<PlacesPhotosRequest, PlacesPhotosResponse>>();
        }

        [Test]
        public void CanResolve_GooglePlaces_QueryAutoCompleteApi()
        {

            var result = _provider.GetRequiredService<GooglePlaces.QueryAutoCompleteApi>();
            result.Should().BeAssignableTo<HttpEngine<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse>>();
        }

        [Test]
        public void CanResolve_GooglePlaces_TextSearchApi()
        {

            var result = _provider.GetRequiredService<GooglePlaces.TextSearchApi>();
            result.Should().BeAssignableTo<HttpEngine<PlacesTextSearchRequest, PlacesTextSearchResponse>>();
        }
        #endregion

        #region GoogleSearch
        [Test]
        public void CanResolve_GoogleSearch_WebSearchApi()
        {

            var result = _provider.GetRequiredService<GoogleSearch.WebSearchApi>();
            result.Should().BeAssignableTo<HttpEngine<WebSearchRequest, BaseSearchResponse>>();
        }

        [Test]
        public void CanResolve_GoogleSearch_ImageSearchApi()
        {

            var result = _provider.GetRequiredService<GoogleSearch.ImageSearchApi>();
            result.Should().BeAssignableTo<HttpEngine<ImageSearchRequest, BaseSearchResponse>>();
        }

        [Test]
        public void CanResolve_GoogleSearch_VideoSearch_ChannelsApi()
        {

            var result = _provider.GetRequiredService<GoogleSearch.VideoSearch.ChannelsApi>();
            result.Should().BeAssignableTo<HttpEngine<ChannelSearchRequest, ChannelSearchResponse>>();
        }

        [Test]
        public void CanResolve_GoogleSearch_VideoSearch_PlaylistsApi()
        {

            var result = _provider.GetRequiredService<GoogleSearch.VideoSearch.PlaylistsApi>();
            result.Should().BeAssignableTo<HttpEngine<PlaylistSearchRequest, PlaylistSearchResponse>>();
        }

        [Test]
        public void CanResolve_GoogleSearch_VideoSearch_VideosApi()
        {

            var result = _provider.GetRequiredService<GoogleSearch.VideoSearch.VideosApi>();
            result.Should().BeAssignableTo<HttpEngine<VideoSearchRequest, VideoSearchResponse>>();
        }
        #endregion

        #region GoogleTranslate
        [Test]
        public void CanResolve_GoogleTranslate_TranslateApi()
        {

            var result = _provider.GetRequiredService<GoogleTranslate.TranslateApi>();
            result.Should().BeAssignableTo<HttpEngine<TranslateRequest, TranslateResponse>>();
        }

        [Test]
        public void CanResolve_GoogleTranslate_DetectApi()
        {

            var result = _provider.GetRequiredService<GoogleTranslate.DetectApi>();
            result.Should().BeAssignableTo<HttpEngine<DetectRequest, DetectResponse>>();
        }

        [Test]
        public void CanResolve_GoogleTranslate_LanguagesApi()
        {

            var result = _provider.GetRequiredService<GoogleTranslate.LanguagesApi>();
            result.Should().BeAssignableTo<HttpEngine<LanguagesRequest, LanguagesResponse>>();
        }
        #endregion

        private static void ShowResult(object result)
        {
            Console.WriteLine(result.ToJson());
        }
    }
}
#endif