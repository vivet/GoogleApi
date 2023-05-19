using System.Collections.Generic;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums;

namespace GoogleApi.Entities.Common;

/// <summary>
/// Postal Address.
/// Represents a postal address, e.g. for postal delivery or payments addresses.
/// Given a postal address, a postal service can deliver items to a premise, P.O. Box or similar.
/// It is not intended to model geographical locations (roads, towns, mountains).
/// In typical usage an address would be created via user input or from importing existing data, depending on the type of process.
/// </summary>
public class PostalAddress
{
    /// <summary>
    /// The schema revision of the PostalAddress.
    /// Any value other than 0 will cause the API to return an INVALID_ARGUMENT error.
    /// </summary>
    public virtual int Revision { get; set; } = 0;

    /// <summary>
    /// Optional. CLDR region code of the country/region of the address.
    /// See https://cldr.unicode.org/ and https://www.unicode.org/cldr/charts/30/supplemental/territory_information.html for details.
    /// Example: "CH" for Switzerland. If the region code is not provided, it will be inferred from the address.
    /// For best performance, it is recommended to include the region code if you know it.
    /// Having inconsistent or repeated regions can lead to poor performance, for example, if the addressLines already includes the region,
    /// do not provide the region code again in this field. Supported regions can be found in the FAQ.
    /// </summary>
    public virtual string RegionCode { get; set; }

    /// <summary>
    /// The language code in the input address is reserved for future uses and is ignored today.
    /// The API returns the address in the appropriate language for where the address is located.
    /// </summary>
    [JsonPropertyName("languageCode")]
    public virtual Language Language { get; set; } = Language.English;

    /// <summary>
    /// Postal Code (optional).
    /// Postal code of the address.
    /// Not all countries use or require postal codes to be present,
    /// but where they are used, they may trigger additional validation with other parts of the address (e.g. state/zip validation in the U.S.A.).
    /// </summary>
    public virtual string PostalCode { get; set; }

    /// <summary>
    /// Sorting Code (optional).
    /// Additional, country-specific, sorting code.
    /// This is not used in most regions. Where it is used, the value is either a string like "CEDEX",
    /// optionally followed by a number (e.g. "CEDEX 7"), or just a number alone,
    /// representing the "sector code" (Jamaica), "delivery area indicator" (Malawi) or "post office indicator" (e.g. Côte d'Ivoire).
    /// </summary>
    public virtual string SortingCode { get; set; }

    /// <summary>
    /// Administrative Area (optional).
    /// Highest administrative subdivision which is used for postal addresses of a country or region. For example, this can be a state, a province, an oblast, or a prefecture.
    /// Specifically, for Spain this is the province and not the autonomous community (e.g. "Barcelona" and not "Catalonia").
    /// Many countries don't use an administrative area in postal addresses. E.g. in Switzerland this should be left unpopulated.
    /// </summary>
    public virtual string AdministrativeArea { get; set; }

    /// <summary>
    /// Locality (optional).
    /// Generally refers to the city/town portion of the address.
    /// Examples: US city, IT comune, UK post town. In regions of the world where localities are not well defined or do not fit into this structure well,
    /// leave locality empty and use addressLines.
    /// </summary>
    public virtual string Locality { get; set; }

    /// <summary>
    /// Sub Locality (optional).
    /// Sublocality of the address. For example, this can be neighborhoods, boroughs, districts.
    /// </summary>
    [JsonPropertyName("sublocality")]
    public virtual string SubLocality { get; set; }

    /// <summary>
    /// Address Lines (required).
    /// Unstructured address lines describing the lower levels of an address.
    /// Because values in addressLines do not have type information and may sometimes contain multiple values in a single field(e.g. "Austin, TX"), it is important that the line order is clear.The order of address lines should be "envelope order" for the country/region of the address.
    /// The minimum permitted structural representation of an address consists of all information placed in the addressLines. If a regionCode is not provided, the region is inferred from the address lines.
    /// Creating an address only containing addressLines, and then geocoding is the recommended way to handle completely unstructured addresses (as opposed to guessing which parts of the address should be localities or administrative areas).
    /// </summary>
    public virtual IEnumerable<string> AddressLines { get; set; }

    /// <summary>
    /// Recipients.
    /// Please avoid setting this field.
    /// The Address Validation API does not currently use it.
    /// Although at this time the API will not reject requests with this field set, the information will be discarded and will not be returned in the response
    /// </summary>
    public virtual IEnumerable<string> Recipients { get; set; }

    /// <summary>
    /// Organization.
    /// Please avoid setting this field.
    /// The Address Validation API does not currently use it.
    /// Although at this time the API will not reject requests with this field set, the information will be discarded and will not be returned in the response.
    /// </summary>
    public virtual string Organization { get; set; }
}