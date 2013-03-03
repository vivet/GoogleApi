using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.Elevation.Response
{
	[DataContract]
	public class ElevationResponse : MapsBaseResponse, IResponseFor
	{
        /// <summary>
        /// Results.
        /// </summary>
		[DataMember(Name = "results")]
		public IEnumerable<Result> Results { get; set; }
	}
}
