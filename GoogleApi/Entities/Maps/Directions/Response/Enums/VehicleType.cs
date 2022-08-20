using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;

namespace GoogleApi.Entities.Maps.Directions.Response.Enums;

/// <summary>
/// VehicleType.
/// </summary>
[JsonConverter(typeof(CustomJsonStringEnumConverter))]
public enum VehicleType
{
    /// <summary>
    /// All other vehicles will return this type.
    /// </summary>
    [EnumMember(Value = "OTHER")]
    Other,

    /// <summary>
    /// Rail.
    /// </summary>
    [EnumMember(Value = "RAIL")]
    Rail,

    /// <summary>
    /// Light rail transit.
    /// </summary>
    [EnumMember(Value = "METRO_RAIL")]
    MetroRail,

    /// <summary>
    /// Underground light rail.
    /// </summary>
    [EnumMember(Value = "SUBWAY")]
    Subway,

    /// <summary>
    /// Above ground light rail.
    /// </summary>
    [EnumMember(Value = "TRAM")]
    Tram,

    /// <summary>
    /// Monorail.
    /// </summary>
    [EnumMember(Value = "MONORAIL")]
    Monorail,

    /// <summary>
    /// Heavy rail.
    /// </summary>
    [EnumMember(Value = "HEAVY_RAIL")]
    HeavyRail,

    /// <summary>
    /// Commuter Train.
    /// </summary>
    [EnumMember(Value = "COMMUTER_TRAIN")]
    CommuterTrain,

    /// <summary>
    /// High speed train.
    /// </summary>
    [EnumMember(Value = "HIGH_SPEED_TRAIN")]
    HighSpeedTrain,

    /// <summary>
    /// Bus.
    /// </summary>
    [EnumMember(Value = "BUS")]
    Bus,

    /// <summary>
    /// Intercity bus.
    /// </summary>
    [EnumMember(Value = "INTERCITY_BUS")]
    IntercityBus,

    /// <summary>
    /// Trolleybus.
    /// </summary>
    [EnumMember(Value = "TROLLEYBUS")]
    Trolleybus,

    /// <summary>
    /// Share taxi is a kind of bus with the ability to drop off and pick up passengers anywhere on its route.
    /// </summary>
    [EnumMember(Value = "SHARE_TAXI")]
    ShareTaxi,

    /// <summary>
    /// Ferry.
    /// </summary>
    [EnumMember(Value = "FERRY")]
    Ferry,

    /// <summary>
    /// A vehicle that operates on a cable, usually on the ground. Aerial cable cars may be of the type GONDOLA_LIFT.
    /// </summary>
    [EnumMember(Value = "CABLE_CAR")]
    CableCar,

    /// <summary>
    /// An aerial cable car.
    /// </summary>
    [EnumMember(Value = "GONDOLA_LIFT")]
    GondolaLift,

    /// <summary>
    /// A vehicle that is pulled up a steep incline by a cable. A Funicular typically consists of two cars, with each car acting as a counterweight for the other.
    /// </summary>
    [EnumMember(Value = "FUNICULAR")]
    Funicular,

    /// <summary>
    /// Long Distance Train.
    /// </summary>
    [EnumMember(Value = "LONG_DISTANCE_TRAIN")]
    LongDistanceTrain
}