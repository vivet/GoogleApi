using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocode.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Geocode
{
    [TestFixture]
    public class GeocodingTests : BaseTest
    {
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

            var types = geocodeResult.Types?.ToArray();
            Assert.IsNotNull(types);
            Assert.IsNotEmpty(types);
            Assert.Contains(PlaceLocationType.Street_Address, types);
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
        public void GeocodingWhenAsyncAndTimeoutTest()
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
        public void GeocodingWhenAsyncAndCancelledTest()
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
        public void GeocodingWhenAddressAndLanguageTest()
        {
            Assert.Inconclusive();
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
            Assert.AreEqual("285 Bedford Ave, Brooklyn, NY 11211, USA", response.Results.First().FormattedAddress);
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
        public void GeocodingWhenLocationAndLanguageTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void GeocodingWhenLocationAndComponentsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void GeocodingWhenAddressAndPlaceIdAndLocationIsNullTest()
        {
            var request = new GeocodingRequest();
            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Geocode.Query(request, TimeSpan.FromMilliseconds(1)));

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Location, PlaceId or Address is required");
        }

        [Test]
        public void GeocodingWhenPlaceAndKeyIsNullTest()
        {
            var request = new GeocodingRequest
            {
                PlaceId = "test"
            };
            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Geocode.Query(request, TimeSpan.FromMilliseconds(1)));

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required, when using PlaceId");
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
    }
}