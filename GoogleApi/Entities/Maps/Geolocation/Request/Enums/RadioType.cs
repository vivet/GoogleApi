using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Geolocation.Request.Enums;

/// <summary>
/// Radio Type.
/// </summary>
public enum RadioType
{
    /// <summary>
    /// Lte.
    /// </summary>
    [EnumMember(Value = "lte")]
    Lte,

    /// <summary>
    /// Gsm.
    /// </summary>
    [EnumMember(Value = "gsm")]
    Gsm,

    /// <summary>
    /// Cdma.
    /// </summary>
    [EnumMember(Value = "cdma")]
    Cdma,

    /// <summary>
    /// Wcdma.
    /// </summary>
    [EnumMember(Value = "wcdma")]
    Wcdma
}