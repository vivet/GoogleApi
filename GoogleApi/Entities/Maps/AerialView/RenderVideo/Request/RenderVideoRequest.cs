using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities.Maps.AerialView.RenderVideo.Request;

/// <summary>
/// Render Video Request.
/// </summary>
public class RenderVideoRequest : BaseMapsRequest, IRequestJson
{
    /// <inheritdoc />
    protected internal override string BaseUrl => "aerialview.googleapis.com/v1beta/videos:renderVideo";

    /// <summary>
    /// Address.
    /// A US postal address.
    /// </summary>
    public virtual string Address { get; set; }
}