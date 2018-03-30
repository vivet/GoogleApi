using System.IO;
using GoogleApi.Entities.Places.Photos.Response;
using Newtonsoft.Json;

namespace GoogleApi.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseStreamResponse : BaseResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("")]
        public virtual byte[] Buffer { get; set; }

        /// <summary>
        /// Returns a <see cref="MemoryStream"/> based on the <see cref="PlacesPhotosResponse.PhotoBuffer"/> downloded.
        /// </summary>
        [JsonProperty("")]
        public virtual MemoryStream Photo => new MemoryStream(this.Buffer ?? new byte[0]);
    }
}