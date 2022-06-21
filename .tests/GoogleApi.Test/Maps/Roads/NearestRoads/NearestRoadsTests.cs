using System;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Roads.Common;
using GoogleApi.Entities.Maps.Roads.NearestRoads.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Roads.NearestRoads;

[TestFixture]
public class NearestRoadsTests : BaseTest
{
    [Test]
    public void NearestRoadsTest()
    {
        var request = new NearestRoadsRequest
        {
            Key = this.Settings.ApiKey,
            Points = new[]
            {
                new Coordinate(60.170880, 24.942795),
                new Coordinate(60.170879, 24.942796),
                new Coordinate(60.170877, 24.942796)
            }
        };

        var result = GoogleMaps.Roads.NearestRoads.Query(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void NearestRoadsWhenAsyncTest()
    {
        var request = new NearestRoadsRequest
        {
            Key = this.Settings.ApiKey,
            Points = new[]
            {
                new Coordinate(60.170880, 24.942795),
                new Coordinate(60.170879, 24.942796),
                new Coordinate(60.170877, 24.942796)
            }
        };
        var result = GoogleMaps.Roads.NearestRoads.QueryAsync(request).Result;

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void NearestRoadsWhenAsyncAndCancelledTest()
    {
        var request = new NearestRoadsRequest
        {
            Key = this.Settings.ApiKey,
            Points = new[] { new Coordinate(0, 0) }
        };
        var cancellationTokenSource = new CancellationTokenSource();
        var task = GoogleMaps.Roads.NearestRoads.QueryAsync(request, cancellationTokenSource.Token);
        cancellationTokenSource.Cancel();

        var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "The operation was canceled.");
    }
}