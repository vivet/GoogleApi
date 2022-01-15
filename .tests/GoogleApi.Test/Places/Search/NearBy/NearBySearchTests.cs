using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Common.Enums;
using GoogleApi.Entities.Places.Search.Common.Enums;
using GoogleApi.Entities.Places.Search.NearBy.Request;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;

namespace GoogleApi.Test.Places.Search.NearBy
{
    [TestFixture]
    public class NearBySearchTests : BaseTest<GooglePlaces.NearBySearchApi>
    {
        protected override GooglePlaces.NearBySearchApi GetClient() => new(_httpClient);
        protected override GooglePlaces.NearBySearchApi GetClientStatic() => GooglePlaces.NearBySearch;

        [Test]
        public void PlacesNearBySearchTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Coordinate(51.491431, -3.16668),
                Radius = 1000
            };

            var response = Sut.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesTextSearchWhenPageTokenTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Coordinate(51.491431, -3.16668),
                Radius = 1000
            };

            var response = Sut.Query(request);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.NextPageToken);

            var requestNextPage = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                PageToken = response.NextPageToken
            };

            Thread.Sleep(1500);

            var responseNextPage = Sut.Query(requestNextPage);
            Assert.IsNotNull(responseNextPage);
            Assert.AreNotEqual(response.Results.FirstOrDefault()?.PlaceId, responseNextPage.Results.FirstOrDefault()?.PlaceId);
        }

        [Test]
        public void PlacesTextSearchWhenNameTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Coordinate(51.491431, -3.16668),
                Radius = 25000,
                Name = "cafe"
            };

            var response = Sut.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesTextSearchWhenKeywordTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Coordinate(51.491431, -3.16668),
                Radius = 25000,
                Keyword = "cafe"
            };

            var response = Sut.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesTextSearchWhenTypeTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Coordinate(51.491431, -3.16668),
                Radius = 25000,
                Type = SearchPlaceType.Cafe
            };

            var response = Sut.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesTextSearchWhenPriceLevelMinTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Coordinate(51.491431, 40.16668),
                Radius = 25000,
                Minprice = PriceLevel.Free
            };

            var response = Sut.Query(request);

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
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Coordinate(51.491431, -3.16668),
                Radius = 25000,
                Maxprice = PriceLevel.Expensive
            };

            var response = Sut.Query(request);

            Assert.IsNotNull(response);
            Assert.IsEmpty(response.HtmlAttributions);
            Assert.AreEqual(Status.Ok, response.Status);

            var result = response.Results.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.PlaceId);
            Assert.LessOrEqual(result.PriceLevel, request.Maxprice);
        }

        [Test]
        public void PlacesNearBySearchWhenAsyncTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Coordinate(51.491431, -3.16668),
                Radius = 500,
                Type = SearchPlaceType.School
            };

            var response = Sut.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesNearBySearchWhenAsyncAndCancelledTest()
        {
            var request = new PlacesNearBySearchRequest
            {
                Key = this.ApiKey,
                Location = new Coordinate(51.491431, -3.16668),
                Radius = 500,
                Type = SearchPlaceType.School
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