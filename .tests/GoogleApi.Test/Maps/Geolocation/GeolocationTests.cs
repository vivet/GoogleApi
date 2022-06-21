using System;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geolocation.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Geolocation;

[TestFixture]
public class GeolocationTests : BaseTest
{
    [Test]
    public void GeolocationTest()
    {
        var request = new GeolocationRequest
        {
            Key = this.Settings.ApiKey
        };

        var result = GoogleMaps.Geolocation.Query(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void GeolocationWhenCarrierTest()
    {
        var request = new GeolocationRequest
        {
            Key = this.Settings.ApiKey,
            Carrier = "Vodafone"
        };

        var result = GoogleMaps.Geolocation.Query(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void GeolocationWhenHomeMobileCountryCodeTest()
    {
        var request = new GeolocationRequest
        {
            Key = this.Settings.ApiKey,
            HomeMobileCountryCode = "310"
        };

        var result = GoogleMaps.Geolocation.Query(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void GeolocationWhenHomeMobileNetworkCodeTest()
    {
        var request = new GeolocationRequest
        {
            Key = this.Settings.ApiKey,
            HomeMobileNetworkCode = "410"
        };

        var result = GoogleMaps.Geolocation.Query(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void GeolocationWhenConsiderIpTest()
    {
        var request = new GeolocationRequest
        {
            Key = this.Settings.ApiKey,
            ConsiderIp = true
        };

        var result = GoogleMaps.Geolocation.Query(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void GeolocationWhenCellTowersTest()
    {
        Assert.Inconclusive();
    }

    [Test]
    public void GeolocationWhenWifiAccessPointsTest()
    {
        var request = new GeolocationRequest
        {
            Key = this.Settings.ApiKey,
            WifiAccessPoints = new[]
            {
                new WifiAccessPoint
                {
                    MacAddress = "00:25:9c:cf:1c:ac",
                    SignalStrength = -43,
                    SignalToNoiseRatio = 0
                },
                new WifiAccessPoint
                {
                    MacAddress = "00:25:9c:cf:1c:ad",
                    SignalStrength = -55,
                    SignalToNoiseRatio = 0
                }
            }
        };
        var result = GoogleMaps.Geolocation.Query(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void GeolocationWhenAsyncTest()
    {
        var request = new GeolocationRequest
        {
            Key = this.Settings.ApiKey
        };

        var result = GoogleMaps.Geolocation.QueryAsync(request).Result;
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public void GeolocationWhenAsyncAndCancelledTest()
    {
        var request = new GeolocationRequest
        {
            Key = this.Settings.ApiKey
        };
        var cancellationTokenSource = new CancellationTokenSource();
        var task = GoogleMaps.Geolocation.QueryAsync(request, cancellationTokenSource.Token);
        cancellationTokenSource.Cancel();

        var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "The operation was canceled.");
    }
}