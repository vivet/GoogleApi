using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Common;

/// <summary>
/// The set of promotions. Present only if the custom search engine's configuration files define any promotions for the given query.
/// https://developers.google.com/custom-search/docs/promotions.
/// </summary>
public class Promotion
{
    /// <summary>
    /// The title of the promotion.
    /// </summary>
    [JsonProperty("title")]
    public virtual string Title { get; set; }

    /// <summary>
    /// The html title of the promotion.
    /// </summary>
    [JsonProperty("htmlTitle")]
    public virtual string HtmlTitle { get; set; }

    /// <summary>
    /// The URL of the promotion.
    /// </summary>
    [JsonProperty("link")]
    public virtual string Link { get; set; }

    /// <summary>
    /// An abridged version of this search's result URL, e.g. www.example.com.
    /// </summary>
    [JsonProperty("displayLink")]
    public virtual string DisplayLink { get; set; }

    /// <summary>
    /// An array of block objects for this promotion.
    /// See Google WebSearch Protocol reference for more information.
    /// </summary>
    [JsonProperty("bodyLines")]
    public virtual IEnumerable<BodyLine> BodyLines { get; set; }

    /// <summary>
    /// Image associated with this promotion, if there is one.
    /// </summary>
    [JsonProperty("image")]
    public virtual PromotionImage PromotionImage { get; set; }
}