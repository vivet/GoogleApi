using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Search.NearBy;

[TestFixture]
public class NearBySearchTests : BaseTest
{
    [Test]
    public async Task PlacesNearBySearchTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = this.Settings.ApiKey,
            Location = new Coordinate(51.491431, -3.16668),
            Radius = 1000
        };

        var response = await GooglePlaces.Search.NearBySearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesTextSearchWhenPageTokenTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = this.Settings.ApiKey,
            Location = new Coordinate(51.491431, -3.16668),
            Radius = 1000
        };

        var response = await GooglePlaces.Search.NearBySearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.IsNotNull(response.NextPageToken);

        var requestNextPage = new PlacesNearBySearchRequest
        {
            Key = this.Settings.ApiKey,
            PageToken = response.NextPageToken
        };

        Thread.Sleep(1500);

        var responseNextPage = await GooglePlaces.Search.NearBySearch.QueryAsync(requestNextPage);
        Assert.IsNotNull(responseNextPage);
        Assert.AreNotEqual(response.Results.FirstOrDefault()?.PlaceId, responseNextPage.Results.FirstOrDefault()?.PlaceId);
    }

    [Test]
    public async Task PlacesTextSearchWhenNameTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = this.Settings.ApiKey,
            Location = new Coordinate(51.491431, -3.16668),
            Radius = 25000,
            Name = "cafe"
        };

        var response = await GooglePlaces.Search.NearBySearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesTextSearchWhenKeywordTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = this.Settings.ApiKey,
            Location = new Coordinate(51.491431, -3.16668),
            Radius = 25000,
            Keyword = "cafe"
        };

        var response = await GooglePlaces.Search.NearBySearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesTextSearchWhenTypeTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = this.Settings.ApiKey,
            Location = new Coordinate(51.491431, -3.16668),
            Radius = 25000,
            Type = SearchPlaceType.Cafe
        };

        var response = await GooglePlaces.Search.NearBySearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task PlacesTextSearchWhenPriceLevelMinTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = this.Settings.ApiKey,
            Location = new Coordinate(51.491431, 40.16668),
            Radius = 25000,
            Minprice = PriceLevel.Free
        };

        var response = await GooglePlaces.Search.NearBySearch.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.IsEmpty(response.HtmlAttributions);
        Assert.AreEqual(Status.Ok, response.Status);

        var result = response.Results.FirstOrDefault();
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.PlaceId);
        Assert.GreaterOrEqual(result.PriceLevel, request.Minprice);
    }

    [Test]
    public async Task PlacesTextSearchWhenPriceLevelMaxTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = this.Settings.ApiKey,
            Location = new Coordinate(51.491431, -3.16668),
            Radius = 25000,
            Maxprice = PriceLevel.Expensive
        };

        var response = await GooglePlaces.Search.NearBySearch.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.IsEmpty(response.HtmlAttributions);
        Assert.AreEqual(Status.Ok, response.Status);

        var result = response.Results.FirstOrDefault();
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.PlaceId);
        Assert.LessOrEqual(result.PriceLevel, request.Maxprice);
    }
}