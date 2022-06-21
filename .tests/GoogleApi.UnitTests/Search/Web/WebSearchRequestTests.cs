using System;
using GoogleApi.Entities.Search.Common.Enums;
using GoogleApi.Entities.Search.Common.Enums.Extensions;
using GoogleApi.Entities.Search.Web.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Search.Web;

[TestFixture]
public class WebSearchRequestTests
{
    [Test]
    public void ConstructorDefaultTest()
    {
        var request = new WebSearchRequest();

        Assert.IsTrue(request.PrettyPrint);
        Assert.AreEqual(request.Alt, AltType.Json);
    }

    [Test]
    public void GetQueryStringParametersTest()
    {
        var request = new WebSearchRequest
        {
            Key = "abc",
            SearchEngineId = "abc",
            Query = "abc"
        };

        Assert.DoesNotThrow(() => request.GetQueryStringParameters());
    }

    [Test]
    public void GetQueryStringParametersWhenKeyIsNullTest()
    {
        var request = new WebSearchRequest
        {
            Key = null
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "Key is required");
    }

    [Test]
    public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
    {
        var request = new WebSearchRequest
        {
            Key = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "Key is required");
    }

    [Test]
    public void GetQueryStringParametersWhenQueryIsNullTest()
    {
        var request = new WebSearchRequest
        {
            Key = "abc",
            Query = null
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "Query is required");
    }

    [Test]
    public void GetQueryStringParametersWhenQueryIsStringEmptyTest()
    {
        var request = new WebSearchRequest
        {
            Key = "abc",
            Query = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "Query is required");
    }

    [Test]
    public void GetQueryStringParametersWhenSearchEngineIdIsNullTest()
    {
        var request = new WebSearchRequest
        {
            Key = "abc",
            Query = "google",
            SearchEngineId = null
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "SearchEngineId is required");
    }

    [Test]
    public void GetQueryStringParametersWhenSearchEngineIdIsStringEmptyTest()
    {
        var request = new WebSearchRequest
        {
            Key = "abc",
            Query = "google",
            SearchEngineId = string.Empty
        };

        var exception = Assert.Throws<ArgumentException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "SearchEngineId is required");
    }

    [Test]
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

        var exception = Assert.Throws<InvalidOperationException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "Number must be between 1 and 10");
    }

    [Test]
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

        var exception = Assert.Throws<InvalidOperationException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "Number must be between 1 and 10");
    }

    [Test]
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

        var exception = Assert.Throws<InvalidOperationException>(() =>
        {
            var parameters = request.GetQueryStringParameters();
            Assert.IsNull(parameters);
        });
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, $"SafetyLevel is not allowed for specified InterfaceLanguage: {request.Options.InterfaceLanguage}");
    }

    [Test]
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

    [Test]
    public void GetUriWhenCallbackTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GetUriWhenFieldsTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GetUriWhenCountryRestrictionTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GetUriWhenDateRestrictionTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GetUriWhenExactTermsTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GetUriWhenExcludeTermsTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GetUriWhenGoogleHostTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GetUriWhenHighRangeTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GetUriWhenAndTermsTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GetUriWhenLinkSiteTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GetUriWhenLowRangeTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GetUriWhenNumberTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GetUriWhenOrTermsTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GetUriWhenRelatedSiteTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GetUriWhenSearchTypeTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GetUriWhenSiteSearchTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GetUriWhenSiteSearchFilterTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GetUriWhenSortExpressionTest()
    {
        Assert.Inconclusive();
    }
}