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
using GoogleApi.Extensions;
using GoogleApi.Interfaces.Maps;
using GoogleApi.Interfaces.Maps.Geocode;
using GoogleApi.Interfaces.Maps.Roads;
using GoogleApi.Interfaces.Places;
using GoogleApi.Interfaces.Places.Search;
using GoogleApi.Interfaces.Search;
using GoogleApi.Interfaces.Search.Video;
using GoogleApi.Interfaces.Translate;

namespace GoogleApi.UnitTests.Extensions;

[TestFixture]
public class ServiceCollectionExtensionTests
{
    private IServiceProvider provider;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        var services = new ServiceCollection();
        services
            .AddGoogleApiClients();

        this.provider = services
            .BuildServiceProvider();
    }

    [Test]
    public void ResolveGoogleApiClientTest()
    {
        var httpClientFactory = this.provider
            .GetRequiredService<IHttpClientFactory>();

        var httpClient = httpClientFactory
            .CreateClient(nameof(GoogleApi));

        Assert.IsInstanceOf<HttpClient>(httpClient);

        var expected = new MediaTypeWithQualityHeaderValue("application/json");
        Assert.Contains(expected, httpClient.DefaultRequestHeaders.Accept.ToArray());

        Assert.AreEqual(httpClient.Timeout, TimeSpan.FromSeconds(30));

        var defaultHttpClientHandler = HttpClientFactory.GetDefaultHttpClientHandler();

        var hasGZip = defaultHttpClientHandler.AutomaticDecompression.HasFlag(DecompressionMethods.GZip);
        Assert.True(hasGZip);

        var hasDeflate = defaultHttpClientHandler.AutomaticDecompression.HasFlag(DecompressionMethods.Deflate);
        Assert.True(hasDeflate);
    }


    [Test]
    public void ResolveMapsDirectionsApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.DirectionsApi>();

        Assert.IsInstanceOf<HttpEngine<DirectionsRequest, DirectionsResponse>>(result);
    }

    [Test]
    public void ResolveMapsDirectionsApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IDirectionsApi>();

        Assert.IsInstanceOf<GoogleMaps.DirectionsApi>(result);
        Assert.IsInstanceOf<HttpEngine<DirectionsRequest, DirectionsResponse>>(result);
    }

    [Test]
    public void ResolveMapsDistanceMatrixApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.DistanceMatrixApi>();

        Assert.IsInstanceOf<HttpEngine<DistanceMatrixRequest, DistanceMatrixResponse>>(result);
    }

    [Test]
    public void ResolveMapsDistanceMatrixApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IDistanceMatrixApi>();

        Assert.IsInstanceOf<GoogleMaps.DistanceMatrixApi>(result);
        Assert.IsInstanceOf<HttpEngine<DistanceMatrixRequest, DistanceMatrixResponse>>(result);
    }

    [Test]
    public void ResolveMapsElevationApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.ElevationApi>();

        Assert.IsInstanceOf<HttpEngine<ElevationRequest, ElevationResponse>>(result);
    }

    [Test]
    public void ResolveMapsElevationApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IElevationApi>();

        Assert.IsInstanceOf<GoogleMaps.ElevationApi>(result);
        Assert.IsInstanceOf<HttpEngine<ElevationRequest, ElevationResponse>>(result);
    }

    [Test]
    public void ResolveMapsGeolocationApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.GeolocationApi>();

        Assert.IsInstanceOf<HttpEngine<GeolocationRequest, GeolocationResponse>>(result);
    }

    [Test]
    public void ResolveMapsGeolocationApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IGeolocationApi>();

        Assert.IsInstanceOf<GoogleMaps.GeolocationApi>(result);
        Assert.IsInstanceOf<HttpEngine<GeolocationRequest, GeolocationResponse>>(result);
    }

    [Test]
    public void ResolveMapsGeocodeAddressGeocodeApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.Geocode.AddressGeocodeApi>();

        Assert.IsInstanceOf<HttpEngine<AddressGeocodeRequest, GeocodeResponse>>(result);
    }

    [Test]
    public void ResolveMapsGeocodeAddressGeocodeApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IAddressGeocodeApi>();

        Assert.IsInstanceOf<GoogleMaps.Geocode.AddressGeocodeApi>(result);
        Assert.IsInstanceOf<HttpEngine<AddressGeocodeRequest, GeocodeResponse>>(result);
    }

    [Test]
    public void ResolveMapsGeocodeLocationGeocodeApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.Geocode.LocationGeocodeApi>();

        Assert.IsInstanceOf<HttpEngine<LocationGeocodeRequest, GeocodeResponse>>(result);
    }

    [Test]
    public void ResolveMapsGeocodeLocationGeocodeApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<ILocationGeocodeApi>();

        Assert.IsInstanceOf<GoogleMaps.Geocode.LocationGeocodeApi>(result);
        Assert.IsInstanceOf<HttpEngine<LocationGeocodeRequest, GeocodeResponse>>(result);
    }

    [Test]
    public void ResolveMapsGeocodePlaceGeoCodeApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.Geocode.PlaceGeocodeApi>();

        Assert.IsInstanceOf<HttpEngine<PlaceGeocodeRequest, GeocodeResponse>>(result);
    }

    [Test]
    public void ResolveMapsGeocodePlaceGeoCodeApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IPlaceGeocodeApi>();

        Assert.IsInstanceOf<GoogleMaps.Geocode.PlaceGeocodeApi>(result);
        Assert.IsInstanceOf<HttpEngine<PlaceGeocodeRequest, GeocodeResponse>>(result);
    }

    [Test]
    public void ResolveMapsGeocodePlusCodeGeocodeApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.Geocode.PlusCodeGeocodeApi>();

        Assert.IsInstanceOf<HttpEngine<PlusCodeGeocodeRequest, PlusCodeGeocodeResponse>>(result);
    }

    [Test]
    public void ResolveMapsGeocodePlusCodeGeocodeApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IPlusCodeGeocodeApi>();

        Assert.IsInstanceOf<GoogleMaps.Geocode.PlusCodeGeocodeApi>(result);
        Assert.IsInstanceOf<HttpEngine<PlusCodeGeocodeRequest, PlusCodeGeocodeResponse>>(result);
    }

    [Test]
    public void ResolveMapsRoadsNearestRoadsApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.Roads.NearestRoadsApi>();

        Assert.IsInstanceOf<HttpEngine<NearestRoadsRequest, NearestRoadsResponse>>(result);
    }

    [Test]
    public void ResolveMapsRoadsNearestRoadsApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<INearestRoadsApi>();

        Assert.IsInstanceOf<GoogleMaps.Roads.NearestRoadsApi>(result);
        Assert.IsInstanceOf<HttpEngine<NearestRoadsRequest, NearestRoadsResponse>>(result);
    }

    [Test]
    public void ResolveMapsRoadsSnapToRoadApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.Roads.SnapToRoadApi>();

        Assert.IsInstanceOf<HttpEngine<SnapToRoadsRequest, SnapToRoadsResponse>>(result);
    }

    [Test]
    public void ResolveMapsRoadsSnapToRoadApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<ISnapToRoadApi>();

        Assert.IsInstanceOf<GoogleMaps.Roads.SnapToRoadApi>(result);
        Assert.IsInstanceOf<HttpEngine<SnapToRoadsRequest, SnapToRoadsResponse>>(result);
    }

    [Test]
    public void ResolveMapsRoadsSpeedLimitsApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.Roads.SpeedLimitsApi>();

        Assert.IsInstanceOf<HttpEngine<SpeedLimitsRequest, SpeedLimitsResponse>>(result);
    }

    [Test]
    public void ResolveMapsRoadsSpeedLimitsApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<ISpeedLimitsApi>();

        Assert.IsInstanceOf<GoogleMaps.Roads.SpeedLimitsApi>(result);
        Assert.IsInstanceOf<HttpEngine<SpeedLimitsRequest, SpeedLimitsResponse>>(result);
    }

    [Test]
    public void ResolveMapsStreetViewApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.StreetViewApi>();

        Assert.IsInstanceOf<HttpEngine<StreetViewRequest, StreetViewResponse>>(result);
    }

    [Test]
    public void ResolveMapsStreetViewApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IStreetViewApi>();

        Assert.IsInstanceOf<GoogleMaps.StreetViewApi>(result);
        Assert.IsInstanceOf<HttpEngine<StreetViewRequest, StreetViewResponse>>(result);
    }

    [Test]
    public void ResolveMapsStaticMapsApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.StaticMapsApi>();

        Assert.IsInstanceOf<HttpEngine<StaticMapsRequest, StaticMapsResponse>>(result);
    }

    [Test]
    public void ResolveMapsStaticMapsApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IStaticMapsApi>();

        Assert.IsInstanceOf<GoogleMaps.StaticMapsApi>(result);
        Assert.IsInstanceOf<HttpEngine<StaticMapsRequest, StaticMapsResponse>>(result);
    }

    [Test]
    public void ResolveMapsTimeZoneApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleMaps.TimeZoneApi>();

        Assert.IsInstanceOf<HttpEngine<TimeZoneRequest, TimeZoneResponse>>(result);
    }

    [Test]
    public void ResolveMapsTimeZoneApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<ITimeZoneApi>();

        Assert.IsInstanceOf<GoogleMaps.TimeZoneApi>(result);
        Assert.IsInstanceOf<HttpEngine<TimeZoneRequest, TimeZoneResponse>>(result);
    }


    [Test]
    public void ResolvePlacesAutoCompleteApiTest()
    {
        var result = this.provider
            .GetRequiredService<GooglePlaces.AutoCompleteApi>();

        Assert.IsInstanceOf<HttpEngine<PlacesAutoCompleteRequest, PlacesAutoCompleteResponse>>(result);
    }

    [Test]
    public void ResolvePlacesAutoCompleteApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IAutoCompleteApi>();

        Assert.IsInstanceOf<GooglePlaces.AutoCompleteApi>(result);
        Assert.IsInstanceOf<HttpEngine<PlacesAutoCompleteRequest, PlacesAutoCompleteResponse>>(result);
    }

    [Test]
    public void ResolvePlacesDetailsApiTest()
    {
        var result = this.provider
            .GetRequiredService<GooglePlaces.DetailsApi>();

        Assert.IsInstanceOf<HttpEngine<PlacesDetailsRequest, PlacesDetailsResponse>>(result);
    }

    [Test]
    public void ResolvePlacesDetailsApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IDetailsApi>();

        Assert.IsInstanceOf<GooglePlaces.DetailsApi>(result);
        Assert.IsInstanceOf<HttpEngine<PlacesDetailsRequest, PlacesDetailsResponse>>(result);
    }

    [Test]
    public void ResolvePlacesPhotosApiTest()
    {
        var result = this.provider
            .GetRequiredService<GooglePlaces.PhotosApi>();

        Assert.IsInstanceOf<HttpEngine<PlacesPhotosRequest, PlacesPhotosResponse>>(result);
    }

    [Test]
    public void ResolvePlacesPhotosApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IPhotosApi>();

        Assert.IsInstanceOf<GooglePlaces.PhotosApi>(result);
        Assert.IsInstanceOf<HttpEngine<PlacesPhotosRequest, PlacesPhotosResponse>>(result);
    }

    [Test]
    public void ResolvePlacesQueryAutoCompleteApiTest()
    {
        var result = this.provider
            .GetRequiredService<GooglePlaces.QueryAutoCompleteApi>();

        Assert.IsInstanceOf<HttpEngine<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse>>(result);
    }

    [Test]
    public void ResolvePlacesQueryAutoCompleteApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IQueryAutoCompleteApi>();

        Assert.IsInstanceOf<GooglePlaces.QueryAutoCompleteApi>(result);
        Assert.IsInstanceOf<HttpEngine<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse>>(result);
    }

    [Test]
    public void ResolvePlacesSearchFindSearchApiTest()
    {
        var result = this.provider
            .GetRequiredService<GooglePlaces.Search.FindSearchApi>();

        Assert.IsInstanceOf<HttpEngine<PlacesFindSearchRequest, PlacesFindSearchResponse>>(result);
    }

    [Test]
    public void ResolvePlacesSearchFindSearchApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IFindSearchApi>();

        Assert.IsInstanceOf<GooglePlaces.Search.FindSearchApi>(result);
        Assert.IsInstanceOf<HttpEngine<PlacesFindSearchRequest, PlacesFindSearchResponse>>(result);
    }

    [Test]
    public void ResolvePlacesSearchNearBySearchApiTest()
    {
        var result = this.provider
            .GetRequiredService<GooglePlaces.Search.NearBySearchApi>();

        Assert.IsInstanceOf<HttpEngine<PlacesNearBySearchRequest, PlacesNearbySearchResponse>>(result);
    }

    [Test]
    public void ResolvePlacesSearchNearBySearchApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<INearBySearchApi>();

        Assert.IsInstanceOf<GooglePlaces.Search.NearBySearchApi>(result);
        Assert.IsInstanceOf<HttpEngine<PlacesNearBySearchRequest, PlacesNearbySearchResponse>>(result);
    }

    [Test]
    public void ResolvePlacesSearchTextSearchApiTest()
    {
        var result = this.provider
            .GetRequiredService<GooglePlaces.Search.TextSearchApi>();

        Assert.IsInstanceOf<HttpEngine<PlacesTextSearchRequest, PlacesTextSearchResponse>>(result);
    }

    [Test]
    public void ResolvePlacesSearchTextSearchApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<ITextSearchApi>();

        Assert.IsInstanceOf<GooglePlaces.Search.TextSearchApi>(result);
        Assert.IsInstanceOf<HttpEngine<PlacesTextSearchRequest, PlacesTextSearchResponse>>(result);
    }


    [Test]
    public void ResolveSearchWebSearchApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleSearch.WebSearchApi>();

        Assert.IsInstanceOf<HttpEngine<WebSearchRequest, BaseSearchResponse>>(result);
    }

    [Test]
    public void ResolveSearchWebSearchApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IWebSearchApi>();

        Assert.IsInstanceOf<GoogleSearch.WebSearchApi>(result);
        Assert.IsInstanceOf<HttpEngine<WebSearchRequest, BaseSearchResponse>>(result);
    }

    [Test]
    public void ResolveSearchImageSearchApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleSearch.ImageSearchApi>();

        Assert.IsInstanceOf<HttpEngine<ImageSearchRequest, BaseSearchResponse>>(result);
    }

    [Test]
    public void ResolveSearchImageSearchApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IImageSearchApi>();

        Assert.IsInstanceOf<GoogleSearch.ImageSearchApi>(result);
        Assert.IsInstanceOf<HttpEngine<ImageSearchRequest, BaseSearchResponse>>(result);
    }

    [Test]
    public void ResolveSearchVideoSearchChannelsApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleSearch.VideoSearch.ChannelsApi>();

        Assert.IsInstanceOf<HttpEngine<ChannelSearchRequest, ChannelSearchResponse>>(result);
    }

    [Test]
    public void ResolveSearchVideoSearchChannelsApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IChannelsApi>();

        Assert.IsInstanceOf<GoogleSearch.VideoSearch.ChannelsApi>(result);
        Assert.IsInstanceOf<HttpEngine<ChannelSearchRequest, ChannelSearchResponse>>(result);
    }

    [Test]
    public void ResolveSearchVideoSearchPlaylistsApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleSearch.VideoSearch.PlaylistsApi>();

        Assert.IsInstanceOf<HttpEngine<PlaylistSearchRequest, PlaylistSearchResponse>>(result);
    }

    [Test]
    public void ResolveSearchVideoSearchPlaylistsApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IPlaylistsApi>();

        Assert.IsInstanceOf<GoogleSearch.VideoSearch.PlaylistsApi>(result);
        Assert.IsInstanceOf<HttpEngine<PlaylistSearchRequest, PlaylistSearchResponse>>(result);
    }

    [Test]
    public void ResolveSearchVideoSearchVideosApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleSearch.VideoSearch.VideosApi>();

        Assert.IsInstanceOf<HttpEngine<VideoSearchRequest, VideoSearchResponse>>(result);
    }

    [Test]
    public void ResolveSearchVideoSearchVideosApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IVideosApi>();

        Assert.IsInstanceOf<GoogleSearch.VideoSearch.VideosApi>(result);
        Assert.IsInstanceOf<HttpEngine<VideoSearchRequest, VideoSearchResponse>>(result);
    }


    [Test]
    public void ResolveTranslateTranslateApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleTranslate.TranslateApi>();

        Assert.IsInstanceOf<HttpEngine<TranslateRequest, TranslateResponse>>(result);
    }

    [Test]
    public void ResolveTranslateTranslateApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<ITranslateApi>();

        Assert.IsInstanceOf<GoogleTranslate.TranslateApi>(result);
        Assert.IsInstanceOf<HttpEngine<TranslateRequest, TranslateResponse>>(result);
    }

    [Test]
    public void ResolveTranslateDetectApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleTranslate.DetectApi>();

        Assert.IsInstanceOf<HttpEngine<DetectRequest, DetectResponse>>(result);
    }

    [Test]
    public void ResolveTranslateDetectApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<IDetectApi>();

        Assert.IsInstanceOf<GoogleTranslate.DetectApi>(result);
        Assert.IsInstanceOf<HttpEngine<DetectRequest, DetectResponse>>(result);
    }

    [Test]
    public void ResolveTranslateLanguagesApiTest()
    {
        var result = this.provider
            .GetRequiredService<GoogleTranslate.LanguagesApi>();

        Assert.IsInstanceOf<HttpEngine<LanguagesRequest, LanguagesResponse>>(result);
    }

    [Test]
    public void ResolveTranslateLanguagesApiInterfaceTest()
    {
        var result = this.provider
            .GetRequiredService<ILanguagesApi>();

        Assert.IsInstanceOf<GoogleTranslate.LanguagesApi>(result);
        Assert.IsInstanceOf<HttpEngine<LanguagesRequest, LanguagesResponse>>(result);
    }
}