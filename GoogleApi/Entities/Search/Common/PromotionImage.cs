namespace GoogleApi.Entities.Search.Common;

/// <summary>
/// Image associated with this promotion, if there is one.
/// </summary>
public class PromotionImage
{
    /// <summary>
    /// URL of the image for this promotion link.
    /// </summary>
    public virtual string Source { get; set; }

    /// <summary>
    /// Image width in pixels.
    /// </summary>
    public virtual int Width { get; set; }

    /// <summary>
    /// Image height in pixels.
    /// </summary>
    public virtual int Height { get; set; }
}