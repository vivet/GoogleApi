using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.Text.Request;
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
                Key = this.Settings.ApiKey,
                Query = "picadelly circus"
            };

            var response = GooglePlaces.Search.TextSearch.Query(request);

            Assert.IsNotNull(response);
            Assert.IsEmpty(response.HtmlAttributions);
            Assert.AreEqual(Status.Ok, response.Status);

            var result = response.Results.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.PlaceId);
            Assert.IsNotNull(result.Geometry);
            Assert.IsNotNull(result.Geometry.Location);
            Assert.AreEqual(result.BusinessStatus, BusinessStatus.Operational);
        }

        [Test]
        public void PlacesTextSearchWhenPageTokenTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.Settings.ApiKey,
                Query = "street"
            };

            var response = GooglePlaces.Search.TextSearch.Query(request);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.NextPageToken);

            var requestNextPage = new PlacesTextSearchRequest
            {
                Key = this.Settings.ApiKey,
                PageToken = response.NextPageToken
            };

            Thread.Sleep(1500);

            var responseNextPage = GooglePlaces.Search.TextSearch.Query(requestNextPage);
            Assert.IsNotNull(responseNextPage);
            Assert.AreNotEqual(response.Results.FirstOrDefault()?.PlaceId, responseNextPage.Results.FirstOrDefault()?.PlaceId);
        }

        [Test]
        public void PlacesTextSearchWhenRegionTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.Settings.ApiKey,
                Query = "picadelly circus",
                Region = "London"
            };

            var response = GooglePlaces.Search.TextSearch.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesTextSearchWhenRadiusTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.Settings.ApiKey,
                Query = "picadelly circus",
                Radius = 5000
            };

            var response = GooglePlaces.Search.TextSearch.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesTextSearchWhenRadiusAndLocationTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.Settings.ApiKey,
                Query = "picadelly circus",
                Location = new Coordinate(51.5100913, -0.1345676),
                Radius = 5000
            };

            var response = GooglePlaces.Search.TextSearch.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesTextSearchWhenTypeTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.Settings.ApiKey,
                Query = "picadelly circus",
                Type = SearchPlaceType.Cafe
            };

            var response = GooglePlaces.Search.TextSearch.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesTextSearchWhenPriceLevelMinTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.Settings.ApiKey,
                Query = "Copenhagen",
                Minprice = PriceLevel.Expensive
            };

            var response = GooglePlaces.Search.TextSearch.Query(request);

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
                Key = this.Settings.ApiKey,
                Query = "Copenhagen",
                Maxprice = PriceLevel.Expensive
            };

            var response = GooglePlaces.Search.TextSearch.Query(request);

            Assert.IsNotNull(response);
            Assert.IsEmpty(response.HtmlAttributions);
            Assert.AreEqual(Status.Ok, response.Status);

            var result = response.Results.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.PlaceId);
            Assert.LessOrEqual(result.PriceLevel, request.Maxprice);
        }

        [Test]
        public void PlacesTextSearchAsyncTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.Settings.ApiKey,
                Query = "picadelly circus"
            };

            var response = GooglePlaces.Search.TextSearch.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesTextSearchWhenAsyncAndCancelledTest()
        {
            var request = new PlacesTextSearchRequest
            {
                Key = this.Settings.ApiKey,
                Query = "picadelly circus"
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var task = GooglePlaces.Search.TextSearch.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

    }
}