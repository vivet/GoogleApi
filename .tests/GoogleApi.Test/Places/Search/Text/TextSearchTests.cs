using System.Linq;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.Text.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.Test.Places.Search.Text;

[TestClass]
public class TextSearchTests : BaseTest
{
    [TestMethod]
    public async Task PlacesTextSearchTest()
    {
        var request = new PlacesTextSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "picadelly circus"
        };

        var response = await GooglePlaces.Search.TextSearch.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.IsTrue(!response.HtmlAttributions.Any());
        Assert.AreEqual(Status.Ok, response.Status);

        var result = response.Results.FirstOrDefault();
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.PlaceId);
        Assert.IsNotNull(result.Geometry);
        Assert.IsNotNull(result.Geometry.Location);
        Assert.AreEqual(result.BusinessStatus, BusinessStatus.Operational);
    }

    [TestMethod]
    [Ignore("Returns null for page-token. Can't find good exampel for page-token")]
    public async Task PlacesTextSearchWhenPageTokenTest()
    {
        var request = new PlacesTextSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "hovedvejen denmark"
        };

        var response = await GooglePlaces.Search.TextSearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.IsNotNull(response.NextPageToken);

        var requestNextPage = new PlacesTextSearchRequest
        {
            Key = this.Settings.ApiKey,
            PageToken = response.NextPageToken
        };

        var responseNextPage = await GooglePlaces.Search.TextSearch.QueryAsync(requestNextPage);
        Assert.IsNotNull(responseNextPage);
        Assert.AreNotEqual(response.Results.FirstOrDefault()?.PlaceId, responseNextPage.Results.FirstOrDefault()?.PlaceId);
    }

    [TestMethod]
    public async Task PlacesTextSearchWhenRegionTest()
    {
        var request = new PlacesTextSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "picadelly circus",
            Region = "London"
        };

        var response = await GooglePlaces.Search.TextSearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task PlacesTextSearchWhenRadiusTest()
    {
        var request = new PlacesTextSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "picadelly circus",
            Radius = 5000
        };

        var response = await GooglePlaces.Search.TextSearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task PlacesTextSearchWhenRadiusAndLocationTest()
    {
        var request = new PlacesTextSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "picadelly circus",
            Location = new Coordinate(51.5100913, -0.1345676),
            Radius = 5000
        };

        var response = await GooglePlaces.Search.TextSearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task PlacesTextSearchWhenTypeTest()
    {
        var request = new PlacesTextSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "picadelly circus",
            Type = SearchPlaceType.Cafe
        };

        var response = await GooglePlaces.Search.TextSearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task PlacesTextSearchWhenPriceLevelMinTest()
    {
        var request = new PlacesTextSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "Noma, Copenhagen",
            Minprice = PriceLevel.Expensive
        };

        var response = await GooglePlaces.Search.TextSearch.QueryAsync(request);

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
        var request = new PlacesTextSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "Copenhagen",
            Maxprice = PriceLevel.Expensive
        };

        var response = await GooglePlaces.Search.TextSearch.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.IsTrue(!response.HtmlAttributions.Any());
        Assert.AreEqual(Status.Ok, response.Status);

        var result = response.Results.FirstOrDefault();
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.PlaceId);
        Assert.IsTrue(result.PriceLevel <= request.Maxprice);
    }
}