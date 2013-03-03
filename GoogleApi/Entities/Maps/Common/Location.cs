using System.Globalization;
using System.Runtime.Serialization;
using GoogleApi.Entities.Maps.Common.Interfaces;

namespace GoogleApi.Entities.Maps.Common
{
	[DataContract]
	public class Location : ILocationString
	{
		[DataMember(Name = "lat")]
		public double Latitude { get; set; }

		[DataMember(Name = "lng")]
		public double Longitude { get; set; }

        public Location(double _latitude, double _longitude)
		{
            this.Latitude = _latitude;
            this.Longitude = _longitude;
		}

		public string LocationString
		{
			get
			{
				return this.Latitude.ToString(CultureInfo.InvariantCulture) + "," + this.Longitude.ToString(CultureInfo.InvariantCulture);
			}
		}

		public override string ToString()
		{
			return this.LocationString;
		}
	}
}
