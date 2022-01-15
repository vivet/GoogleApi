using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Place.Request;
using NUnit.Framework;
using System;
using System.Threading;

namespace GoogleApi.Test.Maps.Geocoding.Place
{
    [TestFixture]
    public class PlaceGeocodeTests : BaseTest<GoogleMaps.PlaceGeoCodeApi>
    {
        protected override GoogleMaps.PlaceGeoCodeApi GetClient() => new(_httpClient);
        protected override GoogleMaps.PlaceGeoCodeApi GetClientStatic() => GoogleMaps.PlaceGeocode;

        [Test]
        public void PlaceGeocodeTest()
        {
            var request = new PlaceGeocodeRequest
            {
                Key = this.ApiKey,
                PlaceId = "ChIJo9YpQWBZwokR7OeY0hiWh8g"
            };

            var response = Sut.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void LocationGeocodeWhenAsyncTest()
        {
            var request = new PlaceGeocodeRequest
            {
                Key = this.ApiKey,
                PlaceId = "ChIJo9YpQWBZwokR7OeY0hiWh8g"
            };
            var result = Sut.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void LocationGeocodeWhenAsyncAndCancelledTest()
        {
            var request = new PlaceGeocodeRequest
            {
                Key = this.ApiKey,
                PlaceId = "ChIJo9YpQWBZwokR7OeY0hiWh8g"
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