using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Translate.Request;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using Language = GoogleApi.Entities.Translate.Common.Enums.Language;

namespace GoogleApi.Test.Translate.Translate
{
    [TestFixture]
    public class TranslateTests : BaseTest<GoogleTranslate.TranslateApi>
    {
        protected override GoogleTranslate.TranslateApi GetClient() => new(_httpClient);
        protected override GoogleTranslate.TranslateApi GetClientStatic() => GoogleTranslate.Translate;

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

            var result = Sut.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var translation1 = result.Data.Translations.FirstOrDefault();
            Assert.IsNotNull(translation1);
            Assert.AreEqual("Hej Verden", translation1.TranslatedText);
        }

        [Test]
        public void TranslateWhenMultipleQsTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Source = Language.English,
                Target = Language.Danish,
                Qs = new[] { "Hello World", "Once upon a time" }
            };

            var result = Sut.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var translations = result.Data.Translations?.ToArray();
            Assert.IsNotNull(translations);
            Assert.IsNotEmpty(translations);
            Assert.AreEqual(2, translations!.Length);

            var translation1 = translations[0];
            Assert.IsNotNull(translation1);
            Assert.AreEqual("Hej Verden", translation1.TranslatedText);

            var translation2 = translations[1];
            Assert.IsNotNull(translation2);
            Assert.AreEqual("Der var engang", translation2.TranslatedText);
        }

        [Test]
        public void TranslateWhenDetectedSourceLanguageTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Target = Language.Albanian,
                Qs = new[] { "Hej med dig min ven" }
            };

            var result = Sut.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            Assert.AreEqual(Language.Danish, result.Data.Translations.FirstOrDefault()?.DetectedSourceLanguage);
        }

        [Test]
        public void TranslateWhenModelNmtTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Source = Language.English,
                Target = Language.Danish,
                Model = Model.Nmt,
                Qs = new[] { "Hello World" }
            };

            var result = Sut.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            Assert.AreEqual(Model.Nmt, result.Data.Translations?.FirstOrDefault()?.Model);
        }

        [Test]
        public void TranslateWhenAsyncTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Source = Language.English,
                Target = Language.Danish,
                Qs = new[] { "Hello World" }
            };

            var result = Sut.QueryAsync(request).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void TranslateWhenAsyncAndCancelledTest()
        {
            var request = new TranslateRequest
            {
                Key = this.ApiKey,
                Source = Language.English,
                Target = Language.Danish,
                Qs = new[] { "Hello World" }
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var task = Sut.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual("The operation was canceled.", exception.Message);
        }
    }
}