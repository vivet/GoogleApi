using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.AddressValidation.Response.Enums;

/// <summary>
/// Confirmation Level.
/// </summary>
public enum ConfirmationLevel
{
    /// <summary>
    /// Default value. This value is unused.
    /// </summary>
    [EnumMember(Value = "CONFIRMATION_LEVEL_UNSPECIFIED")]
    ConfirmationLevelUnspecified,

    /// <summary>
    /// We were able to verify that this component exists and makes sense in the context of the rest of the address.
    /// </summary>
    [EnumMember(Value = "CONFIRMED")]
    Confirmed,

    /// <summary>
    /// This component could not be confirmed, but it is plausible that it exists.
    /// For example, a street number within a known valid range of numbers on a street where specific house numbers are not known.
    /// </summary>
    [EnumMember(Value = "UNCONFIRMED_BUT_PLAUSIBLE")]
    UnconfirmedButPlausible,

    /// <summary>
    /// This component was not confirmed and is likely to be wrong.
    /// For example, a neighborhood that does not fit the rest of the address.
    /// </summary>
    [EnumMember(Value = "UNCONFIRMED_AND_SUSPICIOUS")]
    UnconfirmedAndSuspicious
}