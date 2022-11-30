using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Search.Common;

/// <summary>
/// A search result item.
/// </summary>
public class Item
{
    /// <summary>
    /// A unique identifier for the type of current object. For this API, it is customsearch#result.
    /// </summary>
    public virtual string Kind { get; set; }

    /// <summary>
    /// The title of the search result, in plain text.
    /// </summary>
    public virtual string Title { get; set; }

    /// <summary>
    /// The title of the search result, in HTML.
    /// </summary>
    public virtual string HtmlTitle { get; set; }

    /// <summary>
    /// The full URL to which the search result is pointing, e.g.http://www.example.com/foo/bar.
    /// </summary>
    public virtual string Link { get; set; }

    /// <summary>
    /// An abridged version of this search result’s URL, e.g.www.example.com.
    /// </summary>
    public virtual string DisplayLink { get; set; }

    /// <summary>
    /// The snippet of the search result, in plain text.
    /// </summary>
    public virtual string Snippet { get; set; }

    /// <summary>
    /// The snippet of the search result, in HTML.
    /// </summary>
    public virtual string HtmlSnippet { get; set; }

    /// <summary>
    /// Indicates the ID of Google's cached version of the search result.
    /// </summary>
    public virtual string CacheId { get; set; }

    /// <summary>
    /// The MIME type of the search result.
    /// </summary>
    [JsonPropertyName("mime")]
    public virtual string MimeType { get; set; }

    /// <summary>
    /// The file format of the search results.
    /// </summary>
    public virtual string FileFormat { get; set; }

    /// <summary>
    /// The URL displayed after the snippet for each search result.
    /// </summary>
    public virtual string FormattedUrl { get; set; }

    /// <summary>
    /// The HTML-formatted URL displayed after the snippet for each search result.
    /// </summary>
    public virtual string HtmlFormattedUrl { get; set; }

    /// <summary>
    /// Contains PageMap information for this search result.
    /// </summary>
    public virtual PageMap PageMap { get; set; }

    /// <summary>
    /// Encapsulates all information about an image returned in search results.
    /// </summary>
    public virtual ItemImage Image { get; set; }

    /// <summary>
    /// Encapsulates all information about refinement labels.
    /// </summary>
    public virtual IEnumerable<Label> Labels { get; set; }
}