using System;
using GoogleApi.Entities.Maps.Routes.Directions.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Maps.Routes.Directions;

[TestClass]
public class RouteDirectionsRequestTests
{
    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new RoutesDirectionsRequest
        {
            Key = null
        };

        var exception = Assert.Throws<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsEmptyTest()
    {
        var request = new RoutesDirectionsRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }
}