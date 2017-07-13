using System;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;
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
                Path = new[] { new Location(0, 0) }
            };
            var result = GoogleMaps.SnapToRoad.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void SnapToRoadWhenAsyncTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey,
                Path = new[] { new Location(0, 0) }
            };
            var result = GoogleMaps.SnapToRoad.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void SnapToRoadWhenAsyncAndTimeoutTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey,
                Path = new[] { new Location(0, 0) }
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.SnapToRoad.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void SnapToRoadWhenKeyIsNullTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = null,
                Path = new[] { new Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SnapToRoad.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void SnapToRoadWhenKeyIsStringEmptyTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = string.Empty,
                Path = new[] { new Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SnapToRoad.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void SnapToRoadWhenPathIsNullTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SnapToRoad.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Path is required");
        }

        [Test]
        public void SnapToRoadWhenPathIsEmptyTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey,
                Path = new Location[0]
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SnapToRoad.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Path is required");
        }
    }
}