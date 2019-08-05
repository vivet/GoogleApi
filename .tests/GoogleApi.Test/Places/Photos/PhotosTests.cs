using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Photos.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Photos
{
    [TestFixture]
    public class PhotosTests : BaseTest
    {
        [Test]
        public void PlacesPhotosTest()
        {
            var response = GooglePlaces.AutoComplete.Query(new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "det kongelige teater"
            });

            var response2 = GooglePlaces.Details.Query(new PlacesDetailsRequest
            {
                Key = this.ApiKey,
                PlaceId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault()
            });

            var response3 = GooglePlaces.Photos.Query(new PlacesPhotosRequest
            {
                Key = this.ApiKey,
                PhotoReference = response2.Result.Photos.Select(x => x.PhotoReference).FirstOrDefault(),
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
            var response = GooglePlaces.AutoComplete.Query(new PlacesAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "det kongelige teater"
            });

            var response2 = GooglePlaces.Details.Query(new PlacesDetailsRequest
            {
                Key = this.ApiKey,
                PlaceId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault()
            });

            var response3 = GooglePlaces.Photos.QueryAsync(new PlacesPhotosRequest
            {
                Key = this.ApiKey,
                PhotoReference = response2.Result.Photos.Select(x => x.PhotoReference).FirstOrDefault(),
                MaxWidth = 1600
            }).Result;

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
            var task = GooglePlaces.Photos.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void PlacesPhotosWhenInvalidKeyTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = "test",
                PhotoReference = "abc",
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
        public void PlacesPhotosWhenMaxWidthTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesPhotosWhenMaxHeightTest()
        {
            Assert.Inconclusive();
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

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Photos.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
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

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Photos.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void PlacesPhotosWhenPhotoReferenceIsNullTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = this.ApiKey,
                PhotoReference = null
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Photos.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "PhotoReference is required");
        }

        [Test]
        public void PlacesPhotosWhenPhotoReferenceIsStringEmptyTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = this.ApiKey,
                PhotoReference = string.Empty
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Photos.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "PhotoReference is required");
        }

        [Test]
        public void PlacesPhotosWhenMaxHeightIsNullAndMaxWidthIsNullTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = this.ApiKey,
                PhotoReference = "abc"
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Photos.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "MaxHeight or MaxWidth is required");
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

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Photos.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "MaxHeight must be greater than or equal to 1 and less than or equal to 1.600");
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

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Photos.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "MaxHeight must be greater than or equal to 1 and less than or equal to 1.600");
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

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Photos.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "MaxWidth must be greater than or equal to 1 and less than or equal to 1.600");
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

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Photos.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "MaxWidth must be greater than or equal to 1 and less than or equal to 1.600");
        }
    }
}
