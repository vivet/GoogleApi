using System;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using GoogleApi.Entities.Maps.TimeZone.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps
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
            Assert.AreEqual("GMT-05:00", response.TimeZoneName);
            Assert.AreEqual(0.00, response.OffSet);
            Assert.AreEqual(-18000.00, response.RawOffSet);
        }
        [Test]
        public void TimeZoneWhenLanguageTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void TimeZoneWhenLocationIsNullTest()
        {
            var request = new TimeZoneRequest();

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.TimeZone.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Location is required.");
        }

        [Test]
        public void TimeZoneAsyncTest()
        {
            var location = new Location(40.7141289, -73.9614074);
            var request = new TimeZoneRequest { Location = location };
            var response = GoogleMaps.TimeZone.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("America/New_York", response.TimeZoneId);
            Assert.AreEqual("GMT-05:00", response.TimeZoneName);
            Assert.AreEqual(0.00, response.OffSet);
            Assert.AreEqual(-18000.00, response.RawOffSet);
        }
        [Test]
        public void TimeZoneAsyncWhenTimeoutTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(40.7141289, -73.9614074), },
                Destinations = new[] { new AddressLocation("185 Broadway Ave, Manhattan, NY, USA") }
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.DistanceMatrix.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void TimeZoneAsyncCancelledTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(40.7141289, -73.9614074), },
                Destinations = new[] { new AddressLocation("185 Broadway Ave, Manhattan, NY, USA") }
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.DistanceMatrix.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }
    }
}