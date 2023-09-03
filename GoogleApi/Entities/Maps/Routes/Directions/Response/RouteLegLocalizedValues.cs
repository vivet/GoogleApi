using GoogleApi.Entities.Maps.Routes.Common;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Text representations of certain properties.
/// </summary>
public class RouteLegLocalizedValues
{
    /// <summary>
    /// Travel distance represented in text form.
    /// </summary>
    public virtual LocalizedText Distance { get; set; }

    /// <summary>
    /// Duration taking traffic conditions into consideration, represented in text form.
    /// If you did not request traffic information, this value will be the same value as staticDuration.
    /// </summary>
    public virtual LocalizedText Duration { get; set; }

    /// <summary>
    /// Duration without taking traffic conditions into consideration, represented in text form.
    /// </summary>
    public virtual LocalizedText StaticDuration { get; set; }
}