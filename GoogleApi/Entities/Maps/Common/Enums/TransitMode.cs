using System;

namespace GoogleApi.Entities.Maps.Common.Enums
{
    /// <summary>
    /// Transit mode
    /// </summary>
    [Flags]
    public enum TransitMode
    {
        /// <summary>
        /// Indicates that the calculated route should prefer travel by bus.
        /// </summary>
        BUS = 0x0,
        /// <summary>
        /// Indicates that the calculated route should prefer travel by subway.
        /// </summary>
        SUBWAY = 0x1,
        /// <summary>
        /// Indicates that the calculated route should prefer travel by train.
        /// </summary>
        TRAIN = 0x2,
        /// <summary>
        /// Indicates that the calculated route should prefer travel by tram and light rail.
        /// </summary>
        TRAM = 0x3,
        /// <summary>
        /// Indicates that the calculated route should prefer travel by train, tram, light rail, and subway. This is equivalent to transit_mode=train|tram|subway.
        /// </summary>
        RAIL = 0x1 | 0x2 | 0x3
    }
}