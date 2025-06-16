using System.Runtime.Serialization;

namespace GoogleApi.Entities.PlacesNew.Common.Enums;

/// <summary>
/// Place Location Type A and B.
/// https://developers.google.com/maps/documentation/places/web-service/place-types#table-a
/// https://developers.google.com/maps/documentation/places/web-service/place-types#table-b
/// </summary>
public enum PlaceLocationTypeAb
{
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
    /// Electric Vehicle Charging Station.
    /// </summary>
    [EnumMember(Value = "electric_vehicle_charging_station")]
    ElectricVehicleChargingStation,

    /// <summary>
    /// Gas Station.
    /// </summary>
    [EnumMember(Value = "gas_station")]
    GasStation,

    /// <summary>
    /// Parking.
    /// </summary>
    [EnumMember(Value = "parking")]
    Parking,

    /// <summary>
    /// Rest Stop.
    /// </summary>
    [EnumMember(Value = "rest_stop")]
    RestStop,

    /// <summary>
    /// Corporate Office.
    /// </summary>
    [EnumMember(Value = "corporate_office")]
    CorporateOffice,

    /// <summary>
    /// Farm.
    /// </summary>
    [EnumMember(Value = "farm")]
    Farm,

    /// <summary>
    /// Ranch.
    /// </summary>
    [EnumMember(Value = "ranch")]
    Ranch,

    /// <summary>
    /// Art Gallery.
    /// </summary>
    [EnumMember(Value = "art_gallery")]
    ArtGallery,

    /// <summary>
    /// Art Studio.
    /// </summary>
    [EnumMember(Value = "art_studio")]
    ArtStudio,

    /// <summary>
    /// Auditorium.
    /// </summary>
    [EnumMember(Value = "auditorium")]
    Auditorium,

    /// <summary>
    /// Cultural Landmark.
    /// </summary>
    [EnumMember(Value = "cultural_landmark")]
    CulturalLandmark,

    /// <summary>
    /// Historical Place.
    /// </summary>
    [EnumMember(Value = "historical_place")]
    HistoricalPlace,

    /// <summary>
    /// Monument.
    /// </summary>
    [EnumMember(Value = "monument")]
    Monument,

    /// <summary>
    /// Museum.
    /// </summary>
    [EnumMember(Value = "museum")]
    Museum,

    /// <summary>
    /// Performing Arts Theater.
    /// </summary>
    [EnumMember(Value = "performing_arts_theater")]
    PerformingArtsTheater,

    /// <summary>
    /// Sculpture.
    /// </summary>
    [EnumMember(Value = "sculpture")]
    Sculpture,

    /// <summary>
    /// Library.
    /// </summary>
    [EnumMember(Value = "library")]
    Library,

    /// <summary>
    /// Preschool.
    /// </summary>
    [EnumMember(Value = "preschool")]
    Preschool,

    /// <summary>
    /// Primary School.
    /// </summary>
    [EnumMember(Value = "primary_school")]
    PrimarySchool,

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
    /// University.
    /// </summary>
    [EnumMember(Value = "university")]
    University,

    /// <summary>
    /// Adventure Sports Center.
    /// </summary>
    [EnumMember(Value = "adventure_sports_center")]
    AdventureSportsCenter,

    /// <summary>
    /// Amphitheatre.
    /// </summary>
    [EnumMember(Value = "amphitheatre")]
    Amphitheatre,

    /// <summary>
    /// Amusement Center.
    /// </summary>
    [EnumMember(Value = "amusement_center")]
    AmusementCenter,

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
    /// Banquet Hall.
    /// </summary>
    [EnumMember(Value = "banquet_hall")]
    BanquetHall,

    /// <summary>
    /// Barbecue Area.
    /// </summary>
    [EnumMember(Value = "barbecue_area")]
    BarbecueArea,

    /// <summary>
    /// Botanical Garden.
    /// </summary>
    [EnumMember(Value = "botanical_garden")]
    BotanicalGarden,

    /// <summary>
    /// Bowling Alley.
    /// </summary>
    [EnumMember(Value = "bowling_alley")]
    BowlingAlley,

    /// <summary>
    /// Casino.
    /// </summary>
    [EnumMember(Value = "casino")]
    Casino,

    /// <summary>
    /// Children's Camp.
    /// </summary>
    [EnumMember(Value = "childrens_camp")]
    ChildrensCamp,

    /// <summary>
    /// Comedy Club.
    /// </summary>
    [EnumMember(Value = "comedy_club")]
    ComedyClub,

    /// <summary>
    /// Community Center.
    /// </summary>
    [EnumMember(Value = "community_center")]
    CommunityCenter,

    /// <summary>
    /// Concert Hall.
    /// </summary>
    [EnumMember(Value = "concert_hall")]
    ConcertHall,

    /// <summary>
    /// Convention Center.
    /// </summary>
    [EnumMember(Value = "convention_center")]
    ConventionCenter,

