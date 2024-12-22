using System.Collections.Generic;

namespace GoogleApi.Entities.Maps.Geocoding.Common;

/// <summary>
/// Address Descriptor.
/// There are two arrays in each address_descriptor object: landmarks and areas.
/// </summary>
public class AddressDescriptor
{
    /// <summary>
    /// Landmarks.    
    /// The landmarks array contains up to 5 results ranked in order of relevance by taking account of proximity to the requested coordinate,
    /// the prevalence of the landmark and its visibility.
    /// </summary>
    public virtual IEnumerable<Landmark> Landmarks { get; set; }

    /// <summary>
    /// Areas.
    /// The areas object contains up to 3 responses and limits itself to places that represent small regions,
    /// such as neighborhoods, sublocalities, and large complexes.
    /// Areas that contain the requested coordinate are listed first and ordered from smallest to largest.
    /// </summary>
    public virtual IEnumerable<Area> Areas { get; set; }
}