using System;
using GoogleApi.Entities.Maps.Routes.Matrix.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Routes.Matrix;

[TestFixture]
public class RouteMatrixRequestTests
{
    [Test]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new RoutesMatrixRequest
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
        var request = new RoutesMatrixRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }
}