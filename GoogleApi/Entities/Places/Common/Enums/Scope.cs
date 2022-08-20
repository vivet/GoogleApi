using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;

namespace GoogleApi.Entities.Places.Common.Enums;

/// <summary>
/// Scope.
/// </summary>
[JsonConverter(typeof(CustomJsonStringEnumConverter))]
public enum Scope
{
    /// <summary>
    /// The place ID is recognised by your application only.
    /// This is because your application added the place, and the place has not yet passed the moderation process.
    /// </summary>
    [EnumMember(Value = "APP")]
    App,

    /// <summary>
    /// The place ID is available to other applications and on Google Maps
    /// </summary>
    [EnumMember(Value = "GOOGLE")]
    Google
}