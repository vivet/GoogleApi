using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.PlacesNew.Search.Text.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.Test.PlacesNew.Search.Text;

[TestClass]
public class TextSearchNewTests : BaseTest
{
    [TestMethod]
    public async Task PlacesNewTextSearchTest()
    {
        var request = new PlacesNewTextSearchRequest
        {
            Key = this.Settings.ApiKey,
            TextQuery = "picadelly circus"
        };

        var response = await GooglePlacesNew.Search.TextSearch.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
        Assert.IsNotEmpty(response.Places);
    }

    [TestMethod]
    public async Task PlacesNewTextSearchWhenIncludedTypeTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNewTextSearchWhenIncludePureServiceAreaBusinessesTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNewTextSearchWhenLanguageTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNewTextSearchWhenLocationBiasTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNewTextSearchWhenLocationRestrictionTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNewTextSearchWhenEvOptionsTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNewTextSearchWhenMinRatingTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNewTextSearchWhenOpenNowTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNewTextSearchWhenPageSizeTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNewTextSearchWhenPageTokenTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNewTextSearchWhenPriceLevelsTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNewTextSearchWhenRankPreferenceTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNewTextSearchWhenRegionTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNewTextSearchWhenStrictTypeFilteringTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNewTextSearchWhenRoutingParametersTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNewTextSearchWhenSearchAlongRouteParametersTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }
}