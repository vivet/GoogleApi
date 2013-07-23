using System;
using System.Linq;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.Elevation.Request;
using GoogleApi.Entities.Maps.Geocode.Request;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
	public class MapsTest
	{
        public static void ThrowInnerException(Task _task)
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
        public static void ThrowInnerException(Action _action)
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

		[Test]
		public void GeocodingReturnsCorrectLocationTest()
		{
			var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };

			var _result = GoogleMaps.Geocode.Query(_request);

			if (_result.Status == Status.OVER_QUERY_LIMIT)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

			Assert.AreEqual(Status.OK, _result.Status);
            Assert.AreEqual("40.7140289,-73.961305", _result.Results.First().Geometry.Location.LocationString);
		}
		[Test]
        public void GeocodingAsyncReturnsCorrectLocationTest()
		{
			var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };

			var _result = GoogleMaps.Geocode.QueryAsync(_request).Result;

			if (_result.Status == Status.OVER_QUERY_LIMIT)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

			Assert.AreEqual(Status.OK, _result.Status);
            Assert.AreEqual("40.7140289,-73.961305", _result.Results.First().Geometry.Location.LocationString);
		}

		[Test]
		[ExpectedException(typeof(AuthenticationException))]
        public void GeocodingInvalidClientCredentialsThrowsTest()
		{
			var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA", ClientId = "gme-ThisIsAUnitTest", SigningKey = "AAECAwQFBgcICQoLDA0ODxAREhM=" };

            MapsTest.ThrowInnerException(() => GoogleMaps.Geocode.Query(_request));
		}
		[Test]
		[ExpectedException(typeof(AuthenticationException))]
        public void GeocodingAsyncInvalidClientCredentialsThrowsTest()
		{
			var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA", ClientId = "gme-ThisIsAUnitTest", SigningKey = "AAECAwQFBgcICQoLDA0ODxAREhM=" };

            MapsTest.ThrowInnerException(() => GoogleMaps.Geocode.QueryAsync(_request).Wait());
		}
		[Test]
		[ExpectedException(typeof(TimeoutException))]
        public void GeocodingTimeoutTooShortThrowsTest()
		{
			var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };

            MapsTest.ThrowInnerException(() => GoogleMaps.Geocode.Query(_request, TimeSpan.FromMilliseconds(1)));
		}
		[Test]
		[ExpectedException(typeof(TimeoutException))]
        public void GeocodingAsyncTimeoutTooShortThrowsTest()
		{
            var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };

            MapsTest.ThrowInnerException(() => GoogleMaps.Geocode.QueryAsync(_request, TimeSpan.FromMilliseconds(1)).Wait());
		}
		[Test]
		[ExpectedException(typeof(TaskCanceledException))]
        public void GeocodingAsyncCancelThrowsTest()
		{
            var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };

			var _tokeSource = new CancellationTokenSource();
            var _task = GoogleMaps.Geocode.QueryAsync(_request, _tokeSource.Token);
			_tokeSource.Cancel();
            MapsTest.ThrowInnerException(_task);
		}
		[Test]
		[ExpectedException(typeof(TaskCanceledException))]
        public void GeocodingAsyncWithPreCanceledTokenCancelsTest()
		{
            var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };
			var _cts = new CancellationTokenSource();
			_cts.Cancel();

            var _task = GoogleMaps.Geocode.QueryAsync(_request, _cts.Token);
			MapsTest.ThrowInnerException(_task);
		}
		
        [Test]
        public void ReverseGeocodingReturnsCorrectAddressTest()
		{
			var _request = new GeocodingRequest { Location = new Location(40.7141289, -73.9614074) };

			var _result = GoogleMaps.Geocode.Query(_request);

			if (_result.Status == Status.OVER_QUERY_LIMIT)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

			Assert.AreEqual(Status.OK, _result.Status);
            Assert.AreEqual("285 Bedford Avenue, Brooklyn, NY 11211, USA", _result.Results.First().FormattedAddress);
		}
		[Test]
        public void ReverseGeocodingAsyncReturnsCorrectAddressTest()
		{
			var _request = new GeocodingRequest { Location = new Location(40.7141289, -73.9614074) };

			var _result = GoogleMaps.Geocode.QueryAsync(_request).Result;

			if (_result.Status == Status.OVER_QUERY_LIMIT)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

			Assert.AreEqual(Status.OK, _result.Status);
            Assert.AreEqual("285 Bedford Avenue, Brooklyn, NY 11211, USA", _result.Results.First().FormattedAddress);
		}
		
        [Test]
        public void DirectionsSumOfStepDistancesCorrectTest()
		{
			var _request = new DirectionsRequest { Origin = "285 Bedford Ave, Brooklyn, NY, USA", Destination = "185 Broadway Ave, Manhattan, NY, USA" };

			var _result = GoogleMaps.Directions.Query(_request);

            if (_result.Status == Status.OVER_QUERY_LIMIT)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.OK, _result.Status);
            Assert.AreEqual(5284, _result.Routes.First().Legs.First().Steps.Sum(_s => _s.Distance.Value));
		}
		[Test]
        public void DirectionsWithWayPointsTest()
		{
			var _request = new DirectionsRequest { Origin = "NYC, USA", Destination = "Miami, USA", Waypoints = new[]{"Philadelphia, USA"}, OptimizeWaypoints = true};

			var _result = GoogleMaps.Directions.Query(_request);

			if (_result.Status == Status.OVER_QUERY_LIMIT)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.OK, _result.Status);
            Assert.AreEqual(152601, _result.Routes.First().Legs.First().Steps.Sum(_s => _s.Distance.Value));

			StringAssert.Contains("Philadelphia", _result.Routes.First().Legs.First().EndAddress);
		}
		[Test]
        public void DirectionsCorrectOverviewPathTest()
		{
			var _request = new DirectionsRequest
			    {
			        Destination = "maleva 10, Ahtme, Kohtla-Järve, 31025 Ida-Viru County, Estonia",
			        Origin = "veski 2, Jõhvi Parish, 41532 Ida-Viru County, Estonia"
			    };

		    var _result = GoogleMaps.Directions.Query(_request);

            var _overviewPath = _result.Routes.First().OverviewPath;

            var _polyline = _result.Routes.First().Legs.First().Steps.First().PolyLine;

            Assert.AreEqual(Status.OK, _result.Status);
            Assert.AreEqual(120, _overviewPath.Points.Count());
			Assert.AreEqual(2, _polyline.Points.Count());
		}
		[Test]
        public void DirectionsAsyncSumOfStepDistancesCorrectTest()
		{
            var _request = new DirectionsRequest { Origin = "55.866413, 12.501063", Destination = "55.781495, 12.50114", DepartureTime = DateTime.UtcNow, TravelMode = TravelMode.Driving };

            var _result = GoogleMaps.Directions.QueryAsync(_request).Result;

            if (_result.Status == Status.OVER_QUERY_LIMIT)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.OK, _result.Status);
            Assert.AreEqual(5284, _result.Routes.First().Legs.First().Steps.Sum(_s => _s.Distance.Value));
		}
		
        [Test]
        public void ElevationReturnsCorrectElevationTest()
		{
			var _request = new ElevationRequest { Locations = new[] { new Location(40.7141289, -73.9614074) } };

			var _result = GoogleMaps.Elevation.Query(_request);

            if (_result.Status == Status.OVER_QUERY_LIMIT)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.OK, _result.Status);
			Assert.AreEqual(14.782454490661619, _result.Results.First().Elevation);
		}
		[Test]
        public void ElevationAsyncReturnsCorrectElevationTest()
		{
			var _request = new ElevationRequest { Locations = new[] { new Location(40.7141289, -73.9614074) } };

			var _result = GoogleMaps.Elevation.QueryAsync(_request).Result;

			if (_result.Status == Status.OVER_QUERY_LIMIT)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

			Assert.AreEqual(Status.OK, _result.Status);
			Assert.AreEqual(14.782454490661619, _result.Results.First().Elevation);
		}
	}
}
