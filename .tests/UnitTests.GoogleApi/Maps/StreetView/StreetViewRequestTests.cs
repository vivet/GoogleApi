using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.StreetView.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Maps.StreetView;

[TestClass]
public class StreetViewRequestTests
{
    [TestMethod]
    public void ConstructorDefaultTest()
    {
        var request = new StreetViewRequest();

        Assert.AreEqual(600, request.Size.Width);
        Assert.AreEqual(400, request.Size.Height);
        Assert.AreEqual(0, request.Pitch);
        Assert.AreEqual(90, request.FieldOfView);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenPanoramaTest()
    {
        var request = new StreetViewRequest
        {
            Key = "key",
            PanoramaId = "panorama_id"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.FirstOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var pano = queryStringParameters.FirstOrDefault(x => x.Key == "pano");
        var panoExpected = request.PanoramaId;
        Assert.IsNotNull(pano);
        Assert.AreEqual(panoExpected, pano.Value);

        var size = queryStringParameters.FirstOrDefault(x => x.Key == "size");
        var sizeExpected = request.Size.ToString();
        Assert.IsNotNull(size);
        Assert.AreEqual(sizeExpected, size.Value);

        var pitch = queryStringParameters.FirstOrDefault(x => x.Key == "pitch");
        var pitchExpected = request.Pitch.ToString();
        Assert.IsNotNull(pitch);
        Assert.AreEqual(pitchExpected, pitch.Value);

        var fov = queryStringParameters.FirstOrDefault(x => x.Key == "fov");
        var fovExpected = request.FieldOfView.ToString();
        Assert.IsNotNull(fov);
        Assert.AreEqual(fovExpected, fov.Value);

        var radius = queryStringParameters.FirstOrDefault(x => x.Key == "radius");
        var radiusExpected = request.Radius.ToString();
        Assert.IsNotNull(radius);
        Assert.AreEqual(radiusExpected, radius.Value);

        var returnErrorCode = queryStringParameters.FirstOrDefault(x => x.Key == "return_error_code");
        var returnErrorCodeExpected = request.ReturnErrorCode.ToString().ToLower();
        Assert.IsNotNull(returnErrorCode);
        Assert.AreEqual(returnErrorCodeExpected, returnErrorCode.Value);

        var source = queryStringParameters.FirstOrDefault(x => x.Key == "source");
        var sourceExpected = request.Source.ToString().ToLower();
        Assert.IsNotNull(source);
        Assert.AreEqual(sourceExpected, source.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenLocationTest()
    {
        var request = new StreetViewRequest
        {
            Key = "key",
            Location = new Location(new Coordinate(1, 1))
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.FirstOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var location = queryStringParameters.FirstOrDefault(x => x.Key == "location");
        var expected = request.Location.ToString();
        Assert.IsNotNull(location);
        Assert.AreEqual(expected, location.Value);

        var size = queryStringParameters.FirstOrDefault(x => x.Key == "size");
        var sizeExpected = request.Size.ToString();
        Assert.IsNotNull(size);
        Assert.AreEqual(sizeExpected, size.Value);

        var pitch = queryStringParameters.FirstOrDefault(x => x.Key == "pitch");
        var pitchExpected = request.Pitch.ToString();
        Assert.IsNotNull(pitch);
        Assert.AreEqual(pitchExpected, pitch.Value);

        var fov = queryStringParameters.FirstOrDefault(x => x.Key == "fov");
        var fovExpected = request.FieldOfView.ToString();
        Assert.IsNotNull(fov);
        Assert.AreEqual(fovExpected, fov.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenChannelTest()
    {
        var request = new StreetViewRequest
        {
            Key = "key",
            Location = new Location(new Coordinate(1, 1)),
            Channel = "channel"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var channel = queryStringParameters.FirstOrDefault(x => x.Key == "channel");
        var channelExpected = request.Channel;
        Assert.IsNotNull(channel);
        Assert.AreEqual(channelExpected, channel.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenHeadingTest()
    {
        var request = new StreetViewRequest
        {
            Key = "key",
            PanoramaId = "panorama_id",
            Heading = 10
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var heading = queryStringParameters.FirstOrDefault(x => x.Key == "heading");
        var headingExpected = request.Heading.ToString();
        Assert.IsNotNull(heading);
        Assert.AreEqual(headingExpected, heading.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new StreetViewRequest
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
        var request = new StreetViewRequest
        {
            Key = string.Empty
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenLocationIsNullAndPanoramIdIsNullTest()
    {
        var request = new StreetViewRequest
        {
            Key = "key",
            PanoramaId = null,
            Location = null
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual("'Location' or 'PanoramaId' is required", exception.Message);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenLocationIsNullAndPanoramIdIsEmptyTest()
    {
        var request = new StreetViewRequest
        {
            Key = "key",
            PanoramaId = string.Empty,
            Location = null
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual("'Location' or 'PanoramaId' is required", exception.Message);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenPitchIsOutOfRangeLowerTest()
    {
        var request = new StreetViewRequest
        {
            Key = "key",
            Location = new Location(new Coordinate(0, 0)),
            Pitch = -100
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Pitch' must be greater than -90 and less than 90");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenPitchIsOutOfRangeHigherTest()
    {
        var request = new StreetViewRequest
        {
            Key = "key",
            Location = new Location(new Coordinate(0, 0)),
            Pitch = 100
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Pitch' must be greater than -90 and less than 90");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenHeadingIsOutOfRangeLowerTest()
    {
        var request = new StreetViewRequest
        {
            Key = "key",
            Location = new Location(new Coordinate(0, 0)),
            Heading = -1
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Heading' must be greater than 0 and less than 360");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenHeadingIsOutOfRangeHigherTest()
    {
        var request = new StreetViewRequest
        {
            Key = "key",
            Location = new Location(new Coordinate(0, 0)),
            Heading = 361
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Heading' must be greater than 0 and less than 360");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenFieldOfViewIsOutOfRangeLowerTest()
    {
        var request = new StreetViewRequest
        {
            Key = "key",
            Location = new Location(new Coordinate(0, 0)),
            FieldOfView = -1
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'FieldOfView' must be greater than 0 and less than 120");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenFieldOfViewIsOutOfRangeHigherTest()
    {
        var request = new StreetViewRequest
        {
            Key = "key",
            Location = new Location(new Coordinate(0, 0)),
            FieldOfView = 121
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'FieldOfView' must be greater than 0 and less than 120");
    }
}