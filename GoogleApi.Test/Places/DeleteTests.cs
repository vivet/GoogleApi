using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Add.Request;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Delete.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Places
{
    [TestFixture]
    public class DeleteTests : BaseTest
    {
        [Test]
        public void PlacesDeleteTest()
        {
            var response = GooglePlaces.Add.Query(new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = "Home",
                Types = new[] { PlaceLocationType.StreetAddress },
                Location = new Location(55.664425, 12.502264)
            });

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.PlaceId);

            var response2 = GooglePlaces.Delete.Query(new PlacesDeleteRequest
            {
                Key = this.ApiKey,
                PlaceId = response.PlaceId
            });

            Assert.IsNotNull(response2);
            Assert.AreEqual(response2.Status, Status.Ok);
        }
        [Test]
        public void PlacesDeleteAsyncTest()
        {
            var response = GooglePlaces.Add.Query(new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = "Home",
                Types = new[] { PlaceLocationType.StreetAddress },
                Location = new Location(55.664425, 12.502264)
            });

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.PlaceId);

            var response2 = GooglePlaces.Delete.QueryAsync(new PlacesDeleteRequest
            {
                Key = this.ApiKey,
                PlaceId = response.PlaceId
            }).Result;

            Assert.IsNotNull(response2);
            Assert.AreEqual(response2.Status, Status.Ok);
        }
        [Test]
        public void PlacesDeleteWhenKeyIsNullTest()
        {
            var request = new PlacesDeleteRequest
            {
                Key = null,
                PlaceId = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Delete.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesDeleteWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesDeleteRequest
            {
                Key = string.Empty,
                PlaceId = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Delete.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesDeleteWhenPlaceIdIsNullTest()
        {
            var request = new PlacesDeleteRequest
            {
                Key = this.ApiKey,
                PlaceId = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Delete.Query(request));
            Assert.AreEqual(exception.Message, "PlaceId is required.");
        }
        [Test]
        public void PlacesDeleteWhenPlaceIdIsStringEmptyTest()
        {
            var request = new PlacesDeleteRequest
            {
                Key = this.ApiKey,
                PlaceId = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Delete.Query(request));
            Assert.AreEqual(exception.Message, "PlaceId is required.");
        }

    }
}