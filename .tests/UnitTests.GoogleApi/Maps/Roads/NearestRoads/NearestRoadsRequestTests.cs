using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Maps.Roads.NearestRoads;

[TestClass]
public class NearestRoadsRequestTests
{
    [TestMethod]
    public void GetQueryStringParametersTest()
    {
        var request = new NearestRoadsRequest
        {
            Key = "key",
            Points =
            [
                new LatLng(1, 1),
                new LatLng(2, 2)
            ]
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.SingleOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var points = queryStringParameters.FirstOrDefault(x => x.Key == "points");
        var pointsExpected = string.Join("|", request.Points);
        Assert.IsNotNull(points);
        Assert.AreEqual(pointsExpected, points.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new NearestRoadsRequest
        {
            Key = null
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
    {
        var request = new NearestRoadsRequest
        {
            Key = string.Empty
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenPointsIsNullTest()
    {
        var request = new NearestRoadsRequest
        {
            Key = "key"
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Points' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenPathCotaninsMoreThanHundredLocationsTest()
    {
        var request = new NearestRoadsRequest
        {
            Key = "abc",
            Points = new LatLng[101]
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Points' must contain equal or less than 100 coordinates");
    }
}