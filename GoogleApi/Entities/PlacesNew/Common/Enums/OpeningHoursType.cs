using System.Runtime.Serialization;

namespace GoogleApi.Entities.PlacesNew.Common.Enums;

/// <summary>
/// A type string used to identify the type of secondary hours.
/// For example, DRIVE_THROUGH, HAPPY_HOUR, DELIVERY, TAKEOUT, KITCHEN, BREAKFAST, LUNCH, DINNER, BRUNCH, PICKUP, SENIOR_HOURS.
/// Set for secondary_opening_hours only
/// </summary>
/// <remarks>
/// Enum Documentation
/// https://developers.google.com/maps/documentation/places/android-sdk/reference/com/google/android/libraries/places/api/model/OpeningHours.HoursType
/// </remarks>
public enum OpeningHoursType
{
    /// <summary>
    /// Default value when secondary hour type is not specified.
    /// </summary>
    [EnumMember(Value = "SECONDARY_HOURS_TYPE_UNSPECIFIED")]
    Secondary_Hours_Type_Unspecified,

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
    /// Delivery.
    /// </summary>
    [EnumMember(Value = "DELIVERY")]
    Delivery,

    /// <summary>
    /// Takeout.
    /// </summary>
    [EnumMember(Value = "TAKEOUT")]
    Takeout,

    /// <summary>
    /// Kitchen.
    /// </summary>
    [EnumMember(Value = "KITCHEN")]
    Kitchen,

    /// <summary>
    /// Breakfast.
    /// </summary>
    [EnumMember(Value = "BREAKFAST")]
    Breakfast,

    /// <summary>
    /// Lunch.
    /// </summary>
    [EnumMember(Value = "LUNCH")]
    Lunch,

    /// <summary>
    /// Dinner.
    /// </summary>
    [EnumMember(Value = "DINNER")]
    Dinner,

    /// <summary>
    /// Brunch.
    /// </summary>
    [EnumMember(Value = "BRUNCH")]
    Brunch,

    /// <summary>
    /// Pickup.
    /// </summary>
    [EnumMember(Value = "PICKUP")]
    Pickup,

    /// <summary>
    /// The access hours for storage places.
    /// </summary>
    [EnumMember(Value = "ACCESS")]
    Access,

    /// <summary>
    /// Senior Hours.
    /// </summary>
    [EnumMember(Value = "SENIOR_HOURS")]
    Senior_Hours,

    /// <summary>
    /// Online service hours.
    /// </summary>
    [EnumMember(Value = "ONLINE_SERVICE_HOURS")]
    Online_Service_Hours
}