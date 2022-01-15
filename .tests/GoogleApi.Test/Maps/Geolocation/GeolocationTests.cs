using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geolocation.Request;
using NUnit.Framework;
using System;
using System.Threading;

namespace GoogleApi.Test.Maps.Geolocation
{
    [TestFixture]
    public class GeolocationTests : BaseTest<GoogleMaps.GeolocationApi>
    {
        protected override GoogleMaps.GeolocationApi GetClient() => new(_httpClient);
        protected override GoogleMaps.GeolocationApi GetClientStatic() => GoogleMaps.Geolocation;

        [Test]
        public void GeolocationTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey
            };

            var result = Sut.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void GeolocationWhenCarrierTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey,
                Carrier = "Vodafone"
            };

            var result = Sut.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void GeolocationWhenHomeMobileCountryCodeTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey,
                HomeMobileCountryCode = "310"
            };

            var result = Sut.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void GeolocationWhenHomeMobileNetworkCodeTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey,
                HomeMobileNetworkCode = "410"
            };

            var result = Sut.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void GeolocationWhenConsiderIpTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey,
                ConsiderIp = true
            };

            var result = Sut.Query(request);
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
                Key = this.ApiKey,
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
            var result = Sut.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void GeolocationWhenAsyncTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey
            };

            var result = Sut.QueryAsync(request).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void GeolocationWhenAsyncAndCancelledTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = Sut.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual("The operation was canceled.", exception.Message);
        }
    }
}