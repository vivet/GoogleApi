using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Elevation.Response
{
    /// <summary>
    /// Elevation Response.
    /// </summary>
    [DataContract]
    public class ElevationResponse : BaseResponse
    {
        /// <summary>
        /// Results.
        /// </summary>
        [DataMember(Name = "results")]
        public virtual IEnumerable<ElevationResult> Results { get; set; }
    }
}