using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Elevation.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps
{
    [TestFixture]
    public class ElevationTests : BaseTest
    {
        [Test]
        public void ElevationWhenLocationTest()
        {
            var request = new ElevationRequest
            {
                Locations = new[] { new Location(40.7141289, -73.9614074) }
            };
            var response = GoogleMaps.Elevation.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.AreEqual(14.782454490661619, response.Results.First().Elevation, 0.10);
        }
        [Test]
        public void ElevationWhenPathAndSamplesTest()
        {
            Assert.Inconclusive();
        }
        [Test]
        public void ElevationWhenPathAndSimplesIsNullTest()
        {
            var request = new ElevationRequest
            {
                Path = new[] { new Location(40.7141289, -73.9614074) },
                Samples = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Elevation.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Samples is required, when using the Path.");
        }

        [Test]
        public void ElevationWhenLocationIsNullAndPathIsNullTest()
        {
            var request = new ElevationRequest();

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.Elevation.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Locations or Path is required.");
        }

        [Test]
        public void ElevationAsyncTest()
        {
            var request = new ElevationRequest
            {
                Locations = new[] { new Location(40.7141289, -73.9614074) }
            };
            var response = GoogleMaps.Elevation.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }
        [Test]
        public void ElevationWhenAsyncWhenTimeoutTest()
        {
            var request = new ElevationRequest
            {
                Locations = new[] { new Location(40.7141289, -73.9614074) }
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.Elevation.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void ElevationWhenAsyncCancelledTest()
        {
            var request = new ElevationRequest
            {
                Locations = new[] { new Location(40.7141289, -73.9614074) }
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.Elevation.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

    }
}