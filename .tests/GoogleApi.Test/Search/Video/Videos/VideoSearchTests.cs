using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Video.Videos.Request;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;

namespace GoogleApi.Test.Search.Video.Videos
{
    [TestFixture]
    public class VideoSearchTests : BaseTest<GoogleSearch.VideoSearch.VideosApi>
    {
        protected override GoogleSearch.VideoSearch.VideosApi GetClient() => new(_httpClient);
        protected override GoogleSearch.VideoSearch.VideosApi GetClientStatic() => GoogleSearch.VideoSearch.Videos;

        [Test]
        public void VideoSearchTest()
        {
            var request = new VideoSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                MaxResults = 1
            };

            var response = Sut.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, Status.Ok);

            Assert.AreEqual("youtube#searchListResponse", response.Kind);
            Assert.IsNotNull(response.ETag);
            Assert.IsNotNull(response.PageToken);

            ////Assert.AreEqual(response.Region, Country.Denmark);  //#Flaky depends where you run it from...

            Assert.AreEqual(1000000, response.PageInfo.TotalResults);
            Assert.AreEqual(1, response.PageInfo.ResultsPerPage);

            Assert.IsNotNull(response.Items);
            Assert.AreEqual(1, response.Items.Count());
        }

        [Test]
        public void VideoSearchAsyncTest()
        {
            var request = new VideoSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                MaxResults = 1
            };

            var response = Sut.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, Status.Ok);
            Assert.IsNotEmpty(response.Items);
        }

        [Test]
        public void VideoSearchWhenAsyncAndCancelledTest()
        {
            var request = new VideoSearchRequest
            {
                Key = this.ApiKey,
                Query = "google"
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var task = Sut.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual("The operation was canceled.", exception.Message);
        }
    }
}