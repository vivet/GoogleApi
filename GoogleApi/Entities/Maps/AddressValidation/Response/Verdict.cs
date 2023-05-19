using GoogleApi.Entities.Maps.AddressValidation.Response.Enums;

namespace GoogleApi.Entities.Maps.AddressValidation.Response;

/// <summary>
/// Validation Result.
/// High level overview of the address validation result and geocode.
/// </summary>
public class Verdict
{
    /// <summary>
    /// Input Granularity.
    /// The granularity of the input address. This is the result of parsing the input address and does not give any validation signals. For validation signals, refer to validationGranularity below.
    /// For example, if the input address includes a specific apartment number, then the inputGranularity here will be SUB_PREMISE.If we cannot match the apartment number in the databases or the apartment number is invalid, the validationGranularity will likely be PREMISE or below.
    /// </summary>
    public virtual Granularity? InputGranularity { get; set; }

    /// <summary>
    /// Validation Granularity.
    /// The granularity level that the API can fully validate the address to. For example, an validationGranularity of PREMISE indicates all address components at the level of PREMISE or more coarse can be validated.
    /// Per address component validation result can be found in google.maps.addressvalidation.v1.Address.address_components.
    /// </summary>
    public virtual Granularity? ValidationGranularity { get; set; }

    /// <summary>
    /// Geocode Granularity.
    /// Information about the granularity of the geocode. This can be understood as the semantic meaning of how coarse or fine the geocoded location is.
    /// This can differ from the validationGranularity above occasionally.For example, our database might record the existence of an apartment number but do not have a precise location for the apartment within a big apartment complex.In that case, the validationGranularity will be SUB_PREMISE but the geocodeGranularity will be PREMISE.
    /// </summary>
    public virtual Granularity? GeocodeGranularity { get; set; }

    /// <summary>
    /// Address Complete.
    /// The address is considered complete if there are no unresolved tokens, no unexpected or missing address components.
    /// See missingComponentTypes, unresolvedTokens or unexpected fields for more details.
    /// </summary>
    public virtual bool AddressComplete { get; set; }

    /// <summary>
    /// Has Unconfirmed Components.
    /// At least one address component cannot be categorized or validated,
    /// see google.maps.addressvalidation.v1.Address.address_components for details.
    /// </summary>
    public virtual bool HasUnconfirmedComponents { get; set; }

    /// <summary>
    /// Has Inferred Components.
    /// At least one address component was inferred (added) that wasn't in the input,
    /// see google.maps.addressvalidation.v1.Address.address_components for details.
    /// </summary>
    public virtual bool HasInferredComponents { get; set; }

    /// <summary>
    /// Has Replaced Components.
    /// At least one address component was replaced,
    /// see google.maps.addressvalidation.v1.Address.address_components for details.
    /// </summary>
    public virtual bool HasReplacedComponents { get; set; }
}