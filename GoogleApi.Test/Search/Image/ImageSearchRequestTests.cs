using System;
using GoogleApi.Entities.Search.Common.Enums;
using GoogleApi.Entities.Search.Image.Request;
using NUnit.Framework;
using Language = GoogleApi.Entities.Search.Common.Enums.Language;

namespace GoogleApi.Test.Search.Image
{
    [TestFixture]
    public class ImageSearchRequestTests : BaseTest
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new ImageSearchRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.IsTrue(request.PrettyPrint);
            Assert.AreEqual(request.Alt, AltType.Json);

            Assert.IsNotNull(request.ImageOptions);
            Assert.IsNull(request.ImageOptions.ImageSize);
            Assert.IsNull(request.ImageOptions.ImageType);
            Assert.IsNull(request.ImageOptions.ImageColorType);
            Assert.IsNull(request.ImageOptions.ImageDominantColor);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new ImageSearchRequest
            {
                Key = null
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
            var request = new ImageSearchRequest
            {
                Key = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenQueryIsNullTest()
        {
            var request = new ImageSearchRequest
            {
                Key = this.ApiKey,
                Query = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Query is required");
        }

        [Test]
        public void GetQueryStringParametersWhenQueryIsStringEmptyTest()
        {
            var request = new ImageSearchRequest
            {
                Key = this.ApiKey,
                Query = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Query is required");
        }

        [Test]
        public void GetQueryStringParametersWhenSearchEngineIdIsNullTest()
        {
            var request = new ImageSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                SearchEngineId = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "SearchEngineId is required");
        }

        [Test]
        public void GetQueryStringParametersWhenSearchEngineIdIsStringEmptyTest()
        {
            var request = new ImageSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                SearchEngineId = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "SearchEngineId is required");
        }

        [Test]
        public void GetQueryStringParametersWhenOptionsNumberIsLessThanOneTest()
        {
            var request = new ImageSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                SearchEngineId = this.SearchEngineId,
                Options =
                {
                    Number = 0
                }
            };

            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Number must be between 1 and 10");
        }

        [Test]
        public void GetQueryStringParametersWhenOptionsNumberIsGreaterThanNineTest()
        {
            var request = new ImageSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                SearchEngineId = this.SearchEngineId,
                Options =
                {
                    Number = 11
                }
            };

            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Number must be between 1 and 10");
        }

        [Test]
        public void GetQueryStringParametersWhenSafetyLevelInterfaceLanguageIsNotSupportedTest()
        {
            var request = new ImageSearchRequest
            {
                Key = this.ApiKey,
                Query = "google",
                SearchEngineId = this.SearchEngineId,
                Options =
                {
                    SafetyLevel = SafetyLevel.Medium,
                    InterfaceLanguage = Language.Afrikaans
                }
            };

            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, $"SafetyLevel is not allowed for specified InterfaceLanguage: {request.Options.InterfaceLanguage}");
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new ImageSearchRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }
    }
}