    /// <summary>
    /// Cultural Center.
    /// </summary>
    [EnumMember(Value = "cultural_center")]
    CulturalCenter,

    /// <summary>
    /// Cycling Park.
    /// </summary>
    [EnumMember(Value = "cycling_park")]
    CyclingPark,

    /// <summary>
    /// Dance Hall.
    /// </summary>
    [EnumMember(Value = "dance_hall")]
    DanceHall,

    /// <summary>
    /// Dog Park.
    /// </summary>
    [EnumMember(Value = "dog_park")]
    DogPark,

    /// <summary>
    /// Event Venue.
    /// </summary>
    [EnumMember(Value = "event_venue")]
    EventVenue,

    /// <summary>
    /// Ferris Wheel.
    /// </summary>
    [EnumMember(Value = "ferris_wheel")]
    FerrisWheel,

    /// <summary>
    /// Garden.
    /// </summary>
    [EnumMember(Value = "garden")]
    Garden,

    /// <summary>
    /// Hiking Area.
    /// </summary>
    [EnumMember(Value = "hiking_area")]
    HikingArea,

    /// <summary>
    /// Historical Landmark.
    /// </summary>
    [EnumMember(Value = "historical_landmark")]
    HistoricalLandmark,

    /// <summary>
    /// Internet Cafe.
    /// </summary>
    [EnumMember(Value = "internet_cafe")]
    InternetCafe,

    /// <summary>
    /// Karaoke.
    /// </summary>
    [EnumMember(Value = "karaoke")]
    Karaoke,

    /// <summary>
    /// Marina.
    /// </summary>
    [EnumMember(Value = "marina")]
    Marina,

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
    /// National Park.
    /// </summary>
    [EnumMember(Value = "national_park")]
    NationalPark,

    /// <summary>
    /// Night Club.
    /// </summary>
    [EnumMember(Value = "night_club")]
    NightClub,

    /// <summary>
    /// Observation Deck.
    /// </summary>
    [EnumMember(Value = "observation_deck")]
    ObservationDeck,

    /// <summary>
    /// Off-Roading Area.
    /// </summary>
    [EnumMember(Value = "off_roading_area")]
    OffRoadingArea,

    /// <summary>
    /// Opera House.
    /// </summary>
    [EnumMember(Value = "opera_house")]
    OperaHouse,

    /// <summary>
    /// Park.
    /// </summary>
    [EnumMember(Value = "park")]
    Park,

    /// <summary>
    /// Philharmonic Hall.
    /// </summary>
    [EnumMember(Value = "philharmonic_hall")]
    PhilharmonicHall,

    /// <summary>
    /// Picnic Ground.
    /// </summary>
    [EnumMember(Value = "picnic_ground")]
    PicnicGround,

    /// <summary>
    /// Planetarium.
    /// </summary>
    [EnumMember(Value = "planetarium")]
    Planetarium,

    /// <summary>
    /// Plaza.
    /// </summary>
    [EnumMember(Value = "plaza")]
    Plaza,

    /// <summary>
    /// Roller Coaster.
    /// </summary>
    [EnumMember(Value = "roller_coaster")]
    RollerCoaster,

    /// <summary>
    /// Skateboard Park.
    /// </summary>
    [EnumMember(Value = "skateboard_park")]
    SkateboardPark,

    /// <summary>
    /// State Park.
    /// </summary>
    [EnumMember(Value = "state_park")]
    StatePark,

    /// <summary>
    /// Tourist Attraction.
    /// </summary>
    [EnumMember(Value = "tourist_attraction")]
    TouristAttraction,

    /// <summary>
    /// Video Arcade.
    /// </summary>
    [EnumMember(Value = "video_arcade")]
    VideoArcade,

    /// <summary>
    /// Visitor Center.
    /// </summary>
    [EnumMember(Value = "visitor_center")]
    VisitorCenter,

    /// <summary>
    /// Water Park.
    /// </summary>
    [EnumMember(Value = "water_park")]
    WaterPark,

    /// <summary>
    /// Wedding Venue.
    /// </summary>
    [EnumMember(Value = "wedding_venue")]
    WeddingVenue,

    /// <summary>
    /// Wildlife Park.
    /// </summary>
    [EnumMember(Value = "wildlife_park")]
    WildlifePark,

    /// <summary>
    /// Wildlife Refuge.
    /// </summary>
    [EnumMember(Value = "wildlife_refuge")]
    WildlifeRefuge,

    /// <summary>
    /// Zoo.
    /// </summary>
    [EnumMember(Value = "zoo")]
    Zoo,

    /// <summary>
    /// Public Bath.
    /// </summary>
    [EnumMember(Value = "public_bath")]
    PublicBath,

    /// <summary>
    /// Public Bathroom.
    /// </summary>
    [EnumMember(Value = "public_bathroom")]
    PublicBathroom,

    /// <summary>
    /// Stable.
    /// </summary>
    [EnumMember(Value = "stable")]
    Stable,

