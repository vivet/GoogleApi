using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Maps.AddressValidation.Response.Enums;

namespace GoogleApi.Entities.Maps.AddressValidation.Response;

/// <summary>
/// Address Component.
/// Represents an address component, such as a street, city, or state.
/// </summary>
public class AddressComponent
{
    /// <summary>
    /// Component Name.
    /// </summary>
    public virtual ComponentName ComponentName { get; set; }

    /// <summary>
    /// Type.
    /// The type of the address component.
    /// https://developers.google.com/maps/documentation/places/web-service/supported_types#table2
    /// </summary>
    [JsonPropertyName("componentType")]
    public virtual PlaceLocationType? Type { get; set; }

    /// <summary>
    /// Confirmation Level.
    /// Indicates the level of certainty that we have that the component is correct.
    /// </summary>
    public virtual ConfirmationLevel? ConfirmationLevel { get; set; }

    /// <summary>
    /// Inferred.
    /// Indicates that the component was not part of the input,
    /// but we inferred it for the address location and believe it should be provided for a complete address.
    /// </summary>
    public virtual bool Inferred { get; set; }

    /// <summary>
    /// Spell Corrected.
    /// Indicates the spelling of the component name was corrected in a minor way, for example by switching two characters that appeared in the wrong order.
    /// This indicates a cosmetic change.
    /// </summary>
    public virtual bool SpellCorrected { get; set; }

    /// <summary>
    /// Replaced.
    /// Indicates the name of the component was replaced with a completely different one, for example a wrong postal code being replaced with one that is correct for the address.
    /// This is not a cosmetic change, the input component has been changed to a different one.
    /// </summary>
    public virtual bool Replaced { get; set; }

    /// <summary>
    /// Unexpected.
    /// Indicates an address component that is not expected to be present in a postal address for the given region.
    /// We have retained it only because it was part of the input.
    /// </summary>
    public virtual bool Unexpected { get; set; }
}