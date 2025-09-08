using System.Linq;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Elevation.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.Test.Maps.Elevation;

[TestClass]
public class ElevationTests : BaseTest
{
    [TestMethod]
    public async Task ElevationWhenLocationsTest()
    {
        var coordinate = new Coordinate(40.7141289, -73.9614074);
        var request = new ElevationRequest
        {
            Key = this.Settings.ApiKey,
            Locations =
            [
                coordinate
            ]
        };
        var response = await GoogleMaps.Elevation.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
        Assert.AreEqual(1, response.Results.Count());

        var result = response.Results.FirstOrDefault();
        Assert.IsNotNull(result);
        Assert.AreEqual(16.9243183135986, result.Elevation.GetValueOrDefault(), 0.1);
        Assert.AreEqual(coordinate.Latitude, result.Location.Latitude);
        Assert.AreEqual(coordinate.Longitude, result.Location.Longitude);
        Assert.AreEqual(76.35161590576172, result.Resolution.GetValueOrDefault(), 0.5);
    }

    [TestMethod]
    public async Task ElevationWhenLocationsAndMultipleCoordinatesTest()
    {
        var coordinate1 = new Coordinate(40.7141289, -73.9614074);
        var coordinate2 = new Coordinate(40.714128899999999, -73.961407399999999);
        var request = new ElevationRequest
        {
            Key = this.Settings.ApiKey,
            Locations =
            [
                coordinate1,
                coordinate2
            ]
        };
        var response = await GoogleMaps.Elevation.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
        Assert.AreEqual(2, response.Results.Count());

        var result1 = response.Results.FirstOrDefault();
        Assert.IsNotNull(result1);
        Assert.AreEqual(16.9243183135986, result1.Elevation.GetValueOrDefault(), 0.1);
        Assert.AreEqual(coordinate1.Latitude, result1.Location.Latitude);
        Assert.AreEqual(coordinate1.Longitude, result1.Location.Longitude);
        Assert.AreEqual(76.35161590576172, result1.Resolution.GetValueOrDefault(), 0.5);

        var result2 = response.Results.FirstOrDefault();
        Assert.IsNotNull(result2);
        Assert.AreEqual(16.9243183135986, result2.Elevation.GetValueOrDefault(), 0.1);
        Assert.AreEqual(coordinate2.Latitude, result2.Location.Latitude);
        Assert.AreEqual(coordinate2.Longitude, result2.Location.Longitude);
        Assert.AreEqual(76.35161590576172, result2.Resolution.GetValueOrDefault(), 0.5);
    }

    [TestMethod]
    public async Task ElevationWhenPathTest()
    {
        var coordinate1 = new Coordinate(40.7141289, -73.9614074);
        var coordinate2 = new Coordinate(40.714128899999999, -73.961407399999999);
        var request = new ElevationRequest
        {
            Key = this.Settings.ApiKey,
            Path =
            [
                coordinate1,
                coordinate2
            ],
            Samples = 2
        };
        var response = await GoogleMaps.Elevation.QueryAsync(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
        Assert.AreEqual(2, response.Results.Count());

        var result1 = response.Results.FirstOrDefault();
        Assert.IsNotNull(result1);
        Assert.AreEqual(16.9243183135986, result1.Elevation.GetValueOrDefault(), 0.1);
        Assert.AreEqual(coordinate1.Latitude, result1.Location.Latitude);
        Assert.AreEqual(coordinate1.Longitude, result1.Location.Longitude);
        Assert.AreEqual(76.35161590576172, result1.Resolution.GetValueOrDefault(), 0.5);

        var result2 = response.Results.FirstOrDefault();
        Assert.IsNotNull(result2);
        Assert.AreEqual(16.9243183135986, result2.Elevation.GetValueOrDefault(), 0.1);
        Assert.AreEqual(coordinate2.Latitude, result2.Location.Latitude);
        Assert.AreEqual(coordinate2.Longitude, result2.Location.Longitude);
        Assert.AreEqual(76.35161590576172, result2.Resolution.GetValueOrDefault(), 0.5);
    }
}