    /// <summary>
    /// Accounting.
    /// </summary>
    [EnumMember(Value = "accounting")]
    Accounting,

    /// <summary>
    /// ATM.
    /// </summary>
    [EnumMember(Value = "atm")]
    ATM,

    /// <summary>
    /// Bank.
    /// </summary>
    [EnumMember(Value = "bank")]
    Bank,

    /// <summary>
    /// Acai Shop.
    /// </summary>
    [EnumMember(Value = "acai_shop")]
    AcaiShop,

    /// <summary>
    /// Afghani Restaurant.
    /// </summary>
    [EnumMember(Value = "afghani_restaurant")]
    AfghaniRestaurant,

    /// <summary>
    /// African Restaurant.
    /// </summary>
    [EnumMember(Value = "african_restaurant")]
    AfricanRestaurant,

    /// <summary>
    /// American Restaurant.
    /// </summary>
    [EnumMember(Value = "american_restaurant")]
    AmericanRestaurant,

    /// <summary>
    /// Asian Restaurant.
    /// </summary>
    [EnumMember(Value = "asian_restaurant")]
    AsianRestaurant,

    /// <summary>
    /// Bagel Shop.
    /// </summary>
    [EnumMember(Value = "bagel_shop")]
    BagelShop,

    /// <summary>
    /// Bakery.
    /// </summary>
    [EnumMember(Value = "bakery")]
    Bakery,

    /// <summary>
    /// Bar.
    /// </summary>
    [EnumMember(Value = "bar")]
    Bar,

    /// <summary>
    /// Bar and Grill.
    /// </summary>
    [EnumMember(Value = "bar_and_grill")]
    BarAndGrill,

    /// <summary>
    /// Barbecue Restaurant.
    /// </summary>
    [EnumMember(Value = "barbecue_restaurant")]
    BarbecueRestaurant,

    /// <summary>
    /// Brazilian Restaurant.
    /// </summary>
    [EnumMember(Value = "brazilian_restaurant")]
    BrazilianRestaurant,

    /// <summary>
    /// Breakfast Restaurant.
    /// </summary>
    [EnumMember(Value = "breakfast_restaurant")]
    BreakfastRestaurant,

    /// <summary>
    /// Brunch Restaurant.
    /// </summary>
    [EnumMember(Value = "brunch_restaurant")]
    BrunchRestaurant,

    /// <summary>
    /// Buffet Restaurant.
    /// </summary>
    [EnumMember(Value = "buffet_restaurant")]
    BuffetRestaurant,

    /// <summary>
    /// Cafe.
    /// </summary>
    [EnumMember(Value = "cafe")]
    Cafe,

    /// <summary>
    /// Cafeteria.
    /// </summary>
    [EnumMember(Value = "cafeteria")]
    Cafeteria,

    /// <summary>
    /// Candy Store.
    /// </summary>
    [EnumMember(Value = "candy_store")]
    CandyStore,

    /// <summary>
    /// Cat Cafe.
    /// </summary>
    [EnumMember(Value = "cat_cafe")]
    CatCafe,

    /// <summary>
    /// Chinese Restaurant.
    /// </summary>
    [EnumMember(Value = "chinese_restaurant")]
    ChineseRestaurant,

    /// <summary>
    /// Chocolate Factory.
    /// </summary>
    [EnumMember(Value = "chocolate_factory")]
    ChocolateFactory,

    /// <summary>
    /// Chocolate Shop.
    /// </summary>
    [EnumMember(Value = "chocolate_shop")]
    ChocolateShop,

    /// <summary>
    /// Coffee Shop.
    /// </summary>
    [EnumMember(Value = "coffee_shop")]
    CoffeeShop,

    /// <summary>
    /// Confectionery.
    /// </summary>
    [EnumMember(Value = "confectionery")]
    Confectionery,

    /// <summary>
    /// Deli.
    /// </summary>
    [EnumMember(Value = "deli")]
    Deli,

    /// <summary>
    /// Dessert Restaurant.
    /// </summary>
    [EnumMember(Value = "dessert_restaurant")]
    DessertRestaurant,

    /// <summary>
    /// Dessert Shop.
    /// </summary>
    [EnumMember(Value = "dessert_shop")]
    DessertShop,

    /// <summary>
    /// Diner.
    /// </summary>
    [EnumMember(Value = "diner")]
    Diner,

    /// <summary>
    /// Dog Cafe.
    /// </summary>
    [EnumMember(Value = "dog_cafe")]
    DogCafe,

    /// <summary>
    /// Donut Shop.
    /// </summary>
    [EnumMember(Value = "donut_shop")]
    DonutShop,

    /// <summary>
    /// Fast Food Restaurant.
    /// </summary>
    [EnumMember(Value = "fast_food_restaurant")]
    FastFoodRestaurant,

    /// <summary>
    /// Fine Dining Restaurant.
    /// </summary>
    [EnumMember(Value = "fine_dining_restaurant")]
    FineDiningRestaurant,

