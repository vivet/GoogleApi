using System;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Common.Enums.Extensions;
using GoogleApi.Entities.Translate.Languages.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Translate.Languages
{
    [TestFixture]
    public class LanguagesRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new LanguagesRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.IsNull(request.Target);
            Assert.AreEqual(Model.Base, request.Model);
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new LanguagesRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new LanguagesRequest
            {
                Key = "abc",
                Target = Language.Afrikaans
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new LanguagesRequest
            {
                Key = null,
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
            var request = new LanguagesRequest
            {
                Key = string.Empty,
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
            var request = new LanguagesRequest
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
        public void GetUriTest()
        {
            var request = new LanguagesRequest
            {
                Key = "abc",
                Target = Language.Afrikaans
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/language/translate/v2/languages?key={request.Key}&target={request.Target.GetValueOrDefault().ToCode()}&model={request.Model.ToString().ToLower()}", uri.PathAndQuery);
        }
    }
}