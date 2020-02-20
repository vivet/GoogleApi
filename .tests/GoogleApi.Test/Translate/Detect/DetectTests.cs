using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Translate.Detect.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;
using Language = GoogleApi.Entities.Translate.Common.Enums.Language;

namespace GoogleApi.Test.Translate.Detect
{
    [TestFixture]
    public class DetectTests : BaseTest
    {
        [Test]
        public void DetectTest()
        {
            var request = new DetectRequest
            {
                Key = this.ApiKey,
                Qs = new[] { "Hello World" }
            };

            var result = GoogleTranslate.Detect.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var detections = result.Data.Detections?.ToArray();
            Assert.IsNotNull(detections);
            Assert.IsNotEmpty(detections);

            var detection = detections.FirstOrDefault();
            Assert.IsNotNull(detection);
            Assert.AreEqual(Language.English, detection[0].Language);
        }

        [Test]
        public void DetectWhenAsyncTest()
        {
            var request = new DetectRequest
            {
                Key = this.ApiKey,
                Qs = new[] { "Hello World" }
            };

            var result = GoogleTranslate.Detect.QueryAsync(request).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var detections = result.Data.Detections?.ToArray();
            Assert.IsNotNull(detections);
            Assert.IsNotEmpty(detections);

            var detection = detections.FirstOrDefault();
            Assert.IsNotNull(detection);
            Assert.AreEqual(Language.English, detection[0].Language);
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
            var task = GoogleTranslate.Detect.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void DetectWhenInvalidKeyTest()
        {
            var request = new DetectRequest
            {
                Key = "test",
                Qs = new[] { "Hello World" }
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleTranslate.Detect.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);
            
            Console.WriteLine(exception.Message);
            Assert.AreEqual("One or more errors occurred. (Response status code does not indicate success: 403 (Forbidden).)", exception.Message);

            var innerException = exception.InnerExceptions.FirstOrDefault();
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("Response status code does not indicate success: 403 (Forbidden).", innerException.Message);
        }

        [Test]
        public void DetectWhenMultipleQsTest()
        {
            var request = new DetectRequest
            {
                Key = this.ApiKey,
                Qs = new[] { "Hello World", "Der var engang" }
            };

            var result = GoogleTranslate.Detect.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var detections = result.Data.Detections?.ToArray();
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
        public void DetectWhenKeyIsNullTest()
        {
            var request = new DetectRequest
            {
                Key = null,
                Qs = new[] { "Hej Verden" }
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleTranslate.Detect.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void DetectWhenKeyIsStringEmptyTest()
        {
            var request = new DetectRequest
            {
                Key = string.Empty,
                Qs = new[] { "Hej Verden" }
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleTranslate.Detect.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void DetectWhenQsIsNullTest()
        {
            var request = new DetectRequest
            {
                Key = this.ApiKey,
                Qs = null
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleTranslate.Detect.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Qs is required");
        }

        [Test]
        public void DetectWhenQsIsEmptyTest()
        {
            var request = new DetectRequest
            {
                Key = this.ApiKey,
                Qs = new string[0]
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleTranslate.Detect.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Qs is required");
        }
    }
}