using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Location.Request;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;

namespace GoogleApi.Test.Maps.Geocoding.Location
{
    [TestFixture]
    public class LocationGeocodeTests : BaseTest<GoogleMaps.LocationGeocodeApi>
    {
        protected override GoogleMaps.LocationGeocodeApi GetClient() => new(_httpClient);
        protected override GoogleMaps.LocationGeocodeApi GetClientStatic() => GoogleMaps.LocationGeocode;

        [Test]
        public void LocationGeocodeTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = this.ApiKey,
                Location = new Coordinate(40.7141289, -73.9614074)
            };

            var response = Sut.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void LocationGeocodeWhenNoLocalCodeTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = this.ApiKey,
                Location = new Coordinate(27.0675, -40.808)
            };

            var response = Sut.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void LocationGeocodeWhenResultTypesTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = this.ApiKey,
                Location = new Coordinate(40.7141289, -73.9614074),
                ResultTypes = new List<PlaceLocationType>
                {
                    PlaceLocationType.Premise,
                    PlaceLocationType.Accounting
                }
            };
            var response = Sut.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void LocationGeocodeWhenResultTypesWhenNoResultsTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = this.ApiKey,
                Location = new Coordinate(40.7141289, -73.9614074),
                ResultTypes = new List<PlaceLocationType>
                {
                    PlaceLocationType.Accounting
                }
            };
            var response = Sut.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.ZeroResults, response.Status);
        }

        [Test]
        public void LocationGeocodeWhenLoncationTypesTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = this.ApiKey,
                Location = new Coordinate(40.7141289, -73.9614074),
                LocationTypes = new List<GeometryLocationType>
                {
                    GeometryLocationType.Rooftop
                }
            };

            var response = Sut.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void LocationGeocodeWhenAsyncTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = this.ApiKey,
                Location = new Coordinate(40.7141289, -73.9614074)
            };
            var result = Sut.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void LocationGeocodeWhenAsyncAndCancelledTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = this.ApiKey,
                Location = new Coordinate(40.7141289, -73.9614074)
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