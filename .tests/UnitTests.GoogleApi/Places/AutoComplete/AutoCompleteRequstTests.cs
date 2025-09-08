using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.AutoComplete.Request.Enums;
using GoogleApi.Entities.Places.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Places.AutoComplete;

[TestClass]
public class AutoCompleteRequstTests
{
    [TestMethod]
    public void ConstructorDefaultTest()
    {
        var request = new PlacesAutoCompleteRequest();

        Assert.IsNull(request.Offset);
        Assert.IsNull(request.Radius);
        Assert.IsNull(request.Location);
        Assert.AreEqual(Language.English, request.Language);
    }

    [TestMethod]
    public void GetQueryStringParametersTest()
    {
        var request = new PlacesAutoCompleteRequest
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

        var language = queryStringParameters.FirstOrDefault(x => x.Key == "language");
        Assert.IsNotNull(language);
        Assert.AreEqual("en", language.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenOriginTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = "key",
            Input = "input",
            Location = new Coordinate(1, 1),
            Origin = new Coordinate(1, 1)
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var origin = queryStringParameters.FirstOrDefault(x => x.Key == "origin");
        var originExpected = request.Origin;
        Assert.IsNotNull(origin);
        Assert.AreEqual(originExpected.ToString(), origin.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenRadiusTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = "key",
            Input = "input",
            Radius = 100
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var radius = queryStringParameters.FirstOrDefault(x => x.Key == "radius");
        var radiusExpected = request.Radius.ToString();
        Assert.IsNotNull(radius);
        Assert.AreEqual(radiusExpected, radius.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenRadiusLocationTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = "key",
            Input = "input",
            Location = new Coordinate(1, 1),
            Radius = 1000
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var location = queryStringParameters.FirstOrDefault(x => x.Key == "location");
        var expected = request.Location.ToString();
        Assert.IsNotNull(location);
        Assert.AreEqual(expected, location.Value);

        var radius = queryStringParameters.FirstOrDefault(x => x.Key == "radius");
        var radiusExpected = request.Radius.ToString();
        Assert.IsNotNull(radius);
        Assert.AreEqual(radiusExpected, radius.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenStrictBoundsTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = "key",
            Input = "input",
            Strictbounds = true
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var strictbounds = queryStringParameters.FirstOrDefault(x => x.Key == "strictbounds");
        Assert.IsNotNull(strictbounds);
        Assert.IsNull(strictbounds.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenLocationBiasAndIpBiasTest()
    {
        var request = new PlacesAutoCompleteRequest
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

    [TestMethod]
    public void GetQueryStringParametersWhenLocationBiasAndPointTest()
    {
        var request = new PlacesAutoCompleteRequest
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

    [TestMethod]
    public void GetQueryStringParametersWhenLocationBiasAndCircleTest()
    {
        var request = new PlacesAutoCompleteRequest
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

    [TestMethod]
    public void GetQueryStringParametersWhenLocationBiasAndRectangularTest()
    {
        var request = new PlacesAutoCompleteRequest
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

    [TestMethod]
    public void GetQueryStringParametersWhenLocationRestrictionAndCircleTest()
    {
        var request = new PlacesAutoCompleteRequest
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

    [TestMethod]
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

    [TestMethod]
    public void PlacesQueryAutoCompleteWhenRegionTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = "key",
            Input = "input",
            Region = "region"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var region = queryStringParameters.FirstOrDefault(x => x.Key == "region");
        var regionExpected = request.Region;
        Assert.IsNotNull(region);
        Assert.AreEqual(regionExpected, region.Value);
    }

    [TestMethod]
    public void PlacesQueryAutoCompleteWhenOffsetTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = "key",
            Input = "input",
            Offset = "offset"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var offset = queryStringParameters.FirstOrDefault(x => x.Key == "offset");
        var offsetExpected = request.Offset;
        Assert.IsNotNull(offset);
        Assert.AreEqual(offsetExpected, offset.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenLocationTypesTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = "key",
            Input = "input",
            LocationTypes =
            [
                PlaceLocationType.Cafe,
                PlaceLocationType.Book_Store
            ]
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var types1 = queryStringParameters.FirstOrDefault(x => x.Key == "types");
        var types1Expected = string.Join("|", request.LocationTypes.Select(x => $"{x.ToString().ToLower()}"));
        Assert.IsNotNull(types1);
        Assert.AreEqual(types1Expected, types1.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenRestrictTypeTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = "key",
            Input = "input",
            RestrictType = RestrictPlaceType.Cities
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var types1 = queryStringParameters.FirstOrDefault(x => x.Key == "types");
        var types1Expected = $"({RestrictPlaceType.Cities.ToString().ToLower()})";
        Assert.IsNotNull(types1);
        Assert.AreEqual(types1Expected, types1.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenComponentsTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = "key",
            Input = "input",
            Components =
            [
                new KeyValuePair<Component, string>(Component.Country, "country"),
                new KeyValuePair<Component, string>(Component.Locality, "locality")
            ]
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var components1 = queryStringParameters.FirstOrDefault(x => x.Key == "components");
        var components1Expected = string.Join("|", request.Components.Select(x => $"{x.Key.ToString().ToLower()}:{x.Value}"));
        Assert.IsNotNull(components1);
        Assert.AreEqual(components1Expected, components1.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new PlacesAutoCompleteRequest
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
        var request = new PlacesAutoCompleteRequest
        {
            Key = string.Empty
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenInputIsNullTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = "key",
            Input = null
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Input' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenInputIsStringEmptyTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = "key",
            Input = string.Empty
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Input' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenRadiusIsZeroTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = "key",
            Input = "input",
            Radius = 0
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Radius' must be greater than or equal to 1 and less than or equal to 50.000");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenRadiusIsGereaterThanFiftyThousandTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = "key",
            Input = "input",
            Radius = 50001
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Radius' must be greater than or equal to 1 and less than or equal to 50.000");
    }
}