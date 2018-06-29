using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
                Location = new Entities.Common.Location(40.7141289, -73.9614074)
            };
            var result = GoogleMaps.LocationGeocode.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void LocationGeocodeWhenAsyncAndTimeoutTest()
        {
            var request = new LocationGeocodeRequest
            {
                Location = new Entities.Common.Location(40.7141289, -73.9614074)
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.LocationGeocode.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void LocationGeocodeWhenLoncationTypesTest()
        {
            var request = new LocationGeocodeRequest
            {
                Location = new Entities.Common.Location(40.7141289, -73.9614074),
                LocationTypes = new List<GeometryLocationType> {  GeometryLocationType.Rooftop }
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
        public void LocationGeocodeWhenLocationIsNullTest()
        {
            var request = new LocationGeocodeRequest();
            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.LocationGeocode.Query(request, TimeSpan.FromMilliseconds(1)));

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Location is required.");
        }
    }
}