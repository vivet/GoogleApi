using System.Collections.Generic;

namespace GoogleApi.Entities.Maps.Common;

/// <summary>
/// Error.
/// </summary>
public class Error
{
    /// <summary>
    /// This is the same as the HTTP status of the response.
    /// </summary>
    public virtual string Code { get; set; }

    /// <summary>
    /// A short description of the error.
    /// </summary>
    public virtual string ErrorMessage { get; set; }

    /// <summary>
    /// Collection of errors.
    /// </summary>
    public virtual IEnumerable<ErrorDetail> Errors { get; set; }
}