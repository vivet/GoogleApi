using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.Search.Find.Request;
using GoogleApi.Entities.Places.Search.Find.Request.Enums;
using GoogleApi.Exceptions;
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
                Fields = FieldTypes.Formatted_Address | 
                         FieldTypes.Geometry | 
                         FieldTypes.Icon | 
                         FieldTypes.Id | 
                         FieldTypes.Name | 
                         FieldTypes.Permanently_Closed | 
                         FieldTypes.Photos | 
                         FieldTypes.Place_Id | 
                         FieldTypes.Plus_Code |
                         //FieldTypes.Scope |
                         //FieldTypes.Opening_Hours |
                         FieldTypes.Price_Level |
                         FieldTypes.Rating,

                Type = InputType.TextQuery
            };

            var response = GooglePlaces.FindSearch.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);

            var candidate = response.Candidates.FirstOrDefault();
            Assert.IsNotNull(candidate);
            Assert.IsNotNull(candidate.PlaceId);
            Assert.IsNotNull(candidate.Geometry);
            Assert.IsNotNull(candidate.Geometry.Location);
            Assert.IsNotNull(candidate.Geometry.ViewPort);
            Assert.AreEqual("https://maps.gstatic.com/mapfiles/place_api/icons/geocode-71.png", candidate.Icon);
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
        public void PlacesNearBySearchWhenInvalidKeyTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = "test",
                Input = "test"
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.FindSearch.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerExceptions.FirstOrDefault();
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual("RequestDenied: The provided API key is invalid.", innerException.Message);
        }

        [Test]
        public void PlacesFindSearchWhenKeyIsNullTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = null,
                Input = "picadelly circus"
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.FindSearch.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void PlacesFindSearchWhenKeyIsStringEmptyTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = string.Empty,
                Input = "picadelly circus"
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.FindSearch.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Key is required");
        }

        [Test]
        public void PlacesFindSearchWhenInputIsNullTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = this.ApiKey,
                Input = null
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.FindSearch.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Input is required");
        }

        [Test]
        public void PlacesFindSearchWhenQueryIsStringEmptyTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = this.ApiKey,
                Input = string.Empty
            };

            var exception = Assert.Throws<AggregateException>(() => GooglePlaces.FindSearch.Query(request));
            Assert.IsNotNull(exception);
            Assert.AreEqual("One or more errors occurred.", exception.Message);

            var innerException = exception.InnerException;
            Assert.IsNotNull(innerException);
            Assert.AreEqual(typeof(GoogleApiException), innerException.GetType());
            Assert.AreEqual(innerException.Message, "Input is required");
        }

        [Test]
        public void PlacesFindSearchWhenTypeIsPhoneNumberTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesFindSearchWhenFieldsTest()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void PlacesFindSearchWhenLocationTest()
        {
            var request = new PlacesFindSearchRequest
            {
                Key = this.ApiKey,
                Input = "picadelly circus",
                Location = new Location(51.5100913, -0.1345676)
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
                Location = new Location(51.5100913, -0.1345676),
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
                Input = "picadelly circus",
                Bounds = new ViewPort
                {
                    NorthEast = new Location(51.5100913, -0.1345676),
                    SouthWest = new Location(50.5100913, -0.0345676)
                }
            };

            var response = GooglePlaces.FindSearch.Query(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }
    }
}