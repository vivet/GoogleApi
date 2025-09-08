using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Place.Request;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.Test.Maps.Geocoding.Place;

[TestClass]
public class PlaceGeocodeTests : BaseTest
{
    [TestMethod]
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