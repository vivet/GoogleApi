namespace GoogleApi.Entities.Search.Video.Common;

/// <summary>
/// Thumbnails.
/// </summary>
public class Thumbnails
{
    /// <summary>
    /// Default.
    /// </summary>
    public virtual Thumbnail Default { get; set; }

    /// <summary>
    /// Medium.
    /// </summary>
    public virtual Thumbnail Medium { get; set; }

    /// <summary>
    /// High.
    /// </summary>
    public virtual Thumbnail High { get; set; }
}