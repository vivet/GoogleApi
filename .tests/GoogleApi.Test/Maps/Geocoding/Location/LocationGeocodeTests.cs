using System;
using System.Collections.Generic;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Location.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Geocoding.Location
{
    [TestFixture]
    public class LocationGeocodeTests : BaseTest
    {
        [Test]
        public void LocationGeocodeTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = this.ApiKey,
                Location = new Coordinate(40.7141289, -73.9614074)
            };

            var response = GoogleMaps.LocationGeocode.Query(request);

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

            var response = GoogleMaps.LocationGeocode.Query(request);

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
            var response = GoogleMaps.LocationGeocode.Query(request);

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
            var response = GoogleMaps.LocationGeocode.Query(request);

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

            var response = GoogleMaps.LocationGeocode.Query(request);

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
            var result = GoogleMaps.LocationGeocode.QueryAsync(request).Result;

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
            var task = GoogleMaps.LocationGeocode.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }
    }
}