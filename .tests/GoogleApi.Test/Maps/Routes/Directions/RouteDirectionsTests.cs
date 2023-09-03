using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.Routes.Common;
using GoogleApi.Entities.Maps.Routes.Common.Enums;
using GoogleApi.Entities.Maps.Routes.Directions.Request;
using GoogleApi.Entities.Maps.Routes.Directions.Request.Enums;
using GoogleApi.Entities.Maps.Routes.Directions.Response.Enums;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Routes.Directions;

[TestFixture]
public class RouteDirectionsTests : BaseTest
{
    [Test]
    public async Task RouteDirectionsTest()
    {
        var request = new RoutesDirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 55.672576, Longitude = 12.489753 } }
            },
            Destination = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 55.692241, Longitude = 12.538547 } }
            },
        };

        var result = await GoogleMaps.Routes.RouteDirections.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task RouteDirectionsWhenIntermediatesTest()
    {
        var request = new RoutesDirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.419734, Longitude = -122.0827784 } }
            },
            Destination = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.417670, Longitude = -122.079595 } }
            },
            Intermediates = new RouteWayPoint[]
            {
                new()
                {
                    Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.411670, Longitude = -122.073595 } }
                }
            },
            OptimizeWaypointOrder = true
        };

        var result = await GoogleMaps.Routes.RouteDirections.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task RouteDirectionsWhenDepartureTimeTest()
    {
        var request = new RoutesDirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.419734, Longitude = -122.0827784 } }
            },
            Destination = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.417670, Longitude = -122.079595 } }
            },
            RoutingPreference = RoutingPreference.TrafficAware,
            DepartureTime = DateTime.UtcNow.AddHours(5)
        };

        var result = await GoogleMaps.Routes.RouteDirections.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task RouteDirectionsWhenGeoJsonLinestringTest()
    {
        var request = new RoutesDirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.419734, Longitude = -122.0827784 } }
            },
            Destination = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.417670, Longitude = -122.079595 } }
            },
            PolylineEncoding = PolylineEncoding.GeoJsonLinestring,
        };

        var result = await GoogleMaps.Routes.RouteDirections.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
        Assert.NotNull(result.Routes.First().Polyline.GeoJsonLinestring);
    }

    [Test]
    public async Task RouteDirectionsWhenComputeAlternativeRoutesTest()
    {
        var request = new RoutesDirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.419734, Longitude = -122.0827784 } }
            },
            Destination = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.417670, Longitude = -122.079595 } }
            },
            ComputeAlternativeRoutes = true
        };

        var result = await GoogleMaps.Routes.RouteDirections.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task RouteDirectionsWhenRouteModifiersAndDriveTest()
    {
        var request = new RoutesDirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.419734, Longitude = -122.0827784 } }
            },
            Destination = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.417670, Longitude = -122.079595 } }
            },
            TravelMode = RouteTravelMode.Drive,
            RouteModifiers = new RouteModifiers
            {
                AvoidFerries = true,
                AvoidHighways = true,
                AvoidTolls = true,
                VehicleInfo = new VehicleInfo
                {
                    EmissionType = VehicleEmissionType.Hybrid
                },
                TollPasses = new List<string>
                {
                    "AU_ETOLL_TAG"
                }
            }
        };

        var result = await GoogleMaps.Routes.RouteDirections.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task RouteDirectionsWhenRouteModifiersAndWalkTest()
    {
        var request = new RoutesDirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.419734, Longitude = -122.0827784 } }
            },
            Destination = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.417670, Longitude = -122.079595 } }
            },
            TravelMode = RouteTravelMode.Walk,
            RouteModifiers = new RouteModifiers
            {
                AvoidIndoor = true
            }
        };

        var result = await GoogleMaps.Routes.RouteDirections.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task RouteDirectionsWhenLanguageTest()
    {
        var request = new RoutesDirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.419734, Longitude = -122.0827784 } }
            },
            Destination = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.417670, Longitude = -122.079595 } }
            },
            Language = Language.Danish
        };

        var result = await GoogleMaps.Routes.RouteDirections.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task RouteDirectionsWhenRegionCodeTest()
    {
        var request = new RoutesDirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.419734, Longitude = -122.0827784 } }
            },
            Destination = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.417670, Longitude = -122.079595 } }
            },
            Region = "US"
        };

        var result = await GoogleMaps.Routes.RouteDirections.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task RouteDirectionsWhenRequestedReferenceRoutesTest()
    {
        var request = new RoutesDirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.419734, Longitude = -122.0827784 } }
            },
            Destination = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.417670, Longitude = -122.079595 } }
            },
            TravelMode = RouteTravelMode.Drive,
            RoutingPreference = RoutingPreference.TrafficAwareOptimal,
            RequestedReferenceRoutes = new List<ReferenceRoute>
            {
                ReferenceRoute.FuelEfficient
            }
        };

        var result = await GoogleMaps.Routes.RouteDirections.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task RouteDirectionsWhenExtraComputationsTest()
    {
        var request = new RoutesDirectionsRequest
        {
            Key = this.Settings.ApiKey,
            Origin = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.419734, Longitude = -122.0827784 } }
            },
            Destination = new RouteWayPoint
            {
                Location = new RouteLocation { LatLng = new LatLng { Latitude = 37.417670, Longitude = -122.079595 } }
            },
            ExtraComputations = new List<ExtraComputation>
            {
                ExtraComputation.TrafficOnPolyline,
                ExtraComputation.FuelConsumption,
                ExtraComputation.Tolls
            }
        };

        var result = await GoogleMaps.Routes.RouteDirections.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void DirectionsWhenBadRequestTest()
    {
        var request = new RoutesDirectionsRequest
        {
            Key = this.Settings.ApiKey
        };

        var exception = Assert.ThrowsAsync<GoogleApiException>(async () => await GoogleMaps.Routes.RouteDirections.QueryAsync(request));
        Assert.IsNotNull(exception);
        Assert.AreEqual("InvalidArgument: Origin and destination must be set.", exception.Message);
    }
}