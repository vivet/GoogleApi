using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.Test.Places.QueryAutoComplete;

[TestClass]
public class QueryAutoCompleteTests : BaseTest
{
    [TestMethod]
    public async Task PlacesQueryAutoCompleteTest()
    {
        var request = new PlacesQueryAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 K�benhavn",
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
            Input = "jagtvej 2200 K�benhavn",
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
            Input = "jagtvej 2200 K�benhavn",
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
            Input = "jagtvej 2200 K�benhavn",
            Radius = 100
        };

        var response = await GooglePlaces.QueryAutoComplete.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }
}