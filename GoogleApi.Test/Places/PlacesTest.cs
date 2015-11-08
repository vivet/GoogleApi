using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.Radar.Request;
using GoogleApi.Entities.Places.Search.Text.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Places
{
    [TestFixture]
    public class PlacesTest : BaseTest
    {
        [Test]
        public void PlacesAutoCompleteTest()
        {
            var _request = new PlacesAutoCompleteRequest
            {
                ApiKey = this._apiKey,
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
                ApiKey = this._apiKey,
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

        [Test]
        public void PlacesNearBySearchTest()
        {
            var _request = new PlacesNearBySearchRequest
            {
                ApiKey = this._apiKey,
                Location = new Location(51.491431, -3.16668),
                Sensor = true,
                Language = "en",
                Radius = 500,
                Types = new[] { PlaceType.SCHOOL, PlaceType.POLICE }
            };

            var _response = GooglePlaces.NearBySearch.Query(_request);

            Assert.IsNotNull(_response);
            Assert.AreEqual(Status.OK, _response.Status);
        }
        
        [Test]
        public void PlacesTextSearchTest()
        {
            var _request = new PlacesTextSearchRequest
            {
                ApiKey = this._apiKey,
                Sensor = true,
                Language = "en",
                Query = "picadelly circus"
            };

            var _response = GooglePlaces.TextSearch.Query(_request);

            Assert.IsNotNull(_response);
            Assert.AreEqual(Status.OK, _response.Status);
        }

        [Test]
        public void PlacesRadarSearchTest()
        {
            var _request = new PlacesRadarSearchRequest
            {
                ApiKey = this._apiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 500,
                Sensor = true,
                Language = "en",
                Keyword = "abc"
            };

            var _response = GooglePlaces.RadarSearch.Query(_request);

            Assert.IsNotNull(_response);
            Assert.AreEqual(Status.OK, _response.Status);
        }

        [Test]
        public void PhotosTest()
        {
            Assert.Inconclusive();

            //var _request = new PlacesAutoCompleteRequest
            //{
            //    ApiKey = _apiKey,
            //    Input = "det kongelige teater",
            //    Sensor = true,
            //    Language = "en",
            //};

            //var _response = GooglePlaces.AutoComplete.Query(_request);
            //var _results = _response.Predictions.ToList();
            //var _result = _results.First();

            //var _request2 = new PlacesDetailsRequest
            //{
            //    ApiKey = _apiKey,
            //    PlaceId = _result.PlaceId,
            //    Sensor = true,
            //};

            //var _response2 = GooglePlaces.Details.Query(_request2);
            //Assert.AreEqual(Status.OK, _response2.Status);
            
            //var _photo = _response2.Result.Photos.FirstOrDefault();
            //Assert.IsNotNull(_photo);

            //var _request3 = new PlacesPhotosRequest
            //{
            //    Sensor = true,
            //    PhotoReference = _photo.PhotoReference,
            //    MaxWidth = 1600
            //};

            //var _response3 = GooglePlaces.Photos.Query(_request3);

            //Assert.IsNotNull(_response3);
            //Assert.AreEqual(Status.OK, _response3.Status);
        }
    }
}
