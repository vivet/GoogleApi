using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Enums.Converters;

namespace GoogleApi.Entities.Common.Enums;

/// <summary>
/// Place Location Types
/// https://developers.google.com/places/supported_types#table1
/// https://developers.google.com/places/supported_types#table2
/// </summary>
[JsonConverter(typeof(PlaceLocationTypeEnumJsonConverter))]
public enum PlaceLocationType
{
    /// <summary>
    /// Accounting.
    /// </summary>
    [EnumMember(Value = "accounting")]
    Accounting,

    /// <summary>
    /// Airport.
    /// </summary>
    [EnumMember(Value = "airport")]
    Airport,

    /// <summary>
    /// Amusement Park.
    /// </summary>
    [EnumMember(Value = "amusement_park")]
    Amusement_Park,

    /// <summary>
    /// Aquarium.
    /// </summary>
    [EnumMember(Value = "aquarium")]
    Aquarium,

    /// <summary>
    /// Art Gallery.
    /// </summary>
    [EnumMember(Value = "art_gallery")]
    Art_Gallery,

    /// <summary>
    /// Atm.
    /// </summary>
    [EnumMember(Value = "atm")]
    Atm,

    /// <summary>
    /// Bakery.
    /// </summary>
    [EnumMember(Value = "bakery")]
    Bakery,

    /// <summary>
    /// Bank.
    /// </summary>
    [EnumMember(Value = "bank")]
    Bank,

    /// <summary>
    /// Bar.
    /// </summary>
    [EnumMember(Value = "bar")]
    Bar,

    /// <summary>
    /// Beauty Salon.
    /// </summary>
    [EnumMember(Value = "beauty_salon")]
    Beauty_Salon,

    /// <summary>
    /// Bicycle Store.
    /// </summary>
    [EnumMember(Value = "bicycle_store")]
    Bicycle_Store,

    /// <summary>
    /// Book Store.
    /// </summary>
    [EnumMember(Value = "book_store")]
    Book_Store,

    /// <summary>
    /// Bowling Alley.
    /// </summary>
    [EnumMember(Value = "bowling_alley")]
    Bowling_Alley,

    /// <summary>
    /// Bus Station.
    /// </summary>
    [EnumMember(Value = "bus_station")]
    Bus_Station,

    /// <summary>
    /// Cafe.
    /// </summary>
    [EnumMember(Value = "cafe")]
    Cafe,

    /// <summary>
    /// Campground.
    /// </summary>
    [EnumMember(Value = "campground")]
    Campground,

    /// <summary>
    /// Car Dealer.
    /// </summary>
    [EnumMember(Value = "car_dealer")]
    Car_Dealer,

    /// <summary>
    /// Car Rental.
    /// </summary>
    [EnumMember(Value = "car_rental")]
    Car_Rental,

    /// <summary>
    /// Car Repair.
    /// </summary>
    [EnumMember(Value = "car_repair")]
    Car_Repair,

    /// <summary>
    /// Car Wash.
    /// </summary>
    [EnumMember(Value = "car_wash")]
    Car_Wash,

    /// <summary>
    /// Casino.
    /// </summary>
    [EnumMember(Value = "casino")]
    Casino,

    /// <summary>
    /// Cemetery.
    /// </summary>
    [EnumMember(Value = "cemetery")]
    Cemetery,

    /// <summary>
    /// Church.
    /// </summary>
    [EnumMember(Value = "church")]
    Church,

    /// <summary>
    /// City Hall.
    /// </summary>
    [EnumMember(Value = "city_hall")]
    City_Hall,

    /// <summary>
    /// Clothing Store.
    /// </summary>
    [EnumMember(Value = "clothing_store")]
    Clothing_Store,

    /// <summary>
    /// Convenience Store.
    /// </summary>
    [EnumMember(Value = "convenience_store")]
    Convenience_Store,

    /// <summary>
    /// Courthouse.
    /// </summary>
    [EnumMember(Value = "courthouse")]
    Courthouse,

    /// <summary>
    /// Dentist.
    /// </summary>
    [EnumMember(Value = "dentist")]
    Dentist,

    /// <summary>
    /// Department Store.
    /// </summary>
    [EnumMember(Value = "department_store")]
    Department_Store,

    /// <summary>
    /// Doctor.
    /// </summary>
    [EnumMember(Value = "doctor")]
    Doctor,

    /// <summary>
    /// Doctor.
    /// </summary>
    [EnumMember(Value = "drugstore")]
    DrugStore,

    /// <summary>
    /// Electrician.
    /// </summary>
    [EnumMember(Value = "electrician")]
    Electrician,

    /// <summary>
    /// Electronics Store.
    /// </summary>
    [EnumMember(Value = "electronics_store")]
    Electronics_Store,

