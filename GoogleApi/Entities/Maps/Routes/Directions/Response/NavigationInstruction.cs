using GoogleApi.Entities.Maps.Routes.Directions.Response.Enums;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Navigation Instruction.
/// </summary>
public class NavigationInstruction
{
    /// <summary>
    /// Maneuver.
    /// Encapsulates the navigation instructions for the current step (e.g., turn left, merge, straight, etc.).
    /// This field determines which icon to display.
    /// </summary>
    public virtual Maneuver? Maneuver { get; set; }

    /// <summary>
    /// Instructions.
    /// Instructions for navigating this step.
    /// </summary>
    public virtual string Instructions { get; set; }
}