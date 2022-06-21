using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Elevation.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Elevation;

[TestFixture]
public class ElevationTests : BaseTest
{
    [Test]
    public void ElevationWhenLocationsTest()
    {
        var coordinate = new Coordinate(40.7141289, -73.9614074);
        var request = new ElevationRequest
        {
            Key = this.Settings.ApiKey,
            Locations = new[]
            {
                coordinate
            }
        };
        var response = GoogleMaps.Elevation.Query(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
        Assert.AreEqual(1, response.Results.Count());

        var result = response.Results.FirstOrDefault();
        Assert.IsNotNull(result);
        Assert.AreEqual(16.9243183135986, result.Elevation, 0.1);
        Assert.AreEqual(coordinate.Latitude, result.Location.Latitude);
        Assert.AreEqual(coordinate.Longitude, result.Location.Longitude);
        Assert.AreEqual(76.35161590576172, result.Resolution, 0.5);
    }

    [Test]
    public void ElevationWhenLocationsAndMultipleCoordinatesTest()
    {
        var coordinate1 = new Coordinate(40.7141289, -73.9614074);
        var coordinate2 = new Coordinate(40.714128899999999, -73.961407399999999);
        var request = new ElevationRequest
        {
            Key = this.Settings.ApiKey,
            Locations = new[]
            {
                coordinate1,
                coordinate2
            }
        };
        var response = GoogleMaps.Elevation.Query(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
        Assert.AreEqual(2, response.Results.Count());

        var result1 = response.Results.FirstOrDefault();
        Assert.IsNotNull(result1);
        Assert.AreEqual(16.9243183135986, result1.Elevation, 0.1);
        Assert.AreEqual(coordinate1.Latitude, result1.Location.Latitude);
        Assert.AreEqual(coordinate1.Longitude, result1.Location.Longitude);
        Assert.AreEqual(76.35161590576172, result1.Resolution, 0.5);

        var result2 = response.Results.FirstOrDefault();
        Assert.IsNotNull(result2);
        Assert.AreEqual(16.9243183135986, result2.Elevation, 0.1);
        Assert.AreEqual(coordinate2.Latitude, result2.Location.Latitude);
        Assert.AreEqual(coordinate2.Longitude, result2.Location.Longitude);
        Assert.AreEqual(76.35161590576172, result2.Resolution, 0.5);
    }

    [Test]
    public void ElevationWhenPathTest()
    {
        var coordinate1 = new Coordinate(40.7141289, -73.9614074);
        var coordinate2 = new Coordinate(40.714128899999999, -73.961407399999999);
        var request = new ElevationRequest
        {
            Key = this.Settings.ApiKey,
            Path = new[]
            {
                coordinate1,
                coordinate2
            },
            Samples = 2
        };
        var response = GoogleMaps.Elevation.Query(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
        Assert.AreEqual(2, response.Results.Count());

        var result1 = response.Results.FirstOrDefault();
        Assert.IsNotNull(result1);
        Assert.AreEqual(16.9243183135986, result1.Elevation, 0.1);
        Assert.AreEqual(coordinate1.Latitude, result1.Location.Latitude);
        Assert.AreEqual(coordinate1.Longitude, result1.Location.Longitude);
        Assert.AreEqual(76.35161590576172, result1.Resolution, 0.5);

        var result2 = response.Results.FirstOrDefault();
        Assert.IsNotNull(result2);
        Assert.AreEqual(16.9243183135986, result2.Elevation, 0.1);
        Assert.AreEqual(coordinate2.Latitude, result2.Location.Latitude);
        Assert.AreEqual(coordinate2.Longitude, result2.Location.Longitude);
        Assert.AreEqual(76.35161590576172, result2.Resolution, 0.5);
    }

    [Test]
    public void ElevationAsyncTest()
    {
        var request = new ElevationRequest
        {
            Key = this.Settings.ApiKey,
            Locations = new[] { new Coordinate(40.7141289, -73.9614074) }
        };
        var response = GoogleMaps.Elevation.QueryAsync(request).Result;

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public void ElevationAsyncAndCancelledTest()
    {
        var request = new ElevationRequest
        {
            Key = this.Settings.ApiKey,
            Locations = new[]
            {
                new Coordinate(40.7141289, -73.9614074)
            }
        };
        var cancellationTokenSource = new CancellationTokenSource();
        var task = GoogleMaps.Elevation.QueryAsync(request, cancellationTokenSource.Token);
        cancellationTokenSource.Cancel();

        var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "The operation was canceled.");
    }
}