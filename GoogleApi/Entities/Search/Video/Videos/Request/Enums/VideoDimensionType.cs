namespace GoogleApi.Entities.Search.Video.Videos.Request.Enums
{
    /// <summary>
    /// Video Dimension Type.
    /// </summary>
    public enum VideoDimensionType
    {
        /// <summary>
        /// Any.
        /// Include both 3D and non-3D videos in returned results.
        /// This is the default value.
        /// </summary>
        Any,

        /// <summary>
        /// Two Dimensional (2D).
        /// Restrict search results to exclude 3D videos.
        /// </summary>
        TwoDimensional,

        /// <summary>
        /// Three Dimensional (3D).
        /// Restrict search results to only include 3D videos.
        /// </summary>
        ThreeDimensional
    }
}