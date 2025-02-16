namespace GoogleApi.Entities.PlacesNew.Search.Text.Response;

/// <summary>
/// This shows some attributes a business has that could interest an end user.
/// Experimental: See https://developers.google.com/maps/documentation/places/web-service/experimental/places-generative for more details.
/// </summary>
public class BusinessAvailabilityAttributesJustification
{
    /// <summary>
    /// If a place provides takeout.
    /// </summary>
    public virtual bool Takeout { get; set; }

    /// <summary>
    /// If a place provides delivery.
    /// </summary>
    public virtual bool Delivery { get; set; }

    /// <summary>
    /// If a place provides dine-in.
    /// </summary>
    public virtual bool DineIn { get; set; }
}