    /// <summary>
    /// Food Court.
    /// </summary>
    [EnumMember(Value = "food_court")]
    FoodCourt,

    /// <summary>
    /// French Restaurant.
    /// </summary>
    [EnumMember(Value = "french_restaurant")]
    FrenchRestaurant,

    /// <summary>
    /// Greek Restaurant.
    /// </summary>
    [EnumMember(Value = "greek_restaurant")]
    GreekRestaurant,

    /// <summary>
    /// Hamburger Restaurant.
    /// </summary>
    [EnumMember(Value = "hamburger_restaurant")]
    HamburgerRestaurant,

    /// <summary>
    /// Ice Cream Shop.
    /// </summary>
    [EnumMember(Value = "ice_cream_shop")]
    IceCreamShop,

    /// <summary>
    /// Indian Restaurant.
    /// </summary>
    [EnumMember(Value = "indian_restaurant")]
    IndianRestaurant,

    /// <summary>
    /// Indonesian Restaurant.
    /// </summary>
    [EnumMember(Value = "indonesian_restaurant")]
    IndonesianRestaurant,

    /// <summary>
    /// Italian Restaurant.
    /// </summary>
    [EnumMember(Value = "italian_restaurant")]
    ItalianRestaurant,

    /// <summary>
    /// Japanese Restaurant.
    /// </summary>
    [EnumMember(Value = "japanese_restaurant")]
    JapaneseRestaurant,

    /// <summary>
    /// Juice Shop.
    /// </summary>
    [EnumMember(Value = "juice_shop")]
    JuiceShop,

    /// <summary>
    /// Korean Restaurant.
    /// </summary>
    [EnumMember(Value = "korean_restaurant")]
    KoreanRestaurant,

    /// <summary>
    /// Lebanese Restaurant.
    /// </summary>
    [EnumMember(Value = "lebanese_restaurant")]
    LebaneseRestaurant,

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
    /// Mediterranean Restaurant.
    /// </summary>
    [EnumMember(Value = "mediterranean_restaurant")]
    MediterraneanRestaurant,

    /// <summary>
    /// Mexican Restaurant.
    /// </summary>
    [EnumMember(Value = "mexican_restaurant")]
    MexicanRestaurant,

    /// <summary>
    /// Middle Eastern Restaurant.
    /// </summary>
    [EnumMember(Value = "middle_eastern_restaurant")]
    MiddleEasternRestaurant,

    /// <summary>
    /// Pizza Restaurant.
    /// </summary>
    [EnumMember(Value = "pizza_restaurant")]
    PizzaRestaurant,

    /// <summary>
    /// Pub.
    /// </summary>
    [EnumMember(Value = "pub")]
    Pub,

    /// <summary>
    /// Ramen Restaurant.
    /// </summary>
    [EnumMember(Value = "ramen_restaurant")]
    RamenRestaurant,

    /// <summary>
    /// Restaurant.
    /// </summary>
    [EnumMember(Value = "restaurant")]
    Restaurant,

    /// <summary>
    /// Sandwich Shop.
    /// </summary>
    [EnumMember(Value = "sandwich_shop")]
    SandwichShop,

    /// <summary>
    /// Seafood Restaurant.
    /// </summary>
    [EnumMember(Value = "seafood_restaurant")]
    SeafoodRestaurant,

    /// <summary>
    /// Spanish Restaurant.
    /// </summary>
    [EnumMember(Value = "spanish_restaurant")]
    SpanishRestaurant,

    /// <summary>
    /// Steak House.
    /// </summary>
    [EnumMember(Value = "steak_house")]
    SteakHouse,

    /// <summary>
    /// Sushi Restaurant.
    /// </summary>
    [EnumMember(Value = "sushi_restaurant")]
    SushiRestaurant,

    /// <summary>
    /// Tea House.
    /// </summary>
    [EnumMember(Value = "tea_house")]
    TeaHouse,

    /// <summary>
    /// Thai Restaurant.
    /// </summary>
    [EnumMember(Value = "thai_restaurant")]
    ThaiRestaurant,

    /// <summary>
    /// Turkish Restaurant.
    /// </summary>
    [EnumMember(Value = "turkish_restaurant")]
    TurkishRestaurant,

    /// <summary>
    /// Vegan Restaurant.
    /// </summary>
    [EnumMember(Value = "vegan_restaurant")]
    VeganRestaurant,

    /// <summary>
    /// Vegetarian Restaurant.
    /// </summary>
    [EnumMember(Value = "vegetarian_restaurant")]
    VegetarianRestaurant,

    /// <summary>
    /// Vietnamese Restaurant.
    /// </summary>
    [EnumMember(Value = "vietnamese_restaurant")]
    VietnameseRestaurant,

    /// <summary>
    /// Wine Bar.
    /// </summary>
    [EnumMember(Value = "wine_bar")]
    WineBar,

