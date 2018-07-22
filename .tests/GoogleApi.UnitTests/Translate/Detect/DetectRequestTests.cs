using System;
using System.Linq;
using GoogleApi.Entities.Translate.Detect.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Translate.Detect
{
    [TestFixture]
    public class DetectRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new DetectRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.IsNull(request.Qs);
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new DetectRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new DetectRequest
            {
                Key = "abc",
                Qs = new[]
                {
                    "abc"
                }
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
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
                var parameters = request.GetQueryStringParameters();
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
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenQsIsNullTest()
        {
            var request = new DetectRequest
            {
                Key = "abc",
                Qs = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Qs is required");
        }

        [Test]
        public void GetQueryStringParametersWhenQsIsEmptyTest()
        {
            var request = new DetectRequest
            {
                Key = "abc",
                Qs = new string[0]
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Qs is required");
        }

        [Test]
        public void GetUriTest()
        {
            var request = new DetectRequest
            {
                Key = "abc",
                Qs = new[]
                {
                    "abc",
                    "def"
                }
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/language/translate/v2/detect?key={request.Key}&q={request.Qs.First()}&q={request.Qs.Last()}", uri.PathAndQuery);
        }
    }
}