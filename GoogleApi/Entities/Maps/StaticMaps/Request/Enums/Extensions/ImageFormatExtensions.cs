namespace GoogleApi.Entities.Maps.StaticMaps.Request.Enums.Extensions;

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
        return format switch
        {
            ImageFormat.Png => "png",
            ImageFormat.Png32 => "png32",
            ImageFormat.Gif => "gif",
            ImageFormat.Jpg => "jpg",
            ImageFormat.JpgBaseline => "jpg-baseline",
            _ => "png"
        };
    }
}