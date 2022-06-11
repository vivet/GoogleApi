using System;
using System.Linq;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Maps.Geocoding.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Location.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.Geocoding.Location
{
    [TestFixture]
    public class GeocodingLocationRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new LocationGeocodeRequest();
            Assert.AreEqual(Language.English, request.Language);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = "key",
                Location = new Coordinate(1, 1)
            };

            var queryStringParameters = request.GetQueryStringParameters();

            var key = queryStringParameters.SingleOrDefault(x => x.Key == "key");
            var keyExpected = request.Key;
            Assert.IsNotNull(key);
            Assert.AreEqual(keyExpected, key.Value);

            var language = queryStringParameters.SingleOrDefault(x => x.Key == "language");
            var languageExpected = request.Language.ToCode();
            Assert.IsNotNull(language);
            Assert.AreEqual(languageExpected, language.Value);

            var location = queryStringParameters.SingleOrDefault(x => x.Key == "latlng");
            var locationExpected = request.Location.ToString();
            Assert.IsNotNull(location);
            Assert.AreEqual(locationExpected, location.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenChannelTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = "key",
                Location = new Coordinate(1, 1),
                Channel = "channel"
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var channel = queryStringParameters.FirstOrDefault(x => x.Key == "channel");
            var channelExpected = request.Channel;
            Assert.IsNotNull(channel);
            Assert.AreEqual(channelExpected, channel.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenResultTypeTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = "key",
                Location = new Coordinate(1, 1),
                ResultTypes = new[]
                {
                    PlaceLocationType.Accounting,
                    PlaceLocationType.Administrative_Area_Level_1 
                }
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var resultType = queryStringParameters.SingleOrDefault(x => x.Key == "result_type");
            var resultTypeExpected = string.Join("|", request.ResultTypes.Select(x => x.ToString().ToLower()));
            Assert.IsNotNull(resultType);
            Assert.AreEqual(resultTypeExpected, resultType.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenLocationTypeTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = "key",
                Location = new Coordinate(1, 1),
                LocationTypes = new[]
                {
                    GeometryLocationType.Rooftop
                }
            };

            var queryStringParameters = request.GetQueryStringParameters();
            Assert.IsNotNull(queryStringParameters);

            var locationType = queryStringParameters.SingleOrDefault(x => x.Key == "location_type");
            var locationTypeExpected = string.Join("|", request.LocationTypes.Select(x => x.ToString().ToUpper()));
            Assert.IsNotNull(locationType);
            Assert.AreEqual(locationTypeExpected, locationType.Value);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsNullTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = null
            };

            var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
            Assert.IsNotNull(exception);
            Assert.AreEqual("'Key' is required", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersWhenKeyIsEmptyTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => request.GetQueryStringParameters());
            Assert.IsNotNull(exception);
            Assert.AreEqual("'Key' is required", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersWhenLocationIsNullTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = "key"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "'Location' is required");
        }
    }
}