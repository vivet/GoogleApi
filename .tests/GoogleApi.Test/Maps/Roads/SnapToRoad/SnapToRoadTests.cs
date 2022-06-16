using System;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Roads.Common;
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
                Key = this.Settings.ApiKey,
                Path = new[]
                {
                    new Coordinate(60.170880, 24.942795),
                    new Coordinate(60.170879, 24.942796),
                    new Coordinate(60.170877, 24.942796)
                }
            };
            var result = GoogleMaps.Roads.SnapToRoad.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void SnapToRoadWhenAsyncTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.Settings.ApiKey,
                Path = new[]
                {
                    new Coordinate(60.170880, 24.942795),
                    new Coordinate(60.170879, 24.942796),
                    new Coordinate(60.170877, 24.942796)
                }
            };
            var result = GoogleMaps.Roads.SnapToRoad.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void SnapToRoadWhenAsyncAndCancelledTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.Settings.ApiKey,
                Path = new[] { new Coordinate(0, 0) }
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.Roads.SnapToRoad.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }
    }
}