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

        provider = services
            .BuildServiceProvider();
    }

    [Test]
    public void ResolveGoogleApiClientTest()
    {
        var httpClientFactory = provider
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
    public void ResolveMapsDirectionsApi()
    {
        var result = provider
            .GetRequiredService<GoogleMaps.DirectionsApi>();

        Assert.IsInstanceOf<HttpEngine<DirectionsRequest, DirectionsResponse>>(result);
    }

    [Test]
    public void ResolveMapsDistanceMatrixApi()
    {
        var result = provider
            .GetRequiredService<GoogleMaps.DistanceMatrixApi>();

        Assert.IsInstanceOf<HttpEngine<DistanceMatrixRequest, DistanceMatrixResponse>>(result);
    }

    [Test]
    public void ResolveMapsElevationApi()
    {
        var result = provider
            .GetRequiredService<GoogleMaps.ElevationApi>();

        Assert.IsInstanceOf<HttpEngine<ElevationRequest, ElevationResponse>>(result);
    }

    [Test]
    public void ResolveMapsGeolocationApi()
    {
        var result = provider
            .GetRequiredService<GoogleMaps.GeolocationApi>();

        Assert.IsInstanceOf<HttpEngine<GeolocationRequest, GeolocationResponse>>(result);
    }

    [Test]
    public void ResolveMapsGeocodeAddressGeocodeApi()
    {
        var result = provider
            .GetRequiredService<GoogleMaps.Geocode.AddressGeocodeApi>();

        Assert.IsInstanceOf<HttpEngine<AddressGeocodeRequest, GeocodeResponse>>(result);
    }

    [Test]
    public void ResolveMapsGeocodeLocationGeocodeApi()
    {
        var result = provider
            .GetRequiredService<GoogleMaps.Geocode.LocationGeocodeApi>();

        Assert.IsInstanceOf<HttpEngine<LocationGeocodeRequest, GeocodeResponse>>(result);
    }

    [Test]
    public void ResolveMapsGeocodePlaceGeoCodeApi()
    {
        var result = provider
            .GetRequiredService<GoogleMaps.Geocode.PlaceGeocodeApi>();

        Assert.IsInstanceOf<HttpEngine<PlaceGeocodeRequest, GeocodeResponse>>(result);
    }

    [Test]
    public void ResolveMapsGeocodePlusCodeGeocodeApi()
    {
        var result = provider
            .GetRequiredService<GoogleMaps.Geocode.PlusCodeGeocodeApi>();

        Assert.IsInstanceOf<HttpEngine<PlusCodeGeocodeRequest, PlusCodeGeocodeResponse>>(result);
    }

    [Test]
    public void ResolveMapsRoadsNearestRoadsApi()
    {
        var result = provider
            .GetRequiredService<GoogleMaps.Roads.NearestRoadsApi>();

        Assert.IsInstanceOf<HttpEngine<NearestRoadsRequest, NearestRoadsResponse>>(result);
    }

    [Test]
    public void ResolveMapsRoadsSnapToRoadApi()
    {
        var result = provider
            .GetRequiredService<GoogleMaps.Roads.SnapToRoadApi>();

        Assert.IsInstanceOf<HttpEngine<SnapToRoadsRequest, SnapToRoadsResponse>>(result);
    }

    [Test]
    public void ResolveMapsRoadsSpeedLimitsApi()
    {
        var result = provider
            .GetRequiredService<GoogleMaps.Roads.SpeedLimitsApi>();

        Assert.IsInstanceOf<HttpEngine<SpeedLimitsRequest, SpeedLimitsResponse>>(result);
    }

    [Test]
    public void ResolveMapsStreetViewApi()
    {
        var result = provider
            .GetRequiredService<GoogleMaps.StreetViewApi>();

        Assert.IsInstanceOf<HttpEngine<StreetViewRequest, StreetViewResponse>>(result);
    }

    [Test]
    public void ResolveMapsStaticMapsApi()
    {
        var result = provider
            .GetRequiredService<GoogleMaps.StaticMapsApi>();

        Assert.IsInstanceOf<HttpEngine<StaticMapsRequest, StaticMapsResponse>>(result);
    }

    [Test]
    public void ResolveMapsTimeZoneApi()
    {
        var result = provider
            .GetRequiredService<GoogleMaps.TimeZoneApi>();

        Assert.IsInstanceOf<HttpEngine<TimeZoneRequest, TimeZoneResponse>>(result);
    }


    [Test]
    public void ResolvePlacesAutoCompleteApi()
    {
        var result = provider
            .GetRequiredService<GooglePlaces.AutoCompleteApi>();

        Assert.IsInstanceOf<HttpEngine<PlacesAutoCompleteRequest, PlacesAutoCompleteResponse>>(result);
    }

    [Test]
    public void ResolvePlacesDetailsApi()
    {
        var result = provider
            .GetRequiredService<GooglePlaces.DetailsApi>();

        Assert.IsInstanceOf<HttpEngine<PlacesDetailsRequest, PlacesDetailsResponse>>(result);
    }

    [Test]
    public void ResolvePlacesPhotosApi()
    {
        var result = provider
            .GetRequiredService<GooglePlaces.PhotosApi>();

        Assert.IsInstanceOf<HttpEngine<PlacesPhotosRequest, PlacesPhotosResponse>>(result);
    }

    [Test]
    public void ResolvePlacesQueryAutoCompleteApi()
    {
        var result = provider
            .GetRequiredService<GooglePlaces.QueryAutoCompleteApi>();

        Assert.IsInstanceOf<HttpEngine<PlacesQueryAutoCompleteRequest, PlacesQueryAutoCompleteResponse>>(result);
    }

    [Test]
    public void ResolvePlacesSearchFindSearchApi()
    {
        var result = provider
            .GetRequiredService<GooglePlaces.Search.FindSearchApi>();

        Assert.IsInstanceOf<HttpEngine<PlacesFindSearchRequest, PlacesFindSearchResponse>>(result);
    }

    [Test]
    public void ResolvePlacesSearchNearBySearchApi()
    {
        var result = provider
            .GetRequiredService<GooglePlaces.Search.NearBySearchApi>();

        Assert.IsInstanceOf<HttpEngine<PlacesNearBySearchRequest, PlacesNearbySearchResponse>>(result);
    }

    [Test]
    public void ResolvePlacesSearchTextSearchApi()
    {
        var result = provider
            .GetRequiredService<GooglePlaces.Search.TextSearchApi>();

        Assert.IsInstanceOf<HttpEngine<PlacesTextSearchRequest, PlacesTextSearchResponse>>(result);
    }


    [Test]
    public void ResolveSearchWebSearchApi()
    {
        var result = provider
            .GetRequiredService<GoogleSearch.WebSearchApi>();

        Assert.IsInstanceOf<HttpEngine<WebSearchRequest, BaseSearchResponse>>(result);
    }

    [Test]
    public void ResolveSearchImageSearchApi()
    {
        var result = provider
            .GetRequiredService<GoogleSearch.ImageSearchApi>();

        Assert.IsInstanceOf<HttpEngine<ImageSearchRequest, BaseSearchResponse>>(result);
    }

    [Test]
    public void ResolveSearchVideoSearchChannelsApi()
    {
        var result = provider
            .GetRequiredService<GoogleSearch.VideoSearch.ChannelsApi>();

        Assert.IsInstanceOf<HttpEngine<ChannelSearchRequest, ChannelSearchResponse>>(result);
    }

    [Test]
    public void ResolveSearchVideoSearchPlaylistsApi()
    {
        var result = provider
            .GetRequiredService<GoogleSearch.VideoSearch.PlaylistsApi>();

        Assert.IsInstanceOf<HttpEngine<PlaylistSearchRequest, PlaylistSearchResponse>>(result);
    }

    [Test]
    public void ResolveSearchVideoSearchVideosApi()
    {
        var result = provider
            .GetRequiredService<GoogleSearch.VideoSearch.VideosApi>();

        Assert.IsInstanceOf<HttpEngine<VideoSearchRequest, VideoSearchResponse>>(result);
    }


    [Test]
    public void ResolveTranslateTranslateApi()
    {
        var result = provider
            .GetRequiredService<GoogleTranslate.TranslateApi>();

        Assert.IsInstanceOf<HttpEngine<TranslateRequest, TranslateResponse>>(result);
    }

    [Test]
    public void ResolveTranslateDetectApi()
    {
        var result = provider
            .GetRequiredService<GoogleTranslate.DetectApi>();

        Assert.IsInstanceOf<HttpEngine<DetectRequest, DetectResponse>>(result);
    }

    [Test]
    public void ResolveTranslateLanguagesApi()
    {
        var result = provider
            .GetRequiredService<GoogleTranslate.LanguagesApi>();

        Assert.IsInstanceOf<HttpEngine<LanguagesRequest, LanguagesResponse>>(result);
    }
}