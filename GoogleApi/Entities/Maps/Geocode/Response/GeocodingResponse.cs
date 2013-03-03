using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.Geocode.Response
{
	[DataContract]
	public class GeocodingResponse : MapsBaseResponse, IResponseFor
	{
		[DataMember(Name = "results")]
		public IEnumerable<Result> Results { get; set; }
	}
}