    /// <summary>
    /// Embassy.
    /// </summary>
    [EnumMember(Value = "embassy")]
    Embassy,

    /// <summary>
    /// Fire Station.
    /// </summary>
    [EnumMember(Value = "fire_station")]
    Fire_Station,

    /// <summary>
    /// Florist.
    /// </summary>
    [EnumMember(Value = "florist")]
    Florist,

    /// <summary>
    /// Funeral Home.
    /// </summary>
    [EnumMember(Value = "funeral_home")]
    Funeral_Home,

    /// <summary>
    /// Furniture Store.
    /// </summary>
    [EnumMember(Value = "furniture_store")]
    Furniture_Store,

    /// <summary>
    /// Gas Station.
    /// </summary>
    [EnumMember(Value = "gas_station")]
    Gas_Station,

    /// <summary>
    /// Gym.
    /// </summary>
    [EnumMember(Value = "gym")]
    Gym,

    /// <summary>
    /// Hair Care.
    /// </summary>
    [EnumMember(Value = "hair_care")]
    Hair_Care,

    /// <summary>
    /// Hardware Store.
    /// </summary>
    [EnumMember(Value = "hardware_store")]
    Hardware_Store,

    /// <summary>
    /// Hindu Temple.
    /// </summary>
    [EnumMember(Value = "hindu_temple")]
    Hindu_Temple,

    /// <summary>
    /// Home Goods Store.
    /// </summary>
    [EnumMember(Value = "home_goods_store")]
    Home_Goods_Store,

    /// <summary>
    /// Hospital.
    /// </summary>
    [EnumMember(Value = "hospital")]
    Hospital,

    /// <summary>
    /// Insurance Agency.
    /// </summary>
    [EnumMember(Value = "insurance_agency")]
    Insurance_Agency,

    /// <summary>
    /// Jewelry Store.
    /// </summary>
    [EnumMember(Value = "jewelry_store")]
    Jewelry_Store,

    /// <summary>
    /// Laundry.
    /// </summary>
    [EnumMember(Value = "laundry")]
    Laundry,

    /// <summary>
    /// Lawyer.
    /// </summary>
    [EnumMember(Value = "lawyer")]
    Lawyer,

    /// <summary>
    /// Library.
    /// </summary>
    [EnumMember(Value = "library")]
    Library,

    /// <summary>
    /// Light Rail Station.
    /// </summary>
    [EnumMember(Value = "light_rail_station")]
    Light_Rail_Station,

    /// <summary>
    /// Liquor Store.
    /// </summary>
    [EnumMember(Value = "liquor_store")]
    Liquor_Store,

    /// <summary>
    /// Local Government Office.
    /// </summary>
    [EnumMember(Value = "local_government_office")]
    Local_Government_Office,

    /// <summary>
    /// Locksmith.
    /// </summary>
    [EnumMember(Value = "locksmith")]
    Locksmith,

    /// <summary>
    /// Lodging.
    /// </summary>
    [EnumMember(Value = "lodging")]
    Lodging,

    /// <summary>
    /// Meal Delivery.
    /// </summary>
    [EnumMember(Value = "meal_delivery")]
    Meal_Delivery,

    /// <summary>
    ///
    /// </summary>
    [EnumMember(Value = "meal_takeaway")]
    Meal_Takeaway,

    /// <summary>
    /// Mosque.
    /// </summary>
    [EnumMember(Value = "mosque")]
    Mosque,

    /// <summary>
    /// Movie Rental.
    /// </summary>
    [EnumMember(Value = "movie_rental")]
    Movie_Rental,

    /// <summary>
    /// Movie Theater.
    /// </summary>
    [EnumMember(Value = "movie_theater")]
    Movie_Theater,

    /// <summary>
    /// Moving Company.
    /// </summary>
    [EnumMember(Value = "moving_company")]
    Moving_Company,

    /// <summary>
    /// Museum.
    /// </summary>
    [EnumMember(Value = "museum")]
    Museum,

    /// <summary>
    /// Night Club.
    /// </summary>
    [EnumMember(Value = "night_club")]
    Night_Club,

    /// <summary>
    /// Painter.
    /// </summary>
    [EnumMember(Value = "painter")]
    Painter,

    /// <summary>
    /// Park.
    /// </summary>
    [EnumMember(Value = "park")]
    Park,

    /// <summary>
    /// Parking.
    /// </summary>
    [EnumMember(Value = "parking")]
    Parking,

    /// <summary>
    /// Pet Store.
    /// </summary>
    [EnumMember(Value = "pet_store")]
    Pet_Store,

