using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.Location.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Geocoding.Location;

[TestFixture]
public class LocationGeocodeTests : BaseTest
{
    [Test]
    public async Task LocationGeocodeTest()
    {
        var request = new LocationGeocodeRequest
        {
            Key = this.Settings.ApiKey,
            Location = new Coordinate(38.1864717,-109.9743631)
        };

        var response = await GoogleMaps.Geocode.LocationGeocode.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task LocationGeocodeWhenNoLocalCodeTest()
    {
        var request = new LocationGeocodeRequest
        {
            Key = this.Settings.ApiKey,
            Location = new Coordinate(27.0675, -40.808)
        };

        var response = await GoogleMaps.Geocode.LocationGeocode.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task LocationGeocodeWhenResultTypesTest()
    {
        var request = new LocationGeocodeRequest
        {
            Key = this.Settings.ApiKey,
            Location = new Coordinate(40.7141289, -73.9614074),
            ResultTypes = new List<LocationResultType>
            {
                LocationResultType.Street_Address
            }
        };
        var response = await GoogleMaps.Geocode.LocationGeocode.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public async Task LocationGeocodeWhenResultTypesWhenNoResultsTest()
    {
        var request = new LocationGeocodeRequest
        {
            Key = this.Settings.ApiKey,
            Location = new Coordinate(40.7141289, -73.9614074),
            ResultTypes = new List<LocationResultType>
            {
                LocationResultType.Administrative_Area_Level_7
            }
        };

        var response = await GoogleMaps.Geocode.LocationGeocode.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.ZeroResults, response.Status);
    }

    [Test]
    public async Task LocationGeocodeWhenLocationTypesTest()
    {
        var request = new LocationGeocodeRequest
        {
            Key = this.Settings.ApiKey,
            Location = new Coordinate(40.7141289, -73.9614074),
            LocationTypes = new List<GeometryLocationType>
            {
                GeometryLocationType.Rooftop
            }
        };

        var response = await GoogleMaps.Geocode.LocationGeocode.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }
}