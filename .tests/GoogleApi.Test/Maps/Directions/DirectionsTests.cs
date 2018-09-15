using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.Directions.Request;
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
            Assert.AreEqual(137, overviewPath.Points.Count(), 40);
            Assert.AreEqual(5, polyline.Points.Count());
            Assert.AreEqual(8258.00, result.Routes.First().Legs.First().Steps.Sum(s => s.Distance.Value), 1000.00);
            Assert.AreEqual(1135.00, result.Routes.First().Legs.First().Steps.Sum(s => s.Duration.Value), 200.00);
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
        public void DirectionsWhenhWayPointsTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("NYC, USA"),
                Destination = new Location("Miami, USA"),
                Waypoints = new[] { new Location("Philadelphia, USA") },
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
        public void DirectionsWhenWayÆointsAndOptimizeWaypointsTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("NYC, USA"),
                Destination = new Location("Miami, USA"),
                Waypoints = new[] { new Location("Philadelphia, USA") },
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
        public void DirectionsWhenOriginIsNullTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA")
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.Directions.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

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
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Destination is required");
        }
    }
}