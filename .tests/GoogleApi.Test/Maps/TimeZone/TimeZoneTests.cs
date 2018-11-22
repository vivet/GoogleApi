using System;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.TimeZone.Request;
using GoogleApi.Exceptions;
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
                Key = this.ApiKey,
                Location = location
            };

            var response = GoogleMaps.TimeZone.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("America/New_York", response.TimeZoneId);
            Assert.IsNotNull(response.TimeZoneName);
            Assert.IsNotNull(response.OffSet);
            Assert.IsNotNull(response.RawOffSet);
        }

        [Test]
        public void TimeZoneWhenAsyncTest()
        {
            var location = new Location(40.7141289, -73.9614074);
            var request = new TimeZoneRequest
            {
                Key = this.ApiKey,
                Location = location
            };

            var response = GoogleMaps.TimeZone.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("America/New_York", response.TimeZoneId);
            Assert.IsNotNull(response.TimeZoneName);
            Assert.IsNotNull(response.OffSet);
            Assert.IsNotNull(response.RawOffSet);
        }

        [Test]
        public void TimeZoneWhenAsyncAndCancelledTest()
        {
            var location = new Location(40.7141289, -73.9614074);
            var request = new TimeZoneRequest
            {
                Key = this.ApiKey,
                Location = location
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.TimeZone.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void TimeZoneWhenLanguageTest()
        {
            var location = new Location(40.7141289, -73.9614074);
            var request = new TimeZoneRequest
            {
                Key = this.ApiKey,
                Location = location,
                Language = Language.German
            };

            var response = GoogleMaps.TimeZone.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("America/New_York", response.TimeZoneId);
            Assert.IsNotNull(response.TimeZoneName);
        }

        [Test]
        public void TimeZoneWhenTimeStampTest()
        {
            var location = new Location(40.7141289, -73.9614074);
            var request = new TimeZoneRequest
            {
                Key = this.ApiKey,
                Location = location,
                TimeStamp = DateTime.Now.AddMonths(6)
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
        public void TimeZoneWhenLocationIsNullTest()
        {
            var request = new TimeZoneRequest
            {
                Key = this.ApiKey
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.TimeZone.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Location is required");
        }
    }
}