namespace GoogleApi.Entities.Maps.AddressValidation.Response;

/// <summary>
/// Address Metadata.
/// The metadata for the address.
/// Metadata is not guaranteed to be fully populated for every address sent to the Address Validation API.
/// </summary>
public class AddressMetadata
{
    /// <summary>
    /// Business.
    /// Indicates that this is the address of a business. If unset, indicates that the value is unknown.
    /// </summary>
    public virtual bool Business { get; set; }

    /// <summary>
    /// PO Box.
    /// Indicates that the address of a PO box. If unset, indicates that the value is unknown
    /// </summary>
    public virtual bool PoBox { get; set; }

    /// <summary>
    /// Residential.
    /// Indicates that this is the address of a residence. If unset, indicates that the value is unknown.
    /// </summary>
    public virtual bool Residential { get; set; }
}