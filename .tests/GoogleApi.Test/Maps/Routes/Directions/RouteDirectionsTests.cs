using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
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
    public void RouteDirectionsTest()
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
            }
        };

        var result = GoogleMaps.Routes.Direcions.Query(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void RouteDirectionsWhenIntermediatesTest()
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
            }
        };

        var result = GoogleMaps.Routes.Direcions.Query(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void RouteDirectionsWhenDepartureTimeTest()
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

        var result = GoogleMaps.Routes.Direcions.Query(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void RouteDirectionsWhenGeoJsonLinestringTest()
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

        var result = GoogleMaps.Routes.Direcions.Query(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
        Assert.NotNull(result.Routes.First().Polyline.GeoJsonLinestring);
    }

    [Test]
    public void RouteDirectionsWhenComputeAlternativeRoutesTest()
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

        var result = GoogleMaps.Routes.Direcions.Query(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void RouteDirectionsWhenRouteModifiersAndDriveTest()
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

        var result = GoogleMaps.Routes.Direcions.Query(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void RouteDirectionsWhenRouteModifiersAndWalkTest()
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

        var result = GoogleMaps.Routes.Direcions.Query(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void RouteDirectionsWhenLanguageTest()
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

        var result = GoogleMaps.Routes.Direcions.Query(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void RouteDirectionsWhenRegionCodeTest()
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

        var result = GoogleMaps.Routes.Direcions.Query(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void RouteDirectionsWhenRequestedReferenceRoutesTest()
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

        var result = GoogleMaps.Routes.Direcions.Query(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void RouteDirectionsWhenExtraComputationsTest()
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

        var result = GoogleMaps.Routes.Direcions.Query(request);

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

        var exception = Assert.Throws<AggregateException>(() => GoogleMaps.Routes.Direcions.Query(request));
        Assert.IsNotNull(exception);

        var innerException = exception.InnerException;
        Assert.IsNotNull(innerException);
        Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
        Assert.AreEqual("InvalidArgument: Origin and destination must be set.", innerException.Message);
    }

    [Test]
    public void DirectionsWhenAsyncTest()
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
            }
        };

        var result = GoogleMaps.Routes.Direcions.QueryAsync(request).Result;
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void DirectionsWhenAsyncAndCancelledTest()
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
            }
        };

        var cancellationTokenSource = new CancellationTokenSource();
        var task = GoogleMaps.Routes.Direcions.QueryAsync(request, cancellationTokenSource.Token);
        cancellationTokenSource.Cancel();

        var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "The operation was canceled.");
    }
}