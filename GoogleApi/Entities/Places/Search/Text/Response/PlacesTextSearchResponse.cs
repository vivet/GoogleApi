using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Places.Common;

namespace GoogleApi.Entities.Places.Search.Text.Response;

/// <summary>
/// Places TextSearch Response.
/// </summary>
public class PlacesTextSearchResponse : BasePlacesResponse
{
    /// <summary>
    /// Results.
    /// </summary>
    public virtual IEnumerable<PlaceResult> Results { get; set; }

    /// <summary>
    /// Contains a token that can be used to return up to 20 additional results. A next_page_token will not be returned if there are no additional results to display.
    /// The maximum number of results that can be returned is 60. There is a short delay between when a next_page_token is issued, and when it will become valid.
    /// </summary>
    [JsonPropertyName("next_page_token")]
    public virtual string NextPageToken { get; set; }
}