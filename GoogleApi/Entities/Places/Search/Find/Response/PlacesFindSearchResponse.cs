using System.Collections.Generic;
using GoogleApi.Entities.Places.Common;

namespace GoogleApi.Entities.Places.Search.Find.Response;

/// <summary>
/// Places Find Search Response.
/// </summary>
public class PlacesFindSearchResponse : BasePlacesResponse
{
    /// <summary>
    /// Candidates.
    /// </summary>
    public virtual IEnumerable<PlaceResult> Candidates { get; set; }
}