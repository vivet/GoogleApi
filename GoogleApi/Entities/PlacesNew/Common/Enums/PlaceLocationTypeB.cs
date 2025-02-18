using System.Runtime.Serialization;

namespace GoogleApi.Entities.PlacesNew.Common.Enums;

/// <summary>
/// The Place type values in Table B may be returned as part of a Place Autocomplete (New) response.
/// These types are also supported by includedPrimaryTypes for Place Autocomplete (New) requests.
/// https://developers.google.com/maps/documentation/places/web-service/place-types#table-b
/// </summary>
public enum PlaceLocationTypeB
{
    /// <summary>
    /// Administrative Area Level 3.
    /// </summary>
    [EnumMember(Value = "administrative_area_level_3")]
    AdministrativeAreaLevel3,

    /// <summary>
    /// Administrative Area Level 4.
    /// </summary>
    [EnumMember(Value = "administrative_area_level_4")]
    AdministrativeAreaLevel4,

    /// <summary>
    /// Administrative Area Level 5.
    /// </summary>
    [EnumMember(Value = "administrative_area_level_5")]
    AdministrativeAreaLevel5,

    /// <summary>
    /// Administrative Area Level 6.
    /// </summary>
    [EnumMember(Value = "administrative_area_level_6")]
    AdministrativeAreaLevel6,

    /// <summary>
    /// Administrative Area Level 7.
    /// </summary>
    [EnumMember(Value = "administrative_area_level_7")]
    AdministrativeAreaLevel7,

    /// <summary>
    /// Archipelago.
    /// </summary>
    [EnumMember(Value = "archipelago")]
    Archipelago,

    /// <summary>
    /// Colloquial Area.
    /// </summary>
    [EnumMember(Value = "colloquial_area")]
    ColloquialArea,

    /// <summary>
    /// Continent.
    /// </summary>
    [EnumMember(Value = "continent")]
    Continent,

    /// <summary>
    /// Establishment.
    /// </summary>
    [EnumMember(Value = "establishment")]
    Establishment,

    /// <summary>
    /// Finance.
    /// </summary>
    [EnumMember(Value = "finance")]
    Finance,

    /// <summary>
    /// Floor.
    /// </summary>
    [EnumMember(Value = "floor")]
    Floor,

    /// <summary>
    /// Food.
    /// </summary>
    [EnumMember(Value = "food")]
    Food,

    /// <summary>
    /// General Contractor.
    /// </summary>
    [EnumMember(Value = "general_contractor")]
    GeneralContractor,

    /// <summary>
    /// Geocode.
    /// </summary>
    [EnumMember(Value = "geocode")]
    Geocode,

    /// <summary>
    /// Health.
    /// </summary>
    [EnumMember(Value = "health")]
    Health,

    /// <summary>
    /// Intersection.
    /// </summary>
    [EnumMember(Value = "intersection")]
    Intersection,

    /// <summary>
    /// Landmark.
    /// </summary>
    [EnumMember(Value = "landmark")]
    Landmark,

    /// <summary>
    /// Natural Feature.
    /// </summary>
    [EnumMember(Value = "natural_feature")]
    NaturalFeature,

    /// <summary>
    /// Neighborhood.
    /// </summary>
    [EnumMember(Value = "neighborhood")]
    Neighborhood,

    /// <summary>
    /// Place of Worship.
    /// </summary>
    [EnumMember(Value = "place_of_worship")]
    PlaceOfWorship,

    /// <summary>
    /// Plus Code.
    /// </summary>
    [EnumMember(Value = "plus_code")]
    PlusCode,

    /// <summary>
    /// Point of Interest.
    /// </summary>
    [EnumMember(Value = "point_of_interest")]
    PointOfInterest,

    /// <summary>
    /// Political.
    /// </summary>
    [EnumMember(Value = "political")]
    Political,

    /// <summary>
    /// Post Box.
    /// </summary>
    [EnumMember(Value = "post_box")]
    PostBox,

    /// <summary>
    /// Postal Code Prefix.
    /// </summary>
    [EnumMember(Value = "postal_code_prefix")]
    PostalCodePrefix,

    /// <summary>
    /// Postal Code Suffix.
    /// </summary>
    [EnumMember(Value = "postal_code_suffix")]
    PostalCodeSuffix,

    /// <summary>
    /// Postal Town.
    /// </summary>
    [EnumMember(Value = "postal_town")]
    PostalTown,

    /// <summary>
    /// Premise.
    /// </summary>
    [EnumMember(Value = "premise")]
    Premise,

    /// <summary>
    /// Room.
    /// </summary>
    [EnumMember(Value = "room")]
    Room,

    /// <summary>
    /// Route.
    /// </summary>
    [EnumMember(Value = "route")]
    Route,

    /// <summary>
    /// Street Address.
    /// </summary>
    [EnumMember(Value = "street_address")]
    StreetAddress,

    /// <summary>
    /// Street Number.
    /// </summary>
    [EnumMember(Value = "street_number")]
    StreetNumber,

    /// <summary>
    /// Sublocality.
    /// </summary>
    [EnumMember(Value = "sublocality")]
    Sublocality,

    /// <summary>
    /// Sublocality Level 1.
    /// </summary>
    [EnumMember(Value = "sublocality_level_1")]
    SublocalityLevel1,

    /// <summary>
    /// Sublocality Level 2.
    /// </summary>
    [EnumMember(Value = "sublocality_level_2")]
    SublocalityLevel2,

    /// <summary>
    /// Sublocality Level 3.
    /// </summary>
    [EnumMember(Value = "sublocality_level_3")]
    SublocalityLevel3,

    /// <summary>
    /// Sublocality Level 4.
    /// </summary>
    [EnumMember(Value = "sublocality_level_4")]
    SublocalityLevel4,

    /// <summary>
    /// Sublocality Level 5.
    /// </summary>
    [EnumMember(Value = "sublocality_level_5")]
    SublocalityLevel5,

    /// <summary>
    /// Subpremise.
    /// </summary>
    [EnumMember(Value = "subpremise")]
    Subpremise,

    /// <summary>
    /// Town Square.
    /// </summary>
    [EnumMember(Value = "town_square")]
    TownSquare
}