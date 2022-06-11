using System;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Geocoding.PlusCode
{
    [TestFixture]
    public class PlusCodeGeocodeTests : BaseTest
    {
        [Test]
        public void PlusCodeGeocodeWhenLocationTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.Settings.ApiKey,
                Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new Coordinate(40.71406249999997, -73.9613125))
            };

            var response = GoogleMaps.Geocode.PlusCodeGeocode.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.IsNotNull(response.PlusCode.Locality);
            Assert.AreEqual("87G8P27Q+JF", response.PlusCode.GlobalCode);
        }

        [Test]
        public void PlusCodeGeocodeWhenLocationWhenKeyIsNullTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new Coordinate(40.71406249999997, -73.9613125))
            };
            var response = GoogleMaps.Geocode.PlusCodeGeocode.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.IsNull(response.PlusCode.Locality.PlaceId);
            Assert.IsNull(response.PlusCode.Locality.Address);
            Assert.AreEqual("87G8P27Q+JF", response.PlusCode.GlobalCode);
        }

        [Test]
        public void PlusCodeGeocodeWhenAddressTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.Settings.ApiKey,
                Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new Entities.Common.Address("285 Bedford Ave, Brooklyn, NY 11211, USA"))
            };

            var response = GoogleMaps.Geocode.PlusCodeGeocode.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlusCodeGeocodeWhenGlobalCodeTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.Settings.ApiKey,
                Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new GlobalCode("796RWF8Q+WF"))
            };

            var response = GoogleMaps.Geocode.PlusCodeGeocode.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlusCodeGeocodeWhenLocalCodeAndLocalityTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.Settings.ApiKey,
                Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new LocalCodeAndLocality("WF8Q+WF Praia", "Cape Verde"))
            };

            var response = GoogleMaps.Geocode.PlusCodeGeocode.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlusCodeGeocodeWhenAsyncTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.Settings.ApiKey,
                Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new Coordinate(40.71406249999997, -73.9613125))
            };
            var result = GoogleMaps.Geocode.PlusCodeGeocode.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void PlusCodeGeocodeWhenAsyncAndCancelledTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.Settings.ApiKey,
                Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new Coordinate(40.71406249999997, -73.9613125))
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.Geocode.PlusCodeGeocode.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }
    }
}