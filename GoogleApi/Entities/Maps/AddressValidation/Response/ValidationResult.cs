namespace GoogleApi.Entities.Maps.AddressValidation.Response;

/// <summary>
/// Validation Result.
/// The result of validating an address.
/// </summary>
public class ValidationResult
{
    /// <summary>
    /// Verdict.
    /// Overall verdict flags
    /// </summary>
    public virtual Verdict Verdict { get; set; }

    /// <summary>
    /// Address.
    /// Information about the address itself as opposed to the geocode.
    /// </summary>
    public virtual Address Address { get; set; }

    /// <summary>
    /// English Latin Address.
    /// Information about the address itself as opposed to the geocode.
    /// </summary>
    public virtual Address EnglishLatinAddress { get; set; }

    /// <summary>
    /// Geocode.
    /// Information about the location and place that the address geocoded to.
    /// </summary>
    public virtual Geocode Geocode { get; set; }

    /// <summary>
    /// Metadata.
    /// Other information relevant to deliverability.
    /// Metadata is not guaranteed to be fully populated for every address sent to the Address Validation API.
    /// </summary>
    public virtual AddressMetadata Metadata { get; set; }

    /// <summary>
    /// Extra deliverability flags provided by USPS.
    /// Only provided in region US and PR.
    /// </summary>
    public virtual UspsData UspsData { get; set; }
}