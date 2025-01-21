using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Routes.Directions.Request.Enums;

/// <summary>
/// Transit Travel Mode.
/// Specifies routing preferences for transit routes.
/// </summary>
public enum TransitTravelMode
{
    /// <summary>
    /// No transit travel mode specified.
    /// </summary>
    [EnumMember(Value = "TRANSIT_TRAVEL_MODE_UNSPECIFIED")]
    TRANSIT_TRAVEL_MODE_UNSPECIFIED,

    /// <summary>
    /// Travel by bus.
    /// </summary>
    [EnumMember(Value = "BUS")]
    BUS,

    /// <summary>
    /// Travel by subway.
    /// </summary>
    [EnumMember(Value = "SUBWAY")]
    SUBWAY,

    /// <summary>
    /// Travel by train.
    /// </summary>
    [EnumMember(Value = "TRAIN")]
    TRAIN,

    /// <summary>
    /// Travel by light rail or tram.
    /// </summary>
    [EnumMember(Value = "LIGHT_RAIL")]
    LIGHT_RAIL,

    /// <summary>
    /// Travel by rail. This is equivalent to a combination of SUBWAY, TRAIN, and LIGHT_RAIL.
    /// </summary>
    [EnumMember(Value = "RAIL")]
    RAIL
}