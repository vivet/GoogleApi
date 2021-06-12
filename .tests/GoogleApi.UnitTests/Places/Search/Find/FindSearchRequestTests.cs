using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Places.Search.Find.Request;
using GoogleApi.Entities.Places.Search.Find.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Places.Search.Find
{
    [TestFixture]
    public class FindSearchRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new PlacesFindSearchRequest();

            Assert.AreEqual(InputType.TextQuery, request.Type);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = "abc",
                Location = new Coordinate(0, 0),
                Input = "test"
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = null,
                Location = new Coordinate(0, 0),
                Input = "test"
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
            var request = new PlacesFindSearchRequest
            {
                Key = string.Empty,
                Location = new Coordinate(0, 0),
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
        public void GetQueryStringParametersWhenInputIsNullTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = "abc",
                Input = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.AreEqual(exception.Message, "Input is required");
        }

        [Test]
        public void GetUriTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = "abc",
                Input = "test"
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/findplacefromtext/json?key={request.Key}&input={request.Input}&inputtype={request.Type.ToString().ToLower()}&fields=place_id&language={request.Language.ToCode()}&locationbias=ipbias", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenLocationTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = "abc",
                Input = "test",
                Location = new Coordinate(1, 1)
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/findplacefromtext/json?key={request.Key}&input={request.Input}&inputtype={request.Type.ToString().ToLower()}&fields=place_id&language={request.Language.ToCode()}&locationbias=point%3A{Uri.EscapeDataString(request.Location.ToString())}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenLocationAndRadiusTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = "abc",
                Input = "test",
                Location = new Coordinate(1, 1),
                Radius = 50
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/findplacefromtext/json?key={request.Key}&input={request.Input}&inputtype={request.Type.ToString().ToLower()}&fields=place_id&language={request.Language.ToCode()}&locationbias=circle%3A{request.Radius}%40{Uri.EscapeDataString(request.Location.ToString())}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenBoundsTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = "abc",
                Input = "test",
                Bounds = new ViewPort
                {
                    NorthEast = new Coordinate(1, 1),
                    SouthWest = new Coordinate(2, 2)
                }
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/findplacefromtext/json?key={request.Key}&input={request.Input}&inputtype={request.Type.ToString().ToLower()}&fields=place_id&language={request.Language.ToCode()}&locationbias=rectangle%3A{Uri.EscapeDataString(request.Bounds.SouthWest.ToString())}%7C{Uri.EscapeDataString(request.Bounds.NorthEast.ToString())}", uri.PathAndQuery);
        }

        [Test]
        public void GetUriWhenFieldsTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = "abc",
                Input = "test",
                Fields = FieldTypes.Name
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/place/findplacefromtext/json?key={request.Key}&input={request.Input}&inputtype={request.Type.ToString().ToLower()}&fields=name&language={request.Language.ToCode()}&locationbias=ipbias", uri.PathAndQuery);
        }
    }
}