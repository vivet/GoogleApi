namespace GoogleApi.Entities.PlacesNew.Search.Text.Request;

/// <summary>
/// Polyline.
/// </summary>
public class Polyline
{
    /// <summary>
    /// An encoded polyline, as returned by the Routes API by default. See the encoder and decoder tools.
    /// </summary>
    public virtual string EncodedPolyline { get; set; }
}