using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.NearBy.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Search.NearBy
{
    [TestFixture]
    public class NearBySearchRequestTests : BaseTest
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new PlacesNearBySearchRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.IsNull(request.Type);
            Assert.IsNull(request.Radius);
            Assert.IsNull(request.Location);
            Assert.IsNull(request.Minprice);
            Assert.IsNull(request.Maxprice);
            Assert.IsFalse(request.OpenNow);
            Assert.AreEqual(Language.English, request.Language);
            Assert.AreEqual(Ranking.Prominence, request.Rankby);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = null,
                Location = new Location(0, 0),
                Radius = 5000,
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
            var request = new PlacesNearBySearchRequest
            {
                Key = string.Empty,
                Location = new Location(0, 0),
                Radius = 5000
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
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = null,
                Radius = 5000
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
            var request = new PlacesNearBySearchRequest
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
            Assert.AreEqual(exception.Message, "Radius is required, when RankBy is not Distance");
        }

        [Test]
        public void GetQueryStringParametersWhenRadiusIsLessThanOneTest()
        {
            var request = new PlacesNearBySearchRequest
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
            var request = new PlacesNearBySearchRequest
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
        public void GetQueryStringParametersWhenRankByDistanceAndRadiusIsNotNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 5001,
                Rankby = Ranking.Distance
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Radius cannot be specified, when using RankBy distance");
        }

        [Test]
        public void GetQueryStringParametersWhenRankByDistanceAndNameIsNullAndKeywordIsNullAndTypeIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Rankby = Ranking.Distance
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Keyword, Name or Type is required, If rank by distance");
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new PlacesNearBySearchRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }
    }
}