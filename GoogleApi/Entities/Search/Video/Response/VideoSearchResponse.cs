using System.Collections.Generic;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Video.Response
{
    /// <summary>
    /// 
    /// </summary>
    public class VideoSearchResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("kind")]
        public virtual string Kind { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("etag")]
        public virtual string ETag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("etag")]
        public virtual IEnumerable<Video> Videos { get; set; }
    }
}