namespace GoogleApi.Entities.Interfaces;

/// <summary>
/// Base interface for requests X.
/// </summary>
public interface IRequestX : IRequest
{
    /// <summary>
    /// Field Mask.
    /// Field mask of all available fields (for manual inspection): X-Goog-FieldMask: *.
    /// Field mask of Route-level duration, distance, and polyline (an example production setup): X-Goog-FieldMask: routes.duration,routes.distanceMeters,routes.polyline.encodedPolyline
    /// (Required).
    /// </summary>
    string FieldMask { get; set; }
}