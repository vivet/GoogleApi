using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using GoogleApi.Entities.Maps.Elevation.Request;
using GoogleApi.Entities.Maps.Geocode.Request;
using GoogleApi.Entities.Maps.Geolocation.Request;
using GoogleApi.Entities.Maps.TimeZone.Request;
using NUnit.Framework;
using System.Net.Http;

namespace GoogleApi.Test
{
    [TestFixture]
    public class GoogleMapsTest : BaseTest
	{
        [Test]
        public void DirectionsTest()
        {
            var request = new DirectionsRequest { Origin = "285 Bedford Ave, Brooklyn, NY, USA", Destination = "185 Broadway Ave, Manhattan, NY, USA" };

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
        public void DirectionsAsyncTest()
        {
            var request = new DirectionsRequest { Origin = "285 Bedford Ave, Brooklyn, NY, USA", Destination = "185 Broadway Ave, Manhattan, NY, USA" };

            var result = GoogleMaps.Directions.QueryAsync(request, new TimeSpan(0, 0, 5)).Result;
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
        public void DirectionsWhenhWayPointsTest()
        {
            var request = new DirectionsRequest { Origin = "NYC, USA", Destination = "Miami, USA", Waypoints = new[] { "Philadelphia, USA" }, OptimizeWaypoints = true };
            var result = GoogleMaps.Directions.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.AreEqual(156084, result.Routes.First().Legs.First().Steps.Sum(s => s.Distance.Value), 15000);

            StringAssert.Contains("Philadelphia", result.Routes.First().Legs.First().EndAddress);
        }

        [Test]
        public void GeocodingTest()
        {
            var request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };
            var result = GoogleMaps.Geocode.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.AreEqual(40.7140415, result.Results.First().Geometry.Location.Latitude, 0.001);
            Assert.AreEqual(-73.9613119, result.Results.First().Geometry.Location.Longitude, 0.001);
        }
        [Test]
        public void GeocodingAsyncTest()
        {
            var request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };
            var result = GoogleMaps.Geocode.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.AreEqual(40.7140415, result.Results.First().Geometry.Location.Latitude, 0.001);
            Assert.AreEqual(-73.9613119, result.Results.First().Geometry.Location.Longitude, 0.001);
        }
        [Test]
        public void GeocodingAsyncCancelledTest()
        {
            var request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };

            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.Geocode.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            Assert.Throws<OperationCanceledException>(() =>
            {
                try
                {
                    task.Wait(cancellationTokenSource.Token);
                }
                catch (AggregateException ex)
                {
                    throw ex.Flatten().InnerException ?? ex;
                }
            });
        }
        [Test]
        public void GeocodingWhenTimeoutTest()
        {
            var request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };
            Assert.Throws<TaskCanceledException> (() =>
            {
                try
                {
                    GoogleMaps.Geocode.Query(request, TimeSpan.FromMilliseconds(1));
                }
                catch (AggregateException ex)
                {
                    throw ex.InnerException ?? ex;
                }
            });
        }
        [Test]
        public void GeocodingWhenInvalidClientCredentialsTest()
        {
            var request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA", ClientId = "gme-ThisIsAUnitTest", Key = "AAECAwQFBgcICQoLDA0ODxAREhM=" };
            Assert.Throws<HttpRequestException> (() =>
            {
                try
                {
                    GoogleMaps.Geocode.Query(request);
                }
                catch (AggregateException ex)
                {
                    throw ex.InnerException ?? ex;
                }
            });
        }

        [Test]
        public void GeolocationTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey,
                ConsiderIp = false,
                WifiAccessPoints = new[]
                {
                    new WifiAccessPoint
                    {
                        MacAddress =  "00:25:9c:cf:1c:ac",
                        SignalStrength = -43,
                        SignalToNoiseRatio = 0
                    },
                    new WifiAccessPoint
                    {
                        MacAddress =  "00:25:9c:cf:1c:ad",
                        SignalStrength = -55,
                        SignalToNoiseRatio = 0
                    }
                }
            };

            var result = GoogleMaps.Geolocation.Query(request);

            Assert.AreEqual(Status.Ok, result.Status);
        }
        [Test]
        public void GeolocationAsyncTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey,
                ConsiderIp = false,
                WifiAccessPoints = new[]
                {
                    new WifiAccessPoint
                    {
                        MacAddress =  "00:25:9c:cf:1c:ac",
                        SignalStrength = -43,
                        SignalToNoiseRatio = 0
                    },
                    new WifiAccessPoint
                    {
                        MacAddress =  "00:25:9c:cf:1c:ad",
                        SignalStrength = -55,
                        SignalToNoiseRatio = 0
                    }
                }
            };

            var result = GoogleMaps.Geolocation.QueryAsync(request).Result;

            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void ReverseGeocodingTest()
		{
			var request = new GeocodingRequest { Location = new Location(40.7141289, -73.9614074) };
			var response = GoogleMaps.Geocode.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("285 Bedford Ave, Brooklyn, NY 11211, USA", response.Results.First().FormattedAddress);
		}
		[Test]
        public void ReverseGeocodingAsyncTest()
		{
			var request = new GeocodingRequest { Location = new Location(40.7141289, -73.9614074) };
			var response = GoogleMaps.Geocode.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("285 Bedford Ave, Brooklyn, NY 11211, USA", response.Results.First().FormattedAddress);
		}
		
        [Test]
        public void ElevationTest()
		{
			var request = new ElevationRequest { Locations = new[] { new Location(40.7141289, -73.9614074) } };
            var response = GoogleMaps.Elevation.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
			Assert.AreEqual(14.782454490661619, response.Results.First().Elevation, 0.10);
		}
		[Test]
        public void ElevationAsyncTest()
		{
			var request = new ElevationRequest { Locations = new[] { new Location(40.7141289, -73.9614074) } };
            var response = GoogleMaps.Elevation.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
			Assert.AreEqual(14.782454490661619, response.Results.First().Elevation, 0.10);
		}

        [Test]
        public void DistanceMatrixTest()
        {
            var request = new DistanceMatrixRequest { Origins = new [] {new Location(40.7141289, -73.9614074), }, Destinations = new [] { new AddressLocation("185 Broadway Ave, Manhattan, NY, USA") }};
            var response = GoogleMaps.DistanceMatrix.Query(request);

            Assert.AreEqual(8247, response.Rows.First().Elements.First().Distance.Value, 100);
        }
        [Test]
        public void DistanceMatrixAsyncTest()
        {
            var request = new DistanceMatrixRequest { Origins = new[] { new Location(40.7141289, -73.9614074), }, Destinations = new[] { new AddressLocation("185 Broadway Ave, Manhattan, NY, USA") } };
            var response = GoogleMaps.DistanceMatrix.QueryAsync(request).GetAwaiter().GetResult();

            Assert.AreEqual(8247, response.Rows.First().Elements.First().Distance.Value, 100);
        }

        [Test]
        public void TimeZoneTest()
        {
            var location = new Location(40.7141289, -73.9614074);
            var request = new TimeZoneRequest { Location = location };
            var response = GoogleMaps.TimeZone.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("America/New_York", response.TimeZoneId);
            Assert.AreEqual("GMT-05:00", response.TimeZoneName);
            Assert.AreEqual(0.00, response.OffSet);
            Assert.AreEqual(-18000.00, response.RawOffSet);
        }
        [Test]
        public void TimeZoneAsyncTest()
        {
            var location = new Location(40.7141289, -73.9614074);
            var request = new TimeZoneRequest { Location = location };
            var response = GoogleMaps.TimeZone.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("America/New_York", response.TimeZoneId);
            Assert.AreEqual("GMT-05:00", response.TimeZoneName);
            Assert.AreEqual(0.00, response.OffSet);
            Assert.AreEqual(-18000.00, response.RawOffSet);
        }

        [Test]
        public void SnapToRoadsTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void SnapToRoadsAsyncTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void NearestRoadsTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void NearestRoadsAsyncTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void SpeedLimitsTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void SpeedLimitsAsyncTest()
        {
            Assert.Inconclusive();
        }

    }
}
