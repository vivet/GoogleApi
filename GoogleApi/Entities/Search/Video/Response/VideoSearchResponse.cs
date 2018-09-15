using System.Collections.Generic;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.Search.Video.Response.Enums;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Video.Response
{
    /// <summary>
    /// 
    /// </summary>
    public class VideoSearchResponse : BaseResponse
    {
        /// <summary>
        /// Kind.
        /// </summary>
        [JsonProperty("kind")]
        public virtual string Kind { get; set; }

        /// <summary>
        /// ETag.
        /// </summary>
        [JsonProperty("etag")]
        public virtual string ETag { get; set; }

        /// <summary>
        /// Page Token.
        /// </summary>
        [JsonProperty("nextPageToken")]
        public virtual string PageToken { get; set; }

        /// <summary>
        /// Region Code.
        /// </summary>
        [JsonProperty("regionCode")]
        [JsonConverter(typeof(StringEnumOrDefaultConverter<Country>))]
        public virtual Country Region { get; set; }

        /// <summary>
        /// Page Info.
        /// </summary>
        [JsonProperty("pageInfo")]
        public virtual PageInfo PageInfo { get; set; }

        /// <summary>
        /// Items.
        /// </summary>
        [JsonProperty("Items")]
        public virtual IEnumerable<Video> Items { get; set; }
    }
}