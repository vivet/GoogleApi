using System;

namespace GoogleApi.Entities.Places.Details.Request.Enums
{
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
        /// Alt Id (billing: basic).
        /// </summary>
        Alt_Id = 1 << 3,

        /// <summary>
        /// Formatted Address (billing: basic).
        /// </summary>
        Formatted_Address = 1 << 4,

        /// <summary>
        /// Geometry (billing: basic).
        /// </summary>
        Geometry = 1 << 5,

        /// <summary>
        /// Icon (billing: basic).
        /// </summary>
        Icon = 1 << 6,

        /// <summary>
        /// Id (billing: basic).
        /// </summary>
        Id = 1 << 7,

        /// <summary>
        /// Name (billing: basic).
        /// </summary>
        Name = 1 << 8,

        /// <summary>
        /// Permanently Closed (billing: basic).
        /// </summary>
        Permanently_Closed = 1 << 9,

        /// <summary>
        /// Photo (billing: basic).
        /// </summary>
        Photo = 1 << 10,

        /// <summary>
        /// Place_Id (billing: basic).
        /// </summary>
        Place_Id = 1 << 11,

        /// <summary>
        /// Plus_Code (billing: basic).
        /// </summary>
        Plus_Code = 1 << 12,

        /// <summary>
        /// Scope (billing: basic).
        /// </summary>
        Scope = 1 << 13,

        /// <summary>
        /// Type (billing: basic).
        /// </summary>
        Type = 1 << 14,

        /// <summary>
        /// Url (billing: basic).
        /// </summary>
        Url = 1 << 15,

        /// <summary>
        /// Utc Offset (billing: basic).
        /// </summary>
        Utc_Offset = 1 << 16,

        /// <summary>
        /// Vicinity (billing: basic).
        /// </summary>
        Vicinity = 1 << 17,

        /// <summary>
        /// Formatted Phone Number (billing: contact).
        /// </summary>
        Formatted_Phone_Number = 1 << 18,

        /// <summary>
        /// International Phone Number (billing: contact).
        /// </summary>
        International_Phone_Number = 1 << 19,

        /// <summary>
        /// Opening Hours (billing: contact).
        /// </summary>
        Opening_Hours = 1 << 20,

        /// <summary>
        /// Website (billing: contact).
        /// </summary>
        Website = 1 << 21,

        /// <summary>
        /// Price Level (billing: atmosphere)
        /// </summary>
        Price_Level = 1 << 22,

        /// <summary>
        /// Rating (billing: atmosphere).
        /// </summary>
        Rating = 1 << 23,

        /// <summary>
        /// Review (billing: atmosphere).
        /// </summary>
        Review = 1 << 24,

        /// <summary>
        /// User Ratings Total (billing: atmosphere).
        /// </summary>
        User_Ratings_Total = 1 << 25,

        /// <summary>
        /// Basic (all).
        /// </summary>
        Basic = Address_Component| Adr_Address | Alt_Id | Formatted_Address | Geometry | Icon | Id | Name | Permanently_Closed | Photo | Place_Id | Plus_Code | Scope | Type | Url | Utc_Offset | Vicinity,

        /// <summary>
        /// Contact (all).
        /// </summary>
        Contact = Formatted_Phone_Number | International_Phone_Number | Website | Opening_Hours,

        /// <summary>
        /// Atmosphere (all).
        /// </summary>
        Atmosphere = Price_Level | Rating | User_Ratings_Total | Review
    }
}