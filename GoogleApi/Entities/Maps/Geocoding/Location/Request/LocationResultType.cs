using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Geocoding.Location.Request;

/// <summary>
/// Location Result Type-
/// </summary>
public enum LocationResultType
{
    /// <summary>
    /// Indicates a precise street address.
    /// </summary>
    [EnumMember(Value = "street_address")]
    Street_Address,

    /// <summary>
    /// Indicates a named route (such as "US 101").
    /// </summary>
    [EnumMember(Value = "route")]
    Route,

    /// <summary>
    /// Indicates a major intersection, usually of two major roads.
    /// </summary>
    [EnumMember(Value = "intersection")]
    Intersection,

    /// <summary>
    /// Indicates a political entity. Usually, this type indicates a polygon of some civil administration.
    /// </summary>
    [EnumMember(Value = "political")]
    Political,

    /// <summary>
    /// Indicates the national political entity, and is typically the highest order type returned by the Geocoder.
    /// </summary>
    [EnumMember(Value = "country")]
    Country,

    /// <summary>
    /// Indicates a first-order civil entity below the country level. Within the United States,
    /// these administrative levels are states. Not all nations exhibit these administrative levels.
    /// </summary>
    [EnumMember(Value = "administrative_area_level_1")]
    Administrative_Area_Level_1,

    /// <summary>
    /// Indicates a second-order civil entity below the country level. Within the United States,
    /// these administrative levels are counties. Not all nations exhibit these administrative levels.
    /// </summary>
    [EnumMember(Value = "administrative_area_level_2")]
    Administrative_Area_Level_2,

    /// <summary>
    /// Indicates a third-order civil entity below the country level. This type indicates a minor civil division.
    /// Not all nations exhibit these administrative levels.
    /// </summary>
    [EnumMember(Value = "administrative_area_level_3")]
    Administrative_Area_Level_3,

    /// <summary>
    /// Indicates a fourth-order civil entity below the country level. This type indicates a minor civil division.
    /// Not all nations exhibit these administrative levels.
    /// </summary>
    [EnumMember(Value = "administrative_area_level_4")]
    Administrative_Area_Level_4,

    /// <summary>
    /// Indicates a fifth-order civil entity below the country level. This type indicates a minor civil division.
    /// Not all nations exhibit these administrative levels.
    /// </summary>
    [EnumMember(Value = "administrative_area_level_5")]
    Administrative_Area_Level_5,

    /// <summary>
    /// Indicates a sixth-order civil entity below the country level. This type indicates a minor civil division.
    /// Not all nations exhibit these administrative levels.
    /// </summary>
    [EnumMember(Value = "administrative_area_level_6")]
    Administrative_Area_Level_6,

    /// <summary>
    /// Indicates a seventh-order civil entity below the country level. This type indicates a minor civil division.
    /// Not all nations exhibit these administrative levels.
    /// </summary>
    [EnumMember(Value = "administrative_area_level_7")]
    Administrative_Area_Level_7,

    /// <summary>
    /// Indicates a commonly-used alternative name for the entity.
    /// </summary>
    [EnumMember(Value = "colloquial_area")]
    Colloquial_Area,

    /// <summary>
    /// Indicates an incorporated city or town political entity.
    /// </summary>
    [EnumMember(Value = "locality")]
    Locality,

    /// <summary>
    /// locality.
    /// </summary>
    [EnumMember(Value = "sublocality")]
    Sublocality,

    /// <summary>
    /// Indicates a named neighborhood
    /// </summary>
    [EnumMember(Value = "neighborhood")]
    Neighborhood,

    /// <summary>
    /// Indicates a named location, usually a building or collection of buildings with a common name.
    /// </summary>
    [EnumMember(Value = "premise")]
    Premise,

    /// <summary>
    /// Indicates a first-order entity below a named location, usually a singular building within a collection of buildings with a common name.
    /// </summary>
    [EnumMember(Value = "subpremise")]
    Subpremise,

    /// <summary>
    /// Indicates an encoded location reference, derived from latitude and longitude.
    /// <para/>
    /// Plus codes can be used as a replacement for street addresses in places where they do not exist
    /// (where buildings are not numbered or streets are not named).
    /// <para/>
    /// See <see href="https://plus.codes"/> for details.
    /// </summary>
    [EnumMember(Value = "plus_code")]
    Plus_Code,

    /// <summary>
    /// Indicates a postal code as used to address postal mail within the country.
    /// </summary>
    [EnumMember(Value = "postal_code")]
    Postal_Code,

    /// <summary>
    /// Indicates a prominent natural feature.
    /// </summary>
    [EnumMember(Value = "natural_feature")]
    Natural_Feature,

    /// <summary>
    /// Airport.
    /// </summary>
    [EnumMember(Value = "airport")]
    Airport,

    /// <summary>
    /// Park.
    /// </summary>
    [EnumMember(Value = "park")]
    Park,

    /// <summary>
    /// Indicates a named point of interest. Typically, these "POI"s are prominent local entities that don't easily fit in another category such as "Empire State Building" or "Statue of Liberty."
    /// </summary>
    [EnumMember(Value = "point_of_interest")]
    Point_Of_Interest
}