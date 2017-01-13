using System;
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
        public void TranslateWhenTargetIsDanishTest()
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
        public void TranslateWhenTargetIsGermanTest()
        {
            var request = new TranslateRequest { Target = "de", Qs = new[] { "Hello World" }, Key = this.ApiKey, Format = Format.Text };
            var result = GoogleTranslate.Translate.Query(request);

            Assert.AreEqual("Hallo Welt", result.Data.Translations.First().TranslatedText);
            Assert.AreEqual("en", result.Data.Translations.First().DetectedSourceLanguage);
        }
        [Test]
        public void TranslateWhenApiKeyIsNullTest()
        {
            var request = new TranslateRequest
            {
                Key = null
            };

            var _exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Translate.Query(request));
            Assert.AreEqual(_exception.Message, "ApiKey is required");
        }
        [Test]
        public void TranslateWhenApiKeyIsStringEmptyTest()
        {
            var request = new TranslateRequest
            {
                Key = string.Empty
            };

            var _exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Translate.Query(request));
            Assert.AreEqual(_exception.Message, "ApiKey is required");
        }
        [Test]
        public void TranslateWhenTargetIsNullTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Target = null
            };

            var _exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Translate.Query(request));
            Assert.AreEqual(_exception.Message, "Target is required");
        }
        [Test]
        public void TranslateWhenTargetIsStringEmptyTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Target = string.Empty
            };

            var _exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Translate.Query(request));
            Assert.AreEqual(_exception.Message, "Target is required");
        }
        [Test]
        public void TranslateWhenQsIsNullTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Target = "da",
                Qs = null
            };

            var _exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Translate.Query(request));
            Assert.AreEqual(_exception.Message, "Qs is required");
        }
        [Test]
        public void TranslateWhenQsIsEmptyTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Target = "da",
                Qs = new string[0]
            };

            var _exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Translate.Query(request));
            Assert.AreEqual(_exception.Message, "Qs is required");
        }          
    }
}