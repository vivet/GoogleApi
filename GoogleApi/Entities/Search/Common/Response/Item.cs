using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Common.Response
{
    /// <summary>
    /// A search result item.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// A unique identifier for the type of current object. For this API, it is customsearch#result.	
        /// </summary>
        [JsonProperty("kind")]
        public virtual string Kind { get; set; }

        /// <summary>
        /// The title of the search result, in plain text.	
        /// </summary>
        [JsonProperty("title")]
        public virtual string Title { get; set; }

        /// <summary>
        /// The title of the search result, in HTML.
        /// </summary>
        [JsonProperty("htmlTitle")]
        public virtual string HtmlTitle { get; set; }

        /// <summary>
        /// The full URL to which the search result is pointing, e.g.http://www.example.com/foo/bar.
        /// </summary>
        [JsonProperty("link")]
        public virtual string Link { get; set; }

        /// <summary>
        /// An abridged version of this search result’s URL, e.g.www.example.com.
        /// </summary>
        [JsonProperty("displayLink")]
        public virtual string DisplayLink { get; set; }

        /// <summary>
        /// The snippet of the search result, in plain text.
        /// </summary>
        [JsonProperty("snippet")]
        public virtual string Snippet { get; set; }
       
        /// <summary>
        /// The snippet of the search result, in HTML.
        /// </summary>
        [JsonProperty("htmlSnippet")]
        public virtual string HtmlSnippet { get; set; }
     
        /// <summary>
        /// Indicates the ID of Google's cached version of the search result.
        /// </summary>
        [JsonProperty("cacheId")]
        public virtual string CacheId { get; set; }

        /// <summary>
        /// The MIME type of the search result.	
        /// </summary>
        [JsonProperty("mime")]
        public virtual string MimeType { get; set; }

        /// <summary>
        /// The file format of the search results.
        /// </summary>
        [JsonProperty("fileFormat")]
        public virtual string FileFormat { get; set; }

        /// <summary>
        /// The URL displayed after the snippet for each search result.
        /// </summary>
        [JsonProperty("formattedUrl")]
        public virtual string FormattedUrl { get; set; }

        /// <summary>
        /// The HTML-formatted URL displayed after the snippet for each search result.
        /// </summary>
        [JsonProperty("htmlFormattedUrl")]
        public virtual string HtmlFormattedUrl { get; set; }

        /// <summary>
        /// Encapsulates all information about an image returned in search results.
        /// </summary>
        [JsonProperty("image")]
        public virtual ItemImage Image { get; set; }

        /// <summary>
        /// Contains PageMap information for this search result.
        /// </summary>
        [JsonProperty("pagemap")]
        public virtual PageMap PageMap { get; set; }

        /// <summary>
        /// Encapsulates all information about refinement labels.	
        /// </summary>
        [JsonProperty("labels")]
        public virtual IEnumerable<Label> Labels { get; set; }
    }
}