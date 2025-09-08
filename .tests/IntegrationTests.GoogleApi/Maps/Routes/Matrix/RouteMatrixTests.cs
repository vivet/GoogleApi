using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Routes.Common;
using GoogleApi.Entities.Maps.Routes.Matrix.Request;
using GoogleApi.Entities.Maps.Routes.Matrix.Request.Enums;
using GoogleApi.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.Test.Maps.Routes.Matrix;

[TestClass]
public class RouteMatrixTests : BaseTest
{
    [TestMethod]
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
            }
        };

        var result = await GoogleMaps.Routes.RoutesMatrix.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
        Assert.IsNotEmpty(result.Elements);
    }

    [TestMethod]
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

    [TestMethod]
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

    [TestMethod]
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

    [TestMethod]
    public async Task DirectionsWhenBadRequestTest()
    {
        var request = new RoutesMatrixRequest
        {
            Key = this.Settings.ApiKey
        };

        var exception = await Assert.ThrowsExceptionAsync<GoogleApiException>(async () => await GoogleMaps.Routes.RoutesMatrix.QueryAsync(request));

        Assert.IsNotNull(exception);
        Assert.AreEqual("InvalidArgument: Request must contain at least one origin.", exception.Message);
    }
}