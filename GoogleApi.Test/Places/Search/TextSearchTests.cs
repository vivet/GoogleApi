using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Places.Search.Text.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Search
{
    [TestFixture]
    public class TextSearchTests : BaseTest
    {
        [Test]
        public void PlacesTextSearchTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Sensor = true,
                Language = "en",
                Query = "picadelly circus"
            };

            var response = GooglePlaces.TextSearch.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }
        [Test]
        public void PlacesTextSearchAsyncTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Sensor = true,
                Language = "en",
                Query = "picadelly circus"
            };

            var response = GooglePlaces.TextSearch.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }
        [Test]
        public void PlacesTextSearchWhenKeyIsNullTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = null,
                Query = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.TextSearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesTextSearchWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = string.Empty,
                Query = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.TextSearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesTextSearchWhenQueryIsNullTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.TextSearch.Query(request));
            Assert.AreEqual(exception.Message, "Query is required.");
        }
        [Test]
        public void PlacesTextSearchWhenQueryIsStringEmptyTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.TextSearch.Query(request));
            Assert.AreEqual(exception.Message, "Query is required.");
        }

    }
}