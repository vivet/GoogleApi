using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geolocation.Request;
using NUnit.Framework;
using System.Threading.Tasks;

namespace GoogleApi.Test.Maps.Geolocation;

[TestFixture]
public class GeolocationTests : BaseTest
{
    [Test]
    public async Task GeolocationTest()
    {
        var request = new GeolocationRequest
        {
            Key = this.Settings.ApiKey
        };

        var result = await GoogleMaps.Geolocation.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task GeolocationWhenCarrierTest()
    {
        var request = new GeolocationRequest
        {
            Key = this.Settings.ApiKey,
            Carrier = "Vodafone"
        };

        var result = await GoogleMaps.Geolocation.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task GeolocationWhenHomeMobileCountryCodeTest()
    {
        var request = new GeolocationRequest
        {
            Key = this.Settings.ApiKey,
            HomeMobileCountryCode = "310"
        };

        var result = await GoogleMaps.Geolocation.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task GeolocationWhenHomeMobileNetworkCodeTest()
    {
        var request = new GeolocationRequest
        {
            Key = this.Settings.ApiKey,
            HomeMobileNetworkCode = "410"
        };

        var result = await GoogleMaps.Geolocation.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    public async Task GeolocationWhenConsiderIpTest()
    {
        var request = new GeolocationRequest
        {
            Key = this.Settings.ApiKey,
            ConsiderIp = true
        };

        var result = await GoogleMaps.Geolocation.QueryAsync(request);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [Test]
    [Ignore("No valid example for Cell Towers.")]
    public async Task GeolocationWhenCellTowersTest()
    {
        await Task.CompletedTask;
    }

    [Test]
    public async Task GeolocationWhenWifiAccessPointsTest()
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
        var result = await GoogleMaps.Geolocation.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }
}