using System;
using System.Linq;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Translate.Detect.Request;
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

            var exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Detect.Query(request));
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void DetectWhenKeyIsStringEmptyTest()
        {
            var request = new DetectRequest
            {
                Key = string.Empty,
                Qs = new[] { "Hej Verden" }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Detect.Query(request));
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void DetectWhenQsIsNullTest()
        {
            var request = new DetectRequest
            {
                Key = this.ApiKey,
                Qs = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Detect.Query(request));
            Assert.AreEqual(exception.Message, "Qs is required");
        }

        [Test]
        public void DetectWhenQsIsEmptyTest()
        {
            var request = new DetectRequest
            {
                Key = this.ApiKey,
                Qs = new string[0]
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleTranslate.Detect.Query(request));
            Assert.AreEqual(exception.Message, "Qs is required");
        }
    }
}