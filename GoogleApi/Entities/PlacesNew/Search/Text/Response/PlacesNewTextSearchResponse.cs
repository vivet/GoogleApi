using System.Collections.Generic;
using GoogleApi.Entities.PlacesNew.Common;
using GoogleApi.Entities.PlacesNew.Search.Common;

namespace GoogleApi.Entities.PlacesNew.Search.Text.Response;

/// <summary>
/// Places New TextSearch Response.
/// </summary>
public class PlacesNewTextSearchResponse : BaseResponseX
{
    /// <summary>
    /// A list of places that meet the user's text search criteria.
    /// </summary>
    public virtual IEnumerable<Place> Places { get; set; }

    /// <summary>
    /// A list of routing summaries where each entry associates to the corresponding place in the same index in the places field.
    /// If the routing summary is not available for one of the places, it will contain an empty entry.
    /// This list will have as many entries as the list of places if requested.
    /// </summary>
    public virtual IEnumerable<RoutingSummary> RoutingSummaries { get; set; }

    /// <summary>
    /// Experimental: See https://developers.google.com/maps/documentation/places/web-service/experimental/places-generative for more details.
    /// A list of contextual contents where each entry associates to the corresponding place in the same index in the places field.
    /// The contents that are relevant to the textQuery in the request are preferred.If the contextual content is not available for one of the places,
    /// it will return non-contextual content. It will be empty only when the content is unavailable for this place.
    /// This list will have as many entries as the list of places if requested..
    /// </summary>
    public virtual IEnumerable<ContextualContent> ContextualContents { get; set; }

    /// <summary>
    /// A token that can be sent as pageToken to retrieve the next page.
    /// If this field is omitted or empty, there are no subsequent pages.
    /// </summary>
    public virtual string NextPageToken { get; set; }

    /// <summary>
    /// A link allows the user to search with the same text query as specified in the request on Google Maps.
    /// </summary>
    public virtual string SearchUri { get; set; }
}