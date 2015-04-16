using System.Linq;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.PlacesAutoComplete.Request;
using GoogleApi.Entities.Places.PlacesDetails.Request;
using GoogleApi.Entities.Places.PlacesQueryAutoComplete.Request;
using GoogleApi.Entities.Places.PlacesSearch.Request;
using GoogleApi.Helpers;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
    public class PlacesTest
    {
        //TODO: These are Integration Tests, really need unit tests 

        private const string ApiKey = "AIzaSyAMaxRRrZDKBxC1Rezpzmnwj-3HpzRZyx0"; // your API key goes here...

        [Test]
        public void PlacesAutoCompleteTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                ApiKey = ApiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };

            var response = GooglePlaces.AutoComplete.Query(request);
            var results = response.Predictions.ToList();

            Assert.AreEqual(results[0].Description, "Jagtvej 2200, Denmark");
            Assert.AreEqual(results[1].Description, "Jagtvej 2200, Næstved, Denmark");
            Assert.AreEqual(results[2].Description, "Jagtvej 2200, Lemvig, Denmark");
            Assert.AreEqual(results[3].Description, "Jagtvej 2200, Hillerød, Denmark");
            Assert.AreEqual(results[4].Description, "Jagtvej 2200, Højbjerg, Denmark");
            Assert.AreEqual(5, results.Count);
        }

        [Test]
        public void PlacesQueryAutoCompleteTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                ApiKey = ApiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };
            var response = GooglePlaces.QueryAutoComplete.Query(request);
            var results = response.Predictions.ToList();

            Assert.AreEqual(Status.OK, response.Status);
            
            // Just think these asserts are a bad idea as they have changed and will keep changing prob
            //Assert.AreEqual(results[0].Description, "Jagtvej 2200, Copenhagen, Denmark");
            //Assert.AreEqual(results[1].Description, "2200 Jagtvej, Nuuk, Greenland");
            //Assert.AreEqual(results[2].Description, "Jagtvej 2200, Odense, Denmark");
            //Assert.AreEqual(results[3].Description, "Jagtvej 2200, Esbjerg, Denmark");
            //Assert.AreEqual(results[4].Description, "Jagtvej 2200, Naestved, Denmark");
            
            Assert.AreEqual(5, results.Count);
        }

        [Test]
        public void PlacesDetailsTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                ApiKey = ApiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };

            var response = GooglePlaces.AutoComplete.Query(request);
            var results = response.Predictions.ToList();
            var result = results.First();

            var request2 = new PlacesDetailsRequest
            {
                ApiKey = ApiKey,
                Reference = result.Reference,
                Sensor = true,
            };

            var response2 = GooglePlaces.Details.Query(request2);
            Assert.AreEqual(Status.OK, response2.Status);
        }

        [Test]
        public void NearBySearchTest()
        {
            var request = new PlacesNearbySearchRequest
            {
                ApiKey = ApiKey,
                Location = new Location(51.477307, -3.181229),
                Sensor = true,
                Language = "en",
                Radius = 500,
                Types = new[] { PlaceType.School, PlaceType.Police }
            };

            var response = GooglePlaces.NearBy.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.OK, response.Status);
        }

        [Test]
        public void RadarSearchTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                ApiKey = ApiKey,
                Location = new Location(51.477307, -3.181229),
                Sensor = true,
                Language = "en",
                Radius = 500,
                Types = new[] {PlaceType.PostOffice, PlaceType.Restaurant}
            };

            var response = GooglePlaces.Radar.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.OK, response.Status);
        }

        [Test]
        public void TextSearchTest()
        {
            var request = new PlacesTextSearchRequest
            {
                ApiKey = ApiKey,
                Location = new Location(51.477307, -3.181229),
                Sensor = true,
                Language = "en",
                Radius = 500,
                Types = new[] { PlaceType.Restaurant },
                Query = "Restaurant in Roath, Cardiff"
            };

            var response = GooglePlaces.Text.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.OK, response.Status);
        }
    }
}