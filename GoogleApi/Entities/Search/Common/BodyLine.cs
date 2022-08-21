namespace GoogleApi.Entities.Search.Common;

/// <summary>
/// Body line.
/// </summary>
public class BodyLine
{
    /// <summary>
    /// The block object's text, if it has text.
    /// </summary>
    public virtual string Title { get; set; }

    /// <summary>
    /// The block object's html text, if it has text.
    /// </summary>
    public virtual string HtmlTitle { get; set; }

    /// <summary>
    /// The anchor text of the block object's link, if it has a link.
    /// </summary>
    public virtual string Link { get; set; }

    /// <summary>
    /// The URL of the block object's link, if it has one
    /// </summary>
    public virtual string Url { get; set; }
}