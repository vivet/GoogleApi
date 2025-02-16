namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Links to trigger different Google Maps actions.
/// </summary>
public class GoogleMapsLinks
{
    /// <summary>
    /// A link to show the directions to the place.
    /// The link only populates the destination location and uses the default travel mode DRIVE.
    /// </summary>
    public virtual string DirectionsUri { get; set; }

    /// <summary>
    /// A link to show this place.
    /// </summary>
    public virtual string PlaceUri { get; set; }

    /// <summary>
    /// A link to write a review for this place.
    /// This link is currently not supported on Google Maps Mobile and only works on the web version of Google Maps.
    /// </summary>
    public virtual string WriteAReviewUri { get; set; }

    /// <summary>
    /// A link to show reviews of this place.
    /// This link is currently not supported on Google Maps Mobile and only works on the web version of Google Maps.
    /// </summary>
    public virtual string ReviewsUri { get; set; }

    /// <summary>
    /// A link to show photos of this place.
    /// This link is currently not supported on Google Maps Mobile and only works on the web version of Google Maps.
    /// </summary>
    public virtual string PhotosUri { get; set; }
}