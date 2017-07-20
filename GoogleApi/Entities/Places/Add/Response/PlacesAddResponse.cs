using GoogleApi.Entities.Places.Common.Enums;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Places.Add.Response
{
    /// <summary>
    /// Places add response.
    /// </summary>
    public class PlacesAddResponse : BasePlacesResponse
    {
        /// <summary>
        /// A textual identifier that uniquely identifies a place. To retrieve information about the place, 
        /// pass this identifier in the placeid field of a Place Details request. 
        /// For more information about place IDs, see the place ID overview.
        /// </summary>
        [JsonProperty("place_id")]
        public virtual string PlaceId { get; set; }

        /// <summary>
        /// Indicates the scope of the place_id. 
        /// </summary>
        [JsonProperty("scope")]
        public virtual Scope Scope { get; set; }
    }
}