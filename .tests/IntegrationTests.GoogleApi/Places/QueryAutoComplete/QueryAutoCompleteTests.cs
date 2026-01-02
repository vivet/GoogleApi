using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.GoogleApi.Places.QueryAutoComplete;

[TestClass]
public class QueryAutoCompleteTests : BaseTest
{
    [TestMethod]
    public async Task PlacesQueryAutoCompleteTest()
    {
        var request = new PlacesQueryAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            Language = Language.English
        };

        var response = await GooglePlaces.QueryAutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task PlacesAutoCompleteWhenOffsetTest()
    {
        var request = new PlacesQueryAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            Offset = "offset"
        };

        var response = await GooglePlaces.QueryAutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task PlacesAutoCompleteWhenLocationTest()
    {
        var request = new PlacesQueryAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            Location = new Coordinate(1, 1)
        };

        var response = await GooglePlaces.QueryAutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task PlacesAutoCompleteWhenLocationAndRadiusTest()
    {
        var request = new PlacesQueryAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            Radius = 100
        };

        var response = await GooglePlaces.QueryAutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }
}