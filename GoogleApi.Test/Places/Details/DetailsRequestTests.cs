using System;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Details.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Details
{
    [TestFixture]
    public class DetailsRequestTests : BaseTest
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new PlacesDetailsRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.AreEqual(Language.English, request.Language);
            Assert.AreEqual(Extensions.None, request.Extensions);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = null,
                PlaceId = "test"
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
            var request = new PlacesDetailsRequest
            {
                Key = string.Empty,
                PlaceId = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenPlaceIdIsNullTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "PlaceId is required");
        }

        [Test]
        public void GetQueryStringParametersWhenPlaceIdIsStringEmptyTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "PlaceId is required");
        }
    }
}