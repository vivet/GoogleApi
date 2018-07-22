using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Roads.Common.Enums;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Roads.SpeedLimits
{
    [TestFixture]
    public class SpeedLimitsRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new SpeedLimitsRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.AreEqual(Units.Kph, request.Unit);
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new SpeedLimitsRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = "abc",
                Path = new[]
                {
                    new Location(1, 1),
                    new Location(2, 2)
                }
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = null,
                Path = new[] { new Location(0, 0) }
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
        public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = string.Empty,
                Path = new[] { new Location(0, 0) }
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
        public void GetQueryStringParametersWhenPathIsNullAndPlaceIdsIsNullTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = "abc"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Path or PlaceId's is required");
        }

        [Test]
        public void GetQueryStringParametersWhenPathIsEmptyAndPlaceIdsIsEmptyTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = "abc",
                Path = new Location[0],
                PlaceIds = new string[0]
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Path or PlaceId's is required");
        }

        [Test]
        public void GetQueryStringParametersWhenPlaceIdsCountIsGreaterThanAllowedTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = "abc",
                PlaceIds = new string[101]
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Max PlaceId's exceeded");
        }

        [Test]
        public void GetUriTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = "abc",
                Path = new[]
                {
                    new Location(1, 1),
                    new Location(2, 2)
                }
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/v1/speedLimits?key={request.Key}&path={Uri.EscapeDataString(string.Join("|", request.Path))}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenPlaceIdsTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = "abc",
                PlaceIds = new[]
                {
                    "abc",
                    "def"
                }
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/v1/speedLimits?key={request.Key}&placeId={Uri.EscapeDataString(request.PlaceIds.First())}&placeId={Uri.EscapeDataString(request.PlaceIds.Last())}", uri.PathAndQuery);
        }
    }
}