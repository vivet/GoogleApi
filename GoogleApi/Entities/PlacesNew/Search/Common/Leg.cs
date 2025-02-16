namespace GoogleApi.Entities.PlacesNew.Search.Common;

/// <summary>
/// A leg is a single portion of a journey from one location to another.
/// </summary>
public class Leg
{
    /// <summary>
    /// The time it takes to complete this leg of the trip.
    /// A duration in seconds with up to nine fractional digits, ending with 's'. Example: "3.5s".
    /// https://protobuf.dev/reference/protobuf/google.protobuf/#duration
    /// </summary>
    public virtual string Duration { get; set; }

    /// <summary>
    /// The distance of this leg of the trip.
    /// </summary>
    public virtual int DistanceMeters { get; set; }
}