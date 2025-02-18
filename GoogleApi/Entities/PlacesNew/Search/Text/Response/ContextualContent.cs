using System.Collections.Generic;
using GoogleApi.Entities.PlacesNew.Common;

namespace GoogleApi.Entities.PlacesNew.Search.Text.Response;

/// <summary>
/// Contextual Content.
/// </summary>
public class ContextualContent
{
    /// <summary>
    /// List of reviews about this place, contexual to the place query.
    /// </summary>
    public virtual IEnumerable<Review> Reviews { get; set; }

    /// <summary>
    /// Information (including references) about photos of this place, contexual to the place query.
    /// </summary>
    public virtual IEnumerable<Photo> Photos { get; set; }

    /// <summary>
    /// Justifications for the place.
    /// Experimental: See https://developers.google.com/maps/documentation/places/web-service/experimental/places-generative for more details.
    /// </summary>
    public virtual IEnumerable<Justification> Justifications { get; set; }
}