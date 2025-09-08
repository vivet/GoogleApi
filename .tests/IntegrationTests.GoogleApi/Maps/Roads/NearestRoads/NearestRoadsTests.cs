using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Request;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.Test.Maps.Roads.NearestRoads;

[TestClass]
public class NearestRoadsTests : BaseTest
{
    [TestMethod]
    public async Task NearestRoadsTest()
    {
        var request = new NearestRoadsRequest
        {
            Key = this.Settings.ApiKey,
            Points =
            [
                new LatLng(60.170880, 24.942795),
                new LatLng(60.170879, 24.942796),
                new LatLng(60.170877, 24.942796)
            ]
        };

        var result = await GoogleMaps.Roads.NearestRoads.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }
}