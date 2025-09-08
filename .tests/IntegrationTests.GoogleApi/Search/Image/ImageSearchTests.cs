using System.Linq;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Image.Request;
using GoogleApi.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.Test.Search.Image;

[TestClass]
public class ImageSearchTests : BaseTest
{
    [TestMethod]
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
        Assert.IsTrue(response.Items.Any());
        Assert.AreEqual(response.Kind, "customsearch#search");
        Assert.AreEqual(response.Status, Status.Ok);

        Assert.IsNotNull(response.Url);
        Assert.AreEqual(response.Url.Type, "application/json");
        Assert.AreEqual(response.Url.Template, "https://www.googleapis.com/customsearch/v1?q={searchTerms}&num={count?}&start={startIndex?}&lr={language?}&safe={safe?}&cx={cx?}&sort={sort?}&filter={filter?}&gl={gl?}&cr={cr?}&googlehost={googleHost?}&c2coff={disableCnTwTranslation?}&hq={hq?}&hl={hl?}&siteSearch={siteSearch?}&siteSearchFilter={siteSearchFilter?}&exactTerms={exactTerms?}&excludeTerms={excludeTerms?}&linkSite={linkSite?}&orTerms={orTerms?}&relatedSite={relatedSite?}&dateRestrict={dateRestrict?}&lowRange={lowRange?}&highRange={highRange?}&searchType={searchType}&fileType={fileType?}&rights={rights?}&imgSize={imgSize?}&imgType={imgType?}&imgColorType={imgColorType?}&imgDominantColor={imgDominantColor?}&alt=json");

        Assert.IsNotNull(response.Search);
        Assert.IsTrue(response.Search.SearchTime > 0.00);
        Assert.IsTrue(response.Search.SearchTimeFormatted.Any());
        Assert.IsTrue(response.Search.TotalResults > 0);
        Assert.IsTrue(response.Search.TotalResultsFormatted.Any());

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

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task ImageSearchWhenImageTypeTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task ImageSearchWhenImageSizeTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task ImageSearchWhenImageColorTypeTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    [Ignore("Inconclusive")]
    public Task ImageSearchWhenImageDominantColorTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    public async Task ImageSearchWhenKeyIsNullTest()
    {
        var request = new ImageSearchRequest
        {
            Key = null
        };

        var exception = await Assert.ThrowsExceptionAsync<GoogleApiException>(async () => await GoogleSearch.ImageSearch.QueryAsync(request));

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "Key is required");
    }

    [TestMethod]
    public async Task ImageSearchWhenQueryIsNullTest()
    {
        var request = new ImageSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = null
        };

        var exception = await Assert.ThrowsExceptionAsync<GoogleApiException>(async () => await GoogleSearch.ImageSearch.QueryAsync(request));

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "Query is required");
    }

    [TestMethod]
    public async Task ImageSearchWhenSearchEngineIdIsNullTest()
    {
        var request = new ImageSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "google",
            SearchEngineId = null
        };

        var exception = await Assert.ThrowsExceptionAsync<GoogleApiException>(async () => await GoogleSearch.ImageSearch.QueryAsync(request));

        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "SearchEngineId is required");
    }
}