using System.Linq;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Image.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Search.Image;

[TestFixture]
public class ImageSearchTests : BaseTest
{
    [Test]
    public async Task ImageSearchTest()
    {
        var request = new ImageSearchRequest
        {
            Key = this.Settings.ApiKey,
            SearchEngineId = this.Settings.SearchEngineId,
            Query = "google"
        };

        var response = await GoogleSearch.ImageSearch.QueryAsync(request);
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
    [Ignore("Inconclusive")]
    public async Task ImageSearchWhenImageTypeTest()
    {
        await Task.CompletedTask;
    }

    [Test]
    [Ignore("Inconclusive")]
    public async Task ImageSearchWhenImageSizeTest()
    {
        await Task.CompletedTask;
    }

    [Test]
    [Ignore("Inconclusive")]
    public async Task ImageSearchWhenImageColorTypeTest()
    {
        await Task.CompletedTask;
    }

    [Test]
    [Ignore("Inconclusive")]
    public async Task ImageSearchWhenImageDominantColorTest()
    {
        await Task.CompletedTask;
    }

    [Test]
    public void ImageSearchWhenKeyIsNullTest()
    {
        var request = new ImageSearchRequest
        {
            Key = null
        };

        var exception = Assert.ThrowsAsync<GoogleApiException>(async () => await GoogleSearch.ImageSearch.QueryAsync(request));
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "Key is required");
    }

    [Test]
    public void ImageSearchWhenQueryIsNullTest()
    {
        var request = new ImageSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = null
        };

        var exception = Assert.ThrowsAsync<GoogleApiException>(async () => await GoogleSearch.ImageSearch.QueryAsync(request));
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "Query is required");
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

        var exception = Assert.ThrowsAsync<GoogleApiException>(async () => await GoogleSearch.ImageSearch.QueryAsync(request));
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "SearchEngineId is required");
    }
}