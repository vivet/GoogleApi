using GoogleApi.Entities.Places.Common;

namespace GoogleApi.Entities.Places.Details.Response;

/// <summary>
/// Places Details Response.
/// </summary>
public class PlacesDetailsResponse : BasePlacesResponse
{
    /// <summary>
    /// Results contains an array of places, with information about the place.
    /// See Place Search Results for information about these results.
    /// The Places API returns up to 20 establishment results. Additionally, political results may be returned which serve to identify the area of the request.
    /// </summary>
    public virtual PlaceResult Result { get; set; }
}