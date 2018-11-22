using System.Collections.Generic;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.Search.Video.Common;
using GoogleApi.Entities.Search.Video.Common.Enums;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Video
{
    /// <summary>
    /// Base Video Search Response (abstract).
    /// </summary>
    public abstract class BaseVideoSearchResponse : BaseResponse
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
        [JsonProperty("items")]
        public virtual IEnumerable<Item> Items { get; set; }
    }
}