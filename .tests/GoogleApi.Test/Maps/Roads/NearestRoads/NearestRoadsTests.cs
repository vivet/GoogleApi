using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Roads.NearestRoads
{
    [TestFixture]
    public class NearestRoadsTests : BaseTest
    {
        [Test]
        public void NearestRoadsTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = this.ApiKey,
                Points = new[]
                {
                    new Location(60.170880, 24.942795),
                    new Location(60.170879, 24.942796),
                    new Location(60.170877, 24.942796)
                }
            };

            var result = GoogleMaps.NearestRoads.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var snappedPoints = result.SnappedPoints?.ToArray();
            Assert.IsNotNull(snappedPoints);
            Assert.AreEqual(3, snappedPoints.Length);

            Assert.AreEqual(0, snappedPoints[0].OriginalIndex);
            Assert.AreEqual(60.170877918672588, snappedPoints[0].Location.Latitude, 0.0001);
            Assert.AreEqual(24.942699821922421, snappedPoints[0].Location.Longitude, 0.0001);

            Assert.AreEqual(1, snappedPoints[1].OriginalIndex);
            Assert.AreEqual(60.170876898776406, snappedPoints[1].Location.Latitude, 0.0001);
            Assert.AreEqual(24.942699912064771, snappedPoints[1].Location.Longitude, 0.0001);

            Assert.AreEqual(2, snappedPoints[2].OriginalIndex);
            Assert.AreEqual(60.170874902634374, snappedPoints[2].Location.Latitude, 0.0001);
            Assert.AreEqual(24.942700088491474, snappedPoints[2].Location.Longitude, 0.0001);
        }

        [Test]
        public void NearestRoadsWhenAsyncTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = this.ApiKey,
                Points = new[]
                {
                    new Location(60.170880, 24.942795),
                    new Location(60.170879, 24.942796),
                    new Location(60.170877, 24.942796)
                }
            };
            var result = GoogleMaps.NearestRoads.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var snappedPoints = result.SnappedPoints?.ToArray();
            Assert.IsNotNull(snappedPoints);
            Assert.AreEqual(3, snappedPoints.Length);

            Assert.AreEqual(0, snappedPoints[0].OriginalIndex);
            Assert.AreEqual(60.170877918672588, snappedPoints[0].Location.Latitude, 0.0001);
            Assert.AreEqual(24.942699821922421, snappedPoints[0].Location.Longitude, 0.0001);

            Assert.AreEqual(1, snappedPoints[1].OriginalIndex);
            Assert.AreEqual(60.170876898776406, snappedPoints[1].Location.Latitude, 0.0001);
            Assert.AreEqual(24.942699912064771, snappedPoints[1].Location.Longitude, 0.0001);

            Assert.AreEqual(2, snappedPoints[2].OriginalIndex);
            Assert.AreEqual(60.170874902634374, snappedPoints[2].Location.Latitude, 0.0001);
            Assert.AreEqual(24.942700088491474, snappedPoints[2].Location.Longitude, 0.0001);
        }

        [Test]
        public void NearestRoadsWhenAsyncAndCancelledTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = this.ApiKey,
                Points = new[] { new Location(0, 0) }
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.NearestRoads.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void NearestRoadsWhenInvalidKeyTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = "test",
                Points = new[]
                {
                    new Location(60.170880, 24.942795),
                    new Location(60.170879, 24.942796),
                    new Location(60.170877, 24.942796)
                }
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.NearestRoads.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerExceptions.FirstOrDefault();
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException).ToString(), innerException.GetType().ToString());
            Assert.AreEqual("Response status code does not indicate success: 400 (Bad Request).", innerException.Message);
        }

        [Test]
        public void NearestRoadsWhenKeyIsNullTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = null,
                Points = new[] { new Location(0, 0) }
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.NearestRoads.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void NearestRoadsWhenKeyIsStringEmptyTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = string.Empty,
                Points = new[] { new Location(0, 0) }
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.NearestRoads.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void NearestRoadsWhenPointsIsNullTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = this.ApiKey
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.NearestRoads.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Points is required");
        }

        [Test]
        public void NearestRoadsWhenPointsIsEmptyTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = this.ApiKey,
                Points = new Location[0]
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.NearestRoads.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Points is required");
        }
    }
}