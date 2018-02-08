using System;
using System.Runtime.Serialization;

// ReSharper disable InconsistentNaming

namespace GoogleApi.Entities.Places.Search.Common.Enums
{
    /// <summary>
    /// Place Types
    /// https://developers.google.com/places/supported_types#table1
    /// </summary>
    public enum SearchPlaceType
    {
        /// <summary>
        /// Accounting.
        /// </summary>
        Accounting,

        /// <summary>
        /// Airport.
        /// </summary>
        Airport,

        /// <summary>
        /// Amusement Park.
        /// </summary>       
        AmusementPark,

        /// <summary>
        /// Aquarium.
        /// </summary>
        Aquarium,

        /// <summary>
        /// Art Gallery.
        /// </summary>        
        ArtGallery,

        /// <summary>
        /// Atm.
        /// </summary>
        Atm,

        /// <summary>
        /// Bakery.
        /// </summary>
        Bakery,

        /// <summary>
        /// Bank.
        /// </summary>
        Bank,

        /// <summary>
        /// Bar.
        /// </summary>
        Bar,

        /// <summary>
        /// Beauty Salon.
        /// </summary>
        BeautySalon,

        /// <summary>
        /// Bicycle Store.
        /// </summary>
        BicycleStore,

        /// <summary>
        /// Book Store.
        /// </summary>
        BookStore,

        /// <summary>
        /// Bowling Alley.
        /// </summary>
        BowlingAlley,

        /// <summary>
        /// Bus Station.
        /// </summary>
        BusStation,

        /// <summary>
        /// Cafe.
        /// </summary>
        Cafe,

        /// <summary>
        /// Campground.
        /// </summary>
        Campground,

        /// <summary>
        /// Car Dealer.
        /// </summary>
        CarDealer,

        /// <summary>
        /// Car Rental.
        /// </summary>
        CarRental,

        /// <summary>
        /// Car Repair.
        /// </summary>
        CarRepair,

        /// <summary>
        /// Car Wash.
        /// </summary>
        CarWash,

        /// <summary>
        /// Casino.
        /// </summary>
        Casino,

        /// <summary>
        /// Cemetery.
        /// </summary>
        Cemetery,

        /// <summary>
        /// Church.
        /// </summary>
        Church,

        /// <summary>
        /// City Hall.
        /// </summary>
        CityHall,

        /// <summary>
        /// Clothing Store.
        /// </summary>
        ClothingStore,

        /// <summary>
        /// Convenience Store.
        /// </summary>
        ConvenienceStore,

        /// <summary>
        /// Courthouse.
        /// </summary>
        Courthouse,

        /// <summary>
        /// Dentist.
        /// </summary>
        Dentist,

        /// <summary>
        /// Department Store.
        /// </summary>
        DepartmentStore,

        /// <summary>
        /// Doctor.
        /// </summary>
        Doctor,

        /// <summary>
        /// Embassy.
        /// </summary>
        Embassy,

        /// <summary>
        /// Electrician
        /// </summary>
        Electrician,

        /// <summary>
        /// Electronics Store.
        /// </summary>
        ElectronicsStore,

        /// <summary>
        /// Establishment.
        /// </summary>
        [Obsolete]
        Establishment,

        /// <summary>
        /// Finance.
        /// </summary>
        [Obsolete]
        Finance,

        /// <summary>
        /// Fire Station.
        /// </summary>
        FireStation,

        /// <summary>
        /// Florist.
        /// </summary>
        Florist,

        /// <summary>
        /// Food.
        /// </summary>
        [Obsolete]
        Food,

        /// <summary>
        /// Funeral Home.
        /// </summary>
        FuneralHome,

        /// <summary>
        /// Furniture Store.
        /// </summary>
        FurnitureStore,

        /// <summary>
        /// Gas Station.
        /// </summary>
        GasStation,

        /// <summary>
        /// General Contractor.
        /// </summary>
        [Obsolete]
        GeneralContractor,

        /// <summary>
        /// Grocery Or Supermarket.
        /// </summary>
        [Obsolete]
        GroceryOrSupermarket,

        /// <summary>
        /// Gym.
        /// </summary>
        Gym,

        /// <summary>
        /// Hair Care.
        /// </summary>
        HairCare,

        /// <summary>
        /// Hardware Store.
        /// </summary>
        HardwareStore,

