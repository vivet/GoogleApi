using System.Linq;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Details.Request.Enums;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Details;

[TestFixture]
public class DetailsTests : BaseTest
{
    [Test]
    public async Task PlacesDetailsTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = Settings.ApiKey,
            Input = "jagtvej 2200 København"
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        var placeId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault();
        var request2 = new PlacesDetailsRequest
        {
            Key = Settings.ApiKey,
            PlaceId = placeId
        };

        var response2 = await GooglePlaces.Details.QueryAsync(request2);
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
        Assert.GreaterOrEqual(addressComponents.Length, 4);
    }

    [Test]
    public async Task PlacesDetailsWhenLanguageTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København"
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        var placeId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault();
        var request2 = new PlacesDetailsRequest
        {
            Key = this.Settings.ApiKey,
            PlaceId = placeId,
            Language = Language.Danish
        };

        var response2 = await GooglePlaces.Details.QueryAsync(request2);
        Assert.IsNotNull(response2);
        Assert.AreEqual(Status.Ok, response2.Status);

        Assert.IsNotNull(response2.Result.PlaceId);
    }

    [Test]
    public async Task PlacesDetailsWhenFieldsTest()
    {
        var request = new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "jagtvej 2200 København"
        };

        var response = await GooglePlaces.AutoComplete.QueryAsync(request);

        var placeId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault();
        var request2 = new PlacesDetailsRequest
        {
            Key = this.Settings.ApiKey,
            PlaceId = placeId,
            Fields = FieldTypes.Place_Id
        };

        var response2 = await GooglePlaces.Details.QueryAsync(request2);
        Assert.IsNotNull(response2);
        Assert.AreEqual(Status.Ok, response2.Status);

        Assert.IsNotNull(response2.Result.PlaceId);
    }
}