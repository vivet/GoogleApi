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

	/// <summary>
	/// Specify the referer to send in the request in case your API key is restricted to specific domains.
	/// You need to specify one of the allowed domains, if you receive "PermissionDenied: Requests from referer &lt;empty> are blocked." errors.
	/// https://cloud.google.com/api-keys/docs/add-restrictions-api-keys#add-client-restrictions
	/// </summary>
	public string Referer
	{
		get {
			return AdditionalHeaders != null && AdditionalHeaders.TryGetValue("Referer", out var referer) ? referer : null;
		}
		set {
			AdditionalHeaders ??= [];
			AdditionalHeaders["Referer"] = value;
		}
	}
}