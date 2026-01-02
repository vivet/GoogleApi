using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Maps.Geocoding.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Location.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Maps.Geocoding.Location;

[TestClass]
public class LocationGeocodingRequestTests
{
    [TestMethod]
    public void ConstructorDefaultTest()
    {
        var request = new LocationGeocodeRequest();
        Assert.AreEqual(Language.English, request.Language);
    }

    [TestMethod]
    public void GetQueryStringParametersTest()
    {
        var request = new LocationGeocodeRequest
        {
            Key = "key",
            Location = new Coordinate(1, 1)
        };

        var queryStringParameters = request.GetQueryStringParameters();

        var key = queryStringParameters.SingleOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var language = queryStringParameters.SingleOrDefault(x => x.Key == "language");
        var languageExpected = request.Language.ToCode();
        Assert.IsNotNull(language);
        Assert.AreEqual(languageExpected, language.Value);

        var location = queryStringParameters.SingleOrDefault(x => x.Key == "latlng");
        var expected = request.Location.ToString();
        Assert.IsNotNull(location);
        Assert.AreEqual(expected, location.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenChannelTest()
    {
        var request = new LocationGeocodeRequest
        {
            Key = "key",
            Location = new Coordinate(1, 1),
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
    public void GetQueryStringParametersWhenResultTypeTest()
    {
        var request = new LocationGeocodeRequest
        {
            Key = "key",
            Location = new Coordinate(1, 1),
            ResultTypes =
            [
                LocationResultType.Administrative_Area_Level_1,
                LocationResultType.Administrative_Area_Level_2
            ]
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var resultType = queryStringParameters.SingleOrDefault(x => x.Key == "result_type");
        var resultTypeExpected = string.Join("|", request.ResultTypes.Select(x => x.ToString().ToLower()));
        Assert.IsNotNull(resultType);
        Assert.AreEqual(resultTypeExpected, resultType.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenLocationTypeTest()
    {
        var request = new LocationGeocodeRequest
        {
            Key = "key",
            Location = new Coordinate(1, 1),
            LocationTypes =
            [
                GeometryLocationType.Rooftop
            ]
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var type = queryStringParameters.SingleOrDefault(x => x.Key == "location_type");
        var typeExpected = string.Join("|", request.LocationTypes.Select(x => x.ToString().ToUpper()));
        Assert.IsNotNull(type);
        Assert.AreEqual(typeExpected, type.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new LocationGeocodeRequest
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
        var request = new LocationGeocodeRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenLocationIsNullTest()
    {
        var request = new LocationGeocodeRequest
        {
            Key = "key"
        };

        var exception = Assert.Throws<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Location' is required");
    }
}