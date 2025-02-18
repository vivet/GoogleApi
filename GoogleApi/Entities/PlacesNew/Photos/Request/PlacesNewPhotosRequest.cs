using System;
using System.Collections.Generic;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities.PlacesNew.Photos.Request;

/// <summary>
/// The Place Photo (New) service is a read-only API that allows you to add high quality photographic content to your application.
/// The Place Photo service gives you access to the millions of photos stored in the Places database.
/// When you get place information using a Place Details, Nearby Search, or Text Search request, you can also request photo resources for relevant photographic content.
/// Using the Photo service, you can then access the referenced photos and resize the image to the optimal size for your application.
/// </summary>
public class PlacesNewPhotosRequest : BasePlacesNewRequest, IRequestQueryStringX
{
    /// <summary>
    /// Base Url.
    /// </summary>
    protected internal override string BaseUrl => $"{base.BaseUrl}{this.PhotoName}/media";

    /// <summary>
    /// Required.
    /// A string identifier that uniquely identifies a photo.
    /// Photo names are returned from a Place Details (New), Nearby Search (New), or Text Search (New) request
    /// in the name property of each element of the photos[] array.
    /// </summary>
    public virtual string PhotoName { get; set; }

    /// <summary>
    /// Optional (Required).
    /// Specifies the maximum desired width, in pixels, of the image. If the image is smaller than the values specified, the original image will be returned.
    /// If the image is larger in either dimension, it will be scaled to match the smaller of the two dimensions, restricted to its original aspect ratio.
    /// Accepts an integer between 1 and 4800.
    /// You must specify either maxHeightPx, or maxWidthPx, or both.
    /// </summary>
    public virtual int? MaxWidthPx { get; set; }

    /// <summary>
    /// Optional (Required).
    /// Specifies the maximum desired height, in pixels, of the image. If the image is smaller than the values specified, the original image will be returned.
    /// If the image is larger in either dimension, it will be scaled to match the smaller of the two dimensions, restricted to its original aspect ratio.
    /// Accepts an integer between 1 and 4800.
    /// You must specify either maxHeightPx, or maxWidthPx, or both.
    /// </summary>
    public virtual int? MaxHeightPx { get; set; }

    /// <inheritdoc />
    public override IList<KeyValuePair<string, string>> GetQueryStringParameters()
    {
        var parameters = base.GetQueryStringParameters();

        if (string.IsNullOrWhiteSpace(this.PhotoName))
        {
            throw new ArgumentException($"'{nameof(this.PhotoName)}' is required");
        }

        if (!this.MaxHeightPx.HasValue && !this.MaxWidthPx.HasValue)
        {
            throw new ArgumentException($"'{nameof(this.MaxHeightPx)}' or '{nameof(this.MaxWidthPx)}' is required");
        }

        if (this.MaxHeightPx is > 4800 or < 1)
        {
            throw new ArgumentException($"'{nameof(this.MaxHeightPx)}' must be greater than or equal to 1 and less than or equal to 4800");
        }

        if (this.MaxWidthPx is > 4800 or < 1)
        {
            throw new ArgumentException($"'{nameof(this.MaxWidthPx)}' must be greater than or equal to 1 and less than or equal to 4800");
        }

        if (this.MaxWidthPx.HasValue)
        {
            parameters
                .Add("maxWidthPx", this.MaxWidthPx.Value.ToString());
        }

        if (this.MaxHeightPx.HasValue)
        {
            parameters
                .Add("maxHeightPx", this.MaxHeightPx.Value.ToString());
        }

        return parameters;
    }
}