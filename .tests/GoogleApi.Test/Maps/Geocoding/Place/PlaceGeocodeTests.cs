using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Place.Request;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Geocoding.Place
{
    [TestFixture]
    public class PlaceGeocodeTests : BaseTest
    {
        [Test]
        public void PlaceGeocodeTest()
        {
            var autoCompleteRequest = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "285 Bedford Ave, Brooklyn, NY 11211, USA"
            };

            var autoCompleteResponse = GooglePlaces.AutoComplete.Query(autoCompleteRequest);
            var placeId = autoCompleteResponse.Predictions.Select(x => x.PlaceId).FirstOrDefault();

            var request = new PlaceGeocodeRequest
            {
                Key = this.ApiKey,
                PlaceId = placeId
            };

            var result = GoogleMaps.PlaceGeocode.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var geocodeResult = result.Results.FirstOrDefault();
            Assert.IsNotNull(geocodeResult);
        }

        [Test]
        public void PlaceGeocodeWhenAsyncTest()
        {
            var autoCompleteRequest = new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "285 Bedford Ave, Brooklyn, NY 11211, USA"
            };

            var autoCompleteResponse = GooglePlaces.AutoComplete.Query(autoCompleteRequest);
            var placeId = autoCompleteResponse.Predictions.Select(x => x.PlaceId).FirstOrDefault();

            var request = new PlaceGeocodeRequest
            {
                Key = this.ApiKey,
                PlaceId = placeId
            };

            var result = GoogleMaps.PlaceGeocode.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void PlaceGeocodeWhenAsyncAndCancelledTest()
        {
            var request = new PlaceGeocodeRequest
            {
                Key = this.ApiKey,
                PlaceId = "abc"
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.PlaceGeocode.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void PlaceGeocodeAndLanguageTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlaceGeocodeWhenKeyIsNullTest()
        {
            var request = new PlaceGeocodeRequest
            {
                PlaceId = "test"
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.PlaceGeocode.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void PlaceGeocodeWhenClientCredentialsIsInvalidTest()
        {
            var request = new PlaceGeocodeRequest
            {
                ClientId = "abc",
                Key = "abc",
                PlaceId = "test"
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.PlaceGeocode.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "ClientId must begin with 'gme-'");
        }

        [Test]
        public void PlaceGeocodeWhenPlaceIdIsNullTest()
            {
            var request = new PlaceGeocodeRequest
            {
                Key = this.ApiKey
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.PlaceGeocode.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "PlaceId is required");
        }
    }
}