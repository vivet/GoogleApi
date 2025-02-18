using System;
using System.IO;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities;

/// <summary>
/// Base Response Stream.
/// </summary>
public class BaseResponseStream : BaseResponse, IResponseStream
{
    /// <summary>
    /// Buffer.
    /// </summary>
    public virtual byte[] Buffer { get; set; }

    /// <summary>
    /// Stream.
    /// </summary>
    public virtual MemoryStream Stream => new(this.Buffer ?? Array.Empty<byte>());
}