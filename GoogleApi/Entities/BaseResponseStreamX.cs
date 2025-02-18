using System.IO;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities;

/// <summary>
/// Base Response Stream X.
/// </summary>
public class BaseResponseStreamX : BaseResponseX, IResponseStream
{
    /// <summary>
    /// Buffer.
    /// </summary>
    public virtual byte[] Buffer { get; set; }

    /// <summary>
    /// Stream.
    /// </summary>
    public virtual MemoryStream Stream => new(this.Buffer ?? []);
}