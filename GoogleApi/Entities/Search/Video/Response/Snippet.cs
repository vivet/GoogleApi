using System;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Video.Response
{
    /// <summary>
    /// 
    /// </summary>
    public class Snippet
    {
        /// <summary>
        /// Title.
        /// </summary>
        [JsonProperty("title")]
        public virtual string Title { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        [JsonProperty("description")]
        public virtual string Description { get; set; }

        /// <summary>
        /// Channel Id.
        /// </summary>
        [JsonProperty("channelId")]
        public virtual string ChannelId { get; set; }

        /// <summary>
        /// Channel Title.
        /// </summary>
        [JsonProperty("channelTitle")]
        public virtual string ChannelTitle { get; set; }

        /// <summary>
        /// Live Broadcast Content.
        /// </summary>
        [JsonProperty("liveBroadcastContent")]
        public virtual string LiveBroadcastContent { get; set; }

        /// <summary>
        /// Category Id.
        /// </summary>
        [JsonProperty("categoryId")]
        public virtual int CategoryId { get; set; }

        /// <summary>
        /// Published At.
        /// </summary>
        [JsonProperty("publishedAt")]
        public virtual DateTimeOffset PublishedAt { get; set; }

        /// <summary>
        /// Thumbnails.
        /// </summary>
        [JsonProperty("thumbnails")]
        public virtual Thumbnails Thumbnails { get; set; }
    }
}