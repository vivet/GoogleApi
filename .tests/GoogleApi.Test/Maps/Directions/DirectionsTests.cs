using AutoFixture;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.Directions.Request;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;

namespace GoogleApi.Test.Maps.Directions
{
    [TestFixture]
    public class DirectionsTests : BaseTest<GoogleMaps.DirectionsApi>
    {
        protected override GoogleMaps.DirectionsApi GetClient() => new(_httpClient);
        protected override GoogleMaps.DirectionsApi GetClientStatic() => GoogleMaps.Directions;

        [Test]
        public void DirectionsWhenAddressTest()
        {
            var origin = new Address("285 Bedford Ave, Brooklyn, NY, USA");
            var destination = new Address("185 Broadway Ave, Manhattan, NY, USA");
            var request = _fixture.Build<DirectionsRequest>()
                .With(_ => _.Key)
                .With(_ => _.Origin, new LocationEx(origin))
                .With(_ => _.Destination, new LocationEx(destination))
                .OmitAutoProperties()
                .Create();


            var result = Sut.Query(request);
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

            var result = Sut.Query(request);
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

            var result = Sut.Query(request);
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

            var result = Sut.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void DirectionsWhenPlaceIdTest()
        {
            var origin = new Place("ChIJo9YpQWBZwokR7OeY0hiWh8g");
            var destination = new Place("ChIJx2ypzRlawokRrtKq2wZKitw");
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new LocationEx(origin),
                Destination = new LocationEx(destination)
            };

            var result = Sut.Query(request);
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

            var result = Sut.Query(request);
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

            var result = Sut.Query(request);
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

            var result = Sut.Query(request);
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

            var result = Sut.Query(request);
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

            var result = Sut.Query(request);
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

            var result = Sut.QueryAsync(request).Result;
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
            var task = Sut.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual("The operation was canceled.", exception.Message);
        }
    }
}