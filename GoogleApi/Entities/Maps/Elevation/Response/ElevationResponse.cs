using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;

namespace GoogleApi.Entities.Maps.Elevation.Response
{
    /// <summary>
    /// Elevation Response.
    /// </summary>
	[DataContract]
	public class ElevationResponse : BaseResponse, IResponseFor
	{
        /// <summary>
        /// Results.
        /// </summary>
		[DataMember(Name = "results")]
        public virtual IEnumerable<ElevationResult> Results { get; set; }
	}
}
