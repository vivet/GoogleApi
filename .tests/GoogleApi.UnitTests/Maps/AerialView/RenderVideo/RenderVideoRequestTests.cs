using System;
using GoogleApi.Entities.Maps.AerialView.RenderVideo.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.AerialView.RenderVideo;

[TestFixture]
public class RenderVideoRequestTests
{
    [Test]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new RenderVideoRequest
        {
            Key = null
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }

    [Test]
    public void GetQueryStringParametersWhenKeyIsEmptyTest()
    {
        var request = new RenderVideoRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }
}