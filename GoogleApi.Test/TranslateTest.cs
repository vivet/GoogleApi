using System.Linq;
using GoogleApi.Entities.Translate.Translate.Request;
using GoogleApi.Entities.Translate.Translate.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
    public class TranslateTest
    {
        public string _apiKey = ""; // your API key goes here...

        [Test]
        public void TranslateCorrectTest()
        {
            var _request = new TranslateRequest { Target = "de", Qs = new[] { "Hello World" }, ApiKey = this._apiKey, Format = Format.Text };

            var _result = GoogleTranslate.Translate.Query(_request);

            Assert.AreEqual("Hallo Welt", _result.Data.Translations.First().TranslatedText);
            Assert.AreEqual("en", _result.Data.Translations.First().DetectedSourceLanguage);
        }
    }
}