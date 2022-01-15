using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.Common;
using GoogleApi.Entities.Maps.StreetView.Request;
using NUnit.Framework;
using System;
using System.Threading;

namespace GoogleApi.Test.Maps.StreetView
{
    [TestFixture]
    public class StreetViewTests : BaseTest<GoogleMaps.StreetViewApi>
    {
        protected override GoogleMaps.StreetViewApi GetClient() => new(_httpClient);
        protected override GoogleMaps.StreetViewApi GetClientStatic() => GoogleMaps.StreetView;

        [Test]
        public void StreetViewWhenLocationTest()
        {
            var request = new StreetViewRequest
            {
                Key = this.ApiKey,
                Location = new Location(new Coordinate(60.170877, 24.942796))
            };

            var result = Sut.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StreetViewWhenPanoramaIdTest()
        {
            var request = new StreetViewRequest
            {
                Key = this.ApiKey,
                PanoramaId = "-gVtvWrACv2k/Vnh0Vg8Z8YI/AAAAAAABLWA/a-AT4Wb8M"
            };

            var result = Sut.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StreetViewWhenHeadingTest()
        {
            var request = new StreetViewRequest
            {
                Key = this.ApiKey,
                Location = new Location(new Coordinate(60.170877, 24.942796)),
                Heading = 90
            };

            var result = Sut.Query(request);

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StreetViewWhenAsyncTest()
        {
            var request = new StreetViewRequest
            {
                Key = this.ApiKey,
                Location = new Location(new Coordinate(60.170877, 24.942796))

            };
            var result = Sut.QueryAsync(request).Result;

            Assert.IsNotNull(result);
            Assert.AreEqual(Status.Ok, result.Status);
        }

        [Test]
        public void StreetViewWhenAsyncAndCancelledTest()
        {
            var request = new StreetViewRequest
            {
                Key = this.ApiKey,
                Location = new Location(new Coordinate(60.170877, 24.942796))
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = Sut.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual("The operation was canceled.", exception.Message);
        }
    }
}