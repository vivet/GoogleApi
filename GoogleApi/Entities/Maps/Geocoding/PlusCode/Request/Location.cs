using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Geocoding.PlusCode.Request
{
    /// <summary>
    /// Location.
    /// </summary>
    public class Location : Maps.Common.Location
    {
        /// <inheritdoc />
        public Location(Coordinate coordinate)
            : base(coordinate)
        {

        }

        /// <inheritdoc />
        public Location(Entities.Common.Address address)
            : base(address)
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="globalCode">The <see cref="GlobalCode"/>.</param>
        public Location(GlobalCode globalCode)
            : base(new Entities.Common.Address(globalCode?.ToString()))
        {

        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="localCodeAndLocality">The <see cref="LocalCodeAndLocality"/>.</param>
        public Location(LocalCodeAndLocality localCodeAndLocality)
            : base(new Entities.Common.Address(localCodeAndLocality?.ToString()))
        {

        }
    }
}