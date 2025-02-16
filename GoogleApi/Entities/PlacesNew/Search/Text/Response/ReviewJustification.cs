using GoogleApi.Entities.PlacesNew.Common;

namespace GoogleApi.Entities.PlacesNew.Search.Text.Response;

/// <summary>
/// User review justifications. This highlights a section of the user review that would interest an end user.
/// For instance, if the search query is "firewood pizza", the review justification highlights the text relevant to the search query.
/// Experimental: See https://developers.google.com/maps/documentation/places/web-service/experimental/places-generative for more details.
/// </summary>
public class ReviewJustification
{
    /// <summary>
    /// Highlighted Text.
    /// </summary>
    public virtual HighlightedText HighlightedText { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public virtual Review Review { get; set; }
}