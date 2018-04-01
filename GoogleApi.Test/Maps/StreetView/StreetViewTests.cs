using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.StreetView.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.StreetView
{
    [TestFixture]
    public class StreetViewTests : BaseTest
    {
        [Test]
        public void StreetViewTest()
        {
            var request = new StreetViewRequest
            {
                Key = this.ApiKey,
                Location = new Location(60.170877, 24.942796)
            };

            var result = GoogleMaps.StreetView.Query(request);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Buffer);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StreetViewWhenAsyncTest()
        {
            var request = new StreetViewRequest
            {
                Key = this.ApiKey,
                Location = new Location(60.170877, 24.942796)

            };
            var result = GoogleMaps.StreetView.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Buffer);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StreetViewWhenAsyncAndTimeoutTest()
        {
            var request = new StreetViewRequest
            {
                Key = this.ApiKey,
                Location = new Location(60.170877, 24.942796)
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.StreetView.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
            var request = new StreetViewRequest
            {
                Key = this.ApiKey,
                Location = new Location(60.170877, 24.942796)
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.StreetView.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void StreetViewWhenInvalidKeyTest()
        {
            var request = new StreetViewRequest
            {
                Key = "test",
                Location = new Location(60.170877, 24.942796)
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.StreetView.Query(request));
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
            var request = new StreetViewRequest
            {
                Key = null,
                Location = new Location(60.170877, 24.942796)
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.StreetView.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void StreetViewWhenKeyIsStringEmptyTest()
        {
            var request = new StreetViewRequest
            {
                Key = string.Empty,
                Location = new Location(60.170877, 24.942796)
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.StreetView.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void StreetViewWhenPanoramaIdTest()
        {
            var request = new StreetViewRequest
            {
                Key = this.ApiKey,
                PanoramaId = "-gVtvWrACv2k/Vnh0Vg8Z8YI/AAAAAAABLWA/a-AT4Wb8M"
            };

            var result = GoogleMaps.StreetView.Query(request);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Buffer);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StreetViewWhenPitchTest()
        {
            var request = new StreetViewRequest
            {
                Key = this.ApiKey,
                Location = new Location(60.170877, 24.942796),
                Pitch = 80
            };

            var result = GoogleMaps.StreetView.Query(request);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Buffer);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StreetViewWhenHeadingTest()
        {
            var request = new StreetViewRequest
            {
                Key = this.ApiKey,
                Location = new Location(60.170877, 24.942796),
                Heading = 80
            };

            var result = GoogleMaps.StreetView.Query(request);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Buffer);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StreetViewWhenFieldOfViewTest()
        {
            var request = new StreetViewRequest
            {
                Key = this.ApiKey,
                Location = new Location(60.170877, 24.942796),
                FieldOfView = 50
            };

            var result = GoogleMaps.StreetView.Query(request);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Buffer);
            Assert.AreEqual(Status.Ok, result.Status);
        }
    }
}