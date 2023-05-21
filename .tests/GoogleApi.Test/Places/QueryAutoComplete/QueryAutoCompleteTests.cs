using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GoogleApi.Test.Places.QueryAutoComplete;

[TestFixture]
public class QueryAutoCompleteTests : BaseTest
{
    [Test]
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

    [Test]
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

    [Test]
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

    [Test]
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