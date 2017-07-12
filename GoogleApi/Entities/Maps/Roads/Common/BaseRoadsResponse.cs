using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Roads.Common
{
    /// <summary>
    /// NearestRoads Response.
    /// </summary>
    [DataContract]
    public class BaseRoadsResponse : BaseResponse
    {
        /// <summary>
        /// An array of snapped points
        /// </summary>
        [DataMember(Name = "snappedPoints")]
        public virtual IEnumerable<SnappedPoint> SnappedPoints { get; set; }
    }
}