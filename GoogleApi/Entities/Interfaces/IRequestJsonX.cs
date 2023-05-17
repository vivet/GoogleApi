namespace GoogleApi.Entities.Interfaces;

/// <summary>
/// Indicates the Request is a Json payload request with X-Goog header values, using http post method.
/// </summary>
public interface IRequestJsonX : IRequestJson
{
    /// <summary>
    /// Field Mask.
    /// Field mask of all available fields (for manual inspection): X-Goog-FieldMask: *.
    /// Field mask of Route-level duration, distance, and polyline (an example production setup): X-Goog-FieldMask: routes.duration,routes.distanceMeters,routes.polyline.encodedPolyline
    /// </summary>
    string FieldMask { get; set; }
}