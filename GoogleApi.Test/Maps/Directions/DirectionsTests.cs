using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Directions.Request;
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
            Assert.AreEqual(10, overviewPath.Points.Count(), 2);
            Assert.AreEqual(2, polyline.Points.Count());
            Assert.AreEqual(700.00, result.Routes.First().Legs.First().Steps.Sum(s => s.Distance.Value), 100.00);
            Assert.AreEqual(209.00, result.Routes.First().Legs.First().Steps.Sum(s => s.Duration.Value), 30.00);
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
        public void DirectionsWhenAsyncAndTimeoutTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("285 Bedford Ave, Brooklyn, NY, USA"),
                Destination = new Location("185 Broadway Ave, Manhattan, NY, USA")
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.Directions.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
            Assert.Inconclusive();
        }

        [Test]
        public void DirectionsWhenUnitsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DirectionsWhenAvoidWayTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DirectionsWhenTravelModeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DirectionsWhenTransitModeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DirectionsWhenTransitRoutingPreferenceTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DirectionsWhenArrivalTimeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DirectionsWhenDepartureTimeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DirectionsWhenAlternativesTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DirectionsWhenRegionTest()
        {
            Assert.Inconclusive();
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

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Directions.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Origin is required");
        }

        [Test]
        public void DirectionsWhenDestinationIsNullTest()
        {
            var request = new DirectionsRequest
            {
                Key = this.ApiKey,
                Origin = new Location("185 Broadway Ave, Manhattan, NY, USA")
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Directions.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Destination is required");
        }
    }
}