using System;
using System.Linq;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Maps.Geocoding.Place.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Geocoding.Place;

[TestFixture]
public class GeocodingPlaceRequestTests
{
    [Test]
    public void ConstructorDefaultTest()
    {
        var request = new PlaceGeocodeRequest();
        Assert.AreEqual(Language.English, request.Language);
    }

    [Test]
    public void GetQueryStringParametersTest()
    {
        var request = new PlaceGeocodeRequest
        {
            Key = "key",
            PlaceId = "place_id"
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

        var location = queryStringParameters.SingleOrDefault(x => x.Key == "place_id");
        var expected = request.PlaceId;
        Assert.IsNotNull(location);
        Assert.AreEqual(expected, location.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenChannelTest()
    {
        var request = new PlaceGeocodeRequest
        {
            Key = "key",
            PlaceId = "place_id",
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
        var request = new PlaceGeocodeRequest
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
        var request = new PlaceGeocodeRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }

    [Test]
    public void GetQueryStringParametersWhenPlaceIdIsNullTest()
    {
        var request = new PlaceGeocodeRequest
        {
            Key = "key"
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'PlaceId' is required");
    }
}