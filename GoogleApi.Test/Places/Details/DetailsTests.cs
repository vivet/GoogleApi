using System;
using System.Linq;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.Details.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Details
{
    [TestFixture]
    public class DetailsTests : BaseTest
    {
        [Test]
        public void PlacesDetailsTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = ApiKey,
                Input = "jagtvej 2200",
                Sensor = true
            };

            var response = GooglePlaces.AutoComplete.Query(request);
            var results = response.Predictions.ToArray();
            var result = results.First();

            var request2 = new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = result.PlaceId,
                Sensor = true,
            };

            var response2 = GooglePlaces.Details.Query(request2);
            Assert.AreEqual(Status.Ok, response2.Status);
        }
        [Test]
        public void PlacesDetailsAsyncTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = ApiKey,
                Input = "jagtvej 2200",
                Sensor = true
            };

            var response = GooglePlaces.AutoComplete.QueryAsync(request).Result;
            var results = response.Predictions.ToArray();
            var result = results.First();

            var request2 = new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = result.PlaceId,
                Sensor = true,
            };

            var response2 = GooglePlaces.Details.Query(request2);
            Assert.AreEqual(Status.Ok, response2.Status);
        }
        [Test]
        public void PlacesDetailsWhenKeyIsNullTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = null,
                PlaceId = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Details.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesDetailsWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = string.Empty,
                PlaceId = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Details.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesDetailsWhenPlaceIdIsNullTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Details.Query(request));
            Assert.AreEqual(exception.Message, "PlaceId must be provided.");
        }
        [Test]
        public void PlacesDetailsWhenPlaceIdIsStringEmptyTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Details.Query(request));
            Assert.AreEqual(exception.Message, "PlaceId must be provided.");
        }


    }
}