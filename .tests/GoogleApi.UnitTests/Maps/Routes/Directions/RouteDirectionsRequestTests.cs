using System;
using GoogleApi.Entities.Maps.Routes.Directions.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Routes.Directions;

[TestFixture]
public class RouteDirectionsRequestTests
{
    [Test]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new RoutesDirectionsRequest
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
        var request = new RoutesDirectionsRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }
}