using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Elevation.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Elevation
{
    [TestFixture]
    public class ElevationTests : BaseTest
    {
        [Test]
        public void ElevationWhenLocationTest()
        {
            var request = new ElevationRequest
            {
                Key = this.ApiKey,
                Locations = new[] { new Location(40.7141289, -73.9614074) }
            };

            var response = GoogleMaps.Elevation.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual(16.9243183135986, response.Results.First().Elevation, 2.00);
        }

        [Test]
        public void ElevationWhenAsyncTest()
        {
            var request = new ElevationRequest
            {
                Key = this.ApiKey,
                Locations = new[] { new Location(40.7141289, -73.9614074) }
            };
            var response = GoogleMaps.Elevation.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void ElevationWhenAsyncAndCancelledTest()
        {
            var request = new ElevationRequest
            {
                Key = this.ApiKey,
                Locations = new[] { new Location(40.7141289, -73.9614074) }
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.Elevation.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void ElevationWhenPathAndSamplesTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void ElevationWhenPathAndSamplesIsNullTest()
        {
            var request = new ElevationRequest
            {
                Key = this.ApiKey,
                Path = new[] { new Location(40.7141289, -73.9614074) },
                Samples = null
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.Elevation.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Samples is required, when using Path");
        }

        [Test]
        public void ElevationWhenPathAndLocationTest()
        {
            var request = new ElevationRequest
            {
                Key = this.ApiKey,
                Path = new[] { new Location(40.7141289, -73.9614074) },
                Locations = new[] { new Location(40.7141289, -73.9614074) }
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.Elevation.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Path and Locations cannot both be specified");
        }

        [Test]
        public void ElevationWhenPathAndLocationIsNullTest()
        {
            var request = new ElevationRequest();

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.Elevation.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Locations or Path is required");
        }
    }
}