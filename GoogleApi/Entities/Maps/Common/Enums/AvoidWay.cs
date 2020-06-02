using System;

namespace GoogleApi.Entities.Maps.Common.Enums
{
    /// <summary>
    /// Avoid Way restrictions.
    /// </summary>
    [Flags]
    public enum AvoidWay
    {
        /// <summary>
        /// Nothing
        /// </summary>
        Nothing = 0,

        /// <summary>
        /// Avoid tolls
        /// </summary>
        Tolls = 1 << 1,

        /// <summary>
        /// Avoid highways
        /// </summary>
        Highways = 1 << 2,

        /// <summary>
        /// Avoid indoor
        /// </summary>
        Indoor = 1 << 3,

        /// <summary>
        /// Avoid ferries
        /// </summary>
        Ferries = 1 << 4
    }
}