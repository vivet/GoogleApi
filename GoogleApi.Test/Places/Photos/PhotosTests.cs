using System;
using System.Linq;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Photos.Request;
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
