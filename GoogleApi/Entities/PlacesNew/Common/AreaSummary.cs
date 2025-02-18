using System.Collections.Generic;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// AI-generated summary of the area that the place is in.
/// Experimental: See https://developers.google.com/maps/documentation/places/web-service/experimental/places-generative for more details.
/// </summary>
public class AreaSummary
{
    /// <summary>
    /// Content blocks that compose the area summary. Each block has a separate topic about the area
    /// </summary>
    public virtual IEnumerable<ContentBlock> ContentBlocks { get; set; } = new List<ContentBlock>();

    /// <summary>
    /// A link where users can flag a problem with the summary.
    /// </summary>
    public virtual string FlagContentUri { get; set; }
}