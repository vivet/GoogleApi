using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Places.QueryAutoComplete;

[TestClass]
public class QueryAutoCompleteRequstTests
{
    [TestMethod]
    public void ConstructorDefaultTest()
    {
        var request = new PlacesQueryAutoCompleteRequest();

        Assert.IsNull(request.Offset);
        Assert.IsNull(request.Radius);
        Assert.IsNull(request.Location);
        Assert.AreEqual(Language.English, request.Language);
    }

    [TestMethod]
    public void GetQueryStringParametersTest()
    {
        var request = new PlacesQueryAutoCompleteRequest
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
    public void GetQueryStringParametersWhenLocationTest()
    {
        var request = new PlacesQueryAutoCompleteRequest
        {
            Key = "key",
            Input = "input",
            Location = new Coordinate(1, 1)
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var location = queryStringParameters.FirstOrDefault(x => x.Key == "location");
        var expected = request.Location.ToString();
        Assert.IsNotNull(location);
        Assert.AreEqual(expected, location.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenRadiusTest()
    {
        var request = new PlacesQueryAutoCompleteRequest
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
    public void PlacesQueryAutoCompleteWhenOffsetTest()
    {
        var request = new PlacesQueryAutoCompleteRequest
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
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new PlacesQueryAutoCompleteRequest
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
        var request = new PlacesQueryAutoCompleteRequest
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
        var request = new PlacesQueryAutoCompleteRequest
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
        var request = new PlacesQueryAutoCompleteRequest
        {
            Key = "key",
            Input = string.Empty
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Input' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenRadiusIsLessThanOneTest()
    {
        var request = new PlacesQueryAutoCompleteRequest
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
        var request = new PlacesQueryAutoCompleteRequest
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