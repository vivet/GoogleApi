using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.Directions.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Directions;

[TestFixture]
public class DirectionsTests : BaseTest
{
    [Test]
    public async Task DirectionsWhenAddressTest()
    {
        var origin = new Address("285 Bedford Ave, Brooklyn, NY, USA");
        var destination = new Address("185 Broadway Ave, Manhattan, NY, USA");
        var request = new DirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new LocationEx(origin),
            Destination = new LocationEx(destination)
        };

        var result = await GoogleMaps.Directions.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task DirectionsWhenCoordinateTest()
    {
        var origin = new CoordinateEx(55.7237480, 12.4208282);
        var destination = new CoordinateEx(55.72672682, 12.407996582);
        var request = new DirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new LocationEx(origin),
            Destination = new LocationEx(destination)
        };

        var result = await GoogleMaps.Directions.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task DirectionsWhenCoordinateAndHeadingTest()
    {
        var origin = new CoordinateEx(55.7237480, 12.4208282)
        {
            Heading = 90
        };
        var destination = new CoordinateEx(55.72672682, 12.407996582)
        {
            Heading = 90
        };
        var request = new DirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new LocationEx(origin),
            Destination = new LocationEx(destination)
        };

        var result = await GoogleMaps.Directions.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task DirectionsWhenCoordinateAndUseSideOfRoadTest()
    {
        var origin = new CoordinateEx(55.7237480, 12.4208282)
        {
            UseSideOfRoad = true
        };
        var destination = new CoordinateEx(55.72672682, 12.407996582)
        {
            UseSideOfRoad = true
        };
        var request = new DirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new LocationEx(origin),
            Destination = new LocationEx(destination)
        };

        var result = await GoogleMaps.Directions.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task DirectionsWhenPlaceIdTest()
    {
        var origin = new Place("ChIJo9YpQWBZwokR7OeY0hiWh8g");
        var destination = new Place("ChIJo9YpQWBZwokR7OeY0hiWh8g");
        var request = new DirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new LocationEx(origin),
            Destination = new LocationEx(destination)
        };

        var result = await GoogleMaps.Directions.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task DirectionsWhenAvoidWayTest()
    {
        var request = new DirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new LocationEx(new Address("285 Bedford Ave, Brooklyn, NY, USA")),
            Destination = new LocationEx(new Address("185 Broadway Ave, Manhattan, NY, USA")),
            Avoid = AvoidWay.Highways
        };

        var result = await GoogleMaps.Directions.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task DirectionsWhenTravelModeDrivingAndDepartureTimeTest()
    {
        var request = new DirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new LocationEx(new Address("285 Bedford Ave, Brooklyn, NY, USA")),
            Destination = new LocationEx(new Address("185 Broadway Ave, Manhattan, NY, USA")),
            TravelMode = TravelMode.DRIVING,
            DepartureTime = DateTime.UtcNow.AddHours(1)
        };

        var result = await GoogleMaps.Directions.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task DirectionsWhenTravelModeTransitAndArrivalTimeTest()
    {
        var request = new DirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new LocationEx(new Address("285 Bedford Ave, Brooklyn, NY, USA")),
            Destination = new LocationEx(new Address("185 Broadway Ave, Manhattan, NY, USA")),
            TravelMode = TravelMode.DRIVING,
            ArrivalTime = DateTime.UtcNow.AddHours(1),
            TransitRoutingPreference = TransitRoutingPreference.Fewer_Transfers
        };

        var result = await GoogleMaps.Directions.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task DirectionsWhenWayPointsTest()
    {
        var request = new DirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new LocationEx(new Address("NYC, USA")),
            Destination = new LocationEx(new Address("Miami, USA")),
            WayPoints = new List<WayPoint>
            {
                new(new LocationEx(new Address("Philadelphia, USA")))
            },
            OptimizeWaypoints = false
        };

        var result = await GoogleMaps.Directions.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task DirectionsWhenWayPointsAndOptimizedTest()
    {
        var request = new DirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new LocationEx(new Address("NYC, USA")),
            Destination = new LocationEx(new Address("Miami, USA")),
            WayPoints = new List<WayPoint>
            {
                new(new LocationEx(new Address("Philadelphia, USA")), true)
            },
            OptimizeWaypoints = true
        };

        var result = await GoogleMaps.Directions.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }
}