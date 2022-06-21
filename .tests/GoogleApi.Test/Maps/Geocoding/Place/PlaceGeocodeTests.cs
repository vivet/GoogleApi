using System;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Place.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Geocoding.Place;

[TestFixture]
public class PlaceGeocodeTests : BaseTest
{
    [Test]
    public void PlaceGeocodeTest()
    {
        var request = new PlaceGeocodeRequest
        {
            Key = this.Settings.ApiKey,
            PlaceId = "ChIJo9YpQWBZwokR7OeY0hiWh8g"
        };

        var response = GoogleMaps.Geocode.PlaceGeocode.Query(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public void LocationGeocodeWhenAsyncTest()
    {
        var request = new PlaceGeocodeRequest
        {
            Key = this.Settings.ApiKey,
            PlaceId = "ChIJo9YpQWBZwokR7OeY0hiWh8g"
        };
        var result = GoogleMaps.Geocode.PlaceGeocode.QueryAsync(request).Result;

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void LocationGeocodeWhenAsyncAndCancelledTest()
    {
        var request = new PlaceGeocodeRequest
        {
            Key = this.Settings.ApiKey,
            PlaceId = "ChIJo9YpQWBZwokR7OeY0hiWh8g"
        };
        var cancellationTokenSource = new CancellationTokenSource();
        var task = GoogleMaps.Geocode.PlaceGeocode.QueryAsync(request, cancellationTokenSource.Token);
        cancellationTokenSource.Cancel();

        var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "The operation was canceled.");
    }
}