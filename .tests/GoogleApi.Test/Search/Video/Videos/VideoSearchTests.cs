using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Video.Common.Enums;
using GoogleApi.Entities.Search.Video.Videos.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Search.Video.Videos;

[TestFixture]
public class VideoSearchTests : BaseTest
{
    [Test]
    public void VideoSearchTest()
    {
        var request = new VideoSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "google",
            MaxResults = 1
        };

        var response = GoogleSearch.VideoSearch.Videos.Query(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, Status.Ok);

        Assert.AreEqual(response.Kind, "youtube#searchListResponse");
        Assert.IsNotNull(response.ETag);
        Assert.IsNotNull(response.PageToken);

        //NOTE: this check yields different outcome depending where the origin of the request comes from
        //Assert.AreEqual(response.Region, Country.Denmark);

        Assert.AreEqual(response.PageInfo.TotalResults, 1000000);
        Assert.AreEqual(response.PageInfo.ResultsPerPage, 1);

        Assert.IsNotNull(response.Items);
        Assert.AreEqual(1, response.Items.Count());
    }

    [Test]
    public void VideoSearchAsyncTest()
    {
        var request = new VideoSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "google",
            MaxResults = 1
        };

        var response = GoogleSearch.VideoSearch.Videos.QueryAsync(request).Result;

        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, Status.Ok);
        Assert.IsNotEmpty(response.Items);
    }

    [Test]
    public void VideoSearchWhenAsyncAndCancelledTest()
    {
        var request = new VideoSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "google"
        };

        var cancellationTokenSource = new CancellationTokenSource();
        var task = GoogleSearch.VideoSearch.Videos.QueryAsync(request, cancellationTokenSource.Token);
        cancellationTokenSource.Cancel();

        var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "The operation was canceled.");
    }
}