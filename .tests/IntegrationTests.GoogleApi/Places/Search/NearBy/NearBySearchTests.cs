using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.GoogleApi.Places.Search.NearBy;

[TestClass]
public class NearBySearchTests : BaseTest
{
    [TestMethod]
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

    [TestMethod]
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

    [TestMethod]
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

    [TestMethod]
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

    [TestMethod]
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

    [TestMethod]
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
        Assert.IsTrue(!response.HtmlAttributions.Any());
        Assert.AreEqual(Status.Ok, response.Status);

        var result = response.Results.FirstOrDefault();
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.PlaceId);
        Assert.IsTrue(result.PriceLevel >= request.Minprice);
    }

    [TestMethod]
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
        Assert.IsTrue(!response.HtmlAttributions.Any());
        Assert.AreEqual(Status.Ok, response.Status);

        var result = response.Results.FirstOrDefault();
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.PlaceId);
        Assert.IsTrue(result.PriceLevel <= request.Maxprice);
    }
}