using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// A block of content that can be served individually.
/// </summary>
public class ContentBlock
{
    /// <summary>
    /// The topic of the content, for example "overview" or "restaurant".
    /// </summary>
    public virtual string Topic { get; set; }

    /// <summary>
    /// Content related to the topic
    /// </summary>
    public virtual LocalizedText Content { get; set; }

    /// <summary>
    /// References that are related to this block of content.
    /// Experimental: See https://developers.google.com/maps/documentation/places/web-service/experimental/places-generative for more details.
    /// </summary>
    public virtual References References { get; set; }
}