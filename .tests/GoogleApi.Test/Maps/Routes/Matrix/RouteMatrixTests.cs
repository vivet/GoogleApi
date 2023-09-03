using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.Routes.Common;
using GoogleApi.Entities.Maps.Routes.Common.Enums;
using GoogleApi.Entities.Maps.Routes.Matrix.Request;
using GoogleApi.Entities.Maps.Routes.Matrix.Request.Enums;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Routes.Matrix;

[TestFixture]
public class RouteMatrixTests : BaseTest
{
    [Test]
    public async Task RouteMatrixTest()
    {
        var request = new RoutesMatrixRequest
        {
            Key = this.Settings.ApiKey,
            Origins = new List<RouteMatrixOrigin>
            {
                new()
                {
                    Waypoint = new RouteWayPoint
                    {
                        Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.419734, Longitude = -122.0827784 } }
                    }
                }
            },
            Destinations = new List<RouteMatrixDestination>
            {
                new()
                {
                    Waypoint = new RouteWayPoint
                    {
                        Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.417670, Longitude = -122.079595 } }
                    }
                }
            },
            TravelMode = RouteTravelMode.Walk,
            TrafficModel = TrafficModel.Best_Guess
        };

        var result = await GoogleMaps.Routes.RoutesMatrix.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task RouteMatrixWhenDepartureTimeTest()
    {
        var request = new RoutesMatrixRequest
        {
            Key = this.Settings.ApiKey,
            Origins = new List<RouteMatrixOrigin>
            {
                new()
                {
                    Waypoint = new RouteWayPoint
                    {
                        Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.419734, Longitude = -122.0827784 } }
                    }
                }
            },
            Destinations = new List<RouteMatrixDestination>
            {
                new()
                {
                    Waypoint = new RouteWayPoint
                    {
                        Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.417670, Longitude = -122.079595 } }
                    }
                }
            },
            DepartureTime = DateTime.UtcNow.AddHours(5),
            RoutingPreference = RoutingPreference.TrafficAware
        };

        var result = await GoogleMaps.Routes.RoutesMatrix.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task RouteMatrixWhenLanguageTest()
    {
        var request = new RoutesMatrixRequest
        {
            Key = this.Settings.ApiKey,
            Origins = new List<RouteMatrixOrigin>
            {
                new()
                {
                    Waypoint = new RouteWayPoint
                    {
                        Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.419734, Longitude = -122.0827784 } }
                    }
                }
            },
            Destinations = new List<RouteMatrixDestination>
            {
                new()
                {
                    Waypoint = new RouteWayPoint
                    {
                        Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.417670, Longitude = -122.079595 } }
                    }
                }
            },
            Language = Language.Danish
        };

        var result = await GoogleMaps.Routes.RoutesMatrix.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task RouteMatrixWhenExtraComputationsTest()
    {
        var request = new RoutesMatrixRequest
        {
            Key = this.Settings.ApiKey,
            Origins = new List<RouteMatrixOrigin>
            {
                new()
                {
                    Waypoint = new RouteWayPoint
                    {
                        Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.419734, Longitude = -122.0827784 } }
                    }
                }
            },
            Destinations = new List<RouteMatrixDestination>
            {
                new()
                {
                    Waypoint = new RouteWayPoint
                    {
                        Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.417670, Longitude = -122.079595 } }
                    }
                }
            },
            ExtraComputations = new List<ExtraComputation> { ExtraComputation.Tolls }
        };

        var result = await GoogleMaps.Routes.RoutesMatrix.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void DirectionsWhenBadRequestTest()
    {
        var request = new RoutesMatrixRequest
        {
            Key = this.Settings.ApiKey
        };

        var exception = Assert.ThrowsAsync<GoogleApiException>(async () => await GoogleMaps.Routes.RoutesMatrix.QueryAsync(request));
        Assert.IsNotNull(exception);
        Assert.AreEqual("InvalidArgument: Request must contain at least one origin.", exception.Message);
    }
}