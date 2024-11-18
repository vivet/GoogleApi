using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.Common.Enums;

/// <summary>
/// A type string used to identify the type of secondary hours.
/// For example, DRIVE_THROUGH, HAPPY_HOUR, DELIVERY, TAKEOUT, KITCHEN, BREAKFAST, LUNCH, DINNER, BRUNCH, PICKUP, SENIOR_HOURS.
/// Set for secondary_opening_hours only
/// </summary>
public enum OpeningHoursType
{
    /// <summary>
    /// The access hours for storage places.
    /// </summary>
    [EnumMember(Value = "ACCESS")]
    Access,

    /// <summary>
    /// Breakfast.
    /// </summary>
    [EnumMember(Value = "BREAKFAST")]
    Breakfast,

    /// <summary>
    /// Brunch.
    /// </summary>
    [EnumMember(Value = "BRUNCH")]
    Brunch,

    /// <summary>
    /// Delivery.
    /// </summary>
    [EnumMember(Value = "DELIVERY")]
    Delivery,

    /// <summary>
    /// Dinner.
    /// </summary>
    [EnumMember(Value = "DINNER")]
    Dinner,

    /// <summary>
    /// Drive Through.
    /// </summary>
    [EnumMember(Value = "DRIVE_THROUGH")]
    Drive_Through,

    /// <summary>
    /// Happy Hour.
    /// </summary>
    [EnumMember(Value = "HAPPY_HOUR")]
    Happy_Hour,

    /// <summary>
    /// Kitchen.
    /// </summary>
    [EnumMember(Value = "KITCHEN")]
    Kitchen,

    /// <summary>
    /// Lunch.
    /// </summary>
    [EnumMember(Value = "LUNCH")]
    Lunch,

    /// <summary>
    /// Online service hours.
    /// </summary>
    [EnumMember(Value = "ONLINE_SERVICE_HOURS")]
    Online_Service_Hours,

    /// <summary>
    /// Pickup.
    /// </summary>
    [EnumMember(Value = "PICKUP")]
    Pickup,

    /// <summary>
    /// Reception.
    /// </summary>
    [EnumMember(Value = "RECEPTION")]
    Reception,

    /// <summary>
    /// Default value when secondary hour type is not specified.
    /// </summary>
    [EnumMember(Value = "SECONDARY_HOURS_TYPE_UNSPECIFIED")]
    Secondary_Hours_Type_Unspecified,

    /// <summary>
    /// Senior Hours.
    /// </summary>
    [EnumMember(Value = "SENIOR_HOURS")]
    Senior_Hours,

    /// <summary>
    /// Takeout.
    /// </summary>
    [EnumMember(Value = "TAKEOUT")]
    Takeout,
}