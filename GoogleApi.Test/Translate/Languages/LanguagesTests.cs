using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Languages.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Translate.Languages
{
    [TestFixture]
    public class LanguagesTests : BaseTest
    {
        [Test]
        public void LanguagesTest()
        {
            var request = new LanguagesRequest
            {
                Key = this.ApiKey,
                Target = Language.English
            };

            var result = GoogleTranslate.Languages.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var languages = result.Data.Languages;
            Assert.IsNotNull(languages);
            Assert.AreEqual(104, languages.Count());

            var language = result.Data.Languages.FirstOrDefault();
            Assert.IsNotNull(language);
            Assert.AreEqual("Afrikaans", language.Name);
            Assert.AreEqual(Language.Afrikaans, language.Language);
        }

        [Test]
        public void LanguagesWhenKeyIsNullTest()
        {
            var request = new LanguagesRequest
            {
                Key = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Languages.Query(request));
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void LanguagesWhenKeyIsStringEmptyTest()
        {
            var request = new LanguagesRequest
            {
                Key = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Languages.Query(request));
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void LanguagesWhenTargetIsNullTest()
        {
            var request = new LanguagesRequest
            {
                Key = this.ApiKey,
                Target = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Languages.Query(request));
            Assert.AreEqual(exception.Message, "Target is required");

        }
    }
}