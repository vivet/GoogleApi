using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Common
{
    /// <summary>
    /// Location Ex.
    /// </summary>
    public class LocationEx
    {
        /// <summary>
        /// Location String.
        /// </summary>
        public string String { get; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="place">The <see cref="Place"/>.</param>
        public LocationEx(Place place)
        {
            this.String = place.ToString("place_id");
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="address">The <see cref="Address"/>.</param>
        public LocationEx(Address address)
        {
            this.String = address.ToString();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="plusCode">The <see cref="PlusCode"/>.</param>
        public LocationEx(PlusCode plusCode)
        {
            this.String = plusCode.ToString();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="coordinate">The <see cref="CoordinateEx"/>.</param>
        public LocationEx(CoordinateEx coordinate)
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