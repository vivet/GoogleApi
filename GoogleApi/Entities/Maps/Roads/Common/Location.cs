using System.Globalization;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Roads.Common
{
    // TODO: Refactor into Common Location entity (differs in DataMember name)
    /// <summary>
    /// Location (Roads only). 
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Latitude.
        /// </summary>
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        [JsonProperty("longitude")]
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