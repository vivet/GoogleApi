using System.Collections.Generic;
using GoogleApi.Entities.Common.Enums;

namespace GoogleApi.Entities.Maps.Common;

/// <summary>
/// Error.
/// </summary>
public class Error
{
    /// <summary>
    /// Code.
    /// </summary>
    public virtual int? Code { get; set; }

    /// <summary>
    /// Message.
    /// </summary>
    public virtual string Message { get; set; }

    /// <summary>
    /// Status.
    /// </summary>
    public virtual Status Status { get; set; }

    /// <summary>
    /// Details.
    /// </summary>
    public virtual IEnumerable<ErrorDetail> Details { get; set; }
}