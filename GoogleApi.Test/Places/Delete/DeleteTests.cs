using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Add.Request;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Delete.Request;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Delete
{
    [TestFixture]
    public class DeleteTests : BaseTest
    {
        [Test]
        public void PlacesDeleteTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = Guid.NewGuid().ToString("N"),
                Types = new[] {PlaceLocationType.Street_Address},
                Location = new Location(55.664425, 12.502264)
            };

            var response = GooglePlaces.Add.Query(request);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.PlaceId);

            var request2 = new PlacesDeleteRequest
            {
                Key = this.ApiKey,
                PlaceId = response.PlaceId
            };

            var response2 = GooglePlaces.Delete.Query(request2);
            Assert.IsNotNull(response2);
            Assert.AreEqual(response2.Status, Status.Ok);

            var request3 = new PlacesDetailsRequest
            {
                Key = this.ApiKey,
                PlaceId = response.PlaceId
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Details.Query(request3));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerExceptions.FirstOrDefault() as GoogleApiException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("Exception of type 'GoogleApi.Exceptions.GoogleApiException' was thrown.", innerException.Message);
        }

        [Test]
        public void PlacesDeleteWhenAsyncTest()
        {
            var request = new PlacesAddRequest
            {
                Key = this.ApiKey,
                Name = Guid.NewGuid().ToString("N"),
                Types = new[] {PlaceLocationType.Street_Address},
                Location = new Location(55.664425, 12.502264)
            };

            var response = GooglePlaces.Add.Query(request);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.PlaceId);

            var request2 = new PlacesDeleteRequest
            {
                Key = this.ApiKey,
                PlaceId = response.PlaceId
            };

            var response2 = GooglePlaces.Delete.QueryAsync(request2).Result;
            Assert.IsNotNull(response2);
            Assert.AreEqual(response2.Status, Status.Ok);
        }

        [Test]
        public void PlacesDeleteWhenAsyncAndTimeoutTest()
        {
            var request = new PlacesDeleteRequest
            {
                Key = this.ApiKey,
                PlaceId = Guid.NewGuid().ToString("N")
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GooglePlaces.Delete.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void PlacesDeleteWhenAsyncAndCancelledTest()
        {
            var request = new PlacesDeleteRequest
            {
                Key = this.ApiKey,
                PlaceId = Guid.NewGuid().ToString("N")
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GooglePlaces.Delete.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void PlacesDeleteWhenInvalidKeyTest()
        {
            var request = new PlacesDeleteRequest
            {
                Key = "test",
                PlaceId = "abc"
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Delete.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerExceptions.FirstOrDefault();
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("The provided API key is invalid.", innerException.Message);
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
            Assert.AreEqual(exception.Message, "Key is required");
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
            Assert.AreEqual(exception.Message, "Key is required");
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
            Assert.AreEqual(exception.Message, "PlaceId is required");
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
            Assert.AreEqual(exception.Message, "PlaceId is required");
        }
    }
}