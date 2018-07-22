using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Maps.TimeZone.Request;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Maps.TimeZone
{
    [TestFixture]
    public class TimeZoneRequestTests
    {
        [Test]
        public void ConstructorDefaultTest()
        {
            var request = new TimeZoneRequest();

            Assert.IsTrue(request.IsSsl);
            Assert.IsNotNull(request.TimeStamp);
            Assert.AreEqual(Language.English, request.Language);
        }

        [Test]
        public void SetIsSslTest()
        {
            var exception = Assert.Throws<NotSupportedException>(() => new TimeZoneRequest
            {
                IsSsl = false
            });
            Assert.AreEqual("This operation is not supported, Request must use SSL", exception.Message);
        }

        [Test]
        public void GetQueryStringParametersTest()
        {
            var request = new TimeZoneRequest
            {
                Key = "abc",
                Location = new Location(40.7141289, -73.9614074)
            };

            Assert.DoesNotThrow(() => request.GetQueryStringParameters());
        }

        [Test]
        public void GetQueryStringParametersWhenLocationIsNullTest()
        {
            var request = new TimeZoneRequest
            {
                Key = "abc"
            };

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                var parameters = request.GetQueryStringParameters();
                Assert.IsNull(parameters);
            });
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Location is required");
        }

        [Test]
        public void GetUriTest()
        {
            var request = new TimeZoneRequest
            {
                Key = "abc",
                Location = new Location(40.7141289, -73.9614074)
            };

            var uri = request.GetUri();

            Assert.IsNotNull(uri);
            Assert.AreEqual($"/maps/api/timezone/json?key={request.Key}&language={request.Language.ToCode()}&location={Uri.EscapeDataString(request.Location.ToString())}&timestamp={request.TimeStamp.DateTimeToUnixTimestamp()}", uri.PathAndQuery);
        }
    }
}