using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Roads.Common.Enums;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Roads.SpeedLimits
{
    [TestFixture]
    public class SpeedLimitsRequestTests : BaseTest
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new SpeedLimitsRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.AreEqual(Units.Kph, request.Unit);
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
                Key = this.ApiKey
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
                Key = this.ApiKey,
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
                Key = this.ApiKey,
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
    }
}