using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Search.Radar.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Search.RadarSearch
{
    [TestFixture]
    public class RadarSearchTests : BaseTest
    {
        [Test]
        public void PlacesRadarSearchTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(55.673323, 12.527438),
                Radius = 500,
                Sensor = true,
                Keyword = "abc"
            };

            var response = GooglePlaces.RadarSearch.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }
        [Test]
        public void PlacesRadarSearchAsyncTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(55.673323, 12.527438),
                Radius = 500,
                Sensor = true,
                Keyword = "abc"
            };

            var response = GooglePlaces.RadarSearch.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }
        [Test]
        public void PlacesRadarSearchWhenKeyIsNullTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = null,
                Location = new Location(0, 0),
                Radius = 10,
                Keyword = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesRadarSearchWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = string.Empty,
                Location = new Location(0, 0),
                Radius = 10,
                Keyword = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesRadarSearchWhenLocationIsNullTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Location is required.");
        }
        [Test]
        public void PlacesRadarSearchWhenRadiusIsNullTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(0, 0),
                Radius = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius is required.");
        }
        [Test]
        public void PlacesRadarSearchWhenRadiusIsLessThanOneTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 0
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000.");
        }
        [Test]
        public void PlacesRadarSearchWhenRadiusIsGereaterThanFiftyThousandTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 50001
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000.");
        }
        [Test]
        public void PlacesRadarSearchWhenRankByDistanceAndNameIsNullAndKeywordIsNullAndTypeIsNullTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 1
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Keyword or Name or Type must is required.");
        }

    }
}