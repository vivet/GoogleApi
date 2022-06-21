using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.StaticMaps.Request.Enums;

/// <summary>
/// Features, or feature types, are geographic characteristics on the map, including roads, parks, bodies of water, businesses, and more.
/// The features form a category tree, with all as the root.If you don't specify a feature, all features are selected. Specifying a feature of all has the same effect.
/// Some features contain child features you specify using a dot notation.For example, landscape.natural or road.local.
/// If you specify only the parent feature, such as road, the styles you specify for the parent apply to all its children, such as road.local and road.highway.
/// Note that parent features may include some elements that are not included in all of their child features.
/// </summary>
public enum StyleFeature
{
    /// <summary>
    /// Selects all features.
    /// </summary>
    [EnumMember(Value = "all")]
    All,

    /// <summary>
    /// selects all administrative areas.
    /// Styling affects only the labels of administrative areas, not the geographical borders or fill.
    /// </summary>
    [EnumMember(Value = "administrative")]
    Administrative,

    /// <summary>
    /// selects countries.
    /// </summary>
    [EnumMember(Value = "administrative.country")]
    Administrative_Country,

    /// <summary>
    /// selects land parcels.
    /// </summary>
    [EnumMember(Value = "administrative.land_parcel")]
    Administrative_Land_Parcel,

    /// <summary>
    /// selects localities.
    /// </summary>
    [EnumMember(Value = "administrative.locality")]
    Administrative_Locality,

    /// <summary>
    /// selects neighborhoods.
    /// </summary>
    [EnumMember(Value = "administrative.neighborhood")]
    Administrative_Neighborhood,

    /// <summary>
    /// selects provinces.
    /// </summary>
    [EnumMember(Value = "administrative.province")]
    Administrative_Province,

    /// <summary>
    /// selects all landscapes.
    /// </summary>
    [EnumMember(Value = "landscape")]
    Landscape,

    /// <summary>
    /// selects man-made features, such as buildings and other structures.
    /// </summary>
    [EnumMember(Value = "landscape.man_made")]
    Landscape_Man_Made,

    /// <summary>
    /// selects natural features, such as mountains, rivers, deserts, and glaciers.
    /// </summary>
    [EnumMember(Value = "landscape.natural")]
    Landscape_Natural,

    /// <summary>
    /// selects land cover features, the physical material that covers the earth's surface, such as forests, grasslands, wetlands, and bare ground.
    /// </summary>
    [EnumMember(Value = "landscape.natural.landcover")]
    Landscape_Natural_Landcover,

    /// <summary>
    /// selects terrain features of a land surface, such as elevation, slope, and orientation.
    /// </summary>
    [EnumMember(Value = "landscape.natural.terrain")]
    Landscape_Natural_Terrain,

    /// <summary>
    /// selects all points of interest.
    /// </summary>
    [EnumMember(Value = "poi")]
    Poi,

    /// <summary>
    /// selects tourist attractions.
    /// </summary>
    [EnumMember(Value = "poi.attraction")]
    Poi_Attraction,

    /// <summary>
    /// selects businesses.
    /// </summary>
    [EnumMember(Value = "poi.business")]
    Poi_Business,

    /// <summary>
    /// selects government buildings.
    /// </summary>
    [EnumMember(Value = "poi.government")]
    Poi_Government,

    /// <summary>
    /// selects emergency services, including hospitals, pharmacies, police, doctors, and others.
    /// </summary>
    [EnumMember(Value = "poi.medical")]
    Poi_Medical,

    /// <summary>
    /// selects parks.
    /// </summary>
    [EnumMember(Value = "poi.park")]
    Poi_Park,

    /// <summary>
    /// selects places of worship, including churches, temples, mosques, and others.
    /// </summary>
    [EnumMember(Value = "poi.place_of_worship")]
    Poi_Place_Of_Worship,

    /// <summary>
    /// selects schools.
    /// </summary>
    [EnumMember(Value = "poi.school")]
    Poi_School,

    /// <summary>
    /// selects sports complexes.
    /// </summary>
    [EnumMember(Value = "poi.sports_complex")]
    Poi_Sports_Complex,

    /// <summary>
    /// selects all roads.
    /// </summary>
    [EnumMember(Value = "road")]
    Road,

    /// <summary>
    /// selects arterial roads.
    /// </summary>
    [EnumMember(Value = "road.arterial")]
    Road_Arterial,

    /// <summary>
    /// selects highways.
    /// </summary>
    [EnumMember(Value = "road.highway")]
    Road_Highway,

    /// <summary>
    /// selects highways with controlled access.
    /// </summary>
    [EnumMember(Value = "road.highway.controlled_access")]
    Road_Highway_Controlled_Access,

    /// <summary>
    /// selects local roads.
    /// </summary>
    [EnumMember(Value = "road.local")]
    Road_Local,

    /// <summary>
    /// selects all transit stations and lines.
    /// </summary>
    [EnumMember(Value = "transit")]
    Transit,

    /// <summary>
    /// selects transit lines.
    /// </summary>
    [EnumMember(Value = "transit.line")]
    Transit_Line,

    /// <summary>
    /// selects all transit stations.
    /// </summary>
    [EnumMember(Value = "transit.station")]
    Transit_Station,

    /// <summary>
    /// selects airports.
    /// </summary>
    [EnumMember(Value = "transit.station.airport")]
    Transit_Station_Airport,

    /// <summary>
    /// selects bus stops.
    /// </summary>
    [EnumMember(Value = "transit.station.bus")]
    Transit_Station_Bus,

    /// <summary>
    /// selects rail stations.
    /// </summary>
    [EnumMember(Value = "transit.station.rail")]
    Transit_Station_Rail,

    /// <summary>
    /// selects bodies of water.
    /// </summary>
    [EnumMember(Value = "water")]
    Water
}