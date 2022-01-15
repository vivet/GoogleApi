using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Photos.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;

namespace GoogleApi.Test.Places.Photos
{
    [TestFixture]
    public class PhotosTests : BaseTest<GooglePlaces.DetailsApi>
    {
        protected override GooglePlaces.DetailsApi GetClient() => new(_httpClient);
        protected override GooglePlaces.DetailsApi GetClientStatic() => GooglePlaces.Details;

        private GooglePlaces.PhotosApi GetPhotoApi()
        {
            if (Settings.UseGlobalStaticHttpClients)
                return GooglePlaces.Photos;

            return new GooglePlaces.PhotosApi(_httpClient);
        }

        private GooglePlaces.AutoCompleteApi GetAutoCompleteApi()
        {
            if (Settings.UseGlobalStaticHttpClients)
                return GooglePlaces.AutoComplete;

            return new GooglePlaces.AutoCompleteApi(_httpClient);
        }

        [Test]
        public void PlacesPhotosTest()
        {
            var response = GetAutoCompleteApi().Query(new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "det kongelige teater"
            });

            var placeId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault();
            var response2 = Sut.Query(new PlacesDetailsRequest
            {
                Key = this.ApiKey,
                PlaceId = placeId
            });

            var photoReference = response2.Result.Photos.Select(x => x.PhotoReference).FirstOrDefault();
            var response3 = GetPhotoApi().Query(new PlacesPhotosRequest
            {
                Key = this.ApiKey,
                PhotoReference = photoReference,
                MaxWidth = 1600
            });

            Assert.IsNotNull(response3);
            Assert.IsNotNull(response3.Stream);
            Assert.IsNotNull(response3.Buffer);
            Assert.AreEqual(Status.Ok, response3.Status);
            Assert.GreaterOrEqual(response3.Stream.Length, 1000);
        }

        [Test]
        public void PlacesPhotosAsyncTest()
        {
            var response = GetAutoCompleteApi().Query(new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "det kongelige teater"
            });

            var placeId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault();
            var response2 = Sut.Query(new PlacesDetailsRequest
            {
                Key = this.ApiKey,
                PlaceId = placeId
            });

            var photoReference = response2.Result.Photos.Select(x => x.PhotoReference).FirstOrDefault();
            var response3 = GetPhotoApi().Query(new PlacesPhotosRequest
            {
                Key = this.ApiKey,
                PhotoReference = photoReference,
                MaxWidth = 1600
            });

            Assert.IsNotNull(response3);
            Assert.IsNotNull(response3.Stream);
            Assert.AreEqual(Status.Ok, response3.Status);
        }

        [Test]
        public void PlacesPhotosWhenAsyncAndCancelledTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = this.ApiKey,
                PhotoReference = Guid.NewGuid().ToString("N"),
                MaxWidth = 1600
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GetPhotoApi().QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual("The operation was canceled.", exception.Message);
        }

        [Test]
        public void PlacesPhotosWhenInvalidKeyTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = "test",
                PhotoReference = "photoReference",
                MaxWidth = 1600
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Photos.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerExceptions.FirstOrDefault();
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException).ToString(), innerException.GetType().ToString());
            Assert.AreEqual("Response status code does not indicate success: 403 (Forbidden).", innerException.Message);
        }

        [Test]
#pragma warning disable S4144 // Methods should not have identical implementations
        public void PlacesPhotosWhenMaxWidthTest()
        {
            var response = GetAutoCompleteApi().Query(new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "det kongelige teater"
            });

            var placeId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault();
            var response2 = Sut.Query(new PlacesDetailsRequest
            {
                Key = this.ApiKey,
                PlaceId = placeId
            });

            var photoReference = response2.Result.Photos.Select(x => x.PhotoReference).FirstOrDefault();
            var response3 = GetPhotoApi().Query(new PlacesPhotosRequest
            {
                Key = this.ApiKey,
                PhotoReference = photoReference,
                MaxWidth = 1600
            });

            Assert.IsNotNull(response3);
            Assert.IsNotNull(response3.Stream);
            Assert.AreEqual(Status.Ok, response3.Status);
        }
#pragma warning restore S4144 // Methods should not have identical implementations

        [Test]
        public void PlacesPhotosWhenMaxHeightTest()
        {
            var response = GetAutoCompleteApi().Query(new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "det kongelige teater"
            });

            var placeId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault();
            var response2 = Sut.Query(new PlacesDetailsRequest
            {
                Key = this.ApiKey,
                PlaceId = placeId
            });

            var photoReference = response2.Result.Photos.Select(x => x.PhotoReference).FirstOrDefault();
            var response3 = GetPhotoApi().Query(new PlacesPhotosRequest
            {
                Key = this.ApiKey,
                PhotoReference = photoReference,
                MaxHeight = 1600
            });

            Assert.IsNotNull(response3);
            Assert.IsNotNull(response3.Stream);
            Assert.AreEqual(Status.Ok, response3.Status);
        }
    }
}
