namespace GoogleApi.Entities.Maps.StaticMaps.Request.Enums.Extensions
{
    /// <summary>
    /// Image Format Extensions.
    /// </summary>
    public static class ImageFormatExtensions
    {
        /// <summary>
        /// Gets the parameter name used for querying.
        /// </summary>
        /// <param name="format">The <inheritdoc cref="ImageFormat"/>.</param>
        /// <returns>The parameter name.</returns>
        public static string GetParameterName(this ImageFormat format)
        {
            switch (format)
            {
                case ImageFormat.Png:
                    return "png";

                case ImageFormat.Png32:
                    return "png32";

                case ImageFormat.Gif:
                    return "gif";

                case ImageFormat.Jpg:
                    return "jpg";

                case ImageFormat.JpgBaseline:
                    return "jpg-baseline";

                default:
                    return "png";
            }
        }
    }
}