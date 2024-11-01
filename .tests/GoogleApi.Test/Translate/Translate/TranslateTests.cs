using System.Linq;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Translate.Request;
using NUnit.Framework;
using Language = GoogleApi.Entities.Translate.Common.Enums.Language;

namespace GoogleApi.Test.Translate.Translate;

[TestFixture]
public class TranslateTests : BaseTest
{
    [Test]
    public async Task TranslateTest()
    {
        var request = new TranslateRequest
        {
            Key = this.Settings.ApiKey,
            Source = Language.English,
            Target = Language.Danish,
            Qs = new[] { "Hello World" }
        };

        var result = await GoogleTranslate.Translate.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);

        var translation1 = result.Data.Translations.FirstOrDefault();
        Assert.IsNotNull(translation1);
        Assert.AreEqual("Hej verden", translation1.TranslatedText);
    }

    [Test]
    public async Task TranslateWhenMultipleQsTest()
    {
        var request = new TranslateRequest
        {
            Key = this.Settings.ApiKey,
            Source = Language.English,
            Target = Language.Danish,
            Qs = new[] { "Hello World", "Once upon a time" }
        };

        var result = await GoogleTranslate.Translate.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);

        var translations = result.Data.Translations?.ToArray();
        Assert.IsNotNull(translations);
        Assert.IsNotEmpty(translations);
        Assert.AreEqual(2, translations.Length);

        var translation1 = translations[0];
        Assert.IsNotNull(translation1);
        Assert.AreEqual("Hej verden", translation1.TranslatedText);

        var translation2 = translations[1];
        Assert.IsNotNull(translation2);
        Assert.AreEqual("Der var engang", translation2.TranslatedText);
    }

    [Test]
    public async Task TranslateWhenDetectedSourceLanguageTest()
    {
        var request = new TranslateRequest
        {
            Key = this.Settings.ApiKey,
            Target = Language.Albanian,
            Qs = new[] { "Hej med dig min ven" }
        };

        var result = await GoogleTranslate.Translate.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);

        Assert.AreEqual(Language.Danish, result.Data.Translations.FirstOrDefault()?.DetectedSourceLanguage);
    }

    [Test]
    public async Task TranslateWhenModelNmtTest()
    {
        var request = new TranslateRequest
        {
            Key = this.Settings.ApiKey,
            Source = Language.English,
            Target = Language.Danish,
            Model = Model.Nmt,
            Qs = new[] { "Hello World" }
        };

        var result = await GoogleTranslate.Translate.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);

        Assert.AreEqual(Model.Nmt, result.Data.Translations?.FirstOrDefault()?.Model);
    }
}