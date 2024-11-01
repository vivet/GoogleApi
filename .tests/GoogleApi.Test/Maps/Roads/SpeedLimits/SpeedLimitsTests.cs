using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Roads.Common;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Request;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.Test.Maps.Roads.SpeedLimits;

[TestClass]
public class SpeedLimitsTests : BaseTest
{
    [TestMethod]
    [Ignore("Requires Enterprise License")]
    public async Task SpeedLimitsTest()
    {
        var request = new SpeedLimitsRequest
        {
            Key = this.Settings.ApiKey,
            Path = new[]
            {
                new Coordinate(60.170880, 24.942795),
                new Coordinate(60.170879, 24.942796),
                new Coordinate(60.170877, 24.942796)
            }
        };

        var result = await GoogleMaps.Roads.SpeedLimits.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [TestMethod]
    [Ignore("Requires Enterprise License")]
    public async Task SpeedLimitsWhenPlaceIdsTest()
    {
        var request = new SpeedLimitsRequest
        {
            Key = this.Settings.ApiKey,
            Places = new[]
            {
                new Place("ChIJaSLMpEVQUkYRL4xNOWBfwhQ"),
                new Place("ChIJuc03_GlQUkYRlLku0KsLdJw")
            }
        };

        var result = await GoogleMaps.Roads.SpeedLimits.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }
}