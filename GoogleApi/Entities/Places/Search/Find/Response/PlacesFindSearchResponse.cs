using System.Collections.Generic;

namespace GoogleApi.Entities.Places.Search.Find.Response;

/// <summary>
/// Places Find Search Response.
/// </summary>
public class PlacesFindSearchResponse : BasePlacesResponse
{
    /// <summary>
    /// Candidates.
    /// </summary>
    public virtual IEnumerable<Candidate> Candidates { get; set; }
}