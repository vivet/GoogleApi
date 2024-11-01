using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.NearBy.Request.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Places.Search.NearBy;

[TestClass]
public class NearBySearchRequestTests
{
    [TestMethod]
    public void ConstructorDefaultTest()
    {
        var request = new PlacesNearBySearchRequest();

        Assert.IsNull(request.Type);
        Assert.IsNull(request.Radius);
        Assert.IsNull(request.Location);
        Assert.IsNull(request.Minprice);
        Assert.IsNull(request.Maxprice);
        Assert.IsFalse(request.OpenNow);
        Assert.AreEqual(Language.English, request.Language);
        Assert.AreEqual(Ranking.Prominence, request.Rankby);
    }

    [TestMethod]
    public void GetQueryStringParametersTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = "key",
            Location = new Coordinate(0, 0),
            Radius = 100
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.FirstOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var keyword = queryStringParameters.FirstOrDefault(x => x.Key == "keyword");
        var keywordExpected = request.Keyword;
        Assert.IsNotNull(keyword);
        Assert.AreEqual(keywordExpected, keyword.Value);

        var language = queryStringParameters.FirstOrDefault(x => x.Key == "language");
        Assert.IsNotNull(language);
        Assert.AreEqual("en", language.Value);

        var rankby = queryStringParameters.FirstOrDefault(x => x.Key == "rankby");
        var rankbyExpected = Ranking.Prominence.ToString().ToLower();
        Assert.IsNotNull(rankby);
        Assert.AreEqual(rankbyExpected, rankby.Value);

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
    public void GetQueryStringParametersWhenNameTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = "key",
            Location = new Coordinate(0, 0),
            Radius = 100,
            Name = "name"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var name = queryStringParameters.FirstOrDefault(x => x.Key == "name");
        var nameExpected = request.Name;
        Assert.IsNotNull(name);
        Assert.AreEqual(nameExpected, name.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeywordTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = "key",
            Location = new Coordinate(0, 0),
            Radius = 100,
            Keyword = "keyword"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var keyword = queryStringParameters.FirstOrDefault(x => x.Key == "keyword");
        var keywordExpected = request.Keyword;
        Assert.IsNotNull(keyword);
        Assert.AreEqual(keywordExpected, keyword.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenTypeTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = "key",
            Location = new Coordinate(0, 0),
            Radius = 100,
            Type = SearchPlaceType.Accounting
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var type = queryStringParameters.FirstOrDefault(x => x.Key == "type");
        var typeAttribute = request.Type?.GetType().GetMembers().FirstOrDefault(x => x.Name == request.Type.ToString())?.GetCustomAttribute<EnumMemberAttribute>();
        var typeExpected = typeAttribute?.Value?.ToLower();
        Assert.IsNotNull(type);
        Assert.AreEqual(typeExpected, type.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenOpenNowTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = "key",
            Location = new Coordinate(0, 0),
            Radius = 100,
            OpenNow = true
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var radius = queryStringParameters.FirstOrDefault(x => x.Key == "opennow");
        Assert.IsNotNull(radius);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenMinpriceTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = "key",
            Location = new Coordinate(0, 0),
            Radius = 100,
            Minprice = PriceLevel.Expensive
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var minprice = queryStringParameters.FirstOrDefault(x => x.Key == "minprice");
        var minpriceExpected = ((int)request.Minprice.GetValueOrDefault()).ToString();
        Assert.IsNotNull(minprice);
        Assert.AreEqual(minpriceExpected, minprice.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenMaxpriceTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = "key",
            Location = new Coordinate(0, 0),
            Radius = 100,
            Maxprice = PriceLevel.Free
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var maxprice = queryStringParameters.FirstOrDefault(x => x.Key == "maxprice");
        var maxpriceExpected = ((int)request.Maxprice.GetValueOrDefault()).ToString();
        Assert.IsNotNull(maxprice);
        Assert.AreEqual(maxpriceExpected, maxprice.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenPageTokenTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = "key",
            PageToken = "pagetoken"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var pagetoken = queryStringParameters.FirstOrDefault(x => x.Key == "pagetoken");
        var pagetokenExpected = request.PageToken;
        Assert.IsNotNull(pagetoken);
        Assert.AreEqual(pagetokenExpected, pagetoken.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new PlacesNearBySearchRequest
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
        var request = new PlacesNearBySearchRequest
        {
            Key = string.Empty
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenLocationIsNullTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = "key",
            Location = null
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Location' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenRadiusIsNullTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = "key",
            Location = new Coordinate(0, 0),
            Radius = null
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Radius' is required, when 'Rankby' is not Distance");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenRadiusIsLessThanOneTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = "key",
            Location = new Coordinate(1, 1),
            Radius = 0
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Radius' must be greater than or equal to 1 and less than or equal to 50.000");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenRadiusIsGereaterThanFiftyThousandTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = "key",
            Location = new Coordinate(1, 1),
            Radius = 50001
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Radius' must be greater than or equal to 1 and less than or equal to 50.000");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenRankByDistanceAndRadiusIsNotNullTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = "key",
            Location = new Coordinate(1, 1),
            Radius = 5001,
            Rankby = Ranking.Distance
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Radius' cannot be specified, when using 'Rankby' is distance");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenRankByDistanceAndNameIsNullAndKeywordIsNullAndTypeIsNullTest()
    {
        var request = new PlacesNearBySearchRequest
        {
            Key = "abc",
            Location = new Coordinate(51.491431, -3.16668),
            Rankby = Ranking.Distance
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Keyword', 'Name' or 'Type' is required, If 'Rankby' is distance");
    }
}