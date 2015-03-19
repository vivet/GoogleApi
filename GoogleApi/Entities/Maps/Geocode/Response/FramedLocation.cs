using System.Runtime.Serialization;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.Geocode.Response
{
	[DataContract]
	public class FramedLocation
	{
		[DataMember(Name = "southwest")]
        public virtual Location SouthWest { get; set; }

		[DataMember(Name = "northeast")]
        public virtual Location NorthEast { get; set; }
	}
}
