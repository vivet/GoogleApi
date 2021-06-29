using System;
using System.Linq;
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
            Assert.AreEqual(Model.Base, request.Model);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new LanguagesRequest
            {
                Key = "key",
                Target = Language.Afrikaans
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var key = queryStringParameters.FirstOrDefault(x => x.Key == "key");
            var keyExpected = request.Key;
            Assert.IsNotNull(key);
            Assert.AreEqual(keyExpected, key.Value);

            var target = queryStringParameters.FirstOrDefault(x => x.Key == "target");
            var targetExpected = request.Target.GetValueOrDefault().ToCode();
            Assert.IsNotNull(target);
            Assert.AreEqual(targetExpected, target.Value);

            var model = queryStringParameters.FirstOrDefault(x => x.Key == "model");
            var modelExpected = request.Model.ToString().ToLower();
            Assert.IsNotNull(model);
            Assert.AreEqual(modelExpected, model.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new LanguagesRequest
            {
                Key = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "'Key' is required");
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
        {
            var request = new LanguagesRequest
            {
                Key = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "'Key' is required");
        }

        [Test]
        public void GetQueryStringParametersWhenTargetIsNullTest()
        {
            var request = new LanguagesRequest
            {
                Key = "key",
                Target = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "'Target' is required");
        }
    }
}