using System;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Roads.Common;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Roads.SpeedLimits
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
                Path = new[]
                {
                    new Coordinate(60.170880, 24.942795),
                    new Coordinate(60.170879, 24.942796),
                    new Coordinate(60.170877, 24.942796)
                }
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
                Places = new[]
                {
                    new Place("ChIJaSLMpEVQUkYRL4xNOWBfwhQ"),
                    new Place("ChIJuc03_GlQUkYRlLku0KsLdJw")
                }
            };

            var result = GoogleMaps.SpeedLimits.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
	    public void SpeedLimitsWhenAsyncTest()
	    {
            var request = new SpeedLimitsRequest
            {
                Key = this.ApiKey,
                Path = new[] { new Coordinate(0, 0) }
            };
            var result = GoogleMaps.SpeedLimits.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
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
	        var task = GoogleMaps.SpeedLimits.QueryAsync(request, cancellationTokenSource.Token);
	        cancellationTokenSource.Cancel();

	        var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
	        Assert.IsNotNull(exception);
	        Assert.AreEqual(exception.Message, "The operation was canceled.");
	    }
    }
}