using System;
using System.Linq;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Translate.Request;
using NUnit.Framework;
using Language = GoogleApi.Entities.Translate.Common.Enums.Language;

namespace GoogleApi.Test.Translate.Translate
{
    [TestFixture]
    public class TranslateTests : BaseTest
    {
        [Test]
        public void TranslateTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Source = Language.English,
                Target = Language.Danish,
                Qs = new[] { "Hello World" }
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
            Assert.AreEqual(Model.Base, translation.Model);
            Assert.IsNull(translation.DetectedSourceLanguage);
        }

        [Test]
        public void TranslateWhenDetectedSourceLanguageTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Target = Language.Spanish,
                Qs = new[] { "Hej med dig min ven" }
            };

            var result = GoogleTranslate.Translate.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var translations = result.Data.Translations?.ToArray();
            Assert.IsNotNull(translations);
            Assert.IsNotEmpty(translations);

            var translation = translations.FirstOrDefault();
            Assert.IsNotNull(translation);
            Assert.AreEqual("¿Cómo está usted mi amigo", translation.TranslatedText);
            Assert.AreEqual(Model.Base, translation.Model);
            Assert.AreEqual(Language.Danish, translation.DetectedSourceLanguage);
        }

        [Test]
        public void TranslateWhenModelIsNmtTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Source = Language.English,
                Target = Language.Danish,
                Model = Model.Nmt,
                Qs = new[] { "Hello World" }
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
            Assert.AreEqual(Model.Nmt, translation.Model);
            Assert.IsNull(translation.DetectedSourceLanguage);
        }

        [Test]
        public void TranslateWhenModelIsNmtReversedTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Source = Language.German,
                Target = Language.English,
                Model = Model.Nmt,
                Qs = new[] { "Hallo, mein Freund" }
            };

            var result = GoogleTranslate.Translate.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var translations = result.Data.Translations?.ToArray();
            Assert.IsNotNull(translations);
            Assert.IsNotEmpty(translations);

            var translation = translations.FirstOrDefault();
            Assert.IsNotNull(translation);
            Assert.AreEqual("Hello my friend", translation.TranslatedText);
            Assert.AreEqual(Model.Nmt, translation.Model);
            Assert.IsNull(translation.DetectedSourceLanguage);
        }

        [Test]
        public void TranslateWhenModelIsNmtAndDetectedSourceLanguageTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Target = Language.German,
                Model = Model.Nmt,
                Qs = new[] { "Hello my friend" }
            };

            var result = GoogleTranslate.Translate.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var translations = result.Data.Translations?.ToArray();
            Assert.IsNotNull(translations);
            Assert.IsNotEmpty(translations);

            var translation = translations.FirstOrDefault();
            Assert.IsNotNull(translation);
            Assert.AreEqual("Hallo, mein Freund", translation.TranslatedText);
            Assert.AreEqual(Model.Nmt, translation.Model);
            Assert.AreEqual(Language.English, translation.DetectedSourceLanguage);
        }

        [Test]
        public void TranslateWhenModelIsNmtAndSourceIsNotValidNmtTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Source = Language.Amharic,
                Target = Language.English,
                Model = Model.Nmt,
                Qs = new[] { "Hej Verden" }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Translate.Query(request));
            Assert.AreEqual(exception.Message, "Source is not compatible with model 'nmt'");
        }

        [Test]
        public void TranslateWhenModelIsNmtAndTargetIsNotValidNmtTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Source = Language.English,
                Target = Language.Amharic,
                Model = Model.Nmt,
                Qs = new[] { "Hej Verden" }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Translate.Query(request));
            Assert.AreEqual(exception.Message, "Target is not compatible with model 'nmt'");
        }

        [Test]
        public void TranslateWhenModelIsNmtAndSourceOrTargetIsNotEnglishTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Source = Language.Danish,
                Target = Language.Danish,
                Model = Model.Nmt,
                Qs = new[] { "Hej Verden" }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Translate.Query(request));
            Assert.AreEqual(exception.Message, "Source or Target must be english");
        }

        [Test]
        public void TranslateWhenMultipleQsTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Target = Language.Danish,
                Qs = new[] { "Hello World", "Once upon a time" }
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
            Assert.AreEqual(Language.English, translation1.DetectedSourceLanguage);

            var translation2 = translations[1];
            Assert.IsNotNull(translation2);
            Assert.AreEqual("Der var engang", translation2.TranslatedText);
            Assert.AreEqual(Language.English, translation2.DetectedSourceLanguage);
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
        public void TranslateWhenQsIsNullTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Target = Language.Danish,
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
                Target = Language.Danish,
                Qs = new string[0]
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Translate.Query(request));
            Assert.AreEqual(exception.Message, "Qs is required");
        }          
    }
}