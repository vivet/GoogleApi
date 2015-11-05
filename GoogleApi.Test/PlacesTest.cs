using System;
using System.Linq;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Places.PlacesAutoComplete.Request;
using GoogleApi.Entities.Places.PlacesDetails.Request;
using GoogleApi.Entities.Places.PlacesQueryAutoComplete.Request;
using NUnit.Framework;

namespace GoogleApi.Test
{
    // TODO: Improve tests
    [TestFixture]
    public class PlacesTest : BaseTest
    {
        [Test]
        public void PlacesAutoCompleteTest()
        {
            var _request = new PlacesAutoCompleteRequest
            {
                ApiKey = _apiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };

            var _response = GooglePlaces.AutoComplete.Query(_request);
            var _results = _response.Predictions.ToList();

            Assert.AreEqual(_results[0].Description, "Jagtvej 2200, Denmark");
            Assert.AreEqual(_results[1].Description, "Jagtvej, 2200 Copenhagen, Denmark");
            Assert.AreEqual(_results[2].Description, "Jagtvej 2200, Hillerød, Denmark");
            Assert.AreEqual(_results[3].Description, "Jagtvej 2200, Fredensborg, Denmark");
            Assert.AreEqual(_results[4].Description, "Jagtvej, 2200 Denmark");
            Assert.AreEqual(5, _results.Count);
        }

        [Test]
        public void PlacesQueryAutoCompleteTest()
        {
            var _request = new PlacesQueryAutoCompleteRequest
            {
                ApiKey = _apiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };
            var _response = GooglePlaces.QueryAutoComplete.Query(_request);
            var _results = _response.Predictions.ToList();

            foreach (var _prediction in _results)
            {
                Console.WriteLine(_prediction.Description);
            }

            Assert.AreEqual(_results[0].Description, "Jagtvej 2200, Nuuk, Greenland");
            Assert.AreEqual(_results[1].Description, "Jagtvej 2200, Denmark");
            Assert.AreEqual(_results[2].Description, "Jagtvej 2200, Hillerød, Denmark");
            Assert.AreEqual(_results[3].Description, "Jagtvej 2200, Fredensborg, Denmark");
            Assert.AreEqual(_results[4].Description, "Jagtvej 2200, Lemvig, Denmark");
            Assert.AreEqual(5, _results.Count);
        }
        
        [Test]
        public void PlacesDetauilsTest()
        {
            var _request = new PlacesAutoCompleteRequest
            {
                ApiKey = _apiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };

            var _response = GooglePlaces.AutoComplete.Query(_request);
            var _results = _response.Predictions.ToList();
            var _result = _results.First();
            
            var _request2 = new PlacesDetailsRequest
            {
                ApiKey = _apiKey,
                PlaceId = _result.PlaceId,
                Sensor = true,
            };

            var _response2 = GooglePlaces.Details.Query(_request2);
            Assert.AreEqual(Status.OK, _response2.Status);
        }
    }
}
