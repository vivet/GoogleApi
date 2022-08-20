using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;

namespace GoogleApi.Entities.Translate.Common.Enums;

/// <summary>
/// The translation model.
/// </summary>

[JsonConverter(typeof(CustomJsonStringEnumConverter))]
public enum Model
{
    /// <summary>
    /// Base, Phrase-Based Machine Translation (PBMT) model
    /// </summary>
    [EnumMember(Value = "base")]
    Base,

    /// <summary>
    /// Nmt, Neural Machine Translation (NMT) model.
    /// </summary>
    [EnumMember(Value = "nmt")]
    Nmt
}