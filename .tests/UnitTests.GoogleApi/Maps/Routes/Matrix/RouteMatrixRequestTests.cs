using System;
using GoogleApi.Entities.Maps.Routes.Matrix.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Maps.Routes.Matrix;

[TestClass]
public class RouteMatrixRequestTests
{
    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new RoutesMatrixRequest
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
        var request = new RoutesMatrixRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }
}