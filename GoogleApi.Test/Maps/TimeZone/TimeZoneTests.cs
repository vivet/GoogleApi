using System;
using System.Threading;
using System.Threading.Tasks;
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
        public void TimeZoneWhenAsyncAndTimeoutTest()
        {
            var location = new Location(40.7141289, -73.9614074);
            var request = new TimeZoneRequest
            {
                Location = location
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.TimeZone.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
                Assert.IsNull(result);
            });

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "One or more errors occurred.");

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(innerException.GetType(), typeof(TaskCanceledException));
            Assert.AreEqual(innerException.Message, "A task was canceled.");
        }

        [Test]
        public void TimeZoneWhenAsyncAndCancelledTest()
        {
            var location = new Location(40.7141289, -73.9614074);
            var request = new TimeZoneRequest
            {
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
                Location = location,
                Language = Language.German
            };

            var response = GoogleMaps.TimeZone.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("America/New_York", response.TimeZoneId);
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