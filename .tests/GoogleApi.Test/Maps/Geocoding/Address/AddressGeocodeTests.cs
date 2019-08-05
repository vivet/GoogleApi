using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Address.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Geocoding.Address
{
    [TestFixture]
    public class AddressGeocodeTests : BaseTest
    {
        [Test]
        public void AddressGeocodeTest()
        {
            var request = new AddressGeocodeRequest
            {
                Key = this.ApiKey,
                Address = "285 Bedford Ave, Brooklyn, NY 11211, USA"
            };
            var result = GoogleMaps.AddressGeocode.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var geocodeResult = result.Results.FirstOrDefault();
            Assert.IsNotNull(geocodeResult);
            Assert.AreEqual(40.7140415, geocodeResult.Geometry.Location.Latitude, 0.001);
            Assert.AreEqual(-73.9613119, geocodeResult.Geometry.Location.Longitude, 0.001);

            var types = geocodeResult.Types?.ToArray();
            Assert.IsNotNull(types);
            Assert.IsNotEmpty(types);
            Assert.Contains(PlaceLocationType.Premise, types);
        }

        [Test]
        public void AddressGeocodeWhenAsyncTest()
        {
            var request = new AddressGeocodeRequest
            {
                Key = this.ApiKey,
                Address = "285 Bedford Ave, Brooklyn, NY 11211, USA"
            };
            var result = GoogleMaps.AddressGeocode.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void AddressGeocodeWhenAsyncAndCancelledTest()
        {
            var request = new AddressGeocodeRequest
            {
                Address = "285 Bedford Ave, Brooklyn, NY 11211, USA"
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.AddressGeocode.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void AddressGeocodeAndLanguageTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void AddressGeocodeWhenBoundsTest()
        {
            var request = new AddressGeocodeRequest
            {
                Key = this.ApiKey,
                Address = "285 Bedford Ave, Brooklyn, NY 11211, USA",
                Bounds = new ViewPort
                {
                    NorthEast = new Entities.Common.Location(40.7141289, -73.9614074),
                    SouthWest = new Entities.Common.Location(40.7141289, -73.9614074)
                }
            };
            var result = GoogleMaps.AddressGeocode.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var geocodeResult = result.Results.FirstOrDefault();
            Assert.IsNotNull(geocodeResult);
            Assert.AreEqual(40.7140415, geocodeResult.Geometry.Location.Latitude, 0.001);
            Assert.AreEqual(-73.9613119, geocodeResult.Geometry.Location.Longitude, 0.001);
        }

        [Test]
        public void AddressGeocodeWhenRegionTest()
        {
            var request = new AddressGeocodeRequest
            {
                Key = this.ApiKey,
                Address = "285 Bedford Ave, Brooklyn, NY 11211, USA",
                Region = "Bedford"
            };
            var result = GoogleMaps.AddressGeocode.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            var geocodeResult = result.Results.FirstOrDefault();
            Assert.IsNotNull(geocodeResult);
            Assert.AreEqual(40.7140415, geocodeResult.Geometry.Location.Latitude, 0.001);
            Assert.AreEqual(-73.9613119, geocodeResult.Geometry.Location.Longitude, 0.001);
        }

        [Test]
        public void AddressGeocodeWhenComponentsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void AddressGeocodeWhenAddressIsNullTest()
        {
            var request = new AddressGeocodeRequest();

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.AddressGeocode.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Address is required");
        }
    }
}