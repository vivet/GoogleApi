namespace GoogleApi.Entities.Maps.AerialView.GetVideo.Response;

/// <summary>
/// Uris.
/// Contains all the uris for a given video format.
/// </summary>
public class Uris
{
    /// <summary>
    /// Landscape Uri.
    /// A signed short-lived URI for the media in a landscape orientation.
    /// </summary>
    public virtual string LandscapeUri { get; set; }

    /// <summary>
    /// Portrait Uri.
    /// A signed short-lived URI for the media in a portrait orientation.
    /// </summary>
    public virtual string PortraitUri { get; set; }
}