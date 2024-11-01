using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.Text.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Places.Search.Text;

[TestClass]
public class TextSearchRequestTests
{
    [TestMethod]
    public void ConstructorDefaultTest()
    {
        var request = new PlacesTextSearchRequest();

        Assert.IsNull(request.Type);
        Assert.IsNull(request.Radius);
        Assert.IsNull(request.Location);
        Assert.IsNull(request.Minprice);
        Assert.IsNull(request.Maxprice);
        Assert.IsFalse(request.OpenNow);
        Assert.AreEqual(Language.English, request.Language);
    }

    [TestMethod]
    public void GetQueryStringParametersTest()
    {
        var request = new PlacesTextSearchRequest
        {
            Key = "key",
            Query = "query"
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var key = queryStringParameters.FirstOrDefault(x => x.Key == "key");
        var keyExpected = request.Key;
        Assert.IsNotNull(key);
        Assert.AreEqual(keyExpected, key.Value);

        var query = queryStringParameters.FirstOrDefault(x => x.Key == "query");
        var queryExpected = request.Query;
        Assert.IsNotNull(query);
        Assert.AreEqual(queryExpected, query.Value);

        var language = queryStringParameters.FirstOrDefault(x => x.Key == "language");
        Assert.IsNotNull(language);
        Assert.AreEqual("en", language.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenRegionTest()
    {
        var request = new PlacesTextSearchRequest
        {
            Key = "key",
            Query = "query",
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
    public void GetQueryStringParametersWhenRadiusTest()
    {
        var request = new PlacesTextSearchRequest
        {
            Key = "key",
            Query = "query",
            Radius = 100
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var radius = queryStringParameters.FirstOrDefault(x => x.Key == "radius");
        var radiusExpected = request.Radius?.ToString();
        Assert.IsNotNull(radius);
        Assert.AreEqual(radiusExpected, radius.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenRadiusAndLocationTest()
    {
        var request = new PlacesTextSearchRequest
        {
            Key = "key",
            Query = "query",
            Radius = 100,
            Location = new Coordinate(1, 1)
        };

        var queryStringParameters = request.GetQueryStringParameters();
        Assert.IsNotNull(queryStringParameters);

        var radius = queryStringParameters.FirstOrDefault(x => x.Key == "radius");
        var radiusExpected = request.Radius?.ToString();
        Assert.IsNotNull(radius);
        Assert.AreEqual(radiusExpected, radius.Value);

        var location = queryStringParameters.FirstOrDefault(x => x.Key == "location");
        var expected = request.Location.ToString();
        Assert.IsNotNull(location);
        Assert.AreEqual(expected, location.Value);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenTypeTest()
    {
        var request = new PlacesTextSearchRequest
        {
            Key = "key",
            Query = "query",
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
        var request = new PlacesTextSearchRequest
        {
            Key = "key",
            Query = "query",
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
        var request = new PlacesTextSearchRequest
        {
            Key = "key",
            Query = "query",
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
        var request = new PlacesTextSearchRequest
        {
            Key = "key",
            Query = "query",
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
        var request = new PlacesTextSearchRequest
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
        var request = new PlacesTextSearchRequest
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
        var request = new PlacesTextSearchRequest
        {
            Key = string.Empty
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Key' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenQueryIsNullTest()
    {
        var request = new PlacesTextSearchRequest
        {
            Key = "key",
            Query = null
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Query' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenQueryIsStringEmptyTest()
    {
        var request = new PlacesTextSearchRequest
        {
            Key = "key",
            Query = string.Empty
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Query' is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenLocationAndRadiusIsNullTest()
    {
        var request = new PlacesTextSearchRequest
        {
            Key = "key",
            Query = "picadelly circus",
            Location = new Coordinate(0, 0)
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "'Radius' is required when 'Location' is specified");
    }
}