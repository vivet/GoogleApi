namespace GoogleApi.Entities.PlacesNew.Search.Text.Response;

/// <summary>
/// Justifications for the place. Justifications answers the question of why a place could interest an end user.
/// Experimental: See https://developers.google.com/maps/documentation/places/web-service/experimental/places-generative for more details.
/// </summary>
public class Justification
{
    /// <summary>
    /// Review Justification.
    /// </summary>
    public virtual ReviewJustification ReviewJustification { get; set; }

    /// <summary>
    /// Business Availability Attributes Justification.
    /// </summary>
    public virtual BusinessAvailabilityAttributesJustification BusinessAvailabilityAttributesJustification { get; set; }
}