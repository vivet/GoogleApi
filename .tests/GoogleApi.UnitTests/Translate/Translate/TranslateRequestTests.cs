using System;
using GoogleApi.Entities.Translate.Common.Enums;
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
    }
}