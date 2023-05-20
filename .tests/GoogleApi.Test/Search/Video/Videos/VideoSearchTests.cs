using System.Linq;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Search.Video.Videos.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Search.Video.Videos;

[TestFixture]
public class VideoSearchTests : BaseTest
{
    [Test]
    [Ignore("Requires Enterprise License")]
    public async Task VideoSearchTest()
    {
        var request = new VideoSearchRequest
        {
            Key = this.Settings.ApiKey,
            Query = "google",
            MaxResults = 1
        };

        var response = await GoogleSearch.VideoSearch.Videos.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(response.Status, Status.Ok);

        Assert.AreEqual(response.Kind, "youtube#searchListResponse");
        Assert.IsNotNull(response.ETag);
        Assert.IsNotNull(response.PageToken);
        Assert.AreEqual(response.PageInfo.TotalResults, 1000000);
        Assert.AreEqual(response.PageInfo.ResultsPerPage, 1);

        Assert.IsNotNull(response.Items);
        Assert.AreEqual(1, response.Items.Count());
    }
}