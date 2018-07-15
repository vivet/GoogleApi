using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Roads.SnapToRoad
{
    [TestFixture]
    public class SnapToRoadTests : BaseTest
    {
        [Test]
        public void SnapToRoadTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey,
                Path = new[]
                {
                    new Location(60.170880, 24.942795),
                    new Location(60.170879, 24.942796),
                    new Location(60.170877, 24.942796)
                }
            };
            var result = GoogleMaps.SnapToRoad.Query(request);

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
        public void SnapToRoadWhenAsyncTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey,
                Path = new[]
                {
                    new Location(60.170880, 24.942795),
                    new Location(60.170879, 24.942796),
                    new Location(60.170877, 24.942796)
                }
            };
            var result = GoogleMaps.SnapToRoad.QueryAsync(request).Result;

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
        public void SnapToRoadWhenAsyncAndCancelledTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey,
                Path = new[] { new Location(0, 0) }
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.SnapToRoad.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void SnapToRoadWhenInvalidKeyTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = "test",
                Path = new[]
                {
                    new Location(60.170880, 24.942795),
                    new Location(60.170879, 24.942796),
                    new Location(60.170877, 24.942796)
                }
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.SnapToRoad.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerExceptions.FirstOrDefault();
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException).ToString(), innerException.GetType().ToString());
            Assert.AreEqual("Response status code does not indicate success: 400 (Bad Request).", innerException.Message);
        }

        [Test]
        public void SnapToRoadWhenKeyIsNullTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = null,
                Path = new[] { new Location(0, 0) }
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.SnapToRoad.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void SnapToRoadWhenKeyIsStringEmptyTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = string.Empty,
                Path = new[] { new Location(0, 0) }
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.SnapToRoad.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void SnapToRoadWhenPathIsNullTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.SnapToRoad.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Path is required");
        }

        [Test]
        public void SnapToRoadWhenPathIsEmptyTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey,
                Path = new Location[0]
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.SnapToRoad.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Path is required");
        }
    }
}