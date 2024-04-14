using System;

namespace GoogleApi.Entities.Places.Details.Request.Enums;

/// <summary>
/// Field Types.
/// </summary>
[Flags]
public enum FieldTypes : long
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
    /// Icon Mask Base Uri (billing: basic).
    /// </summary>
    Icon_Mask_Base_Uri = 1 << 6,

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
    /// Price Level (billing: atmosphere)
    /// </summary>
    Price_Level = 1 << 19,

    /// <summary>
    /// Rating (billing: atmosphere).
    /// </summary>
    Rating = 1 << 20,

    /// <summary>
    /// Review (billing: atmosphere).
    /// </summary>
    Review = 1 << 21,

    /// <summary>
    /// User Ratings Total (billing: atmosphere).
    /// </summary>
    User_Ratings_Total = 1 << 22,

    /// <summary>
    /// Business Status.
    /// </summary>
    Business_Status = 1 << 23,

    /// <summary>
    /// Editorial Summary (billing: atmosphere)
    /// </summary>
    Editorial_Summary = 1 << 24,

    /// <summary>
    /// Icon Background Color.
    /// </summary>
    Icon_Background_Color = 1 << 25,

    /// <summary>
    /// Wheelchair Accessible Entrance.
    /// </summary>
    Wheelchair_Accessible_Entrance = 1 << 26,

    /// <summary>
    /// Secondary Opening Hours.
    /// </summary>
    Secondary_Opening_Hours = 1 << 27,

    /// <summary>
    /// Current Opening Hours.
    /// </summary>
    Current_Opening_Hours = 1 << 28,

    /// <summary>
    /// Curbside Pickup.
    /// </summary>
    Curbside_Pickup = 1 << 29,

    /// <summary>
    /// Delivery.
    /// </summary>
    Delivery = 1 << 30,

    /// <summary>
    /// Dine In.
    /// </summary>
    Dine_In = 1 << 31,

    /// <summary>
    /// Reservable.
    /// </summary>
    Reservable = 4294967296,

    /// <summary>
    /// Serves Beer.
    /// </summary>
    Serves_Beer = 8589934592,

    /// <summary>
    /// Serves Breakfast.
    /// </summary>
    Serves_Breakfast = 17179869184,

    /// <summary>
    /// Serves Brunch.
    /// </summary>
    Serves_Brunch = 34359738368,

    /// <summary>
    /// Serves Dinner.
    /// </summary>
    Serves_Dinner = 68719476736,

    /// <summary>
    /// Serves Lunch.
    /// </summary>
    Serves_Lunch = 137438953472,

    /// <summary>
    /// 
    /// </summary>
    Serves_Vegetarian_Food = 274877906944,

    /// <summary>
    /// Serves Wine.
    /// </summary>
    Serves_Wine = 549755813888,

    /// <summary>
    /// Takeout.
    /// </summary>
    Takeout = 1099511627776,

    /// <summary>
    /// Basic (all).
    /// </summary>
    Basic = Address_Component | Adr_Address | Business_Status | Formatted_Address | Geometry | Icon | Icon_Mask_Base_Uri | Icon_Background_Color | Name | Photo | Place_Id | Plus_Code | Type | Url | Utc_Offset | Vicinity | Wheelchair_Accessible_Entrance,

    /// <summary>
    /// Contact (all).
    /// </summary>
    Contact = Current_Opening_Hours | Formatted_Phone_Number | International_Phone_Number | Opening_Hours | Secondary_Opening_Hours | Website,

    /// <summary>
    /// Atmosphere (all).
    /// </summary>
    Atmosphere = Curbside_Pickup | Delivery | Editorial_Summary | Price_Level | Rating | Reservable | Review | Dine_In | User_Ratings_Total | Serves_Beer | Serves_Breakfast | Serves_Brunch | Serves_Dinner | Serves_Lunch | Serves_Vegetarian_Food | Serves_Wine | Takeout
}