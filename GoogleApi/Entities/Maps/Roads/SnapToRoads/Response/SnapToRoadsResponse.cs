using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Roads.Common;

namespace GoogleApi.Entities.Maps.Roads.SnapToRoads.Response
{
    /// <summary>
    /// SnapToRoads Response.
    /// </summary>
	[DataContract]
	public class SnapToRoadsResponse : BaseResponse, IResponseFor
	{
        /// <summary>
        /// An array of snapped points
        /// </summary>
		[DataMember(Name = "snappedPoints")]
        public virtual IEnumerable<SnappedPoint> SnappedPoints { get; set; }
	}
}