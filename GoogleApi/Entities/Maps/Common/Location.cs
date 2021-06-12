using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Directions.Request;
using Coordinate = GoogleApi.Entities.Maps.Directions.Request.Coordinate;

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
        /// <param name="place"></param>
        public Location(Place place)
        {
            this.locationString = place.ToString();
        }

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
        /// <param name="plusCode"></param>
        public Location(PlusCode plusCode)
        {
            this.locationString = plusCode.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="polyLine"></param>
        public Location(PolyLine polyLine)
        {
            this.locationString = $"enc:{polyLine.Path}";
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