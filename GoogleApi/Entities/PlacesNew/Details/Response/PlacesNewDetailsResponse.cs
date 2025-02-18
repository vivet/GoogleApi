using GoogleApi.Entities.PlacesNew.Common;

namespace GoogleApi.Entities.PlacesNew.Details.Response;

/// <summary>
/// Places New Details Response.
/// </summary>
public class PlacesNewDetailsResponse : BaseResponseX
{
    /// <summary>
    /// Place.
    /// </summary>
    public virtual Place Place { get; set; }
}