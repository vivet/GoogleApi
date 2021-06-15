using System;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using NUnit.Framework;
using Coordinate = GoogleApi.Entities.Common.Coordinate;

namespace GoogleApi.Test.Maps.StaticMaps
{
    [TestFixture]
    public class StaticMapsTests : BaseTest
    {
        [Test]
        public void StaticMapsTest()
        {
            var request = new StaticMapsRequest
            {
                Key = this.ApiKey,
                Center = new Location(new Coordinate(60.170877, 24.942796)),
                ZoomLevel = 1
            };

            var result = GoogleMaps.StaticMaps.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StaticMapsWhenAsyncTest()
        {
            var request = new StaticMapsRequest
            {
                Key = this.ApiKey,
                Center = new Location(new Coordinate(60.170877, 24.942796)),
                ZoomLevel = 1
            };
            var result = GoogleMaps.StaticMaps.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StaticMapsWhenAsyncAndCancelledTest()
        {
            var request = new StaticMapsRequest
            {
                Key = this.ApiKey,
                Center = new Location(new Coordinate(60.170877, 24.942796)),
                ZoomLevel = 1
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.StaticMaps.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }
    }
}