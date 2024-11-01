using System.Linq;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Photos.Request;
using GoogleApi.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.Test.Places.Photos;

[TestClass]
public class PhotosTests : BaseTest
{
    [TestMethod]
    public async Task PlacesPhotosTest()
    {
        var response = await GooglePlaces.AutoComplete.QueryAsync(new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "det kongelige teater"
        });

        var placeId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault();
        var response2 = await GooglePlaces.Details.QueryAsync(new PlacesDetailsRequest
        {
            Key = this.Settings.ApiKey,
            PlaceId = placeId
        });

        var photoReference = response2.Result.Photos.Select(x => x.PhotoReference).FirstOrDefault();
        var response3 = await GooglePlaces.Photos.QueryAsync(new PlacesPhotosRequest
        {
            Key = this.Settings.ApiKey,
            PhotoReference = photoReference,
            MaxWidth = 1600
        });

        Assert.IsNotNull(response3);
        Assert.IsNotNull(response3.Stream);
        Assert.IsNotNull(response3.Buffer);
        Assert.AreEqual(Status.Ok, response3.Status);
        Assert.IsTrue(response3.Stream.Length >= 1000);
    }

    [TestMethod]
    public async Task PlacesPhotosWhenMaxWidthTest()
    {
        var response = await GooglePlaces.AutoComplete.QueryAsync(new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "det kongelige teater"
        });

        var placeId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault();
        var response2 = await GooglePlaces.Details.QueryAsync(new PlacesDetailsRequest
        {
            Key = this.Settings.ApiKey,
            PlaceId = placeId
        });

        var photoReference = response2.Result.Photos.Select(x => x.PhotoReference).FirstOrDefault();
        var response3 = await GooglePlaces.Photos.QueryAsync(new PlacesPhotosRequest
        {
            Key = this.Settings.ApiKey,
            PhotoReference = photoReference,
            MaxWidth = 1600
        });

        Assert.IsNotNull(response3);
        Assert.IsNotNull(response3.Stream);
        Assert.AreEqual(Status.Ok, response3.Status);
    }

    [TestMethod]
    public async Task PlacesPhotosWhenMaxHeightTest()
    {
        var response = await GooglePlaces.AutoComplete.QueryAsync(new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "det kongelige teater"
        });

        var placeId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault();
        var response2 = await GooglePlaces.Details.QueryAsync(new PlacesDetailsRequest
        {
            Key = this.Settings.ApiKey,
            PlaceId = placeId
        });

        var photoReference = response2.Result.Photos.Select(x => x.PhotoReference).FirstOrDefault();
        var response3 = await GooglePlaces.Photos.QueryAsync(new PlacesPhotosRequest
        {
            Key = this.Settings.ApiKey,
            PhotoReference = photoReference,
            MaxHeight = 1600
        });

        Assert.IsNotNull(response3);
        Assert.IsNotNull(response3.Stream);
        Assert.AreEqual(Status.Ok, response3.Status);
    }

    [TestMethod]
    public async Task PlacesPhotosWhenInvalidKeyTest()
    {
        var request = new PlacesPhotosRequest
        {
            Key = "test",
            PhotoReference = "photoReference",
            MaxWidth = 1600
        };

        var exception = await Assert.ThrowsExceptionAsync<GoogleApiException>(async () => await GooglePlaces.Photos.QueryAsync(request));
        Assert.IsNotNull(exception);
        Assert.AreEqual("PermissionDenied: Forbidden", exception.Message);
    }
}