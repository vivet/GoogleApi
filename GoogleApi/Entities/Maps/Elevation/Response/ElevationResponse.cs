using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.Elevation.Response
{
    /// <summary>
    /// For each valid request, the Elevation service will return an Elevation response in the format indicated within the request URL.
    /// </summary>
	[DataContract]
	public class ElevationResponse : MapsBaseResponse, IResponseFor
	{
        /// <summary>
        /// Results.
        /// </summary>
		[DataMember(Name = "results")]
        public virtual IEnumerable<Result> Results { get; set; }
	}
}
