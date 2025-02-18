using System.Collections.Generic;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.PlacesNew.Common.Enums;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Basic landmark information and the landmark's relationship with the target location.
/// Landmarks are prominent places that can be used to describe a location.
/// </summary>
public class Landmark
{
    /// <summary>
    /// The landmark's resource name.
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// The landmark's place id.
    /// </summary>
    public virtual string PlaceId { get; set; }

    /// <summary>
    /// The landmark's display name.
    /// </summary>
    public virtual LocalizedText DisplayName { get; set; }

    /// <summary>
    /// A set of type tags for this landmark.
    /// For the complete list of possible values, see Table A and Table B at https://developers.google.com/maps/documentation/places/web-service/place-types
    /// </summary>
    public virtual IEnumerable<PlaceLocationTypeAb> Types { get; set; } = new List<PlaceLocationTypeAb>();

    /// <summary>
    /// Defines the spatial relationship between the target location and the landmark.
    /// </summary>
    public virtual SpatialRelationship SpatialRelationship { get; set; }

    /// <summary>
    /// The straight line distance, in meters, between the center point of the target and the center point of the landmark.
    /// In some situations, this value can be longer than travelDistanceMeters.
    /// </summary>
    public virtual double StraightLineDistanceMeters { get; set; }

    /// <summary>
    /// The travel distance, in meters, along the road network from the target to the landmark, if known.
    /// This value does not take into account the mode of transportation, such as walking, driving, or biking.
    /// </summary>
    public virtual double TravelDistanceMeters { get; set; }
}