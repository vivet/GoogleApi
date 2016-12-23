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
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "accounting")]
        ACCOUNTING,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "airport")]
        AIRPORT,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "amusement_park")]
        AMUSEMENT_PARK,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "aquarium")]
        AQUARIUM,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "art_gallery")]
        ART_GALLERY,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "atm")]
        ATM,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "bakery")]
        BAKERY,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "bank")]
        BANK,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "bar")]
        BAR,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "beauty_salon")]
        BEAUTY_SALON,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "bicycle_store")]
        BICYCLE_STORE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "book_store")]
        BOOK_STORE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "bowling_alley")]
        BOWLING_ALLEY,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "bus_station")]
        BUS_STATION,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "cafe")]
        CAFE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "campground")]
        CAMPGROUND,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "car_dealer")]
        CAR_DEALER,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "car_rental")]
        CAR_RENTAL,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "car_repair")]
        CAR_REPAIR,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "car_wash")]
        CAR_WASH,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "casino")]
        CASINO,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "cemetery")]
        CEMETERY,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "church")]
        CHURCH,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "city_hall")]
        CITY_HALL,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "clothing_store")]
        CLOTHING_STORE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "convenience_store")]
        CONVENIENCE_STORE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "courthouse")]
        COURTHOUSE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "dentist")]
        DENTIST,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "department_store")]
        DEPARTMENT_STORE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "doctor")]
        DOCTOR,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "electrician")]
        ELECTRICIAN,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "electronics_store")]
        ELECTRONICS_STORE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "establishment")]
        ESTABLISHMENT,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "finance")]
        FINANCE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "fire_station")]
        FIRE_STATION,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "florist")]
        FLORIST,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "food")]
        FOOD,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "funeral_home")]
        FUNERAL_HOME,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "furniture_store")]
        FURNITURE_STORE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "gas_station")]
        GAS_STATION,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "general_contractor")]
        GENERAL_CONTRACTOR,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "grocery_or_supermarket")]
        GROCERY_OR_SUPERMARKET,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "gym")]
        GYM,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "hair_care")]
        HAIR_CARE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "hardware_store")]
        HARDWARE_STORE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "health")]
        HEALTH,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "hindu_temple")]
        HINDU_TEMPLE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "home_goods_store")]
        HOME_GOODS_STORE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "hospital")]
        HOSPITAL,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "insurance_agency")]
        INSURANCE_AGENCY,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "jewelry_store")]
        JEWELRY_STORE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "laundry")]
        LAUNDRY,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "lawyer")]
        LAWYER,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "library")]
        LIBRARY,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "liquor_store")]
        LIQUOR_STORE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "local_government_office")]
        LOCAL_GOVERNMENT_OFFICE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "locksmith")]
        LOCKSMITH,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "lodging")]
        LODGING,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "meal_delivery")]
        MEAL_DELIVERY,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "meal_takeaway")]
        MEAL_TAKEAWAY,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "mosque")]
        MOSQUE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "movie_rental")]
        MOVIE_RENTAL,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "movie_theater")]
        MOVIE_THEATER,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "moving_company")]
        MOVING_COMPANY,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "museum")]
        MUSEUM,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "night_club")]
        NIGHT_CLUB,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "painter")]
        PAINTER,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "park")]
        PARK,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "parking")]
        PARKING,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "pet_store")]
        PET_STORE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "pharmacy")]
        PHARMACY,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "physiotherapist")]
        PHYSIOTHERAPIST,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "place_of_worship")]
        PLACE_OF_WORSHIP,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "plumber")]
        PLUMBER,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "police")]
        POLICE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "post_office")]
        POST_OFFICE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "real_estate_agency")]
        REAL_ESTATE_AGENCY,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "restaurant")]
        RESTAURANT,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "roofing_contractor")]
        ROOFING_CONTRACTOR,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "rv_park")]
        RV_PARK,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "school")]
        SCHOOL,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "shoe_store")]
        SHOE_STORE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "shopping_mall")]
        SHOPPING_MALL,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "spa")]
        SPA,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "stadium")]
        STADIUM,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "storage")]
        STORAGE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "store")]
        STORE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "subway_station")]
        SUBWAY_STATION,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "synagogue")]
        SYNAGOGUE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "taxi_stand")]
        TAXI_STAND,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "train_station")]
        TRAIN_STATION,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "travel_agency")]
        TRAVEL_AGENCY,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "university")]
        UNIVERSITY,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "veterinary_care")]
        VETERINARY_CARE,
        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "zoo")]
        ZOO,
    }
}