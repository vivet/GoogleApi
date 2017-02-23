using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Translate.Translate.Request;
using GoogleApi.Entities.Translate.Translate.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.Test.Translate
{
    [TestFixture]
    public class TranslateTests : BaseTest
    {
        [Test]
        public void TranslateTest()
        {
            var request = new TranslateRequest
            {
                Target = "da",
                Qs = new[] { "Hello World" },
                Key = this.ApiKey
            };

            var result = GoogleTranslate.Translate.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var translations = result.Data.Translations?.ToArray();
            Assert.IsNotNull(translations);
            Assert.IsNotEmpty(translations);

            var translation = translations.FirstOrDefault();
            Assert.IsNotNull(translation);
            Assert.AreEqual("Hej Verden", translation.TranslatedText);
            Assert.AreEqual("en", translation.DetectedSourceLanguage);
        }
        [Test]
        public void TranslateWhenMultipleQsTest()
        {
            var request = new TranslateRequest
            {
                Target = "da",
                Qs = new[] { "Hello World", "Der var engang" },
                Key = this.ApiKey
            };

            var result = GoogleTranslate.Translate.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var translations = result.Data.Translations?.ToArray();
            Assert.IsNotNull(translations);
            Assert.IsNotEmpty(translations);
            Assert.AreEqual(2, translations.Length);

            var translation1 = translations[0];
            Assert.IsNotNull(translation1);
            Assert.AreEqual("Hej Verden", translation1.TranslatedText);
            Assert.AreEqual("en", translation1.DetectedSourceLanguage);

            var translation2 = translations[1];
            Assert.IsNotNull(translation2);
            Assert.AreEqual("Once upon a time", translation2.TranslatedText);
            Assert.AreEqual("en", translation2.DetectedSourceLanguage);
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
        public void TranslateWhenKeyIsNullTest()
        {
            var request = new TranslateRequest
            {
                Key = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Translate.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void TranslateWhenKeyIsStringEmptyTest()
        {
            var request = new TranslateRequest
            {
                Key = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Translate.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }

        [Test]
        public void TranslateWhenTargetIsNullTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Target = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Translate.Query(request));
            Assert.AreEqual(exception.Message, "Target is required");
        }
        [Test]
        public void TranslateWhenTargetIsStringEmptyTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Target = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Translate.Query(request));
            Assert.AreEqual(exception.Message, "Target is required");
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

            var exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Translate.Query(request));
            Assert.AreEqual(exception.Message, "Qs is required");
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

            var exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Translate.Query(request));
            Assert.AreEqual(exception.Message, "Qs is required");
        }          
    }
}