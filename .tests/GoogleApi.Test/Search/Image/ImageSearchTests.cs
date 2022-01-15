using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Image.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;

namespace GoogleApi.Test.Search.Image
{
    [TestFixture]
    public class ImageSearchTests : BaseTest<GoogleSearch.ImageSearchApi>
    {
        protected override GoogleSearch.ImageSearchApi GetClient() => new(_httpClient);
        protected override GoogleSearch.ImageSearchApi GetClientStatic() => GoogleSearch.ImageSearch;

        [Test]
        public void ImageSearchTest()
        {
            var request = new ImageSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
                Query = "google"
            };

            var response = Sut.Query(request);
            Assert.IsNotNull(response);
            Assert.IsNotEmpty(response.Items);
            Assert.AreEqual("customsearch#search", response.Kind);
            Assert.AreEqual(Status.Ok, response.Status);

            Assert.IsNotNull(response.Url);
            Assert.AreEqual("application/json", response.Url.Type);
            Assert.AreEqual(
                "https://www.googleapis.com/customsearch/v1?q={searchTerms}&num={count?}&start={startIndex?}&lr={language?}&safe={safe?}&cx={cx?}&sort={sort?}&filter={filter?}&gl={gl?}&cr={cr?}&googlehost={googleHost?}&c2coff={disableCnTwTranslation?}&hq={hq?}&hl={hl?}&siteSearch={siteSearch?}&siteSearchFilter={siteSearchFilter?}&exactTerms={exactTerms?}&excludeTerms={excludeTerms?}&linkSite={linkSite?}&orTerms={orTerms?}&relatedSite={relatedSite?}&dateRestrict={dateRestrict?}&lowRange={lowRange?}&highRange={highRange?}&searchType={searchType}&fileType={fileType?}&rights={rights?}&imgSize={imgSize?}&imgType={imgType?}&imgColorType={imgColorType?}&imgDominantColor={imgDominantColor?}&alt=json",
                response.Url.Template);

            Assert.IsNotNull(response.Search);
            Assert.Greater(response.Search.SearchTime, 0.00);
            Assert.IsNotEmpty(response.Search.SearchTimeFormatted);
            Assert.Greater(response.Search.TotalResults, 0);
            Assert.IsNotEmpty(response.Search.TotalResultsFormatted);

            var context = response.Context;
            Assert.IsNotNull(context);
            Assert.AreEqual("Google Web", context.Title);

            var items = response.Items;
            Assert.IsNotNull(items);

            var item = response.Items.FirstOrDefault();
            Assert.IsNotNull(item);
            Assert.IsNotNull(item.Link);
            Assert.IsNotNull(item.Title);
            Assert.IsNotNull(item.DisplayLink);
        }

        [Test]
        public void ImageSearchAsyncTest()
        {
            var request = new ImageSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
                Query = "google"
            };

            var response = Sut.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.IsNotEmpty(response.Items);
            Assert.AreEqual("customsearch#search", response.Kind);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void ImageSearchWhenAsyncAndCancelledTest()
        {
            var request = new ImageSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = this.SearchEngineId,
                Query = "google"
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var task = Sut.QueryAsync(request, cancellationToken: cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual("The operation was canceled.", exception.Message);
        }

        [Test]
        public void ImageSearchWhenImageTypeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void ImageSearchWhenImageSizeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void ImageSearchWhenImageColorTypeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void ImageSearchWhenImageDominantColorTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void ImageSearchWhenKeyIsNullTest()
        {
            var request = new ImageSearchRequest
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
        public void ImageSearchWhenQueryIsNullTest()
        {
            var request = new ImageSearchRequest
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
        public void ImageSearchWhenSearchEngineIdIsNullTest()
        {
            var request = new ImageSearchRequest
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
    }
}