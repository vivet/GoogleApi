using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        public void StreetViewTest()
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
        public void StreetViewWhenAsyncTest()
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
        public void StreetViewWhenAsyncAndTimeoutTest()
        {
            var request = new StaticMapsRequest
            {
                Key = this.ApiKey,
                Center = new Location(60.170877, 24.942796),
                ZoomLevel = 1
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.StaticMaps.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void StreetViewWhenAsyncAndCancelledTest()
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
        public void StreetViewWhenInvalidKeyTest()
        {
            var request = new StaticMapsRequest
            {
                Key = "test",
                Center = new Location(60.170877, 24.942796),
                ZoomLevel = 1
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.StaticMaps.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerExceptions.FirstOrDefault();
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException).ToString(), innerException.GetType().ToString());
            Assert.AreEqual("Response status code does not indicate success: 403 (Forbidden).", innerException.Message);
        }

        [Test]
        public void StreetViewWhenKeyIsNullTest()
        {
            var request = new StaticMapsRequest
            {
                Key = null,
                Center = new Location(60.170877, 24.942796),
                ZoomLevel = 1
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.StaticMaps.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void StreetViewWhenKeyIsStringEmptyTest()
        {
            var request = new StaticMapsRequest
            {
                Key = string.Empty,
                Center = new Location(60.170877, 24.942796),
                ZoomLevel = 1
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.StaticMaps.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void StreetViewWhenPathsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void StreetViewWhenStylesTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void StreetViewWhenVisiblesTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void StreetViewWhenMarkersTest()
        {
            Assert.Inconclusive();
        }
    }
}