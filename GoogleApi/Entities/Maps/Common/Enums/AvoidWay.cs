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
		NOTHING = 0x0,
		/// <summary>
		/// Avoid Tolls
		/// </summary>
        TOLLS = 0x1,
        /// <summary>
        /// Avoid highways
        /// </summary>
        HIGHWAYS = 0x2,
    	/// <summary>
    	/// Avoid Indoor
    	/// </summary>
        INDOOR = 0x3
}
}
