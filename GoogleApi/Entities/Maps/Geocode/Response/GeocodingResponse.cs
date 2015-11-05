using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.Geocode.Response
{
    /// <summary>
    /// Geocoding responses are returned in the format indicated by the output flag within the URL request's path.
    /// </summary>
	[DataContract]
	public class GeocodingResponse : MapsBaseResponse, IResponseFor
	{
        /// <summary>
        /// Results array.
        /// </summary>
		[DataMember(Name = "results")]
        public virtual IEnumerable<Result> Results { get; set; }
	}
}