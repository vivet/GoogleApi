using System.IO;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Photos.Response
{
    /// <summary>
    /// Places Photos Response.
    /// </summary>
    public class PlacesPhotosResponse : BasePlacesResponse
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("photo")]
        public virtual byte[] PhotoBuffer { get; set; }

        /// <summary>
        /// Returns a <see cref="MemoryStream"/> based on the <see cref="PlacesPhotosResponse.PhotoBuffer"/> downloded.
        /// </summary>
        [JsonProperty("photo")]
        public virtual MemoryStream Photo => new MemoryStream(this.PhotoBuffer ?? new byte[0]);
    }
}