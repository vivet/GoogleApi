namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// Attribution.
/// </summary>
public class Attribution
{
    /// <summary>
    /// Name of the Place's data provider.
    /// </summary>
    public virtual string Provider { get; set; }

    /// <summary>
    /// URI to the Place's data provider.
    /// </summary>
    public virtual string ProviderUri { get; set; }
}