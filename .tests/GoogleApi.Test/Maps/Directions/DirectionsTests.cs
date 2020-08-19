using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.Directions.Response.Enums;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Directions
{
    [TestFixture]
    public class DirectionsTests : BaseTest
    {
        [Test]
        public void DirectionsTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA")
            };

            var result = GoogleMaps.Directions.Query(request);
            var overviewPath = result.Routes.First().OverviewPath;
            var polyline = result.Routes.First().Legs.First().Steps.First().PolyLine;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.AreEqual(400, overviewPath.Points.Length, 300);
            Assert.AreEqual(25, polyline.Points.Length, 10);
            Assert.AreEqual(8258.00, result.Routes.First().Legs.First().Steps.Sum(s => s.Distance.Value), 5000.00);
            Assert.AreEqual(1135.00, result.Routes.First().Legs.First().Steps.Sum(s => s.Duration.Value), 500.00);
        }

        [Test]
        public void DirectionsWhenAsyncTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA")
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
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA")
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.Directions.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void DirectionsWhenLanguageTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                Language = Language.Dutch
            };

            var result = GoogleMaps.Directions.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotEmpty(result.Routes);
        }

        [Test]
        public void DirectionsWhenUnitsTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                Units = Units.Metric
            };

            var result = GoogleMaps.Directions.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotEmpty(result.Routes);
        }

        [Test]
        public void DirectionsWhenAvoidWayTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                Avoid = AvoidWay.Highways
            };

            var result = GoogleMaps.Directions.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotEmpty(result.Routes);
        }

        [Test]
        public void DirectionsWhenAvoidFerriesTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("1001 Alaskan Way, Seattle, WA 98104"),
                Destination = new Location("550 Winslow Way E, Bainbridge Island, WA 98110"),
                Avoid = AvoidWay.Ferries
            };

            var result = GoogleMaps.Directions.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotEmpty(result.Routes);

            Assert.IsFalse((from route in result.Routes
                            from leg in route.Legs
                            from step in leg.Steps
                            where step.Maneuver == ManeuverAction.Ferry
                            select step).Any());
        }

        [Test]
        public void DirectionsWhenTravelModeTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                ArrivalTime = DateTime.UtcNow.AddHours(1)
            };

            var result = GoogleMaps.Directions.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotEmpty(result.Routes);
        }

        [Test]
        public void DirectionsWhenTransitModeTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                TravelMode = TravelMode.Transit,
                ArrivalTime = DateTime.UtcNow.AddHours(2),
                DepartureTime = DateTime.UtcNow.AddHours(1)
            };

            var result = GoogleMaps.Directions.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotEmpty(result.Routes);
        }

        [Test]
        public void DirectionsWhenTransitRoutingPreferenceTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                TransitRoutingPreference = TransitRoutingPreference.FewerTransfers
            };

            var result = GoogleMaps.Directions.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotEmpty(result.Routes);
        }

        [Test]
        public void DirectionsWhenArrivalTimeTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                ArrivalTime = DateTime.UtcNow.AddHours(1)
            };

            var result = GoogleMaps.Directions.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotEmpty(result.Routes);
        }

        [Test]
        public void DirectionsWhenDepartureTimeTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                DepartureTime = DateTime.UtcNow.AddHours(1)
            };

            var result = GoogleMaps.Directions.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotEmpty(result.Routes);
        }

        [Test]
        public void DirectionsWhenAlternativesTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                Alternatives = true
            };

            var result = GoogleMaps.Directions.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotEmpty(result.Routes);
        }

        [Test]
        public void DirectionsWhenRegionTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA"),
                Region = "us"
            };

            var result = GoogleMaps.Directions.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotEmpty(result.Routes);
        }

        [Test]
        public void DirectionsWhenWayPointsTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("NYC, USA"),
                Destination = new Location("Miami, USA"),
                WayPoints = new List<WayPoint>
                {
                    new WayPoint("Philadelphia, USA")
                },
                OptimizeWaypoints = false
            };
            var result = GoogleMaps.Directions.Query(request);


            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var route = result.Routes.FirstOrDefault();
            Assert.IsNotNull(route);

            var leg = route.Legs.FirstOrDefault();
            Assert.IsNotNull(leg);
            Assert.AreEqual(156084, leg.Steps.Sum(s => s.Distance.Value), 15000);
            Assert.IsTrue(leg.EndAddress.Contains("Philadelphia"));
        }

        [Test]
        public void DirectionsWhenWayPointsAndOptimizeWaypointsTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("NYC, USA"),
                Destination = new Location("Miami, USA"),
                WayPoints = new List<WayPoint>
                {
                    new WayPoint("Philadelphia, USA")
                },
                OptimizeWaypoints = true
            };
            var result = GoogleMaps.Directions.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var route = result.Routes.FirstOrDefault();
            Assert.IsNotNull(route);

            var leg = route.Legs.FirstOrDefault();
            Assert.IsNotNull(leg);
            Assert.AreEqual(156084, leg.Steps.Sum(s => s.Distance.Value), 15000);
            Assert.IsTrue(leg.EndAddress.Contains("Philadelphia"));
        }

        [Test]
        public void DirectionsWhenWayPointsViaTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("NYC, USA"),
                Destination = new Location("Miami, USA"),
                WayPoints = new List<WayPoint>
                {
                    new WayPoint("Philadelphia, USA", true)
                },
                OptimizeWaypoints = false
            };

            var result = GoogleMaps.Directions.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var route = result.Routes.FirstOrDefault();
            Assert.IsNotNull(route);

            var leg = route.Legs.FirstOrDefault();
            Assert.IsNotNull(leg);
            Assert.AreEqual(2069947, leg.Steps.Sum(s => s.Distance.Value), 15000);
            Assert.IsTrue(leg.EndAddress.Contains("Miami, FL, USA"));
            Assert.IsNotNull(leg.ViaWayPoints.FirstOrDefault());
        }

        [Test]
        public void DirectionsWhenWayPointsViaAndOptimizeWaypointsTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("NYC, USA"),
                Destination = new Location("Miami, USA"),
                WayPoints = new List<WayPoint>
                {
                    new WayPoint("Philadelphia, USA", true)
                },
                OptimizeWaypoints = true
            };

            var result = GoogleMaps.Directions.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var route = result.Routes.FirstOrDefault();
            Assert.IsNotNull(route);

            var leg = route.Legs.FirstOrDefault();
            Assert.IsNotNull(leg);
            Assert.AreEqual(2069947, leg.Steps.Sum(s => s.Distance.Value), 15000);
            Assert.IsTrue(leg.EndAddress.Contains("Miami, FL, USA"));
            Assert.IsNotNull(leg.ViaWayPoints.FirstOrDefault());
        }

        [Test]
        public void DirectionsWhenOriginIsNullTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA")
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.Directions.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Origin is required");
        }

        [Test]
        public void DirectionsWhenDestinationIsNullTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("185 Broadway Ave, Manhattan, NY, USA")
            };
            
            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.Directions.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Destination is required");
        }
    }
}