namespace GoogleApi.Entities.PlacesNew;

/// <summary>
/// Base abstract class for Places new requests.
/// </summary>
public abstract class BasePlacesNewRequest : BaseRequestX
{
    /// <summary>
    /// Base Url.
    /// </summary>
    protected internal override string BaseUrl => "places.googleapis.com/v1/";
}