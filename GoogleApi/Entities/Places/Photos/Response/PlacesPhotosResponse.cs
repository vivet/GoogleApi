using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Photos.Response
{
    /// <summary>
    /// Places Photos Response.
    /// </summary>
    [DataContract]
    public class PlacesPhotosResponse : BasePlacesResponse
    {
        /// <summary>
        /// A stream containing the downloded photo.
        /// </summary>
        [JsonProperty("photo")]
        public virtual MemoryStream Photo { get; set; }
    }
}