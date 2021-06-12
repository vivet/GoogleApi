using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Elevation.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Elevation
{
    [TestFixture]
    public class ElevationRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new ElevationRequest();
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new ElevationRequest
            {
                Path = new[] { new Location(40.7141289, -73.9614074) },
                Samples = 2
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
        }

        [Test]
        public void GetQueryStringParametersWhenPathAndSamplesIsNullTest()
        {
            var request = new ElevationRequest
            {
                Path = new[] { new Location(40.7141289, -73.9614074) },
                Samples = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Samples is required, when using Path");
        }

        [Test]
        public void GetQueryStringParametersWhenPathAndLocationTest()
        {
            var request = new ElevationRequest
            {
                Path = new[] { new Location(40.7141289, -73.9614074) },
                Locations = new[] { new Location(40.7141289, -73.9614074) }
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Path and Locations cannot both be specified");
        }

        [Test]
        public void GetQueryStringParametersWhenPathAndLocationIsNullTest()
        {
            var request = new ElevationRequest();

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Locations or Path is required");
        }

        [Test]
        public void GetUriWhenLocationsTest()
        {
            var request = new ElevationRequest
            {
                Key = "abc",
                Locations = new[] { new Location(40.7141289, -73.9614074) }
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/elevation/json?key={request.Key}&locations={Uri.EscapeDataString(string.Join("|", request.Locations))}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenWhenPathAndSamplesTest()
        {
            var request = new ElevationRequest
            {
                Key = "abc",
                Path = new[] { new Location(40.7141289, -73.9614074) },
                Samples = 2
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/elevation/json?key={request.Key}&path={Uri.EscapeDataString(string.Join("|", request.Path))}&samples={request.Samples.ToString()}", uri.PathAndQuery);
        }
    }
}