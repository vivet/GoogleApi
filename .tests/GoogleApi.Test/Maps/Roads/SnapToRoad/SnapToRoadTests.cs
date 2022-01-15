using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Roads.Common;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;
using NUnit.Framework;
using System;
using System.Threading;

namespace GoogleApi.Test.Maps.Roads.SnapToRoad
{
    [TestFixture]
    public class SnapToRoadTests : BaseTest<GoogleMaps.SnapToRoadApi>
    {
        protected override GoogleMaps.SnapToRoadApi GetClient() => new(_httpClient);
        protected override GoogleMaps.SnapToRoadApi GetClientStatic() => GoogleMaps.SnapToRoad;

        [Test]
        public void SnapToRoadTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey,
                Path = new[]
                {
                    new Coordinate(60.170880, 24.942795),
                    new Coordinate(60.170879, 24.942796),
                    new Coordinate(60.170877, 24.942796)
                }
            };
            var result = Sut.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void SnapToRoadWhenAsyncTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey,
                Path = new[]
                {
                    new Coordinate(60.170880, 24.942795),
                    new Coordinate(60.170879, 24.942796),
                    new Coordinate(60.170877, 24.942796)
                }
            };
            var result = Sut.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void SnapToRoadWhenAsyncAndCancelledTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = this.ApiKey,
                Path = new[] { new Coordinate(0, 0) }
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