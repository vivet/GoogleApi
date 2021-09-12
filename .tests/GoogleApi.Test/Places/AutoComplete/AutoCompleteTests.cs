using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.AutoComplete.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.Test.Places.AutoComplete
{
    [TestFixture]
    public class AutoCompleteTests : BaseTest
    {
        [Test]
        public void PlacesAutoCompleteTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200 København",
                Types = new List<RestrictPlaceType> { RestrictPlaceType.Address }
            };

            var response = GooglePlaces.AutoComplete.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);

            var results = response.Predictions.ToArray();
            Assert.IsNotNull(results);
            Assert.IsNotEmpty(results);
            Assert.AreEqual(1, results.Length);

            var result = results.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Terms);
            Assert.IsNotNull(result.PlaceId);
            Assert.IsNotNull(result.StructuredFormatting);

            var description = result.Description.ToLower();
            Assert.IsTrue(description.Contains("2200"), "1");
            Assert.IsTrue(description.Contains("jagtvej"), "2");

            var matchedSubstrings = result.MatchedSubstrings.ToArray();
            Assert.IsNotNull(matchedSubstrings);
            Assert.AreEqual(3, matchedSubstrings.Length);

            var types = result.Types.ToArray();
            Assert.IsNotNull(types);
            Assert.Contains(PlaceLocationType.Route, types);
            Assert.Contains(PlaceLocationType.Geocode, types);
        }

        [Test]
        public void PlacesAutoCompleteWhenAsyncTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200 København"
            };

            var result = GooglePlaces.AutoComplete.QueryAsync(request).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void PlacesAutoCompleteWhenAsyncAndCancelledTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200 København"
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var task = GooglePlaces.AutoComplete.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void PlacesAutoCompleteWhenLanguageTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200 København",
                Language = Language.Danish
            };

            var response = GooglePlaces.AutoComplete.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);

            var results = response.Predictions.ToArray();
            Assert.IsNotNull(results);
            Assert.IsNotEmpty(results);
            Assert.GreaterOrEqual(results.Length, 2);

            var result = results.FirstOrDefault();
            Assert.IsNotNull(result);

            var description = result.Description.ToLower();
            Assert.IsTrue(description.Contains("2200"), "1");
            Assert.IsTrue(description.Contains("jagtvej"), "2");
        }

        [Test]
        public void PlacesAutoCompleteWhenOffsetTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200 København",
                Offset = "offset"
            };

            var response = GooglePlaces.AutoComplete.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesAutoCompleteWhenLocationTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200 København",
                Location = new Coordinate(1, 1)
            };

            var response = GooglePlaces.AutoComplete.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesAutoCompleteWhenLocationAndRadiusTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200 København",
                Radius = 100
            };

            var response = GooglePlaces.AutoComplete.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesAutoCompleteWhenTypesTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200 København",
                Types = new List<RestrictPlaceType> { RestrictPlaceType.Address }
            };

            var response = GooglePlaces.AutoComplete.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesAutoCompleteWhenTypesCitiesTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "København",
                Types = new List<RestrictPlaceType> { RestrictPlaceType.Cities }
            };

            var response = GooglePlaces.AutoComplete.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesAutoCompleteWhenTypesRegionsTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "Denmark",
                Types = new List<RestrictPlaceType> { RestrictPlaceType.Regions }
            };

            var response = GooglePlaces.AutoComplete.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }
    }
}