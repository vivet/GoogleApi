using System;
using GoogleApi.Entities.Translate.Detect.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Translate.Detect
{
    [TestFixture]
    public class DetectRequestTests : BaseTest
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new DetectRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.IsNull(request.Qs);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new DetectRequest
            {
                Key = null,
                Qs = new[] { "Hej Verden" }
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
        {
            var request = new DetectRequest
            {
                Key = string.Empty,
                Qs = new[] { "Hej Verden" }
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenQsIsNullTest()
        {
            var request = new DetectRequest
            {
                Key = this.ApiKey,
                Qs = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Qs is required");
        }

        [Test]
        public void GetQueryStringParametersWhenQsIsEmptyTest()
        {
            var request = new DetectRequest
            {
                Key = this.ApiKey,
                Qs = new string[0]
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Qs is required");
        }
    }
}