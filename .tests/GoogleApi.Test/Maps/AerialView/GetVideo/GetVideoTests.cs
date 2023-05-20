using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.AerialView.GetVideo.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.AerialView.GetVideo;

[TestFixture]
public class GetVideoTests : BaseTest
{
    [Test]
    public async Task GetVideoWhenVideoIdTest()
    {
        var request = new GetVideoRequest
        {
            Key = this.Settings.ApiKey,
            VideoId = "j7YO1tEF_P4kLi_xJNkdP8"
        };

        var result = await GoogleMaps.AerialView.GetVideo.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task GetVideoWhenAddressTest()
    {
        var request = new GetVideoRequest
        {
            Key = this.Settings.ApiKey,
            Address = "500 W 2nd St, Austin, TX 78701"
        };

        var result = await GoogleMaps.AerialView.GetVideo.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task GetVideoWhenNotFoundTest()
    {
        var request = new GetVideoRequest
        {
            Key = this.Settings.ApiKey,
            Address = "test"
        };

        var result = await GoogleMaps.AerialView.GetVideo.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.NotFound, result.Status);
    }
}