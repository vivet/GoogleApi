using System.Globalization;

namespace GoogleApi.Entities.Places.Search.NearBy.Request
{
    /// <summary>
    /// Location.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Latitude.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Location()
        {

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
            return this.Latitude.ToString(CultureInfo.InvariantCulture) + "," + this.Longitude.ToString(CultureInfo.InvariantCulture);
        }
    }
}