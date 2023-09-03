using GoogleApi.Entities.Maps.Routes.Common.Enums;
using GoogleApi.Entities.Maps.Routes.Directions.Response.Enums;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// Provides summarized information about different multi-modal segments of the RouteLeg.steps.
/// A multi-modal segment is defined as one or more contiguous RouteLegStep that have the same RouteTravelMode.
/// This field is not populated if the RouteLeg does not contain any multi-modal segments in the steps.
/// </summary>
public class MultiModalSegment
{
    /// <summary>
    /// NavigationInstruction for the multi-modal segment.
    /// </summary>
    public virtual NavigationInstruction NavigationInstruction { get; set; }

    /// <summary>
    /// The travel mode of the multi-modal segment.
    /// </summary>
    public virtual RouteTravelMode TravelMode { get; set; }

    /// <summary>
    /// The corresponding RouteLegStep index that is the start of a multi-modal segment.
    /// </summary>
    public virtual int StepStartIndex { get; set; }

    /// <summary>
    /// The corresponding RouteLegStep index that is the end of a multi-modal segment.
    /// </summary>
    public virtual int StepEndIndex { get; set; }
}