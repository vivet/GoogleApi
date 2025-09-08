using System;
using GoogleApi.Entities.Search.Common.Enums;
using GoogleApi.Entities.Search.Common.Enums.Extensions;
using GoogleApi.Entities.Search.Image.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Language = GoogleApi.Entities.Search.Common.Enums.Language;

namespace GoogleApi.UnitTests.Search.Image;

[TestClass]
public class ImageSearchRequestTests
{
    [TestMethod]
    public void ConstructorDefaultTest()
    {
        var request = new ImageSearchRequest();

        Assert.IsTrue(request.PrettyPrint);
        Assert.AreEqual(request.Alt, AltType.Json);

        Assert.IsNotNull(request.ImageOptions);
        Assert.IsNull(request.ImageOptions.ImageSize);
        Assert.IsNull(request.ImageOptions.ImageType);
        Assert.IsNull(request.ImageOptions.ImageColorType);
        Assert.IsNull(request.ImageOptions.ImageDominantColor);
    }

    [TestMethod]
    public void GetQueryStringParametersTest()
    {
        var request = new ImageSearchRequest
        {
            Key = "abc",
            SearchEngineId = "abc",
            Query = "abc"
        };

        request.GetQueryStringParameters();
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new ImageSearchRequest
        {
            Key = null
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "Key is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
    {
        var request = new ImageSearchRequest
        {
            Key = string.Empty
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "Key is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenQueryIsNullTest()
    {
        var request = new ImageSearchRequest
        {
            Key = "abc",
            Query = null
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "Query is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenQueryIsStringEmptyTest()
    {
        var request = new ImageSearchRequest
        {
            Key = "abc",
            Query = string.Empty
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "Query is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenSearchEngineIdIsNullTest()
    {
        var request = new ImageSearchRequest
        {
            Key = "abc",
            Query = "google",
            SearchEngineId = null
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "SearchEngineId is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenSearchEngineIdIsStringEmptyTest()
    {
        var request = new ImageSearchRequest
        {
            Key = "abc",
            Query = "google",
            SearchEngineId = string.Empty
        };

        var exception = Assert.ThrowsException<ArgumentException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "SearchEngineId is required");
    }

    [TestMethod]
    public void GetQueryStringParametersWhenOptionsNumberIsLessThanOneTest()
    {
        var request = new ImageSearchRequest
        {
            Key = "abc",
            Query = "google",
            SearchEngineId = "abc",
            Options =
            {
                Number = 0
            }
        };

        var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenOptionsNumberIsGreaterThanNineTest()
    {
        var request = new ImageSearchRequest
        {
            Key = "abc",
            Query = "google",
            SearchEngineId = "abc",
            Options =
            {
                Number = 11
            }
        };

        var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
    }

    [TestMethod]
    public void GetQueryStringParametersWhenSafetyLevelInterfaceLanguageIsNotSupportedTest()
    {
        var request = new ImageSearchRequest
        {
            Key = "abc",
            Query = "google",
            SearchEngineId = "abc",
            Options =
            {
                SafetyLevel = SafetyLevel.Medium,
                InterfaceLanguage = Language.Afrikaans
            }
        };

        var exception = Assert.ThrowsException<ArgumentOutOfRangeException>(request.GetQueryStringParameters);

        Assert.IsNotNull(exception);
    }

    [TestMethod]
    public void GetUriTest()
    {
        var request = new ImageSearchRequest
        {
            Key = "abc",
            SearchEngineId = "abc",
            Query = "abc"
        };

        var uri = request.GetUri();

        Assert.IsNotNull(uri);
        Assert.AreEqual($"/customsearch/v1?key={request.Key}&q={request.Query}&alt={request.Alt.ToString().ToLower()}&prettyPrint={request.PrettyPrint.ToString().ToLower()}&cx={request.SearchEngineId}&c2coff=1&fileType={string.Join(",", request.Options.FileTypes)}&filter=0&hl={request.Options.InterfaceLanguage.ToHl()}&num={request.Options.Number}&rights={string.Join(",", request.Options.Rights)}&safe={request.Options.SafetyLevel.ToString().ToLower()}&start={request.Options.StartIndex.ToString()}&searchType=image", uri.PathAndQuery);
    }

    [TestMethod]
    public void GetUriWhenImageTypeTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenImageSizeTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenImageColorTypeTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenImageDominantColorTest()
    {
        Assert.Inconclusive();
    }
}