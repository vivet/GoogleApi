using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Roads.Common;

namespace GoogleApi.Entities.Maps.Roads.NearestRoads.Response
{
    /// <summary>
    /// NearestRoads Response.
    /// </summary>
    [DataContract]
    public class NearestRoadsResponse : BaseResponse
    {
        /// <summary>
        /// An array of snapped points
        /// </summary>
        [DataMember(Name = "snappedPoints")]
        public virtual IEnumerable<SnappedPoint> SnappedPoints { get; set; }
    }
}