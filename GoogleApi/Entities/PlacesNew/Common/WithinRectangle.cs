using GoogleApi.Entities.PlacesNew.Search.Common;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Within Rectangle.
/// </summary>
public class WithinRectangle : BaseWithin
{
    /// <summary>
    /// Circle.
    /// </summary>
    public virtual Rectangle Circle { get; set; }
}