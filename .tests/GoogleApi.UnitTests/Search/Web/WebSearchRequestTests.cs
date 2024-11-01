using System;
using GoogleApi.Entities.Search.Common.Enums;
using GoogleApi.Entities.Search.Common.Enums.Extensions;
using GoogleApi.Entities.Search.Web.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Search.Web;

[TestClass]
public class WebSearchRequestTests
{
    [TestMethod]
    public void ConstructorDefaultTest()
    {
        var request = new WebSearchRequest();

        Assert.IsTrue(request.PrettyPrint);
        Assert.AreEqual(request.Alt, AltType.Json);
    }

    [TestMethod]
    public void GetQueryStringParametersTest()
    {
        var request = new WebSearchRequest
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
        var request = new WebSearchRequest
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
        var request = new WebSearchRequest
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
        var request = new WebSearchRequest
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
        var request = new WebSearchRequest
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
        var request = new WebSearchRequest
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
        var request = new WebSearchRequest
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
        var request = new WebSearchRequest
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
    public void GetQueryStringParametersWhenOptionsNumberIsGreaterThanTenTest()
    {
        var request = new WebSearchRequest
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
        var request = new WebSearchRequest
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
        var request = new WebSearchRequest
        {
            Key = "abc",
            SearchEngineId = "abc",
            Query = "abc"
        };

        var uri = request.GetUri();

        Assert.IsNotNull(uri);
        Assert.AreEqual($"/customsearch/v1?key={request.Key}&q={request.Query}&alt={request.Alt.ToString().ToLower()}&prettyPrint={request.PrettyPrint.ToString().ToLower()}&cx={request.SearchEngineId}&c2coff=1&fileType={string.Join(",", request.Options.FileTypes)}&filter=0&hl={request.Options.InterfaceLanguage.ToHl()}&num={request.Options.Number}&rights={string.Join(",", request.Options.Rights)}&safe={request.Options.SafetyLevel.ToString().ToLower()}&start={request.Options.StartIndex.ToString()}", uri.PathAndQuery);
    }

    [TestMethod]
    public void GetUriWhenCallbackTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenFieldsTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenCountryRestrictionTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenDateRestrictionTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenExactTermsTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenExcludeTermsTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenGoogleHostTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenHighRangeTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenAndTermsTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenLinkSiteTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenLowRangeTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenNumberTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenOrTermsTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenRelatedSiteTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenSearchTypeTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenSiteSearchTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenSiteSearchFilterTest()
    {
        Assert.Inconclusive();
    }

    [TestMethod]
    public void GetUriWhenSortExpressionTest()
    {
        Assert.Inconclusive();
    }
}