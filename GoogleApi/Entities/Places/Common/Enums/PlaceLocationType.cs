using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.Common.Enums
{
    /// <summary>
    /// Place Types
    /// https://developers.google.com/places/supported_types#table1
    /// https://developers.google.com/places/supported_types#table2
    /// </summary>
    [DataContract]
    public enum PlaceLocationType
    {
        /// <summary>
        /// Geocode instructs the Place Autocomplete service to return only geocoding results, 
        /// rather than business results. Generally, you use this request to disambiguate results where the location specified may be indeterminate.
        /// </summary>
        [EnumMember(Value = "geocode")]
        GEOCODE,
        /// <summary>
        /// Indicates a precise street address.
        /// </summary>
        [EnumMember(Value = "street_address")]
        STREET_ADDRESS,
        /// <summary>
        /// Indicates a named route (such as "US 101").
        /// </summary>
        [EnumMember(Value = "route")]
        ROUTE,
        /// <summary>
        /// Indicates a major intersection, usually of two major roads.
        /// </summary>
        [EnumMember(Value = "intersection")]
        INTERSECTION,
        /// <summary>
        /// Indicates a political entity. Usually, this type indicates a polygon of some civil administration.
        /// </summary>
        [EnumMember(Value = "political")]
        POLITICAL,
        /// <summary>
        /// Indicates the national political entity, and is typically the highest order type returned by the Geocoder.
        /// </summary>
        [EnumMember(Value = "country")]
        COUNTRY,
        /// <summary>
        /// Indicates a first-order civil entity below the country level. Within the United States, these administrative levels are states. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_1")]
        ADMINISTRATIVE_AREA_LEVEL_1,
        /// <summary>
        /// Indicates a second-order civil entity below the country level. Within the United States, these administrative levels are counties. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_2")]
        ADMINISTRATIVE_AEA_LVEL_2,
        /// <summary>
        /// Indicates a third-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_3")]
        ADMINISTRATIVE_AEA_LEVEL_3,
        /// <summary>
        /// Indicates a fourth-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_4")]
        ADMINISTRATIVE_AEA_LEVEL_4,
        /// <summary>
        /// Indicates a fifth-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_5")]
        ADMINISTRATIVE_AEA_LEVEL_5,
        /// <summary>
        /// Indicates a commonly-used alternative name for the entity.
        /// </summary>
        [EnumMember(Value = "colloquial_area")]
        COLLOQUIAL_AREA,
        /// <summary>
        /// Indicates an incorporated city or town political entity.
        /// </summary>
        [EnumMember(Value = "locality")]
        LOCALITY,
        /// <summary>
        /// locality
        /// </summary>
        [EnumMember(Value = "sublocality")]
        SUBLOCALITY,
        /// <summary>
        /// indicates an first-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_1")]
        SUBLOCALITY_LEVEL_1,
        /// <summary>
        /// indicates an second-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_2")]
        SUBLOCALITY_LEVEL_2,
        /// <summary>
        /// indicates an third-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_3")]
        SUBLOCALITY_LEVEL_3,
        /// <summary>
        /// indicates an first-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_4")]
        SUBLOCALITY_LEVEL_4,
        /// <summary>
        /// indicates an first-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_5")]
        SUBLOCALITY_LEVEL_5,
        /// <summary>
        /// Indicates a named neighborhood
        /// </summary>
        [EnumMember(Value = "neighborhood")]
        NEIGHBORHOOD,
        /// <summary>
        /// Indicates a named location, usually a building or collection of buildings with a common name
        /// </summary>
        [EnumMember(Value = "premise")]
        PREMISE,
        /// <summary>
        /// Indicates a first-order entity below a named location, usually a singular building within a collection of buildings with a common name
        /// </summary>
        [EnumMember(Value = "subpremise")]
        SUBPREMISE,
        /// <summary>
        /// Indicates a postal code as used to address postal mail within the country.
        /// </summary>
        [EnumMember(Value = "postal_code")]
        POSTAL_CODE,
        /// <summary>
        /// Indicates a postal code prefix.
        /// </summary>
        [EnumMember(Value = "postal_code_prefix")]
        POSTAL_CODE_PREFIX,
        /// <summary>
        /// Indicates a postal code suffix.
        /// </summary>
        [EnumMember(Value = "postal_code_suffix")]
        POSTAL_CODE_SUFFIX,
        /// <summary>
        /// Indicates a prominent natural feature.
        /// </summary>
        [EnumMember(Value = "natural_feature")]
        NATURAL_FEATURE,
        /// <summary>
        /// Indicates a named point of interest. Typically, these "POI"s are prominent local entities that don't easily fit in another category such as "Empire State Building" or "Statue of Liberty."
        /// </summary>
        [EnumMember(Value = "point_of_interest")]
        POINT_OF_INTEREST,
        /// <summary>
        /// Indicates the floor of a building address.
        /// </summary>
        [EnumMember(Value = "floor")]
        FLOOR,
        /// <summary>
        /// post_box indicates a specific postal box.
        /// </summary>
        [EnumMember(Value = "post_box")]
        POST_BOX,
        /// <summary>
        /// postal_town indicates a grouping of geographic areas, such as locality and sublocality, used for mailing addresses in some countries.
        /// </summary>
        [EnumMember(Value = "postal_town")]
        POSTAL_TOWN,
        /// <summary>
        /// room indicates the room of a building address.
        /// </summary>
        [EnumMember(Value = "room")]
        ROOM,
        /// <summary>
        /// street_number indicates the precise street number.
        /// </summary>
        [EnumMember(Value = "street_number")]
        STREET_NUMBER,
        /// <summary>
        /// Indicate the location of a public transit stop.
        /// </summary>
        [EnumMember(Value = "transit_station")]
        TRANSIT_STATION,
        [EnumMember(Value = "accounting")]
        ACCOUNTING,
        [EnumMember(Value = "airport")]
        AIRPORT,
        [EnumMember(Value = "amusement_park")]
        AMUSEMENT_PARK,
        [EnumMember(Value = "aquarium")]
        AQUARIUM,
        [EnumMember(Value = "art_gallery")]
        ART_GALLERY,
        [EnumMember(Value = "atm")]
        ATM,
        [EnumMember(Value = "bakery")]
        BAKERY,
        [EnumMember(Value = "bank")]
        BANK,
        [EnumMember(Value = "bar")]
        BAR,
        [EnumMember(Value = "beauty_salon")]
        BEAUTY_SALON,
        [EnumMember(Value = "bicycle_store")]
        BICYCLE_STORE,
        [EnumMember(Value = "book_store")]
        BOOK_STORE,
        [EnumMember(Value = "bowling_alley")]
        BOWLING_ALLEY,
        [EnumMember(Value = "bus_station")]
        BUS_STATION,
        [EnumMember(Value = "cafe")]
        CAFE,
        [EnumMember(Value = "campground")]
        CAMPGROUND,
        [EnumMember(Value = "car_dealer")]
        CAR_DEALER,
        [EnumMember(Value = "car_rental")]
        CAR_RENTAL,
        [EnumMember(Value = "car_repair")]
        CAR_REPAIR,
        [EnumMember(Value = "car_wash")]
        CAR_WASH,
        [EnumMember(Value = "casino")]
        CASINO,
        [EnumMember(Value = "cemetery")]
        CEMETERY,
        [EnumMember(Value = "church")]
        CHURCH,
        [EnumMember(Value = "city_hall")]
        CITY_HALL,
        [EnumMember(Value = "clothing_store")]
        CLOTHING_STORE,
        [EnumMember(Value = "convenience_store")]
        CONVENIENCE_STORE,
        [EnumMember(Value = "courthouse")]
        COURTHOUSE,
        [EnumMember(Value = "dentist")]
        DENTIST,
        [EnumMember(Value = "department_store")]
        DEPARTMENT_STORE,
        [EnumMember(Value = "doctor")]
        DOCTOR,
        [EnumMember(Value = "electrician")]
        ELECTRICIAN,
        [EnumMember(Value = "electronics_store")]
        ELECTRONICS_STORE,
        [EnumMember(Value = "establishment")]
        ESTABLISHMENT,
        [EnumMember(Value = "finance")]
        FINANCE,
        [EnumMember(Value = "fire_station")]
        FIRE_STATION,
        [EnumMember(Value = "florist")]
        FLORIST,
        [EnumMember(Value = "food")]
        FOOD,
        [EnumMember(Value = "funeral_home")]
        FUNERAL_HOME,
        [EnumMember(Value = "furniture_store")]
        FURNITURE_STORE,
        [EnumMember(Value = "gas_station")]
        GAS_STATION,
        [EnumMember(Value = "general_contractor")]
        GENERAL_CONTRACTOR,
        [EnumMember(Value = "grocery_or_supermarket")]
        GROCERY_OR_SUPERMARKET,
        [EnumMember(Value = "gym")]
        GYM,
        [EnumMember(Value = "hair_care")]
        HAIR_CARE,
        [EnumMember(Value = "hardware_store")]
        HARDWARE_STORE,
        [EnumMember(Value = "health")]
        HEALTH,
        [EnumMember(Value = "hindu_temple")]
        HINDU_TEMPLE,
        [EnumMember(Value = "home_goods_store")]
        HOME_GOODS_STORE,
        [EnumMember(Value = "hospital")]
        HOSPITAL,
        [EnumMember(Value = "insurance_agency")]
        INSURANCE_AGENCY,
        [EnumMember(Value = "jewelry_store")]
        JEWELRY_STORE,
        [EnumMember(Value = "laundry")]
        LAUNDRY,
        [EnumMember(Value = "lawyer")]
        LAWYER,
        [EnumMember(Value = "library")]
        LIBRARY,
        [EnumMember(Value = "liquor_store")]
        LIQUOR_STORE,
        [EnumMember(Value = "local_government_office")]
        LOCAL_GOVERNMENT_OFFICE,
        [EnumMember(Value = "locksmith")]
        LOCKSMITH,
        [EnumMember(Value = "lodging")]
        LODGING,
        [EnumMember(Value = "meal_delivery")]
        MEAL_DELIVERY,
        [EnumMember(Value = "meal_takeaway")]
        MEAL_TAKEAWAY,
        [EnumMember(Value = "mosque")]
        MOSQUE,
        [EnumMember(Value = "movie_rental")]
        MOVIE_RENTAL,
        [EnumMember(Value = "movie_theater")]
        MOVIE_THEATER,
        [EnumMember(Value = "moving_company")]
        MOVING_COMPANY,
        [EnumMember(Value = "museum")]
        MUSEUM,
        [EnumMember(Value = "night_club")]
        NIGHT_CLUB,
        [EnumMember(Value = "painter")]
        PAINTER,
        [EnumMember(Value = "park")]
        PARK,
        [EnumMember(Value = "parking")]
        PARKING,
        [EnumMember(Value = "pet_store")]
        PET_STORE,
        [EnumMember(Value = "pharmacy")]
        PHARMACY,
        [EnumMember(Value = "physiotherapist")]
        PHYSIOTHERAPIST,
        [EnumMember(Value = "place_of_worship")]
        PLACE_OF_WORSHIP,
        [EnumMember(Value = "plumber")]
        PLUMBER,
        [EnumMember(Value = "police")]
        POLICE,
        [EnumMember(Value = "post_office")]
        POST_OFFICE,
        [EnumMember(Value = "real_estate_agency")]
        REAL_ESTATE_AGENCY,
        [EnumMember(Value = "restaurant")]
        RESTAURANT,
        [EnumMember(Value = "roofing_contractor")]
        ROOFING_CONTRACTOR,
        [EnumMember(Value = "rv_park")]
        RV_PARK,
        [EnumMember(Value = "school")]
        SCHOOL,
        [EnumMember(Value = "shoe_store")]
        SHOE_STORE,
        [EnumMember(Value = "shopping_mall")]
        SHOPPING_MALL,
        [EnumMember(Value = "spa")]
        SPA,
        [EnumMember(Value = "stadium")]
        STADIUM,
        [EnumMember(Value = "storage")]
        STORAGE,
        [EnumMember(Value = "store")]
        STORE,
        [EnumMember(Value = "subway_station")]
        SUBWAY_STATION,
        [EnumMember(Value = "synagogue")]
        SYNAGOGUE,
        [EnumMember(Value = "taxi_stand")]
        TAXI_STAND,
        [EnumMember(Value = "train_station")]
        TRAIN_STATION,
        [EnumMember(Value = "travel_agency")]
        TRAVEL_AGENCY,
        [EnumMember(Value = "university")]
        UNIVERSITY,
        [EnumMember(Value = "veterinary_care")]
        VETERINARY_CARE,
        [EnumMember(Value = "zoo")]
        ZOO,
    }
}