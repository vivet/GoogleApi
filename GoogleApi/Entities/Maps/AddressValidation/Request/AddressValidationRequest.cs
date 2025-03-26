using GoogleApi.Entities.Common;
using GoogleApi.Entities.Interfaces;

namespace GoogleApi.Entities.Maps.AddressValidation.Request;

/// <summary>
/// Routes Matrix Request.
/// </summary>
public class AddressValidationRequest : BaseMapsRequest, IRequestJson
{
    /// <inheritdoc />
    protected internal override string BaseUrl => "addressvalidation.googleapis.com/v1:validateAddress";

    /// <summary>
    /// Required. The address being validated. Unformatted addresses should be submitted via addressLines.
    /// The total length of the fields in this input must not exceed 280 characters. Supported regions can be found here.
    /// The languageCode value in the input address is reserved for future uses and is ignored today.
    /// The validated address result will be populated based on the preferred language for the given address, as identified by the system.
    /// The Address Validation API ignores the values in recipients and organization.Any values in those fields will be discarded and not returned. Please do not set them.
    /// </summary>
    public virtual PostalAddress Address { get; set; }

    /// <summary>
    /// Previous Response Id.
    /// This field must be empty for the first address validation request.
    /// If more requests are necessary to fully validate a single address (for example if the changes the user makes after the initial validation need to be re-validated),
    /// then each followup request must populate this field with the responseId from the very first response in the validation sequence.
    /// </summary>
    public virtual string PreviousResponseId { get; set; }

    /// <summary>
    /// Enable Usps Cass.
    /// Enables USPS CASS compatible mode.
    /// This affects only the google.maps.addressvalidation.v1.ValidationResult.usps_data field of google.maps.addressvalidation.v1.ValidationResult.
    /// Note: for USPS CASS enabled requests for addresses in Puerto Rico, a google.type.PostalAddress.region_code of the address must be provided as "PR",
    /// or an google.type.PostalAddress.administrative_area of the address must be provided as "Puerto Rico" (case-insensitive) or "PR".
    /// It's recommended to use a componentized address, or alternatively specify at least two google.type.PostalAddress.address_lines
    /// where the first line contains the street number and name and the second line contains the city, state, and zip code.
    /// </summary>
    public virtual bool EnableUspsCass { get; set; }

    /// <summary>
    /// Language Options.
    /// </summary>
    public virtual LanguageOptions LanguageOptions { get; set; }

    /// <summary>
    /// Optional.
    /// Session tokens are user-generated strings that track Autocomplete (New) calls as "sessions."
    /// Autocomplete (New) uses session tokens to group the query and place selection phases of a user autocomplete search into a discrete session for billing purposes.
    /// Session tokens are passed into Place Details (New) calls that follow Autocomplete (New) calls. For more information,
    /// see https://developers.google.com/maps/documentation/places/web-service/place-session-tokens.
    /// </summary>
    public virtual string SessionToken { get; set; }
}