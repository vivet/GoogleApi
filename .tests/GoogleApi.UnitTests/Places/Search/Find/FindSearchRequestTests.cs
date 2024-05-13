using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.Common;
using GoogleApi.Entities.Places.Search.Find.Request;
using GoogleApi.Entities.Places.Search.Find.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Places.Search.Find;

[TestFixture]
public class FindSearchRequestTests
{
    [Test]
    public void ConstructorDefaultTest()
    {
        var request = new PlacesFindSearchRequest();

        Assert.AreEqual(InputType.TextQuery, request.Type);
        Assert.AreEqual(Language.English, request.Language);
        Assert.AreEqual(FieldTypes.Place_Id, request.Fields);
    }

    [Test]
    public void GetQueryStringParametersTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = "key",
            Input = "input"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.FirstOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var input = queryStringParameters.FirstOrDefault(x => x.Key == "input");
        var inputExpected = request.Input;
        Assert.IsNotNull(input);
        Assert.AreEqual(inputExpected, input.Value);

        var type = queryStringParameters.FirstOrDefault(x => x.Key == "inputtype");
        Assert.IsNotNull(type);
        Assert.AreEqual("textquery", type.Value);

        var language = queryStringParameters.FirstOrDefault(x => x.Key == "language");
        Assert.IsNotNull(language);
        Assert.AreEqual("en", language.Value);

        var fields = queryStringParameters.FirstOrDefault(x => x.Key == "fields");
        Assert.IsNotNull(fields);
        Assert.AreEqual("place_id", fields.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenFieldsTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = "key",
            Input = "input",
            Fields = FieldTypes.Name | FieldTypes.Place_Id
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var fields = queryStringParameters.FirstOrDefault(x => x.Key == "fields");
        var requestedFields = Enum.GetValues(typeof(FieldTypes))
            .Cast<FieldTypes>()
            .Where(x => request.Fields.HasFlag(x) && x != FieldTypes.Basic && x != FieldTypes.Contact && x != FieldTypes.Atmosphere)
            .Aggregate(string.Empty, (current, x) => $"{current}{x.ToString().ToLowerInvariant()},");

        var fieldsExpected = requestedFields.EndsWith(",") ? requestedFields.Substring(0, requestedFields.Length - 1) : requestedFields;
        Assert.IsNotNull(fields);
        Assert.AreEqual(fieldsExpected, fields.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenLocationBiasAndIpBiasTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = "key",
            Input = "input",
            LocationBias = new LocationBias
            {
                IpBias = true
            }
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var ipBias = queryStringParameters.FirstOrDefault(x => x.Key == "ipbias");
        Assert.IsNotNull(ipBias);
    }

    [Test]
    public void GetQueryStringParametersWhenLocationBiasAndPointTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = "key",
            Input = "input",
            LocationBias = new LocationBias
            {
                Location = new Coordinate(1, 1)
            }
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var bias = queryStringParameters.FirstOrDefault(x => x.Key == "locationbias");
        var biasExpected = $"point:{request.LocationBias.Location}";
        Assert.IsNotNull(bias);
        Assert.AreEqual(biasExpected, bias.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenLocationBiasAndCircleTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = "key",
            Input = "input",
            LocationBias = new LocationBias
            {
                Location = new Coordinate(1, 1),
                Radius = 1000
            }
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var bias = queryStringParameters.FirstOrDefault(x => x.Key == "locationbias");
        var biasExpected = $"circle:{request.LocationBias.Radius}@{request.LocationBias.Location}";
        Assert.IsNotNull(bias);
        Assert.AreEqual(biasExpected, bias.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenLocationBiasAndRectangularTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = "key",
            Input = "input",
            LocationBias = new LocationBias
            {
                Bounds = new ViewPort(new Coordinate(1, 1), new Coordinate(2, 2))
            }
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var bias = queryStringParameters.FirstOrDefault(x => x.Key == "locationbias");
        var biasExpected = $"rectangle:{request.LocationBias.Bounds.SouthWest}|{request.LocationBias.Bounds.NorthEast}";
        Assert.IsNotNull(bias);
        Assert.AreEqual(biasExpected, bias.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenLocationRestrictionAndCircleTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = "key",
            Input = "input",
            LocationRestriction = new LocationRestriction
            {
                Location = new Coordinate(1, 1),
                Radius = 1000
            }
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var bias = queryStringParameters.FirstOrDefault(x => x.Key == "locationrestriction");
        var biasExpectedExpected = $"circle:{request.LocationRestriction.Radius}@{request.LocationRestriction.Location}";
        Assert.IsNotNull(bias);
        Assert.AreEqual(biasExpectedExpected, bias.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenLocationRestrictionAndRectangularTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = "key",
            Input = "input",
            LocationRestriction = new LocationRestriction
            {
                Bounds = new ViewPort(new Coordinate(1, 1), new Coordinate(2, 2))
            }
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var restriction = queryStringParameters.FirstOrDefault(x => x.Key == "locationrestriction");
        var restrictionExpected = $"rectangle:{request.LocationRestriction.Bounds.SouthWest}|{request.LocationRestriction.Bounds.NorthEast}";
        Assert.IsNotNull(restriction);
        Assert.AreEqual(restrictionExpected, restriction.Value);
    }

    [Test]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new PlacesFindSearchRequest
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
        var request = new PlacesFindSearchRequest
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
    public void GetQueryStringParametersWhenInputIsNullTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = "key",
            Input = null
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Input' is required");
    }

    [Test]
    public void GetQueryStringParametersWhenInputIsStringEmptyTest()
    {
        var request = new PlacesFindSearchRequest
        {
            Key = "key",
            Input = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Input' is required");
    }
}