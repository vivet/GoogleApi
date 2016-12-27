using System;
using System.Linq;
using System.Net;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using GoogleApi.Entities.Maps.Elevation.Request;
using GoogleApi.Entities.Maps.Geocode.Request;
using GoogleApi.Entities.Maps.Geolocation.Request;
using GoogleApi.Entities.Maps.TimeZone.Request;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
    public class GoogleMapsTest : BaseTest
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
            Assert.AreEqual(133, _overviewPath.Points.Count(), 5);
            Assert.AreEqual(5, _polyline.Points.Count());
            Assert.AreEqual(8253, _result.Routes.First().Legs.First().Steps.Sum(_s => _s.Distance.Value), 300);
            Assert.AreEqual(355, _result.Routes.First().Legs.First().Steps.Sum(_s => _s.Duration.Value.Seconds), 50);
        }
        [Test]
        public void DirectionsTestAsyncTest()
        {
            var _request = new DirectionsRequest { Origin = "285 Bedford Ave, Brooklyn, NY, USA", Destination = "185 Broadway Ave, Manhattan, NY, USA" };

            var _result = GoogleMaps.Directions.QueryAsync(_request).Result;
            var _overviewPath = _result.Routes.First().OverviewPath;
            var _polyline = _result.Routes.First().Legs.First().Steps.First().PolyLine;

            if (_result.Status == Status.OVER_QUERY_LIMIT)
                Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.OK, _result.Status);
            Assert.AreEqual(133, _overviewPath.Points.Count(), 5);
            Assert.AreEqual(5, _polyline.Points.Count());
            Assert.AreEqual(8253, _result.Routes.First().Legs.First().Steps.Sum(_s => _s.Distance.Value), 300);
            Assert.AreEqual(355, _result.Routes.First().Legs.First().Steps.Sum(_s => _s.Duration.Value.Seconds), 50);
        }
        [Test]
        public void DirectionsWhenhWayPointsTest()
        {
            var _request = new DirectionsRequest { Origin = "NYC, USA", Destination = "Miami, USA", Waypoints = new[] { "Philadelphia, USA" }, OptimizeWaypoints = true };

            var _result = GoogleMaps.Directions.Query(_request);

            if (_result.Status == Status.OVER_QUERY_LIMIT)
                Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.OK, _result.Status);
            Assert.AreEqual(156084, _result.Routes.First().Legs.First().Steps.Sum(_s => _s.Distance.Value), 500);

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
            Assert.AreEqual(40.7140415, _result.Results.First().Geometry.Location.Latitude, 0.001);
            Assert.AreEqual(-73.9613119, _result.Results.First().Geometry.Location.Longitude, 0.001);
        }
        [Test]
        public void GeocodingAsyncTest()
        {
            var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };

            var _result = GoogleMaps.Geocode.QueryAsync(_request).Result;

            if (_result.Status == Status.OVER_QUERY_LIMIT)
                Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.OK, _result.Status);
            Assert.AreEqual(40.7140415, _result.Results.First().Geometry.Location.Latitude, 0.001);
            Assert.AreEqual(-73.9613119, _result.Results.First().Geometry.Location.Longitude, 0.001);
        }
        [Test]
        public void GeocodingAsyncCancelledTest()
        {
            var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };

            var _cancellationTokenSource = new CancellationTokenSource();
            var _task = GoogleMaps.Geocode.QueryAsync(_request, _cancellationTokenSource.Token);
            _cancellationTokenSource.Cancel();

            Assert.Throws<OperationCanceledException>(() =>
            {
                try
                {
                    _task.Wait(_cancellationTokenSource.Token);
                }
                catch (AggregateException _ex)
                {
                    throw _ex.Flatten().InnerException ?? _ex;
                }
            });
        }
        [Test]
        public void GeocodingWhenTimeoutTest()
        {
            var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA" };
            Assert.Throws<WebException>(() =>
            {
                try
                {
                    GoogleMaps.Geocode.Query(_request, TimeSpan.FromMilliseconds(1));
                }
                catch (AggregateException _ex)
                {
                    throw _ex.InnerException ?? _ex;
                }
            });
        }
        [Test]
        public void GeocodingWhenInvalidClientCredentialsTest()
        {
            var _request = new GeocodingRequest { Address = "285 Bedford Ave, Brooklyn, NY 11211, USA", ClientId = "gme-ThisIsAUnitTest", Key = "AAECAwQFBgcICQoLDA0ODxAREhM=" };
            Assert.Throws<WebException>(() =>
            {
                try
                {
                    GoogleMaps.Geocode.Query(_request);
                }
                catch (AggregateException _ex)
                {
                    throw _ex.InnerException ?? _ex;
                }
            });
        }

        [Test]
        public void GeolocationTest()
        {
            var _request = new GeolocationRequest
            {
                Key = this._apiKey,
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

            var _result = GoogleMaps.Geolocation.Query(_request);

            Assert.AreEqual(Status.OK, _result.Status);
        }
        [Test]
        public void GeolocationAsyncTest()
        {
            var _request = new GeolocationRequest
            {
                Key = this._apiKey,
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

            var _result = GoogleMaps.Geolocation.QueryAsync(_request).Result;

            Assert.AreEqual(Status.OK, _result.Status);
        }

        [Test]
        public void ReverseGeocodingTest()
		{
			var _request = new GeocodingRequest { Location = new Location(40.7141289, -73.9614074) };
			var _response = GoogleMaps.Geocode.Query(_request);

			if (_response.Status == Status.OVER_QUERY_LIMIT)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

			Assert.AreEqual(Status.OK, _response.Status);
            Assert.AreEqual("285 Bedford Ave, Brooklyn, NY 11211, USA", _response.Results.First().FormattedAddress);
		}
		[Test]
        public void ReverseGeocodingAsyncTest()
		{
			var _request = new GeocodingRequest { Location = new Location(40.7141289, -73.9614074) };
			var _response = GoogleMaps.Geocode.QueryAsync(_request).Result;

			if (_response.Status == Status.OVER_QUERY_LIMIT)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

			Assert.AreEqual(Status.OK, _response.Status);
            Assert.AreEqual("285 Bedford Ave, Brooklyn, NY 11211, USA", _response.Results.First().FormattedAddress);
		}
		
        [Test]
        public void ElevationTest()
		{
			var _request = new ElevationRequest { Locations = new[] { new Location(40.7141289, -73.9614074) } };
            var _response = GoogleMaps.Elevation.Query(_request);

            if (_response.Status == Status.OVER_QUERY_LIMIT)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

            Assert.AreEqual(Status.OK, _response.Status);
			Assert.AreEqual(14.782454490661619, _response.Results.First().Elevation, 0.10);
		}
		[Test]
        public void ElevationAsyncTest()
		{
			var _request = new ElevationRequest { Locations = new[] { new Location(40.7141289, -73.9614074) } };
            var _response = GoogleMaps.Elevation.QueryAsync(_request).Result;

			if (_response.Status == Status.OVER_QUERY_LIMIT)
				Assert.Inconclusive("Cannot run test since you have exceeded your Google API query limit.");

			Assert.AreEqual(Status.OK, _response.Status);
			Assert.AreEqual(14.782454490661619, _response.Results.First().Elevation, 0.10);
		}

        [Test]
        public void DistanceMatrixTest()
        {
            var _request = new DistanceMatrixRequest { Origins = new [] {new Location(40.7141289, -73.9614074), }, Destinations = new [] { new AddressLocation("185 Broadway Ave, Manhattan, NY, USA") }};
            var _response = GoogleMaps.DistanceMatrix.Query(_request);

            Assert.AreEqual(8247, _response.Rows.First().Elements.First().Distance.Value, 100);
        }
        [Test]
        public void DistanceMatrixAsyncTest()
        {
            var _request = new DistanceMatrixRequest { Origins = new[] { new Location(40.7141289, -73.9614074), }, Destinations = new[] { new AddressLocation("185 Broadway Ave, Manhattan, NY, USA") } };
            var _response = GoogleMaps.DistanceMatrix.QueryAsync(_request).GetAwaiter().GetResult();

            Assert.AreEqual(8247, _response.Rows.First().Elements.First().Distance.Value, 100);
        }

        [Test]
        public void TimeZoneTest()
        {
            var _location = new Location(40.7141289, -73.9614074);
            var _request = new TimeZoneRequest { Location = _location };
            var _response = GoogleMaps.TimeZone.Query(_request);

            Assert.IsNotNull(_response);
            Assert.AreEqual(Status.OK, _response.Status);
            Assert.AreEqual("America/New_York", _response.TimeZoneId);
            Assert.AreEqual("GMT-05:00", _response.TimeZoneName);
            Assert.AreEqual(0.00, _response.OffSet);
            Assert.AreEqual(-18000.00, _response.RawOffSet);
        }
        [Test]
        public void TimeZoneAsyncTest()
        {
            var _location = new Location(40.7141289, -73.9614074);
            var _request = new TimeZoneRequest { Location = _location };
            var _response = GoogleMaps.TimeZone.QueryAsync(_request).Result;

            Assert.IsNotNull(_response);
            Assert.AreEqual(Status.OK, _response.Status);
            Assert.AreEqual("America/New_York", _response.TimeZoneId);
            Assert.AreEqual("GMT-05:00", _response.TimeZoneName);
            Assert.AreEqual(0.00, _response.OffSet);
            Assert.AreEqual(-18000.00, _response.RawOffSet);
        }
	}
}
