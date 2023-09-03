using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response.Enums;

/// <summary>
/// The type of vehicles for transit routes.
/// </summary>
public enum TransitVehicleType
{
    /// <summary>
    /// Unused.
    /// </summary>
    [EnumMember(Value = "TRANSIT_VEHICLE_TYPE_UNSPECIFIED")]
    Transit_Vehicle_Type_Unspecified,

    /// <summary>
    /// Bus.
    /// </summary>
    [EnumMember(Value = "BUS")]
    Bus,

    /// <summary>
    /// A vehicle that operates on a cable, usually on the ground. Aerial cable cars may be of the type GONDOLA_LIFT.
    /// </summary>
    [EnumMember(Value = "CABLE_CAR")]
    Cable_Car,

    /// <summary>
    /// Commuter rail.
    /// </summary>
    [EnumMember(Value = "COMMUTER_TRAIN")]
    Commuter_Train,

    /// <summary>
    /// Ferry.
    /// </summary>
    [EnumMember(Value = "FERRY")]
    Ferry,

    /// <summary>
    /// A vehicle that is pulled up a steep incline by a cable. A Funicular typically consists of two cars, with each car acting as a counterweight for the other.
    /// </summary>
    [EnumMember(Value = "FUNICULAR")]
    Funicular,

    /// <summary>
    /// An aerial cable car.
    /// </summary>
    [EnumMember(Value = "GONDOLA_LIFT")]
    Gondola_Lift,

    /// <summary>
    /// Heavy rail.
    /// </summary>
    [EnumMember(Value = "HEAVY_RAIL")]
    Heavy_Rail,

    /// <summary>
    /// High speed train.
    /// </summary>
    [EnumMember(Value = "HIGH_SPEED_TRAIN")]
    High_Speed_Train,

    /// <summary>
    /// Intercity bus.
    /// </summary>
    [EnumMember(Value = "INTERCITY_BUS")]
    Intercity_Bus,

    /// <summary>
    /// Long distance train.
    /// </summary>
    [EnumMember(Value = "LONG_DISTANCE_TRAIN")]
    Long_Distance_Train,

    /// <summary>
    /// Light rail transit.
    /// </summary>
    [EnumMember(Value = "METRO_RAIL")]
    Metro_Rail,

    /// <summary>
    /// Monorail.
    /// </summary>
    [EnumMember(Value = "MONORAIL")]
    Monorail,

    /// <summary>
    /// All other vehicles.
    /// </summary>
    [EnumMember(Value = "OTHER")]
    Other,

    /// <summary>
    /// Rail.
    /// </summary>
    [EnumMember(Value = "RAIL")]
    Rail,

    /// <summary>
    /// Share taxi is a kind of bus with the ability to drop off and pick up passengers anywhere on its route.
    /// </summary>
    [EnumMember(Value = "SHARE_TAXI")]
    Share_Taxi,

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
    /// Trolleybus.
    /// </summary>
    [EnumMember(Value = "TROLLEYBUS")]
    Trolleybus
}