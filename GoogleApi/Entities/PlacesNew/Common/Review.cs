using System;
using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Information about a review of a place.
/// </summary>
public class Review
{
    /// <summary>
    /// A reference representing this place review which may be used to look up this place review again
    /// (also called the API "resource" name: places/{placeId}/reviews/{review}).
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// A string of formatted recent time, expressing the review time relative to the current time
    /// in a form appropriate for the language and country.
    /// </summary>
    public virtual string RelativePublishTimeDescription { get; set; }

    /// <summary>
    /// The localized text of the review.
    /// </summary>
    public virtual LocalizedText Text { get; set; }

    /// <summary>
    /// The review text in its original language.
    /// </summary>
    public virtual LocalizedText OriginalText { get; set; }

    /// <summary>
    /// A number between 1.0 and 5.0, also called the number of stars.
    /// </summary>
    public virtual double? Rating { get; set; }

    /// <summary>
    /// This review's author.
    /// </summary>
    public virtual AuthorAttribution AuthorAttribution { get; set; }

    /// <summary>
    /// The timestamp when the connector availability information in this aggregation was last updated.
    /// A timestamp in RFC3339 UTC "Zulu" format, with nanosecond resolution and up to nine fractional digits.
    /// Examples: "2014-10-02T15:01:23Z" and "2014-10-02T15:01:23.045123456Z".
    /// </summary>
    public virtual DateTime PublishTime { get; set; }

    /// <summary>
    /// A link where users can flag a problem with the review.
    /// </summary>
    public virtual string FlagContentUri { get; set; }

    /// <summary>
    /// A link to show the review on Google Maps.
    /// </summary>
    public virtual string GoogleMapsUri { get; set; }
}