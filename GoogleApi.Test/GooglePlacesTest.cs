using System;
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
using GoogleApi.Entities.Places.Search.NearBy.Request.Enums;
using GoogleApi.Entities.Places.Search.Radar.Request;
using GoogleApi.Entities.Places.Search.Text.Request;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
    public class GooglePlacesTest : BaseTest
    {
        // Auto Complete
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
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);

            var results = response.Predictions.ToArray();
            Assert.IsNotNull(results);
            Assert.AreEqual(results[0].Description, "Jagtvej, 2200 København N, Denmark");
            Assert.AreEqual(results[1].Description, "Jagtvej, 2200 Copenhagen, Denmark");
            Assert.AreEqual(results[2].Description, "Jagtvej 2200, Lemvig, Denmark");
            Assert.AreEqual(results[3].Description, "Jagtvej 2200, Odense C, Denmark");
            Assert.AreEqual(results[4].Description, "Jagtvej 2200, Næstved, Denmark");
            Assert.AreEqual(5, results.Length);
        }

        [Test]
        public void PlacesAutoCompleteWhenKeyIsNullTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.AutoComplete.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesAutoCompleteWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.AutoComplete.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesAutoCompleteWhenInputIsNullTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.AutoComplete.Query(request));
            Assert.AreEqual(exception.Message, "Input is required.");
        }
        [Test]
        public void PlacesAutoCompleteWhenInputIsStringEmptyTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.AutoComplete.Query(request));
            Assert.AreEqual(exception.Message, "Input is required.");
        }
        [Test]
        public void PlacesAutoCompleteWhenRadiusIsLessThanOneTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "abc",
                Radius = 0
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.AutoComplete.Query(request));
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000.");
        }
        [Test]
        public void PlacesAutoCompleteWhenRadiusIsGereaterThanFiftyThousandTest()
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
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }


        // Query Auto Complete
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
                Sensor = true,
                Language = "en",
            };
            var response = GooglePlaces.QueryAutoComplete.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }


        // Add
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
            Assert.AreEqual(exception.Message, "Key is required.");
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
            Assert.AreEqual(exception.Message, "Key is required.");
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
            Assert.AreEqual(exception.Message, "Name must be provided.");
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
            Assert.AreEqual(exception.Message, "Name must be provided.");
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
            Assert.AreEqual(exception.Message, "Location must be provided.");
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
            Assert.AreEqual(exception.Message, "Types must be provided. At least one type must be specified.");
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
            Assert.AreEqual(exception.Message, "Types must be provided. At least one type must be specified.");
        }


        // Delete
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
        public void PlacesDeleteWhenKeyIsNullTest()
        {
            var request = new PlacesDeleteRequest
            {
                Key = null,
                PlaceId = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Delete.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesDeleteWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesDeleteRequest
            {
                Key = string.Empty,
                PlaceId = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Delete.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesDeleteWhenPlaceIdIsNullTest()
        {
            var request = new PlacesDeleteRequest
            {
                Key = this.ApiKey,
                PlaceId = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Delete.Query(request));
            Assert.AreEqual(exception.Message, "PlaceId is required.");
        }
        [Test]
        public void PlacesDeleteWhenPlaceIdIsStringEmptyTest()
        {
            var request = new PlacesDeleteRequest
            {
                Key = this.ApiKey,
                PlaceId = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Delete.Query(request));
            Assert.AreEqual(exception.Message, "PlaceId is required.");
        }


        // Details
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


        // Nearby Search
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
                Type = SearchPlaceType.School
            };

            var response = GooglePlaces.NearBySearch.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }
        [Test]
        public void PlacesNearBySearchWhenKeyIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = null, 
                Location = new Location(0, 0),
                Radius = 10
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesNearBySearchWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = string.Empty,
                Location = new Location(0, 0),
                Radius = 10
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesNearBySearchWhenLocationIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Location is required.");
        }
        [Test]
        public void PlacesNearBySearchWhenRadiusIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(0, 0),
                Radius = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius is required, when RankBy is not Distance");
        }
        [Test]
        public void PlacesNearBySearchWhenRadiusIsLessThanOneTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 0
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000.");
        }
        [Test]
        public void PlacesNearBySearchWhenRadiusIsGereaterThanFiftyThousandTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 50001
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000.");
        }
        [Test]
        public void PlacesNearBySearchWhenRankByDistanceAndRadiusIsNotNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 50001,
                Rankby = Ranking.Distance
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius cannot be specified, when using RankBy distance");
        }
        [Test]
        public void PlacesNearBySearchWhenRankByDistanceAndNameIsNullAndKeywordIsNullAndTypeIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Rankby = Ranking.Distance
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Keyword or Name or Type is required, If rank by distance.");
        }
        

        // Text Search
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


        // Radar Search
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
        public void PlacesRadarSearchWhenKeyIsNullTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = null,
                Location = new Location(0, 0),
                Radius = 10,
                Keyword = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesRadarSearchWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = string.Empty,
                Location = new Location(0, 0),
                Radius = 10,
                Keyword = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesRadarSearchWhenLocationIsNullTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Location is required.");
        }
        [Test]
        public void PlacesRadarSearchWhenRadiusIsNullTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(0, 0),
                Radius = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius is required.");
        }
        [Test]
        public void PlacesRadarSearchWhenRadiusIsLessThanOneTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 0
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000.");
        }
        [Test]
        public void PlacesRadarSearchWhenRadiusIsGereaterThanFiftyThousandTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 50001
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000.");
        }
        [Test]
        public void PlacesRadarSearchWhenRankByDistanceAndNameIsNullAndKeywordIsNullAndTypeIsNullTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 1
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Keyword or Name or Type must is required.");
        }


        // Photos
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
        [Test]
        public void PlacesPhotosWhenKeyIsNullTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = null,
                PhotoReference = "test",
                MaxHeight = 10
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Photos.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesPhotosWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = string.Empty,
                PhotoReference = "test",
                MaxHeight = 10
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Photos.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void PlacesPhotosWhenPhotoReferenceIsNullTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = this.ApiKey,
                PhotoReference = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Photos.Query(request));
            Assert.AreEqual(exception.Message, "PhotoReference is required.");
        }
        [Test]
        public void PlacesPhotosWhenPhotoReferenceIsStringEmptyTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = this.ApiKey,
                PhotoReference = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Photos.Query(request));
            Assert.AreEqual(exception.Message, "PhotoReference is required.");
        }
        [Test]
        public void PlacesPhotosWhenMaxHeightIsNullAndMaxWidthIsNullTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = this.ApiKey,
                PhotoReference = "abc"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Photos.Query(request));
            Assert.AreEqual(exception.Message, "MaxHeight or MaxWidth is required.");
        }
        [Test]
        public void PlacesPhotosWhenMaxHeightIsLessThanOneTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = this.ApiKey,
                PhotoReference = "abc",
                MaxHeight = 0
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Photos.Query(request));
            Assert.AreEqual(exception.Message, "MaxHeight must be greater than or equal to 1 and less than or equal to 1.600.");
        }
        [Test]
        public void PlacesPhotosWhenMaxHeightIsGreaterThanSexteenHundredthsTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = this.ApiKey,
                PhotoReference = "abc",
                MaxHeight = 1601
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Photos.Query(request));
            Assert.AreEqual(exception.Message, "MaxHeight must be greater than or equal to 1 and less than or equal to 1.600.");
        }
        [Test]
        public void PlacesPhotosWhenMaxWidthIsLessThanOneTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = this.ApiKey,
                PhotoReference = "abc",
                MaxWidth = 0
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Photos.Query(request));
            Assert.AreEqual(exception.Message, "MaxWidth must be greater than or equal to 1 and less than or equal to 1.600.");
        }
        [Test]
        public void PlacesPhotosWhenMaxWidthIsGreaterThanSexteenHundredthsTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = this.ApiKey,
                PhotoReference = "abc",
                MaxWidth = 1601
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Photos.Query(request));
            Assert.AreEqual(exception.Message, "MaxWidth must be greater than or equal to 1 and less than or equal to 1.600.");
        }
    }
}