    /// <summary>
    /// Administrative Area Level 1.
    /// </summary>
    [EnumMember(Value = "administrative_area_level_1")]
    AdministrativeAreaLevel1,

    /// <summary>
    /// Administrative Area Level 2.
    /// </summary>
    [EnumMember(Value = "administrative_area_level_2")]
    AdministrativeAreaLevel2,

    /// <summary>
    /// Country.
    /// </summary>
    [EnumMember(Value = "country")]
    Country,

    /// <summary>
    /// Locality.
    /// </summary>
    [EnumMember(Value = "locality")]
    Locality,

    /// <summary>
    /// Postal Code.
    /// </summary>
    [EnumMember(Value = "postal_code")]
    PostalCode,

    /// <summary>
    /// School District.
    /// </summary>
    [EnumMember(Value = "school_district")]
    SchoolDistrict,

    /// <summary>
    /// City Hall.
    /// </summary>
    [EnumMember(Value = "city_hall")]
    CityHall,

    /// <summary>
    /// Courthouse.
    /// </summary>
    [EnumMember(Value = "courthouse")]
    Courthouse,

    /// <summary>
    /// Embassy.
    /// </summary>
    [EnumMember(Value = "embassy")]
    Embassy,

    /// <summary>
    /// Fire Station.
    /// </summary>
    [EnumMember(Value = "fire_station")]
    FireStation,

    /// <summary>
    /// Government Office.
    /// </summary>
    [EnumMember(Value = "government_office")]
    GovernmentOffice,

    /// <summary>
    /// Local Government Office.
    /// </summary>
    [EnumMember(Value = "local_government_office")]
    LocalGovernmentOffice,

    /// <summary>
    /// Neighborhood Police Station (Japan only).
    /// </summary>
    [EnumMember(Value = "neighborhood_police_station")]
    NeighborhoodPoliceStation,

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
    /// Chiropractor.
    /// </summary>
    [EnumMember(Value = "chiropractor")]
    Chiropractor,

    /// <summary>
    /// Dental Clinic.
    /// </summary>
    [EnumMember(Value = "dental_clinic")]
    DentalClinic,

    /// <summary>
    /// Dentist.
    /// </summary>
    [EnumMember(Value = "dentist")]
    Dentist,

    /// <summary>
    /// Doctor.
    /// </summary>
    [EnumMember(Value = "doctor")]
    Doctor,

    /// <summary>
    /// Drugstore.
    /// </summary>
    [EnumMember(Value = "drugstore")]
    Drugstore,

    /// <summary>
    /// Hospital.
    /// </summary>
    [EnumMember(Value = "hospital")]
    Hospital,

    /// <summary>
    /// Massage.
    /// </summary>
    [EnumMember(Value = "massage")]
    Massage,

    /// <summary>
    /// Medical Lab.
    /// </summary>
    [EnumMember(Value = "medical_lab")]
    MedicalLab,

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
    /// Sauna.
    /// </summary>
    [EnumMember(Value = "sauna")]
    Sauna,

    /// <summary>
    /// Skin Care Clinic.
    /// </summary>
    [EnumMember(Value = "skin_care_clinic")]
    SkinCareClinic,

    /// <summary>
    /// Spa.
    /// </summary>
    [EnumMember(Value = "spa")]
    Spa,

    /// <summary>
    /// Tanning Studio.
    /// </summary>
    [EnumMember(Value = "tanning_studio")]
    TanningStudio,

    /// <summary>
    /// Wellness Center.
    /// </summary>
    [EnumMember(Value = "wellness_center")]
    WellnessCenter,

    /// <summary>
    /// Yoga Studio.
    /// </summary>
    [EnumMember(Value = "yoga_studio")]
    YogaStudio,

    /// <summary>
    /// Apartment Building.
    /// </summary>
    [EnumMember(Value = "apartment_building")]
    ApartmentBuilding,

    /// <summary>
    /// Apartment Complex.
    /// </summary>
    [EnumMember(Value = "apartment_complex")]
    ApartmentComplex,

    /// <summary>
    /// Condominium Complex.
    /// </summary>
    [EnumMember(Value = "condominium_complex")]
    CondominiumComplex,

    /// <summary>
    /// Housing Complex.
    /// </summary>
    [EnumMember(Value = "housing_complex")]
    HousingComplex,

    /// <summary>
    /// Bed and Breakfast.
    /// </summary>
    [EnumMember(Value = "bed_and_breakfast")]
    BedAndBreakfast,

    /// <summary>
    /// Budget Japanese Inn.
    /// </summary>
    [EnumMember(Value = "budget_japanese_inn")]
    BudgetJapaneseInn,

    /// <summary>
    /// Campground.
    /// </summary>
    [EnumMember(Value = "campground")]
    Campground,

    /// <summary>
    /// Camping Cabin.
    /// </summary>
    [EnumMember(Value = "camping_cabin")]
    CampingCabin,

