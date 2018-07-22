using System;
using System.Linq;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Common.Enums.Extensions;
using GoogleApi.Entities.Translate.Translate.Request;
using GoogleApi.Entities.Translate.Translate.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Translate.Translate
{
    [TestFixture]
    public class TranslateRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new TranslateRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.IsNull(request.Source);
            Assert.IsNull(request.Target);
            Assert.AreEqual(Model.Base, request.Model);
            Assert.AreEqual(Format.Html, request.Format);
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new TranslateRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new TranslateRequest
            {
                Key = "abc",
                Target = Language.Afrikaans,
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
            var request = new TranslateRequest
            {
                Key = null,
                Qs = new[] { "Hej Verden" },
                Target = Language.Afrikaans
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
            var request = new TranslateRequest
            {
                Key = string.Empty,
                Qs = new[] { "Hej Verden" },
                Target = Language.Afrikaans
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenTargetIsNullTest()
        {
            var request = new TranslateRequest
            {
                Key = "abc",
                Target = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Target is required");
        }

        [Test]
        public void GetQueryStringParametersWhenQsIsNullTest()
        {
            var request = new TranslateRequest
            {
                Key = "abc",
                Target = Language.Danish,
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
            var request = new TranslateRequest
            {
                Key = "abc",
                Target = Language.Danish,
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
            var request = new TranslateRequest
            {
                Key = "abc",
                Target = Language.Afrikaans,
                Qs = new[]
                {
                    "abc",
                    "def"
                }
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/language/translate/v2?key={request.Key}&target={request.Target.GetValueOrDefault().ToCode()}&model={request.Model.ToString().ToLower()}&format={request.Format.ToString().ToLower()}&q={request.Qs.First()}&q={request.Qs.Last()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenSourceTest()
        {
            var request = new TranslateRequest
            {
                Key = "abc",
                Target = Language.Afrikaans,
                Qs = new[]
                {
                    "abc",
                    "def"
                },
                Source = Language.Albanian
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/language/translate/v2?key={request.Key}&target={request.Target.GetValueOrDefault().ToCode()}&model={request.Model.ToString().ToLower()}&format={request.Format.ToString().ToLower()}&source={request.Source.GetValueOrDefault().ToCode()}&q={request.Qs.First()}&q={request.Qs.Last()}", uri.PathAndQuery);
        }
    }
}