using System;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Maps.Geocoding.Place.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Geocoding.Place
{
    [TestFixture]
    public class GeocodingPlaceRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new PlaceGeocodeRequest();
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new PlaceGeocodeRequest
            {
                Key = "abc",
                PlaceId= "abc"
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new PlaceGeocodeRequest
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
        public void GetQueryStringParametersWhenPlaceIdIsNullTest()
        {
            var request = new PlaceGeocodeRequest
            {
                Key = "abc"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "PlaceId is required");
        }

        [Test]
        public void GetUriTest()
        {
            var request = new PlaceGeocodeRequest
            {
                Key = "abc",
                PlaceId = "abc"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/geocode/json?key={request.Key}&language={request.Language.ToCode()}&place_id={Uri.EscapeDataString(request.PlaceId)}", uri.PathAndQuery);
        }
    }
}