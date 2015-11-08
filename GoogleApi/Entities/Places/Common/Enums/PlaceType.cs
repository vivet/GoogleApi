using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.Common.Enums
{
    /// <summary>
    /// Place Type
    /// </summary>
    [DataContract]
    public enum PlaceType
    {
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
        ZOO
    }
}