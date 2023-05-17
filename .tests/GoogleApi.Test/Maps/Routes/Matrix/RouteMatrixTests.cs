using System;
using System.Collections.Generic;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Routes.Common;
using GoogleApi.Entities.Maps.Routes.Matrix.Request;
using GoogleApi.Entities.Maps.Routes.Matrix.Request.Enums;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Routes.Matrix;

[TestFixture]
public class RouteMatrixTests : BaseTest
{
    [Test]
    public void RouteMatrixTest()
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

        var result = GoogleMaps.Routes.Matrix.Query(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void RouteMatrixWhenDepartureTimeTest()
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
            DepartureTime = DateTime.UtcNow.AddHours(5)
        };

        var result = GoogleMaps.Routes.Matrix.Query(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void RouteMatrixWhenLanguageTest()
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

        var result = GoogleMaps.Routes.Matrix.Query(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void RouteMatrixWhenExtraComputationsTest()
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

        var result = GoogleMaps.Routes.Matrix.Query(request);

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

        // TODO: Figure out how to handle bad request for routes matrix, and what happens when one set of coordinates is valid and another is not.

        //var a = GoogleMaps.Routes.Matrix.Query(request);

        var exception = Assert.Throws<GoogleApiException>(() => GoogleMaps.Routes.Matrix.Query(request));
        Assert.IsNotNull(exception);
        Assert.AreEqual("InvalidArgument: Origin and destination must be set.", exception.Message);
    }

    [Test]
    public void DirectionsWhenAsyncTest()
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

        var result = GoogleMaps.Routes.Matrix.QueryAsync(request).Result;
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void DirectionsWhenAsyncAndCancelledTest()
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

        var cancellationTokenSource = new CancellationTokenSource();
        var task = GoogleMaps.Routes.Matrix.QueryAsync(request, cancellationTokenSource.Token);
        cancellationTokenSource.Cancel();

        var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "The operation was canceled.");
    }
}