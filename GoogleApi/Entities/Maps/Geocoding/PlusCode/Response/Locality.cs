using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Geocoding.PlusCode.Response
{
    /// <summary>
    /// Locality.
    /// </summary>
    public class Locality
    {
        /// <summary>
        /// Address.
        /// </summary>
        [JsonProperty("local_address")]
        public virtual string Address { get; set; }

        /// <summary>
        /// Place Id.
        /// </summary>
        [JsonProperty("locality_place_id")]
        public virtual string PlaceId { get; set; }
    }
}