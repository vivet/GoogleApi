using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.AutoComplete.Request.Enums;
using GoogleApi.Exceptions;
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
        public void PlacesAutoCompleteWhhenAsyncTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200"
            };

            var response = GooglePlaces.AutoComplete.QueryAsync(request).Result;
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesAutoCompleteWhenAsyncAndCancelledTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200"
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var task = GooglePlaces.AutoComplete.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void PlacesAutoCompleteWhenInvalidKeyTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = "test",
                Input = "jagtvej 2200 København"
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.AutoComplete.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerExceptions.FirstOrDefault();
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("RequestDenied: The provided API key is invalid.", innerException.Message);
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
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesAutoCompleteWhenLocationTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesAutoCompleteWhenLocationAndRadiusTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesAutoCompleteWhenLocationAndRadiusAndStrictBoundsTest()
        {
            Assert.Inconclusive();
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

        [Test]
        public void PlacesAutoCompleteWhenComponentsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesAutoCompleteWhenKeyIsNullTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = null
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.AutoComplete.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void PlacesAutoCompleteWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = string.Empty
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.AutoComplete.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void PlacesAutoCompleteWhenInputIsNullTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = null
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.AutoComplete.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Input is required");
        }

        [Test]
        public void PlacesAutoCompleteWhenInputIsStringEmptyTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = string.Empty
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.AutoComplete.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Input is required");
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

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.AutoComplete.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000");
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

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.AutoComplete.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000");
        }
    }
}