#if NETCOREAPP3_1_OR_GREATER
using AutoFixture;
using AutoFixture.AutoNSubstitute;
#else
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
#endif
using FluentAssertions;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Translate.Detect.Request;
using GoogleApi.Entities.Translate.Detect.Response;
using NUnit.Framework;
using RichardSzalay.MockHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using Language = GoogleApi.Entities.Translate.Common.Enums.Language;

namespace GoogleApi.UnitTests.Translate.Detect
{


    [TestFixture]
    public class DetectRequestTests : HttpClientTest
    {
        [SetUp]
        public void Init()
        {
            _FakeHandler = new FakeWithTraceLogRequestHandler();

#if NETCOREAPP3_1_OR_GREATER
            _fixture.Customize(new AutoNSubstituteCustomization { ConfigureMembers = true });
            _fixture.Customize<DetectRequest>(x => x
                .With(_ => _.Key, () => $"{Guid.NewGuid():N}")
                .With(_ => _.ClientId, () => $"gme-{Guid.NewGuid():N}")
                .OmitAutoProperties()
                );
#else
            _fixture.Customize<DetectRequest>(x => x
                .With(_ => _.Key, $"{Guid.NewGuid():N}")
                .With(_ => _.ClientId, $"gme-{Guid.NewGuid():N}")
                .OmitAutoProperties()
                );
#endif



        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new DetectRequest
            {
                Key = "key",
                Qs = new[]
                {
                    "qs"
                }
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var key = queryStringParameters.FirstOrDefault(x => x.Key == "key");
            var keyExpected = request.Key;
            Assert.IsNotNull(key);
            Assert.AreEqual(keyExpected, key.Value);

            var qs = queryStringParameters.FirstOrDefault(x => x.Key == "q");
            var qsExpected = request.Qs.First();
            Assert.IsNotNull(qs);
            Assert.AreEqual(qsExpected, qs.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new DetectRequest
            {
                Key = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual("'Key' is required", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
        {
            var request = new DetectRequest
            {
                Key = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual("'Key' is required", exception.Message);
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
            Assert.AreEqual("'Qs' is required", exception.Message);
        }

        [Test]
        public void DetectTest()
        {
            Actor.When("https://translation.googleapis.com/language/translate/v2/detect*")
                .Respond(ApplicationJson, new
                {
                    data = new Data
                    {
                        Detections = new List<Detection[]>
                        {
                            new [] { new Detection{ Language = Language.English } }
                        }
                    }
                }.ToJson());

            var request = _fixture.Create<DetectRequest>();
            request.Qs = new[] { "Hello World" };

            var result = new GoogleTranslate.DetectApi(_FakeHandler.ToHttpClient()).Query(request);

            Assert.IsNotNull(result);
            result.Status.Should().Be(Status.Ok);

            result.Data.Detections.Should().NotBeNullOrEmpty().And.HaveCount(1);

            var detection = result.Data.Detections.First().First();
            detection.Should().NotBeNull();
            detection.Language.Should().Be(Language.English);
        }
    }
}