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
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using GoogleApi.Extensions;
using GoogleApi.Interfaces.Maps;
using GoogleApi.Interfaces.Maps.Geocode;
using GoogleApi.Interfaces.Maps.Roads;
using GoogleApi.Interfaces.Places;
using GoogleApi.Interfaces.Places.Search;
using GoogleApi.Interfaces.Search;
using GoogleApi.Interfaces.Search.Video;
using GoogleApi.Interfaces.Translate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Extensions;

[TestClass]
public class ServiceCollectionExtensionTests
{
    private readonly IServiceProvider provider;

    public ServiceCollectionExtensionTests()
    {
        var services = new ServiceCollection();
        services
            .AddGoogleApiClients();

        this.provider = services
            .BuildServiceProvider();
    }

    [TestMethod]
    public void ResolveGoogleApiClientTest()
    {
        var httpClientFactory = this.provider
            .GetRequiredService<IHttpClientFactory>();

        var httpClient = httpClientFactory
            .CreateClient(nameof(GoogleApi));

        Assert.IsInstanceOfType<HttpClient>(httpClient);

        var expected = new MediaTypeWithQualityHeaderValue("application/json");
        Assert.IsTrue(httpClient.DefaultRequestHeaders.Accept.Contains(expected));

        Assert.AreEqual(httpClient.Timeout, TimeSpan.FromSeconds(30));

        var defaultHttpClientHandler = HttpClientFactory.GetDefaultHttpClientHandler();

        var hasGZip = defaultHttpClientHandler.AutomaticDecompression.HasFlag(DecompressionMethods.GZip);
        Assert.IsTrue(hasGZip);

        var hasDeflate = defaultHttpClientHandler.AutomaticDecompression.HasFlag(DecompressionMethods.Deflate);
        Assert.IsTrue(hasDeflate);
    }


    [TestMethod]
    public void ResolveMapsDirectionsApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.DirectionsApi>();

        Assert.IsInstanceOfType<HttpEngine<DirectionsRequest, DirectionsResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsDirectionsApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IDirectionsApi>();

        Assert.IsInstanceOfType<GoogleMaps.DirectionsApi>(result);
        Assert.IsInstanceOfType<HttpEngine<DirectionsRequest, DirectionsResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsDistanceMatrixApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.DistanceMatrixApi>();

        Assert.IsInstanceOfType<HttpEngine<DistanceMatrixRequest, DistanceMatrixResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsDistanceMatrixApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IDistanceMatrixApi>();

        Assert.IsInstanceOfType<GoogleMaps.DistanceMatrixApi>(result);
        Assert.IsInstanceOfType<HttpEngine<DistanceMatrixRequest, DistanceMatrixResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsElevationApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.ElevationApi>();

        Assert.IsInstanceOfType<HttpEngine<ElevationRequest, ElevationResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsElevationApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IElevationApi>();

        Assert.IsInstanceOfType<GoogleMaps.ElevationApi>(result);
        Assert.IsInstanceOfType<HttpEngine<ElevationRequest, ElevationResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsGeolocationApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.GeolocationApi>();

        Assert.IsInstanceOfType<HttpEngine<GeolocationRequest, GeolocationResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsGeolocationApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IGeolocationApi>();

        Assert.IsInstanceOfType<GoogleMaps.GeolocationApi>(result);
        Assert.IsInstanceOfType<HttpEngine<GeolocationRequest, GeolocationResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsGeocodeAddressGeocodeApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.Geocode.AddressGeocodeApi>();

        Assert.IsInstanceOfType<HttpEngine<AddressGeocodeRequest, GeocodeResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsGeocodeAddressGeocodeApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IAddressGeocodeApi>();

        Assert.IsInstanceOfType<GoogleMaps.Geocode.AddressGeocodeApi>(result);
        Assert.IsInstanceOfType<HttpEngine<AddressGeocodeRequest, GeocodeResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsGeocodeLocationGeocodeApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.Geocode.LocationGeocodeApi>();

        Assert.IsInstanceOfType<HttpEngine<LocationGeocodeRequest, GeocodeResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsGeocodeLocationGeocodeApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<ILocationGeocodeApi>();

