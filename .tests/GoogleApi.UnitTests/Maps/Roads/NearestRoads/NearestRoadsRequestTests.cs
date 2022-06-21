using System;
using System.Linq;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Request;
using NUnit.Framework;
using Coordinate = GoogleApi.Entities.Maps.Roads.Common.Coordinate;

namespace GoogleApi.UnitTests.Maps.Roads.NearestRoads;

[TestFixture]
public class NearestRoadsRequestTests
{
    [Test]
    public void GetQueryStringParametersTest()
    {
        var request = new NearestRoadsRequest
        {
            Key = "key",
            Points = new[]
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

        var points = queryStringParameters.FirstOrDefault(x => x.Key == "points");
        var pointsExpected = string.Join("|", request.Points);
        Assert.IsNotNull(points);
        Assert.AreEqual(pointsExpected, points.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new NearestRoadsRequest
        {
            Key = null
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }

    [Test]
    public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
    {
        var request = new NearestRoadsRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }

    [Test]
    public void GetQueryStringParametersWhenPointsIsNullTest()
    {
        var request = new NearestRoadsRequest
        {
            Key = "key"
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Points' is required");
    }

    [Test]
    public void GetQueryStringParametersWhenPathCotaninsMoreThanHundredLocationsTest()
    {
        var request = new NearestRoadsRequest
        {
            Key = "abc",
            Points = new Coordinate[101]
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Points' must contain equal or less than 100 coordinates");
    }
}