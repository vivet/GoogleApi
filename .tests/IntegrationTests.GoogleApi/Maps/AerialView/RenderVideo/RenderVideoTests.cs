using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.AerialView.RenderVideo.Request;
using GoogleApi.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.GoogleApi.Maps.AerialView.RenderVideo;

[TestClass]
public class RenderVideoTests : BaseTest
{
    [TestMethod]
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

    [TestMethod]
    public async Task RenderVideoWhenBadRequestTest()
    {
        var request = new RenderVideoRequest
        {
            Key = this.Settings.ApiKey,
            Address = "test"
        };

        var exception = await Assert.ThrowsAsync<GoogleApiException>(async () => await GoogleMaps.AerialView.RenderVideo.QueryAsync(request));

        Assert.IsNotNull(exception);
        Assert.AreEqual("InvalidArgument: Address not supported.", exception.Message);
    }
}