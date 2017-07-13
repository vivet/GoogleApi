using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Maps.Roads.Common;

namespace GoogleApi.Entities.Maps.Roads
{
    /// <summary>
    /// Base abstract roads response.
    /// </summary>
    [DataContract]
    public abstract class BaseRoadsResponse : BaseResponse
    {
        /// <summary>
        /// An array of snapped points.
        /// </summary>
        [DataMember(Name = "snappedPoints")]
        public virtual IEnumerable<SnappedPoint> SnappedPoints { get; set; }
    }
}