namespace GoogleApi.Entities.PlacesNew.Photos.Response;

/// <summary>
/// Places New Photos Skip Http Redirect Response.
/// </summary>
public class PlacesNewPhotosSkipHttpRedirectResponse : BaseResponseX
{
    /// <summary>
    /// A string containing the resource name of the photo.
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// The uri of the photo.
    /// </summary>
    public virtual string PhotoUri { get; set; }
}