using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Search.Radar.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Search.Radar
{
    [TestFixture]
    public class RadarSearchTests : BaseTest
    {
        [Test]
        public void PlacesRadarSearchTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(55.673323, 12.527438),
                Radius = 500,
                Keyword = "abc"
            };

            var response = GooglePlaces.RadarSearch.Query(request);
            Assert.IsNotNull(response);
            Assert.IsEmpty(response.HtmlAttributions);
            Assert.AreEqual(Status.Ok, response.Status);

            var result = response.Results.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.PlaceId);
            Assert.IsNotNull(result.Geometry);
            Assert.IsNotNull(result.Geometry.Location);
            Assert.AreEqual(55.673323, result.Geometry.Location.Latitude, 0.01);
            Assert.AreEqual(12.527438, result.Geometry.Location.Longitude, 0.01);
        }

        [Test]
        public void PlacesRadarSearchWhenZeroResultsTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(55.673323, 12.527438),
                Radius = 10,
                Keyword = "abc"
            };

            var response = GooglePlaces.RadarSearch.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.ZeroResults, response.Status);
        }

        [Test]
        public void PlacesRadarSearchWhenMultipleResultsTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(55.673323, 12.527438),
                Radius = 5000,
                Keyword = "abc"
            };

            var response = GooglePlaces.RadarSearch.Query(request);
            Assert.IsNotNull(response);
            Assert.GreaterOrEqual(response.Results.Count(), 5);
        }

        [Test]
        public void PlacesRadarSearchWhenAsyncTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(55.673323, 12.527438),
                Radius = 500,
                Keyword = "abc"
            };

            var response = GooglePlaces.RadarSearch.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesRadarSearchWhenAsyncAndTimeoutTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(55.673323, 12.527438),
                Radius = 500,
                Keyword = "abc"
            };

            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GooglePlaces.RadarSearch.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void PlacesRadarSearchWhenAsyncAndCancelledTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(55.673323, 12.527438),
                Radius = 500,
                Keyword = "abc"
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var task = GooglePlaces.RadarSearch.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void PlacesRadarSearchWhenKeyIsNullTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = null,
                Location = new Location(0, 0),
                Radius = 10,
                Keyword = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void PlacesRadarSearchWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = string.Empty,
                Location = new Location(0, 0),
                Radius = 10,
                Keyword = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void PlacesRadarSearchWhenLocationIsNullTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Location is required");
        }

        [Test]
        public void PlacesRadarSearchWhenRadiusIsNullTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(0, 0),
                Radius = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius is required");
        }

        [Test]
        public void PlacesRadarSearchWhenRadiusIsLessThanOneTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 0
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000");
        }

        [Test]
        public void PlacesRadarSearchWhenRadiusIsGereaterThanFiftyThousandTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 50001
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000");
        }

        [Test]
        public void PlacesRadarSearchWhenRankByDistanceAndNameIsNullAndKeywordIsNullAndTypeIsNullTest()
        {
            var request = new PlacesRadarSearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 1
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.RadarSearch.Query(request));
            Assert.AreEqual(exception.Message, "Keyword, Name or Type is required");
        }
    }
}