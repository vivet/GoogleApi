using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Translate.Languages.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;
using Language = GoogleApi.Entities.Translate.Common.Enums.Language;

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
        public void LanguagesWhenAsyncTest()
        {
            var request = new LanguagesRequest
            {
                Key = this.ApiKey,
                Target = Language.English
            };

            var result = GoogleTranslate.Languages.QueryAsync(request).Result;
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
        public void LanguagesWhenAsyncAndCancelledTest()
        {
            var request = new LanguagesRequest
            {
                Key = this.ApiKey,
                Target = Language.English
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleTranslate.Languages.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void LanguagesWhenInvalidKeyTest()
        {
            var request = new LanguagesRequest
            {
                Key = "test",
                Target = Language.Danish
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleTranslate.Languages.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerExceptions.FirstOrDefault();
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException).ToString(), innerException.GetType().ToString());
            Assert.AreEqual("Response status code does not indicate success: 400 (Bad Request).", innerException.Message);
        }

        [Test]
        public void LanguagesWhenKeyIsNullTest()
        {
            var request = new LanguagesRequest
            {
                Key = null,
                Target = Language.English
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleTranslate.Languages.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void LanguagesWhenKeyIsStringEmptyTest()
        {
            var request = new LanguagesRequest
            {
                Key = string.Empty,
                Target = Language.English
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleTranslate.Languages.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void LanguagesWhenTargetIsNullTest()
        {
            var request = new LanguagesRequest
            {
                Key = this.ApiKey,
                Target = null
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleTranslate.Languages.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Target is required");
        }
    }
}