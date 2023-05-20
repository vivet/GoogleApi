using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Roads.Common;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Request;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GoogleApi.Test.Maps.Roads.NearestRoads;

[TestFixture]
public class NearestRoadsTests : BaseTest
{
    [Test]
    public async Task NearestRoadsTest()
    {
        var request = new NearestRoadsRequest
        {
            Key = this.Settings.ApiKey,
            Points = new[]
            {
                new Coordinate(60.170880, 24.942795),
                new Coordinate(60.170879, 24.942796),
                new Coordinate(60.170877, 24.942796)
            }
        };

        var result = await GoogleMaps.Roads.NearestRoads.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }
}