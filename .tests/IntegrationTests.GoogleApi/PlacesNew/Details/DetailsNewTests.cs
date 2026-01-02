using System;
using System.Linq;
using System.Threading.Tasks;
using GoogleApi;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.PlacesNew.AutoComplete.Request;
using GoogleApi.Entities.PlacesNew.Common.Enums;
using GoogleApi.Entities.PlacesNew.Details.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.GoogleApi.PlacesNew.Details;

[TestClass]
public class DetailsNewTests : BaseTest
{
    [TestMethod]
    public async Task PlacesNewDetailsTest()
    {
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = Settings.ApiKey,
            Input = "jagtvej 2200 København",
            SessionToken = Guid.NewGuid().ToString()
        };

        var response = await GooglePlacesNew.AutoComplete.QueryAsync(request);

        var placeId = response.Suggestions.Select(x => x.PlacePrediction.PlaceId).FirstOrDefault();
        var request2 = new PlacesNewDetailsRequest
        {
            Key = Settings.ApiKey,
            PlaceId = placeId,
            SessionToken = request.SessionToken
        };

        var result = await GooglePlacesNew.Details.QueryAsync(request2);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);

        var place = result.Place;
        Assert.IsNotNull(place);
        Assert.IsNotNull(place.AdrFormatAddress);
        Assert.IsNotNull(place.Location);
        Assert.IsTrue(place.Types.Contains(PlaceLocationTypeAb.Route));
        Assert.AreEqual(BusinessStatus.Operational, place.BusinessStatus);

        var formattedAddress = place.FormattedAddress.ToLower();
        Assert.IsNotNull(formattedAddress);
        Assert.IsTrue(formattedAddress.Contains("jagtvej"));
        Assert.IsTrue(formattedAddress.Contains("københavn"));

        var addressComponents = place.AddressComponents?.ToArray();
        Assert.IsNotNull(addressComponents);
        Assert.IsTrue(addressComponents.Length >= 4);
    }

    [TestMethod]
    public async Task PlacesNewDetailsWhenPassingPlaceInsteadOfPlaceIdTest()
    {
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = Settings.ApiKey,
            Input = "jagtvej 2200 København"
        };

        var response = await GooglePlacesNew.AutoComplete.QueryAsync(request);

        var placeId = response.Suggestions.Select(x => x.PlacePrediction.Place).FirstOrDefault();
        var request2 = new PlacesNewDetailsRequest
        {
            Key = Settings.ApiKey,
            PlaceId = placeId
        };

        var result = await GooglePlacesNew.Details.QueryAsync(request2);
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.Ok, result.Status);
    }

    [TestMethod]
    public async Task PlacesNewDetailsWhenLanguageTest()
    {
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København"
        };

        var response = await GooglePlacesNew.AutoComplete.QueryAsync(request);

        var placeId = response.Suggestions.Select(x => x.PlacePrediction.PlaceId).FirstOrDefault();
        var request2 = new PlacesNewDetailsRequest
        {
            Key = this.Settings.ApiKey,
            PlaceId = placeId,
            Language = Language.Danish
        };

        var response2 = await GooglePlacesNew.Details.QueryAsync(request2);
        Assert.IsNotNull(response2);
        Assert.AreEqual(Status.Ok, response2.Status);
    }

    [TestMethod]
    public async Task PlacesNewDetailsWhenRegionTest()
    {
        var request = new PlacesNewAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København",
            Region = "dk"
        };

        var response = await GooglePlacesNew.AutoComplete.QueryAsync(request);

        var placeId = response.Suggestions.Select(x => x.PlacePrediction.PlaceId).FirstOrDefault();
        var request2 = new PlacesNewDetailsRequest
        {
            Key = this.Settings.ApiKey,
            PlaceId = placeId,
            Language = Language.Danish
        };

        var response2 = await GooglePlacesNew.Details.QueryAsync(request2);
        Assert.IsNotNull(response2);
        Assert.AreEqual(Status.Ok, response2.Status);
    }

    [TestMethod]
    public async Task PlacesNewDetailsWhenSessionTokenTest()
    {
        await Task.CompletedTask;

        Assert.Inconclusive();
    }

    [TestMethod]
    public async Task PlacesNewDetailsWhenInvalidPlaceIdTest()
    {
        var request2 = new PlacesNewDetailsRequest
        {
            Key = Settings.ApiKey,
            PlaceId = "invalid"
        };

        var result = await GooglePlacesNew.Details.QueryAsync(request2, new HttpEngineOptions { ThrowOnInvalidRequest = false });
        Assert.IsNotNull(result);
        Assert.AreEqual(Status.InvalidArgument, result.Status);
        Assert.IsNotNull(result.ErrorMessage);
    }
}