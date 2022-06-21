using System;
using GoogleApi.Entities.Common.Enums;

namespace GoogleApi.Exceptions;

/// <summary>
/// Exception that is thrown when Google returns a status code
/// </summary>
public class GoogleApiException : Exception
{
    /// <summary>
    /// Status.
    /// </summary>
    public virtual Status? Status { get; set; }

    /// <summary>
    /// Constructor, accepting a error message and a optional status.
    /// </summary>
    /// <param name="message">The error message.</param>
    public GoogleApiException(string message)
        : base(message)
    {

    }

    /// <summary>
    /// Constructor, accepting a error message and a optional status.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <param name="innerException">The inner exception.</param>
    public GoogleApiException(string message, Exception innerException)
        : base(message, innerException)
    {

    }
}