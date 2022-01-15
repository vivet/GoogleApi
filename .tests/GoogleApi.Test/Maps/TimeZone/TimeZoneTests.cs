using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.TimeZone.Request;
using NUnit.Framework;
using System;
using System.Threading;

namespace GoogleApi.Test.Maps.TimeZone
{
    [TestFixture]
    public class TimeZoneTests : BaseTest<GoogleMaps.TimeZoneApi>
    {
        protected override GoogleMaps.TimeZoneApi GetClient() => new(_httpClient);
        protected override GoogleMaps.TimeZoneApi GetClientStatic() => GoogleMaps.TimeZone;

        [Test]
        public void TimeZoneTest()
        {
            var location = new Coordinate(40.7141289, -73.9614074);
            var request = new TimeZoneRequest
            {
                Key = this.ApiKey,
                Location = location
            };

            var response = Sut.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void TimeZoneWhenLanguageTest()
        {
            var location = new Coordinate(40.7141289, -73.9614074);
            var request = new TimeZoneRequest
            {
                Key = this.ApiKey,
                Location = location,
                Language = Language.German
            };

            var response = Sut.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void TimeZoneWhenTimeStampTest()
        {
            var location = new Coordinate(40.7141289, -73.9614074);
            var request = new TimeZoneRequest
            {
                Key = this.ApiKey,
                Location = location,
                TimeStamp = DateTime.Now.AddMonths(6)
            };

            var response = Sut.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void TimeZoneWhenAsyncTest()
        {
            var location = new Coordinate(40.7141289, -73.9614074);
            var request = new TimeZoneRequest
            {
                Key = this.ApiKey,
                Location = location
            };

            var response = Sut.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void TimeZoneWhenAsyncAndCancelledTest()
        {
            var location = new Coordinate(40.7141289, -73.9614074);
            var request = new TimeZoneRequest
            {
                Key = this.ApiKey,
                Location = location
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = Sut.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual("The operation was canceled.", exception.Message);
        }
    }
}