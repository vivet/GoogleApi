using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Places.Add.Request;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Delete.Request;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Photos.Request;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.Radar.Request;
using GoogleApi.Entities.Places.Search.Text.Request;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
    public class GooglePlacesTest : BaseTest
    {
        [Test]
        public void PlacesAutoCompleteTest()
        {
            var _request = new PlacesAutoCompleteRequest
            {
                Key = this._apiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };

            var _response = GooglePlaces.AutoComplete.Query(_request);
            var _results = _response.Predictions.ToArray();

            Assert.AreEqual(_results[0].Description, "Jagtvej, 2200 Denmark");
            Assert.AreEqual(_results[1].Description, "Jagtvej, 2200 Copenhagen, Denmark");
            Assert.AreEqual(_results[2].Description, "Jagtvej 2200, Lemvig, Denmark");
            Assert.AreEqual(_results[3].Description, "Jagtvej 2200, Denmark");
            Assert.AreEqual(_results[4].Description, "Jagtvej 2200, Hillerød, Denmark");
            Assert.AreEqual(5, _results.Length);
        }
        [Test]
        public void PlacesAutoCompleteAsyncTest()
        {
            var _request = new PlacesAutoCompleteRequest
            {
                Key = this._apiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };

            var _response = GooglePlaces.AutoComplete.QueryAsync(_request).Result;
            var _results = _response.Predictions.ToArray();

            Assert.AreEqual(_results[0].Description, "Jagtvej, 2200 Denmark");
            Assert.AreEqual(_results[1].Description, "Jagtvej, 2200 Copenhagen, Denmark");
            Assert.AreEqual(_results[2].Description, "Jagtvej 2200, Lemvig, Denmark");
            Assert.AreEqual(_results[3].Description, "Jagtvej 2200, Denmark");
            Assert.AreEqual(_results[4].Description, "Jagtvej 2200, Hillerød, Denmark");
            Assert.AreEqual(5, _results.Length);
        }

        [Test]
        public void PlacesQueryAutoCompleteTest()
        {
            var _request = new PlacesQueryAutoCompleteRequest
            {
                Key = this._apiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };
            var _response = GooglePlaces.QueryAutoComplete.Query(_request);
            var _results = _response.Predictions.ToArray();

            Assert.AreEqual(_results[0].Description, "Jagtvej 2200, Denmark");
            Assert.AreEqual(_results[1].Description, "Jagtvej 2200, Lemvig, Denmark");
            Assert.AreEqual(_results[2].Description, "Jagtvej 2200, Hillerød, Denmark");
            Assert.AreEqual(_results[3].Description, "Jagtvej 2200, Næstved, Denmark");
            Assert.AreEqual(_results[4].Description, "Jagtvej 2200, Fredensborg, Denmark");
            Assert.AreEqual(5, _results.Length);
        }
        [Test]
        public void PlacesQueryAutoCompleteAsyncTest()
        {
            var _request = new PlacesQueryAutoCompleteRequest
            {
                Key = this._apiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };
            var _response = GooglePlaces.QueryAutoComplete.QueryAsync(_request).Result;
            var _results = _response.Predictions.ToArray();

            Assert.AreEqual(_results[0].Description, "Jagtvej 2200, Denmark");
            Assert.AreEqual(_results[1].Description, "Jagtvej 2200, Lemvig, Denmark");
            Assert.AreEqual(_results[2].Description, "Jagtvej 2200, Hillerød, Denmark");
            Assert.AreEqual(_results[3].Description, "Jagtvej 2200, Næstved, Denmark");
            Assert.AreEqual(_results[4].Description, "Jagtvej 2200, Fredensborg, Denmark");
            Assert.AreEqual(5, _results.Length);
        }

        [Test]
        public void PlacesAddTest()
        {
            var _request = new PlacesAddRequest
            {
                Key = this._apiKey,
                Name = "Home",
                Types = new[] { PlaceLocationType.STREET_ADDRESS },
                Location = new Location(55.664425, 12.502264),
                Accuracy = 50,
                PhoneNumber = "+45 00000000",
                Address = "J. P. E. Hartmanns Allé 35 2500 Valby, Denmark",
                Website = "http://www.google.com",
                Language = "en-US"
            };
            var _response = GooglePlaces.Add.Query(_request);

            Assert.IsNotNull(_response);
            Assert.IsNotNull(_response.Id);
            Assert.IsNotNull(_response.PlaceId);
            Assert.IsNotNull(_response.Reference);
            Assert.AreEqual(_response.Scope, Scope.APP);
            Assert.AreEqual(_response.Status, Status.OK);
        }
        [Test]
        public void PlacesAddAsyncTest()
        {
            var _request = new PlacesAddRequest
            {
                Key = this._apiKey,
                Name = "Home",
                Types = new[] { PlaceLocationType.STREET_ADDRESS },
                Location = new Location(55.664425, 12.502264),
                Accuracy = 50,
                PhoneNumber = "+45 00000000",
                Address = "J. P. E. Hartmanns Allé 35 2500 Valby, Denmark",
                Website = "http://www.google.com",
                Language = "en-US"
            };
            var _response = GooglePlaces.Add.QueryAsync(_request).Result;

            Assert.IsNotNull(_response);
            Assert.IsNotNull(_response.Id);
            Assert.IsNotNull(_response.PlaceId);
            Assert.IsNotNull(_response.Reference);
            Assert.AreEqual(_response.Scope, Scope.APP);
            Assert.AreEqual(_response.Status, Status.OK);
        }

        [Test]
        public void PlacesDeleteTest()
        {
            var _response = GooglePlaces.Add.Query(new PlacesAddRequest
            {
                Key = this._apiKey,
                Name = "Home",
                Types = new[] { PlaceLocationType.STREET_ADDRESS },
                Location = new Location(55.664425, 12.502264)
            });

            Assert.IsNotNull(_response);
            Assert.IsNotNull(_response.PlaceId);

            var _response2 = GooglePlaces.Delete.Query(new PlacesDeleteRequest
            {
                Key = this._apiKey,
                PlaceId = _response.PlaceId
            });

            Assert.IsNotNull(_response2);
            Assert.AreEqual(_response2.Status, Status.OK);
        }
        [Test]
        public void PlacesDeleteAsyncTest()
        {
            var _response = GooglePlaces.Add.Query(new PlacesAddRequest
            {
                Key = this._apiKey,
                Name = "Home",
                Types = new[] { PlaceLocationType.STREET_ADDRESS },
                Location = new Location(55.664425, 12.502264)
            });

            Assert.IsNotNull(_response);
            Assert.IsNotNull(_response.PlaceId);

            var _response2 = GooglePlaces.Delete.QueryAsync(new PlacesDeleteRequest
            {
                Key = this._apiKey,
                PlaceId = _response.PlaceId
            }).Result;

            Assert.IsNotNull(_response2);
            Assert.AreEqual(_response2.Status, Status.OK);
        }
        
        [Test]
        public void PlacesDetailsTest()
        {
            var _request = new PlacesAutoCompleteRequest
            {
                Key = _apiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };

            var _response = GooglePlaces.AutoComplete.Query(_request);
            var _results = _response.Predictions.ToArray();
            var _result = _results.First();
            
            var _request2 = new PlacesDetailsRequest
            {
                Key = _apiKey,
                PlaceId = _result.PlaceId,
                Sensor = true,
            };

            var _response2 = GooglePlaces.Details.Query(_request2);
            Assert.AreEqual(Status.OK, _response2.Status);
        }
        [Test]
        public void PlacesDetailsAsyncTest()
        {
            var _request = new PlacesAutoCompleteRequest
            {
                Key = _apiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };

            var _response = GooglePlaces.AutoComplete.QueryAsync(_request).Result;
            var _results = _response.Predictions.ToArray();
            var _result = _results.First();

            var _request2 = new PlacesDetailsRequest
            {
                Key = _apiKey,
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
                Key = this._apiKey,
                Location = new Location(51.491431, -3.16668),
                Sensor = true,
                Language = "en",
                Radius = 500,
                Types = new[] { SearchPlaceType.SCHOOL, SearchPlaceType.POLICE }
            };

            var _response = GooglePlaces.NearBySearch.Query(_request);

            Assert.IsNotNull(_response);
            Assert.AreEqual(Status.OK, _response.Status);
        }
        [Test]
        public void PlacesNearBySearchAsyncTest()
        {
            var _request = new PlacesNearBySearchRequest
            {
                Key = this._apiKey,
                Location = new Location(51.491431, -3.16668),
                Sensor = true,
                Language = "en",
                Radius = 500,
                Types = new[] { SearchPlaceType.SCHOOL, SearchPlaceType.POLICE }
            };

            var _response = GooglePlaces.NearBySearch.QueryAsync(_request).Result;

            Assert.IsNotNull(_response);
            Assert.AreEqual(Status.OK, _response.Status);
        }
        
        [Test]
        public void PlacesTextSearchTest()
        {
            var _request = new PlacesTextSearchRequest
            {
                Key = this._apiKey,
                Sensor = true,
                Language = "en",
                Query = "picadelly circus"
            };

            var _response = GooglePlaces.TextSearch.Query(_request);

            Assert.IsNotNull(_response);
            Assert.AreEqual(Status.OK, _response.Status);
        }
        [Test]
        public void PlacesTextSearchAsyncTest()
        {
            var _request = new PlacesTextSearchRequest
            {
                Key = this._apiKey,
                Sensor = true,
                Language = "en",
                Query = "picadelly circus"
            };

            var _response = GooglePlaces.TextSearch.QueryAsync(_request).Result;

            Assert.IsNotNull(_response);
            Assert.AreEqual(Status.OK, _response.Status);
        }

        [Test]
        public void PlacesRadarSearchTest()
        {
            var _request = new PlacesRadarSearchRequest
            {
                Key = this._apiKey,
                Location = new Location(55.673323, 12.527438),
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
        public void PlacesRadarSearchAsyncTest()
        {
            var _request = new PlacesRadarSearchRequest
            {
                Key = this._apiKey,
                Location = new Location(55.673323, 12.527438),
                Radius = 500,
                Sensor = true,
                Language = "en",
                Keyword = "abc"
            };

            var _response = GooglePlaces.RadarSearch.QueryAsync(_request).Result;

            Assert.IsNotNull(_response);
            Assert.AreEqual(Status.OK, _response.Status);
        }

        [Test]
        public void PlacesPhotosTest()
        {
            var _response = GooglePlaces.AutoComplete.Query(new PlacesAutoCompleteRequest
            {
                Key = _apiKey,
                Input = "det kongelige teater",
            });

            var _response2 = GooglePlaces.Details.Query(new PlacesDetailsRequest
            {
                Key = _apiKey,
                PlaceId = _response.Predictions.Select(_x => _x.PlaceId).FirstOrDefault(),
            });

            var _response3 = GooglePlaces.Photos.Query(new PlacesPhotosRequest
            {
                Key = _apiKey,
                PhotoReference = _response2.Result.Photos.Select(_x => _x.PhotoReference).FirstOrDefault(),
                MaxWidth = 1600
            });

            Assert.IsNotNull(_response3);
            Assert.IsNotNull(_response3.Photo);
            Assert.AreEqual(Status.OK, _response3.Status);
        }
        [Test]
        public void PlacesPhotosAsyncTest()
        {
            var _response = GooglePlaces.AutoComplete.Query(new PlacesAutoCompleteRequest
            {
                Key = _apiKey,
                Input = "det kongelige teater",
            });

            var _response2 = GooglePlaces.Details.Query(new PlacesDetailsRequest
            {
                Key = _apiKey,
                PlaceId = _response.Predictions.Select(_x => _x.PlaceId).FirstOrDefault(),
            });

            var _response3 = GooglePlaces.Photos.QueryAsync(new PlacesPhotosRequest
            {
                Key = _apiKey,
                PhotoReference = _response2.Result.Photos.Select(_x => _x.PhotoReference).FirstOrDefault(),
                MaxWidth = 1600
            }).Result;

            Assert.IsNotNull(_response3);
            Assert.IsNotNull(_response3.Photo);
            Assert.AreEqual(Status.OK, _response3.Status);
        }
    }
}
