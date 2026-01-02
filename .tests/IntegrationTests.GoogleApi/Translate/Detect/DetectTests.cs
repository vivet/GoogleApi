using System.Linq;
using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Translate.Detect.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Language = GoogleApi.Entities.Translate.Common.Enums.Language;

namespace IntegrationTests.GoogleApi.Translate.Detect;

[TestClass]
public class DetectTests : BaseTest
{
    [TestMethod]
    public async Task DetectTest()
    {
        var request = new DetectRequest
        {
            Key = this.Settings.ApiKey,
            Qs = ["Hello World"]
        };

        var result = await GoogleTranslate.Detect.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);

        var detections = result.Data.Detections?.ToArray();
        Assert.IsNotNull(detections);
        Assert.IsTrue(detections.Any());

        var detection = detections.FirstOrDefault();
        Assert.IsNotNull(detection);
        Assert.AreEqual(Language.English, detection[0].Language);
    }

    [TestMethod]
    public async Task DetectWhenMultipleQsTest()
    {
        var request = new DetectRequest
        {
            Key = this.Settings.ApiKey,
            Qs = ["Hello World", "Der var engang"]
        };

        var result = await GoogleTranslate.Detect.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);

        var detections = result.Data.Detections?.ToArray();
        Assert.IsNotNull(detections);
        Assert.IsTrue(detections.Any());
        Assert.AreEqual(2, detections.Length);

        var detection1 = detections[0];
        Assert.IsNotNull(detection1);
        Assert.AreEqual(Language.English, detection1[0].Language);

        var detection2 = detections[1];
        Assert.IsNotNull(detection2);
        Assert.AreEqual(Language.Danish, detection2[0].Language);
    }
}