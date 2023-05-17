using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Routes.Common;
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
    public void RouteDirectionsWhenRouteModifiersTest()
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
            RequestedReferenceRoutes = new List<ReferenceRoute> { ReferenceRoute.FuelEfficient }
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
            ExtraComputations = new List<ExtraComputation> { ExtraComputation.Tolls }
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

        var exception = Assert.Throws<GoogleApiException>(() => GoogleMaps.Routes.Direcions.Query(request));
        Assert.IsNotNull(exception);
        Assert.AreEqual("InvalidArgument: Origin and destination must be set.", exception.Message);
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