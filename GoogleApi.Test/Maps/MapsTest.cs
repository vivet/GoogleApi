using System;
using System.Linq;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.Elevation.Request;
using GoogleApi.Entities.Maps.Geocode.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps
{
    [TestFixture]
    public class MapsTest : BaseTest
	{
        [Test]
        public void DirectionsTestTest()
        {
            var _request = new DirectionsRequest { Origin = "285 Bedford Ave, Brooklyn, NY, USA", Destination = "185 Broadway Ave, Manhattan, NY, USA" };

            var _result = GoogleMaps.Directions.Query(_request);
            var _overviewPath = _result.Routes.First().OverviewPath;
            var _polyline = _result.Routes.First().Legs.First().Steps.First().PolyLine;

            if (_result.Status == Status.OVER_QUERY_LIMIT)
                Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.OK, _result.Status);
            Assert.AreEqual(155, _overviewPath.Points.Count());
            Assert.AreEqual(4, _polyline.Points.Count());
            Assert.AreEqual(11777, _result.Routes.First().Legs.First().Steps.Sum(_s => _s.Distance.Value));
            Assert.AreEqual(469, _result.Routes.First().Legs.First().Steps.Sum(_s => _s.Duration.Value.Seconds));
        }
        [Test]
        public void DirectionsWhenhWayPointsTest()
        {
            var _request = new DirectionsRequest { Origin = "NYC, USA", Destination = "Miami, USA", Waypoints = new[] { "Philadelphia, USA" }, OptimizeWaypoints = true };

            var _result = GoogleMaps.Directions.Query(_request);

            if (_result.Status == Status.OVER_QUERY_LIMIT)
                Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.OK, _result.Status);
            Assert.AreEqual(156084, _result.Routes.First().Legs.First().Steps.Sum(_s => _s.Distance.Value));

            StringAssert.Contains("Philadelphia", _result.Routes.First().Legs.First().EndAddress);
        }

        [Test]
        public void GeocodingTest()
        {
            var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };
            var _result = GoogleMaps.Geocode.Query(_request);

            if (_result.Status == Status.OVER_QUERY_LIMIT)
                Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.OK, _result.Status);
            Assert.AreEqual("40.7140415,-73.9613119", _result.Results.First().Geometry.Location.LocationString);
        }
        [Test]
        public void GeocodingWhenTimeoutTest()
        {
            var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };
            Assert.Throws<TimeoutException>(() => MapsTest.ThrowInnerException(() => GoogleMaps.Geocode.Query(_request, TimeSpan.FromMilliseconds(1))));
        }
        [Test]
        public void GeocodingWhenInvalidClientCredentialsTest()
        {
            var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA", ClientId = "gme-ThisIsAUnitTest", SigningKey = "AAECAwQFBgcICQoLDA0ODxAREhM=" };
            Assert.Throws<AuthenticationException>(() => MapsTest.ThrowInnerException(() => GoogleMaps.Geocode.Query(_request)));
        }
        [Test]
        public void GeocodingAsyncTest()
        {
            var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };

            var _result = GoogleMaps.Geocode.QueryAsync(_request).Result;

            if (_result.Status == Status.OVER_QUERY_LIMIT)
                Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.OK, _result.Status);
            Assert.AreEqual("40.7140415,-73.9613119", _result.Results.First().Geometry.Location.LocationString);
        }
		[Test]
        public void GeocodingAsyncWhenInvalidClientCredentialsTest()
		{
			var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA", ClientId = "gme-ThisIsAUnitTest", SigningKey = "AAECAwQFBgcICQoLDA0ODxAREhM=" };
            Assert.Throws<AuthenticationException>(() => MapsTest.ThrowInnerException(() => GoogleMaps.Geocode.QueryAsync(_request).Wait()));
		}
		[Test]
        public void GeocodingAsyncWhenTimeoutTest()
		{
            var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };
            Assert.Throws<TimeoutException>(() => MapsTest.ThrowInnerException(() => GoogleMaps.Geocode.QueryAsync(_request, TimeSpan.FromMilliseconds(1)).Wait()));
		}
        [Test]
        public void GeocodingAsyncCancelThrowsTest()
		{
            var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };

			var _cancellationTokenSource = new CancellationTokenSource();
            var _task = GoogleMaps.Geocode.QueryAsync(_request, _cancellationTokenSource.Token);
			_cancellationTokenSource.Cancel();

            Assert.Throws<TaskCanceledException>(() => MapsTest.ThrowInnerException(_task));
        }

        [Test]
        public void ReverseGeocodingTest()
		{
			var _request = new GeocodingRequest { Location = new Location(40.7141289, -73.9614074) };
			var _result = GoogleMaps.Geocode.Query(_request);

			if (_result.Status == Status.OVER_QUERY_LIMIT)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

			Assert.AreEqual(Status.OK, _result.Status);
            Assert.AreEqual("281 Bedford Ave, Brooklyn, NY 11211, USA", _result.Results.First().FormattedAddress);
		}
		[Test]
        public void ReverseGeocodingAsyncTest()
		{
			var _request = new GeocodingRequest { Location = new Location(40.7141289, -73.9614074) };
			var _result = GoogleMaps.Geocode.QueryAsync(_request).Result;

			if (_result.Status == Status.OVER_QUERY_LIMIT)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

			Assert.AreEqual(Status.OK, _result.Status);
            Assert.AreEqual("281 Bedford Ave, Brooklyn, NY 11211, USA", _result.Results.First().FormattedAddress);
		}
		
        [Test]
        public void ElevationTest()
		{
			var _request = new ElevationRequest { Locations = new[] { new Location(40.7141289, -73.9614074) } };

			var _result = GoogleMaps.Elevation.Query(_request);

            if (_result.Status == Status.OVER_QUERY_LIMIT)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.OK, _result.Status);
			Assert.AreEqual(14.782454490661619, _result.Results.First().Elevation);
		}
		[Test]
        public void ElevationAsyncTest()
		{
			var _request = new ElevationRequest { Locations = new[] { new Location(40.7141289, -73.9614074) } };

			var _result = GoogleMaps.Elevation.QueryAsync(_request).Result;

			if (_result.Status == Status.OVER_QUERY_LIMIT)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

			Assert.AreEqual(Status.OK, _result.Status);
			Assert.AreEqual(14.782454490661619, _result.Results.First().Elevation);
		}

        [Test]
        public void DistanceMatrixTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void TimeZoneTest()
        {
            Assert.Inconclusive();
        }

        private static void ThrowInnerException(Task _task)
        {
            try
            {
                _task.Wait();
            }
            catch (AggregateException _ex)
            {
                throw _ex.Flatten().InnerException;
            }
        }
        private static void ThrowInnerException(Action _action)
        {
            try
            {
                _action();
            }
            catch (AggregateException _ex)
            {
                throw _ex.InnerException;
            }
        }
	}
}