    /// <summary>
    /// Pharmacy.
    /// </summary>
    [EnumMember(Value = "pharmacy")]
    Pharmacy,

    /// <summary>
    /// Physiotherapist.
    /// </summary>
    [EnumMember(Value = "physiotherapist")]
    Physiotherapist,

    /// <summary>
    /// Plumber.
    /// </summary>
    [EnumMember(Value = "plumber")]
    Plumber,

    /// <summary>
    /// Police.
    /// </summary>
    [EnumMember(Value = "police")]
    Police,

    /// <summary>
    /// Post Office.
    /// </summary>
    [EnumMember(Value = "post_office")]
    PostOffice,

    /// <summary>
    /// School.
    /// </summary>
    [EnumMember(Value = "primary_school")]
    Primary_School,

    /// <summary>
    /// Real Estate Agency.
    /// </summary>
    [EnumMember(Value = "real_estate_agency")]
    Real_Estate_Agency,

    /// <summary>
    /// Restaurant.
    /// </summary>
    [EnumMember(Value = "restaurant")]
    Restaurant,

    /// <summary>
    /// Roofing Contractor.
    /// </summary>
    [EnumMember(Value = "roofing_contractor")]
    Roofing_Contractor,

    /// <summary>
    /// Rv Park.
    /// </summary>
    [EnumMember(Value = "rv_park")]
    Rv_Park,

    /// <summary>
    /// School.
    /// </summary>
    [EnumMember(Value = "school")]
    School,

    /// <summary>
    ///
    /// </summary>
    [EnumMember(Value = "shoe_store")]
    Shoe_Store,

    /// <summary>
    /// Shopping Mall.
    /// </summary>
    [EnumMember(Value = "shopping_mall")]
    Shopping_Mall,

    /// <summary>
    /// Spa.
    /// </summary>
    [EnumMember(Value = "spa")]
    Spa,

    /// <summary>
    /// Stadium.
    /// </summary>
    [EnumMember(Value = "stadium")]
    Stadium,

    /// <summary>
    /// Storage.
    /// </summary>
    [EnumMember(Value = "storage")]
    Storage,

    /// <summary>
    /// Store-
    /// </summary>
    [EnumMember(Value = "store")]
    Store,

    /// <summary>
    /// Subway Station.
    /// </summary>
    [EnumMember(Value = "subway_station")]
    Subway_Station,

    /// <summary>
    /// Supermarket.
    /// </summary>
    [EnumMember(Value = "supermarket")]
    Supermarket,

    /// <summary>
    /// Synagogue.
    /// </summary>
    [EnumMember(Value = "synagogue")]
    Synagogue,

    /// <summary>
    /// Taxi Stand.
    /// </summary>
    [EnumMember(Value = "taxi_stand")]
    Taxi_Stand,

    /// <summary>
    /// Tourist Attracton.
    /// </summary>
    [EnumMember(Value = "tourist_attraction")]
    Tourist_Attracton,

    /// <summary>
    /// Train Station.
    /// </summary>
    [EnumMember(Value = "train_station")]
    Train_Station,

    /// <summary>
    /// Indicate the location of a public transit stop.
    /// </summary>
    [EnumMember(Value = "transit_station")]
    Transit_Station,

    /// <summary>
    /// Travel Agency.
    /// </summary>
    [EnumMember(Value = "travel_agency")]
    Travel_Agency,

    /// <summary>
    /// University.
    /// </summary>
    [EnumMember(Value = "university")]
    University,

    /// <summary>
    /// VeterinaryCare.
    /// </summary>
    [EnumMember(Value = "veterinary_care")]
    Veterinary_Care,

    /// <summary>
    /// Zoo.
    /// </summary>
    [EnumMember(Value = "zoo")]
    Zoo,

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
    /// Archipelago.
    /// </summary>
    [EnumMember(Value = "archipelago")]
    Archipelago,

    /// <summary>
    /// Indicates a commonly-used alternative name for the entity.
    /// </summary>
    [EnumMember(Value = "colloquial_area")]
    Colloquial_Area,

    /// <summary>
    /// Continent.
    /// </summary>
    [EnumMember(Value = "continent")]
    Continent,

    /// <summary>
    /// Indicates the national political entity, and is typically the highest order type returned by the Geocoder.
    /// </summary>
    [EnumMember(Value = "country")]
    Country,

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
    /// Indicates the floor of a building address.
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
    General_Contractor,

    /// <summary>
    /// Geocode instructs the Place Autocomplete service to return only geocoding results,
    /// rather than business results. Generally, you use this request to disambiguate results where the location specified may be indeterminate.
    /// </summary>
    [EnumMember(Value = "geocode")]
    Geocode,

    /// <summary>
    /// Health.
    /// </summary>
    [EnumMember(Value = "health")]
    Health,

