using System.Runtime.Serialization;
using GoogleApi.Entities.Common;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Directions.Response
{
    /// <summary>
    /// Contains information about bounding box of the direction requested.
    /// </summary>
    [DataContract(Name = "bounds")]
    public class Bounds
    {
        /// <summary>
        /// The location of the north / east corner.
        /// </summary>
        [JsonProperty("northeast")]
        public virtual Location NorthEast { get; set; }

        /// <summary>
        /// The location of the south / west corner.
        /// </summary>
        [JsonProperty("southwest")]
        public virtual Location SouthWest { get; set; }
    }
}