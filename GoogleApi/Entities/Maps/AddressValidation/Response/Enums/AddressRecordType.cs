using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.AddressValidation.Response.Enums;

/// <summary>
/// Address Record Type.
/// Type of the address record that matches the input address.
/// </summary>
public enum AddressRecordType
{
    /// <summary>
    /// F: This is a match to a Firm Record, which is the finest level of match available for an address.
    /// </summary>
    [EnumMember(Value = "F")]
    Firm,

    /// <summary>
    /// G: This is a match to a General Delivery record.
    /// </summary>
    [EnumMember(Value = "G")]
    General_Delivery,

    /// <summary>
    /// H: This is a match to a Building or Apartment record.
    /// </summary>
    [EnumMember(Value = "H")]
    Building_Or_Apartment,

    /// <summary>
    /// P: This is a match to a Post Office Box.
    /// </summary>
    [EnumMember(Value = "P")]
    Post_Office_Box,

    /// <summary>
    /// R: This is a match to either a Rural Route or a Highway Contract record, both of which may have associated Box Number ranges.
    /// </summary>
    [EnumMember(Value = "R")]
    Rural_Route_Or_Highway_Contract,

    /// <summary>
    /// This is a match to a Street record containing a valid primary number range.
    /// </summary>
    [EnumMember(Value = "S")]
    Street_Record
}