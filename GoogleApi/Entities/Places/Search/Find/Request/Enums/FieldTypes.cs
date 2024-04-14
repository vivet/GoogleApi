using System;

namespace GoogleApi.Entities.Places.Search.Find.Request.Enums;

/// <summary>
/// Field Types.
/// </summary>
[Flags]
public enum FieldTypes
{
    /// <summary>
    /// Formatted Address (billing: basic).
    /// </summary>
    Formatted_Address = 1 << 1,

    /// <summary>
    /// Geometry (billing: basic).
    /// </summary>
    Geometry = 1 << 2,

    /// <summary>
    /// Icon (billing: basic).
    /// </summary>
    Icon = 1 << 3,

    /// <summary>
    /// Icon Mask Base Uri (billing: basic).
    /// </summary>
    Icon_Mask_Base_Uri = 1 << 4,

    /// <summary>
    /// Name (billing: basic).
    /// </summary>
    Name = 1 << 5,

    /// <summary>
    /// Photo (billing: basic).
    /// </summary>
    Photo = 1 << 6,

    /// <summary>
    /// Place_Id (billing: basic).
    /// </summary>
    Place_Id = 1 << 7,

    /// <summary>
    /// Plus_Code (billing: basic).
    /// </summary>
    Plus_Code = 1 << 8,

    /// <summary>
    /// Type (billing: basic).
    /// </summary>
    Type = 1 << 9,

    /// <summary>
    /// Opening Hours (billing: contact).
    /// </summary>
    Opening_Hours = 1 << 10,

    /// <summary>
    /// User Ratings Total (billing: atmosphere).
    /// </summary>
    User_Ratings_Total = 1 << 11,

    /// <summary>
    /// Business Status.
    /// </summary>
    Business_Status = 1 << 12,

    /// <summary>
    /// Icon Background Color.
    /// </summary>
    Icon_Background_Color = 1 << 13,

    /// <summary>
    /// Basic (all).
    /// </summary>
    Basic = Business_Status | Formatted_Address | Geometry | Icon | Icon_Mask_Base_Uri | Icon_Background_Color | Name | Photo | Place_Id | Plus_Code | Type,

    /// <summary>
    /// Contact (all).
    /// </summary>
    Contact = Opening_Hours,

    /// <summary>
    /// Atmosphere (all).
    /// </summary>
    Atmosphere = User_Ratings_Total
}