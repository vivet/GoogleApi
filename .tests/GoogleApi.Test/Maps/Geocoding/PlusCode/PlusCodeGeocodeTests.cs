using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.Test.Maps.Geocoding.PlusCode;

[TestClass]
public class PlusCodeGeocodeTests : BaseTest
{
    [TestMethod]
    public async Task PlusCodeGeocodeWhenLocationTest()
    {
        var request = new PlusCodeGeocodeRequest
        {
            Key = this.Settings.ApiKey,
            Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new Coordinate(40.71406249999997, -73.9613125))
        };

        var response = await GoogleMaps.Geocode.PlusCodeGeocode.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
        Assert.IsNotNull(response.PlusCode.Locality);
        Assert.AreEqual("87G8P27Q+JF", response.PlusCode.GlobalCode);
    }

    [TestMethod]
    public async Task PlusCodeGeocodeWhenLocationWhenKeyIsNullTest()
    {
        var request = new PlusCodeGeocodeRequest
        {
            Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new Coordinate(40.71406249999997, -73.9613125))
        };
        var response = await GoogleMaps.Geocode.PlusCodeGeocode.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
        Assert.IsNull(response.PlusCode.Locality.PlaceId);
        Assert.IsNull(response.PlusCode.Locality.Address);
        Assert.AreEqual("87G8P27Q+JF", response.PlusCode.GlobalCode);
    }

    [TestMethod]
    [Ignore("Returns IP restriction issue")]
    public async Task PlusCodeGeocodeWhenAddressTest()
    {
        var request = new PlusCodeGeocodeRequest
        {
            Key = this.Settings.ApiKey,
            Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new Entities.Common.Address("285 Bedford Ave, Brooklyn, NY 11211, USA"))
        };

        var response = await GoogleMaps.Geocode.PlusCodeGeocode.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    [Ignore("Returns IP restriction issue")]
    public async Task PlusCodeGeocodeWhenGlobalCodeTest()
    {
        var request = new PlusCodeGeocodeRequest
        {
            Key = this.Settings.ApiKey,
            Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new GlobalCode("796RWF8Q+WF"))
        };

        var response = await GoogleMaps.Geocode.PlusCodeGeocode.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    [Ignore("Returns IP restriction issue")]
    public async Task PlusCodeGeocodeWhenLocalCodeAndLocalityTest()
    {
        var request = new PlusCodeGeocodeRequest
        {
            Key = this.Settings.ApiKey,
            Address = new Entities.Maps.Geocoding.PlusCode.Request.Location(new LocalCodeAndLocality("WF8Q+WF Praia", "Cape Verde"))
        };

        var response = await GoogleMaps.Geocode.PlusCodeGeocode.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }
}