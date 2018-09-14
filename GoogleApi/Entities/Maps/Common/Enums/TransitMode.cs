using System;

namespace GoogleApi.Entities.Maps.Common.Enums
{
    /// <summary>
    /// Transit mode.
    /// </summary>
    [Flags]
    public enum TransitMode
    {
        /// <summary>
        /// Indicates that the calculated route should prefer travel by subway.
        /// </summary>
        Subway = 1 << 0,

        /// <summary>
        /// Indicates that the calculated route should prefer travel by train.
        /// </summary>
        Train = 1 << 1,

        /// <summary>
        /// Indicates that the calculated route should prefer travel by tram and light rail.
        /// </summary>
        Tram = 1 << 2,

        /// <summary>
        /// Indicates that the calculated route should prefer travel by bus.
        /// </summary>
        Bus = 1 << 3,

        /// <summary>
        /// Indicates that the calculated route should prefer travel by train, tram, light rail, and subway. 
        /// This is equivalent to transit_mode=train|tram|subway.
        /// </summary>
        Rail = TransitMode.Subway | TransitMode.Train | TransitMode.Tram
    }
}