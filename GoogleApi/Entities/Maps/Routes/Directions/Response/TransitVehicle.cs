using GoogleApi.Entities.Common;
using GoogleApi.Entities.Maps.Routes.Directions.Response.Enums;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Information about a vehicle used in transit routes.
/// </summary>
public class TransitVehicle
{
    /// <summary>
    /// The name of this vehicle, capitalized.
    /// </summary>
    public virtual LocalizedText Name { get; set; }

    /// <summary>
    /// The type of vehicle used.
    /// </summary>
    public virtual TransitVehicleType Type { get; set; }

    /// <summary>
    /// The URI for an icon associated with this vehicle type.
    /// </summary>
    public virtual string IconUri { get; set; }

    /// <summary>
    /// The URI for the icon associated with this vehicle type,
    /// based on the local transport signage.
    /// </summary>
    public virtual string LocalIconUri { get; set; }
}