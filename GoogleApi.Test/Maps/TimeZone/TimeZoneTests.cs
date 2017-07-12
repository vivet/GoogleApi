using System;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.TimeZone.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.TimeZone
{
    [TestFixture]
    public class TimeZoneTests : BaseTest
    {
        [Test]
        public void TimeZoneTest()
        {
            var location = new Location(40.7141289, -73.9614074);
            var request = new TimeZoneRequest
            {
                Location = location
            };

            var response = GoogleMaps.TimeZone.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("America/New_York", response.TimeZoneId);
            Assert.AreEqual("Eastern Daylight Time", response.TimeZoneName);
            Assert.AreEqual(3600.00, response.OffSet);
            Assert.AreEqual(-18000.00, response.RawOffSet);
        }

        [Test]
        public void TimeZoneAsyncTest()
        {
            var location = new Location(40.7141289, -73.9614074);
            var request = new TimeZoneRequest
            {
                Location = location
            };

            var response = GoogleMaps.TimeZone.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("America/New_York", response.TimeZoneId);
            Assert.AreEqual("Eastern Daylight Time", response.TimeZoneName);
            Assert.AreEqual(3600.00, response.OffSet);
            Assert.AreEqual(-18000.00, response.RawOffSet);
        }

        [Test]
        public void TimeZoneWhenLanguageTest()
        {
            var location = new Location(40.7141289, -73.9614074);
            var request = new TimeZoneRequest
            {
                Location = location,
                Language = Language.German
            };

            var response = GoogleMaps.TimeZone.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("America/New_York", response.TimeZoneId);
            Assert.AreEqual("Nordamerikanische Ostküsten-Sommerzeit", response.TimeZoneName);
            Assert.AreEqual(3600.00, response.OffSet);
            Assert.AreEqual(-18000.00, response.RawOffSet);
        }

        [Test]
        public void TimeZoneWhenTimeStampTest()
        {
            var location = new Location(40.7141289, -73.9614074);
            var request = new TimeZoneRequest
            {
                Location = location,
                TimeStamp = DateTime.Now.AddMonths(6)
            };

            var response = GoogleMaps.TimeZone.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("America/New_York", response.TimeZoneId);
            Assert.AreEqual("Eastern Standard Time", response.TimeZoneName);
            Assert.AreEqual(0.00, response.OffSet);
            Assert.AreEqual(-18000.00, response.RawOffSet);
        }

        [Test]
        public void TimeZoneWhenLocationIsNullTest()
        {
            var request = new TimeZoneRequest
            {
                Key = this.ApiKey
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.TimeZone.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Location is required");
        }
    }
}