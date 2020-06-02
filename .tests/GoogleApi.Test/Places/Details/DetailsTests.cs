using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Details.Request.Enums;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Details
{
    [TestFixture]
    public class DetailsTests : BaseTest
    {
        [Test]
        public void PlacesDetailsTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = ApiKey,
                Input = "jagtvej 2200 København"
            };

            var response = GooglePlaces.AutoComplete.Query(request);
            var request2 = new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault()
            };

            var response2 = GooglePlaces.Details.Query(request2);
            Assert.IsNotNull(response2);
            Assert.AreEqual(Status.Ok, response2.Status);

            var result = response2.Result;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Url);
            Assert.IsNotNull(result.Icon);
            Assert.IsNotNull(result.PlaceId);
            Assert.IsNotNull(result.Vicinity);
            Assert.IsNotNull(result.UtcOffset);
            Assert.IsNotNull(result.AdrAddress);
            Assert.IsNotNull(result.Geometry);
            Assert.IsNotNull(result.Geometry.Location);
            Assert.Contains(PlaceLocationType.Route, result.Types.ToArray());
            Assert.AreEqual(BusinessStatus.Operational, result.BusinessStatus);

            var formattedAddress = result.FormattedAddress.ToLower();
            Assert.IsNotNull(formattedAddress);
            Assert.IsTrue(formattedAddress.Contains("jagtvej"));
            Assert.IsTrue(formattedAddress.Contains("københavn"));

            var addressComponents = result.AddressComponents?.ToArray();
            Assert.IsNotNull(addressComponents);
            Assert.AreEqual(4, addressComponents.Length);
        }

        [Test]
        public void PlacesDetailsAsyncTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = ApiKey,
                Input = "jagtvej 2200"
            };

            var response = GooglePlaces.AutoComplete.QueryAsync(request).Result;
            var results = response.Predictions.ToArray();
            var result = results.First();

            var request2 = new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = result.PlaceId
            };

            var response2 = GooglePlaces.Details.Query(request2);
            Assert.AreEqual(Status.Ok, response2.Status);
        }

        [Test]
        public void PlacesDetailsWhenAsyncAndCancelledTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = this.ApiKey,
                PlaceId = Guid.NewGuid().ToString("N")
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GooglePlaces.Details.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void PlacesDetailsWhenInvalidKeyTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = "test",
                PlaceId = "abc"
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Details.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerExceptions.FirstOrDefault();
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("RequestDenied: The provided API key is invalid.", innerException.Message);
        }

        [Test]
        public void PlacesDetailsWhenLanguageTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesDetailsWhenFieldsTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = ApiKey,
                Input = "jagtvej 2200 København"
            };

            var response = GooglePlaces.AutoComplete.Query(request);
            var request2 = new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault(),
                Fields = FieldTypes.Place_Id
            };

            var response2 = GooglePlaces.Details.Query(request2);
            Assert.IsNotNull(response2);
            Assert.AreEqual(Status.Ok, response2.Status);
            Assert.IsNotNull(response2.Result.PlaceId);

        }

        [Test]
        public void PlacesDetailsWhenExtensionsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesDetailsWhenKeyIsNullTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = null,
                PlaceId = "test"
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Details.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void PlacesDetailsWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = string.Empty,
                PlaceId = "test"
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Details.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void PlacesDetailsWhenPlaceIdIsNullTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = null
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Details.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "PlaceId is required");
        }

        [Test]
        public void PlacesDetailsWhenPlaceIdIsStringEmptyTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = string.Empty
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Details.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "PlaceId is required");
        }
    }
}