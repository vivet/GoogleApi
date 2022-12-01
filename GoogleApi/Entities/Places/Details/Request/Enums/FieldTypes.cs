using System;

namespace GoogleApi.Entities.Places.Details.Request.Enums;

/// <summary>
/// Field Types.
/// </summary>
[Flags]
public enum FieldTypes
{
    /// <summary>
    /// Address Component (billing: basic).
    /// </summary>
    Address_Component = 1 << 1,

    /// <summary>
    /// Adr Address (billing: basic).
    /// </summary>
    Adr_Address = 1 << 2,

    /// <summary>
    /// Formatted Address (billing: basic).
    /// </summary>
    Formatted_Address = 1 << 3,

    /// <summary>
    /// Geometry (billing: basic).
    /// </summary>
    Geometry = 1 << 4,

    /// <summary>
    /// Icon (billing: basic).
    /// </summary>
    Icon = 1 << 5,

    /// <summary>
    /// Id (billing: basic).
    /// </summary>
    Id = 1 << 6,

    /// <summary>
    /// Name (billing: basic).
    /// </summary>
    Name = 1 << 7,

    /// <summary>
    /// Photo (billing: basic).
    /// </summary>
    Photo = 1 << 8,

    /// <summary>
    /// Place_Id (billing: basic).
    /// </summary>
    Place_Id = 1 << 9,

    /// <summary>
    /// Plus_Code (billing: basic).
    /// </summary>
    Plus_Code = 1 << 10,

    /// <summary>
    /// Type (billing: basic).
    /// </summary>
    Type = 1 << 11,

    /// <summary>
    /// Url (billing: basic).
    /// </summary>
    Url = 1 << 12,

    /// <summary>
    /// Utc Offset (billing: basic).
    /// </summary>
    Utc_Offset = 1 << 13,

    /// <summary>
    /// Vicinity (billing: basic).
    /// </summary>
    Vicinity = 1 << 14,

    /// <summary>
    /// Formatted Phone Number (billing: contact).
    /// </summary>
    Formatted_Phone_Number = 1 << 15,

    /// <summary>
    /// International Phone Number (billing: contact).
    /// </summary>
    International_Phone_Number = 1 << 16,

    /// <summary>
    /// Opening Hours (billing: contact).
    /// </summary>
    Opening_Hours = 1 << 17,

    /// <summary>
    /// Website (billing: contact).
    /// </summary>
    Website = 1 << 18,

    /// <summary>
    /// Editorial Summary (billing: atmosphere)
    /// </summary>
    Editorial_Summary = 1 << 19,
    
    /// <summary>
    /// Price Level (billing: atmosphere)
    /// </summary>
    Price_Level = 1 << 20,

    /// <summary>
    /// Rating (billing: atmosphere).
    /// </summary>
    Rating = 1 << 21,

    /// <summary>
    /// Review (billing: atmosphere).
    /// </summary>
    Review = 1 << 22,

    /// <summary>
    /// User Ratings Total (billing: atmosphere).
    /// </summary>
    User_Ratings_Total = 1 << 23,

    /// <summary>
    /// Business Status.
    /// </summary>
    Business_Status = 1 << 24,

    /// <summary>
    /// Basic (all).
    /// </summary>
    Basic = Address_Component| Adr_Address | Formatted_Address | Geometry | Icon | Id | Name | Photo | Place_Id | Plus_Code | Type | Url | Utc_Offset | Vicinity | Business_Status,

    /// <summary>
    /// Contact (all).
    /// </summary>
    Contact = Formatted_Phone_Number | International_Phone_Number | Website | Opening_Hours,

    /// <summary>
    /// Atmosphere (all).
    /// </summary>
    Atmosphere = Editorial_Summary | Price_Level | Rating | User_Ratings_Total | Review
}
