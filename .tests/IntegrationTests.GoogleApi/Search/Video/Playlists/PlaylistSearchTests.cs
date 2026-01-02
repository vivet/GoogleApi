using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Video.Playlists.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.GoogleApi.Search.Video.Playlists;

[TestClass]
public class PlaylistSearchTests : BaseTest
{
    [TestMethod]
    [Ignore("Requires Enterprise License")]
    public async Task PlaylistsSearchTest()
    {
        var request = new PlaylistSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "google",
            MaxResults = 1
        };

        var response = await GoogleSearch.VideoSearch.Playlists.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, Status.Ok);
    }
}