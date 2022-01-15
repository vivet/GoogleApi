using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using NUnit.Framework;
using System;
using System.Threading;

namespace GoogleApi.Test.Maps.Geocoding.PlusCode
{
    [TestFixture]
    public class PlusCodeGeocodeTests : BaseTest<GoogleMaps.PlusCodeGeocodeApi>
    {
        protected override GoogleMaps.PlusCodeGeocodeApi GetClient() => new(_httpClient);
        protected override GoogleMaps.PlusCodeGeocodeApi GetClientStatic() => GoogleMaps.PlusCodeGeocode;

        [Test]
        public void PlusCodeGeocodeWhenLocationTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.ApiKey,
                Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new Coordinate(40.71406249999997, -73.9613125))
            };

            var response = Sut.Query(request);

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
            var response = Sut.Query(request);

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
                Key = this.ApiKey,
                Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new Entities.Common.Address("285 Bedford Ave, Brooklyn, NY 11211, USA"))
            };

            var response = Sut.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlusCodeGeocodeWhenGlobalCodeTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.ApiKey,
                Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new GlobalCode("796RWF8Q+WF"))
            };

            var response = Sut.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlusCodeGeocodeWhenLocalCodeAndLocalityTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.ApiKey,
                Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new LocalCodeAndLocality("WF8Q+WF Praia", "Cape Verde"))
            };

            var response = Sut.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlusCodeGeocodeWhenAsyncTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.ApiKey,
                Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new Coordinate(40.71406249999997, -73.9613125))
            };
            var result = Sut.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void PlusCodeGeocodeWhenAsyncAndCancelledTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.ApiKey,
                Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new Coordinate(40.71406249999997, -73.9613125))
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = Sut.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual("The operation was canceled.", exception.Message);
        }
    }
}