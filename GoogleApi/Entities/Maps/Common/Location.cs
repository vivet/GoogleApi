using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Common
{
    /// <summary>
    /// Location.
    /// </summary>
    public class Location
    {
        private readonly string locationString;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        public Location(Address address)
        {
            this.locationString = address.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinate"></param>
        public Location(Coordinate coordinate)
        {
            this.locationString = coordinate.ToString();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.locationString;
        }
    }
}