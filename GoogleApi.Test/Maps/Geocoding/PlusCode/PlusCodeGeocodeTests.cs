using System;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Geocoding.PlusCode.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Maps.Geocoding.PlusCode
{
    [TestFixture]
    public class PlusCodeGeocodeTests : BaseTest
    {
        [Test]
        public void PlusCodeGeocodeWhenPlaceIdTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlusCodeGeocodeWhenLocationTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.ApiKey,
                Location = new Entities.Common.Location(40.71406249999997, -73.9613125)
            };
            var result = GoogleMaps.PlusCodeGeocode.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
            Assert.AreEqual("87G8P27Q+JF", result.PlusCode.GlobalCode);
        }

        [Test]
        public void PlusCodeGeocodeWhenLocationAndLocalCodeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlusCodeGeocodeWhenAddressTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.ApiKey,
                Address = "285 Bedford Ave, Brooklyn, NY 11211, USA"
            };
            var result = GoogleMaps.PlusCodeGeocode.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            Assert.AreEqual("P27Q+JF", result.PlusCode.LocalCode);
            Assert.AreEqual("87G8P27Q+JF", result.PlusCode.GlobalCode);
            Assert.AreEqual("285 Bedford Ave, Brooklyn, NY 11211, USA", result.PlusCode.BestStreetAddress);
            Assert.AreEqual("New York, NY, USA", result.PlusCode.Locality.Address);
        }

        [Test]
        public void PlusCodeGeocodeWhenAddressAndLocalCodeTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.ApiKey,
                Address = "285 Bedford Ave, Brooklyn, NY 11211, USA",
                LocalCode = "P27Q+JF"
            };
            var result = GoogleMaps.PlusCodeGeocode.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            Assert.AreEqual("P27Q+JF", result.PlusCode.LocalCode);
            Assert.AreEqual("87G8P27Q+JF", result.PlusCode.GlobalCode);
            Assert.AreEqual("285 Bedford Ave, Brooklyn, NY 11211, USA", result.PlusCode.BestStreetAddress);
            Assert.AreEqual("New York, NY, USA", result.PlusCode.Locality.Address);
        }

        [Test]
        public void PlusCodeGeocodeWhenGlobalCodeTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.ApiKey,
                GlobalCode = "87G8P27Q+JF"
            };
            var result = GoogleMaps.PlusCodeGeocode.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);

            Assert.AreEqual("P27Q+JF", result.PlusCode.LocalCode);
            Assert.AreEqual("87G8P27Q+JF", result.PlusCode.GlobalCode);
            Assert.AreEqual("285 Bedford Ave, Brooklyn, NY 11211, USA", result.PlusCode.BestStreetAddress);
            Assert.AreEqual("New York, NY, USA", result.PlusCode.Locality.Address);
        }

        [Test]
        public void PlusCodeGeocodeWhenAsyncTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.ApiKey,
                Location = new Entities.Common.Location(40.71406249999997, -73.9613125)
            };
            var result = GoogleMaps.PlusCodeGeocode.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void PlusCodeGeocodeWhenAsyncAndTimeoutTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.ApiKey,
                Location = new Entities.Common.Location(40.71406249999997, -73.9613125)
            };
            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GoogleMaps.PlusCodeGeocode.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void PlusCodeGeocodeWhenAsyncAndCancelledTest()
        {
            var request = new PlusCodeGeocodeRequest
            {
                Key = this.ApiKey,
                Location = new Entities.Common.Location(40.71406249999997, -73.9613125)
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = GoogleMaps.PlusCodeGeocode.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void PlusCodeGeocodeAndLanguageTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlusCodeGeocodeWhenPlaceIdOrLocationOrAddressOrGlobalCodeIsNullTest()
        {
            var request = new PlusCodeGeocodeRequest();
            var exception = Assert.Throws<ArgumentException>(() => GoogleMaps.PlusCodeGeocode.Query(request));

            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "PlaceId, Location, Address or GlobalCode is required.");
        }
    }
}