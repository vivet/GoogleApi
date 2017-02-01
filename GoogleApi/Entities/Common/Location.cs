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
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        [DataMember(Name = "lng")]
        public double Longitude { get; set; }

        /// <summary>
        /// Contructor intializing a valid Location
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public Location(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// Location expressed as Google compatible string.
        /// </summary>
        public virtual string LocationString => this.Latitude.ToString(CultureInfo.InvariantCulture) + "," + this.Longitude.ToString(CultureInfo.InvariantCulture);

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