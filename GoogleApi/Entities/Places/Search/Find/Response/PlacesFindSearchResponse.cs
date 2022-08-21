using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Search.Find.Response;

/// <summary>
/// Places Find Search Response.
/// </summary>
public class PlacesFindSearchResponse : BasePlacesResponse
{
    /// <summary>
    /// Candidates.
    /// </summary>
    [JsonProperty("candidates")]
    public virtual IEnumerable<Candidate> Candidates { get; set; }
}