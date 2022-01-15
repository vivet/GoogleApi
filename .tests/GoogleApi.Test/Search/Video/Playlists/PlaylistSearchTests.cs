using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Video.Playlists.Request;
using NUnit.Framework;
using System;
using System.Threading;

namespace GoogleApi.Test.Search.Video.Playlists
{
    [TestFixture]
    public class PlaylistSearchTests : BaseTest<GoogleSearch.VideoSearch.PlaylistsApi>
    {
        protected override GoogleSearch.VideoSearch.PlaylistsApi GetClient() => new(_httpClient);
        protected override GoogleSearch.VideoSearch.PlaylistsApi GetClientStatic() => GoogleSearch.VideoSearch.Playlists;

        [Test]
        public void PlaylistsSearchTest()
        {
            var request = new PlaylistSearchRequest
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
        public void PlaylistsSearchAsyncTest()
        {
            var request = new PlaylistSearchRequest
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
        public void PlaylistsSearchWhenAsyncAndCancelledTest()
        {
            var request = new PlaylistSearchRequest
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