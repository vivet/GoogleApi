using System;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Video.Channels.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Search.Video.Channels
{
    [TestFixture]
    public class ChannelSearchTests : BaseTest
    {
        [Test]
        public void ChannelSearchTest()
        {
            var request = new ChannelSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                MaxResults = 1
            };

            var response = GoogleSearch.VideoSearch.Channels.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, Status.Ok);
        }
            
        [Test]
        public void ChannelSearchAsyncTest()
        {
            var request = new ChannelSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                MaxResults = 1
            };

            var response = GoogleSearch.VideoSearch.Channels.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, Status.Ok);
            Assert.IsNotEmpty(response.Items);
        }

        [Test]
        public void ChannelSearchWhenAsyncAndCancelledTest()
        {
            var request = new ChannelSearchRequest
            {
                Key = this.ApiKey,
                Query = "google"
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleSearch.VideoSearch.Channels.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }
    }
}