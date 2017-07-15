using System;
using GoogleApi.Entities.Places.Delete.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Delete
{
    [TestFixture]
    public class DeleteRequestTests : BaseTest
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new PlacesDeleteRequest();

            Assert.IsTrue(request.IsSsl);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new PlacesDeleteRequest
            {
                Key = null,
                PlaceId = "test"
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
            var request = new PlacesDeleteRequest
            {
                Key = string.Empty,
                PlaceId = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenPlaceIdIsNullTest()
        {
            var request = new PlacesDeleteRequest
            {
                Key = this.ApiKey,
                PlaceId = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "PlaceId is required");
        }

        [Test]
        public void GetQueryStringParametersWhenPlaceIdIsStringEmptyTest()
        {
            var request = new PlacesDeleteRequest
            {
                Key = this.ApiKey,
                PlaceId = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "PlaceId is required");
        }
    }
}