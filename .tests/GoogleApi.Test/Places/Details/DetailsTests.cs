using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Details.Request.Enums;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading;

namespace GoogleApi.Test.Places.Details
{
    [TestFixture]
    public class DetailsTests : BaseTest<GooglePlaces.DetailsApi>
    {
        protected override GooglePlaces.DetailsApi GetClient() => new(_httpClient);
        protected override GooglePlaces.DetailsApi GetClientStatic() => GooglePlaces.Details;

        private GooglePlaces.AutoCompleteApi GetAutoCompleteApi()
        {
            if (Settings.UseGlobalStaticHttpClients)
                return GooglePlaces.AutoComplete;

            return new GooglePlaces.AutoCompleteApi(_httpClient);
        }


        [Test]
        public void PlacesDetailsTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = ApiKey,
                Input = "jagtvej 2200 København"
            };

            var response = GetAutoCompleteApi().Query(request);

            var placeId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault();
            var request2 = new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = placeId
            };

            var response2 = Sut.Query(request2);
            Assert.IsNotNull(response2);
            Assert.AreEqual(Status.Ok, response2.Status);

            var result = response2.Result;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Url);
            Assert.IsNotNull(result.Icon);
            Assert.IsNotNull(result.PlaceId);
            Assert.IsNotNull(result.Vicinity);
            Assert.IsNotNull(result.UtcOffset);
            Assert.IsNotNull(result.AdrAddress);
            Assert.IsNotNull(result.Geometry);
            Assert.IsNotNull(result.Geometry.Location);
            Assert.Contains(PlaceLocationType.Route, result.Types.ToArray());
            Assert.AreEqual(BusinessStatus.Operational, result.BusinessStatus);

            var formattedAddress = result.FormattedAddress.ToLower();
            Assert.IsNotNull(formattedAddress);
            Assert.IsTrue(formattedAddress.Contains("jagtvej"));
            Assert.IsTrue(formattedAddress.Contains("københavn"));

            var addressComponents = result.AddressComponents?.ToArray();
            Assert.IsNotNull(addressComponents);
            Assert.GreaterOrEqual(addressComponents!.Length, 4);
        }

        [Test]
        public void PlacesDetailsAsyncTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = ApiKey,
                Input = "jagtvej 2200"
            };

            var response = GetAutoCompleteApi().Query(request);

            var results = response.Predictions.ToArray();
            var result = results.First();

            var request2 = new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = result.PlaceId
            };

            var response2 = Sut.Query(request2);
            Assert.AreEqual(Status.Ok, response2.Status);
        }

        [Test]
        public void PlacesDetailsWhenAsyncAndCancelledTest()
        {
            var request = new PlacesDetailsRequest
            {
                Key = this.ApiKey,
                PlaceId = Guid.NewGuid().ToString("N")
            };
            var cancellationTokenSource = new CancellationTokenSource();
            var task = Sut.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual("The operation was canceled.", exception.Message);
        }

        [Test]
        public void PlacesDetailsWhenLanguageTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = ApiKey,
                Input = "jagtvej 2200 København"
            };

            var response = GetAutoCompleteApi().Query(request);
            var placeId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault();
            var request2 = new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = placeId,
                Language = Language.Danish
            };

            var response2 = Sut.Query(request2);
            Assert.IsNotNull(response2);
            Assert.AreEqual(Status.Ok, response2.Status);

            Assert.IsNotNull(response2.Result.PlaceId);
        }

        [Test]
        public void PlacesDetailsWhenFieldsTest()
        {
            var request = new PlacesAutoCompleteRequest
            {
                Key = ApiKey,
                Input = "jagtvej 2200 København"
            };

            var response = GetAutoCompleteApi().Query(request);
            var placeId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault();
            var request2 = new PlacesDetailsRequest
            {
                Key = ApiKey,
                PlaceId = placeId,
                Fields = FieldTypes.Place_Id
            };

            var response2 = Sut.Query(request2);
            Assert.IsNotNull(response2);
            Assert.AreEqual(Status.Ok, response2.Status);

            Assert.IsNotNull(response2.Result.PlaceId);
        }
    }
}