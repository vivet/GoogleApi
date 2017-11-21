using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Roads.SnapToRoad
{
    [TestFixture]
    public class SnapToRoadRequestTests : BaseTest
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new SnapToRoadsRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.IsFalse(request.Interpolate);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new SnapToRoadsRequest
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
            var request = new SnapToRoadsRequest
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
        public void GetQueryStringParametersWhenPathIsNullTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Path is required");
        }

        [Test]
        public void GetQueryStringParametersWhenPathIsEmptyTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey,
                Path = new Location[0]
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Path is required");
        }

        [Test]
        public void GetQueryStringParametersWhenPathCotaninsMoreThan100LocationsTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey,
                Path = new Location[101]
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Path must contain less than 100 locations");
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new SnapToRoadsRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }
    }
}