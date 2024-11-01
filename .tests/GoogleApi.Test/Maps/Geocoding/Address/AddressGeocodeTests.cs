using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Address.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.Test.Maps.Geocoding.Address;

[TestClass]
public class AddressGeocodeTests : BaseTest
{
    [TestMethod]
    public async Task AddressGeocodeTest()
    {
        var request = new AddressGeocodeRequest
        {
            Key = this.Settings.ApiKey,
            Address = "285 Bedford Ave, Brooklyn, NY 11211, USA"
        };
        var result = await GoogleMaps.Geocode.AddressGeocode.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [TestMethod]
    public async Task AddressGeocodeWhenRegionTest()
    {
        var request = new AddressGeocodeRequest
        {
            Key = this.Settings.ApiKey,
            Address = "285 Bedford Ave, Brooklyn, NY 11211, USA",
            Region = "Bedford"
        };
        var result = await GoogleMaps.Geocode.AddressGeocode.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [TestMethod]
    public async Task AddressGeocodeWhenBoundsTest()
    {
        var request = new AddressGeocodeRequest
        {
            Key = this.Settings.ApiKey,
            Address = "285 Bedford Ave, Brooklyn, NY 11211, USA",
            Bounds = new ViewPort(new Coordinate(40.7141289, -73.9614074), new Coordinate(40.7141289, -73.9614074))
        };
        var result = await GoogleMaps.Geocode.AddressGeocode.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [TestMethod]
    public async Task AddressGeocodeWhenComponentsTest()
    {
        var request = new AddressGeocodeRequest
        {
            Key = this.Settings.ApiKey,
            Components = new[]
            {
                new KeyValuePair<Component, string>(Component.Country, "dk")
            }
        };
        var result = await GoogleMaps.Geocode.AddressGeocode.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }
}