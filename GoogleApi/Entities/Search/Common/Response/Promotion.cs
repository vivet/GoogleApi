using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Search.Common.Response
{
    /// <summary>
    /// The set of promotions. Present only if the custom search engine's configuration files define any promotions for the given query.
    /// https://developers.google.com/custom-search/docs/promotions.
    /// </summary>
    [DataContract]
    public class Promotion
    {
        /// <summary>
        /// The title of the promotion.
        /// </summary>
        [DataMember(Name = "title")]
        public virtual string Title { get; set; }

        /// <summary>
        /// The html title of the promotion.
        /// </summary>
        [DataMember(Name = "htmlTitle")]
        public virtual string HtmlTitle { get; set; }

        /// <summary>
        /// The URL of the promotion.
        /// </summary>
        [DataMember(Name = "link")]
        public virtual string Link { get; set; }

        /// <summary>
        /// An abridged version of this search's result URL, e.g. www.example.com.
        /// </summary>
        [DataMember(Name = "displayLink")]
        public virtual string DisplayLink { get; set; }

        /// <summary>
        /// An array of block objects for this promotion.
        /// See Google WebSearch Protocol reference for more information.	
        /// </summary>
        [DataMember(Name = "bodyLines")]
        public virtual IEnumerable<BodyLine> BodyLines { get; set; }

        /// <summary>
        /// Image associated with this promotion, if there is one.
        /// </summary>
        [DataMember(Name = "image")]
        public virtual PromotionImage PromotionImage { get; set; }
    }
}