using System;
using System.Collections.Generic;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geolocation.Request;
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
                Key = this.ApiKey
            };

            var result = GoogleMaps.Geolocation.Query(request);
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            Assert.IsNotNull(result.Location);
            Assert.AreEqual(3628.00, result.Accuracy, 2000.00);
            Assert.AreEqual(55.692889700000002d, result.Location.Latitude, 0.1);
            Assert.AreEqual(12.547805d, result.Location.Longitude, 0.1);
        }

        [Test]
        public void GeolocationWhenAsyncTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey
            };

            var result = GoogleMaps.Geolocation.QueryAsync(request).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotNull(result.Location);
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

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("Response status code does not indicate success: 400 (Bad Request).", innerException.Message);
        }

        [Test]
        public void GeolocationWhenRadioTypeTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey
            };

            var result = GoogleMaps.Geolocation.QueryAsync(request).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotNull(result.Location);
        }

        [Test]
        public void GeolocationWhenCarrierTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey,
                Carrier = "Vodafone"
            };

            var result = GoogleMaps.Geolocation.QueryAsync(request).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotNull(result.Location);
        }

        [Test]
        public void GeolocationWhenHomeMobileCountryCodeTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey,
                HomeMobileCountryCode = "310"
            };

            var result = GoogleMaps.Geolocation.QueryAsync(request).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotNull(result.Location);
        }

        [Test]
        public void GeolocationWhenHomeMobileNetworkCodeTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey,
                HomeMobileNetworkCode = "410"
            };

            var result = GoogleMaps.Geolocation.QueryAsync(request).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotNull(result.Location);
        }

        [Test]
        public void GeolocationWhenConsiderIpTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey,
                ConsiderIp = true
            };

            var result = GoogleMaps.Geolocation.QueryAsync(request).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotNull(result.Location);
        }

        [Test]
        public void GeolocationWhenCellTowersTest()
        {
            var request = new GeolocationRequest
            {
                Key = this.ApiKey,
                CellTowers = new List<CellTower>
                {
                    new CellTower
                    {
                        Age = 1
                    }
                }
            };

            var result = GoogleMaps.Geolocation.QueryAsync(request).Result;
            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.IsNotNull(result.Location);
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

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.Geolocation.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("Key is required", innerException.Message);
        }

        [Test]
        public void GeolocationWhenKeyIsStringEmptyTest()
        {
            var request = new GeolocationRequest
            {
                Key = string.Empty
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.Geolocation.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("Key is required", innerException.Message);
        }

        [Test]
        public void GeolocationWhenClientCredentialsIsInvalidTest()
        {
            var request = new GeolocationRequest
            {
                ClientId = "abc",
                Key = "abc"
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.Geolocation.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("ClientId must begin with 'gme-'", innerException.Message);
        }
    }
}