namespace GoogleApi.Entities.Maps.AddressValidation.Response;

/// <summary>
/// Usps Address.
/// USPS representation of a US address.
/// </summary>
public class UspsAddress
{
    /// <summary>
    /// First address line.
    /// </summary>
    public virtual string FirstAddressLine { get; set; }

    /// <summary>
    /// Firm name.
    /// </summary>
    public virtual string Firm { get; set; }

    /// <summary>
    /// Second address line.
    /// </summary>
    public virtual string SecondAddressLine { get; set; }

    /// <summary>
    /// Puerto Rican urbanization name.
    /// </summary>
    public virtual string Urbanization { get; set; }

    /// <summary>
    /// City + state + postal code.
    /// </summary>
    public virtual string CityStateZipAddressLine { get; set; }

    /// <summary>
    /// City name.
    /// </summary>
    public virtual string City { get; set; }

    /// <summary>
    /// 2 letter state code.
    /// </summary>
    public virtual string State { get; set; }

    /// <summary>
    /// Postal code e.g. 10009.
    /// </summary>
    public virtual string ZipCode { get; set; }

    /// <summary>
    /// 4-digit postal code extension e.g. 5023.
    /// </summary>
    public virtual string ZipCodeExtension { get; set; }
}