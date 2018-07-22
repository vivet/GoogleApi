using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Location.Request;
using GoogleApi.Exceptions;
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
                Location = new Entities.Common.Location(40.7141289, -73.9614074)
            };
            var response = GoogleMaps.LocationGeocode.Query(request);
            var result = response.Results.FirstOrDefault();

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);

            Assert.IsNotNull(result);
            Assert.AreEqual("285 Bedford Ave, Brooklyn, NY 11211, USA", result.FormattedAddress);

            var types = result.Types?.ToArray();
            Assert.IsNotNull(types);
            Assert.IsNotEmpty(types);
            Assert.Contains(PlaceLocationType.Premise, types);
        }

        [Test]
        public void LocationGeocodeWhenAsyncTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = this.ApiKey,
                Location = new Entities.Common.Location(40.7141289, -73.9614074)
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
                Location = new Entities.Common.Location(40.7141289, -73.9614074)
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.LocationGeocode.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void LocationGeocodeAndLanguageTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void LocationGeocodeWhenResultTypesTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = this.ApiKey,
                Location = new Entities.Common.Location(40.7141289, -73.9614074),
                ResultTypes = new List<PlaceLocationType> { PlaceLocationType.Premise, PlaceLocationType.Accounting }
            };
            var response = GoogleMaps.LocationGeocode.Query(request);
            var result = response.Results.FirstOrDefault();

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);

            Assert.IsNotNull(result);
            Assert.AreEqual("285 Bedford Ave, Brooklyn, NY 11211, USA", result.FormattedAddress);

            var types = result.Types?.ToArray();
            Assert.IsNotNull(types);
            Assert.IsNotEmpty(types);
            Assert.Contains(PlaceLocationType.Premise, types);
        }

        [Test]
        public void LocationGeocodeWhenResultTypesWhenNoResultsTest()
        {
            var request = new LocationGeocodeRequest
            {
                Key = this.ApiKey,
                Location = new Entities.Common.Location(40.7141289, -73.9614074),
                ResultTypes = new List<PlaceLocationType> { PlaceLocationType.Accounting }
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
                Location = new Entities.Common.Location(40.7141289, -73.9614074),
                LocationTypes = new List<GeometryLocationType> {  GeometryLocationType.Rooftop }
            };
            var response = GoogleMaps.LocationGeocode.Query(request);
            var result = response.Results.FirstOrDefault();

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);

            Assert.IsNotNull(result);
            Assert.AreEqual("285 Bedford Ave, Brooklyn, NY 11211, USA", result.FormattedAddress);
            Assert.AreEqual(GeometryLocationType.Rooftop, result.Geometry.LocationType);
        }

        [Test]
        public void LocationGeocodeWhenLocationIsNullTest()
        {
            var request = new LocationGeocodeRequest();

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.LocationGeocode.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Location is required");
        }
    }
}