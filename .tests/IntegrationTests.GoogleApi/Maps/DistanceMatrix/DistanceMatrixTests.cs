using System;
using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.GoogleApi.Maps.DistanceMatrix;

[TestClass]
public class DistanceMatrixTests : BaseTest
{
    [TestMethod]
    public async Task DistanceMatrixTest()
    {
        var origin1 = new Address("285 Bedford Ave, Brooklyn, NY, USA");
        var origin2 = new Address("1 Broadway Ave, Manhattan, NY, USA");
        var destination1 = new Address("185 Broadway Ave, Manhattan, NY, USA");
        var destination2 = new Address("200 Bedford Ave, Brooklyn, NY, USA");

        var request = new DistanceMatrixRequest
        {
            Key = this.Settings.ApiKey,
            Origins =
            [
                new LocationEx(origin1),
                new LocationEx(origin2)
            ],
            Destinations =
            [
                new LocationEx(destination1),
                new LocationEx(destination2)
            ]
        };

        var response = await GoogleMaps.DistanceMatrix.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task DistanceMatrixWhenAddressTest()
    {
        var origin = new Address("285 Bedford Ave, Brooklyn, NY, USA");
        var destination = new Address("185 Broadway Ave, Manhattan, NY, USA");

        var request = new DistanceMatrixRequest
        {
            Key = this.Settings.ApiKey,
            Origins =
            [
                new LocationEx(origin)
            ],
            Destinations =
            [
                new LocationEx(destination)
            ]
        };

        var response = await GoogleMaps.DistanceMatrix.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task DistanceMatrixWhenCoordinateTest()
    {
        var origin = new CoordinateEx(55.7237480, 12.4208282);
        var destination = new CoordinateEx(55.72672682, 12.407996582);
        var request = new DistanceMatrixRequest
        {
            Key = this.Settings.ApiKey,
            Origins =
            [
                new LocationEx(origin)
            ],
            Destinations =
            [
                new LocationEx(destination)
            ]
        };

        var response = await GoogleMaps.DistanceMatrix.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task DistanceMatrixWhenCoordinateAndHeadingTest()
    {
        var origin = new CoordinateEx(55.7237480, 12.4208282)
        {
            Heading = 90
        };
        var destination = new CoordinateEx(55.72672682, 12.407996582)
        {
            Heading = 90
        };
        var request = new DistanceMatrixRequest
        {
            Key = this.Settings.ApiKey,
            Origins =
            [
                new LocationEx(origin)
            ],
            Destinations =
            [
                new LocationEx(destination)
            ]
        };

        var response = await GoogleMaps.DistanceMatrix.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task DistanceMatrixWhenCoordinateAndUseSideOfRoadTest()
    {
        var origin = new CoordinateEx(55.7237480, 12.4208282)
        {
            UseSideOfRoad = true
        };
        var destination = new CoordinateEx(55.72672682, 12.407996582)
        {
            UseSideOfRoad = true
        };
        var request = new DistanceMatrixRequest
        {
            Key = this.Settings.ApiKey,
            Origins =
            [
                new LocationEx(origin)
            ],
            Destinations =
            [
                new LocationEx(destination)
            ]
        };

        var response = await GoogleMaps.DistanceMatrix.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task DistanceMatrixWhenPlaceIdTest()
    {
        var origin = new Place("ChIJaSLMpEVQUkYRL4xNOWBfwhQ");
        var destination = new Place("ChIJuc03_GlQUkYRlLku0KsLdJw");
        var request = new DistanceMatrixRequest
        {
            Key = this.Settings.ApiKey,
            Origins =
            [
                new LocationEx(origin)
            ],
            Destinations =
            [
                new LocationEx(destination)
            ]
        };

        var response = await GoogleMaps.DistanceMatrix.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task DistanceMatrixWhenAvoidWayTest()
    {
        var origin = new Address("285 Bedford Ave, Brooklyn, NY, USA");
        var destination = new Address("185 Broadway Ave, Manhattan, NY, USA");
        var request = new DistanceMatrixRequest
        {
            Key = this.Settings.ApiKey,
            Origins =
            [
                new LocationEx(origin)
            ],
            Destinations =
            [
                new LocationEx(destination)
            ],
            Avoid = AvoidWay.Highways
        };

        var response = await GoogleMaps.DistanceMatrix.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task DistanceMatrixWhenTravelModeDrivingAndDepartureTimeTest()
    {
        var origin = new Address("285 Bedford Ave, Brooklyn, NY, USA");
        var destination = new Address("185 Broadway Ave, Manhattan, NY, USA");
        var request = new DistanceMatrixRequest
        {
            Key = this.Settings.ApiKey,
            Origins =
            [
                new LocationEx(origin)
            ],
            Destinations =
            [
                new LocationEx(destination)
            ],
            TravelMode = TravelMode.DRIVING,
            DepartureTime = DateTime.UtcNow.AddHours(1)
        };

        var response = await GoogleMaps.DistanceMatrix.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task DistanceMatrixWhenTravelModeTransitAndArrivalTimeTest()
    {
        var origin = new Address("285 Bedford Ave, Brooklyn, NY, USA");
        var destination = new Address("185 Broadway Ave, Manhattan, NY, USA");
        var request = new DistanceMatrixRequest
        {
            Key = this.Settings.ApiKey,
            Origins =
            [
                new LocationEx(origin)
            ],
            Destinations =
            [
                new LocationEx(destination)
            ],
            TravelMode = TravelMode.DRIVING,
            ArrivalTime = DateTime.UtcNow.AddHours(1),
            TransitRoutingPreference = TransitRoutingPreference.Fewer_Transfers
        };

        var response = await GoogleMaps.DistanceMatrix.QueryAsync(request);
        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [TestMethod]
    public async Task DistanceMatrixWhenTravelModeWalking()
    {
        var origin = new Address("285 Bedford Ave, Brooklyn, NY, USA");
        var destination = new Address("185 Broadway Ave, Manhattan, NY, USA");
        var drivingRequest = new DistanceMatrixRequest
        {
            Key = this.Settings.ApiKey,
            Origins =
            [
                new LocationEx(origin)
            ],
            Destinations =
            [
                new LocationEx(destination)
            ],
            TravelMode = TravelMode.DRIVING
        };
        var drivingResponse = await GoogleMaps.DistanceMatrix.QueryAsync(drivingRequest);

        var walkingRequest = new DistanceMatrixRequest
        {
            Key = this.Settings.ApiKey,
            Origins =
            [
                new LocationEx(origin)
            ],
            Destinations =
            [
                new LocationEx(destination)
            ],
            TravelMode = TravelMode.WALKING
        };
        var walkingResponse = await GoogleMaps.DistanceMatrix.QueryAsync(walkingRequest);

        Assert.AreNotEqual(walkingResponse.RawJson, drivingResponse.RawJson, "Walking travel mode response cannot be identical to Driving mode");
    }
}