using System;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.TimeZone.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.TimeZone;

[TestFixture]
public class TimeZoneTests : BaseTest
{
    [Test]
    public void TimeZoneTest()
    {
        var location = new Coordinate(40.7141289, -73.9614074);
        var request = new TimeZoneRequest
        {
            Key = this.Settings.ApiKey,
            Location = location
        };

        var response = GoogleMaps.TimeZone.Query(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public void TimeZoneWhenLanguageTest()
    {
        var location = new Coordinate(40.7141289, -73.9614074);
        var request = new TimeZoneRequest
        {
            Key = this.Settings.ApiKey,
            Location = location,
            Language = Language.German
        };

        var response = GoogleMaps.TimeZone.Query(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public void TimeZoneWhenTimeStampTest()
    {
        var location = new Coordinate(40.7141289, -73.9614074);
        var request = new TimeZoneRequest
        {
            Key = this.Settings.ApiKey,
            Location = location,
            TimeStamp = DateTime.Now.AddMonths(6)
        };

        var response = GoogleMaps.TimeZone.Query(request);

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public void TimeZoneWhenAsyncTest()
    {
        var location = new Coordinate(40.7141289, -73.9614074);
        var request = new TimeZoneRequest
        {
            Key = this.Settings.ApiKey,
            Location = location
        };

        var response = GoogleMaps.TimeZone.QueryAsync(request).Result;

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.Ok, response.Status);
    }

    [Test]
    public void TimeZoneWhenAsyncAndCancelledTest()
    {
        var location = new Coordinate(40.7141289, -73.9614074);
        var request = new TimeZoneRequest
        {
            Key = this.Settings.ApiKey,
            Location = location
        };
        var cancellationTokenSource = new CancellationTokenSource();
        var task = GoogleMaps.TimeZone.QueryAsync(request, cancellationTokenSource.Token);
        cancellationTokenSource.Cancel();

        var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "The operation was canceled.");
    }
}