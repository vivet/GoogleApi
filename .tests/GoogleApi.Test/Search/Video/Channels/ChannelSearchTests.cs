using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Video.Channels.Request;
using NUnit.Framework;
using System;
using System.Threading;

namespace GoogleApi.Test.Search.Video.Channels
{
    [TestFixture]
    public class ChannelSearchTests : BaseTest<GoogleSearch.VideoSearch.ChannelsApi>
    {
        protected override GoogleSearch.VideoSearch.ChannelsApi GetClient() => new(_httpClient);
        protected override GoogleSearch.VideoSearch.ChannelsApi GetClientStatic() => GoogleSearch.VideoSearch.Channels;

        [Test]
        public void ChannelSearchTest()
        {
            var request = new ChannelSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                MaxResults = 1
            };

            var response = Sut.Query(request);

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

            var response = Sut.QueryAsync(request).Result;

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
            var task = Sut.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual("The operation was canceled.", exception.Message);
        }
    }
}