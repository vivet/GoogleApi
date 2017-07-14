using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Add.Request;
using GoogleApi.Entities.Places.Common.Enums;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Add
{
    [TestFixture]
    public class AddTests : BaseTest
    {
        [Test]
        public void PlacesAddTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = "Home",
                Types = new[] { PlaceLocationType.StreetAddress },
                Location = new Location(55.664425, 12.502264),
                Accuracy = 50,
                PhoneNumber = "+45 00000000",
                Address = "J. P. E. Hartmanns Allé 35 2500 Valby, Denmark",
                Website = "http://www.google.com",
                Language = "en-US"
            };
            var response = GooglePlaces.Add.Query(request);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.PlaceId);
            Assert.AreEqual(response.Scope, Scope.App);
            Assert.AreEqual(response.Status, Status.Ok);
        }
        [Test]
        public void PlacesAddAsyncTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = "Home",
                Types = new[] { PlaceLocationType.StreetAddress },
                Location = new Location(55.664425, 12.502264),
                Accuracy = 50,
                PhoneNumber = "+45 00000000",
                Address = "J. P. E. Hartmanns Allé 35 2500 Valby, Denmark",
                Website = "http://www.google.com",
                Language = "en-US"
            };
            var response = GooglePlaces.Add.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.PlaceId);
            Assert.AreEqual(response.Scope, Scope.App);
            Assert.AreEqual(response.Status, Status.Ok);
        }
        [Test]
        public void PlacesAddWhenKeyIsNullTest()
        {
            var request = new PlacesAddRequest
            {
                Key = null,
                Name = "test",
                Location = new Location(0, 0),
                Types = new[] { PlaceLocationType.StreetAddress }
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Add.Query(request));
            Assert.AreEqual(exception.Message, "Key is required");
        }
        [Test]
        public void PlacesAddWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesAddRequest
            {
                Key = string.Empty,
                Name = "test",
                Location = new Location(0, 0),
                Types = new[] { PlaceLocationType.StreetAddress }
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Add.Query(request));
            Assert.AreEqual(exception.Message, "Key is required");
        }
        [Test]
        public void PlacesAddWhenNameIsNullTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Add.Query(request));
            Assert.AreEqual(exception.Message, "Name must be provided");
        }
        [Test]
        public void PlacesAddWhenNameIsStringEmptyTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Add.Query(request));
            Assert.AreEqual(exception.Message, "Name must be provided");
        }
        [Test]
        public void PlacesAddWhenLocationIsNullTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = "Home",
                Location = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Add.Query(request));
            Assert.AreEqual(exception.Message, "Location must be provided");
        }
        [Test]
        public void PlacesAddWhenTypesIsNullTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = "Home",
                Location = new Location(55.664425, 12.502264),
                Types = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Add.Query(request));
            Assert.AreEqual(exception.Message, "Types must be provided. At least one type must be specified");
        }
        [Test]
        public void PlacesAddWhenTypesIsEmotyTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = "Home",
                Location = new Location(55.664425, 12.502264),
                Types = new PlaceLocationType[0]
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Add.Query(request));
            Assert.AreEqual(exception.Message, "Types must be provided. At least one type must be specified");
        }
    }
}