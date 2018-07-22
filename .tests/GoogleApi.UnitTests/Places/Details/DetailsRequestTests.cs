using System;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Details.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Places.Details
{
    [TestFixture]
    public class DetailsRequestTests
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
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new PlacesDetailsRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = "abc",
                PlaceId = "test"
            };
            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
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
                Key = "abc",
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
                Key = "abc",
                PlaceId = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "PlaceId is required");
        }

        [Test]
        public void GetUriTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = "abc",
                PlaceId = "abc"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/details/json?key={request.Key}&placeid={request.PlaceId}&language={request.Language.ToCode()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenExtensionsTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = "abc",
                PlaceId = "abc",
                Extensions = Extensions.ReviewSummary
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/details/json?key={request.Key}&placeid={request.PlaceId}&language={request.Language.ToCode()}&extensions={request.Extensions.ToString().ToLower()}", uri.PathAndQuery);
        }
    }
}