using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Place.Request;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GoogleApi.Test.Maps.Geocoding.Place;

[TestFixture]
public class PlaceGeocodeTests : BaseTest
{
    [Test]
    public async Task PlaceGeocodeTest()
    {
        var request = new PlaceGeocodeRequest
        {
            Key = this.Settings.ApiKey,
            PlaceId = "ChIJo9YpQWBZwokR7OeY0hiWh8g"
        };

        var response = await GoogleMaps.Geocode.PlaceGeocode.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }
}