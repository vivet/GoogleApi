using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.AerialView.RenderVideo.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.AerialView.RenderVideo;

[TestFixture]
public class RenderVideoTests : BaseTest
{
    [Test]
    public async Task RenderVideoTest()
    {
        var request = new RenderVideoRequest
        {
            Key = this.Settings.ApiKey,
            Address = "500 W 2nd St, Austin, TX 78701"
        };

        var result = await GoogleMaps.AerialView.RenderVideo.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void RenderVideoWhenBadRequestTest()
    {
        var request = new RenderVideoRequest
        {
            Key = this.Settings.ApiKey,
            Address = "test"
        };

        var exception = Assert.ThrowsAsync<GoogleApiException>(async () => await GoogleMaps.AerialView.RenderVideo.QueryAsync(request));
        Assert.IsNotNull(exception);
        Assert.AreEqual("InvalidArgument: Address not supported.", exception.Message);
    }
}