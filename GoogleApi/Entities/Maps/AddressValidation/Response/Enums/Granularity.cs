using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.AddressValidation.Response.Enums;

/// <summary>
/// Granularity.
/// The various granularities that an address or a geocode can have.
/// When used to indicate granularity for an address, these values indicate with how fine a granularity the address identifies a mailing destination.
/// For example, an address such as "123 Main Street, Redwood City, CA, 94061" identifies a PREMISE while something like "Redwood City, CA, 94061" identifies a LOCALITY.
/// However, if we are unable to find a geocode for "123 Main Street" in Redwood City,
/// the geocode returned might be of LOCALITY granularity even though the address is more granular.
/// </summary>
public enum Granularity
{
    /// <summary>
    /// Default value. This value is unused.
    /// </summary>
    [EnumMember(Value = "GRANULARITY_UNSPECIFIED")]
    Granularity_Unspecified,

    /// <summary>
    /// Below-building level result, such as an apartment.
    /// </summary>
    [EnumMember(Value = "SUB_PREMISE")]
    Sub_Premise,

    /// <summary>
    /// Building-level result.
    /// </summary>
    [EnumMember(Value = "PREMISE")]
    Premise,

    /// <summary>
    /// A geocode that approximates the building-level location of the address.
    /// </summary>
    [EnumMember(Value = "PREMISE_PROXIMITY")]
    Premise_Proximity,

    /// <summary>
    /// The address or geocode indicates a block. Only used in regions which have block-level addressing, such as Japan.
    /// </summary>
    [EnumMember(Value = "BLOCK")]
    Block,

    /// <summary>
    /// The geocode or address is granular to route, such as a street, road, or highway.
    /// </summary>
    [EnumMember(Value = "ROUTE")]
    Route,

    /// <summary>
    /// All other granularities, which are bucketed together since they are not deliverable.
    /// </summary>
    [EnumMember(Value = "OTHER")]
    Other
}