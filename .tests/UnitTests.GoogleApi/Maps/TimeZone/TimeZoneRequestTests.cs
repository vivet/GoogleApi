using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Maps.TimeZone.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Maps.TimeZone;

[TestClass]
public class TimeZoneRequestTests
{
    [TestMethod]
    public void ConstructorDefaultTest()
    {
        var request = new TimeZoneRequest();

        Assert.IsNotNull(request.TimeStamp);
        Assert.AreEqual(Language.English, request.Language);
    }

    [TestMethod]
    public void GetQueryStringParametersTest()
    {
        var request = new TimeZoneRequest
        {
            Key = "key",
            Location = new Coordinate(40.7141289, -73.9614074)
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.FirstOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var language = queryStringParameters.FirstOrDefault(x => x.Key == "language");
        var languageExpected = request.Language.ToCode();
        Assert.IsNotNull(language);
        Assert.AreEqual(languageExpected, language.Value);

        var timestamp = queryStringParameters.FirstOrDefault(x => x.Key == "timestamp");
        var timestampExpected = request.TimeStamp.DateTimeToUnixTimestamp().ToString();
        Assert.IsNotNull(timestamp);
        Assert.AreEqual(timestampExpected, timestamp.Value);

        var location = queryStringParameters.FirstOrDefault(x => x.Key == "location");
        var expected = request.Location.ToString();
        Assert.IsNotNull(location);
        Assert.AreEqual(expected, location.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new TimeZoneRequest
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
        var request = new TimeZoneRequest
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
        var request = new TimeZoneRequest
        {
            Key = "key"
        };

        var exception = Assert.Throws<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Location' is required");
    }
}