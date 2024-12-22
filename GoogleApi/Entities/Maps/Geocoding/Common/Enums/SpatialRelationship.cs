using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Geocoding.Common.Enums;

/// <summary>
/// The estimated relationship between the input coordinate and the landmarks result.
/// </summary>
public enum SpatialRelationship
{
    /// <summary>
    /// the default relationship when none of the following applies.
    /// </summary>
    [EnumMember(Value = "NEAR")]
    Near,

    /// <summary>
    /// the input coordinate is contained within the bounds of the structure associated with the landmark.
    /// </summary>
    [EnumMember(Value = "WITHIN")]
    Within,

    /// <summary>
    /// the input coordinate is directly adjacent to the landmark or landmark's access point.
    /// </summary>
    [EnumMember(Value = "BESIDE")]
    Beside,

    /// <summary>
    /// the input coordinate is directly opposite of the landmark on the other side of the route.
    /// </summary>
    [EnumMember(Value = "ACROSS_THE_ROAD")]
    AcrossTheRoad,

    /// <summary>
    /// the input coordinate is along the same route as the landmark, but not "BESIDES" or "ACROSS_THE_ROAD".
    /// </summary>
    [EnumMember(Value = "DOWN_THE_ROAD")]
    DownTheRoad,

    /// <summary>
    /// the input coordinate is along a perpendicular route as the landmark (restricted to a single turn)
    /// </summary>
    [EnumMember(Value = "AROUND_THE_CORNER")]
    AroundTheCorner,

    /// <summary>
    /// the input coordinate is spatially close to the landmark, but far from its access point.
    /// </summary>
    [EnumMember(Value = "BEHIND")]
    Behind
}