using System;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Video.Playlists.Request;
using GoogleApi.Entities.Search.Video.Videos.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Search.Video.Playlists
{
    [TestFixture]
    public class PlaylistSearchTests : BaseTest
    {
        [Test]
        public void PlaylistsSearchTest()
        {
            var request = new PlaylistSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                MaxResults = 1
            };

            var response = GoogleSearch.VideoSearch.Playlists.Query(request);

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

            var response = GoogleSearch.VideoSearch.Playlists.QueryAsync(request).Result;

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
            var task = GoogleSearch.VideoSearch.Playlists.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }
    }
}