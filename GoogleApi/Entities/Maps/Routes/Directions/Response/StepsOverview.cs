using System.Collections.Generic;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Provides overview information about a list of RouteLegSteps.
/// </summary>
public class StepsOverview
{
    /// <summary>
    /// Summarized information about different multi-modal segments of the RouteLeg.steps.
    /// This field is not populated if the RouteLeg does not contain any multi-modal segments in the steps.
    /// </summary>
    public virtual IEnumerable<MultiModalSegment> MultiModalSegments { get; set; } = new List<MultiModalSegment>();
}