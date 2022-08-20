using System;
using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Common;

/// <summary>
/// Plus Code.
/// </summary>
public class PlusCode
{
    /// <summary>
    /// Global Code.
    /// A 4 character area code.
    /// </summary>
    [JsonPropertyName("global_code")]
    public string GlobalCode { get; protected set; }

    /// <summary>
    /// Global Code.
    /// A 6 character or longer local code with an explicit location (CWC8+R9, Mountain View, CA, USA).
    /// </summary>
    [JsonPropertyName("compound_code")]
    public string LocalCode { get; protected set; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="globalCode">The global code.</param>
    /// <param name="localCode">The local code (optional).</param>
    public PlusCode(string globalCode, string localCode = null)
    {
        this.GlobalCode = globalCode ?? throw new ArgumentNullException(nameof(globalCode));
        this.LocalCode = localCode;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{this.GlobalCode}{this.LocalCode}";
    }
}