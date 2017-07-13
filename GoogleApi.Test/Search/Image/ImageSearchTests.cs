using System;
using GoogleApi.Entities.Search.Image.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Search.Image
{
    [TestFixture]
    public class ImageSearchTests : BaseTest
    {
        [Test]
        public void ImageSearchTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void ImageSearchWhenImageTypeTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void ImageSearchWhenImageSizeTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void ImageSearchWhenImageColorTypeTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void ImageSearchWhenImageDominantColorTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void ImageSearchWhenKeyIsNullTest()
        {
            var request = new ImageSearchRequest
            {
                Key = null,
                SearchEngineId = "abc",
                Query = "google"
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleSearch.ImageSearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void ImageSearchWhenSearchEngineIdIsNullTest()
        {
            var request = new ImageSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = null,
                Query = "google"
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleSearch.ImageSearch.Query(request));
            Assert.AreEqual(exception.Message, "SearchEngineId is required.");
        }
        [Test]
        public void ImageSearchWhenQueryIsNullTest()
        {
            var request = new ImageSearchRequest
            {
                Key = this.ApiKey,
                SearchEngineId = "abc",
                Query = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleSearch.ImageSearch.Query(request));
            Assert.AreEqual(exception.Message, "Query is required.");
        }

        [Test]
        public void ImageSearchAsyncTest()
        {
            Assert.Inconclusive();
        }
    }
}