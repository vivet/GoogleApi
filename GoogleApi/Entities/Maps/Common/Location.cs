using System.Globalization;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Common
{
    /// <summary>
    /// Location.
    /// </summary>
    public class Location : Entities.Common.Location
    {
        /// <summary>
        /// Heading.
        /// </summary>
        public int? Heading { get; set; }

        /// <summary>
        /// Use Side Of Road.
        /// </summary>
        public bool UseSideOfRoad { get; set; } = false;

        /// <inheritdoc />
        public Location()
        {

        }

        /// <inheritdoc />
        public Location(string address)
            : base(address)
        {

        }

        /// <inheritdoc />
        public Location(double latitude, double longitude)
            : this()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        /// <summary>
        /// Overrdden ToString method for default conversion to Google compatible string.
        /// If address is null and use side of road is false, side_of_road will prepended to the location.
        /// If address is null, use side of road is false and heading is not null, the heading will be prepended to the location.
        /// </summary>
        /// <returns>The location string.</returns>
        public virtual string ToStringHeading()
        {
            if (this.Address != null)
            {
                return base.ToString();
            }

            if (this.UseSideOfRoad)
            {
                return $"side_of_road:{this.Latitude.ToString(CultureInfo.InvariantCulture)},{this.Longitude.ToString(CultureInfo.InvariantCulture)}";
            }

            if (this.Heading.HasValue)
            {
                return $"heading={Heading}:{this.Latitude.ToString(CultureInfo.InvariantCulture)},{this.Longitude.ToString(CultureInfo.InvariantCulture)}";
            }

            return base.ToString();
        }
    }
}