        Assert.IsInstanceOfType<GoogleMaps.Geocode.LocationGeocodeApi>(result);
        Assert.IsInstanceOfType<HttpEngine<LocationGeocodeRequest, GeocodeResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsGeocodePlaceGeoCodeApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.Geocode.PlaceGeocodeApi>();

        Assert.IsInstanceOfType<HttpEngine<PlaceGeocodeRequest, GeocodeResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsGeocodePlaceGeoCodeApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IPlaceGeocodeApi>();

        Assert.IsInstanceOfType<GoogleMaps.Geocode.PlaceGeocodeApi>(result);
        Assert.IsInstanceOfType<HttpEngine<PlaceGeocodeRequest, GeocodeResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsGeocodePlusCodeGeocodeApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.Geocode.PlusCodeGeocodeApi>();

        Assert.IsInstanceOfType<HttpEngine<PlusCodeGeocodeRequest, PlusCodeGeocodeResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsGeocodePlusCodeGeocodeApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IPlusCodeGeocodeApi>();

        Assert.IsInstanceOfType<GoogleMaps.Geocode.PlusCodeGeocodeApi>(result);
        Assert.IsInstanceOfType<HttpEngine<PlusCodeGeocodeRequest, PlusCodeGeocodeResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsRoadsNearestRoadsApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.Roads.NearestRoadsApi>();

        Assert.IsInstanceOfType<HttpEngine<NearestRoadsRequest, NearestRoadsResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsRoadsNearestRoadsApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<INearestRoadsApi>();

        Assert.IsInstanceOfType<GoogleMaps.Roads.NearestRoadsApi>(result);
        Assert.IsInstanceOfType<HttpEngine<NearestRoadsRequest, NearestRoadsResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsRoadsSnapToRoadApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.Roads.SnapToRoadApi>();

        Assert.IsInstanceOfType<HttpEngine<SnapToRoadsRequest, SnapToRoadsResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsRoadsSnapToRoadApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<ISnapToRoadApi>();

        Assert.IsInstanceOfType<GoogleMaps.Roads.SnapToRoadApi>(result);
        Assert.IsInstanceOfType<HttpEngine<SnapToRoadsRequest, SnapToRoadsResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsRoadsSpeedLimitsApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.Roads.SpeedLimitsApi>();

        Assert.IsInstanceOfType<HttpEngine<SpeedLimitsRequest, SpeedLimitsResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsRoadsSpeedLimitsApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<ISpeedLimitsApi>();

        Assert.IsInstanceOfType<GoogleMaps.Roads.SpeedLimitsApi>(result);
        Assert.IsInstanceOfType<HttpEngine<SpeedLimitsRequest, SpeedLimitsResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsStreetViewApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.StreetViewApi>();

        Assert.IsInstanceOfType<HttpEngine<StreetViewRequest, StreetViewResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsStreetViewApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IStreetViewApi>();

        Assert.IsInstanceOfType<GoogleMaps.StreetViewApi>(result);
        Assert.IsInstanceOfType<HttpEngine<StreetViewRequest, StreetViewResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsStaticMapsApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.StaticMapsApi>();

        Assert.IsInstanceOfType<HttpEngine<StaticMapsRequest, StaticMapsResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsStaticMapsApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IStaticMapsApi>();

        Assert.IsInstanceOfType<GoogleMaps.StaticMapsApi>(result);
        Assert.IsInstanceOfType<HttpEngine<StaticMapsRequest, StaticMapsResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsTimeZoneApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.TimeZoneApi>();

