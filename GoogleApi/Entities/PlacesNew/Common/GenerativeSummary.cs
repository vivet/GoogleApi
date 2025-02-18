using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// AI-generated summary of the place.
/// Experimental: See https://developers.google.com/maps/documentation/places/web-service/experimental/places-generative for more details.
/// </summary>
public class GenerativeSummary
{
    /// <summary>
    /// The overview of the place.
    /// </summary>
    public virtual LocalizedText Overview { get; set; }

    /// <summary>
    /// A link where users can flag a problem with the overview summary.
    /// </summary>
    public virtual string OverviewFlagContentUri { get; set; }

    /// <summary>
    /// The detailed description of the place.
    /// </summary>
    public virtual LocalizedText Description { get; set; }

    /// <summary>
    /// A link where users can flag a problem with the description summary.
    /// </summary>
    public virtual string DescriptionFlagContentUri { get; set; }

    /// <summary>
    /// References that are used to generate the summary description.
    /// </summary>
    public virtual References References { get; set; }
}