using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Roads.NearestRoads
{
    [TestFixture]
    public class NearestRoadsRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new NearestRoadsRequest();
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = "abc",
                Points = new[]
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
            var request = new NearestRoadsRequest
            {
                Key = null,
                Points = new[] { new Location(0, 0) }
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
            var request = new NearestRoadsRequest
            {
                Key = string.Empty,
                Points = new[] { new Location(0, 0) }
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
        public void GetQueryStringParametersWhenPointsIsNullTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = "abc"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
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
                Key = "abc",
                Points = new Location[0]
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Points is required");
        }

        [Test]
        public void GetQueryStringParametersWhenPathCotaninsMoreThanHundredLocationsTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = "abc",
                Points = new Location[101]
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
            var request = new NearestRoadsRequest
            {
                Key = "abc",
                Points = new[]
                {
                    new Location(1, 1),
                    new Location(2, 2) 
                }
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/v1/nearestRoads?key={request.Key}&points={Uri.EscapeDataString(string.Join("|", request.Points))}", uri.PathAndQuery);
        }
    }
}