using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Search.Find.Request;
using GoogleApi.Entities.Places.Search.Find.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Search.Find
{
    [TestFixture]
    public class FindSearchTests : BaseTest
    {
        [Test]
        public void PlacesFindSearchTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = this.ApiKey,
                Input = "picadelly circus",
                Type = InputType.TextQuery,
                Fields = FieldTypes.Basic
            };

            var response = GooglePlaces.FindSearch.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);

            var candidate = response.Candidates.FirstOrDefault();
            Assert.IsNotNull(candidate);
            Assert.IsNotNull(candidate.PlaceId);
            Assert.AreEqual(candidate.BusinessStatus, BusinessStatus.Operational);
        }

        [Test]
        public void PlacesFindSearchWhenTypeIsPhoneNumberTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = this.ApiKey,
                Input = "+4533333333",
                Type = InputType.PhoneNumber
            };

            var response = GooglePlaces.FindSearch.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesFindSearchAsyncTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = this.ApiKey,
                Input = "picadelly circus"
            };

            var response = GooglePlaces.FindSearch.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesFindSearchWhenAsyncAndCancelledTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = this.ApiKey,
                Input = "picadelly circus"
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var task = GooglePlaces.FindSearch.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void PlacesFindSearchWhenFieldsTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = this.ApiKey,
                Input = "picadelly circus",
                Type = InputType.TextQuery,
                Fields = FieldTypes.Basic
            };

            var response = GooglePlaces.FindSearch.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);

            var candidate = response.Candidates.FirstOrDefault();
            Assert.IsNotNull(candidate);
            Assert.IsNotNull(candidate.Name);
            Assert.IsNotNull(candidate.Icon);
            Assert.IsNotNull(candidate.PlaceId);
            Assert.IsNotNull(candidate.Geometry);
            Assert.IsNotNull(candidate.Geometry.Location);
            Assert.IsNotNull(candidate.Geometry.ViewPort);
        }

        [Test]
        public void PlacesFindSearchWhenLocationTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = this.ApiKey,
                Input = "picadelly circus",
                Location = new Coordinate(51.5100913, -0.1345676)
            };

            var response = GooglePlaces.FindSearch.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesFindSearchWhenLocationAndRadiusTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = this.ApiKey,
                Input = "picadelly circus",
                Location = new Coordinate(51.5100913, -0.1345676),
                Radius = 5000
            };

            var response = GooglePlaces.FindSearch.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesFindSearchWhenBoundsTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = this.ApiKey,
                Input = "new york",
                Bounds = new ViewPort(new Coordinate(51.5100913, -0.1345676), new Coordinate(50.5100913, -0.0345676))
            };

            var response = GooglePlaces.FindSearch.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }
    }
}