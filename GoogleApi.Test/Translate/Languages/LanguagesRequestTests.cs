using System;
using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Languages.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Translate.Languages
{
    [TestFixture]
    public class LanguagesRequestTests : BaseTest
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
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new LanguagesRequest
            {
                Key = null,
                Target = Language.Afrikaans
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
            var request = new LanguagesRequest
            {
                Key = string.Empty,
                Target = Language.Afrikaans
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenTargetIsNullTest()
        {
            var request = new LanguagesRequest
            {
                Key = this.ApiKey,
                Target = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Target is required");
        }
    }
}