    /// <summary>
    /// Indicates a major intersection, usually of two major roads.
    /// </summary>
    [EnumMember(Value = "intersection")]
    Intersection,

    /// <summary>
    /// Landmark.
    /// </summary>
    [EnumMember(Value = "landmark")]
    Landmark,

    /// <summary>
    /// Indicates an incorporated city or town political entity.
    /// </summary>
    [EnumMember(Value = "locality")]
    Locality,

    /// <summary>
    /// Indicates a prominent natural feature.
    /// </summary>
    [EnumMember(Value = "natural_feature")]
    Natural_Feature,

    /// <summary>
    /// Indicates a named neighborhood
    /// </summary>
    [EnumMember(Value = "neighborhood")]
    Neighborhood,

    /// <summary>
    /// Place Of Worship.
    /// </summary>
    [EnumMember(Value = "place_of_worship")]
    Place_Of_Worship,

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
    /// Indicates a named point of interest. Typically, these "POI"s are prominent local entities that don't easily fit in another category such as "Empire State Building" or "Statue of Liberty."
    /// </summary>
    [EnumMember(Value = "point_of_interest")]
    Point_Of_Interest,

    /// <summary>
    /// Indicates a political entity. Usually, this type indicates a polygon of some civil administration.
    /// </summary>
    [EnumMember(Value = "political")]
    Political,

    /// <summary>
    /// post_box indicates a specific postal box.
    /// </summary>
    [EnumMember(Value = "post_box")]
    Post_Box,

    /// <summary>
    /// Indicates a postal code as used to address postal mail within the country.
    /// </summary>
    [EnumMember(Value = "postal_code")]
    Postal_Code,

    /// <summary>
    /// Indicates a postal code prefix.
    /// </summary>
    [EnumMember(Value = "postal_code_prefix")]
    Postal_Code_Prefix,

    /// <summary>
    /// Indicates a postal code suffix.
    /// </summary>
    [EnumMember(Value = "postal_code_suffix")]
    Postal_Code_Suffix,

    /// <summary>
    /// postal_town indicates a grouping of geographic areas, such as locality and sublocality, used for mailing addresses in some countries.
    /// </summary>
    [EnumMember(Value = "postal_town")]
    Postal_Town,

    /// <summary>
    /// Indicates a named location, usually a building or collection of buildings with a common name.
    /// </summary>
    [EnumMember(Value = "premise")]
    Premise,

    /// <summary>
    /// room indicates the room of a building address.
    /// </summary>
    [EnumMember(Value = "room")]
    Room,

    /// <summary>
    /// Indicates a named route (such as "US 101").
    /// </summary>
    [EnumMember(Value = "route")]
    Route,

    /// <summary>
    /// Indicates a precise street address.
    /// </summary>
    [EnumMember(Value = "street_address")]
    Street_Address,

    /// <summary>
    /// street_number indicates the precise street number.
    /// </summary>
    [EnumMember(Value = "street_number")]
    Street_Number,

    /// <summary>
    /// locality.
    /// </summary>
    [EnumMember(Value = "sublocality")]
    Sublocality,

    /// <summary>
    /// indicates an first-order civil entity below a locality.
    /// </summary>
    [EnumMember(Value = "sublocality_level_1")]
    Sublocality_Level_1,

    /// <summary>
    /// indicates an second-order civil entity below a locality.
    /// </summary>
    [EnumMember(Value = "sublocality_level_2")]
    Sublocality_Level_2,

    /// <summary>
    /// indicates an third-order civil entity below a locality.
    /// </summary>
    [EnumMember(Value = "sublocality_level_3")]
    Sublocality_Level_3,

    /// <summary>
    /// indicates an first-order civil entity below a locality.
    /// </summary>
    [EnumMember(Value = "sublocality_level_4")]
    Sublocality_Level_4,

    /// <summary>
    /// indicates an first-order civil entity below a locality.
    /// </summary>
    [EnumMember(Value = "sublocality_level_5")]
    Sublocality_Level_5,

    /// <summary>
    /// Indicates a first-order entity below a named location, usually a singular building within a collection of buildings with a common name.
    /// </summary>
    [EnumMember(Value = "subpremise")]
    Subpremise,

    /// <summary>
    /// Town Square.
    /// </summary>
    [EnumMember(Value = "town_square")]
    Town_Square,

    /// <summary>
    /// Grocery Or Supermarket.
    /// </summary>
    [EnumMember(Value = "grocery_or_supermarket")]
    Grocery_Or_Supermarket,

    /// <summary>
    /// Unknown is set when unmapped place location types is returned.
    /// </summary>
    [EnumMember(Value = "unknown")]
    Unknown
}