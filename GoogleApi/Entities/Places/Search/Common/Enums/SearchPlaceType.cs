using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;

namespace GoogleApi.Entities.Places.Search.Common.Enums;

/// <summary>
/// Place Types
/// https://developers.google.com/places/supported_types#table1
/// </summary>
[JsonConverter(typeof(CustomJsonStringEnumConverter))]
public enum SearchPlaceType
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
    AmusementPark,

    /// <summary>
    /// Aquarium.
    /// </summary>
    [EnumMember(Value = "aquarium")]
    Aquarium,

    /// <summary>
    /// Art Gallery.
    /// </summary>
    [EnumMember(Value = "art_gallery")]
    ArtGallery,

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
    BeautySalon,

    /// <summary>
    /// Bicycle Store.
    /// </summary>
    [EnumMember(Value = "bicycle_store")]
    BicycleStore,

    /// <summary>
    /// Book Store.
    /// </summary>
    [EnumMember(Value = "book_store")]
    BookStore,

    /// <summary>
    /// Bowling Alley.
    /// </summary>
    [EnumMember(Value = "bowling_alley")]
    BowlingAlley,

    /// <summary>
    /// Bus Station.
    /// </summary>
    [EnumMember(Value = "bus_station")]
    BusStation,

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
    CarDealer,

    /// <summary>
    /// Car Rental.
    /// </summary>
    [EnumMember(Value = "car_rental")]
    CarRental,

    /// <summary>
    /// Car Repair.
    /// </summary>
    [EnumMember(Value = "car_repair")]
    CarRepair,

    /// <summary>
    /// Car Wash.
    /// </summary>
    [EnumMember(Value = "car_wash")]
    CarWash,

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
    CityHall,

    /// <summary>
    /// Clothing Store.
    /// </summary>
    [EnumMember(Value = "clothing_store")]
    ClothingStore,

    /// <summary>
    /// Convenience Store.
    /// </summary>
    [EnumMember(Value = "convenience_store")]
    ConvenienceStore,

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
    DepartmentStore,

    /// <summary>
    /// Doctor.
    /// </summary>
    [EnumMember(Value = "doctor")]
    Doctor,

    /// <summary>
    /// Embassy.
    /// </summary>
    [EnumMember(Value = "embassy")]
    Embassy,

    /// <summary>
    /// Electrician
    /// </summary>
    [EnumMember(Value = "electrician")]
    Electrician,

    /// <summary>
    /// Electronics Store.
    /// </summary>
    [EnumMember(Value = "electronics_store")]
    ElectronicsStore,

    /// <summary>
    /// Fire Station.
    /// </summary>
    [EnumMember(Value = "fire_station")]
    FireStation,

    /// <summary>
    /// Florist.
    /// </summary>
    [EnumMember(Value = "florist")]
    Florist,

    /// <summary>
    /// Funeral Home.
    /// </summary>
    [EnumMember(Value = "funeral_home")]
    FuneralHome,

    /// <summary>
    /// Furniture Store.
    /// </summary>
    [EnumMember(Value = "furniture_store")]
    FurnitureStore,

    /// <summary>
    /// Gas Station.
    /// </summary>
    [EnumMember(Value = "gas_station")]
    GasStation,

    /// <summary>
    /// Gym.
    /// </summary>
    [EnumMember(Value = "gym")]
    Gym,

    /// <summary>
    /// Hair Care.
    /// </summary>
    [EnumMember(Value = "hair_care")]
    HairCare,

    /// <summary>
    /// Hardware Store.
    /// </summary>
    [EnumMember(Value = "hardware_store")]
    HardwareStore,

    /// <summary>
    /// Hindu Temple.
    /// </summary>
    [EnumMember(Value = "hindu_temple")]
    HinduTemple,

    /// <summary>
    /// Home Goods Store.
    /// </summary>
    [EnumMember(Value = "home_goods_store")]
    HomeGoodsStore,

    /// <summary>
    /// Hospital.
    /// </summary>
    [EnumMember(Value = "hospital")]
    Hospital,

    /// <summary>
    /// Insurance Agency.
    /// </summary>
    [EnumMember(Value = "insurance_agency")]
    InsuranceAgency,

    /// <summary>
    /// Jewelry Store.
    /// </summary>
    [EnumMember(Value = "jewelry_store")]
    JewelryStore,

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
    /// Liquor Store.
    /// </summary>
    [EnumMember(Value = "liquor_store")]
    LiquorStore,

    /// <summary>
    /// Local Government Office.
    /// </summary>
    [EnumMember(Value = "local_government_office")]
    LocalGovernmentOffice,

    /// <summary>
    /// Locksmith
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
    MealDelivery,

    /// <summary>
    /// Meal Takeaway.
    /// </summary>
    [EnumMember(Value = "meal_takeaway")]
    MealTakeaway,

    /// <summary>
    /// Mosque.
    /// </summary>
    [EnumMember(Value = "mosque")]
    Mosque,

    /// <summary>
    /// Movie Rental.
    /// </summary>
    [EnumMember(Value = "movie_rental")]
    MovieRental,

    /// <summary>
    /// Movie Theater.
    /// </summary>
    [EnumMember(Value = "movie_theater")]
    MovieTheater,

    /// <summary>
    /// Moving Company.
    /// </summary>
    [EnumMember(Value = "moving_company")]
    MovingCompany,

    /// <summary>
    /// Museum.
    /// </summary>
    [EnumMember(Value = "museum")]
    Museum,

    /// <summary>
    /// Night Club.
    /// </summary>
    [EnumMember(Value = "night_club")]
    NightClub,

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
    PetStore,

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
    /// Primary School.
    /// </summary>
    [EnumMember(Value = "primary_school")]
    PrimarySchool,

    /// <summary>
    /// Real Estate Agency.
    /// </summary>
    [EnumMember(Value = "real_estate_agency")]
    RealEstateAgency,

    /// <summary>
    /// Restaurant.
    /// </summary>
    [EnumMember(Value = "restaurant")]
    Restaurant,

    /// <summary>
    /// Roofing Contractor.
    /// </summary>
    [EnumMember(Value = "roofing_contractor")]
    RoofingContractor,

    /// <summary>
    /// Rv Park.
    /// </summary>
    [EnumMember(Value = "rv_park")]
    RvPark,

    /// <summary>
    /// School.
    /// </summary>
    [EnumMember(Value = "school")]
    School,

    /// <summary>
    /// Secondary School.
    /// </summary>
    [EnumMember(Value = "secondary_school")]
    SecondarySchool,

    /// <summary>
    /// Shoe Store.
    /// </summary>
    [EnumMember(Value = "shoe_store")]
    ShoeStore,

    /// <summary>
    /// Shopping Mall.
    /// </summary>
    [EnumMember(Value = "shopping_mall")]
    ShoppingMall,

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
    /// Store.
    /// </summary>
    [EnumMember(Value = "store")]
    Store,

    /// <summary>
    /// Subway Station.
    /// </summary>
    [EnumMember(Value = "subway_station")]
    SubwayStation,

    /// <summary>
    /// Synagogue.
    /// </summary>
    [EnumMember(Value = "supermarket")]
    SuperMarket,

    /// <summary>
    /// Synagogue.
    /// </summary>
    [EnumMember(Value = "synagogue")]
    Synagogue,

    /// <summary>
    /// Taxi Stand.
    /// </summary>
    [EnumMember(Value = "taxi_stand")]
    TaxiStand,

    /// <summary>
    /// Train Station.
    /// </summary>
    [EnumMember(Value = "tourist_attraction")]
    TouristAttraction,

    /// <summary>
    /// Train Station.
    /// </summary>
    [EnumMember(Value = "train_station")]
    TrainStation,

    /// <summary>
    /// Train Station.
    /// </summary>
    [EnumMember(Value = "transit_station")]
    TransitStation,

    /// <summary>
    /// Travel Agency.
    /// </summary>
    [EnumMember(Value = "travel_agency")]
    TravelAgency,

    /// <summary>
    /// University.
    /// </summary>
    [EnumMember(Value = "university")]
    University,

    /// <summary>
    /// Veterinary Care.
    /// </summary>
    [EnumMember(Value = "veterinary_care")]
    VeterinaryCare,

    /// <summary>
    /// Zoo.
    /// </summary>
    [EnumMember(Value = "zoo")]
    Zoo
}