using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.Directions.Request;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using GoogleApi.Entities.Maps.Elevation.Request;
using GoogleApi.Entities.Maps.Geocode.Request;
using GoogleApi.Entities.Maps.Geolocation.Request;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Request;
using GoogleApi.Entities.Maps.Roads.SnapToRoads.Request;
using GoogleApi.Entities.Maps.Roads.SpeedLimits.Request;
using GoogleApi.Entities.Maps.TimeZone.Request;
using NUnit.Framework;

namespace GoogleApi.Test
{
    [TestFixture]
    public class GoogleMapsTest : BaseTest
	{
        // Geocoding
        [Test]
        public void GeocodingWhenAddressTest()
        {
            var request = new GeocodingRequest
            {
                Address = "285 Bedford Ave, Brooklyn, NY 11211, USA"
            };
            var result = GoogleMaps.Geocode.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var geocodeResult = result.Results.FirstOrDefault();
            Assert.IsNotNull(geocodeResult);
            Assert.AreEqual(40.7140415, geocodeResult.Geometry.Location.Latitude, 0.001);
            Assert.AreEqual(-73.9613119, geocodeResult.Geometry.Location.Longitude, 0.001);
        }
        [Test]
        public void GeocodingWhenAddressAndLanguageTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void GeocodingWhenAddressAndBoundsTest()
        {
            var request = new GeocodingRequest
            {
                Address = "285 Bedford Ave, Brooklyn, NY 11211, USA",
                Bounds = new[] { new Location(40.7141289, -73.9614074), new Location(40.7141289, -73.9614074) }
            };
            var result = GoogleMaps.Geocode.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var geocodeResult = result.Results.FirstOrDefault();
            Assert.IsNotNull(geocodeResult);
            Assert.AreEqual(40.7140415, geocodeResult.Geometry.Location.Latitude, 0.001);
            Assert.AreEqual(-73.9613119, geocodeResult.Geometry.Location.Longitude, 0.001);
        }
        [Test]
        public void GeocodingWhenAddressAndRegionTest()
        {
            var request = new GeocodingRequest
            {
                Address = "285 Bedford Ave, Brooklyn, NY 11211, USA",
                Region = "Bedford"
            };
            var result = GoogleMaps.Geocode.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var geocodeResult = result.Results.FirstOrDefault();
            Assert.IsNotNull(geocodeResult);
            Assert.AreEqual(40.7140415, geocodeResult.Geometry.Location.Latitude, 0.001);
            Assert.AreEqual(-73.9613119, geocodeResult.Geometry.Location.Longitude, 0.001);
        }
        [Test]
        public void GeocodingWhenAddressAndComponentsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void GeocodingWhenLocationTest()
        {
            var request = new GeocodingRequest
            {
                Location = new Location(40.7141289, -73.9614074)
            };
            var response = GoogleMaps.Geocode.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("285 Bedford Ave, Brooklyn, NY 11211, USA", response.Results.First().FormattedAddress);
        }
        [Test]
        public void GeocodingWhenLocationAndLanguageTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void GeocodingWhenLocationAndBoundsTest()
        {
            var request = new GeocodingRequest
            {
                Location = new Location(40.7141289, -73.9614074),
                Bounds = new[] { new Location(40.7141289, -73.9614074), new Location(40.7141289, -73.9614074) }
            };
            var response = GoogleMaps.Geocode.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("Brooklyn, NY, USA", response.Results.First().FormattedAddress);
        }
        [Test]
        public void GeocodingWhenLocationAndRegionTest()
        {
            var request = new GeocodingRequest
            {
                Location = new Location(40.7141289, -73.9614074),
                Region = "Bedford"
            };
            var response = GoogleMaps.Geocode.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("285 Bedford Ave, Brooklyn, NY 11211, USA", response.Results.First().FormattedAddress);
        }
        [Test]
        public void GeocodingWhenLocationAndComponentsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void GeocodingWhenAddressAndLocationIsNullTest()
        {
            var request = new GeocodingRequest();
            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Geocode.Query(request, TimeSpan.FromMilliseconds(1)));

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Location or Address is required.");
        }
        [Test]
        public void GeocodingWhenClientCredentialsIsInvalidTest()
        {
            var request = new GeocodingRequest
            {
                Address = "test",
                ClientId = "abc",
                Key = "abc"
            };
            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Geocode.Query(request));

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "ClientId must begin with 'gme-'.");
        }

        [Test]
        public void GeocodingWhenAsyncTest()
        {
            var request = new GeocodingRequest
            {
                Address = "285 Bedford Ave, Brooklyn, NY 11211, USA"
            };
            var result = GoogleMaps.Geocode.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }
        [Test]
        public void GeocodingWhenAsyncWhenTimeoutTest()
        {
            var request = new GeocodingRequest
            {
                Address = "test"
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.Geocode.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void GeocodingWhenAsyncCancelledTest()
        {
            var request = new GeocodingRequest
            {
                Address = "test"
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.Geocode.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }


        // Geolocation
        [Test]
        public void GeolocationTest()
        {
            var request = new GeolocationRequest();
            var result = GoogleMaps.Geolocation.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }
        [Test]
        public void GeolocationWhenCarrierTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void GeolocationWhenHomeMobileCountryCodeTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void GeolocationWhenHomeMobileNetworkCodeTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void GeolocationWhenConsiderIpTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void GeolocationWhenCellTowersTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void GeolocationWhenWifiAccessPointsTest()
        {
            var request = new GeolocationRequest
            {
                WifiAccessPoints = new[]
                {
                    new WifiAccessPoint
                    {
                        MacAddress = "00:25:9c:cf:1c:ac",
                        SignalStrength = -43,
                        SignalToNoiseRatio = 0
                    },
                    new WifiAccessPoint
                    {
                        MacAddress = "00:25:9c:cf:1c:ad",
                        SignalStrength = -55,
                        SignalToNoiseRatio = 0
                    }
                }
            };
            var result = GoogleMaps.Geolocation.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void GeolocationWhenKeyIsNullTest()
        {
            var request = new GeolocationRequest
            {
                Key = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Geolocation.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void GeolocationWhenKeyIsStringEmptyTest()
        {
            var request = new GeolocationRequest
            {
                Key = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Geolocation.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void GeolocationWhenClientCredentialsIsInvalidTest()
        {
            var request = new GeocodingRequest
            {
                Address = "test",
                ClientId = "abc",
                Key = "abc"
            };
            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Geocode.Query(request));

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "ClientId must begin with 'gme-'.");
        }

        [Test]
        public void GeolocationAsyncTest()
        {
            var request = new GeolocationRequest();
            var result = GoogleMaps.Geolocation.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }
        [Test]
        public void GeolocationWhenAsyncWhenTimeoutTest()
        {
            var request = new GeolocationRequest();
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.Geolocation.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void GeolocationWhenAsyncCancelledTest()
        {
            var request = new GeolocationRequest();
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.Geolocation.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }


        // Directions
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


        // Elavation
        [Test]
        public void ElevationWhenLocationTest()
		{
			var request = new ElevationRequest
			{
			    Locations = new[] { new Location(40.7141289, -73.9614074) }
			};
            var response = GoogleMaps.Elevation.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
			Assert.AreEqual(14.782454490661619, response.Results.First().Elevation, 0.10);
		}
        [Test]
        public void ElevationWhenPathAndSamplesTest()
        {
            var request = new ElevationRequest
            {
                Path = new[] { new Location(40.7141289, -73.9614074) },
                Samples = 1
            };
            var response = GoogleMaps.Elevation.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual(14.782454490661619, response.Results.First().Elevation, 0.10);
        }
        [Test]
        public void ElevationWhenPathAndSimplesIsNullTest()
        {
            var request = new ElevationRequest
            {
                Path = new[] { new Location(40.7141289, -73.9614074) },
                Samples = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Elevation.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Samples is required, when using the Path.");
        }

        [Test]
        public void ElevationWhenLocationIsNullAndPathIsNullTest()
        {
            var request = new ElevationRequest();

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Elevation.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Locations or Path is required.");
        }

        [Test]
        public void ElevationAsyncTest()
		{
			var request = new ElevationRequest
			{
			    Locations = new[] { new Location(40.7141289, -73.9614074) }
			};
            var response = GoogleMaps.Elevation.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
		}
        [Test]
        public void ElevationWhenAsyncWhenTimeoutTest()
        {
            var request = new ElevationRequest
            {
                Locations = new[] { new Location(40.7141289, -73.9614074) }
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.Elevation.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void ElevationWhenAsyncCancelledTest()
        {
            var request = new ElevationRequest
            {
                Locations = new[] { new Location(40.7141289, -73.9614074) }
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.Elevation.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }


        // Distance Matrix
        [Test]
        public void DistanceMatrixTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new [] { new Location(40.7141289, -73.9614074) },
                Destinations = new [] { new AddressLocation("185 Broadway Ave, Manhattan, NY, USA") }
            };
            var response = GoogleMaps.DistanceMatrix.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.IsNotNull(response.OriginAddresses.FirstOrDefault());
            Assert.IsNotNull(response.DestinationAddresses.FirstOrDefault());
            
            var row = response.Rows.FirstOrDefault();
            Assert.IsNotNull(row);

            var element = row.Elements.FirstOrDefault();
            Assert.IsNotNull(element);
            Assert.AreEqual(Status.Ok, element.Status);
            Assert.IsNotNull(element.Distance.Text);
            Assert.AreEqual(8247, element.Distance.Value, 250);
            Assert.IsNotNull(element.Duration.Text);
            Assert.AreEqual(1095, element.Duration.Value.TotalSeconds, 50);
        }
        [Test]
        public void DistanceMatrixWhenLanguageTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void DistanceMatrixWhenUnitsTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void DistanceMatrixWhenAvoidWayTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void DistanceMatrixWhenTravelModeTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void DistanceMatrixWhenTransitModeTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void DistanceMatrixWhenTransitRoutingPreferenceTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void DistanceMatrixWhenArrivalTimeTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void DistanceMatrixWhenDepartureTimeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DistanceMatrixWhenOriginsIsNullTest()
        {
            var request = new DistanceMatrixRequest
            {
                Destinations = new[] { new AddressLocation("test") }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.DistanceMatrix.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Origins is required.");
        }
        [Test]
        public void DistanceMatrixWhenOriginsIsEmptyTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new ILocationString[0],
                Destinations = new[] { new Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.DistanceMatrix.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Origins is required.");
        }
        [Test]
        public void DistanceMatrixWhenDestinationsIsNullTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.DistanceMatrix.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Destinations is required.");
        }
        [Test]
        public void DistanceMatrixWhenDestinationsIsEmptyTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(0, 0) },
                Destinations = new ILocationString[0]
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.DistanceMatrix.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Destinations is required.");
        }
        [Test]
        public void DistanceMatrixWhenWhenTravelModeIsTransitAndDepartureTimeIsNullAndArrivalTimeIsNullTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(0, 0) },
                Destinations = new[] { new AddressLocation("test") },
                TravelMode = TravelMode.Transit,
                DepartureTime = null,
                ArrivalTime = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.DistanceMatrix.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "DepatureTime or ArrivalTime is required, when TravelMode is Transit.");
        }

        [Test]
        public void DistanceMatrixAsyncTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(40.7141289, -73.9614074) },
                Destinations = new[] { new AddressLocation("185 Broadway Ave, Manhattan, NY, USA") }
            };
            var response = GoogleMaps.DistanceMatrix.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }
        [Test]
        public void DistanceMatrixAsyncWhenTimeoutTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(0, 0) },
                Destinations = new[] { new AddressLocation("185 Broadway Ave, Manhattan, NY, USA") }
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.DistanceMatrix.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void DistanceMatrixAsyncCancelledTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(0, 0), },
                Destinations = new[] { new AddressLocation("test") }
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.DistanceMatrix.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }


        // TimeZone
        [Test]
        public void TimeZoneTest()
        {
            var location = new Location(40.7141289, -73.9614074);
            var request = new TimeZoneRequest
            {
                Location = location
            };

            var response = GoogleMaps.TimeZone.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual("America/New_York", response.TimeZoneId);
            Assert.AreEqual("GMT-05:00", response.TimeZoneName);
            Assert.AreEqual(0.00, response.OffSet);
            Assert.AreEqual(-18000.00, response.RawOffSet);
        }
        [Test]
        public void TimeZoneWhenLanguageTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void TimeZoneWhenLocationIsNullTest()
        {
            var request = new TimeZoneRequest();

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.TimeZone.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Location is required.");
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
        public void TimeZoneAsyncWhenTimeoutTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(40.7141289, -73.9614074), },
                Destinations = new[] { new AddressLocation("185 Broadway Ave, Manhattan, NY, USA") }
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.DistanceMatrix.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void TimeZoneAsyncCancelledTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(40.7141289, -73.9614074), },
                Destinations = new[] { new AddressLocation("185 Broadway Ave, Manhattan, NY, USA") }
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.DistanceMatrix.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }


        // Snap To Roads
        [Test]
        public void SnapToRoadTest()
        {
            var request = new SnapToRoadsRequest
            {
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var result = GoogleMaps.SnapToRoad.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void SnapToRoadWhenKeyIsNullTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = null,
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SnapToRoad.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void SnapToRoadWhenKeyIsStringEmptyTest()
        {
            var request = new SnapToRoadsRequest
            {
                Key = string.Empty,
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SnapToRoad.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void SnapToRoadWhenPathIsNullTest()
        {
            var request = new SnapToRoadsRequest();

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SnapToRoad.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Path is required.");
        }
        [Test]
        public void SnapToRoadWhenPathIsEmptyTest()
        {
            var request = new SnapToRoadsRequest
            {
                Path = new Entities.Maps.Roads.Common.Location[0]
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SnapToRoad.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Path is required.");
        }

        [Test]
        public void SnapToRoadAsyncTest()
        {
            var request = new SnapToRoadsRequest
            {
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var result = GoogleMaps.SnapToRoad.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }
        [Test]
        public void SnapToRoadAsyncWhenTimeoutTest()
        {
            var request = new SnapToRoadsRequest
            {
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0)  }
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.SnapToRoad.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void SnapToRoadAsyncCancelledTest()
        {
            var request = new SnapToRoadsRequest
            {
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.SnapToRoad.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }


        // Nearest Roads
        [Test]
        public void NearestRoadsTest()
        {
            var request = new NearestRoadsRequest
            {
                Points = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var result = GoogleMaps.NearestRoads.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void NearestRoadsWhenKeyIsNullTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = null,
                Points = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.NearestRoads.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void NearestRoadsWhenKeyIsStringEmptyTest()
        {
            var request = new NearestRoadsRequest
            {
                Key = string.Empty,
                Points = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.NearestRoads.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void NearestRoadsWhenPointsIsNullTest()
        {
            var request = new NearestRoadsRequest();

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.NearestRoads.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Points is required.");
        }
        [Test]
        public void NearestRoadsWhenPointsIsEmptyTest()
        {
            var request = new NearestRoadsRequest
            {
                Points = new Entities.Maps.Roads.Common.Location[0]
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.NearestRoads.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Points is required.");
        }

        [Test]
        public void NearestRoadsAsyncTest()
        {
            var request = new NearestRoadsRequest
            {
                Points = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var result = GoogleMaps.NearestRoads.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }
        [Test]
        public void NearestRoadsAsyncWhenTimeoutTest()
        {
            var request = new NearestRoadsRequest
            {
                Points = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.NearestRoads.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void NearestRoadsAsyncCancelledTest()
        {
            var request = new NearestRoadsRequest
            {
                Points = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.NearestRoads.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }


        // Speed Limits
        [Test]
        public void SpeedLimitsTest()
        {
            var request = new SpeedLimitsRequest
            {
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var result = GoogleMaps.SpeedLimits.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }
        [Test]
        public void SpeedLimitsWhenPlaceIdsTest()
        {
            var request = new SpeedLimitsRequest
            {
                PlaceIds = new[] { "test" }
            };
            var result = GoogleMaps.SpeedLimits.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void SpeedLimitsWhenKeyIsNullTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = null,
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SpeedLimits.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void SpeedLimitsWhenKeyIsStringEmptyTest()
        {
            var request = new SpeedLimitsRequest
            {
                Key = string.Empty,
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SpeedLimits.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void NearestRoadsWhenPathIsNullAndPlaceIdsIsNullTest()
        {
            var request = new SpeedLimitsRequest();

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SpeedLimits.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Path or PlaceId's is required.");
        }
        [Test]
        public void NearestRoadsWhenPathIsEmptyAndPlaceIdsIsEmptyTest()
        {
            var request = new SpeedLimitsRequest()
            {
                Path = new Entities.Maps.Roads.Common.Location[0],
                PlaceIds = new string[0]
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SpeedLimits.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Path or PlaceId's is required.");
        }
        [Test]
        public void SpeedLimitsWhenPlaceIdsCountIsGreaterThanAllowedTest()
        {
            var request = new SpeedLimitsRequest
            {
                PlaceIds = new string[101]
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.SpeedLimits.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Max 100 PlaceId's is allowed.");
        }

        [Test]
        public void SpeedLimitsAsyncTest()
        {
            var request = new SpeedLimitsRequest
            {
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var result = GoogleMaps.SpeedLimits.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }
        [Test]
        public void SpeedLimitsAsyncWhenTimeoutTest()
        {
            var request = new SpeedLimitsRequest
            {
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.SpeedLimits.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void SpeedLimitsAsyncCancelledTest()
        {
            var request = new SpeedLimitsRequest
            {
                Path = new[] { new Entities.Maps.Roads.Common.Location(0, 0) }
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.SpeedLimits.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }
    }
}

