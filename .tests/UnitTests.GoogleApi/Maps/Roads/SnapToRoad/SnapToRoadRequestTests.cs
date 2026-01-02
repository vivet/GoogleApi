using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Maps.Roads.SnapToRoad;

[TestClass]
public class SnapToRoadRequestTests
{
    [TestMethod]
    public void ConstructorDefaultTest()
    {
        var request = new SnapToRoadsRequest();
        Assert.IsFalse(request.Interpolate);
    }

    [TestMethod]
    public void GetQueryStringParametersTest()
    {
        var request = new SnapToRoadsRequest
        {
            Key = "key",
            Path =
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

        var points = queryStringParameters.FirstOrDefault(x => x.Key == "path");
        var pointsExpected = string.Join("|", request.Path);
        Assert.IsNotNull(points);
        Assert.AreEqual(pointsExpected, points.Value);

        var interpolate = queryStringParameters.FirstOrDefault(x => x.Key == "interpolate");
        var interpolateExpected = request.Interpolate.ToString().ToLower();
        Assert.IsNotNull(interpolate);
        Assert.AreEqual(interpolateExpected, interpolate.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new SnapToRoadsRequest
        {
            Key = null
        };

        var exception = Assert.Throws<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
    {
        var request = new SnapToRoadsRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenPointsIsNullTest()
    {
        var request = new SnapToRoadsRequest
        {
            Key = "key"
        };

        var exception = Assert.Throws<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Path' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenPathCotaninsMoreThanHundredLocationsTest()
    {
        var request = new SnapToRoadsRequest
        {
            Key = "abc",
            Path = new LatLng[101]
        };

        var exception = Assert.Throws<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Path' must contain equal or less than 100 coordinates");
    }
}