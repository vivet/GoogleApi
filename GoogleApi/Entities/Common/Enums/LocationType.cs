using System.Runtime.Serialization;

namespace GoogleApi.Entities.Common.Enums
{
    /// <summary>
    /// Location types.
    /// </summary>
    public enum LocationType
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
        /// Indicates a first-order civil entity below the country level. Within the United States, these administrative levels are states. 
        /// Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_1")]
        Administrative_Area_Level_1,

        /// <summary>
        /// Indicates a second-order civil entity below the country level. Within the United States, these administrative levels are counties. 
        /// Not all nations exhibit these administrative levels.
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
        /// Indicates a commonly-used alternative name for the entity.
        /// </summary>
        [EnumMember(Value = "colloquial_area")]
        Colloquial_Area,

        /// <summary>
        /// Ward indicates a specific type of Japanese locality, to facilitate distinction between multiple locality components within a Japanese address.
        /// </summary>
        [EnumMember(Value = "ward")]
        Ward,

        /// <summary>
        /// Indicates an incorporated city or town political entity.
        /// </summary>
        [EnumMember(Value = "locality")]
        Locality,

        /// <summary>
        /// indicates an first-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality")]
        Sublocality,

        /// <summary>
        /// indicates an first-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_1")]
        Sublocality_Level_1,

        /// <summary>
        /// indicates an second-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_2")]
        SublocalityLevel2,

        /// <summary>
        /// indicates an third-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_3")]
        Sublocality_Level_3,

        /// <summary>
        /// indicates an first-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_4")]
        Sublocality_Level_4,

        /// <summary>
        /// indicates an first-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_5")]
        Sublocality_Level_5,

        /// <summary>
        /// Indicates a named neighborhood
        /// </summary>
        [EnumMember(Value = "neighborhood")]
        Neighborhood,

        /// <summary>
        /// Indicates a named location, usually a building or collection of buildings with a common name
        /// </summary>
        [EnumMember(Value = "premise")]
        Premise,

        /// <summary>
        /// Indicates a first-order entity below a named location, usually a singular building within a collection of buildings with a common name
        /// </summary>
        [EnumMember(Value = "subpremise")]
        Subpremise,

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
        /// Indicates an airport.
        /// </summary>
        [EnumMember(Value = "airport")] Airport,

        /// <summary>
        /// Indicates a named park.
        /// </summary>
        [EnumMember(Value = "park")] Park,

        /// <summary>
        /// Indicates a named point of interest. Typically, these "POI"s are prominent local entities that don't easily fit in another category such as "Empire State Building" or "Statue of Liberty."
        /// </summary>
        [EnumMember(Value = "point_of_interest")]
        Point_Of_Interest,

        /// <summary>
        /// Indicates the floor of a building address.
        /// </summary>
        [EnumMember(Value = "floor")]
        Floor,

        /// <summary>
        /// Establishment typically indicates a place that has not yet been categorized.
        /// </summary>
        [EnumMember(Value = "establishment")]
        Establishment,

        /// <summary>
        /// Parking indicates a parking lot or parking structure.
        /// </summary>
        [EnumMember(Value = "parking")]
        Parking,

        /// <summary>
        /// post_box indicates a specific postal box.
        /// </summary>
        [EnumMember(Value = "post_box")]
        Post_Box,

        /// <summary>
        /// postal_town indicates a grouping of geographic areas, such as locality and sublocality, used for mailing addresses in some countries.
        /// </summary>
        [EnumMember(Value = "postal_town")]
        Postal_Town,

        /// <summary>
        /// room indicates the room of a building address.
        /// </summary>
        [EnumMember(Value = "room")]
        Room,

        /// <summary>
        /// street_number indicates the precise street number.
        /// </summary>
        [EnumMember(Value = "street_number")]
        Street_Number,

        /// <summary>
        /// Indicate the location of a bus stop.
        /// </summary>
        [EnumMember(Value = "bus_station")]
        Bus_Station,

        /// <summary>
        /// Indicate the location of a train stop.
        /// </summary>
        [EnumMember(Value = "train_station")]
        Train_Station,

        /// <summary>
        /// Indicate the location of a public transit stop.
        /// </summary>
        [EnumMember(Value = "transit_station")]
        Transit_Station,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "postal_code_suffix")]
        Postal_Code_Suffix
    }
}