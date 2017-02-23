using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.NearBy.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Search
{
    [TestFixture]
    public class NearBySearchTests : BaseTest
    {
        [Test]
        public void PlacesNearBySearchTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Sensor = true,
                Radius = 500,
                Type = SearchPlaceType.School
            };

            var response = GooglePlaces.NearBySearch.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }
        [Test]
        public void PlacesNearBySearchAsyncTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Sensor = true,
                Radius = 500,
                Type = SearchPlaceType.School
            };

            var response = GooglePlaces.NearBySearch.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }
        [Test]
        public void PlacesNearBySearchWhenKeyIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = null,
                Location = new Location(0, 0),
                Radius = 10
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesNearBySearchWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = string.Empty,
                Location = new Location(0, 0),
                Radius = 10
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesNearBySearchWhenLocationIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Location is required.");
        }
        [Test]
        public void PlacesNearBySearchWhenRadiusIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(0, 0),
                Radius = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius is required, when RankBy is not Distance");
        }
        [Test]
        public void PlacesNearBySearchWhenRadiusIsLessThanOneTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 0
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000.");
        }
        [Test]
        public void PlacesNearBySearchWhenRadiusIsGereaterThanFiftyThousandTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 50001
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000.");
        }
        [Test]
        public void PlacesNearBySearchWhenRankByDistanceAndRadiusIsNotNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 50001,
                Rankby = Ranking.Distance
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius cannot be specified, when using RankBy distance");
        }
        [Test]
        public void PlacesNearBySearchWhenRankByDistanceAndNameIsNullAndKeywordIsNullAndTypeIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Rankby = Ranking.Distance
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Keyword or Name or Type is required, If rank by distance.");
        }

    }
}