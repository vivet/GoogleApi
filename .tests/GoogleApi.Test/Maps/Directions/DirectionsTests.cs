using System;
using System.Collections.Generic;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.Directions.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Directions
{
    [TestFixture]
    public class DirectionsTests : BaseTest
    {
        [Test]
        public void DirectionsWhenAddressTest()
        {
            var origin = new Address("285 Bedford Ave, Brooklyn, NY, USA");
            var destination = new Address("185 Broadway Ave, Manhattan, NY, USA");
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new LocationEx(origin),
                Destination = new LocationEx(destination)
            };

            var result = GoogleMaps.Directions.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DirectionsWhenCoordinateTest()
        {
            var origin = new CoordinateEx(55.7237480, 12.4208282);
            var destination = new CoordinateEx(55.72672682, 12.407996582);
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new LocationEx(origin),
                Destination = new LocationEx(destination)
            };

            var result = GoogleMaps.Directions.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DirectionsWhenCoordinateAndHeadingTest()
        {
            var origin = new CoordinateEx(55.7237480, 12.4208282)
            {
                Heading = 90
            };
            var destination = new CoordinateEx(55.72672682, 12.407996582)
            {
                Heading = 90
            };
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new LocationEx(origin),
                Destination = new LocationEx(destination)
            };

            var result = GoogleMaps.Directions.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DirectionsWhenCoordinateAndUseSideOfRoadTest()
        {
            var origin = new CoordinateEx(55.7237480, 12.4208282)
            {
                UseSideOfRoad = true
            };
            var destination = new CoordinateEx(55.72672682, 12.407996582)
            {
                UseSideOfRoad = true
            };
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new LocationEx(origin),
                Destination = new LocationEx(destination)
            };

            var result = GoogleMaps.Directions.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DirectionsWhenPlaceIdTest()
        {
            var origin = new Place("ChIJaSLMpEVQUkYRL4xNOWBfwhQ");
            var destination = new Place("ChIJuc03_GlQUkYRlLku0KsLdJw");
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new LocationEx(origin),
                Destination = new LocationEx(destination)
            };

            var result = GoogleMaps.Directions.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DirectionsWhenAvoidWayTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new LocationEx(new Address("285 Bedford Ave, Brooklyn, NY, USA")),
                Destination = new LocationEx(new Address("185 Broadway Ave, Manhattan, NY, USA")),
                Avoid = AvoidWay.Highways
            };

            var result = GoogleMaps.Directions.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DirectionsWhenTravelModeDrivingAndDepartureTimeTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new LocationEx(new Address("285 Bedford Ave, Brooklyn, NY, USA")),
                Destination = new LocationEx(new Address("185 Broadway Ave, Manhattan, NY, USA")),
                TravelMode = TravelMode.Driving,
                DepartureTime = DateTime.UtcNow.AddHours(1)
            };

            var result = GoogleMaps.Directions.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DirectionsWhenTravelModeTransitAndArrivalTimeTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new LocationEx(new Address("285 Bedford Ave, Brooklyn, NY, USA")),
                Destination = new LocationEx(new Address("185 Broadway Ave, Manhattan, NY, USA")),
                TravelMode = TravelMode.Driving,
                ArrivalTime = DateTime.UtcNow.AddHours(1),
                TransitRoutingPreference = TransitRoutingPreference.Fewer_Transfers
            };

            var result = GoogleMaps.Directions.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DirectionsWhenWayPointsTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new LocationEx(new Address("NYC, USA")),
                Destination = new LocationEx(new Address("Miami, USA")),
                WayPoints = new List<WayPoint>
                {
                    new WayPoint(new LocationEx(new Address("Philadelphia, USA")))
                },
                OptimizeWaypoints = false
            };

            var result = GoogleMaps.Directions.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DirectionsWhenWayPointsAndOptimizedTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new LocationEx(new Address("NYC, USA")),
                Destination = new LocationEx(new Address("Miami, USA")),
                WayPoints = new List<WayPoint>
                {
                    new WayPoint(new LocationEx(new Address("Philadelphia, USA")), true)
                },
                OptimizeWaypoints = true
            };

            var result = GoogleMaps.Directions.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DirectionsWhenAsyncTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new LocationEx(new Address("285 Bedford Ave, Brooklyn, NY, USA")),
                Destination = new LocationEx(new Address("185 Broadway Ave, Manhattan, NY, USA"))
            };

            var result = GoogleMaps.Directions.QueryAsync(request).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DirectionsWhenAsyncAndCancelledTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new LocationEx(new Address("285 Bedford Ave, Brooklyn, NY, USA")),
                Destination = new LocationEx(new Address("185 Broadway Ave, Manhattan, NY, USA"))
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.Directions.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }
    }
}