    /// <summary>
    /// Cottage.
    /// </summary>
    [EnumMember(Value = "cottage")]
    Cottage,

    /// <summary>
    /// Extended Stay Hotel.
    /// </summary>
    [EnumMember(Value = "extended_stay_hotel")]
    ExtendedStayHotel,

    /// <summary>
    /// Farmstay.
    /// </summary>
    [EnumMember(Value = "farmstay")]
    Farmstay,

    /// <summary>
    /// Guest House.
    /// </summary>
    [EnumMember(Value = "guest_house")]
    GuestHouse,

    /// <summary>
    /// Hostel.
    /// </summary>
    [EnumMember(Value = "hostel")]
    Hostel,

    /// <summary>
    /// Hotel.
    /// </summary>
    [EnumMember(Value = "hotel")]
    Hotel,

    /// <summary>
    /// Inn.
    /// </summary>
    [EnumMember(Value = "inn")]
    Inn,

    /// <summary>
    /// Japanese Inn.
    /// </summary>
    [EnumMember(Value = "japanese_inn")]
    JapaneseInn,

    /// <summary>
    /// Lodging.
    /// </summary>
    [EnumMember(Value = "lodging")]
    Lodging,

    /// <summary>
    /// Mobile Home Park.
    /// </summary>
    [EnumMember(Value = "mobile_home_park")]
    MobileHomePark,

    /// <summary>
    /// Motel.
    /// </summary>
    [EnumMember(Value = "motel")]
    Motel,

    /// <summary>
    /// Private Guest Room.
    /// </summary>
    [EnumMember(Value = "private_guest_room")]
    PrivateGuestRoom,

    /// <summary>
    /// Resort Hotel.
    /// </summary>
    [EnumMember(Value = "resort_hotel")]
    ResortHotel,

    /// <summary>
    /// RV Park.
    /// </summary>
    [EnumMember(Value = "rv_park")]
    RvPark,

    /// <summary>
    /// Beach.
    /// </summary>
    [EnumMember(Value = "beach")]
    Beach,

    /// <summary>
    /// Church.
    /// </summary>
    [EnumMember(Value = "church")]
    Church,

    /// <summary>
    /// Hindu Temple.
    /// </summary>
    [EnumMember(Value = "hindu_temple")]
    HinduTemple,

    /// <summary>
    /// Mosque.
    /// </summary>
    [EnumMember(Value = "mosque")]
    Mosque,

    /// <summary>
    /// Synagogue.
    /// </summary>
    [EnumMember(Value = "synagogue")]
    Synagogue,

    /// <summary>
    /// Astrologer.
    /// </summary>
    [EnumMember(Value = "astrologer")]
    Astrologer,

    /// <summary>
    /// Barber Shop.
    /// </summary>
    [EnumMember(Value = "barber_shop")]
    BarberShop,

    /// <summary>
    /// Beautician.
    /// </summary>
    [EnumMember(Value = "beautician")]
    Beautician,

    /// <summary>
    /// Beauty Salon.
    /// </summary>
    [EnumMember(Value = "beauty_salon")]
    BeautySalon,

    /// <summary>
    /// Body Art Service.
    /// </summary>
    [EnumMember(Value = "body_art_service")]
    BodyArtService,

    /// <summary>
    /// Catering Service.
    /// </summary>
    [EnumMember(Value = "catering_service")]
    CateringService,

    /// <summary>
    /// Cemetery.
    /// </summary>
    [EnumMember(Value = "cemetery")]
    Cemetery,

    /// <summary>
    /// Child Care Agency.
    /// </summary>
    [EnumMember(Value = "child_care_agency")]
    ChildCareAgency,

    /// <summary>
    /// Consultant.
    /// </summary>
    [EnumMember(Value = "consultant")]
    Consultant,

    /// <summary>
    /// Courier Service.
    /// </summary>
    [EnumMember(Value = "courier_service")]
    CourierService,

    /// <summary>
    /// Electrician.
    /// </summary>
    [EnumMember(Value = "electrician")]
    Electrician,

    /// <summary>
    /// Florist.
    /// </summary>
    [EnumMember(Value = "florist")]
    Florist,

    /// <summary>
    /// Food Delivery.
    /// </summary>
    [EnumMember(Value = "food_delivery")]
    FoodDelivery,

    /// <summary>
    /// Foot Care.
    /// </summary>
    [EnumMember(Value = "foot_care")]
    FootCare,

    /// <summary>
    /// Funeral Home.
    /// </summary>
    [EnumMember(Value = "funeral_home")]
    FuneralHome,

    /// <summary>
    /// Hair Care.
    /// </summary>
    [EnumMember(Value = "hair_care")]
    HairCare,

    /// <summary>
    /// Hair Salon.
    /// </summary>
    [EnumMember(Value = "hair_salon")]
    HairSalon,

    /// <summary>
    /// Insurance Agency.
    /// </summary>
    [EnumMember(Value = "insurance_agency")]
    InsuranceAgency,

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
    /// Locksmith.
    /// </summary>
    [EnumMember(Value = "locksmith")]
    Locksmith,

