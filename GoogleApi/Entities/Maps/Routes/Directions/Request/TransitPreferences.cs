using GoogleApi.Entities.Maps.Routes.Directions.Request.Enums;

namespace GoogleApi.Entities.Maps.Routes.Directions.Request;

/// <summary>
/// Transit Preferences.
/// Preferences for TRANSIT based routes that influence the route that is returned.
/// </summary>
public class TransitPreferences
{
    /// <summary>
    /// Routing Preference.
    /// Specify preferences for the transit type
    /// </summary>
    public virtual TransitRoutingPreference? RoutingPreference { get; set; }

    /// <summary>
    /// Allowed Travel Modes.
    /// </summary>
    public virtual TransitTravelMode? AllowedTravelModes { get; set; }
}