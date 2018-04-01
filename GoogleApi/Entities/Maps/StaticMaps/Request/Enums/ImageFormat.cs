namespace GoogleApi.Entities.Maps.StaticMaps.Request.Enums
{
    /// <summary>
    /// Image Format.
    /// </summary>
    public enum ImageFormat
    {
        /// <summary>
        /// Specifies the 8-bit PNG format (default).
        /// </summary>
        Png,

        /// <summary>
        /// specifies the 32-bit PNG format.
        /// </summary>
        Png32,
		
        /// <summary>
        /// specifies the GIF format.
        /// </summary>
        Gif,
		
        /// <summary>
        /// specifies the JPEG compression format.
        /// </summary>
        Jpg,

        /// <summary>
        /// specifies a non-progressive JPEG compression format.
        /// </summary>
        JpgBaseline
    }
}