using System;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Roads
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
                Path = new[] {new Entities.Maps.Roads.Common.Location(0, 0)}
            };
            var result = GoogleMaps.SnapToRoad.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void SnapToRoadWhenKeyIsNullTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = null,
                Path = new[] {new Entities.Maps.Roads.Common.Location(0, 0)}
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SnapToRoad.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void SnapToRoadWhenKeyIsStringEmptyTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = string.Empty,
                Path = new[] {new Entities.Maps.Roads.Common.Location(0, 0)}
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SnapToRoad.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required.");
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
            Assert.AreEqual(exception.Message, "Path is required.");
        }
        [Test]
        public void SnapToRoadWhenPathIsEmptyTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey,
                Path = new Entities.Maps.Roads.Common.Location[0]
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SnapToRoad.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Path is required.");
        }
        [Test]
        public void SnapToRoadAsyncTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey,
                Path = new[] {new Entities.Maps.Roads.Common.Location(0, 0)}
            };
            var result = GoogleMaps.SnapToRoad.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }
        [Test]
        public void SnapToRoadAsyncWhenTimeoutTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey,
                Path = new[] {new Entities.Maps.Roads.Common.Location(0, 0)}
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
        public void SnapToRoadAsyncCancelledTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey,
                Path = new[] {new Entities.Maps.Roads.Common.Location(0, 0)}
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.SnapToRoad.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }
    }
}