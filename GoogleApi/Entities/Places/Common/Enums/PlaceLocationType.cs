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
        [EnumMember(Value = "geocode")] Geocode,

        /// <summary>
        /// Indicates a precise street address.
        /// </summary>
        [EnumMember(Value = "street_address")] StreetAddress,

        /// <summary>
        /// Indicates a named route (such as "US 101").
        /// </summary>
        [EnumMember(Value = "route")] Route,

        /// <summary>
        /// Indicates a major intersection, usually of two major roads.
        /// </summary>
        [EnumMember(Value = "intersection")] Intersection,

        /// <summary>
        /// Indicates a political entity. Usually, this type indicates a polygon of some civil administration.
        /// </summary>
        [EnumMember(Value = "political")] Political,

        /// <summary>
        /// Indicates the national political entity, and is typically the highest order type returned by the Geocoder.
        /// </summary>
        [EnumMember(Value = "country")] Country,

        /// <summary>
        /// Indicates a first-order civil entity below the country level. Within the United States, these administrative levels are states. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_1")] AdministrativeAreaLevel1,

        /// <summary>
        /// Indicates a second-order civil entity below the country level. Within the United States, these administrative levels are counties. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_2")] AdministrativeAeaLvel2,

        /// <summary>
        /// Indicates a third-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_3")] AdministrativeAeaLevel3,

        /// <summary>
        /// Indicates a fourth-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_4")] AdministrativeAeaLevel4,

        /// <summary>
        /// Indicates a fifth-order civil entity below the country level. This type indicates a minor civil division. Not all nations exhibit these administrative levels.
        /// </summary>
        [EnumMember(Value = "administrative_area_level_5")] AdministrativeAeaLevel5,

        /// <summary>
        /// Indicates a commonly-used alternative name for the entity.
        /// </summary>
        [EnumMember(Value = "colloquial_area")] ColloquialArea,

        /// <summary>
        /// Indicates an incorporated city or town political entity.
        /// </summary>
        [EnumMember(Value = "locality")] Locality,

        /// <summary>
        /// locality
        /// </summary>
        [EnumMember(Value = "sublocality")] Sublocality,

        /// <summary>
        /// indicates an first-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_1")] SublocalityLevel1,

        /// <summary>
        /// indicates an second-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_2")] SublocalityLevel2,

        /// <summary>
        /// indicates an third-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_3")] SublocalityLevel3,

        /// <summary>
        /// indicates an first-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_4")] SublocalityLevel4,

        /// <summary>
        /// indicates an first-order civil entity below a locality
        /// </summary>
        [EnumMember(Value = "sublocality_level_5")] SublocalityLevel5,

        /// <summary>
        /// Indicates a named neighborhood
        /// </summary>
        [EnumMember(Value = "neighborhood")] Neighborhood,

        /// <summary>
        /// Indicates a named location, usually a building or collection of buildings with a common name
        /// </summary>
        [EnumMember(Value = "premise")] Premise,

        /// <summary>
        /// Indicates a first-order entity below a named location, usually a singular building within a collection of buildings with a common name
        /// </summary>
        [EnumMember(Value = "subpremise")] Subpremise,

        /// <summary>
        /// Indicates a postal code as used to address postal mail within the country.
        /// </summary>
        [EnumMember(Value = "postal_code")] PostalCode,

        /// <summary>
        /// Indicates a postal code prefix.
        /// </summary>
        [EnumMember(Value = "postal_code_prefix")] PostalCodePrefix,

        /// <summary>
        /// Indicates a postal code suffix.
        /// </summary>
        [EnumMember(Value = "postal_code_suffix")] PostalCodeSuffix,

        /// <summary>
        /// Indicates a prominent natural feature.
        /// </summary>
        [EnumMember(Value = "natural_feature")] NaturalFeature,

        /// <summary>
        /// Indicates a named point of interest. Typically, these "POI"s are prominent local entities that don't easily fit in another category such as "Empire State Building" or "Statue of Liberty."
        /// </summary>
        [EnumMember(Value = "point_of_interest")] PointOfInterest,

        /// <summary>
        /// Indicates the floor of a building address.
        /// </summary>
        [EnumMember(Value = "floor")] Floor,

        /// <summary>
        /// post_box indicates a specific postal box.
        /// </summary>
        [EnumMember(Value = "post_box")] PostBox,

        /// <summary>
        /// postal_town indicates a grouping of geographic areas, such as locality and sublocality, used for mailing addresses in some countries.
        /// </summary>
        [EnumMember(Value = "postal_town")] PostalTown,

        /// <summary>
        /// room indicates the room of a building address.
        /// </summary>
        [EnumMember(Value = "room")] Room,

        /// <summary>
        /// street_number indicates the precise street number.
        /// </summary>
        [EnumMember(Value = "street_number")] StreetNumber,

        /// <summary>
        /// Indicate the location of a public transit stop.
        /// </summary>
        [EnumMember(Value = "transit_station")] TransitStation,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "accounting")] Accounting,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "airport")] Airport,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "amusement_park")] AmusementPark,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "aquarium")] Aquarium,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "art_gallery")] ArtGallery,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "atm")] Atm,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "bakery")] Bakery,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "bank")] Bank,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "bar")] Bar,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "beauty_salon")] BeautySalon,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "bicycle_store")] BicycleStore,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "book_store")] BookStore,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "bowling_alley")] BowlingAlley,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "bus_station")] BusStation,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "cafe")] Cafe,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "campground")] Campground,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "car_dealer")] CarDealer,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "car_rental")] CarRental,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "car_repair")] CarRepair,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "car_wash")] CarWash,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "casino")] Casino,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "cemetery")] Cemetery,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "church")] Church,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "city_hall")] CityHall,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "clothing_store")] ClothingStore,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "convenience_store")] ConvenienceStore,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "courthouse")] Courthouse,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "dentist")] Dentist,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "department_store")] DepartmentStore,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "doctor")] Doctor,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "electrician")] Electrician,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "electronics_store")] ElectronicsStore,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "establishment")] Establishment,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "finance")] Finance,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "fire_station")] FireStation,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "florist")] Florist,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "food")] Food,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "funeral_home")] FuneralHome,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "furniture_store")] FurnitureStore,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "gas_station")] GasStation,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "general_contractor")] GeneralContractor,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "grocery_or_supermarket")] GroceryOrSupermarket,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "gym")] Gym,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "hair_care")] HairCare,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "hardware_store")] HardwareStore,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "health")] Health,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "hindu_temple")] HinduTemple,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "home_goods_store")] HomeGoodsStore,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "hospital")] Hospital,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "insurance_agency")] InsuranceAgency,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "jewelry_store")] JewelryStore,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "laundry")] Laundry,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "lawyer")] Lawyer,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "library")] Library,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "liquor_store")] LiquorStore,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "local_government_office")] LocalGovernmentOffice,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "locksmith")] Locksmith,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "lodging")] Lodging,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "meal_delivery")] MealDelivery,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "meal_takeaway")] MealTakeaway,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "mosque")] Mosque,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "movie_rental")] MovieRental,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "movie_theater")] MovieTheater,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "moving_company")] MovingCompany,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "museum")] Museum,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "night_club")] NightClub,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "painter")] Painter,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "park")] Park,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "parking")] Parking,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "pet_store")] PetStore,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "pharmacy")] Pharmacy,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "physiotherapist")] Physiotherapist,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "place_of_worship")] PlaceOfWorship,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "plumber")] Plumber,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "police")] Police,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "post_office")] PostOffice,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "real_estate_agency")] RealEstateAgency,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "restaurant")] Restaurant,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "roofing_contractor")] RoofingContractor,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "rv_park")] RvPark,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "school")] School,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "shoe_store")] ShoeStore,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "shopping_mall")] ShoppingMall,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "spa")] Spa,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "stadium")] Stadium,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "storage")] Storage,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "store")] Store,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "subway_station")] SubwayStation,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "synagogue")] Synagogue,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "taxi_stand")] TaxiStand,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "train_station")] TrainStation,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "travel_agency")] TravelAgency,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "university")] University,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "veterinary_care")] VeterinaryCare,

        /// <summary>
        /// 
        /// </summary>
        [EnumMember(Value = "zoo")] Zoo,
    }
}