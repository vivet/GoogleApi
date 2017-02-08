namespace GoogleApi.Entities.Search.Common.Enums
{
    /// <summary>
    /// Search safety level.
    /// </summary>
    public enum SafetyLevel
    {
        /// <summary>
        /// Disables SafeSearch filtering. (default)
        /// </summary>
        Off,
        /// <summary>
        /// Enables moderate SafeSearch filtering.
        /// </summary>
        Medium,
        /// <summary>
        /// Enables highest level of SafeSearch filtering.
        /// </summary>
        High
    }
}