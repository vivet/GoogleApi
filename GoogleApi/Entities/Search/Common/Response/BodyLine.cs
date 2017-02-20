using System.Runtime.Serialization;

namespace GoogleApi.Entities.Search.Common.Response
{
    /// <summary>
    /// Body line.
    /// </summary>
    [DataContract]
    public class BodyLine
    {
        /// <summary>
        /// The block object's text, if it has text.
        /// </summary>
        [DataMember(Name = "title")]
        public virtual string Title { get; set; }

        /// <summary>
        /// The block object's html text, if it has text.
        /// </summary>
        [DataMember(Name = "htmlTitle")]
        public virtual string HtmlTitle { get; set; }

        /// <summary>
        /// The anchor text of the block object's link, if it has a link.
        /// </summary>
        [DataMember(Name = "link")]
        public virtual string Link { get; set; }

        /// <summary>
        /// The URL of the block object's link, if it has one
        /// </summary>
        [DataMember(Name = "url")]
        public virtual string Url { get; set; }
    }
}