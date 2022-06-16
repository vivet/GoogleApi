using System;
using GoogleApi.Entities.Search.Common.Enums;
using GoogleApi.Entities.Search.Common.Enums.Extensions;
using GoogleApi.Entities.Search.Image.Request;
using NUnit.Framework;
using Language = GoogleApi.Entities.Search.Common.Enums.Language;

namespace GoogleApi.UnitTests.Search.Image
{
    [TestFixture]
    public class ImageSearchRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new ImageSearchRequest();

            Assert.IsTrue(request.PrettyPrint);
            Assert.AreEqual(request.Alt, AltType.Json);

            Assert.IsNotNull(request.ImageOptions);
            Assert.IsNull(request.ImageOptions.ImageSize);
            Assert.IsNull(request.ImageOptions.ImageType);
            Assert.IsNull(request.ImageOptions.ImageColorType);
            Assert.IsNull(request.ImageOptions.ImageDominantColor);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new ImageSearchRequest
            {
                Key = "abc",
                SearchEngineId = "abc",
                Query = "abc"
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
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
            Assert.IsNotNull(exception);
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
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenQueryIsNullTest()
        {
            var request = new ImageSearchRequest
            {
                Key = "abc",
                Query = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Query is required");
        }

        [Test]
        public void GetQueryStringParametersWhenQueryIsStringEmptyTest()
        {
            var request = new ImageSearchRequest
            {
                Key = "abc",
                Query = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Query is required");
        }

        [Test]
        public void GetQueryStringParametersWhenSearchEngineIdIsNullTest()
        {
            var request = new ImageSearchRequest
            {
                Key = "abc",
                Query = "google",
                SearchEngineId = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "SearchEngineId is required");
        }

        [Test]
        public void GetQueryStringParametersWhenSearchEngineIdIsStringEmptyTest()
        {
            var request = new ImageSearchRequest
            {
                Key = "abc",
                Query = "google",
                SearchEngineId = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "SearchEngineId is required");
        }

        [Test]
        public void GetQueryStringParametersWhenOptionsNumberIsLessThanOneTest()
        {
            var request = new ImageSearchRequest
            {
                Key = "abc",
                Query = "google",
                SearchEngineId = "abc",
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
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Number must be between 1 and 10");
        }

        [Test]
        public void GetQueryStringParametersWhenOptionsNumberIsGreaterThanNineTest()
        {
            var request = new ImageSearchRequest
            {
                Key = "abc",
                Query = "google",
                SearchEngineId = "abc",
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
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Number must be between 1 and 10");
        }

        [Test]
        public void GetQueryStringParametersWhenSafetyLevelInterfaceLanguageIsNotSupportedTest()
        {
            var request = new ImageSearchRequest
            {
                Key = "abc",
                Query = "google",
                SearchEngineId = "abc",
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
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, $"SafetyLevel is not allowed for specified InterfaceLanguage: {request.Options.InterfaceLanguage}");
        }

        [Test]
        public void GetUriTest()
        {
            var request = new ImageSearchRequest
            {
                Key = "abc",
                SearchEngineId = "abc",
                Query = "abc"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/customsearch/v1?key={request.Key}&q={request.Query}&alt={request.Alt.ToString().ToLower()}&prettyPrint={request.PrettyPrint.ToString().ToLower()}&cx={request.SearchEngineId}&c2coff=1&fileType={string.Join(",", request.Options.FileTypes)}&filter=0&hl={request.Options.InterfaceLanguage.ToHl()}&num={request.Options.Number}&rights={string.Join(",", request.Options.Rights)}&safe={request.Options.SafetyLevel.ToString().ToLower()}&start={request.Options.StartIndex.ToString()}&searchType=image", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenImageTypeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void GetUriWhenImageSizeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void GetUriWhenImageColorTypeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void GetUriWhenImageDominantColorTest()
        {
            Assert.Inconclusive();
        }
    }
}