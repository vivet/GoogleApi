using System;
using GoogleApi.Entities.Maps.Geolocation.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Maps.Geolocation;

[TestClass]
public class GeolocationRequestTests
{
    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new GeolocationRequest
        {
            Key = null
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsEmptyTest()
    {
        var request = new GeolocationRequest
        {
            Key = string.Empty
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }
}