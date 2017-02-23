using System;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Roads
{
    [TestFixture]
    public class SpeedLimitsTests : BaseTest
	{
        [Test]
        public void SpeedLimitsTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = this.ApiKey,
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var result = GoogleMaps.SpeedLimits.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }
        [Test]
        public void SpeedLimitsWhenPlaceIdsTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = this.ApiKey,
                PlaceIds = new[] { "test" }
            };
            var result = GoogleMaps.SpeedLimits.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void SpeedLimitsWhenKeyIsNullTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = null,
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SpeedLimits.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void SpeedLimitsWhenKeyIsStringEmptyTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = string.Empty,
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SpeedLimits.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void NearestRoadsWhenPathIsNullAndPlaceIdsIsNullTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = this.ApiKey
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SpeedLimits.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Path or PlaceId's is required.");
        }
        [Test]
        public void NearestRoadsWhenPathIsEmptyAndPlaceIdsIsEmptyTest()
        {
            var request = new SpeedLimitsRequest()
            {
                Key = this.ApiKey,
                Path = new Entities.Maps.Roads.Common.Location[0],
                PlaceIds = new string[0]
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SpeedLimits.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Path or PlaceId's is required.");
        }
        [Test]
        public void SpeedLimitsWhenPlaceIdsCountIsGreaterThanAllowedTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = this.ApiKey,
                PlaceIds = new string[101]
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SpeedLimits.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Max 100 PlaceId's is allowed.");
        }

        [Test]
        public void SpeedLimitsAsyncTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = this.ApiKey,
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var result = GoogleMaps.SpeedLimits.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }
        [Test]
        public void SpeedLimitsAsyncWhenTimeoutTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = this.ApiKey,
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.SpeedLimits.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void SpeedLimitsAsyncCancelledTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = this.ApiKey,
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.SpeedLimits.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }
    }
}

