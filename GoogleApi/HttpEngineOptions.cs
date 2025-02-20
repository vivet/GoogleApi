using System.Collections.Generic;

namespace GoogleApi;

/// <summary>
/// Http Engine Options.
/// </summary>
public class HttpEngineOptions {
	/// <summary>
	/// Throw On Bad Request.
	/// </summary>
	public virtual bool ThrowOnInvalidRequest { get; set; } = true;

	/// <summary>
	/// Allows you to add custom HTTP headers to the requests.
	/// </summary>
	/// <example>new HttpEngineOptions { AdditionalHeaders = new() { { "Referer", "https://www.yoursite.com" } } }</example>
	public Dictionary<string, string> AdditionalHeaders { get; set; }
}