        /// <summary>
        /// Health.
        /// </summary>
        [Obsolete]
        Health,

        /// <summary>
        /// Hindu Temple.
        /// </summary>
        HinduTemple,

        /// <summary>
        /// Home Goods Store.
        /// </summary>
        HomeGoodsStore,

        /// <summary>
        /// Hospital.
        /// </summary>
        Hospital,

        /// <summary>
        /// Insurance Agency.
        /// </summary>
        InsuranceAgency,

        /// <summary>
        /// Jewelry Store.
        /// </summary>
        JewelryStore,

        /// <summary>
        /// Laundry.
        /// </summary>
        Laundry,

        /// <summary>
        /// Lawyer.
        /// </summary>
        Lawyer,

        /// <summary>
        /// Library.
        /// </summary>
        Library,

        /// <summary>
        /// Liquor Store.
        /// </summary>
        LiquorStore,

        /// <summary>
        /// Local Government Office.
        /// </summary>
        LocalGovernmentOffice,

        /// <summary>
        /// Locksmith
        /// </summary>
        Locksmith,

        /// <summary>
        /// Lodging.
        /// </summary>
        Lodging,

        /// <summary>
        /// Meal Delivery.
        /// </summary>
        MealDelivery,

        /// <summary>
        /// Meal Takeaway.
        /// </summary>
        MealTakeaway,

        /// <summary>
        /// Mosque.
        /// </summary>
        Mosque,

        /// <summary>
        /// Movie Rental.
        /// </summary>
        MovieRental,

        /// <summary>
        /// Movie Theater.
        /// </summary>
        MovieTheater,

        /// <summary>
        /// Moving Company.
        /// </summary>
        MovingCompany,

        /// <summary>
        /// Museum.
        /// </summary>
        Museum,

        /// <summary>
        /// Night Club.
        /// </summary>
        NightClub,

        /// <summary>
        /// Painter.
        /// </summary>
        Painter,

        /// <summary>
        /// Park.
        /// </summary>
        Park,

        /// <summary>
        /// Parking.
        /// </summary>
        Parking,

        /// <summary>
        /// Pet Store.
        /// </summary>
        PetStore,

        /// <summary>
        /// Pharmacy.
        /// </summary>
        Pharmacy,

        /// <summary>
        /// Physiotherapist.
        /// </summary>
        Physiotherapist,

        /// <summary>
        /// Place Of Worship.
        /// </summary>
        [Obsolete]
        PlaceOfWorship,

        /// <summary>
        /// Plumber.
        /// </summary>
        Plumber,

        /// <summary>
        /// Police.
        /// </summary>
        Police,

        /// <summary>
        /// Post Office.
        /// </summary>
        PostOffice,

        /// <summary>
        /// Real Estate Agency.
        /// </summary>
        RealEstateAgency,

        /// <summary>
        /// Restaurant.
        /// </summary>
        Restaurant,

        /// <summary>
        /// Roofing Contractor.
        /// </summary>
        RoofingContractor,

        /// <summary>
        /// Rv Park.
        /// </summary>
        RvPark,

        /// <summary>
        /// School.
        /// </summary>
        School,

        /// <summary>
        /// Shoe Store.
        /// </summary>
        ShoeStore,

        /// <summary>
        /// Shopping Mall.
        /// </summary>
        ShoppingMall,

        /// <summary>
        /// Spa.
        /// </summary>
        Spa,

        /// <summary>
        /// Stadium.
        /// </summary>
        Stadium,

        /// <summary>
        /// Storage.
        /// </summary>
        Storage,

        /// <summary>
        /// Store.
        /// </summary>
        Store,

        /// <summary>
        /// Subway Station.
        /// </summary>
        SubwayStation,

        /// <summary>
        /// Synagogue.
        /// </summary>
        Synagogue,

        /// <summary>
        /// Taxi Stand.
        /// </summary>
        TaxiStand,

        /// <summary>
        /// Train Station.
        /// </summary>
        TrainStation,

        /// <summary>
        /// Travel Agency.
        /// </summary>
        TravelAgency,

        /// <summary>
        /// University.
        /// </summary>
        University,

        /// <summary>
        /// Veterinary Care.
        /// </summary>
        VeterinaryCare,

        /// <summary>
        /// Zoo.
        /// </summary>
        Zoo
    }   
}