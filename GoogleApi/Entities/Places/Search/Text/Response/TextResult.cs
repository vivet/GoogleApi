using System.Text.Json.Serialization;

using GoogleApi.Entities.Places.Search.Common;

namespace GoogleApi.Entities.Places.Search.Text.Response;

/// <summary>
/// Text Result.
/// </summary>
public class TextResult : BaseResult
{
    /// <summary>
    /// FormattedAddress is a string containing the human-readable address of this place.
    /// Often this address is equivalent to the "postal address".
    /// The formatted_address property is only returned for a Text Search.
    /// </summary>
    [JsonPropertyName("formatted_address")]
    public virtual string FormattedAddress { get; set; }
}