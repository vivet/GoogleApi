using System.Globalization;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Roads.Common
{
    /// <summary>
    /// Location (Roads only). 
    /// </summary>
    [DataContract]
    public class Location
    {
        /// <summary>
        /// Latitude.
        /// </summary>
        [DataMember(Name = "latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        [DataMember(Name = "longitude")]
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
        /// Overrdden ToString method for default conversion to Google compatible string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Latitude.ToString(CultureInfo.InvariantCulture) + "," + this.Longitude.ToString(CultureInfo.InvariantCulture);
        }
    }
}