using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using GoogleApi.Entities.Places.Search.NearBy.Request.Enums;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Search.NearBy
{
    [TestFixture]
    public class NearBySearchTests : BaseTest
    {
        [Test]
        public void PlacesNearBySearchTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 500,
                Type = SearchPlaceType.School
            };

            var response = GooglePlaces.NearBySearch.Query(request);
            Assert.IsNotNull(response);
            Assert.IsEmpty(response.HtmlAttributions);
            Assert.AreEqual(Status.Ok, response.Status);
            Assert.GreaterOrEqual(response.Results.Count(), 5);
        }

        [Test]
        public void PlacesNearBySearchWhenAsyncTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 500,
                Type = SearchPlaceType.School
            };

            var response = GooglePlaces.NearBySearch.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesNearBySearchWhenAsyncAndTimeoutTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 500,
                Type = SearchPlaceType.School
            };

            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GooglePlaces.NearBySearch.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void PlacesNearBySearchWhenAsyncAndCancelledTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 500,
                Type = SearchPlaceType.School
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var task = GooglePlaces.NearBySearch.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void PlacesNearBySearchWhenInvalidKeyTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = "test",
                Location = new Location(51.491431, -3.16668),
                Radius = 500,
                Type = SearchPlaceType.School
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerExceptions.FirstOrDefault();
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("The provided API key is invalid.", innerException.Message);
        }

        [Test]
        public void PlacesNearBySearchWhenTypeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesNearBySearchWhenPageTokenTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesNearBySearchWhenPriceLevelTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesNearBySearchWhenKeyIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = null,
                Location = new Location(0, 0),
                Radius = 10
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void PlacesNearBySearchWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = string.Empty,
                Location = new Location(0, 0),
                Radius = 10
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void PlacesNearBySearchWhenLocationIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Location is required");
        }

        [Test]
        public void PlacesNearBySearchWhenRadiusIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(0, 0),
                Radius = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius is required, when RankBy is not Distance");
        }

        [Test]
        public void PlacesNearBySearchWhenRadiusIsLessThanOneTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 0
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000");
        }

        [Test]
        public void PlacesNearBySearchWhenRadiusIsGereaterThanFiftyThousandTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 50001
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius must be greater than or equal to 1 and less than or equal to 50.000");
        }

        [Test]
        public void PlacesNearBySearchWhenRankByDistanceAndRadiusIsNotNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Radius = 5001,
                Rankby = Ranking.Distance
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius cannot be specified, when using RankBy distance");
        }

        [Test]
        public void PlacesNearBySearchWhenRankByDistanceAndNameIsNullAndKeywordIsNullAndTypeIsNullTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Location(51.491431, -3.16668),
                Rankby = Ranking.Distance
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.NearBySearch.Query(request));
            Assert.AreEqual(exception.Message, "Keyword, Name or Type is required, If rank by distance");
        }
    }
}