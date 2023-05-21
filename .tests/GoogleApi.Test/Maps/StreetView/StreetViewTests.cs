using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.StreetView.Request;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GoogleApi.Test.Maps.StreetView;

[TestFixture]
public class StreetViewTests : BaseTest
{
    [Test]
    public async Task StreetViewWhenLocationTest()
    {
        var request = new StreetViewRequest
        {
            Key = this.Settings.ApiKey,
            Location = new Location(new Coordinate(60.170877, 24.942796))
        };

        var result = await GoogleMaps.StreetView.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task StreetViewWhenPanoramaIdTest()
    {
        var request = new StreetViewRequest
        {
            Key = this.Settings.ApiKey,
            PanoramaId = "-gVtvWrACv2k/Vnh0Vg8Z8YI/AAAAAAABLWA/a-AT4Wb8M"
        };

        var result = await GoogleMaps.StreetView.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task StreetViewWhenHeadingTest()
    {
        var request = new StreetViewRequest
        {
            Key = this.Settings.ApiKey,
            Location = new Location(new Coordinate(60.170877, 24.942796)),
            Heading = 90
        };

        var result = await GoogleMaps.StreetView.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }
}