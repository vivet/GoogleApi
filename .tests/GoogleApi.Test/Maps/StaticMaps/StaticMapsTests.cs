using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.StaticMaps.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.StaticMaps
{
    [TestFixture]
    public class StaticMapsTests : BaseTest
    {
        [Test]
        public void StaticMapsTest()
        {
            var request = new StaticMapsRequest
            {
                Key = this.ApiKey,
                Center = new Location(60.170877, 24.942796),
                ZoomLevel = 1
            };

            var result = GoogleMaps.StaticMaps.Query(request);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Buffer);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StaticMapsWhenAsyncTest()
        {
            var request = new StaticMapsRequest
            {
                Key = this.ApiKey,
                Center = new Location(60.170877, 24.942796),
                ZoomLevel = 1
            };
            var result = GoogleMaps.StaticMaps.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Buffer);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StaticMapsWhenAsyncAndCancelledTest()
        {
            var request = new StaticMapsRequest
            {
                Key = this.ApiKey,
                Center = new Location(60.170877, 24.942796),
                ZoomLevel = 1
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.StaticMaps.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void StaticMapsWhenInvalidKeyTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "test",
                Center = new Location(60.170877, 24.942796),
                ZoomLevel = 1
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.StaticMaps.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerExceptions.FirstOrDefault();
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException).ToString(), innerException.GetType().ToString());
            Assert.AreEqual("Response status code does not indicate success: 403 (Forbidden).", innerException.Message);
        }

        [Test]
        public void StaticMapsWhenKeyIsNullTest()
        {
            var request = new StaticMapsRequest
            {
                Key = null,
                Center = new Location(60.170877, 24.942796),
                ZoomLevel = 1
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.StaticMaps.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void StaticMapsWhenKeyIsStringEmptyTest()
        {
            var request = new StaticMapsRequest
            {
                Key = string.Empty,
                Center = new Location(60.170877, 24.942796),
                ZoomLevel = 1
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.StaticMaps.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void StaticMapsWhenPathsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void StaticMapsWhenStylesTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void StaticMapsWhenVisiblesTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void StaticMapsWhenMarkersTest()
        {
            Assert.Inconclusive();
        }
    }
}