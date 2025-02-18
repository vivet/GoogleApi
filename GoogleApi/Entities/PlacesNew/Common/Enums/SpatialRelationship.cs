namespace GoogleApi.Entities.PlacesNew.Common.Enums;

/// <summary>
/// Defines the spatial relationship between the target location and the landmark.
/// </summary>
public enum SpatialRelationship
{
    /// <summary>
    /// This is the default relationship when nothing more specific below applies.
    /// </summary>
    NEAR,

    /// <summary>
    /// The landmark has a spatial geometry and the target is within its bounds.
    /// </summary>
    WITHIN,

    /// <summary>
    /// The target is directly adjacent to the landmark.
    /// </summary>
    BESIDE,

    /// <summary>
    /// The target is directly opposite the landmark on the other side of the road.
    /// </summary>
    ACROSS_THE_ROAD,

    /// <summary>
    /// On the same route as the landmark but not besides or across.
    /// </summary>
    DOWN_THE_ROAD,

    /// <summary>
    /// Not on the same route as the landmark but a single turn away.
    /// </summary>
    AROUND_THE_CORNER,

    /// <summary>
    /// Close to the landmark's structure but further away from its street entrances.
    /// </summary>
    BEHIND
}