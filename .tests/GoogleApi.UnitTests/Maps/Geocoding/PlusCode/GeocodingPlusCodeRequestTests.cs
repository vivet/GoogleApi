using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Geocoding.PlusCode;

[TestFixture]
public class GeocodingPlusCodeRequestTests
{
    [Test]
    public void ConstructorDefaultTest()
    {
        var request = new PlusCodeGeocodeRequest();
        Assert.AreEqual(Language.English, request.Language);
        Assert.IsFalse(request.UseEncryptedKey);
    }

    [Test]
    public void GetQueryStringParametersWhenCoordinateTest()
    {
        var request = new PlusCodeGeocodeRequest
        {
            Key = "abc",
            Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new Coordinate(1, 1))
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
        var addressExpected = request.Address.ToString();
        Assert.IsNotNull(address);
        Assert.AreEqual(addressExpected, address.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenAddressTest()
    {
        var request = new PlusCodeGeocodeRequest
        {
            Key = "abc",
            Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new Entities.Common.Address("address"))
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var address = queryStringParameters.SingleOrDefault(x => x.Key == "address");
        var addressExpected = request.Address.ToString();
        Assert.IsNotNull(address);
        Assert.AreEqual(addressExpected, address.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenGlobalCodeTest()
    {
        var request = new PlusCodeGeocodeRequest
        {
            Key = "abc",
            Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new GlobalCode("global_code"))
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var address = queryStringParameters.SingleOrDefault(x => x.Key == "address");
        var addressExpected = request.Address.ToString();
        Assert.IsNotNull(address);
        Assert.AreEqual(addressExpected, address.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenLocalCodeAndLocalityTest()
    {
        var request = new PlusCodeGeocodeRequest
        {
            Key = "abc",
            Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new LocalCodeAndLocality("local_code", "locality"))
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var address = queryStringParameters.SingleOrDefault(x => x.Key == "address");
        var addressExpected = request.Address.ToString();
        Assert.IsNotNull(address);
        Assert.AreEqual(addressExpected, address.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenUseEncryptedKeyTest()
    {
        var request = new PlusCodeGeocodeRequest
        {
            Key = "abc",
            Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new Coordinate(1, 1)),
            UseEncryptedKey = true
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.SingleOrDefault(x => x.Key == "ekey");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenEmailTest()
    {
        var request = new PlusCodeGeocodeRequest
        {
            Key = "abc",
            Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new Coordinate(1, 1)),
            Email = "email"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var email = queryStringParameters.SingleOrDefault(x => x.Key == "email");
        var emailExpected = request.Email;
        Assert.IsNotNull(email);
        Assert.AreEqual(emailExpected, email.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new PlusCodeGeocodeRequest
        {
            Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new Coordinate(1, 1))
        };

        Assert.DoesNotThrow(() => request.GetQueryStringParameters());
    }

    [Test]
    public void GetQueryStringParametersWhenAddressIsNullTest()
    {
        var request = new PlusCodeGeocodeRequest
        {
            Key = "key"
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "Address is required");
    }
}