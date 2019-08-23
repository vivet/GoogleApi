using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Entities.Maps.DistanceMatrix.Request;
using GoogleApi.Exceptions;
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
                Key = this.ApiKey,
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
            Assert.AreEqual(8258.00, element.Distance.Value, 5000.00);
            Assert.IsNotNull(element.Duration.Text);
            Assert.AreEqual(1135.00, element.Duration.Value, 500.00);
        }

        [Test]
        public void DistanceMatrixWhenAsyncTest()
        {
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[] { new Location(40.7141289, -73.9614074) },
                Destinations = new[] { new Location("185 Broadway Ave, Manhattan, NY, USA") }
            };
            var response = GoogleMaps.DistanceMatrix.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void DistanceMatrixWhenAsyncAndCancelledTest()
        {
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[] { new Location(0, 0) },
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
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[] { new Location(40.7141289, -73.9614074) },
                Destinations = new[] { new Location("185 Broadway Ave, Manhattan, NY, USA") },
                Avoid = AvoidWay.Tolls | AvoidWay.Highways,
                DepartureTime = DateTime.Now
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
            Assert.AreEqual(5857.00, element.Distance.Value, 500.00);
            Assert.IsNotNull(element.Duration.Text);
            Assert.AreEqual(1509.00, element.Duration.Value, 500.00);
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
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[] { new Location(40.7141289, -73.9614074) },
                Destinations = new[] { new Location("185 Broadway Ave, Manhattan, NY, USA") },
                DepartureTime = DateTime.Now
            };
            var response = GoogleMaps.DistanceMatrix.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);

            var row = response.Rows.FirstOrDefault();
            Assert.IsNotNull(row);

            var element = row.Elements.FirstOrDefault();
            Assert.IsNotNull(element);
            Assert.AreEqual(Status.Ok, element.Status);
            Assert.IsNotNull(element.Distance.Value);
            Assert.IsNotNull(element.Duration.Value);
            Assert.IsNotNull(element.DurationInTraffic.Value);
        }

        [Test]
        public void DistanceMatrixWhenOriginsIsNullTest()
        {
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Destinations = new[] { new Location("test") }
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.DistanceMatrix.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Origins is required");
        }

        [Test]
        public void DistanceMatrixWhenOriginsIsEmptyTest()
        {
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new Location[0],
                Destinations = new[] { new Location(0, 0) }
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.DistanceMatrix.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Origins is required");
        }

        [Test]
        public void DistanceMatrixWhenDestinationsIsNullTest()
        {
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[] { new Location(0, 0) }
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.DistanceMatrix.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Destinations is required");
        }

        [Test]
        public void DistanceMatrixWhenDestinationsIsEmptyTest()
        {
            var request = new DistanceMatrixRequest
            {
                Key = this.ApiKey,
                Origins = new[] { new Location(0, 0) },
                Destinations = new Location[0]
            };

            var exception = Assert.Throws<AggregateException>(() => GoogleMaps.DistanceMatrix.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Destinations is required");
        }
    }
}