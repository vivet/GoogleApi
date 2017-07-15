using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Search.Text.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Search.TextSearch
{
    [TestFixture]
    public class TextSearchTests : BaseTest
    {
        [Test]
        public void PlacesTextSearchTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = "picadelly circus"
            };

            var response = GooglePlaces.TextSearch.Query(request);
            Assert.IsNotNull(response);
            Assert.IsEmpty(response.HtmlAttributions);
            Assert.AreEqual(Status.Ok, response.Status);

            var result = response.Results.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.PlaceId);
            Assert.IsNotNull(result.Geometry);
            Assert.IsNotNull(result.Geometry.Location);
            Assert.AreEqual(51.5100913, result.Geometry.Location.Latitude, 0.01);
            Assert.AreEqual(-0.1345676, result.Geometry.Location.Longitude, 0.01);
        }

        [Test]
        public void PlacesTextSearchAsyncTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = "picadelly circus"
            };

            var response = GooglePlaces.TextSearch.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesTextSearchWhenAsyncAndTimeoutTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = "picadelly circus"
            };

            var exception = Assert.Throws<AggregateException>(() =>
            {
                var result = GooglePlaces.TextSearch.QueryAsync(request, TimeSpan.FromMilliseconds(1)).Result;
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
        public void PlacesTextSearchWhenAsyncAndCancelledTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = "picadelly circus"
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var task = GooglePlaces.TextSearch.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void PlacesTextSearchWhenTypeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesTextSearchWhenPageTokenTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesTextSearchWhenPriceLevelTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesTextSearchWhenKeyIsNullTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = null,
                Query = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.TextSearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void PlacesTextSearchWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = string.Empty,
                Query = "test"
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.TextSearch.Query(request));
            Assert.AreEqual(exception.Message, "Key is required");
        }

        [Test]
        public void PlacesTextSearchWhenQueryIsNullTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = null
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.TextSearch.Query(request));
            Assert.AreEqual(exception.Message, "Query is required");
        }

        [Test]
        public void PlacesTextSearchWhenQueryIsStringEmptyTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = string.Empty
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.TextSearch.Query(request));
            Assert.AreEqual(exception.Message, "Query is required");
        }

        [Test]
        public void PlacesTextSearchWhenLocationAndRadiusTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = "picadelly circus",
                Location = new Location(51.5100913, -0.1345676),
                Radius = 5000
            };

            var response = GooglePlaces.TextSearch.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesTextSearchWhenLocationAndRadiusIsNullTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = "picadelly circus",
                Location = new Location(0, 0)
            };

            var exception = Assert.Throws<ArgumentException>(() => GooglePlaces.TextSearch.Query(request));
            Assert.AreEqual(exception.Message, "Radius is required when Location is specified");
        }
    }
}