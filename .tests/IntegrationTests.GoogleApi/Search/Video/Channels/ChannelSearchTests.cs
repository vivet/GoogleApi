using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Video.Channels.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.GoogleApi.Search.Video.Channels;

[TestClass]
public class ChannelSearchTests : BaseTest
{
    [TestMethod]
    [Ignore("Requires Enterprise License")]
    public async Task ChannelSearchTest()
    {
        var request = new ChannelSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "google",
            MaxResults = 1
        };

        var response = await GoogleSearch.VideoSearch.Channels.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, Status.Ok);
    }
}