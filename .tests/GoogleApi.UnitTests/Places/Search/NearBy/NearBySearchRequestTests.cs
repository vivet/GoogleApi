using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.NearBy.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Places.Search.NearBy
{
    [TestFixture]
    public class NearBySearchRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new PlacesNearBySearchRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.IsNull(request.Type);
            Assert.IsNull(request.Radius);
            Assert.IsNull(request.Location);
            Assert.IsNull(request.Minprice);
            Assert.IsNull(request.Maxprice);
            Assert.IsFalse(request.OpenNow);
            Assert.AreEqual(Language.English, request.Language);
            Assert.AreEqual(Ranking.Prominence, request.Rankby);
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new PlacesNearBySearchRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = "abc",
                Location = new Location(0, 0),
                Radius = 5000,
                Keyword = "test"
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = null,
                Location = new Location(0, 0),
                Radius = 5000,
                Keyword = "test"
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
            var request = new PlacesNearBySearchRequest
            {
                Key = string.Empty,
                Location = new Location(0, 0),
                Radius = 5000
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void GetQueryStringParametersWhenLocationIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = "abc",
                Location = null,
                Radius = 5000
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Location is required");
        }

        [Test]
        public void GetQueryStringParametersWhenRadiusIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = "abc",
                Location = new Location(0, 0),
                Radius = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Radius is required, when RankBy is not Distance");
        }

        [Test]
        public void GetQueryStringParametersWhenRadiusIsLessThanOneTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = "abc",
                Location = new Location(51.491431, -3.16668),
                Radius = 0
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000");
        }

        [Test]
        public void GetQueryStringParametersWhenRadiusIsGereaterThanFiftyThousandTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = "abc",
                Location = new Location(51.491431, -3.16668),
                Radius = 50001
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000");
        }

        [Test]
        public void GetQueryStringParametersWhenRankByDistanceAndRadiusIsNotNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = "abc",
                Location = new Location(51.491431, -3.16668),
                Radius = 5001,
                Rankby = Ranking.Distance
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Radius cannot be specified, when using RankBy distance");
        }

        [Test]
        public void GetQueryStringParametersWhenRankByDistanceAndNameIsNullAndKeywordIsNullAndTypeIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = "abc",
                Location = new Location(51.491431, -3.16668),
                Rankby = Ranking.Distance
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Keyword, Name or Type is required, If rank by distance");
        }

        [Test]
        public void GetUriTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = "abc",
                Location = new Location(1, 1),
                Radius = 50
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/nearbysearch/json?key={request.Key}&rankby={request.Rankby.ToString().ToLower()}&language={request.Language.ToCode()}&location={Uri.EscapeDataString(request.Location.ToString())}&radius={request.Radius}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenTypeTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = "abc",
                Location = new Location(1, 1),
                Radius = 50,
                Type = SearchPlaceType.Accounting 
            };

            var uri = request.GetUri();
            var attribute = request.Type?.GetType().GetMembers().FirstOrDefault(x => x.Name == request.Type.ToString())?.GetCustomAttribute<EnumMemberAttribute>();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/nearbysearch/json?key={request.Key}&rankby={request.Rankby.ToString().ToLower()}&language={request.Language.ToCode()}&location={Uri.EscapeDataString(request.Location.ToString())}&radius={request.Radius}&type={attribute?.Value.ToLower()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenOpenNowTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = "abc",
                Location = new Location(1, 1),
                Radius = 50,
                OpenNow = true
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/nearbysearch/json?key={request.Key}&rankby={request.Rankby.ToString().ToLower()}&language={request.Language.ToCode()}&location={Uri.EscapeDataString(request.Location.ToString())}&radius={request.Radius}&opennow", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenMinpriceTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = "abc",
                Location = new Location(1, 1),
                Radius = 50,
                Minprice = PriceLevel.Expensive
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/nearbysearch/json?key={request.Key}&rankby={request.Rankby.ToString().ToLower()}&language={request.Language.ToCode()}&location={Uri.EscapeDataString(request.Location.ToString())}&radius={request.Radius}&minprice={((int)request.Minprice.GetValueOrDefault()).ToString()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenMaxpriceTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = "abc",
                Location = new Location(1, 1),
                Radius = 50,
                Maxprice = PriceLevel.Free
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/nearbysearch/json?key={request.Key}&rankby={request.Rankby.ToString().ToLower()}&language={request.Language.ToCode()}&location={Uri.EscapeDataString(request.Location.ToString())}&radius={request.Radius}&maxprice={((int)request.Maxprice.GetValueOrDefault()).ToString()}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenPageTokenTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = "abc",
                PageToken = "abc"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/nearbysearch/json?key={request.Key}&pagetoken={request.PageToken}", uri.PathAndQuery);
        }
    }
}