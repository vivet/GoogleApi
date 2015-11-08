using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Roads.Common;

namespace GoogleApi.Entities.Maps.Roads.SpeedLimits.Response
{
    /// <summary>
    /// SpeedLimits Response.
    /// </summary>
	[DataContract]
    public class SpeedLimitsResponse : BaseResponse, IResponseFor
	{
        /// <summary>
        /// An array of snapped points
        /// </summary>
        [DataMember(Name = "snappedPoints")]
        public virtual IEnumerable<SnappedPoint> SnappedPoints { get; set; }

        /// <summary>
        /// SpeedLimits — An array of road metadata. Each element consists of the following fields:
        /// </summary>
        [DataMember(Name = "speedLimits")]
        public virtual IEnumerable<SpeedLimit> SpeedLimits { get; set; }
    }
}