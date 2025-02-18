namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Information about the author of the UGC data. Used in Photo, and Review.
/// </summary>
public class AuthorAttribution
{
    /// <summary>
    /// Name of the author of the Photo or Review.
    /// </summary>
    public virtual string DdisplayName { get; set; }

    /// <summary>
    /// URI of the author of the Photo or Review.
    /// </summary>
    public virtual string Uri { get; set; }

    /// <summary>
    /// Profile photo URI of the author of the Photo or Review.
    /// </summary>
    public virtual string PhotoUri { get; set; }
}