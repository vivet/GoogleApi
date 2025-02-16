using System.Collections.Generic;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// A relational description of a location.
/// Includes a ranked set of nearby landmarks and precise containing areas and their relationship to the target location.
/// </summary>
public class AddressDescriptor
{
    /// <summary>
    /// A ranked list of nearby landmarks.
    /// The most recognizable and nearby landmarks are ranked first.
    /// </summary>
    public virtual IEnumerable<Landmark> Landmarks { get; set; }

    /// <summary>
    /// A ranked list of containing or adjacent areas.
    /// The most recognizable and precise areas are ranked first.
    /// </summary>
    public virtual IEnumerable<Area> Areas { get; set; }
}