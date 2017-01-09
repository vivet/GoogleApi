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
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };

            var response = GooglePlaces.AutoComplete.Query(request);
            var results = response.Predictions.ToArray();

            Assert.AreEqual(results[0].Description, "Jagtvej, 2200 Denmark");
            Assert.AreEqual(results[1].Description, "Jagtvej, 2200 Copenhagen, Denmark");
            Assert.AreEqual(results[2].Description, "Jagtvej 2200, Lemvig, Denmark");
            Assert.AreEqual(results[3].Description, "Jagtvej 2200, Denmark");
            Assert.AreEqual(results[4].Description, "Jagtvej 2200, Hillerød, Denmark");
            Assert.AreEqual(5, results.Length);
        }
        [Test]
        public void PlacesAutoCompleteAsyncTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };

            var response = GooglePlaces.AutoComplete.QueryAsync(request).Result;
            var results = response.Predictions.ToArray();

            Assert.AreEqual(results[0].Description, "Jagtvej, 2200 Denmark");
            Assert.AreEqual(results[1].Description, "Jagtvej, 2200 Copenhagen, Denmark");
            Assert.AreEqual(results[2].Description, "Jagtvej 2200, Lemvig, Denmark");
            Assert.AreEqual(results[3].Description, "Jagtvej 2200, Denmark");
            Assert.AreEqual(results[4].Description, "Jagtvej 2200, Hillerød, Denmark");
            Assert.AreEqual(5, results.Length);
        }

        [Test]
        public void PlacesQueryAutoCompleteTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };
            var response = GooglePlaces.QueryAutoComplete.Query(request);
            var results = response.Predictions.ToArray();

            Assert.AreEqual(results[0].Description, "Jagtvej 2200, Denmark");
            Assert.AreEqual(results[1].Description, "Jagtvej 2200, Lemvig, Denmark");
            Assert.AreEqual(results[2].Description, "Jagtvej 2200, Hillerød, Denmark");
            Assert.AreEqual(results[3].Description, "Jagtvej 2200, Næstved, Denmark");
            Assert.AreEqual(results[4].Description, "Jagtvej 2200, Fredensborg, Denmark");
            Assert.AreEqual(5, results.Length);
        }
        [Test]
        public void PlacesQueryAutoCompleteAsyncTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
            };
            var response = GooglePlaces.QueryAutoComplete.QueryAsync(request).Result;
            var results = response.Predictions.ToArray();

            Assert.AreEqual(results[0].Description, "Jagtvej 2200, Denmark");
            Assert.AreEqual(results[1].Description, "Jagtvej 2200, Lemvig, Denmark");
            Assert.AreEqual(results[2].Description, "Jagtvej 2200, Hillerød, Denmark");
            Assert.AreEqual(results[3].Description, "Jagtvej 2200, Næstved, Denmark");
            Assert.AreEqual(results[4].Description, "Jagtvej 2200, Fredensborg, Denmark");
            Assert.AreEqual(5, results.Length);
        }

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
        public void PlacesDetailsTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = ApiKey,
                Input = "jagtvej 2200",
                Sensor = true,
                Language = "en",
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
                Sensor = true,
                Language = "en",
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
        public void PlacesNearBySearchTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Sensor = true,
                Language = "en",
                Radius = 500,
                Type = SearchPlaceType.School
            };

            var response = GooglePlaces.NearBySearch.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }
        [Test]
        public void PlacesNearBySearchAsyncTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Sensor = true,
                Language = "en",
                Radius = 500,
                Types = new[] { SearchPlaceType.School, SearchPlaceType.Police }
            };

            var response = GooglePlaces.NearBySearch.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }
        
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
        public void PlacesRadarSearchTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(55.673323, 12.527438),
                Radius = 500,
                Sensor = true,
                Language = "en",
                Keyword = "abc"
            };

            var response = GooglePlaces.RadarSearch.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }
        [Test]
        public void PlacesRadarSearchAsyncTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(55.673323, 12.527438),
                Radius = 500,
                Sensor = true,
                Language = "en",
                Keyword = "abc"
            };

            var response = GooglePlaces.RadarSearch.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesPhotosTest()
        {
            var response = GooglePlaces.AutoComplete.Query(new PlacesAutoCompleteRequest
            {
                Key = ApiKey,
                Input = "det kongelige teater",
            });

            var response2 = GooglePlaces.Details.Query(new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault(),
            });

            var response3 = GooglePlaces.Photos.Query(new PlacesPhotosRequest
            {
                Key = ApiKey,
                PhotoReference = response2.Result.Photos.Select(x => x.PhotoReference).FirstOrDefault(),
                MaxWidth = 1600
            });

            Assert.IsNotNull(response3);
            Assert.IsNotNull(response3.Photo);
            Assert.AreEqual(Status.Ok, response3.Status);
        }
        [Test]
        public void PlacesPhotosAsyncTest()
        {
            var response = GooglePlaces.AutoComplete.Query(new PlacesAutoCompleteRequest
            {
                Key = ApiKey,
                Input = "det kongelige teater",
            });

            var response2 = GooglePlaces.Details.Query(new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault(),
            });

            var response3 = GooglePlaces.Photos.QueryAsync(new PlacesPhotosRequest
            {
                Key = ApiKey,
                PhotoReference = response2.Result.Photos.Select(x => x.PhotoReference).FirstOrDefault(),
                MaxWidth = 1600
            }).Result;

            Assert.IsNotNull(response3);
            Assert.IsNotNull(response3.Photo);
            Assert.AreEqual(Status.Ok, response3.Status);
        }
    }
}
