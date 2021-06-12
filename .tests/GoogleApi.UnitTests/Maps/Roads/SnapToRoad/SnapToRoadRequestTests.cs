using System;
using GoogleApi.Entities.Maps.Roads.Common;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Roads.SnapToRoad
{
    [TestFixture]
    public class SnapToRoadRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new SnapToRoadsRequest();

            Assert.IsFalse(request.Interpolate);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = "abc",
                Path = new[]
                {
                    new Coordinate(1, 1),
                    new Coordinate(2, 2)
                }
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = null,
                Path = new[] { new Coordinate(0, 0) }
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
                Path = new[] { new Coordinate(0, 0) }
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
                Key = "abc"
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
                Key = "abc",
                Path = new Coordinate[0]
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
        public void GetQueryStringParametersWhenPathCotaninsMoreThanHundredLocationsTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = "abc",
                Path = new Coordinate[101]
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
        public void GetUriTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = "abc",
                Path = new[]
                {
                    new Coordinate(1, 1),
                    new Coordinate(2, 2)
                }
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/v1/snapToRoads?key={request.Key}&path={Uri.EscapeDataString(string.Join("|", request.Path))}&interpolate={request.Interpolate.ToString().ToLower()}", uri.PathAndQuery);
        }
    }
}