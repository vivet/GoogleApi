using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.QueryAutoComplete.Request;
using NUnit.Framework;

namespace GoogleApi.Test.Places.QueryAutoComplete
{
    [TestFixture]
    public class QueryAutoCompleteTests : BaseTest
    {
        [Test]
        public void PlacesQueryAutoCompleteTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200 København",
                Language = Language.English
            };

            var response = GooglePlaces.QueryAutoComplete.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);

            var results = response.Predictions.ToArray();
            Assert.IsNotNull(results);
            Assert.IsNotEmpty(results);
            Assert.AreEqual(4, results.Length);

            var result = results.FirstOrDefault();
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Terms);
            Assert.IsNotNull(result.PlaceId);
            Assert.IsNotNull(result.StructuredFormatting);
            Assert.AreEqual(result.Description, "Jagtvej, 2200 København, Denmark");

            var matchedSubstrings = result.MatchedSubstrings.ToArray();
            Assert.IsNotNull(matchedSubstrings);
            Assert.AreEqual(3, matchedSubstrings.Length);

            var types = result.Types.ToArray();
            Assert.IsNotNull(types);
            Assert.Contains(PlaceLocationType.Route, types);
            Assert.Contains(PlaceLocationType.Geocode, types);
        }

        [Test]
        public void PlacesQueryAutoCompleteWhenAsyncTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200"
            };
            var response = GooglePlaces.QueryAutoComplete.QueryAsync(request).Result;

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesQueryAutoCompleteWhenAsyncAndCancelledTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200"
            };

            var cancellationTokenSource = new CancellationTokenSource();
            var task = GooglePlaces.QueryAutoComplete.QueryAsync(request, cancellationTokenSource.Token);
            cancellationTokenSource.Cancel();

            var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
            Assert.IsNotNull(exception);
            Assert.AreEqual(exception.Message, "The operation was canceled.");
        }

        [Test]
        public void PlacesAutoCompleteWhenOffsetTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200 København",
                Offset = "offset"
            };

            var response = GooglePlaces.QueryAutoComplete.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesAutoCompleteWhenLocationTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200 København",
                Location = new Coordinate(1, 1)
            };

            var response = GooglePlaces.QueryAutoComplete.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

        [Test]
        public void PlacesAutoCompleteWhenLocationAndRadiusTest()
        {
            var request = new PlacesQueryAutoCompleteRequest
            {
                Key = this.ApiKey,
                Input = "jagtvej 2200 København",
                Radius = 100
            };

            var response = GooglePlaces.QueryAutoComplete.Query(request);

            Assert.IsNotNull(response);
            Assert.AreEqual(Status.Ok, response.Status);
        }

    }
}