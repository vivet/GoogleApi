using System.Collections.Generic;
using GoogleApi.Entities.Common.Enums;

namespace GoogleApi.Entities.Translate.Common;

/// <summary>
/// Error.
/// </summary>
public class Error
{
    /// <summary>
    /// Code.
    /// </summary>
    public virtual int Code { get; set; }

    /// <summary>
    /// Message.
    /// </summary>
    public virtual string Message { get; set; }

    /// <summary>
    /// Status.
    /// </summary>
    public virtual Status Status { get; set; }

    /// <summary>
    /// Error.
    /// </summary>
    public virtual IEnumerable<ErrorDetails> Errors { get; set; }

    /// <summary>
    /// Error Details.
    /// </summary>
    public virtual IEnumerable<ErrorDetails> Details { get; set; }
}