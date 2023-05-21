using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Video.Channels.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Search.Video.Channels;

[TestFixture]
public class ChannelSearchTests : BaseTest
{
    [Test]
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