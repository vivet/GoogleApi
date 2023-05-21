using System.Collections.Generic;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;

namespace GoogleApi.Entities.Maps.AddressValidation.Response;

/// <summary>
/// Address.
/// Details of the post-processed address.
/// Post-processing includes correcting misspelled parts of the address, replacing incorrect parts, and inferring missing parts.
/// </summary>
public class Address
{
    /// <summary>
    /// Formatted Address.
    /// The post-processed address, formatted as a single-line address following the address formatting rules of the region where the address is located.
    /// </summary>
    public virtual string FormattedAddress { get; set; }

    /// <summary>
    /// Postal Address.
    /// The post-processed address represented as a postal address.
    /// </summary>
    public virtual PostalAddress PostalAddress { get; set; }

    /// <summary>
    /// Address Components.
    /// Unordered list.
    /// The individual address components of the formatted and corrected address, along with validation information.
    /// This provides information on the validation status of the individual components.
    /// Address components are not ordered in a particular way.
    /// Do not make any assumptions on the ordering of the address components in the list.
    /// </summary>
    public virtual IEnumerable<AddressComponent> AddressComponents { get; set; }

    /// <summary>
    /// Missing Component Types.
    /// The types of components that were expected to be present in a correctly formatted mailing address but were not found in the input AND could not be inferred.
    /// Components of this type are not present in formattedAddress, postalAddress, or addressComponents.
    /// An example might be ['street_number', 'route'] for an input like "Boulder, Colorado, 80301, USA".
    /// The list of possible types can be found: https://developers.google.com/maps/documentation/geocoding/requests-geocoding#Types.
    /// </summary>
    public virtual IEnumerable<AddressComponentType> MissingComponentTypes { get; set; }

    /// <summary>
    /// Unconfirmed Component Types.
    /// The types of the components that are present in the addressComponents but could not be confirmed to be correct.
    /// This field is provided for the sake of convenience: its contents are equivalent to iterating through the addressComponents to find the types of all the components
    /// where the confirmationLevel is not CONFIRMED or the inferred flag is not set to true.
    /// The list of possible types can be found: https://developers.google.com/maps/documentation/geocoding/requests-geocoding#Types.
    /// </summary>
    public virtual IEnumerable<AddressComponentType> UnconfirmedComponentTypes { get; set; }

    /// <summary>
    /// Unresolved Tokens.
    /// Any tokens in the input that could not be resolved.
    /// This might be an input that was not recognized as a valid part of an address (for example in an input like "123235253253 Main St, San Francisco, CA, 94105",
    /// the unresolved tokens may look like ["123235253253"] since that does not look like a valid street number.
    /// </summary>
    public virtual IEnumerable<string> UnresolvedTokens { get; set; }
}