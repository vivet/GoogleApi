using System.Runtime.Serialization;
using System.Text.Json.Serialization;

using GoogleApi.Entities.Common.Converters;

namespace GoogleApi.Entities.Search.Common.Enums;

/// <summary>
/// Site Search Filter.
/// </summary>
[JsonConverter(typeof(CustomJsonStringEnumConverter))]
public enum SiteSearchFilter
{
    /// <summary>
    /// Include.
    /// </summary>
    [EnumMember(Value = "i")]
    Include,

    /// <summary>
    /// Exclude.
    /// </summary>
    [EnumMember(Value = "e")]
    Exclude
}