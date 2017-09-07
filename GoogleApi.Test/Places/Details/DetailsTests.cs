using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Details.Request;
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
            Assert.IsEmpty(response2.HtmlAttributions);
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
            Assert.AreEqual(Scope.Google, result.Scope);
            Assert.Contains(PlaceLocationType.Route, result.Types.ToArray());

            var formattedAddress = result.FormattedAddress.ToLower();
            Assert.IsNotNull(formattedAddress);
            Assert.IsTrue(formattedAddress.Contains("jagtvej"));
            Assert.IsTrue(formattedAddress.Contains("københavn"));

            var addressComponents = result.AddressComponents?.ToArray();
            Assert.IsNotNull(addressComponents);
            Assert.AreEqual(3, addressComponents.Length);

            Assert.AreEqual("Jagtvej", addressComponents[0].LongName);
            Assert.AreEqual("Jagtvej", addressComponents[0].ShortName);
            Assert.Contains(AddressComponentType.Route, addressComponents[0].Types.ToArray());

            Assert.AreEqual("København", addressComponents[1].LongName);
            Assert.AreEqual("København", addressComponents[1].ShortName);
            Assert.Contains(AddressComponentType.Locality, addressComponents[1].Types.ToArray());
            Assert.Contains(AddressComponentType.Political, addressComponents[1].Types.ToArray());

            Assert.AreEqual("Denmark", addressComponents[2].LongName);
            Assert.AreEqual("DK", addressComponents[2].ShortName);
            Assert.Contains(AddressComponentType.Country, addressComponents[2].Types.ToArray());
            Assert.Contains(AddressComponentType.Political, addressComponents[2].Types.ToArray());
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
        public void PlacesDetailsWhenAsyncAndTimeoutTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = this.ApiKey,
                PlaceId = Guid.NewGuid().ToString("N")
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GooglePlaces.Details.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
                Assert.IsNull(result);
            });

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "One or more errors occurred.");

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(innerException.GetType(), typeof(TaskCanceledException));
            Assert.AreEqual(innerException.Message, "A task was canceled.");
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

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Details.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerExceptions.FirstOrDefault();
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("The provided API key is invalid.", innerException.Message);
        }

        [Test]
        public void PlacesDetailsWhenLanguageTest()
        {
            Assert.Inconclusive();
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

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.Details.Query(request));
            Assert.AreEqual(exception.Message, "Key is required");
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
            Assert.AreEqual(exception.Message, "Key is required");
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
            Assert.AreEqual(exception.Message, "PlaceId is required");
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
            Assert.AreEqual(exception.Message, "PlaceId is required");
        }
    }
}