using System;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Roads
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
                    new Entities.Maps.Roads.Common.Location(60.170880, 24.942795),
                    new Entities.Maps.Roads.Common.Location(60.170879, 24.942796),
                    new Entities.Maps.Roads.Common.Location(60.170877, 24.942796)
                }
            };
            var result = GoogleMaps.NearestRoads.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void NearestRoadsWhenKeyIsNullTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = null,
                Points = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.NearestRoads.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void NearestRoadsWhenKeyIsStringEmptyTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = string.Empty,
                Points = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.NearestRoads.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void NearestRoadsWhenPointsIsNullTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = this.ApiKey
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.NearestRoads.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Points is required.");
        }
        [Test]
        public void NearestRoadsWhenPointsIsEmptyTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = this.ApiKey,
                Points = new Entities.Maps.Roads.Common.Location[0]
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.NearestRoads.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Points is required.");
        }

        [Test]
        public void NearestRoadsAsyncTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = this.ApiKey,
                Points = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var result = GoogleMaps.NearestRoads.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }
        [Test]
        public void NearestRoadsAsyncWhenTimeoutTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = this.ApiKey,
                Points = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.NearestRoads.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void NearestRoadsAsyncCancelledTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = this.ApiKey,
                Points = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.NearestRoads.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }
    }
}