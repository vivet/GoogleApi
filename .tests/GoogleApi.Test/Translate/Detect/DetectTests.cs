using System.Linq;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Translate.Detect.Request;
using NUnit.Framework;
using Language = GoogleApi.Entities.Translate.Common.Enums.Language;

namespace GoogleApi.Test.Translate.Detect;

[TestFixture]
public class DetectTests : BaseTest
{
    [Test]
    public async Task DetectTest()
    {
        var request = new DetectRequest
        {
            Key = this.Settings.ApiKey,
            Qs = new[] { "Hello World" }
        };

        var result = await GoogleTranslate.Detect.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);

        var detections = result.Data.Detections?.ToArray();
        Assert.IsNotNull(detections);
        Assert.IsNotEmpty(detections);

        var detection = detections.FirstOrDefault();
        Assert.IsNotNull(detection);
        Assert.AreEqual(Language.English, detection[0].Language);
    }

    [Test]
    public async Task DetectWhenMultipleQsTest()
    {
        var request = new DetectRequest
        {
            Key = this.Settings.ApiKey,
            Qs = new[] { "Hello World", "Der var engang" }
        };

        var result = await GoogleTranslate.Detect.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);

        var detections = result.Data.Detections?.ToArray();
        Assert.IsNotNull(detections);
        Assert.IsNotEmpty(detections);
        Assert.AreEqual(2, detections.Length);

        var detection1 = detections[0];
        Assert.IsNotNull(detection1);
        Assert.AreEqual(Language.English, detection1[0].Language);

        var detection2 = detections[1];
        Assert.IsNotNull(detection2);
        Assert.AreEqual(Language.Danish, detection2[0].Language);
    }
}