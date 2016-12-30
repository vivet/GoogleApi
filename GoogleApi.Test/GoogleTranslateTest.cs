using System.Linq;
using GoogleApi.Entities.Translate.Translate.Request;
using GoogleApi.Entities.Translate.Translate.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
    public class GoogleTranslateTest : BaseTest
    {
        [Test]
        public void TranslateDanishTest()
        {
            var request = new TranslateRequest
            {
                Target = "da",
                Qs = new[] { "Hello World" },
                Key = this.ApiKey
            };
            var result = GoogleTranslate.Translate.Query(request);

            Assert.AreEqual("Hej Verden", result.Data.Translations.First().TranslatedText);
            Assert.AreEqual("en", result.Data.Translations.First().DetectedSourceLanguage);
        }
        [Test]
        public void TranslateGermanTest()
        {
            var request = new TranslateRequest { Target = "de", Qs = new[] { "Hello World" }, Key = this.ApiKey, Format = Format.Text };
            var result = GoogleTranslate.Translate.Query(request);

            Assert.AreEqual("Hallo Welt", result.Data.Translations.First().TranslatedText);
            Assert.AreEqual("en", result.Data.Translations.First().DetectedSourceLanguage);
        }
    }
}