namespace GoogleApi.Entities.Maps.Routes.Directions.Response;

/// <summary>
/// A transit agency that operates a transit line.
/// </summary>
public class TransitAgency
{
    /// <summary>
    /// The name of this transit agency.
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// The transit agency's locale-specific formatted phone number.
    /// </summary>
    public virtual string PhoneNumber { get; set; }

    /// <summary>
    /// The transit agency's URI.
    /// </summary>
    public virtual string Uri { get; set; }
}