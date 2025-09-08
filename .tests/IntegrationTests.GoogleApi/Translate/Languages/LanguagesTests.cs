using System.Linq;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Translate.Languages.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Language = GoogleApi.Entities.Translate.Common.Enums.Language;

namespace GoogleApi.Test.Translate.Languages;

[TestClass]
public class LanguagesTests : BaseTest
{
    [TestMethod]
    public async Task LanguagesTest()
    {
        var request = new LanguagesRequest
        {
            Key = this.Settings.ApiKey
        };

        var result = await GoogleTranslate.Languages.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);

        var languages = result.Data.Languages;
        Assert.IsNotNull(languages);
        Assert.AreEqual(193, languages.Count());
    }

    [TestMethod]
    public async Task LanguagesWhenTargetTest()
    {
        var request = new LanguagesRequest
        {
            Key = this.Settings.ApiKey,
            Target = Language.English
        };

        var result = await GoogleTranslate.Languages.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);

        var languages = result.Data.Languages;
        Assert.IsNotNull(languages);
        Assert.AreEqual(193, languages.Count());
    }
}