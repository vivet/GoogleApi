using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Search.Text.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Search.Text
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
            Assert.AreEqual(result.BusinessStatus, BusinessStatus.Operational);
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
        public void PlacesTextSearchWhenInvalidKeyTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = "test",
                Query = "picadelly circus"
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.TextSearch.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerExceptions.FirstOrDefault();
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("RequestDenied: The provided API key is invalid.", innerException.Message);
        }

        [Test]
        public void PlacesTextSearchWhenTypeTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesTextSearchWhenPageTokenTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = "l"
            };

            var response = GooglePlaces.TextSearch.Query(request);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.NextPageToken);

            var requestNextPage = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                PageToken = response.NextPageToken
            };

            var responseNextPage = GooglePlaces.TextSearch.Query(requestNextPage);
            Assert.IsNotNull(responseNextPage);
            Assert.AreNotEqual(response.Results.FirstOrDefault()?.PlaceId, responseNextPage.Results.FirstOrDefault()?.PlaceId);
        }

        [Test]
        public void PlacesTextSearchWhenPriceLevelTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = "new york",
                Minprice = PriceLevel.Expensive,
                Maxprice = PriceLevel.VeryExpensive
            };

            var response = GooglePlaces.TextSearch.Query(request);

            Assert.IsNotNull(response);
            Assert.IsEmpty(response.HtmlAttributions);
            Assert.AreEqual(Status.Ok, response.Status);

            var result = response.Results.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.PlaceId);
            Assert.GreaterOrEqual(result.PriceLevel, request.Minprice);
            Assert.LessOrEqual(result.PriceLevel, request.Maxprice);
        }

        [Test]
        public void PlacesTextSearchWhenPriceLevelMinTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = "new york",
                Minprice = PriceLevel.Expensive
            };

            var response = GooglePlaces.TextSearch.Query(request);

            Assert.IsNotNull(response);
            Assert.IsEmpty(response.HtmlAttributions);
            Assert.AreEqual(Status.Ok, response.Status);

            var result = response.Results.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.PlaceId);
            Assert.GreaterOrEqual(result.PriceLevel, request.Minprice);
        }

        [Test]
        public void PlacesTextSearchWhenPriceLevelMaxTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = "new york",
                Maxprice = PriceLevel.Expensive
            };

            var response = GooglePlaces.TextSearch.Query(request);
        
            Assert.IsNotNull(response);
            Assert.IsEmpty(response.HtmlAttributions);
            Assert.AreEqual(Status.Ok, response.Status);

            var result = response.Results.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.PlaceId);
            Assert.LessOrEqual(result.PriceLevel, request.Maxprice);
        }

        [Test]
        public void PlacesTextSearchWhenKeyIsNullTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = null,
                Query = "test"
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.TextSearch.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void PlacesTextSearchWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = string.Empty,
                Query = "test"
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.TextSearch.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void PlacesTextSearchWhenQueryIsNullTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = null
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.TextSearch.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Query is required");
        }

        [Test]
        public void PlacesTextSearchWhenQueryIsStringEmptyTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = string.Empty
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.TextSearch.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Query is required");
        }

        [Test]
        public void PlacesTextSearchWhenLocationAndRadiusTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.ApiKey,
                Query = "picadelly circus",
                Location = new Coordinate(51.5100913, -0.1345676),
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
                Location = new Coordinate(0, 0)
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.TextSearch.QueryAsync(request).Wait());
            Assert.IsNotNull(exception);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Radius is required when Location is specified");
        }
    }
}