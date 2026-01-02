using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Maps.Geocoding.Address.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Maps.Geocoding.Address;

[TestClass]
public class GeocodingAddressRequestTests
{
    [TestMethod]
    public void ConstructorDefaultTest()
    {
        var request = new AddressGeocodeRequest();
        Assert.AreEqual(Language.English, request.Language);
    }

    [TestMethod]
    public void GetQueryStringParametersTest()
    {
        var request = new AddressGeocodeRequest
        {
            Key = "key",
            Address = "address"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.SingleOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var language = queryStringParameters.SingleOrDefault(x => x.Key == "language");
        var languageExpected = request.Language.ToCode();
        Assert.IsNotNull(language);
        Assert.AreEqual(languageExpected, language.Value);

        var address = queryStringParameters.SingleOrDefault(x => x.Key == "address");
        var addressExpected = request.Address;
        Assert.IsNotNull(address);
        Assert.AreEqual(addressExpected, address.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenChannelTest()
    {
        var request = new AddressGeocodeRequest
        {
            Key = "key",
            Address = "address",
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
    public void GetQueryStringParametersWhenRegionTest()
    {
        var request = new AddressGeocodeRequest
        {
            Key = "key",
            Address = "address",
            Region = "region"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var region = queryStringParameters.SingleOrDefault(x => x.Key == "region");
        var regionExpected = request.Region;
        Assert.IsNotNull(region);
        Assert.AreEqual(regionExpected, region.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenBoundsTest()
    {
        var request = new AddressGeocodeRequest
        {
            Key = "key",
            Address = "address",
            Bounds = new ViewPort(new Coordinate(1, 1), new Coordinate(2, 2))
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var bounds = queryStringParameters.SingleOrDefault(x => x.Key == "bounds");
        var boundsExpected = request.Bounds.ToString();
        Assert.IsNotNull(bounds);
        Assert.AreEqual(boundsExpected, bounds.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenComponentsTest()
    {
        var request = new AddressGeocodeRequest
        {
            Key = "key",
            Components =
            [
                new KeyValuePair<Component, string>(Component.Administrative_Area, "component1"),
                new KeyValuePair<Component, string>(Component.Locality, "component2")
            ]
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var components = queryStringParameters.SingleOrDefault(x => x.Key == "components");
        var componentsExpected = string.Join("|", request.Components.Select(x => $"{x.Key.ToString().ToLower()}:{x.Value}"));
        Assert.IsNotNull(components);
        Assert.AreEqual(componentsExpected, components.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new AddressGeocodeRequest
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
        var request = new AddressGeocodeRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual("'Key' is required", exception.Message);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenAddressIsNullAndComponentsIsEmptyTest()
    {
        var request = new AddressGeocodeRequest
        {
            Key = "key"
        };

        var exception = Assert.Throws<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Address' or 'Components' is required");
    }
}