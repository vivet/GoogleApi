using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Maps.Roads.Common;

namespace GoogleApi.Entities.Maps.Roads.SpeedLimits.Response
{
    /// <summary>
    /// SpeedLimits Response.
    /// </summary>
    [DataContract]
    public class SpeedLimitsResponse : BaseRoadsResponse
    {
        /// <summary>
        /// SpeedLimits — An array of road metadata. Each element consists of the following fields:
        /// </summary>
        [DataMember(Name = "speedLimits")]
        public virtual IEnumerable<SpeedLimit> SpeedLimits { get; set; }
    }
}