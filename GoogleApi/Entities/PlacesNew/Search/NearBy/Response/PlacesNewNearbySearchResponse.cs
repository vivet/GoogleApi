using System.Collections.Generic;
using GoogleApi.Entities.PlacesNew.Common;
using GoogleApi.Entities.PlacesNew.Search.Common;

namespace GoogleApi.Entities.PlacesNew.Search.NearBy.Response;

/// <summary>
/// Places New Nearby Search Response.
/// </summary>
public class PlacesNewNearbySearchResponse : BaseResponseX
{
    /// <summary>
    /// A list of places that meets user's requirements like places types, number of places and specific location restriction.
    /// </summary>
    public virtual IEnumerable<Place> Places { get; set; }

    /// <summary>
    /// A list of routing summaries where each entry associates to the corresponding place in the same index in the places field.
    /// If the routing summary is not available for one of the places, it will contain an empty entry.
    /// This list should have as many entries as the list of places if requested.
    /// </summary>
    public virtual IEnumerable<RoutingSummary> RoutingSummaries { get; set; }
}