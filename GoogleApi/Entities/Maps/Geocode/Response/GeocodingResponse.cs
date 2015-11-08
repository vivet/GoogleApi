using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;

namespace GoogleApi.Entities.Maps.Geocode.Response
{
    /// <summary>
    /// Geocoding Response.
    /// </summary>
	[DataContract]
	public class GeocodingResponse : BaseResponse, IResponseFor
	{
        /// <summary>
        /// Results array.
        /// </summary>
		[DataMember(Name = "results")]
        public virtual IEnumerable<GeocodeResult> Results { get; set; }
	}
}