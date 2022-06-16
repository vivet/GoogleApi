using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
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
            Assert.AreEqual(Language.English, request.Language);
            Assert.AreEqual(FieldTypes.Place_Id, request.Fields);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = "key",
                Input = "input"
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var key = queryStringParameters.FirstOrDefault(x => x.Key == "key");
            var keyExpected = request.Key;
            Assert.IsNotNull(key);
            Assert.AreEqual(keyExpected, key.Value);

            var input = queryStringParameters.FirstOrDefault(x => x.Key == "input");
            var inputExpected = request.Input;
            Assert.IsNotNull(input);
            Assert.AreEqual(inputExpected, input.Value);

            var type = queryStringParameters.FirstOrDefault(x => x.Key == "inputtype");
            Assert.IsNotNull(type);
            Assert.AreEqual("textquery", type.Value);

            var language = queryStringParameters.FirstOrDefault(x => x.Key == "language");
            Assert.IsNotNull(language);
            Assert.AreEqual("en", language.Value);

            var fields = queryStringParameters.FirstOrDefault(x => x.Key == "fields");
            Assert.IsNotNull(fields);
            Assert.AreEqual("place_id", fields.Value);

            var locationbias = queryStringParameters.FirstOrDefault(x => x.Key == "locationbias");
            Assert.IsNotNull(locationbias);
            Assert.AreEqual("ipbias", locationbias.Value);

        }

        [Test]
        public void GetQueryStringParametersWhenFieldsTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = "key",
                Input = "input",
                Fields = FieldTypes.Name | FieldTypes.Place_Id
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var fields = queryStringParameters.FirstOrDefault(x => x.Key == "fields");
            var requestedFields = Enum.GetValues(typeof(FieldTypes))
                .Cast<FieldTypes>()
                .Where(x => request.Fields.HasFlag(x) && x != FieldTypes.Basic && x != FieldTypes.Contact && x != FieldTypes.Atmosphere)
                .Aggregate(string.Empty, (current, x) => $"{current}{x.ToString().ToLowerInvariant()},");

            var fieldsExpected = requestedFields.EndsWith(",") ? requestedFields.Substring(0, requestedFields.Length -1) : requestedFields;
            Assert.IsNotNull(fields);
            Assert.AreEqual(fieldsExpected, fields.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenLocationTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = "key",
                Input = "input",
                Location = new Coordinate(1, 1)
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var locationbias = queryStringParameters.FirstOrDefault(x => x.Key == "locationbias");
            var locationbiasExpected = $"point:{request.Location}";
            Assert.IsNotNull(locationbias);
            Assert.AreEqual(locationbiasExpected, locationbias.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenLocationAndRadiusTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = "key",
                Input = "input",
                Location = new Coordinate(1, 1),
                Radius = 10
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var locationbias = queryStringParameters.FirstOrDefault(x => x.Key == "locationbias");
            var locationbiasExpected = $"circle:{request.Radius}@{request.Location}";
            Assert.IsNotNull(locationbias);
            Assert.AreEqual(locationbiasExpected, locationbias.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenBoundsTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = "key",
                Input = "input",
                Bounds = new ViewPort(new Coordinate(1, 1), new Coordinate(2, 2))
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var locationbias = queryStringParameters.FirstOrDefault(x => x.Key == "locationbias");
            var locationbiasExpected = $"rectangle:{request.Bounds.SouthWest}|{request.Bounds.NorthEast}";
            Assert.IsNotNull(locationbias);
            Assert.AreEqual(locationbiasExpected, locationbias.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "'Key' is required");
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "'Key' is required");
        }

        [Test]
        public void GetQueryStringParametersWhenInputIsNullTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = "key",
                Input = null
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "'Input' is required");
        }

        [Test]
        public void GetQueryStringParametersWhenInputIsStringEmptyTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = "key",
                Input = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "'Input' is required");
        }
    }
}