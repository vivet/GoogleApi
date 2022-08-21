namespace GoogleApi.Entities.Search.Common;

/// <summary>
///
/// </summary>
public class ItemImage
{
    /// <summary>
    /// A URL pointing to the webpage hosting the image.
    /// </summary>
    public virtual string ContextLink { get; set; }

    /// <summary>
    /// Image width in pixels.
    /// </summary>
    public virtual int Width { get; set; }

    /// <summary>
    /// Image height in pixels.
    /// </summary>
    public virtual int Height { get; set; }

    /// <summary>
    /// The size of the image, in pixels.
    /// </summary>
    public virtual int ByteSize { get; set; }

    /// <summary>
    /// A URL to the thumbnail image.
    /// </summary>
    public virtual string ThumbnailLink { get; set; }

    /// <summary>
    /// The height of the thumbnail image, in pixels.
    /// </summary>
    public virtual int ThumbnailHeight { get; set; }

    /// <summary>
    /// The width of the thumbnail image, in pixels.
    /// </summary>
    public virtual int ThumbnailWidth { get; set; }
}