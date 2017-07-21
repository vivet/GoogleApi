using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Search.Radar.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Search.Radar
{
    [TestFixture]
    public class RadarSearchRequestTests : BaseTest
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new PlacesRadarSearchRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.IsNull(request.Type);
            Assert.IsNull(request.Radius);
            Assert.IsNull(request.Location);
            Assert.IsNull(request.Minprice);
            Assert.IsNull(request.Maxprice);
            Assert.IsFalse(request.OpenNow);
            Assert.AreEqual(Language.English, request.Language);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = null,
                Location = new Location(0, 0),
                Radius = 10,
                Keyword = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = string.Empty,
                Location = new Location(0, 0),
                Radius = 10,
                Keyword = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenLocationIsNullTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Location is required");
        }

        [Test]
        public void GetQueryStringParametersWhenRadiusIsNullTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(0, 0),
                Radius = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Radius is required");
        }

        [Test]
        public void GetQueryStringParametersWhenRadiusIsLessThanOneTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 0
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000");
        }

        [Test]
        public void GetQueryStringParametersWhenRadiusIsGereaterThanFiftyThousandTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 50001
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000");
        }

        [Test]
        public void GetQueryStringParametersWhenRankByDistanceAndNameIsNullAndKeywordIsNullAndTypeIsNullTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 1
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Keyword, Name or Type is required");
        }
    }
}