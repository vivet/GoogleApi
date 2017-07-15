using System.Globalization;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Common
{
    /// <summary>
    /// Location.
    /// </summary>
    [DataContract(Name = "location")]
    public class Location
    {
        /// <summary>
        /// Latitude.
        /// </summary>
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude.
        /// </summary>
        [JsonProperty("lng")]
        public double Longitude { get; set; }

        /// <summary>
        /// Address.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        protected Location()
        {

        }

        /// <summary>
        /// Constructor initializing a location by an address string.
        /// </summary>
        /// <param name="address"></param>
        public Location(string address)
            : this()
        {
            this.Address = address;
        }

        /// <summary>
        /// Contructor intializing a location using <paramref name="latitude"/> and <paramref name="longitude"/>.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        public Location(double latitude, double longitude)
            : this()
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
            return this.Address ?? this.Latitude.ToString(CultureInfo.InvariantCulture) + "," + this.Longitude.ToString(CultureInfo.InvariantCulture);
        }
    }
}