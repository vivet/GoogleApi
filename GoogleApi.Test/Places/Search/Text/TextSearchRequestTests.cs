using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Search.Text.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Search.Text
{
    [TestFixture]
    public class TextSearchRequestTests : BaseTest
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new PlacesTextSearchRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.IsNull(request.Type);
            Assert.IsNull(request.Radius);
            Assert.IsNull(request.Location);
            Assert.IsNull(request.Minprice);
            Assert.IsNull(request.Maxprice);
            Assert.IsFalse(request.OpenNow);
            Assert.AreEqual(Language.English, request.Language);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = null,
                Query = "test"
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
            var request = new PlacesTextSearchRequest
            {
                Key = string.Empty,
                Query = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenQueryIsNullTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Query is required");
        }

        [Test]
        public void GetQueryStringParametersWhenQueryIsStringEmptyTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Query is required");
        }

        [Test]
        public void GetQueryStringParametersWhenLocationAndRadiusIsNullTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = "picadelly circus",
                Location = new Location(0, 0)
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Radius is required when Location is specified");
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new PlacesTextSearchRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }
    }
}