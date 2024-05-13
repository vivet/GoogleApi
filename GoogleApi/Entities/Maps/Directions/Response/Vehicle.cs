using System.Text.Json.Serialization;
using GoogleApi.Entities.Maps.Directions.Response.Enums;

namespace GoogleApi.Entities.Maps.Directions.Response;

/// <summary>
/// Vehicle
/// </summary>
public class Vehicle
{
    /// <summary>
    /// Contains the name of the vehicle on this line. eg. "Subway."
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// Contains the URL for an icon associated with this vehicle type.
    /// </summary>
    public virtual string Icon { get; set; }

    /// <summary>
    /// Contains the type of vehicle that runs on this line.
    /// </summary>
    [JsonPropertyName("type")]
    public virtual VehicleType VehicleType { get; set; }
}