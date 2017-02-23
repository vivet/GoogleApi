using System;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Geocode.Request;
using GoogleApi.Entities.Maps.Geolocation.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps
{
    [TestFixture]
    public class GeolocationTests : BaseTest
    {
        [Test]
        public void GeolocationTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey
            };
            var result = GoogleMaps.Geolocation.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }
        [Test]
        public void GeolocationWhenCarrierTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void GeolocationWhenHomeMobileCountryCodeTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void GeolocationWhenHomeMobileNetworkCodeTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void GeolocationWhenConsiderIpTest()
        {
            Assert.Inconclusive();
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
            var result = GoogleMaps.Geolocation.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void GeolocationWhenKeyIsNullTest()
        {
            var request = new GeolocationRequest
            {
                Key = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Geolocation.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void GeolocationWhenKeyIsStringEmptyTest()
        {
            var request = new GeolocationRequest
            {
                Key = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Geolocation.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required.");
        }
        [Test]
        public void GeolocationWhenClientCredentialsIsInvalidTest()
        {
            var request = new GeocodingRequest
            {
                Address = "test",
                ClientId = "abc",
                Key = "abc"
            };
            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Geocode.Query(request));

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "ClientId must begin with 'gme-'.");
        }

        [Test]
        public void GeolocationAsyncTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey
            };
            var result = GoogleMaps.Geolocation.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }
        [Test]
        public void GeolocationWhenAsyncWhenTimeoutTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.Geolocation.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
                Assert.IsNull(result);
            });

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "One or more errors occurred.");

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(innerException.GetType(), typeof(TaskCanceledException));
            Assert.AreEqual(innerException.Message, "A task was canceled.");
        }
        [Test]
        public void GeolocationWhenAsyncCancelledTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.Geolocation.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }
    }
}