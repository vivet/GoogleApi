using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Translate.Detect.Request;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;
using Language = GoogleApi.Entities.Translate.Common.Enums.Language;

namespace GoogleApi.Test.Translate.Detect
{
    [TestFixture]
    public class DetectTests : BaseTest<GoogleTranslate.DetectApi>
    {
        protected override GoogleTranslate.DetectApi GetClient() => new(_httpClient);
        protected override GoogleTranslate.DetectApi GetClientStatic() => GoogleTranslate.Detect;

        [Test]
        public void DetectTest()
        {
            var request = new DetectRequest
            {
                Key = this.ApiKey,
                Qs = new[] { "Hello World" }
            };

            var result = Sut.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var detections = result.Data.Detections?.ToArray();
            Assert.IsNotNull(detections);
            Assert.IsNotEmpty(detections);

            var detection = detections.FirstOrDefault();
            Assert.IsNotNull(detection);
            Assert.AreEqual(Language.English, detection[0].Language);

            Console.WriteLine(result.ToJson());
        }

        [Test]
        public void DetectWhenMultipleQsTest()
        {
            var request = new DetectRequest
            {
                Key = this.ApiKey,
                Qs = new[] { "Hello World", "Der var engang" }
            };

            var result = Sut.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var detections = result.Data.Detections.ToArray();
            Assert.IsNotNull(detections);
            Assert.IsNotEmpty(detections);
            Assert.AreEqual(2, detections.Length);

            var detection1 = detections[0];
            Assert.IsNotNull(detection1);
            Assert.AreEqual(Language.English, detection1[0].Language);

            var detection2 = detections[1];
            Assert.IsNotNull(detection2);
            Assert.AreEqual(Language.Danish, detection2[0].Language);
        }

        [Test]
        public void DetectWhenAsyncTest()
        {
            var request = new DetectRequest
            {
                Key = this.ApiKey,
                Qs = new[] { "Hello World" }
            };

            var result = Sut.QueryAsync(request).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DetectWhenAsyncAndCancelledTest()
        {
            var request = new DetectRequest
            {
                Key = this.ApiKey,
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