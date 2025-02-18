using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Text representations of certain properties.
/// </summary>
public class RouteLegStepLocalizedValues
{
    /// <summary>
    /// Travel distance represented in text form.
    /// </summary>
    public virtual LocalizedText Distance { get; set; }

    /// <summary>
    /// Duration without taking traffic conditions into consideration, represented in text form.
    /// </summary>
    public virtual LocalizedText StaticDuration { get; set; }
}