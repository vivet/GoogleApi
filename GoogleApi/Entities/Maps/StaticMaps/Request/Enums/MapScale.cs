namespace GoogleApi.Entities.Maps.StaticMaps.Request.Enums
{
    /// <summary>
    /// Map Scale.
    /// </summary>
    public enum MapScale
    {
        /// <summary>
        /// Normal (default).
        /// </summary>
        Normal = 1,

        /// <summary>
        /// Large. 
        /// Twice has many pixels as normal.
        /// </summary>
        Large = 2,

        /// <summary>
        /// Huge. 
        /// Twice as many pixels as large.
        /// Only available to Google Maps APIs Premium Plan customers
        /// </summary>
        Huge = 4
    }
}