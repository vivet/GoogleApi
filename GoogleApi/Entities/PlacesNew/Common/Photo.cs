using System.Collections.Generic;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Photo.
/// </summary>
public class Photo
{
    /// <summary>
    /// Identifier.
    /// A reference representing this place photo which may be used to look up this place photo again
    /// (also called the API "resource" name: places/{placeId}/photos/{photo}).
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// The maximum available width, in pixels.
    /// </summary>
    public virtual int WidthPx { get; set; }

    /// <summary>
    /// The maximum available height, in pixels.
    /// </summary>
    public virtual int HeightPx { get; set; }

    /// <summary>
    /// This photo's authors.
    /// </summary>
    public virtual IEnumerable<AuthorAttribution> AuthorAttributions { get; set; }

    /// <summary>
    /// A link where users can flag a problem with the photo.
    /// </summary>
    public virtual string FlagContentUri { get; set; }

    /// <summary>
    /// A link to show the photo on Google Maps.
    /// </summary>
    public virtual string GoogleMapsUri { get; set; }
}