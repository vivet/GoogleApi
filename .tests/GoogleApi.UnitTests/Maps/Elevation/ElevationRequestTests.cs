using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Elevation.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Elevation;

[TestFixture]
public class ElevationRequestTests
{
    [Test]
    public void GetQueryStringParametersWhenLocationsTest()
    {
        var request = new ElevationRequest
        {
            Key = "key",
            Locations = new[]
            {
                new Coordinate(1, 1)
            }
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.SingleOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var locations = queryStringParameters.FirstOrDefault(x => x.Key == "locations");
        var locationsExpected = string.Join("|", request.Locations);
        Assert.IsNotNull(locations);
        Assert.AreEqual(locationsExpected, locations.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenLocationsWhenMultipleCoordinatesTest()
    {
        var request = new ElevationRequest
        {
            Key = "key",
            Locations = new[]
            {
                new Coordinate(1, 1),
                new Coordinate(2, 2)
            }
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var locations = queryStringParameters.FirstOrDefault(x => x.Key == "locations");
        var locationsExpected = string.Join("|", request.Locations);
        Assert.IsNotNull(locations);
        Assert.AreEqual(locationsExpected, locations.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenPathTest()
    {
        var request = new ElevationRequest
        {
            Key = "key",
            Path = new[]
            {
                new Coordinate(1, 1),
                new Coordinate(2, 2)
            },
            Samples = 2
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var path = queryStringParameters.FirstOrDefault(x => x.Key == "path");
        var pathExpected = string.Join("|", request.Path);
        Assert.IsNotNull(path);
        Assert.AreEqual(pathExpected, path.Value);

        var samples = queryStringParameters.FirstOrDefault(x => x.Key == "samples");
        Assert.AreEqual(request.Samples.ToString(), samples.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenChannelTest()
    {
        var request = new ElevationRequest
        {
            Key = "key",
            Locations = new[]
            {
                new Coordinate(1, 1)
            },
            Channel = "channel"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var channel = queryStringParameters.FirstOrDefault(x => x.Key == "channel");
        var channelExpected = request.Channel;
        Assert.IsNotNull(channel);
        Assert.AreEqual(channelExpected, channel.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new ElevationRequest
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
        var request = new ElevationRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }

    [Test]
    public void GetQueryStringParametersWhenLocationsIsNullTest()
    {
        var request = new ElevationRequest
        {
            Key = "key",
            Locations = null
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Locations' or 'Path' is required", exception.Message);
    }

    [Test]
    public void GetQueryStringParametersWhenLocationsIsEmptyTest()
    {
        var request = new ElevationRequest
        {
            Key = "key",
            Locations = Array.Empty<Coordinate>()
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Locations' or 'Path' is required", exception.Message);
    }

    [Test]
    public void GetQueryStringParametersWhenPathIsNullTest()
    {
        var request = new ElevationRequest
        {
            Key = "key",
            Path = null
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Locations' or 'Path' is required", exception.Message);
    }

    [Test]
    public void GetQueryStringParametersWhenPathIsEmptyTest()
    {
        var request = new ElevationRequest
        {
            Key = "key",
            Path = Array.Empty<Coordinate>()
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Locations' or 'Path' is required", exception.Message);
    }

    [Test]
    public void GetQueryStringParametersWhenPathIsNotEmptyAndLocationsIsNotEmptyTest()
    {
        var request = new ElevationRequest
        {
            Key = "key",
            Locations = new List<Coordinate>
            {
                new(0, 0)
            },
            Path = new List<Coordinate>
            {
                new(0, 0)
            }
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Path' and 'Locations' cannot both be specified", exception.Message);
    }

    [Test]
    public void GetQueryStringParametersWhenPathContainsLessThanTwoCoordinatesTest()
    {
        var request = new ElevationRequest
        {
            Key = "key",
            Path = new[]
            {
                new Coordinate(1, 1)
            }
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("A minimum of two coordinates is required when using 'Path'", exception.Message);
    }

    [Test]
    public void GetQueryStringParametersWhenPathIsNotEmptyAndSamplesIsNullTest()
    {
        var request = new ElevationRequest
        {
            Key = "key",
            Path = new[]
            {
                new Coordinate(1, 1),
                new Coordinate(2, 2)
            },
            Samples = null
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Samples' is required, when using 'Path'", exception.Message);
    }
}