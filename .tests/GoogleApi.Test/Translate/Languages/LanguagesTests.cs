using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Translate.Languages.Request;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using Language = GoogleApi.Entities.Translate.Common.Enums.Language;

namespace GoogleApi.Test.Translate.Languages
{
    [TestFixture]
    public class LanguagesTests : BaseTest<GoogleTranslate.LanguagesApi>
    {
        protected override GoogleTranslate.LanguagesApi GetClient() => new(_httpClient);
        protected override GoogleTranslate.LanguagesApi GetClientStatic() => GoogleTranslate.Languages;

        [Test]
        public void LanguagesTest()
        {
            var request = new LanguagesRequest
            {
                Key = this.ApiKey
            };

            var result = Sut.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var languages = result.Data.Languages;
            Assert.IsNotNull(languages);
            Assert.AreEqual(111, languages.Count());
        }

        [Test]
        public void LanguagesWhenTargetTest()
        {
            var request = new LanguagesRequest
            {
                Key = this.ApiKey,
                Target = Language.English
            };

            var result = Sut.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var languages = result.Data.Languages;
            Assert.IsNotNull(languages);
            Assert.AreEqual(111, languages.Count());
        }

        [Test]
        public void LanguagesWhenAsyncTest()
        {
            var request = new LanguagesRequest
            {
                Key = this.ApiKey,
                Target = Language.English
            };

            var result = Sut.QueryAsync(request).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
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
            var task = Sut.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual("The operation was canceled.", exception.Message);
        }
    }
}