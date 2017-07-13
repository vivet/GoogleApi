using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.DistanceMatrix
{
    [TestFixture]
    public class DistanceMatrixTests : BaseTest
    {
        [Test]
        public void DistanceMatrixTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(40.7141289, -73.9614074) },
                Destinations = new[] { new Location("185 Broadway Ave, Manhattan, NY, USA") }
            };
            var response = GoogleMaps.DistanceMatrix.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.IsNotNull(response.OriginAddresses.FirstOrDefault());
            Assert.IsNotNull(response.DestinationAddresses.FirstOrDefault());

            var row = response.Rows.FirstOrDefault();
            Assert.IsNotNull(row);

            var element = row.Elements.FirstOrDefault();
            Assert.IsNotNull(element);
            Assert.AreEqual(Status.Ok, element.Status);
            Assert.IsNotNull(element.Distance.Text);
            Assert.AreEqual(706.00, element.Distance.Value, 100.00);
            Assert.IsNotNull(element.Duration.Text);
            Assert.AreEqual(208.00, element.Duration.Value.TotalSeconds, 30.00);
        }

        [Test]
        public void DistanceMatrixWHenAsyncTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(40.7141289, -73.9614074) },
                Destinations = new[] { new Location("185 Broadway Ave, Manhattan, NY, USA") }
            };
            var response = GoogleMaps.DistanceMatrix.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void DistanceMatrixAsyncAndTimeoutTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(0, 0) },
                Destinations = new[] { new Location("185 Broadway Ave, Manhattan, NY, USA") }
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.DistanceMatrix.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void DistanceMatrixAsyncAndCancelledTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(0, 0), },
                Destinations = new[] { new Location("test") }
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.DistanceMatrix.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void DistanceMatrixWhenLanguageTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DistanceMatrixWhenUnitsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DistanceMatrixWhenAvoidWayTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DistanceMatrixWhenTravelModeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DistanceMatrixWhenTransitModeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DistanceMatrixWhenTransitRoutingPreferenceTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DistanceMatrixWhenArrivalTimeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DistanceMatrixWhenDepartureTimeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void DistanceMatrixWhenOriginsIsNullTest()
        {
            var request = new DistanceMatrixRequest
            {
                Destinations = new[] { new Location("test") }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.DistanceMatrix.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Origins is required");
        }

        [Test]
        public void DistanceMatrixWhenOriginsIsEmptyTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new Location[0],
                Destinations = new[] { new Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.DistanceMatrix.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Origins is required");
        }

        [Test]
        public void DistanceMatrixWhenDestinationsIsNullTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(0, 0) }
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.DistanceMatrix.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Destinations is required");
        }

        [Test]
        public void DistanceMatrixWhenDestinationsIsEmptyTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(0, 0) },
                Destinations = new Location[0]
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.DistanceMatrix.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "Destinations is required");
        }

        [Test]
        public void DistanceMatrixWhenWhenTravelModeIsTransitAndDepartureTimeIsNullAndArrivalTimeIsNullTest()
        {
            var request = new DistanceMatrixRequest
            {
                Origins = new[] { new Location(0, 0) },
                Destinations = new[] { new Location("test") },
                TravelMode = TravelMode.Transit,
                DepartureTime = null,
                ArrivalTime = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.DistanceMatrix.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "DepatureTime or ArrivalTime is required, when TravelMode is Transit");
        }
    }
}