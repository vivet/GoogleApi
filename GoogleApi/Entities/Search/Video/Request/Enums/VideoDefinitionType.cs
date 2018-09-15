namespace GoogleApi.Entities.Search.Video.Request.Enums
{
    /// <summary>
    /// Video Definition Type.
    /// </summary>
    public enum VideoDefinitionType
    {
        /// <summary>
        /// Any.
        /// Return all videos, regardless of their resolution.
        /// This is the default value.
        /// </summary>
        Any,

        /// <summary>
        /// High.
        /// Only retrieve HD videos.
        /// </summary>
        High,

        /// <summary>
        /// Standard.
        /// Only retrieve videos in standard definition.
        /// </summary>
        Standard
    }
}