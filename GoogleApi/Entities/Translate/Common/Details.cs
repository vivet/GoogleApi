namespace GoogleApi.Entities.Translate.Common;

/// <summary>
/// Details.
/// </summary>
public class Details
{
    /// <summary>
    /// Type.
    /// </summary>
    public virtual string Type { get; set; }

    /// <summary>
    /// Reason.
    /// </summary>
    public virtual string Reason { get; set; }

    /// <summary>
    /// Domain.
    /// </summary>
    public virtual string Domain { get; set; }

    /// <summary>
    /// Metadata.
    /// </summary>
    public virtual Metadata Metadata { get; set; }
}