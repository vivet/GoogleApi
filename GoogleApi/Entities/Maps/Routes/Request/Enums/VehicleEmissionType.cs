using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Routes.Request.Enums;

/// <summary>
/// Vehicle Emission Type.
/// A set of values describing the vehicle's emission type.
/// Applies only to the DRIVE RouteTravelMode.
/// </summary>
public enum VehicleEmissionType
{
    /// <summary>
    /// Gasoline/petrol fueled vehicle.
    /// </summary>
    [EnumMember(Value = "GASOLINE")]
    Gasoline,

    /// <summary>
    /// Electricity powered vehicle.
    /// </summary>
    [EnumMember(Value = "ELECTRIC")]
    Electric,

    /// <summary>
    /// Hybrid fuel (such as gasoline + electric) vehicle.
    /// </summary>
    [EnumMember(Value = "HYBRID")]
    Hybrid,

    /// <summary>
    /// Diesel fueled vehicle.
    /// </summary>
    [EnumMember(Value = "DIESEL")]
    Diesel
}