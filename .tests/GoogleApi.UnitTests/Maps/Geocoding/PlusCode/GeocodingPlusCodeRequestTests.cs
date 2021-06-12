using System;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Geocoding.PlusCode
{
    [TestFixture]
    public class GeocodingPlusCodeRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new PlusCodeGeocodeRequest();
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = "abc",
                PlaceId = "abc"
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
        }

        [Test]
        public void GetQueryStringParametersWhenPlaceIdAndLocationAndAddressAndGlobalCodeIsNullTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = "abc"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "PlaceId, Location, Address or GlobalCode is required");
        }

        [Test]
        public void GetUriWhenPlaceIdTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = "abc",
                PlaceId = "abc"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/api?ekey={request.Key}&language={request.Language.ToCode()}&address={Uri.EscapeDataString(request.PlaceId)}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenLocationTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = "abc",
                Location = new Entities.Common.Location(1, 1)
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/api?ekey={request.Key}&language={request.Language.ToCode()}&address={Uri.EscapeDataString(request.Location.ToString())}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenAddressTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = "abc",
                Address = "abc"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/api?ekey={request.Key}&language={request.Language.ToCode()}&address={Uri.EscapeDataString(request.Address)}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenGlobalCodeTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = "abc",
                GlobalCode = "abc"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/api?ekey={request.Key}&language={request.Language.ToCode()}&address={Uri.EscapeDataString(request.GlobalCode)}", uri.PathAndQuery);
        }
    }
}