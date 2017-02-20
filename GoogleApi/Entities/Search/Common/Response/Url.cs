using System.Runtime.Serialization;

namespace GoogleApi.Entities.Search.Common.Response
{
    /// <summary>
    /// The OpenSearch URL element that defines the template for the API.
    /// </summary>
    [DataContract]
    public class Url
    {
        /// <summary>
        /// The MIME type of the OpenSearch URL template for the Custom Search API.	
        /// </summary>
        [DataMember(Name = "type")]
        public virtual string Type { get; set; }

        /// <summary>
        /// The actual OpenSearch template for this API.
        /// </summary>
        [DataMember(Name = "template")]
        public virtual string Template { get; set; }
    }
}