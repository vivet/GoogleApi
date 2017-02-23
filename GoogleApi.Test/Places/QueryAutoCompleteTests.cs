using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Places
{
    [TestFixture]
    public class QueryAutoCompleteTests : BaseTest
    {
        [Test]
        public void PlacesQueryAutoCompleteTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200",
                Sensor = true
            };
            var response = GooglePlaces.QueryAutoComplete.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);

            var results = response.Predictions.ToArray();
            Assert.IsNotNull(results);
            Assert.AreEqual(5, results.Length);
        }

        [Test]
        public void PlacesQueryAutoCompleteWhenKeyIsNullTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = null,
                Input = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.QueryAutoComplete.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesQueryAutoCompleteWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = string.Empty,
                Input = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.QueryAutoComplete.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesQueryAutoCompleteWhenInputIsNullTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.QueryAutoComplete.Query(request));
            Assert.AreEqual(exception.Message, "Input is required.");
        }
        [Test]
        public void PlacesQueryAutoCompleteWhenInputIsStringEmptyTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.QueryAutoComplete.Query(request));
            Assert.AreEqual(exception.Message, "Input is required.");
        }
        [Test]
        public void PlacesQueryAutoCompleteWhenRadiusIsLessThanOneTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "abc",
                Radius = 0
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.QueryAutoComplete.Query(request));
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000.");
        }
        [Test]
        public void PlacesQueryAutoCompleteWhenRadiusIsGereaterThanFiftyThousandTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "abc",
                Radius = 50001
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.AutoComplete.Query(request));
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000.");
        }

        [Test]
        public void PlacesQueryAutoCompleteAsyncTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200",
                Sensor = true
            };
            var response = GooglePlaces.QueryAutoComplete.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }
    }
}