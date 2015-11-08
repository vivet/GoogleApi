using System;

namespace GoogleApi.Entities.Maps.Common.Enums
{
    /// <summary>
    /// Transit Routing Preference.
    /// </summary>
    [Flags]
    public enum TransitRoutingPreference 
    {
        /// <summary>
        /// No TransitRoutingPreference.
        /// </summary>
        NOTHING = 0x0,
        /// <summary>
        /// Indicates that the calculated route should prefer limited amounts of walking.
        /// </summary>
        LESS_WALKING = 0x1,
        /// <summary>
        /// Indicates that the calculated route should prefer a limited number of transfers.
        /// </summary>
        FEWER_TRANSFERS = 0x2
    }
}