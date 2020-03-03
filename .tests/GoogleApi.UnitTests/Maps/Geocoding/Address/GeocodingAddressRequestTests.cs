using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Maps.Geocoding.Address.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Geocoding.Address
{
    [TestFixture]
    public class GeocodingAddressRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new AddressGeocodeRequest();

            Assert.IsTrue(request.IsSsl);
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new AddressGeocodeRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new AddressGeocodeRequest
            {
                Key = "abc",
                Address = "abc"
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
        }

        [Test]
        public void GetQueryStringParametersWhenAddressIsNullTest()
        {
            var request = new AddressGeocodeRequest
            {
                Key = "abc"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Address or Components is required");
        }

        [Test]
        public void GetUriTest()
        {
            var request = new AddressGeocodeRequest
            {
                Key = "abc",
                Address = "abc"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/geocode/json?key={request.Key}&language={request.Language.ToCode()}&address={Uri.EscapeDataString(request.Address)}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenRegionTest()
        {
            var request = new AddressGeocodeRequest
            {
                Key = "abc",
                Address = "abc",
                Region = "abc"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/geocode/json?key={request.Key}&language={request.Language.ToCode()}&address={Uri.EscapeDataString(request.Address)}&region={request.Region}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenBoundsTest()
        {
            var request = new AddressGeocodeRequest
            {
                Key = "abc",
                Address = "abc",
                Bounds = new ViewPort
                {
                    SouthWest = new Entities.Common.Location(1, 1),
                    NorthEast = new Entities.Common.Location(1, 1)
                }
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/geocode/json?key={request.Key}&language={request.Language.ToCode()}&address={Uri.EscapeDataString(request.Address)}&bounds={Uri.EscapeDataString(request.Bounds.NorthEast.ToString())}{Uri.EscapeDataString("|")}{Uri.EscapeDataString(request.Bounds.SouthWest.ToString())}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenComponentsTest()
        {
            var request = new AddressGeocodeRequest
            {
                Key = "abc",
                Components = new []
                {
                    new KeyValuePair<Component, string>(Component.Administrative_Area, "abc"),
                    new KeyValuePair<Component, string>(Component.Locality, "def")
                }
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/geocode/json?key={request.Key}&language={request.Language.ToCode()}&components={Uri.EscapeDataString(string.Join("|", request.Components.Select(x => $"{x.Key.ToString().ToLower()}:{x.Value}")))}", uri.PathAndQuery);
        }
    }
}