    /// <summary>
    /// Makeup Artist.
    /// </summary>
    [EnumMember(Value = "makeup_artist")]
    MakeupArtist,

    /// <summary>
    /// Moving Company.
    /// </summary>
    [EnumMember(Value = "moving_company")]
    MovingCompany,

    /// <summary>
    /// Nail Salon.
    /// </summary>
    [EnumMember(Value = "nail_salon")]
    NailSalon,

    /// <summary>
    /// Painter.
    /// </summary>
    [EnumMember(Value = "painter")]
    Painter,

    /// <summary>
    /// Plumber.
    /// </summary>
    [EnumMember(Value = "plumber")]
    Plumber,

    /// <summary>
    /// Psychic.
    /// </summary>
    [EnumMember(Value = "psychic")]
    Psychic,

    /// <summary>
    /// Real Estate Agency.
    /// </summary>
    [EnumMember(Value = "real_estate_agency")]
    RealEstateAgency,

    /// <summary>
    /// Roofing Contractor.
    /// </summary>
    [EnumMember(Value = "roofing_contractor")]
    RoofingContractor,

    /// <summary>
    /// Storage.
    /// </summary>
    [EnumMember(Value = "storage")]
    Storage,

    /// <summary>
    /// Summer Camp Organizer.
    /// </summary>
    [EnumMember(Value = "summer_camp_organizer")]
    SummerCampOrganizer,

    /// <summary>
    /// Tailor.
    /// </summary>
    [EnumMember(Value = "tailor")]
    Tailor,

    /// <summary>
    /// Telecommunications Service Provider.
    /// </summary>
    [EnumMember(Value = "telecommunications_service_provider")]
    TelecommunicationsServiceProvider,

    /// <summary>
    /// Tour Agency.
    /// </summary>
    [EnumMember(Value = "tour_agency")]
    TourAgency,

    /// <summary>
    /// Tourist Information Center.
    /// </summary>
    [EnumMember(Value = "tourist_information_center")]
    TouristInformationCenter,

    /// <summary>
    /// Travel Agency.
    /// </summary>
    [EnumMember(Value = "travel_agency")]
    TravelAgency,

    /// <summary>
    /// Veterinary Care.
    /// </summary>
    [EnumMember(Value = "veterinary_care")]
    VeterinaryCare,

    /// <summary>
    /// Asian Grocery Store.
    /// </summary>
    [EnumMember(Value = "asian_grocery_store")]
    AsianGroceryStore,

    /// <summary>
    /// Auto Parts Store.
    /// </summary>
    [EnumMember(Value = "auto_parts_store")]
    AutoPartsStore,

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
    /// Butcher Shop.
    /// </summary>
    [EnumMember(Value = "butcher_shop")]
    ButcherShop,

    /// <summary>
    /// Cell Phone Store.
    /// </summary>
    [EnumMember(Value = "cell_phone_store")]
    CellPhoneStore,

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
    /// Department Store.
    /// </summary>
    [EnumMember(Value = "department_store")]
    DepartmentStore,

    /// <summary>
    /// Discount Store.
    /// </summary>
    [EnumMember(Value = "discount_store")]
    DiscountStore,

    /// <summary>
    /// Electronics Store.
    /// </summary>
    [EnumMember(Value = "electronics_store")]
    ElectronicsStore,

    /// <summary>
    /// Food Store.
    /// </summary>
    [EnumMember(Value = "food_store")]
    FoodStore,

    /// <summary>
    /// Furniture Store.
    /// </summary>
    [EnumMember(Value = "furniture_store")]
    FurnitureStore,

    /// <summary>
    /// Gift Shop.
    /// </summary>
    [EnumMember(Value = "gift_shop")]
    GiftShop,

    /// <summary>
    /// Grocery Store.
    /// </summary>
    [EnumMember(Value = "grocery_store")]
    GroceryStore,

    /// <summary>
    /// Hardware Store.
    /// </summary>
    [EnumMember(Value = "hardware_store")]
    HardwareStore,

    /// <summary>
    /// Home Goods Store.
    /// </summary>
    [EnumMember(Value = "home_goods_store")]
    HomeGoodsStore,

    /// <summary>
    /// Home Improvement Store.
    /// </summary>
    [EnumMember(Value = "home_improvement_store")]
    HomeImprovementStore,

    /// <summary>
    /// Jewelry Store.
    /// </summary>
    [EnumMember(Value = "jewelry_store")]
    JewelryStore,

    /// <summary>
    /// Liquor Store.
    /// </summary>
    [EnumMember(Value = "liquor_store")]
    LiquorStore,

    /// <summary>
    /// Market.
    /// </summary>
    [EnumMember(Value = "market")]
    Market,

    /// <summary>
    /// Pet Store.
    /// </summary>
    [EnumMember(Value = "pet_store")]
    PetStore,

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
    /// Sporting Goods Store.
    /// </summary>
    [EnumMember(Value = "sporting_goods_store")]
    SportingGoodsStore,

