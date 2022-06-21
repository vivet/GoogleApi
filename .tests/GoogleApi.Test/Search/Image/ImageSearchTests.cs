using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Image.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Search.Image;

[TestFixture]
public class ImageSearchTests : BaseTest
{
    [Test]
    public void ImageSearchTest()
    {
        var request = new ImageSearchRequest
        {
            Key = this.Settings.ApiKey,
            SearchEngineId = this.Settings.SearchEngineId,
            Query = "google"
        };

        var response = GoogleSearch.ImageSearch.Query(request);
        Assert.IsNotNull(response);
        Assert.IsNotEmpty(response.Items);
        Assert.AreEqual(response.Kind, "customsearch#search");
        Assert.AreEqual(response.Status, Status.Ok);

        Assert.IsNotNull(response.Url);
        Assert.AreEqual(response.Url.Type, "application/json");
        Assert.AreEqual(response.Url.Template, "https://www.googleapis.com/customsearch/v1?q={searchTerms}&num={count?}&start={startIndex?}&lr={language?}&safe={safe?}&cx={cx?}&sort={sort?}&filter={filter?}&gl={gl?}&cr={cr?}&googlehost={googleHost?}&c2coff={disableCnTwTranslation?}&hq={hq?}&hl={hl?}&siteSearch={siteSearch?}&siteSearchFilter={siteSearchFilter?}&exactTerms={exactTerms?}&excludeTerms={excludeTerms?}&linkSite={linkSite?}&orTerms={orTerms?}&relatedSite={relatedSite?}&dateRestrict={dateRestrict?}&lowRange={lowRange?}&highRange={highRange?}&searchType={searchType}&fileType={fileType?}&rights={rights?}&imgSize={imgSize?}&imgType={imgType?}&imgColorType={imgColorType?}&imgDominantColor={imgDominantColor?}&alt=json");

        Assert.IsNotNull(response.Search);
        Assert.Greater(response.Search.SearchTime, 0.00);
        Assert.IsNotEmpty(response.Search.SearchTimeFormatted);
        Assert.Greater(response.Search.TotalResults, 0);
        Assert.IsNotEmpty(response.Search.TotalResultsFormatted);

        var context = response.Context;
        Assert.IsNotNull(context);
        Assert.AreEqual(context.Title, "Google Web");

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
            Key = this.Settings.ApiKey,
            SearchEngineId = this.Settings.SearchEngineId,
            Query = "google"
        };

        var response = GoogleSearch.ImageSearch.QueryAsync(request).Result;

        Assert.IsNotNull(response);
        Assert.IsNotEmpty(response.Items);
        Assert.AreEqual(response.Kind, "customsearch#search");
        Assert.AreEqual(response.Status, Status.Ok);
    }

    [Test]
    public void ImageSearchWhenAsyncAndCancelledTest()
    {
        var request = new ImageSearchRequest
        {
            Key = this.Settings.ApiKey,
            SearchEngineId = this.Settings.SearchEngineId,
            Query = "google"
        };

        var cancellationTokenSource = new CancellationTokenSource();
        var task = GoogleSearch.ImageSearch.QueryAsync(request, cancellationTokenSource.Token);
        cancellationTokenSource.Cancel();

        var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "The operation was canceled.");
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

        var exception = Assert.Throws<AggregateException>(() => GoogleSearch.ImageSearch.QueryAsync(request).Wait());
        Assert.IsNotNull(exception);

        var innerException = exception.InnerException;
        Assert.IsNotNull(innerException);
        Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
        Assert.AreEqual(innerException.Message, "Key is required");
    }

    [Test]
    public void ImageSearchWhenQueryIsNullTest()
    {
        var request = new ImageSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = null
        };

        var exception = Assert.Throws<AggregateException>(() => GoogleSearch.ImageSearch.QueryAsync(request).Wait());
        Assert.IsNotNull(exception);

        var innerException = exception.InnerException;
        Assert.IsNotNull(innerException);
        Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
        Assert.AreEqual(innerException.Message, "Query is required");
    }

    [Test]
    public void ImageSearchWhenSearchEngineIdIsNullTest()
    {
        var request = new ImageSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "google",
            SearchEngineId = null
        };

        var exception = Assert.Throws<AggregateException>(() => GoogleSearch.ImageSearch.QueryAsync(request).Wait());
        Assert.IsNotNull(exception);

        var innerException = exception.InnerException;
        Assert.IsNotNull(innerException);
        Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
        Assert.AreEqual(innerException.Message, "SearchEngineId is required");
    }
}