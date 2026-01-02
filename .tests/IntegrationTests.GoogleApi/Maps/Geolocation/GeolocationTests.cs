using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geolocation.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.GoogleApi.Maps.Geolocation;

[TestClass]
public class GeolocationTests : BaseTest
{
    [TestMethod]
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

    [TestMethod]
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

    [TestMethod]
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

    [TestMethod]
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

    [TestMethod]
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

    [TestMethod]
    [Ignore("No valid example for Cell Towers.")]
    public Task GeolocationWhenCellTowersTest()
    {
        return Task.CompletedTask;
    }

    [TestMethod]
    public async Task GeolocationWhenWifiAccessPointsTest()
    {
        var request = new GeolocationRequest
        {
            Key = this.Settings.ApiKey,
            WifiAccessPoints =
            [
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
            ]
        };
        var result = await GoogleMaps.Geolocation.QueryAsync(request);

        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }
}