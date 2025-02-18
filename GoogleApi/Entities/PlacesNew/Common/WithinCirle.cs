namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Within Circle.
/// </summary>
public class WithinCirle : BaseWithin
{
    /// <summary>
    /// A circle is defined by center point and radius in meters.
    /// </summary>
    public virtual Circle Circle { get; set; }
}