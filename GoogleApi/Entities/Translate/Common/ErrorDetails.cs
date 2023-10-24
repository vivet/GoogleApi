namespace GoogleApi.Entities.Translate.Common;

/// <summary>
/// Error Details.
/// </summary>
public class ErrorDetails
{
    /// <summary>
    /// Message.
    /// </summary>
    public virtual string Message { get; set; }

    /// <summary>
    /// Domain.
    /// </summary>
    public virtual string Domain { get; set; }

    /// <summary>
    /// Reason.
    /// </summary>
    public virtual string Reason { get; set; }
}