using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Area information and the area's relationship with the target location.
/// Areas includes precise sublocality, neighborhoods, and large compounds that are useful for describing a location.
/// </summary>
public class Area
{
    /// <summary>
    /// The area's resource name.
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// The area's place id.
    /// </summary>
    public virtual string PlaceId { get; set; }

    /// <summary>
    /// The area's display name.
    /// </summary>
    public virtual LocalizedText DisplayName { get; set; }

    /// <summary>
    /// The area's resource name.
    /// </summary>
    public virtual Containment Containment { get; set; }    
}