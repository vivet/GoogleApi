using System;
using System.Linq;
using System.Threading;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Places.AutoComplete.Request;
using GoogleApi.Entities.Places.Details.Request;
using GoogleApi.Entities.Places.Photos.Request;
using GoogleApi.Exceptions;
using NUnit.Framework;

namespace GoogleApi.Test.Places.Photos;

[TestFixture]
public class PhotosTests : BaseTest
{
    [Test]
    public void PlacesPhotosTest()
    {
        var response = GooglePlaces.AutoComplete.Query(new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "det kongelige teater"
        });

        var placeId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault();
        var response2 = GooglePlaces.Details.Query(new PlacesDetailsRequest
        {
            Key = this.Settings.ApiKey,
            PlaceId = placeId
        });

        var photoReference = response2.Result.Photos.Select(x => x.PhotoReference).FirstOrDefault();
        var response3 = GooglePlaces.Photos.Query(new PlacesPhotosRequest
        {
            Key = this.Settings.ApiKey,
            PhotoReference = photoReference,
            MaxWidth = 1600
        });

        Assert.IsNotNull(response3);
        Assert.IsNotNull(response3.Stream);
        Assert.IsNotNull(response3.Buffer);
        Assert.AreEqual(Status.Ok, response3.Status);
        Assert.GreaterOrEqual(response3.Stream.Length, 1000);
    }

    [Test]
    public void PlacesPhotosAsyncTest()
    {
        var response = GooglePlaces.AutoComplete.Query(new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "det kongelige teater"
        });

        var placeId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault();
        var response2 = GooglePlaces.Details.Query(new PlacesDetailsRequest
        {
            Key = this.Settings.ApiKey,
            PlaceId = placeId
        });

        var photoReference = response2.Result.Photos.Select(x => x.PhotoReference).FirstOrDefault();
        var response3 = GooglePlaces.Photos.Query(new PlacesPhotosRequest
        {
            Key = this.Settings.ApiKey,
            PhotoReference = photoReference,
            MaxWidth = 1600
        });

        Assert.IsNotNull(response3);
        Assert.IsNotNull(response3.Stream);
        Assert.AreEqual(Status.Ok, response3.Status);
    }

    [Test]
    public void PlacesPhotosWhenAsyncAndCancelledTest()
    {
        var request = new PlacesPhotosRequest
        {
            Key = this.Settings.ApiKey,
            PhotoReference = Guid.NewGuid().ToString("N"),
            MaxWidth = 1600
        };
        var cancellationTokenSource = new CancellationTokenSource();
        var task = GooglePlaces.Photos.QueryAsync(request, cancellationTokenSource.Token);
        cancellationTokenSource.Cancel();

        var exception = Assert.Throws<OperationCanceledException>(() => task.Wait(cancellationTokenSource.Token));
        Assert.IsNotNull(exception);
        Assert.AreEqual(exception.Message, "The operation was canceled.");
    }

    [Test]
    public void PlacesPhotosWhenInvalidKeyTest()
    {
        var request = new PlacesPhotosRequest
        {
            Key = "test",
            PhotoReference = "photoReference",
            MaxWidth = 1600
        };

        var exception = Assert.Throws<AggregateException>(() => GooglePlaces.Photos.QueryAsync(request).Wait());
        Assert.IsNotNull(exception);

        var innerException = exception.InnerExceptions.FirstOrDefault();
        Assert.IsNotNull(innerException);
        Assert.AreEqual(typeof(GoogleApiException).ToString(), innerException.GetType().ToString());
        Assert.AreEqual("PermissionDenied: Forbidden", innerException.Message);
    }

    [Test]
    public void PlacesPhotosWhenMaxWidthTest()
    {
        var response = GooglePlaces.AutoComplete.Query(new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "det kongelige teater"
        });

        var placeId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault();
        var response2 = GooglePlaces.Details.Query(new PlacesDetailsRequest
        {
            Key = this.Settings.ApiKey,
            PlaceId = placeId
        });

        var photoReference = response2.Result.Photos.Select(x => x.PhotoReference).FirstOrDefault();
        var response3 = GooglePlaces.Photos.Query(new PlacesPhotosRequest
        {
            Key = this.Settings.ApiKey,
            PhotoReference = photoReference,
            MaxWidth = 1600
        });

        Assert.IsNotNull(response3);
        Assert.IsNotNull(response3.Stream);
        Assert.AreEqual(Status.Ok, response3.Status);
    }

    [Test]
    public void PlacesPhotosWhenMaxHeightTest()
    {
        var response = GooglePlaces.AutoComplete.Query(new PlacesAutoCompleteRequest
        {
            Key = this.Settings.ApiKey,
            Input = "det kongelige teater"
        });

        var placeId = response.Predictions.Select(x => x.PlaceId).FirstOrDefault();
        var response2 = GooglePlaces.Details.Query(new PlacesDetailsRequest
        {
            Key = this.Settings.ApiKey,
            PlaceId = placeId
        });

        var photoReference = response2.Result.Photos.Select(x => x.PhotoReference).FirstOrDefault();
        var response3 = GooglePlaces.Photos.Query(new PlacesPhotosRequest
        {
            Key = this.Settings.ApiKey,
            PhotoReference = photoReference,
            MaxHeight = 1600
        });

        Assert.IsNotNull(response3);
        Assert.IsNotNull(response3.Stream);
        Assert.AreEqual(Status.Ok, response3.Status);
    }
}