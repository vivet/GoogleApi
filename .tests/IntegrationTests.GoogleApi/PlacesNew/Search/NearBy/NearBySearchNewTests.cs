using System.Linq;
using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.PlacesNew.Common;
using GoogleApi.Entities.PlacesNew.Search.NearBy.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.GoogleApi.PlacesNew.Search.NearBy;

[TestClass]
public class NearBySearchNewTests : BaseTest
{
    [TestMethod]
    public async Task PlacesNearBySearchTest()
    {
        var request = new PlacesNewNearBySearchRequest
        {
            Key = this.Settings.ApiKey,
            LocationRestriction = new WithinCirle
            {
                Circle = new Circle
                {
                    Center = new LatLng
                    {
                        Latitude = 51.491431,
                        Longitude = -3.16668
                    },
                    Radius = 1000
                }
            }
        };

        var response = await GooglePlacesNew.Search.NearBySearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
        Assert.IsNotEmpty(response.Places);
    }

    [TestMethod]
    public async Task PlacesNearBySearchWhenIncludedTypesTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNearBySearchWhenExcludedTypesTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNearBySearchWhenIncludedPrimaryTypesTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNearBySearchWhenExcludedPrimaryTypesTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNearBySearchWhenLanguageTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNearBySearchWhenMaxResultCountTest()
    {
        var request = new PlacesNewNearBySearchRequest
        {
            Key = this.Settings.ApiKey,
            LocationRestriction = new WithinCirle
            {
                Circle = new Circle
                {
                    Center = new LatLng
                    {
                        Latitude = 51.491431,
                        Longitude = -3.16668
                    },
                    Radius = 1000
                }
            },
            MaxResultCount = 2
        };

        var response = await GooglePlacesNew.Search.NearBySearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
        Assert.AreEqual(2, response.Places.Count());
    }

    [TestMethod]
    public async Task PlacesNearBySearchWhenRankPreferenceTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNearBySearchWhenRegionTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNearBySearchWhenRoutingParametersTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }
}