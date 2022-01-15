using GoogleApi.Entities.Maps.Roads.Common;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Request;
using NUnit.Framework;
using System;
using System.Threading;

namespace GoogleApi.Test.Maps.Roads.SpeedLimits
{
    [TestFixture]
    public class SpeedLimitsTests : BaseTest<GoogleMaps.SpeedLimitsApi>
    {
        protected override GoogleMaps.SpeedLimitsApi GetClient() => new(_httpClient);
        protected override GoogleMaps.SpeedLimitsApi GetClientStatic() => GoogleMaps.SpeedLimits;

        [Test]
        public void SpeedLimitsTest()
        {
            Assert.Inconclusive();

            ////var request = new SpeedLimitsRequest
            ////{
            ////    Key = this.ApiKey,
            ////    Path = new[]
            ////    {
            ////        new Coordinate(60.170880, 24.942795),
            ////        new Coordinate(60.170879, 24.942796),
            ////        new Coordinate(60.170877, 24.942796)
            ////    }
            ////};

            ////var result = GoogleMaps.SpeedLimits.Query(request);
            ////Assert.IsNotNull(result);
            ////Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void SpeedLimitsWhenPlaceIdsTest()
        {
            Assert.Inconclusive();

            ////var request = new SpeedLimitsRequest
            ////{
            ////    Key = this.ApiKey,
            ////    Places = new[]
            ////    {
            ////        new Place("ChIJaSLMpEVQUkYRL4xNOWBfwhQ"),
            ////        new Place("ChIJuc03_GlQUkYRlLku0KsLdJw")
            ////    }
            ////};

            ////var result = GoogleMaps.SpeedLimits.Query(request);
            ////Assert.IsNotNull(result);
            ////Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void SpeedLimitsWhenAsyncTest()
        {
            Assert.Inconclusive();

            ////var request = new SpeedLimitsRequest
            ////{
            ////    Key = this.ApiKey,
            ////    Path = new[] { new Coordinate(0, 0) }
            ////};
            ////var result = GoogleMaps.SpeedLimits.QueryAsync(request).Result;

            ////Assert.IsNotNull(result);
            ////Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void SpeedLimitsWhenAsyncAndCancelledTest()
        {
            var request = new SpeedLimitsRequest
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