        Assert.IsInstanceOfType<HttpEngine<TimeZoneRequest, TimeZoneResponse>>(result);
    }

    [TestMethod]
    public void ResolveMapsTimeZoneApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<ITimeZoneApi>();

        Assert.IsInstanceOfType<GoogleMaps.TimeZoneApi>(result);
        Assert.IsInstanceOfType<HttpEngine<TimeZoneRequest, TimeZoneResponse>>(result);
    }


    [TestMethod]
    public void ResolvePlacesAutoCompleteApiTest()
    {
        var result = this.provider
            .GetRequiredService<GooglePlaces.AutoCompleteApi>();

        Assert.IsInstanceOfType<HttpEngine<PlacesAutoCompleteRequest, PlacesAutoCompleteResponse>>(result);
    }

    [TestMethod]
    public void ResolvePlacesAutoCompleteApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IAutoCompleteApi>();

        Assert.IsInstanceOfType<GooglePlaces.AutoCompleteApi>(result);
        Assert.IsInstanceOfType<HttpEngine<PlacesAutoCompleteRequest, PlacesAutoCompleteResponse>>(result);
    }

    [TestMethod]
    public void ResolvePlacesDetailsApiTest()
    {
        var result = this.provider
            .GetRequiredService<GooglePlaces.DetailsApi>();

        Assert.IsInstanceOfType<HttpEngine<PlacesDetailsRequest, PlacesDetailsResponse>>(result);
    }

    [TestMethod]
    public void ResolvePlacesDetailsApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IDetailsApi>();

        Assert.IsInstanceOfType<GooglePlaces.DetailsApi>(result);
        Assert.IsInstanceOfType<HttpEngine<PlacesDetailsRequest, PlacesDetailsResponse>>(result);
    }

    [TestMethod]
    public void ResolvePlacesPhotosApiTest()
    {
        var result = this.provider
            .GetRequiredService<GooglePlaces.PhotosApi>();

        Assert.IsInstanceOfType<HttpEngine<PlacesPhotosRequest, PlacesPhotosResponse>>(result);
    }

    [TestMethod]
    public void ResolvePlacesPhotosApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IPhotosApi>();

        Assert.IsInstanceOfType<GooglePlaces.PhotosApi>(result);
        Assert.IsInstanceOfType<HttpEngine<PlacesPhotosRequest, PlacesPhotosResponse>>(result);
    }

    [TestMethod]
    public void ResolvePlacesQueryAutoCompleteApiTest()
    {
        var result = this.provider
            .GetRequiredService<GooglePlaces.QueryAutoCompleteApi>();

        Assert.IsInstanceOfType<HttpEngine<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse>>(result);
    }

    [TestMethod]
    public void ResolvePlacesQueryAutoCompleteApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IQueryAutoCompleteApi>();

        Assert.IsInstanceOfType<GooglePlaces.QueryAutoCompleteApi>(result);
        Assert.IsInstanceOfType<HttpEngine<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse>>(result);
    }

    [TestMethod]
    public void ResolvePlacesSearchFindSearchApiTest()
    {
        var result = this.provider
            .GetRequiredService<GooglePlaces.Search.FindSearchApi>();

        Assert.IsInstanceOfType<HttpEngine<PlacesFindSearchRequest, PlacesFindSearchResponse>>(result);
    }

    [TestMethod]
    public void ResolvePlacesSearchFindSearchApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IFindSearchApi>();

        Assert.IsInstanceOfType<GooglePlaces.Search.FindSearchApi>(result);
        Assert.IsInstanceOfType<HttpEngine<PlacesFindSearchRequest, PlacesFindSearchResponse>>(result);
    }

    [TestMethod]
    public void ResolvePlacesSearchNearBySearchApiTest()
    {
        var result = this.provider
            .GetRequiredService<GooglePlaces.Search.NearBySearchApi>();

        Assert.IsInstanceOfType<HttpEngine<PlacesNearBySearchRequest, PlacesNearbySearchResponse>>(result);
    }

    [TestMethod]
    public void ResolvePlacesSearchNearBySearchApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<INearBySearchApi>();

        Assert.IsInstanceOfType<GooglePlaces.Search.NearBySearchApi>(result);
        Assert.IsInstanceOfType<HttpEngine<PlacesNearBySearchRequest, PlacesNearbySearchResponse>>(result);
    }

    [TestMethod]
    public void ResolvePlacesSearchTextSearchApiTest()
    {
        var result = this.provider
            .GetRequiredService<GooglePlaces.Search.TextSearchApi>();

        Assert.IsInstanceOfType<HttpEngine<PlacesTextSearchRequest, PlacesTextSearchResponse>>(result);
    }

    [TestMethod]
    public void ResolvePlacesSearchTextSearchApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<ITextSearchApi>();

        Assert.IsInstanceOfType<GooglePlaces.Search.TextSearchApi>(result);
        Assert.IsInstanceOfType<HttpEngine<PlacesTextSearchRequest, PlacesTextSearchResponse>>(result);
    }


    [TestMethod]
    public void ResolveSearchWebSearchApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleSearch.WebSearchApi>();

        Assert.IsInstanceOfType<HttpEngine<WebSearchRequest, BaseSearchResponse>>(result);
    }

    [TestMethod]
    public void ResolveSearchWebSearchApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IWebSearchApi>();

        Assert.IsInstanceOfType<GoogleSearch.WebSearchApi>(result);
        Assert.IsInstanceOfType<HttpEngine<WebSearchRequest, BaseSearchResponse>>(result);
    }

    [TestMethod]
    public void ResolveSearchImageSearchApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleSearch.ImageSearchApi>();

        Assert.IsInstanceOfType<HttpEngine<ImageSearchRequest, BaseSearchResponse>>(result);
    }

    [TestMethod]
    public void ResolveSearchImageSearchApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IImageSearchApi>();

        Assert.IsInstanceOfType<GoogleSearch.ImageSearchApi>(result);
        Assert.IsInstanceOfType<HttpEngine<ImageSearchRequest, BaseSearchResponse>>(result);
    }

    [TestMethod]
    public void ResolveSearchVideoSearchChannelsApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleSearch.VideoSearch.ChannelsApi>();

        Assert.IsInstanceOfType<HttpEngine<ChannelSearchRequest, ChannelSearchResponse>>(result);
    }

    [TestMethod]
    public void ResolveSearchVideoSearchChannelsApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IChannelsApi>();

        Assert.IsInstanceOfType<GoogleSearch.VideoSearch.ChannelsApi>(result);
        Assert.IsInstanceOfType<HttpEngine<ChannelSearchRequest, ChannelSearchResponse>>(result);
    }

    [TestMethod]
    public void ResolveSearchVideoSearchPlaylistsApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleSearch.VideoSearch.PlaylistsApi>();

        Assert.IsInstanceOfType<HttpEngine<PlaylistSearchRequest, PlaylistSearchResponse>>(result);
    }

    [TestMethod]
    public void ResolveSearchVideoSearchPlaylistsApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IPlaylistsApi>();

        Assert.IsInstanceOfType<GoogleSearch.VideoSearch.PlaylistsApi>(result);
        Assert.IsInstanceOfType<HttpEngine<PlaylistSearchRequest, PlaylistSearchResponse>>(result);
    }

    [TestMethod]
    public void ResolveSearchVideoSearchVideosApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleSearch.VideoSearch.VideosApi>();

        Assert.IsInstanceOfType<HttpEngine<VideoSearchRequest, VideoSearchResponse>>(result);
    }

    [TestMethod]
    public void ResolveSearchVideoSearchVideosApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IVideosApi>();

        Assert.IsInstanceOfType<GoogleSearch.VideoSearch.VideosApi>(result);
        Assert.IsInstanceOfType<HttpEngine<VideoSearchRequest, VideoSearchResponse>>(result);
    }


    [TestMethod]
    public void ResolveTranslateTranslateApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleTranslate.TranslateApi>();

        Assert.IsInstanceOfType<HttpEngine<TranslateRequest, TranslateResponse>>(result);
    }

    [TestMethod]
    public void ResolveTranslateTranslateApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<ITranslateApi>();

        Assert.IsInstanceOfType<GoogleTranslate.TranslateApi>(result);
        Assert.IsInstanceOfType<HttpEngine<TranslateRequest, TranslateResponse>>(result);
    }

    [TestMethod]
    public void ResolveTranslateDetectApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleTranslate.DetectApi>();

        Assert.IsInstanceOfType<HttpEngine<DetectRequest, DetectResponse>>(result);
    }

    [TestMethod]
    public void ResolveTranslateDetectApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IDetectApi>();

        Assert.IsInstanceOfType<GoogleTranslate.DetectApi>(result);
        Assert.IsInstanceOfType<HttpEngine<DetectRequest, DetectResponse>>(result);
    }

    [TestMethod]
    public void ResolveTranslateLanguagesApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleTranslate.LanguagesApi>();

        Assert.IsInstanceOfType<HttpEngine<LanguagesRequest, LanguagesResponse>>(result);
    }

    [TestMethod]
    public void ResolveTranslateLanguagesApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<ILanguagesApi>();

        Assert.IsInstanceOfType<GoogleTranslate.LanguagesApi>(result);
        Assert.IsInstanceOfType<HttpEngine<LanguagesRequest, LanguagesResponse>>(result);
    }
}