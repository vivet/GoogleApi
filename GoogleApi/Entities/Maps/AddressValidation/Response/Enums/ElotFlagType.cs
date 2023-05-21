using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.AddressValidation.Response.Enums;

/// <summary>
/// Elot Flag Type.
/// </summary>
public enum ElotFlagType
{
    /// <summary>
    /// Ascending.
    /// </summary>
    [EnumMember(Value = "A")]
    Ascending,

    /// <summary>
    /// Descending.
    /// </summary>
    [EnumMember(Value = "D")]
    Descending
}