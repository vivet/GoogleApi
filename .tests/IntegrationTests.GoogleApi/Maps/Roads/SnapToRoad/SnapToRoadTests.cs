using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.GoogleApi.Maps.Roads.SnapToRoad;

[TestClass]
public class SnapToRoadTests : BaseTest
{
    [TestMethod]
    public async Task SnapToRoadTest()
    {
        var request = new SnapToRoadsRequest
        {
            Key = this.Settings.ApiKey,
            Path =
            [
                new LatLng(60.170880, 24.942795),
                new LatLng(60.170879, 24.942796),
                new LatLng(60.170877, 24.942796)
            ]
        };
        var result = await GoogleMaps.Roads.SnapToRoad.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }
}