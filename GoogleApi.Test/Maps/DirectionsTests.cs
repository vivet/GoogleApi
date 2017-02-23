using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Directions.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps
{
    [TestFixture]
    public class DirectionsTests : BaseTest
    {
        [Test]
        public void DirectionsTest()
        {
            var request = new DirectionsRequest
            {
                Origin = "285 Bedford Ave, Brooklyn, NY, USA",
                Destination = "185 Broadway Ave, Manhattan, NY, USA"
            };

            var result = GoogleMaps.Directions.Query(request);
            var overviewPath = result.Routes.First().OverviewPath;
            var polyline = result.Routes.First().Legs.First().Steps.First().PolyLine;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.AreEqual(133, overviewPath.Points.Count(), 5);
            Assert.AreEqual(5, polyline.Points.Count());
            Assert.AreEqual(8253, result.Routes.First().Legs.First().Steps.Sum(s => s.Distance.Value), 300);
            Assert.AreEqual(355, result.Routes.First().Legs.First().Steps.Sum(s => s.Duration.Value.Seconds), 50);
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
                Origin = "NYC, USA",
                Destination = "Miami, USA",
                Waypoints = new[] { "Philadelphia, USA" },
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
                Origin = "NYC, USA",
                Destination = "Miami, USA",
                Waypoints = new[] { "Philadelphia, USA" },
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
                Destination = "185 Broadway Ave, Manhattan, NY, USA"
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Directions.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Origin is required.");
        }
        [Test]
        public void DirectionsWhenDestinationIsNullTest()
        {
            var request = new DirectionsRequest
            {
                Origin = "185 Broadway Ave, Manhattan, NY, USA"
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Directions.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Destination is required.");
        }

        [Test]
        public void DirectionsAsyncTest()
        {
            var request = new DirectionsRequest
            {
                Origin = "285 Bedford Ave, Brooklyn, NY, USA",
                Destination = "185 Broadway Ave, Manhattan, NY, USA"
            };

            var result = GoogleMaps.Directions.QueryAsync(request).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }
        [Test]
        public void DirectionWhenAsyncWhenTimeoutTest()
        {
            var request = new DirectionsRequest
            {
                Origin = "285 Bedford Ave, Brooklyn, NY, USA",
                Destination = "185 Broadway Ave, Manhattan, NY, USA"
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
        public void DirectionWhenAsyncCancelledTest()
        {
            var request = new DirectionsRequest
            {
                Origin = "285 Bedford Ave, Brooklyn, NY, USA",
                Destination = "185 Broadway Ave, Manhattan, NY, USA"
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