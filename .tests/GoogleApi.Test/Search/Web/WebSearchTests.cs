using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Common;
using GoogleApi.Entities.Search.Common.Enums;
using GoogleApi.Entities.Search.Web.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Language = GoogleApi.Entities.Search.Common.Enums.Language;

namespace GoogleApi.Test.Search.Web
{
    [TestFixture]
    public class WebSearchTests : BaseTest<GoogleSearch.WebSearchApi>
    {
        protected override GoogleSearch.WebSearchApi GetClient() => new(_httpClient);
        protected override GoogleSearch.WebSearchApi GetClientStatic() => GoogleSearch.WebSearch;

        [Test]
        public void WebSearchTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
                Query = "google"
            };

            var response = Sut.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, Status.Ok);
            Assert.AreEqual("customsearch#search", response.Kind);

            Assert.IsNotNull(response.Url);
            Assert.AreEqual("application/json", response.Url.Type);
            Assert.AreEqual("https://www.googleapis.com/customsearch/v1?q={searchTerms}&num={count?}&start={startIndex?}&lr={language?}&safe={safe?}&cx={cx?}&sort={sort?}&filter={filter?}&gl={gl?}&cr={cr?}&googlehost={googleHost?}&c2coff={disableCnTwTranslation?}&hq={hq?}&hl={hl?}&siteSearch={siteSearch?}&siteSearchFilter={siteSearchFilter?}&exactTerms={exactTerms?}&excludeTerms={excludeTerms?}&linkSite={linkSite?}&orTerms={orTerms?}&relatedSite={relatedSite?}&dateRestrict={dateRestrict?}&lowRange={lowRange?}&highRange={highRange?}&searchType={searchType}&fileType={fileType?}&rights={rights?}&imgSize={imgSize?}&imgType={imgType?}&imgColorType={imgColorType?}&imgDominantColor={imgDominantColor?}&alt=json", response.Url.Template);

            Assert.IsNotNull(response.Context);
            Assert.IsNull(response.Context.Facets);
            Assert.AreEqual("Google Web", response.Context.Title);

            Assert.IsNull(response.Spelling);

            Assert.IsNotNull(response.Search);
            Assert.LessOrEqual(response.Search.SearchTime, 3.00);
            Assert.IsNotNull(response.Search.SearchTimeFormatted);
            Assert.IsNotEmpty(response.Search.SearchTimeFormatted);
            Assert.Greater(response.Search.TotalResults, 800000000);

            var items = response.Items;
            Assert.IsNotNull(items);
            Assert.IsNotEmpty(response.Items);

            var item = response.Items.FirstOrDefault();
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Link);
            Assert.AreEqual("Google", item.Title);
            Assert.AreEqual("www.google.com", item.DisplayLink);

            Assert.IsNull(response.Promotions);

            var query = response.Query;
            Assert.IsNotNull(query);
            Assert.AreEqual("Google Custom Search - google", query.Title);
            Assert.Greater(query.TotalResults, 800000000);
            Assert.AreEqual("google", query.SearchTerms);
            Assert.AreEqual(10, query.Count);
            Assert.AreEqual(1, query.StartIndex);
            Assert.AreEqual(0, query.StartPage);
            Assert.IsNull(query.Language);
            Assert.AreEqual(EncodingType.Utf8, query.InputEncoding);
            Assert.AreEqual(EncodingType.Utf8, query.OutputEncoding);
            Assert.AreEqual(SafetyLevel.Off, query.SafetyLevel);
            Assert.AreEqual(this.SearchEngineId, query.SearchEngineId);
            Assert.IsFalse(query.Filter);
            Assert.IsTrue(query.DisableCnTwTranslation);
            Assert.AreEqual(Language.English, query.InterfaceLanguage);

            var nextPage = response.NextPage;
            Assert.IsNotNull(nextPage);
            Assert.AreEqual("Google Custom Search - google", nextPage.Title);
            Assert.Greater(nextPage.TotalResults, 800000000);
            Assert.AreEqual("google", nextPage.SearchTerms);
            Assert.AreEqual(10, nextPage.Count);
            Assert.AreEqual(11, nextPage.StartIndex);
            Assert.AreEqual(0, nextPage.StartPage);
            Assert.IsNull(nextPage.Language);
            Assert.AreEqual(EncodingType.Utf8, nextPage.InputEncoding);
            Assert.AreEqual(EncodingType.Utf8, nextPage.OutputEncoding);
            Assert.AreEqual(SafetyLevel.Off, nextPage.SafetyLevel);
            Assert.AreEqual(this.SearchEngineId, nextPage.SearchEngineId);
            Assert.IsFalse(nextPage.Filter);
            Assert.IsTrue(nextPage.DisableCnTwTranslation);
            Assert.AreEqual(Language.English, nextPage.InterfaceLanguage);

            Assert.IsNull(response.PreviousPage);

            var sort = query.SortExpression;
            Assert.IsNull(sort);

            Assert.IsFalse(query.Filter);
            Assert.IsNull(query.GeoLocation);
            Assert.IsNull(query.CountryRestrict);
            Assert.IsNull(query.Googlehost);
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

        [Test]
        public void WebSearchAsyncTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
                Query = "google"
            };

            var response = Sut.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.IsNotEmpty(response.Items);
            Assert.AreEqual(response.Status, Status.Ok);

            var items = response.Items;
            Assert.IsNotEmpty(items);
        }

        [Test]
        public void WebSearchWhenAsyncAndCancelledTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
                Query = "google"
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var task = Sut.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual("The operation was canceled.", exception.Message);
        }

        [Test]
        public void WebSearchWhenFieldsTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
                Query = "google",
                Fields = "kind"
            };

            var response = Sut.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("customsearch#search", response.Kind);

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

        [Test]
        public void WebSearchWhenPrettyPrintTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void WebSearchWhenUserIpTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void WebSearchWhenQuotaUserTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void WebSearchWhenDisableCnTwTranslationFalseTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
                Query = "google",
                Options =
                {
                    DisableCnTwTranslation = false
                }
            };

            var response = Sut.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, Status.Ok);

            var items = response.Items;
            Assert.IsNotNull(items);
            Assert.IsNotEmpty(response.Items);

            var query = response.Query;
            Assert.IsNotNull(query);
            Assert.IsFalse(query.DisableCnTwTranslation);
        }

        [Test]
        public void WebSearchWhenCountryRestrictionTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
                Query = "google",
                Options =
                {
                    CountryRestrict = new CountryRestrict
                    {
                        Expressions = new List<CountryRestrictExpression>
                        {
                            new CountryRestrictExpression { Country = Country.Denmark},
                            new CountryRestrictExpression { Country = Country.Italy }
                        }
                    }
                }
            };

            var response = Sut.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, Status.Ok);

            var items = response.Items;
            Assert.IsNotNull(items);
            Assert.IsNotEmpty(response.Items);

            var query = response.Query;
            Assert.IsNotNull(query);
            Assert.AreEqual("(countryDK.countryIT).", query.CountryRestrict);
        }

        [Test]
        public void WebSearchWhenDateRestrictTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
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

            var response = Sut.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, Status.Ok);

            var items = response.Items;
            Assert.IsNotNull(items);
            Assert.IsNotEmpty(response.Items);

            var query = response.Query;
            Assert.IsNotNull(query);
            Assert.AreEqual(3, query.DateRestrict.Number);
            Assert.AreEqual(DateRestrictType.Days, query.DateRestrict.Type);
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
        public void WebSearchWhenFileTypesTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
                Query = "google",
                Options =
                {
                    FileTypes = new[]
                    {
                        FileType.Text,
                        FileType.AdobePortableDocumentFormat
                    }
                }
            };

            var response = Sut.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, Status.Ok);

            var items = response.Items;
            Assert.IsNotNull(items);
            Assert.IsNotEmpty(response.Items);

            var query = response.Query;
            Assert.IsNotNull(query);

            var fileTypes = query.FileTypes.ToArray();
            Assert.AreEqual(2, fileTypes.Length);
            Assert.Contains(FileType.Text, fileTypes);
            Assert.Contains(FileType.AdobePortableDocumentFormat, fileTypes);
        }

        [Test]
        public void WebSearchWhenFilterTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void WebSearchWhenGeoLocationTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
                Query = "google",
                Options =
                {
                    GeoLocation = GeoLocation.Denmark
                }
            };

            var response = Sut.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, Status.Ok);

            var items = response.Items;
            Assert.IsNotNull(items);
            Assert.IsNotEmpty(response.Items);

            var query = response.Query;
            Assert.IsNotNull(query);
            Assert.AreEqual(GeoLocation.Denmark, query.GeoLocation);
        }

        [Test]
        public void WebSearchWhenGooglehostTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void WebSearchWhenHighRangeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void WebSearchWhenInterfaceLanguageTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
                Query = "google",
                Options =
                {
                    InterfaceLanguage = Language.German
                }
            };

            var response = Sut.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, Status.Ok);

            var items = response.Items;
            Assert.IsNotNull(items);
            Assert.IsNotEmpty(response.Items);

            var query = response.Query;
            Assert.IsNotNull(query);
            Assert.AreEqual(Language.German, query.InterfaceLanguage);
        }

        [Test]
        public void WebSearchWhenAndTermsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void WebSearchWhenLinkSiteTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void WebSearchWhenLowRangeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void WebSearchWhenNumberTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
                Query = "google",
                Options =
                {
                    Number = 6
                }
            };

            var response = Sut.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, Status.Ok);

            var items = response.Items;
            Assert.IsNotNull(items);
            Assert.IsNotEmpty(response.Items);

            var query = response.Query;
            Assert.IsNotNull(query);
            Assert.AreEqual(6, query.Count);
        }

        [Test]
        public void WebSearchWhenOrTermsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void WebSearchWhenRelatedSiteTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void WebSearchWhenRightsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void WebSearchWhenSafetyLevelTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void WebSearchWhenSafetyLevelOffTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                SearchEngineId = this.SearchEngineId,
                Options =
                {
                    InterfaceLanguage = Language.Danish,
                    SafetyLevel = SafetyLevel.Off
                }
            };

            Assert.DoesNotThrow(() => Sut.Query(request));
        }

        [Test]
        public void WebSearchWhenSafetyLevelAndNotAllowedTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                SearchEngineId = this.SearchEngineId,
                Options =
                {
                    InterfaceLanguage = Language.Danish,
                    SafetyLevel = SafetyLevel.High
                }
            };

            var exception = Assert.Throws<AggregateException>(() => Sut.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, $"SafetyLevel is not allowed for specified InterfaceLanguage: {request.Options.InterfaceLanguage}");
        }

        [Test]
        public void WebSearchWhenSiteSearchTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
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

            var response = Sut.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, Status.Ok);

            var items = response.Items;
            Assert.IsNotNull(items);
            Assert.IsNotEmpty(response.Items);

            var query = response.Query;
            Assert.IsNotNull(query);
            Assert.IsNotNull(query.SiteSearch);
            Assert.AreEqual("google.com", query.SiteSearch.Site);
            Assert.AreEqual(SiteSearchFilter.Exclude, query.SiteSearch.Filter);
        }

        [Test]
        public void WebSearchWhenSortExpressionTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
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

            var response = Sut.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, Status.Ok);

            var items = response.Items;
            Assert.IsNotNull(items);
            Assert.IsNotEmpty(response.Items);

            var query = response.Query;
            Assert.IsNotNull(query);

            var sort = query.SortExpression;
            Assert.IsNotNull(sort);
            Assert.AreEqual(SortBy.Date, sort.By);
            Assert.AreEqual(SortOrder.Descending, sort.Order);
            Assert.AreEqual(2, sort.DefaultValue);
        }

        [Test]
        public void WebSearchWhenStartIndexTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
                Query = "google",
                Options =
                {
                    StartIndex = 11
                }
            };

            var response = Sut.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("customsearch#search", response.Kind);

            var items = response.Items;
            Assert.IsNotNull(items);
            Assert.IsNotEmpty(response.Items);

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

        [Test]
        public void WebSearchWhenKeyIsNullTest()
        {
            var request = new WebSearchRequest
            {
                Key = null
            };

            var exception = Assert.Throws<AggregateException>(() => Sut.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("Key is required", innerException.Message);
        }

        [Test]
        public void WebSearchWhenQueryIsNullTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                Query = null
            };

            var exception = Assert.Throws<AggregateException>(() => Sut.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("Query is required", innerException.Message);
        }

        [Test]
        public void WebSearchWhenSearchEngineIdIsNullTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                SearchEngineId = null
            };

            var exception = Assert.Throws<AggregateException>(() => Sut.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("SearchEngineId is required", innerException.Message);
        }

        [Test]
        public void WebSearchWhenNumberIsLessThanOneTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                SearchEngineId = this.SearchEngineId,
                Options =
                {
                    Number = 0
                }
            };

            var exception = Assert.Throws<AggregateException>(() => Sut.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("Number must be between 1 and 10", innerException.Message);
        }

        [Test]
        public void WebSearchWhenNumberIsGreaterThanTenTest()
        {
            var request = new WebSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                SearchEngineId = this.SearchEngineId,
                Options =
                {
                    Number = 11
                }
            };

            var exception = Assert.Throws<AggregateException>(() => Sut.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("Number must be between 1 and 10", innerException.Message);
        }
    }
}