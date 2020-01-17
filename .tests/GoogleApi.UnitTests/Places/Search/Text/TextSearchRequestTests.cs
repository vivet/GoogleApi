using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.Text.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Places.Search.Text
{
    [TestFixture]
    public class TextSearchRequestTests
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
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new PlacesTextSearchRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = "abc",
                Query = "test"
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
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
                Key = "abc",
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
                Key = "abc",
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
                Key = "abc",
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
        public void GetUriTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = "abc",
                Query = "test"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/textsearch/json?key={request.Key}&query={request.Query}&language={request.Language.ToCode()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenLocationTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = "abc",
                Query = "test",
                Location = new Location(1, 1),
                Radius = 50
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/textsearch/json?key={request.Key}&query={request.Query}&language={request.Language.ToCode()}&location={Uri.EscapeDataString(request.Location.ToString())}&radius={request.Radius}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenRadiusTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = "abc",
                Query = "test",
                Radius = 50
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/textsearch/json?key={request.Key}&query={request.Query}&language={request.Language.ToCode()}&radius={request.Radius}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenTypeTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = "abc",
                Query = "test",
                Type = SearchPlaceType.Accounting
            };

            var uri = request.GetUri();
            var attribute = request.Type?.GetType().GetMembers().FirstOrDefault(x => x.Name == request.Type.ToString())?.GetCustomAttribute<EnumMemberAttribute>();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/textsearch/json?key={request.Key}&query={request.Query}&language={request.Language.ToCode()}&type={attribute?.Value.ToLower()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenOpenNowTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = "abc",
                Query = "test",
                OpenNow = true
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/textsearch/json?key={request.Key}&query={request.Query}&language={request.Language.ToCode()}&opennow", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenMinpriceTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = "abc",
                Query = "test",
                Minprice = PriceLevel.Expensive
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/textsearch/json?key={request.Key}&query={request.Query}&language={request.Language.ToCode()}&minprice={((int)request.Minprice.GetValueOrDefault()).ToString()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenMaxpriceTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = "abc",
                Query = "test",
                Maxprice = PriceLevel.Free 
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/textsearch/json?key={request.Key}&query={request.Query}&language={request.Language.ToCode()}&maxprice={((int)request.Minprice.GetValueOrDefault()).ToString()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenPageTokenTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = "abc",
                PageToken = "abc"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/textsearch/json?key={request.Key}&pagetoken={request.PageToken}", uri.PathAndQuery);
        }
    }
}