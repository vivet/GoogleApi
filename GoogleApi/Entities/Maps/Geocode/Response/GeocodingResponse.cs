using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Geocode.Response
{
    /// <summary>
    /// Geocoding Response.
    /// </summary>
    [DataContract]
    public class GeocodingResponse : BaseResponse
    {
        /// <summary>
        /// Results array.
        /// </summary>
        [DataMember(Name = "results")]
        public virtual IEnumerable<GeocodeResult> Results { get; set; }
    }
}