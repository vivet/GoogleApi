using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Search.Web.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Search
{
    [TestFixture]
    public class WebSearchTests : BaseTest
    {
        [Test]
        public void WebSearchTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
                Query = "google"
            };

            var response = GoogleSearch.WebSearch.Query(request);

            Assert.IsNotNull(response);
            Assert.IsNotEmpty(response.Items);
            Assert.AreEqual(response.Kind, "customsearch#search");
            Assert.AreEqual(response.Status, Status.Ok);

            Assert.IsNotNull(response.Url);
            Assert.AreEqual(response.Url.Type, "application/json");
            Assert.AreEqual(response.Url.Template, "https://www.googleapis.com/customsearch/v1?q={searchTerms}&num={count?}&start={startIndex?}&lr={language?}&safe={safe?}&cx={cx?}&cref={cref?}&sort={sort?}&filter={filter?}&gl={gl?}&cr={cr?}&googlehost={googleHost?}&c2coff={disableCnTwTranslation?}&hq={hq?}&hl={hl?}&siteSearch={siteSearch?}&siteSearchFilter={siteSearchFilter?}&exactTerms={exactTerms?}&excludeTerms={excludeTerms?}&linkSite={linkSite?}&orTerms={orTerms?}&relatedSite={relatedSite?}&dateRestrict={dateRestrict?}&lowRange={lowRange?}&highRange={highRange?}&searchType={searchType}&fileType={fileType?}&rights={rights?}&imgSize={imgSize?}&imgType={imgType?}&imgColorType={imgColorType?}&imgDominantColor={imgDominantColor?}&alt=json");

            Assert.IsNotNull(response.SearchInformation);
            Assert.Greater(response.SearchInformation.SearchTime, 0.00);
            Assert.IsNotEmpty(response.SearchInformation.SearchTimeFormatted);
            Assert.Greater(response.SearchInformation.TotalResults, 0);
            Assert.IsNotEmpty(response.SearchInformation.TotalResultsFormatted);

            var context = response.Context;
            Assert.IsNotNull(context);
            Assert.AreEqual(context.Title, "Google Web");

            var items = response.Items;
            Assert.IsNotNull(items);

            var item = response.Items.FirstOrDefault();
            Assert.IsNotNull(item);
            Assert.AreEqual(item.Link, "http://www.google.com/");
            Assert.AreEqual(item.Title, "Google");
            Assert.AreEqual(item.DisplayLink, "www.google.com");

        }
        [Test]
        public void WebSearchWhenFieldsTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenNumberTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenInterfaceLanguageTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenGeoLocationTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenCountryRestrictionTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenSortExpressionTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenStartIndexTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenSafetyLevelTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenFilterTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenDisableCnTwTranslationTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenRightsTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenFileTypesTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenDateRestrictTypeTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenGooglehostTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenSiteSearchTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenSiteSearchFilterTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenExactTermsTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenExcludeTermsTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWheAndTermsnTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenOrTermsTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenLinkSiteTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenRelatedSiteTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenLowRangeTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void WebSearchWhenHighRangeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void WebSearchWhenKeyIsNullTest()
        {
            var request = new WebSearchRequest
            {
                Key = null,
                SearchEngineId = this.SearchEngineId,
                Query = "google"
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleSearch.WebSearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void WebSearchWhenSearchEngineIdIsNullTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = null,
                Query = "google"
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleSearch.WebSearch.Query(request));
            Assert.AreEqual(exception.Message, "SearchEngineId is required.");
        }
        [Test]
        public void WebSearchWhenQueryIsNullTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
                Query = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleSearch.WebSearch.Query(request));
            Assert.AreEqual(exception.Message, "Query is required.");
        }

        [Test]
        public void WebSearchAsyncTest()
        {
            Assert.Inconclusive();
        }
    }
}