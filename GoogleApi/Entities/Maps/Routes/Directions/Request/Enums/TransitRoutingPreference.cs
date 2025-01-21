using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Routes.Directions.Request.Enums;

/// <summary>
/// Transit Routing Preference.
/// A set of values used to specify the mode of transit.
/// </summary>
public enum TransitRoutingPreference
{
    /// <summary>
    /// No preference specified.
    /// </summary>
    [EnumMember(Value = "TRANSIT_ROUTING_PREFERENCE_UNSPECIFIED")]
    TRANSIT_ROUTING_PREFERENCE_UNSPECIFIED,

    /// <summary>
    /// Indicates that the calculated route should prefer limited amounts of walking.
    /// </summary>
    [EnumMember(Value = "LESS_WALKING")]
    LESS_WALKING,

    /// <summary>
    /// Indicates that the calculated route should prefer a limited number of transfers
    /// </summary>
    [EnumMember(Value = "FEWER_TRANSFERS")]
    FEWER_TRANSFERS
}