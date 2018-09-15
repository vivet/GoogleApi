using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Video.Request;
using GoogleApi.Entities.Search.Video.Request.Enums;
using GoogleApi.Entities.Search.Video.Response.Enums;
using NUnit.Framework;

namespace GoogleApi.Test.Search.Video
{
    [TestFixture]
    public class VideoSearchTests : BaseTest
    {
        [Test]
        public void VideoSearchTest()
        {
            var request = new VideoSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                MaxResults = 1
            };

            var response = GoogleSearch.VideoSearch.Query(request);
            Console.WriteLine(response.RawJson);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, Status.Ok);

            Assert.AreEqual(response.Kind, "youtube#searchListResponse");
            Assert.IsNotNull(response.ETag);
            Assert.IsNotNull(response.PageToken);
            Assert.AreEqual(response.Region, Country.Denmark);
            Assert.AreEqual(response.PageInfo.TotalResults, 1000000);
            Assert.AreEqual(response.PageInfo.ResultsPerPage, 1);


            Assert.IsNotNull(response.Items);
            Assert.AreEqual(1, response.Items.Count());

            var item = response.Items.First();
            Assert.AreEqual(item.Kind, "youtube#searchResult");
            Assert.IsNotNull(item.ETag);
            Assert.AreEqual(item.Id.Kind, "youtube#video");
            Assert.AreEqual(item.Id.VideoId, "YR_kV74lfoQ");

            var snippet = item.Snippet;
            Assert.IsNotNull(snippet);
            Assert.IsNotNull(snippet.PublishedAt);
            Assert.AreEqual(snippet.ChannelId, "UCIZBXVGIJoJMXf8giib0IiQ");
            Assert.AreEqual(snippet.Title, "Google BUSTED Influencing Election Results");
            Assert.AreEqual(snippet.Description, "Protect yourself online now with VirtualShield's VPN technology- 70% off! http://www.virtualshield.com/allsup Leaked documents prove that Google was ...");
            Assert.AreEqual(snippet.ChannelId, "UCIZBXVGIJoJMXf8giib0IiQ");
            Assert.AreEqual(snippet.ChannelTitle, "James Allsup");
            Assert.AreEqual(snippet.LiveBroadcastContent, "none");

            var thumbnails = snippet.Thumbnails;
            Assert.IsNotNull(thumbnails);

            Assert.AreEqual(thumbnails.Default.Width, 120);
            Assert.AreEqual(thumbnails.Default.Height, 90);
            Assert.AreEqual(thumbnails.Default.Url, "https://i.ytimg.com/vi/YR_kV74lfoQ/default.jpg");

            Assert.AreEqual(thumbnails.Medium.Width, 320);
            Assert.AreEqual(thumbnails.Medium.Height, 180);
            Assert.AreEqual(thumbnails.Medium.Url, "https://i.ytimg.com/vi/YR_kV74lfoQ/mqdefault.jpg");

            Assert.AreEqual(thumbnails.High.Width, 480);
            Assert.AreEqual(thumbnails.High.Height, 360);
            Assert.AreEqual(thumbnails.High.Url, "https://i.ytimg.com/vi/YR_kV74lfoQ/hqdefault.jpg");
        }
            
        [Test]
        public void VideoSearchAsyncTest()
        {
            var request = new VideoSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                Part = PartType.Snippet,
                MaxResults = 1
            };

            var response = GoogleSearch.VideoSearch.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.IsNotEmpty(response.Items);
            Assert.AreEqual(response.Status, Status.Ok);

            var items = response.Items;
            Assert.IsNotEmpty(items);
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
            var task = GoogleSearch.VideoSearch.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void VideoSearchWhenFieldsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void VideoSearchWhenPrettyPrintTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void VideoSearchWhenUserIpTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void VideoSearchWhenQuotaUserTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void VideoSearchWhenPartIsContentDetailsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void VideoSearchWhenPartIsFileDetailsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void VideoSearchWhenPartIsPlayerTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void VideoSearchWhenPartIsProcessingDetailsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void VideoSearchWhenPartIsRecordingDetailsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void VideoSearchWhenPartIsStatisticsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void VideoSearchWhenPartIsStatusTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void VideoSearchWhenPartIsSuggestionsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void VideoSearchWhenPartTopicDetailsTest()
        {
            Assert.Inconclusive();
        }
    }
}