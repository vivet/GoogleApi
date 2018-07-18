using System;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.Photos.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Places.Photos
{
    [TestFixture]
    public class PhotosRequestTests 
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new PlacesAutoCompleteRequest();

            Assert.IsTrue(request.IsSsl);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = null,
                PhotoReference = "test",
                MaxHeight = 10
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = string.Empty,
                PhotoReference = "test",
                MaxHeight = 10
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenPhotoReferenceIsNullTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = "abc",
                PhotoReference = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "PhotoReference is required");
        }

        [Test]
        public void GetQueryStringParametersWhenPhotoReferenceIsStringEmptyTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = "abc",
                PhotoReference = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "PhotoReference is required");
        }

        [Test]
        public void GetQueryStringParametersWhenMaxHeightIsNullAndMaxWidthIsNullTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = "abc",
                PhotoReference = "abc"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "MaxHeight or MaxWidth is required");
        }

        [Test]
        public void GetQueryStringParametersWhenMaxHeightIsLessThanOneTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = "abc",
                PhotoReference = "abc",
                MaxHeight = 0
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "MaxHeight must be greater than or equal to 1 and less than or equal to 1.600");
        }

        [Test]
        public void GetQueryStringParametersWhenMaxHeightIsGreaterThanSexteenHundredthsTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = "abc",
                PhotoReference = "abc",
                MaxHeight = 1601
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "MaxHeight must be greater than or equal to 1 and less than or equal to 1.600");
        }

        [Test]
        public void GetQueryStringParametersWhenMaxWidthIsLessThanOneTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = "abc",
                PhotoReference = "abc",
                MaxWidth = 0
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "MaxWidth must be greater than or equal to 1 and less than or equal to 1.600");
        }

        [Test]
        public void GetQueryStringParametersWhenMaxWidthIsGreaterThanSexteenHundredthsTest()
        {
            var request = new PlacesPhotosRequest
            {
                Key = "abc",
                PhotoReference = "abc",
                MaxWidth = 1601
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "MaxWidth must be greater than or equal to 1 and less than or equal to 1.600");
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new PlacesPhotosRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }
    }
}