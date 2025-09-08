﻿using System.Linq;
using System.Threading.Tasks;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.PlacesNew.AutoComplete.Request;
using GoogleApi.Entities.PlacesNew.Details.Request;
using GoogleApi.Entities.PlacesNew.Photos.Request;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.Test.PlacesNew.Photos;

[TestClass]
public class PhotosNewSkipHttpRedirectTests : BaseTest
{
    [TestMethod]
    public async Task PlacesNewPhotosWhenMaxWidthTest()
    {
        var response = await GooglePlacesNew.AutoComplete.QueryAsync(new PlacesNewAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "det kongelige teater"
        });

        var placeId = response.Suggestions.Select(x => x.PlacePrediction.Place).FirstOrDefault();
        var response2 = await GooglePlacesNew.Details.QueryAsync(new PlacesNewDetailsRequest
        {
            Key = this.Settings.ApiKey,
            PlaceId = placeId
        });

        var photoName = response2.Place.Photos.Select(x => x.Name).FirstOrDefault();
        var response3 = await GooglePlacesNew.Photos.PhotoSkipHttpRedirect.QueryAsync(new PlacesNewPhotosSkipHttpRedirectRequest
        {
            Key = this.Settings.ApiKey,
            PhotoName = photoName,
            MaxWidthPx = 1600
        });

        Assert.IsNotNull(response3);
        Assert.AreEqual(Status.Ok, response3.Status);
        Assert.IsNotNull(response3.Name);
        Assert.IsNotNull(response3.PhotoUri);
    }

    [TestMethod]
    public async Task PlacesNewPhotosWhenMaxHeightTest()
    {
        var response = await GooglePlacesNew.AutoComplete.QueryAsync(new PlacesNewAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "det kongelige teater"
        });

        var placeId = response.Suggestions.Select(x => x.PlacePrediction.Place).FirstOrDefault();
        var response2 = await GooglePlacesNew.Details.QueryAsync(new PlacesNewDetailsRequest
        {
            Key = this.Settings.ApiKey,
            PlaceId = placeId
        });

        var photoName = response2.Place.Photos.Select(x => x.Name).FirstOrDefault();
        var response3 = await GooglePlacesNew.Photos.PhotoSkipHttpRedirect.QueryAsync(new PlacesNewPhotosSkipHttpRedirectRequest
        {
            Key = this.Settings.ApiKey,
            PhotoName = photoName,
            MaxHeightPx = 1600
        });

        Assert.IsNotNull(response3);
        Assert.AreEqual(Status.Ok, response3.Status);
        Assert.IsNotNull(response3.Name);
        Assert.IsNotNull(response3.PhotoUri);
    }

    [TestMethod]
    public async Task PlacesNewPhotosWhenInvalidPhotoNameTest()
    {
        var response = await GooglePlacesNew.Photos.PhotoSkipHttpRedirect.QueryAsync(new PlacesNewPhotosSkipHttpRedirectRequest
        {
            Key = this.Settings.ApiKey,
            PhotoName = "invalid",
            MaxWidthPx = 1600
        }, new HttpEngineOptions { ThrowOnInvalidRequest = false });

        Assert.IsNotNull(response);
        Assert.AreEqual(Status.NotFound, response.Status);
        Assert.IsNotNull(response.ErrorMessage);
    }
}