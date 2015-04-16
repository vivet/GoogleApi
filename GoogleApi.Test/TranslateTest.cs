using System.Linq;
using GoogleApi.Entities.Translate.Translate.Request;
using GoogleApi.Entities.Translate.Translate.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
    public class TranslateTest
    {
        public string ApiKey = ""; // your API key goes here...

        [Test]
        public void TranslateCorrectTest()
        {
            var request = new TranslateRequest { Target = "de", Qs = new[] { "Hello World" }, ApiKey = this.ApiKey, Format = Format.Text };

            var result = GoogleTranslate.Translate.Query(request);

            Assert.AreEqual("Hallo Welt", result.Data.Translations.First().TranslatedText);
            Assert.AreEqual("en", result.Data.Translations.First().DetectedSourceLanguage);
        }
    }
}