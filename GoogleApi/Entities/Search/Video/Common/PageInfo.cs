namespace GoogleApi.Entities.Search.Video.Common;

/// <summary>
/// Page Info.
/// </summary>
public class PageInfo
{
    /// <summary>
    /// Total Results.
    /// </summary>
    public virtual int TotalResults { get; set; }

    /// <summary>
    /// Results Per Page.
    /// </summary>
    public virtual int ResultsPerPage { get; set; }
}