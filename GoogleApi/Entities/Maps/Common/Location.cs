using System.Globalization;
using System.Runtime.Serialization;
using GoogleApi.Entities.Maps.Common.Interfaces;

namespace GoogleApi.Entities.Maps.Common
{
	[DataContract]
	public class Location : ILocationString
	{
		[DataMember(Name = "lat")]
        public virtual double Latitude { get; set; }

		[DataMember(Name = "lng")]
        public virtual double Longitude { get; set; }

        public Location(double latitude, double longitude)
		{
            Latitude = latitude;
            Longitude = longitude;
		}

		public string LocationString
		{
			get
			{
				return Latitude.ToString(CultureInfo.InvariantCulture) + "," + Longitude.ToString(CultureInfo.InvariantCulture);
			}
		}

		public override string ToString()
		{
			return LocationString;
		}
	}
}
