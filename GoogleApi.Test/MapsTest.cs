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
        public static void ThrowInnerException(Task task)
        {
            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                throw ex.Flatten().InnerException;
            }
        }
        public static void ThrowInnerException(Action action)
        {
            try
            {
                action();
            }
            catch (AggregateException ex)
            {
                throw ex.InnerException;
            }
        }

		[Test]
		public void GeocodingReturnsCorrectLocationTest()
		{
			var request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };

			var result = GoogleMaps.Geocode.Query(request);

			if (result.Status == Status.OverQueryLimit)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.Ok, result.Status);
            Assert.AreEqual("40.7140289,-73.961305", result.Results.First().Geometry.Location.LocationString);
		}
		[Test]
        public void GeocodingAsyncReturnsCorrectLocationTest()
		{
			var request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };

			var result = GoogleMaps.Geocode.QueryAsync(request).Result;

			if (result.Status == Status.OverQueryLimit)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.Ok, result.Status);
            Assert.AreEqual("40.7140289,-73.961305", result.Results.First().Geometry.Location.LocationString);
		}

		[Test]
		[ExpectedException(typeof(AuthenticationException))]
        public void GeocodingInvalidClientCredentialsThrowsTest()
		{
			var request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA", ClientId = "gme-ThisIsAUnitTest", SigningKey = "AAECAwQFBgcICQoLDA0ODxAREhM=" };

            ThrowInnerException(() => GoogleMaps.Geocode.Query(request));
		}
		[Test]
		[ExpectedException(typeof(AuthenticationException))]
        public void GeocodingAsyncInvalidClientCredentialsThrowsTest()
		{
			var request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA", ClientId = "gme-ThisIsAUnitTest", SigningKey = "AAECAwQFBgcICQoLDA0ODxAREhM=" };

            ThrowInnerException(() => GoogleMaps.Geocode.QueryAsync(request).Wait());
		}
		[Test]
		[ExpectedException(typeof(TimeoutException))]
        public void GeocodingTimeoutTooShortThrowsTest()
		{
			var request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };

            ThrowInnerException(() => GoogleMaps.Geocode.Query(request, TimeSpan.FromMilliseconds(1)));
		}
		[Test]
		[ExpectedException(typeof(TimeoutException))]
        public void GeocodingAsyncTimeoutTooShortThrowsTest()
		{
            var request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };

            ThrowInnerException(() => GoogleMaps.Geocode.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Wait());
		}
		[Test]
		[ExpectedException(typeof(TaskCanceledException))]
        public void GeocodingAsyncCancelThrowsTest()
		{
            var request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };

			var tokeSource = new CancellationTokenSource();
            var task = GoogleMaps.Geocode.QueryAsync(request, tokeSource.Token);
			tokeSource.Cancel();
            ThrowInnerException(task);
		}
		[Test]
		[ExpectedException(typeof(TaskCanceledException))]
        public void GeocodingAsyncWithPreCanceledTokenCancelsTest()
		{
            var request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };
			var cts = new CancellationTokenSource();
			cts.Cancel();

            var task = GoogleMaps.Geocode.QueryAsync(request, cts.Token);
			ThrowInnerException(task);
		}
		
        [Test]
        public void ReverseGeocodingReturnsCorrectAddressTest()
		{
			var request = new GeocodingRequest { Location = new Location(40.7141289, -73.9614074) };

			var result = GoogleMaps.Geocode.Query(request);

			if (result.Status == Status.OverQueryLimit)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.Ok, result.Status);
            Assert.True(result.Results.First().FormattedAddress.Contains("Bedford Avenue, Brooklyn, NY 11211, USA"));
		}
		[Test]
        public void ReverseGeocodingAsyncReturnsCorrectAddressTest()
		{
			var request = new GeocodingRequest { Location = new Location(40.7141289, -73.9614074) };

			var result = GoogleMaps.Geocode.QueryAsync(request).Result;

			if (result.Status == Status.OverQueryLimit)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.Ok, result.Status);
            Assert.AreEqual("285 Bedford Avenue, Brooklyn, NY 11211, USA", result.Results.First().FormattedAddress);
		}
		
        [Test]
        public void DirectionsSumOfStepDistancesCorrectTest()
		{
			var request = new DirectionsRequest { Origin = "285 Bedford Ave, Brooklyn, NY, USA", Destination = "185 Broadway Ave, Manhattan, NY, USA" };

			var result = GoogleMaps.Directions.Query(request);

            if (result.Status == Status.OverQueryLimit)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.Ok, result.Status);
            Assert.AreEqual(5284, result.Routes.First().Legs.First().Steps.Sum(s => s.Distance.Value));
		}
		[Test]
        public void DirectionsWithWayPointsTest()
		{
			var request = new DirectionsRequest { Origin = "NYC, USA", Destination = "Miami, USA", Waypoints = new[]{"Philadelphia, USA"}, OptimizeWaypoints = true};

			var result = GoogleMaps.Directions.Query(request);

			if (result.Status == Status.OverQueryLimit)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.Ok, result.Status);
            Assert.AreEqual(152601, result.Routes.First().Legs.First().Steps.Sum(s => s.Distance.Value));

			StringAssert.Contains("Philadelphia", result.Routes.First().Legs.First().EndAddress);
		}
		[Test]
        public void DirectionsCorrectOverviewPathTest()
		{
			var request = new DirectionsRequest
			    {
			        Destination = "maleva 10, Ahtme, Kohtla-Järve, 31025 Ida-Viru County, Estonia",
			        Origin = "veski 2, Jõhvi Parish, 41532 Ida-Viru County, Estonia"
			    };

		    var result = GoogleMaps.Directions.Query(request);

            var overviewPath = result.Routes.First().OverviewPath;

            var polyline = result.Routes.First().Legs.First().Steps.First().PolyLine;

            Assert.AreEqual(Status.Ok, result.Status);
            Assert.AreEqual(120, overviewPath.Points.Count());
			Assert.AreEqual(2, polyline.Points.Count());
		}
		[Test]
        public void DirectionsAsyncSumOfStepDistancesCorrectTest()
		{
            var request = new DirectionsRequest { Origin = "55.866413, 12.501063", Destination = "55.781495, 12.50114", DepartureTime = DateTime.UtcNow, TravelMode = TravelMode.Driving };

            var result = GoogleMaps.Directions.QueryAsync(request).Result;

            if (result.Status == Status.OverQueryLimit)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.Ok, result.Status);
            Assert.AreEqual(5284, result.Routes.First().Legs.First().Steps.Sum(s => s.Distance.Value));
		}
		
        [Test]
        public void ElevationReturnsCorrectElevationTest()
		{
			var request = new ElevationRequest { Locations = new[] { new Location(40.7141289, -73.9614074) } };

			var result = GoogleMaps.Elevation.Query(request);

            if (result.Status == Status.OverQueryLimit)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.Ok, result.Status);
			Assert.AreEqual(14.782454490661619, result.Results.First().Elevation);
		}
		[Test]
        public void ElevationAsyncReturnsCorrectElevationTest()
		{
			var request = new ElevationRequest { Locations = new[] { new Location(40.7141289, -73.9614074) } };

			var result = GoogleMaps.Elevation.QueryAsync(request).Result;

			if (result.Status == Status.OverQueryLimit)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

			Assert.AreEqual(Status.Ok, result.Status);
			Assert.AreEqual(14.782454490661619, result.Results.First().Elevation);
		}
	}
}
