using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Common;
using GoogleApi.Entities.Search.Common.Enums;
using GoogleApi.Entities.Search.Web.Request;
using GoogleApi.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Language = GoogleApi.Entities.Search.Common.Enums.Language;

namespace GoogleApi.Test.Search.Web;

[TestClass]
public class WebSearchTests : BaseTest
{
    [TestMethod]
    public async Task WebSearchTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            SearchEngineId = this.Settings.SearchEngineId,
            Query = "google"
        };

        var response = await GoogleSearch.WebSearch.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, Status.Ok);
        Assert.AreEqual(response.Kind, "customsearch#search");

        Assert.IsNotNull(response.Url);
        Assert.AreEqual(response.Url.Type, "application/json");
        Assert.AreEqual(response.Url.Template, "https://www.googleapis.com/customsearch/v1?q={searchTerms}&num={count?}&start={startIndex?}&lr={language?}&safe={safe?}&cx={cx?}&sort={sort?}&filter={filter?}&gl={gl?}&cr={cr?}&googlehost={googleHost?}&c2coff={disableCnTwTranslation?}&hq={hq?}&hl={hl?}&siteSearch={siteSearch?}&siteSearchFilter={siteSearchFilter?}&exactTerms={exactTerms?}&excludeTerms={excludeTerms?}&linkSite={linkSite?}&orTerms={orTerms?}&relatedSite={relatedSite?}&dateRestrict={dateRestrict?}&lowRange={lowRange?}&highRange={highRange?}&searchType={searchType}&fileType={fileType?}&rights={rights?}&imgSize={imgSize?}&imgType={imgType?}&imgColorType={imgColorType?}&imgDominantColor={imgDominantColor?}&alt=json");

        Assert.IsNotNull(response.Context);
        Assert.IsNull(response.Context.Facets);
        Assert.AreEqual(response.Context.Title, "Google Web");

        Assert.IsNull(response.Spelling);

        Assert.IsNotNull(response.Search);
        Assert.IsTrue(response.Search.SearchTime <= 3.00);
        Assert.IsNotNull(response.Search.SearchTimeFormatted);
        Assert.IsTrue(response.Search.SearchTimeFormatted.Any());
        Assert.IsTrue(response.Search.TotalResults > 800000000);

        var items = response.Items;
        Assert.IsNotNull(items);
        Assert.IsTrue(response.Items.Any());

        var item = response.Items.FirstOrDefault();
        Assert.IsNotNull(item);
        Assert.IsNotNull(item.Link);
        Assert.AreEqual(item.Title, "Google");
        Assert.AreEqual(item.DisplayLink, "www.google.com");

        Assert.IsNull(response.Promotions);

        var query = response.Query;
        Assert.IsNotNull(query);
        Assert.AreEqual("Google Custom Search - google", query.Title);
        Assert.IsTrue(query.TotalResults > 800000000);
        Assert.AreEqual("google", query.SearchTerms);
        Assert.AreEqual(10, query.Count);
        Assert.AreEqual(1, query.StartIndex);
        Assert.AreEqual(0, query.StartPage);
        Assert.IsNull(query.Language);
        Assert.AreEqual(EncodingType.Utf8, query.InputEncoding);
        Assert.AreEqual(EncodingType.Utf8, query.OutputEncoding);
        Assert.AreEqual(SafetyLevel.Off, query.SafetyLevel);
        Assert.AreEqual(this.Settings.SearchEngineId, query.SearchEngineId);
        Assert.IsFalse(query.Filter);
        Assert.IsTrue(query.DisableCnTwTranslation);
        Assert.AreEqual(Language.English, query.InterfaceLanguage);

        var nextPage = response.NextPage;
        Assert.IsNotNull(nextPage);
        Assert.AreEqual("Google Custom Search - google", nextPage.Title);
        Assert.IsTrue(nextPage.TotalResults > 800000000);
        Assert.AreEqual("google", nextPage.SearchTerms);
        Assert.AreEqual(10, nextPage.Count);
        Assert.AreEqual(11, nextPage.StartIndex);
        Assert.AreEqual(0, nextPage.StartPage);
        Assert.IsNull(nextPage.Language);
        Assert.AreEqual(EncodingType.Utf8, nextPage.InputEncoding);
        Assert.AreEqual(EncodingType.Utf8, nextPage.OutputEncoding);
        Assert.AreEqual(SafetyLevel.Off, nextPage.SafetyLevel);
        Assert.AreEqual(this.Settings.SearchEngineId, nextPage.SearchEngineId);
        Assert.IsFalse(nextPage.Filter);
        Assert.IsTrue(nextPage.DisableCnTwTranslation);
        Assert.AreEqual(Language.English, nextPage.InterfaceLanguage);

        Assert.IsNull(response.PreviousPage);

        var sort = query.SortExpression;
        Assert.IsNull(sort);

        Assert.IsFalse(query.Filter);
        Assert.IsNull(query.GeoLocation);
        Assert.IsNull(query.CountryRestrict);
        Assert.IsNull(query.GoogleHost);
        Assert.IsTrue(query.DisableCnTwTranslation);
        Assert.IsNull(query.AndTerms);
        Assert.AreEqual(Language.English, query.InterfaceLanguage);

        var siteSearch = query.SiteSearch;
        Assert.IsNull(siteSearch);

        Assert.IsNull(query.ExactTerms);
        Assert.IsNull(query.ExcludeTerms);
        Assert.IsNull(query.LinkSite);
        Assert.IsNull(query.OrTerms);
        Assert.IsNull(query.RelatedSite);

        var dateRestrict = query.DateRestrict;
        Assert.IsNull(dateRestrict);

        Assert.IsNull(query.LowRange);
        Assert.IsNull(query.HighRange);
        Assert.IsNull(query.FileTypes);
        Assert.IsNull(query.Rights);
        Assert.IsNull(query.SearchType);

        Assert.IsNull(query.ImageSize);
        Assert.IsNull(query.ImageType);
        Assert.IsNull(query.ImageColorType);
        Assert.IsNull(query.ImageDominantColor);
    }

    [TestMethod]
    public async Task WebSearchWhenFieldsTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            SearchEngineId = this.Settings.SearchEngineId,
            Query = "google",
            Fields = "kind"
        };

        var response = await GoogleSearch.WebSearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, Status.Ok);
        Assert.AreEqual(response.Kind, "customsearch#search");

        Assert.IsNull(response.Url);
        Assert.IsNull(response.Context);
        Assert.IsNull(response.Spelling);
        Assert.IsNull(response.Search);
        Assert.IsNull(response.Items);
        Assert.IsNull(response.Promotions);
        Assert.IsNull(response.Query);
        Assert.IsNull(response.NextPage);
        Assert.IsNull(response.PreviousPage);
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task WebSearchWhenPrettyPrintTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task WebSearchWhenUserIpTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task WebSearchWhenQuotaUserTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    public async Task WebSearchWhenDisableCnTwTranslationFalseTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            SearchEngineId = this.Settings.SearchEngineId,
            Query = "google",
            Options =
            {
                DisableCnTwTranslation = false
            }
        };

        var response = await GoogleSearch.WebSearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, Status.Ok);

        var items = response.Items;
        Assert.IsNotNull(items);
        Assert.IsTrue(response.Items.Any());

        var query = response.Query;
        Assert.IsNotNull(query);
        Assert.IsFalse(query.DisableCnTwTranslation);
    }

    [TestMethod]
    public async Task WebSearchWhenCountryRestrictionTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            SearchEngineId = this.Settings.SearchEngineId,
            Query = "google",
            Options =
            {
                CountryRestrict = new CountryRestrict
                {
                    Expressions = new List<CountryRestrictExpression>
                    {
                        new() { Country = Country.Denmark },
                        new() { Country = Country.Italy }
                    }
                }
            }
        };

        var response = await GoogleSearch.WebSearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, Status.Ok);

        var items = response.Items;
        Assert.IsNotNull(items);
        Assert.IsTrue(response.Items.Any());

        var query = response.Query;
        Assert.IsNotNull(query);
        Assert.AreEqual("(countryDK.countryIT).", query.CountryRestrict);
    }

    [TestMethod]
    public async Task WebSearchWhenDateRestrictTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            SearchEngineId = this.Settings.SearchEngineId,
            Query = "google",
            Options =
            {
                DateRestrict = new DateRestrict
                {
                    Type = DateRestrictType.Days,
                    Number = 3
                }
            }
        };

        var response = await GoogleSearch.WebSearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, Status.Ok);

        var items = response.Items;
        Assert.IsNotNull(items);
        Assert.IsTrue(response.Items.Any());

        var query = response.Query;
        Assert.IsNotNull(query);
        Assert.AreEqual(3, query.DateRestrict.Number);
        Assert.AreEqual(DateRestrictType.Days, query.DateRestrict.Type);
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task WebSearchWhenExactTermsTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task WebSearchWhenExcludeTermsTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    public async Task WebSearchWhenFileTypesTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            SearchEngineId = this.Settings.SearchEngineId,
            Query = "google",
            Options =
            {
                FileTypes =
                [
                    FileType.Text,
                    FileType.AdobePortableDocumentFormat
                ]
            }
        };

        var response = await GoogleSearch.WebSearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, Status.Ok);

        var items = response.Items;
        Assert.IsNotNull(items);
        Assert.IsTrue(response.Items.Any());

        var query = response.Query;
        Assert.IsNotNull(query);

        var fileTypes = query.FileTypes.ToArray();
        Assert.AreEqual(2, fileTypes.Length);
        Assert.IsTrue(fileTypes.Contains(FileType.Text));
        Assert.IsTrue(fileTypes.Contains(FileType.AdobePortableDocumentFormat));
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task WebSearchWhenFilterTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    public async Task WebSearchWhenGeoLocationTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            SearchEngineId = this.Settings.SearchEngineId,
            Query = "google",
            Options =
            {
                GeoLocation = GeoLocation.Denmark
            }
        };

        var response = await GoogleSearch.WebSearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, Status.Ok);

        var items = response.Items;
        Assert.IsNotNull(items);
        Assert.IsTrue(response.Items.Any());

        var query = response.Query;
        Assert.IsNotNull(query);
        Assert.AreEqual(GeoLocation.Denmark, query.GeoLocation);
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task WebSearchWhenGooglehostTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task WebSearchWhenHighRangeTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    public async Task WebSearchWhenInterfaceLanguageTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            SearchEngineId = this.Settings.SearchEngineId,
            Query = "google",
            Options =
            {
                InterfaceLanguage = Language.German
            }
        };

        var response = await GoogleSearch.WebSearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, Status.Ok);

        var items = response.Items;
        Assert.IsNotNull(items);
        Assert.IsTrue(response.Items.Any());

        var query = response.Query;
        Assert.IsNotNull(query);
        Assert.AreEqual(Language.German, query.InterfaceLanguage);
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task WebSearchWhenAndTermsTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task WebSearchWhenLinkSiteTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task WebSearchWhenLowRangeTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    public async Task WebSearchWhenNumberTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            SearchEngineId = this.Settings.SearchEngineId,
            Query = "google",
            Options =
            {
                Number = 6
            }
        };

        var response = await GoogleSearch.WebSearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, Status.Ok);

        var items = response.Items;
        Assert.IsNotNull(items);
        Assert.IsTrue(response.Items.Any());

        var query = response.Query;
        Assert.IsNotNull(query);
        Assert.AreEqual(6, query.Count);
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task WebSearchWhenOrTermsTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task WebSearchWhenRelatedSiteTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task WebSearchWhenRightsTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task WebSearchWhenSafetyLevelTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    public void WebSearchWhenSafetyLevelOffTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "google",
            SearchEngineId = this.Settings.SearchEngineId,
            Options =
            {
                InterfaceLanguage = Language.Danish,
                SafetyLevel = SafetyLevel.Off
            }
        };

        GoogleSearch.WebSearch.QueryAsync(request);
    }

    [TestMethod]
    public async Task WebSearchWhenSafetyLevelAndNotAllowedTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "google",
            SearchEngineId = this.Settings.SearchEngineId,
            Options =
            {
                InterfaceLanguage = Language.Danish,
                SafetyLevel = SafetyLevel.High
            }
        };

        var exception = await Assert.ThrowsExceptionAsync<GoogleApiException>(async () => await GoogleSearch.WebSearch.QueryAsync(request));

        Assert.IsNotNull(exception);
        Assert.IsTrue(exception.Message.Contains($"SafetyLevel is not allowed for specified InterfaceLanguage: {request.Options.InterfaceLanguage}"));
    }

    [TestMethod]
    public async Task WebSearchWhenSiteSearchTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            SearchEngineId = this.Settings.SearchEngineId,
            Query = "google",
            Options =
            {
                SiteSearch = new SiteSearch
                {
                    Site = "google.com",
                    Filter = SiteSearchFilter.Exclude
                }
            }
        };

        var response = await GoogleSearch.WebSearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, Status.Ok);

        var items = response.Items;
        Assert.IsNotNull(items);
        Assert.IsTrue(response.Items.Any());

        var query = response.Query;
        Assert.IsNotNull(query);
        Assert.IsNotNull(query.SiteSearch);
        Assert.AreEqual("google.com", query.SiteSearch.Site);
        Assert.AreEqual(SiteSearchFilter.Exclude, query.SiteSearch.Filter);
    }

    [TestMethod]
    public async Task WebSearchWhenSortExpressionTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            SearchEngineId = this.Settings.SearchEngineId,
            Query = "google",
            Options =
            {
                SortExpression = new SortExpression
                {
                    By = SortBy.Date,
                    Order = SortOrder.Descending,
                    DefaultValue = 2
                }
            }
        };

        var response = await GoogleSearch.WebSearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, Status.Ok);

        var items = response.Items;
        Assert.IsNotNull(items);
        Assert.IsTrue(response.Items.Any());

        var query = response.Query;
        Assert.IsNotNull(query);

        var sort = query.SortExpression;
        Assert.IsNotNull(sort);
        Assert.AreEqual(SortBy.Date, sort.By);
        Assert.AreEqual(SortOrder.Descending, sort.Order);
        Assert.AreEqual(2, sort.DefaultValue);
    }

    [TestMethod]
    public async Task WebSearchWhenStartIndexTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            SearchEngineId = this.Settings.SearchEngineId,
            Query = "google",
            Options =
            {
                StartIndex = 11
            }
        };

        var response = await GoogleSearch.WebSearch.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, Status.Ok);
        Assert.AreEqual(response.Kind, "customsearch#search");

        var items = response.Items;
        Assert.IsNotNull(items);
        Assert.IsTrue(response.Items.Any());

        var item = response.Items.FirstOrDefault();
        Assert.IsNotNull(item);

        var query = response.Query;
        Assert.IsNotNull(query);
        Assert.AreEqual(11, query.StartIndex);

        var nextPage = response.NextPage;
        Assert.IsNotNull(nextPage);
        Assert.AreEqual(21, nextPage.StartIndex);

        var previousPage = response.PreviousPage;
        Assert.IsNotNull(previousPage);
        Assert.AreEqual(1, previousPage.StartIndex);
    }

    [TestMethod]
    public async Task WebSearchWhenKeyIsNullTest()
    {
        var request = new WebSearchRequest
        {
            Key = null
        };

        var exception = await Assert.ThrowsExceptionAsync<GoogleApiException>(async () => await GoogleSearch.WebSearch.QueryAsync(request));

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "Key is required");
    }

    [TestMethod]
    public async Task WebSearchWhenQueryIsNullTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = null
        };

        var exception = await Assert.ThrowsExceptionAsync<GoogleApiException>(async () => await GoogleSearch.WebSearch.QueryAsync(request));

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "Query is required");
    }

    [TestMethod]
    public async Task WebSearchWhenSearchEngineIdIsNullTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "google",
            SearchEngineId = null
        };

        var exception = await Assert.ThrowsExceptionAsync<GoogleApiException>(async () => await GoogleSearch.WebSearch.QueryAsync(request));

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "SearchEngineId is required");
    }

    [TestMethod]
    public async Task WebSearchWhenNumberIsLessThanOneTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "google",
            SearchEngineId = this.Settings.SearchEngineId,
            Options =
            {
                Number = 0
            }
        };

        var exception = await Assert.ThrowsExceptionAsync<GoogleApiException>(async () => await GoogleSearch.WebSearch.QueryAsync(request));

        Assert.IsNotNull(exception);
        Assert.IsTrue(exception.Message.Contains("Number must be between 1 and 10"));
    }

    [TestMethod]
    public async Task WebSearchWhenNumberIsGreaterThanTenTest()
    {
        var request = new WebSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "google",
            SearchEngineId = this.Settings.SearchEngineId,
            Options =
            {
                Number = 11
            }
        };

        var exception = await Assert.ThrowsExceptionAsync<GoogleApiException>(async () => await GoogleSearch.WebSearch.QueryAsync(request));

        Assert.IsNotNull(exception);
        Assert.IsTrue(exception.Message.Contains("Number must be between 1 and 10"));
    }
}