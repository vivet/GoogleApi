using Newtonsoft.Json;

namespace GoogleApi.Entities.Search.Video.Response
{
    /// <summary>
    /// 
    /// </summary>
    public class Status
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("uploadStatus")]
        public virtual string UploadStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("privacyStatus")]
        public virtual string PrivacyStatus { get; set; }
    }
}