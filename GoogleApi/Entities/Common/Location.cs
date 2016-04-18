using System.Globalization;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Interfaces;

namespace GoogleApi.Entities.Common
{
    /// <summary>
    /// Location.
    /// </summary>
	[DataContract]
	public class Location : ILocationString
	{
        /// <summary>
        /// Latitude.
        /// </summary>
		[DataMember(Name = "lat")]
        public virtual double Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
		[DataMember(Name = "lng")]
        public virtual double Longitude { get; set; }

        /// <summary>
        /// Contructor intializing a valid Location
        /// </summary>
        /// <param name="_latitude"></param>
        /// <param name="_longitude"></param>
        public Location(double _latitude, double _longitude)
		{
            this.Latitude = _latitude;
            this.Longitude = _longitude;
		}

        /// <summary>
        /// Location expressed as Google compatible string.
        /// </summary>
		public virtual string LocationString
		{
			get
			{
				return this.Latitude.ToString(CultureInfo.InvariantCulture) + "," + this.Longitude.ToString(CultureInfo.InvariantCulture);
			}
		}

        /// <summary>
        /// Overrdden ToString method for default conversion to Google compatible string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
		{
			return this.LocationString;
		}
	}
}
