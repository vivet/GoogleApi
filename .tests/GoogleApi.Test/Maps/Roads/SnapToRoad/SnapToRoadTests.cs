using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Roads.Common;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GoogleApi.Test.Maps.Roads.SnapToRoad;

[TestFixture]
public class SnapToRoadTests : BaseTest
{
    [Test]
    public async Task SnapToRoadTest()
    {
        var request = new SnapToRoadsRequest
        {
            Key = this.Settings.ApiKey,
            Path = new[]
            {
                new Coordinate(60.170880, 24.942795),
                new Coordinate(60.170879, 24.942796),
                new Coordinate(60.170877, 24.942796)
            }
        };
        var result = await GoogleMaps.Roads.SnapToRoad.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }
}