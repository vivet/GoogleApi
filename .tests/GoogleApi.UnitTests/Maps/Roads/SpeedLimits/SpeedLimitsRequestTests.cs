using System;
using System.Linq;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Roads.Common;
using GoogleApi.Entities.Maps.Roads.Common.Enums;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Maps.Roads.SpeedLimits;

[TestClass]
public class SpeedLimitsRequestTests
{
    [TestMethod]
    public void ConstructorDefaultTest()
    {
        var request = new SpeedLimitsRequest();
        Assert.AreEqual(Units.Kph, request.Unit);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenPathTest()
    {
        var request = new SpeedLimitsRequest
        {
            Key = "key",
            Path = new[]
            {
                new Coordinate(1, 1),
                new Coordinate(2, 2)
            }
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.SingleOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var path = queryStringParameters.FirstOrDefault(x => x.Key == "path");
        var pathExpected = string.Join("|", request.Path);
        Assert.IsNotNull(path);
        Assert.AreEqual(pathExpected, path.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenPathAndTooManyTest()
    {
        var request = new SpeedLimitsRequest
        {
            Key = "key",
            Path = new Coordinate[101]
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Path' must contain equal or less than 100 coordinates");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenPlacesTest()
    {
        var request = new SpeedLimitsRequest
        {
            Key = "key",
            Places = new[]
            {
                new Place("place1"),
                new Place("place2")
            }
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var place1 = queryStringParameters.FirstOrDefault(x => x.Key == "placeId");
        var place1Expected = request.Places.First().ToString();
        Assert.IsNotNull(place1);
        Assert.AreEqual(place1Expected, place1.Value);

        var place2 = queryStringParameters.LastOrDefault(x => x.Key == "placeId");
        var place2Expected = request.Places.Last().ToString();
        Assert.IsNotNull(place2);
        Assert.AreEqual(place2Expected, place2.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenPlacesAndTooManyTest()
    {
        var request = new SpeedLimitsRequest
        {
            Key = "key",
            Places = new Place[101]
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Places' must contain equal or less than 100 places");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new SpeedLimitsRequest
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
        var request = new SpeedLimitsRequest
        {
            Key = string.Empty
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenPathIsNullAndPlacesIsNullTest()
    {
        var request = new SpeedLimitsRequest
        {
            Key = "key"
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Path' or 'Places' is required");
    }
}