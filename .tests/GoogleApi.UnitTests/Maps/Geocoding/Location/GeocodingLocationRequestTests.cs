using System;
using System.Linq;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Maps.Geocoding.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Location.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Geocoding.Location
{
    [TestFixture]
    public class GeocodingLocationRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new LocationGeocodeRequest();

            Assert.IsTrue(request.IsSsl);
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new LocationGeocodeRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = "abc",
                Location = new Entities.Common.Location(1, 1)
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
        }

        [Test]
        public void GetQueryStringParametersWhenLocationIsNullTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = "abc"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Location is required");
        }

        [Test]
        public void GetUriTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = "abc",
                Location = new Entities.Common.Location(1, 1)
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/geocode/json?key={request.Key}&language={request.Language.ToCode()}&latlng={Uri.EscapeDataString(request.Location.ToString())}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenResultTypeTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = "abc",
                Location = new Entities.Common.Location(1, 1),
                ResultTypes = new[]
                {
                    PlaceLocationType.Accounting,
                    PlaceLocationType.Administrative_Area_Level_1 
                }
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/geocode/json?key={request.Key}&language={request.Language.ToCode()}&latlng={Uri.EscapeDataString(request.Location.ToString())}&result_type={Uri.EscapeDataString(string.Join("|", request.ResultTypes.Select(x => x.ToString().ToLower()).AsEnumerable()))}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenLocationTypeTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = "abc",
                Location = new Entities.Common.Location(1, 1),
                LocationTypes = new[]
                {
                    GeometryLocationType.Rooftop
                }
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/geocode/json?key={request.Key}&language={request.Language.ToCode()}&latlng={Uri.EscapeDataString(request.Location.ToString())}&location_type={Uri.EscapeDataString(string.Join("|", request.LocationTypes.Select(x => x.ToString().ToUpper()).AsEnumerable()))}", uri.PathAndQuery);
        }
    }
}