    /// <summary>
    /// Store.
    /// </summary>
    [EnumMember(Value = "store")]
    Store,

    /// <summary>
    /// Supermarket.
    /// </summary>
    [EnumMember(Value = "supermarket")]
    Supermarket,

    /// <summary>
    /// Warehouse Store.
    /// </summary>
    [EnumMember(Value = "warehouse_store")]
    WarehouseStore,

    /// <summary>
    /// Wholesaler.
    /// </summary>
    [EnumMember(Value = "wholesaler")]
    Wholesaler,

    /// <summary>
    /// Arena.
    /// </summary>
    [EnumMember(Value = "arena")]
    Arena,

    /// <summary>
    /// Athletic Field.
    /// </summary>
    [EnumMember(Value = "athletic_field")]
    AthleticField,

    /// <summary>
    /// Fishing Charter.
    /// </summary>
    [EnumMember(Value = "fishing_charter")]
    FishingCharter,

    /// <summary>
    /// Fishing Pond.
    /// </summary>
    [EnumMember(Value = "fishing_pond")]
    FishingPond,

    /// <summary>
    /// Fitness Center.
    /// </summary>
    [EnumMember(Value = "fitness_center")]
    FitnessCenter,

    /// <summary>
    /// Golf Course.
    /// </summary>
    [EnumMember(Value = "golf_course")]
    GolfCourse,

    /// <summary>
    /// Gym.
    /// </summary>
    [EnumMember(Value = "gym")]
    Gym,

    /// <summary>
    /// Ice Skating Rink.
    /// </summary>
    [EnumMember(Value = "ice_skating_rink")]
    IceSkatingRink,

    /// <summary>
    /// Playground.
    /// </summary>
    [EnumMember(Value = "playground")]
    Playground,

    /// <summary>
    /// Ski Resort.
    /// </summary>
    [EnumMember(Value = "ski_resort")]
    SkiResort,

    /// <summary>
    /// Sports Activity Location.
    /// </summary>
    [EnumMember(Value = "sports_activity_location")]
    SportsActivityLocation,

    /// <summary>
    /// Sports Club.
    /// </summary>
    [EnumMember(Value = "sports_club")]
    SportsClub,

    /// <summary>
    /// Sports Coaching.
    /// </summary>
    [EnumMember(Value = "sports_coaching")]
    SportsCoaching,

    /// <summary>
    /// Sports Complex.
    /// </summary>
    [EnumMember(Value = "sports_complex")]
    SportsComplex,

    /// <summary>
    /// Stadium.
    /// </summary>
    [EnumMember(Value = "stadium")]
    Stadium,

    /// <summary>
    /// Swimming Pool.
    /// </summary>
    [EnumMember(Value = "swimming_pool")]
    SwimmingPool,

    /// <summary>
    /// Airport.
    /// </summary>
    [EnumMember(Value = "airport")]
    Airport,

    /// <summary>
    /// Airstrip.
    /// </summary>
    [EnumMember(Value = "airstrip")]
    Airstrip,

    /// <summary>
    /// Bus Station.
    /// </summary>
    [EnumMember(Value = "bus_station")]
    BusStation,

    /// <summary>
    /// Bus Stop.
    /// </summary>
    [EnumMember(Value = "bus_stop")]
    BusStop,

    /// <summary>
    /// Ferry Terminal.
    /// </summary>
    [EnumMember(Value = "ferry_terminal")]
    FerryTerminal,

    /// <summary>
    /// Heliport.
    /// </summary>
    [EnumMember(Value = "heliport")]
    Heliport,

    /// <summary>
    /// International Airport.
    /// </summary>
    [EnumMember(Value = "international_airport")]
    InternationalAirport,

    /// <summary>
    /// Light Rail Station.
    /// </summary>
    [EnumMember(Value = "light_rail_station")]
    LightRailStation,

    /// <summary>
    /// Park and Ride.
    /// </summary>
    [EnumMember(Value = "park_and_ride")]
    ParkAndRide,

    /// <summary>
    /// Subway Station.
    /// </summary>
    [EnumMember(Value = "subway_station")]
    SubwayStation,

    /// <summary>
    /// Taxi Stand.
    /// </summary>
    [EnumMember(Value = "taxi_stand")]
    TaxiStand,

    /// <summary>
    /// Train Station.
    /// </summary>
    [EnumMember(Value = "train_station")]
    TrainStation,

    /// <summary>
    /// Transit Depot.
    /// </summary>
    [EnumMember(Value = "transit_depot")]
    TransitDepot,

    /// <summary>
    /// Transit Station.
    /// </summary>
    [EnumMember(Value = "transit_station")]
    TransitStation,

    /// <summary>
    /// Truck Stop.
    /// </summary>
    [EnumMember(Value = "truck_stop")]
    TruckStop,

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