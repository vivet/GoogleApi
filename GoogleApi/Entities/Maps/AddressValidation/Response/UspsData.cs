using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.Maps.AddressValidation.Response.Enums;

namespace GoogleApi.Entities.Maps.AddressValidation.Response;

/// <summary>
/// Usps Data.
/// The USPS data for the address.
/// UspsData is not guaranteed to be fully populated for every US or PR address sent to the Address Validation API.
/// It's recommended to integrate the backup address fields in the response if you utilize uspsData as the primary part of the response.
/// </summary>
public class UspsData
{
    /// <summary>
    /// Address.
    /// USPS standardized address.
    /// </summary>
    [JsonPropertyName("standardizedAddress")]
    public virtual UspsAddress Address { get; set; }

    /// <summary>
    /// Delivery Point Code.
    /// 2 digit delivery point code.
    /// </summary>
    public virtual string DeliveryPointCode { get; set; }

    /// <summary>
    /// Delivery Point Check Digit.
    /// The delivery point check digit.
    /// This number is added to the end of the delivery_point_barcode for mechanically scanned mail.
    /// Adding all the digits of the delivery_point_barcode, deliveryPointCheckDigit, postal code, and ZIP+4 together should yield a number divisible by 10.
    /// </summary>
    public virtual string DeliveryPointCheckDigit { get; set; }

    /// <summary>
    /// Dpv Confirmation.
    /// The possible values for DPV confirmation.
    /// Returns a single character.
    /// Y: Address was DPV confirmed for primary and any secondary numbers.
    /// N: Primary and any secondary number information failed to DPV confirm.
    /// S: Address was DPV confirmed for the primary number only, and the secondary number information was present by not confirmed.
    /// D: Address was DPV confirmed for the primary number only, and the secondary number information was missing.
    /// </summary>
    public virtual string DpvConfirmation { get; set; }

    /// <summary>
    /// Dpv Footnote.
    /// The footnotes from delivery point validation.
    /// Multiple footnotes may be strung together in the same string.
    /// AA: Input address matched to the ZIP+4 file
    /// A1: Input address was not matched to the ZIP+4 file
    /// BB: Matched to DPV(all components)
    /// CC: Secondary number not matched(present but invalid)
    /// N1: High-rise address missing secondary number
    /// M1: Primary number missing
    /// M3: Primary number invalid
    /// P1: Input address RR or HC box number missing
    /// P3: Input address PO, RR, or HC Box number invalid
    /// F1: Input address matched to a military address
    /// G1: Input address matched to a general delivery address
    /// U1: Input address matched to a unique ZIP code
    /// PB: Input address matched to PBSA record
    /// RR: DPV confirmed address with PMB information
    /// R1: DPV confirmed address without PMB information
    /// R7: Carrier Route R777 or R779 record
    /// </summary>
    public virtual string DpvFootnote { get; set; }

    /// <summary>
    /// Dpv Cmra.
    /// Indicates if the address is a CMRA (Commercial Mail Receiving Agency)--a private business receiving mail for clients. Returns a single character.
    /// Y: The address is a CMRA
    /// N: The address is not a CMRA
    /// </summary>
    [JsonConverter(typeof(StringBooleanZeroOneJsonConverter))]
    public virtual bool DpvCmra { get; set; }

    /// <summary>
    /// Dpv Vacant.
    /// Is this place vacant? Returns a single character.
    /// Y: The address is vacant
    /// N: The address is not vacant
    /// </summary>
    [JsonConverter(typeof(StringBooleanZeroOneJsonConverter))]
    public virtual bool DpvVacant { get; set; }

    /// <summary>
    /// Dpv No Stat.
    /// Is this a no stat address or an active address? No stat addresses are ones which are not continuously occupied or addresses that the USPS does not service.
    /// Returns a single character.
    /// Y: The address is not active
    /// N: The address is active
    /// </summary>
    [JsonConverter(typeof(StringBooleanZeroOneJsonConverter))]
    public virtual bool DpvNoStat { get; set; }

    /// <summary>
    /// Carrier Route.
    /// The carrier route code. A four character code consisting of a one letter prefix and a three digit route designator.
    /// Prefixes:
    /// C: Carrier route(or city route)
    /// R: Rural route
    /// H: Highway Contract Route
    /// B: Post Office Box Section
    /// G: General delivery unit
    /// </summary>
    public virtual string CarrierRoute { get; set; }

    /// <summary>
    /// Carrier Route Indicator.
    /// Carrier route rate sort indicator.
    /// </summary>
    public virtual string CarrierRouteIndicator { get; set; }

    /// <summary>
    /// Ews No Match.
    /// The delivery address is matchable, but the EWS file indicates that an exact match will be available soon.
    /// </summary>
    public virtual bool EwsNoMatch { get; set; }

    /// <summary>
    /// Post Office City.
    /// Main post office city.
    /// </summary>
    public virtual string PostOfficeCity { get; set; }

    /// <summary>
    /// Main post office state.
    /// </summary>
    public virtual string PostOfficeState { get; set; }

    /// <summary>
    /// Abbreviated city.
    /// </summary>
    public virtual string AbbreviatedCity { get; set; }

    /// <summary>
    /// FIPS county code.
    /// </summary>
    public virtual string FipsCountyCode { get; set; }

    /// <summary>
    /// County.
    /// County name.
    /// </summary>
    public virtual string County { get; set; }

    /// <summary>
    /// Elot Number
    /// Enhanced Line of Travel (eLOT) number.
    /// </summary>
    public virtual string ElotNumber { get; set; }

    /// <summary>
    /// Elot Flag
    /// eLOT Ascending/Descending Flag (A/D).
    /// </summary>
    public virtual ElotFlagType? ElotFlag { get; set; }

    /// <summary>
    /// LACSLink Return Code.
    /// </summary>
    public virtual string LacsLinkReturnCode { get; set; }

    /// <summary>
    /// LACSLink Indicator.
    /// </summary>
    public virtual string LacsLinkIndicator { get; set; }

    /// <summary>
    /// PO Box Only Postal Code.
    /// </summary>
    public virtual bool PoBoxOnlyPostalCode { get; set; }

    /// <summary>
    /// Suitelink Footnote.
    /// Footnotes from matching a street or highrise record to suite information. If business name match is found, the secondary number is returned.
    /// A: SuiteLink record match, business address improved.
    /// 00: No match, business address is not improved.
    /// </summary>
    public virtual string SuitelinkFootnote { get; set; }

    /// <summary>
    /// Pmb Designator.
    /// PMB (Private Mail Box) unit designator.
    /// </summary>
    public virtual string PmbDesignator { get; set; }

    /// <summary>
    /// Pmb Number.
    /// PMB (Private Mail Box) number
    /// </summary>
    public virtual string PmbNumber { get; set; }

    /// <summary>
    /// Address Record Type.
    /// Type of the address record that matches the input address.
    /// </summary>
    public virtual AddressRecordType? AddressRecordType { get; set; }

    /// <summary>
    /// Default Address.
    /// Indicator that a default address was found, but more specific addresses exists.
    /// </summary>
    public virtual bool DefaultAddress { get; set; }

    /// <summary>
    /// Error Message.
    /// Error message for USPS data retrieval.
    /// This is populated when USPS processing is suspended because of the detection of artificially created addresses.
    /// The USPS data fields might not be populated when this error is present.
    /// </summary>
    public virtual string ErrorMessage { get; set; }

    /// <summary>
    /// Cass Processed.
    /// Indicator that the request has been CASS processed.
    /// </summary>
    public virtual bool CassProcessed { get; set; }
}