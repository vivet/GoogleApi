using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Address.Request;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;

namespace GoogleApi.Test.Maps.Geocoding.Address
{
    [TestFixture]
    public class AddressGeocodeTests : BaseTest<GoogleMaps.AddressGeocodeApi>
    {
        protected override GoogleMaps.AddressGeocodeApi GetClient() => new(_httpClient);
        protected override GoogleMaps.AddressGeocodeApi GetClientStatic() => GoogleMaps.AddressGeocode;

        [Test]
        public void AddressGeocodeTest()
        {
            var request = new AddressGeocodeRequest
            {
                Key = this.ApiKey,
                Address = "285 Bedford Ave, Brooklyn, NY 11211, USA"
            };
            var result = Sut.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
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
            var result = Sut.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void AddressGeocodeWhenBoundsTest()
        {
            var request = new AddressGeocodeRequest
            {
                Key = this.ApiKey,
                Address = "285 Bedford Ave, Brooklyn, NY 11211, USA",
                Bounds = new ViewPort(new Coordinate(40.7141289, -73.9614074), new Coordinate(40.7141289, -73.9614074))
            };
            var result = Sut.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void AddressGeocodeWhenComponentsTest()
        {
            var request = new AddressGeocodeRequest
            {
                Key = this.ApiKey,
                Components = new[]
                {
                    new KeyValuePair<Component, string>(Component.Country, "dk")
                }
            };
            var result = Sut.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void AddressGeocodeWhenAsyncTest()
        {
            var request = new AddressGeocodeRequest
            {
                Key = this.ApiKey,
                Address = "285 Bedford Ave, Brooklyn, NY 11211, USA"
            };
            var result = Sut.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void AddressGeocodeWhenAsyncAndCancelledTest()
        {
            var request = new AddressGeocodeRequest
            {
                Key = this.ApiKey,
                Address = "285 Bedford Ave, Brooklyn, NY 11211, USA"
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