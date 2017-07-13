using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Roads.NearestRoads
{
    [TestFixture]
    public class NearestRoadsRequestTests : BaseTest
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new NearestRoadsRequest();

            Assert.IsTrue(request.IsSsl);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = null,
                Points = new[] { new Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = string.Empty,
                Points = new[] { new Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenPointsIsNullTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = this.ApiKey
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Points is required");
        }

        [Test]
        public void GetQueryStringParametersWhenPointsIsEmptyTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = this.ApiKey,
                Points = new Location[0]
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.QueryStringParameters;
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Points is required");
        }
    }
}