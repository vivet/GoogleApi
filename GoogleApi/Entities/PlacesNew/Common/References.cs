using System.Collections.Generic;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Reference that the generative content is related to.
/// Experimental: See https://developers.google.com/maps/documentation/places/web-service/experimental/places-generative for more details.
/// </summary>
public class References
{
    /// <summary>
    /// Reviews that serve as references.
    /// </summary>
    public virtual IEnumerable<Review> Reviews { get; set; }

    /// <summary>
    /// The list of resource names of the referenced places.
    /// This name can be used in other APIs that accept Place resource names.
    /// </summary>
    public virtual IEnumerable<string> Places { get; set; }
}