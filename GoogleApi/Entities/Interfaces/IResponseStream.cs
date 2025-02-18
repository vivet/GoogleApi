using System.IO;

namespace GoogleApi.Entities.Interfaces;

/// <summary>
/// Response Stream Interface.
/// </summary>
public interface IResponseStream
{
    /// <summary>
    /// Buffer.
    /// </summary>
    byte[] Buffer { get; set; }

    /// <summary>
    /// Stream.
    /// </summary>
    MemoryStream Stream { get; }
}