using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.Directions.Request
{
    /// <summary>
    /// Location.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Location String.
        /// </summary>
        public string String { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="place">The <see cref="Common.Place"/>.</param>
        public Location(Place place)
        {
            this.String = place.ToString();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="address">The <see cref="Address"/>.</param>
        public Location(Address address)
        {
            this.String = address.ToString();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="plusCode">The <see cref="PlusCode"/>.</param>
        public Location(PlusCode plusCode)
        {
            this.String = plusCode.ToString();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="coordinate">The <see cref="Entities.Common.Coordinate"/>.</param>
        public Location(Coordinate coordinate)
        {
            this.String = coordinate.ToString();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.String;
        }
    }
}