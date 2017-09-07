using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocode.Request;
using GoogleApi.Entities.Maps.Geolocation.Request;
using GoogleApi.Entities.Maps.Geolocation.Request.Enums;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Geolocation
{
    [TestFixture]
    public class GeolocationTests : BaseTest
    {
        [Test]
        public void GeolocationTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey,
                ConsiderIp = false,
                RadioType = RadioType.Gsm,
                HomeMobileCountryCode = "310",
                HomeMobileNetworkCode = "410",
                Carrier = "Vodafone"

            };

            var result = GoogleMaps.Geolocation.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            Assert.IsNotNull(result.Location);
            Assert.AreEqual(1821.00, result.Accuracy, 1000.00);
            Assert.AreEqual(55.692889700000002d, result.Location.Latitude, 0.1);
            Assert.AreEqual(12.547805d, result.Location.Longitude, 0.1);
        }

        [Test]
        public void GeolocationWhenAsyncTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey,
                ConsiderIp = false,
                RadioType = RadioType.Gsm,
                HomeMobileCountryCode = "310",
                HomeMobileNetworkCode = "410",
                Carrier = "Vodafone"
            };

            var result = GoogleMaps.Geolocation.QueryAsync(request).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotNull(result.Location);
        }

        [Test]
        public void GeolocationWhenAsyncAndTimeoutTest()
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
        public void GeolocationWhenAsyncAndCancelledTest()
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

        [Test]
        public void GeolocationWhenInvalidKeyTest()
        {
            var request = new GeolocationRequest
            {
                Key = "test"
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.Geolocation.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerExceptions.FirstOrDefault();
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException).ToString(), innerException.GetType().ToString());
            Assert.AreEqual("Response status code does not indicate success: 400 (Bad Request).", innerException.Message);
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
            Assert.AreEqual(exception.Message, "Key is required");
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
            Assert.AreEqual(exception.Message, "Key is required");
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
    }
}