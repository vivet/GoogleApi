using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Places.QueryAutoComplete
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
                Input = "jagtvej 2200 København",
                Language = Language.English
            };

            var response = GooglePlaces.QueryAutoComplete.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);

            var results = response.Predictions.ToArray();
            Assert.IsNotNull(results);
            Assert.IsNotEmpty(results);
            Assert.AreEqual(3, results.Length);

            var result = results.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Terms);
            Assert.IsNotNull(result.PlaceId);
            Assert.IsNotNull(result.StructuredFormatting);
            Assert.AreEqual(result.Description, "Jagtvej, 2200 København, Denmark");

            var matchedSubstrings = result.MatchedSubstrings.ToArray();
            Assert.IsNotNull(matchedSubstrings);
            Assert.AreEqual(3, matchedSubstrings.Length);

            var types = result.Types.ToArray();
            Assert.IsNotNull(types);
            Assert.Contains(PlaceLocationType.Route, types);
            Assert.Contains(PlaceLocationType.Geocode, types);
        }

        [Test]
        public void PlacesQueryAutoCompleteWhenAsyncTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200"
            };
            var response = GooglePlaces.QueryAutoComplete.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesQueryAutoCompleteWhenAsyncAndCancelledTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200"
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var task = GooglePlaces.QueryAutoComplete.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void PlacesQueryAutoCompleteWhenInvalidKeyTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = "test",
                Input = "jagtvej 2200 København"
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.QueryAutoComplete.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerExceptions.FirstOrDefault();
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("RequestDenied: The provided API key is invalid.", innerException.Message);
        }

        [Test]
        public void PlacesQueryAutoCompleteWhenLanguageTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200 København",
                Language = Language.Danish
            };

            var response = GooglePlaces.QueryAutoComplete.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);

            var results = response.Predictions.ToArray();
            Assert.IsNotNull(results);
            Assert.IsNotEmpty(results);
            Assert.GreaterOrEqual(results.Length, 3);

            var result = results.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Description, "Jagtvej, 2200 København, Danmark");
        }

        [Test]
        public void PlacesQueryAutoCompleteWhenOffsetTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesQueryAutoCompleteWhenLocationTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesQueryAutoCompleteWhenLocationAndRadiusTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesQueryAutoCompleteWhenKeyIsNullTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = null,
                Input = "test"
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.QueryAutoComplete.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void PlacesQueryAutoCompleteWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = string.Empty,
                Input = "test"
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.QueryAutoComplete.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void PlacesQueryAutoCompleteWhenInputIsNullTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = null
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.QueryAutoComplete.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Input is required");
        }

        [Test]
        public void PlacesQueryAutoCompleteWhenInputIsStringEmptyTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = string.Empty
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.QueryAutoComplete.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Input is required");
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

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.QueryAutoComplete.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000");
        }

        [Test]
        public void PlacesQueryAutoCompleteWhenRadiusIsGereaterThanFiftyThousandTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "abc",
                Radius = 50001
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.QueryAutoComplete.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000");
        }
    }
}