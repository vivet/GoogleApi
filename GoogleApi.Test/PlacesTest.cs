using System.Linq;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Places.PlacesAutoComplete.Request;
using GoogleApi.Entities.Places.PlacesDetails.Request;
using GoogleApi.Entities.Places.PlacesQueryAutoComplete.Request;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
    public class PlacesTest
    {
        public string _apiKey = ""; // your API key goes here...
        
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

            Assert.AreEqual(_results[0].Description, "Jagtvej 2200, Copenhagen, Denmark");
            Assert.AreEqual(_results[1].Description, "2200 Jagtvej, Nuuk, Greenland");
            Assert.AreEqual(_results[2].Description, "Jagtvej 2200, Odense, Denmark");
            Assert.AreEqual(_results[3].Description, "Jagtvej 2200, Esbjerg, Denmark");
            Assert.AreEqual(_results[4].Description, "Jagtvej 2200, Naestved, Denmark");
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

            Assert.AreEqual(_results[0].Description, "Jagtvej 2200, Copenhagen, Denmark");
            Assert.AreEqual(_results[1].Description, "2200 Jagtvej, Nuuk, Greenland");
            Assert.AreEqual(_results[2].Description, "Jagtvej 2200, Odense, Denmark");
            Assert.AreEqual(_results[3].Description, "Jagtvej 2200, Esbjerg, Denmark");
            Assert.AreEqual(_results[4].Description, "Jagtvej 2200, Naestved, Denmark");
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
                Reference = _result.Reference,
                Sensor = true,
            };

            var _response2 = GooglePlaces.Details.Query(_request2);
            Assert.AreEqual(Status.OK, _response2.Status);
        }
    }
}
