using System.Collections.Generic;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.PlacesNew.Common.Enums;
using PriceLevel = GoogleApi.Entities.PlacesNew.Common.Enums.PriceLevel;

namespace GoogleApi.Entities.PlacesNew.Common;

/// <summary>
/// All the information representing a Place.
/// </summary>
public class Place
{
    /// <summary>
    /// This Place's resource name, in places/{placeId} format. Can be used to look up the Place
    /// </summary>
    public virtual string Name { get; set; }

    /// <summary>
    /// The unique identifier of a place.
    /// </summary>
    public virtual string Id { get; set; }

    /// <summary>
    /// The localized name of the place, suitable as a short human-readable description.
    /// For example, "Google Sydney", "Starbucks", "Pyrmont", etc.
    /// </summary>
    public virtual LocalizedText DisplayName { get; set; }

    /// <summary>
    /// A set of type tags for this result. For example, "political" and "locality".
    /// For the complete list of possible values, see Table A and Table B at https://developers.google.com/maps/documentation/places/web-service/place-types
    /// </summary>
    public virtual IEnumerable<PlaceLocationTypeAb> Types { get; set; } = new List<PlaceLocationTypeAb>();

    /// <summary>
    /// The primary type of the given result. This type must one of the Places API supported types.
    /// For example, "restaurant", "cafe", "airport", etc. A place can only have a single primary type.
    /// For the complete list of possible values, see Table A and Table B at https://developers.google.com/maps/documentation/places/web-service/place-types
    /// </summary>
    public virtual PlaceLocationTypeAb PrimaryType { get; set; }

    /// <summary>
    /// The display name of the primary type, localized to the request language if applicable.
    /// For the complete list of possible values, see Table A and Table B at https://developers.google.com/maps/documentation/places/web-service/place-types
    /// </summary>
    public virtual LocalizedText PrimaryTypeDisplayName { get; set; }

    /// <summary>
    /// A human-readable phone number for the place, in national format.
    /// </summary>
    public virtual string NationalPhoneNumber { get; set; }

    /// <summary>
    /// A human-readable phone number for the place, in international format.
    /// </summary>
    public virtual string InternationalPhoneNumber { get; set; }

    /// <summary>
    /// A full, human-readable address for this place.
    /// </summary>
    public virtual string FormattedAddress { get; set; }

    /// <summary>
    /// A short, human-readable address for this place.
    /// </summary>
    public virtual string ShortFormattedAddress { get; set; }

    /// <summary>
    /// Repeated components for each locality level.
    /// Note the following facts about the addressComponents[] array:
    /// The array of address components may contain more components than the formattedAddress.
    /// The array does not necessarily include all the political entities that contain an address, apart from those included in the formattedAddress.
    /// To retrieve all the political entities that contain a specific address, you should use reverse geocoding,
    /// passing the latitude/longitude of the address as a parameter to the request.
    /// The format of the response is not guaranteed to remain the same between requests.
    /// In particular, the number of addressComponents varies based on the address requested and can change over time for the same address.
    /// A component can change position in the array.
    /// The type of the component can change.
    /// A particular component may be missing in a later response.
    /// </summary>
    public virtual IEnumerable<AddressComponent> AddressComponents { get; set; } = new List<AddressComponent>();

    /// <summary>
    /// Plus code of the place location lat/long
    /// </summary>
    public virtual PlusCode PlusCode { get; set; }

    /// <summary>
    /// The position of this place.
    /// </summary>
    public virtual LatLng Location { get; set; }

    /// <summary>
    /// A viewport suitable for displaying the place on an average-sized map.
    /// This viewport should not be used as the physical boundary or the service area of the business.
    /// </summary>
    public virtual Rectangle Viewport { get; set; }

    /// <summary>
    /// A rating between 1.0 and 5.0, based on user reviews of this place.
    /// </summary>
    public virtual decimal? Rating { get; set; }

    /// <summary>
    /// A URL providing more information about this place.
    /// </summary>
    public virtual string GoogleMapsUri { get; set; }

    /// <summary>
    /// The authoritative website for this place, e.g. a business' homepage. Note that for places that are part of a chain (e.g. an IKEA store),
    /// this will usually be the website for the individual store, not the overall chain.
    /// </summary>
    public virtual string WebsiteUri { get; set; }

    /// <summary>
    /// List of reviews about this place, sorted by relevance. A maximum of 5 reviews can be returned.
    /// </summary>
    public virtual IEnumerable<Review> Reviews { get; set; } = new List<Review>(); 

    /// <summary>
    /// The regular hours of operation. Note that if a place is always open (24 hours), the close field will not be set.
    /// Clients can rely on always open (24 hours) being represented as an [open][OpeningHours.Period.open] period containing [day][Point.day] with value 0,
    /// [hour][Point.hour] with value 0, and [minute][Point.minute] with value 0.
    /// </summary>
    public virtual OpeningHours RegularOpeningHours { get; set; }

    /// <summary>
    /// Information (including references) about photos of this place. A maximum of 10 photos can be returned.
    /// </summary>
    public virtual IEnumerable<Photo> Photos { get; set; } = new List<Photo>();

    /// <summary>
    /// The place's address in adr microformat: http://microformats.org/wiki/adr.
    /// </summary>
    public virtual string AdrFormatAddress { get; set; }

    /// <summary>
    /// The business status for the place.
    /// </summary>
    public virtual BusinessStatus BusinessStatus { get; set; }

    /// <summary>
    /// Price level of the place.
    /// </summary>
    public virtual PriceLevel PriceLevel { get; set; }

    /// <summary>
    /// A set of data provider that must be shown with this result.
    /// </summary>
    public virtual IEnumerable<Attribution> Attributions { get; set; } = new List<Attribution>();

    /// <summary>
    /// A truncated URL to an icon mask. User can access different icon type by appending type suffix to the end (eg, ".svg" or ".png").
    /// </summary>
    public virtual string IconMaskBaseUri { get; set; }

    /// <summary>
    /// Background color for icon_mask in hex format, e.g. #909CE1.
    /// </summary>
    public virtual string IconBackgroundColor { get; set; }

    /// <summary>
    /// The hours of operation for the next seven days (including today).
    /// The time period starts at midnight on the date of the request and ends at 11:59 pm six days later.
    /// This field includes the specialDays subfield of all hours, set for dates that have exceptional hours.
    /// </summary>
    public virtual OpeningHours CurrentOpeningHours { get; set; }

    /// <summary>
    /// Contains an array of entries for the next seven days including information about secondary hours of a business.
    /// Secondary hours are different from a business's main hours. For example, a restaurant can specify drive through hours or delivery hours as its secondary hours.
    /// This field populates the type subfield, which draws from a predefined list of opening hours types (such as DRIVE_THROUGH, PICKUP, or TAKEOUT)
    /// based on the types of the place. This field includes the specialDays subfield of all hours, set for dates that have exceptional hours.
    /// </summary>
    public virtual IEnumerable<OpeningHours> CurrentSecondaryOpeningHours { get; set; } = new List<OpeningHours>();

    /// <summary>
    /// Contains an array of entries for information about regular secondary hours of a business.
    /// Secondary hours are different from a business's main hours. For example, a restaurant can specify drive through hours or delivery hours as its secondary hours.
    /// This field populates the type subfield, which draws from a predefined list of opening hours types (such as DRIVE_THROUGH, PICKUP, or TAKEOUT)
    /// based on the types of the place.
    /// </summary>
    public virtual IEnumerable<OpeningHours> RegularSecondaryOpeningHours { get; set; } = new List<OpeningHours>();

    /// <summary>
    /// Contains a summary of the place. A summary is comprised of a textual overview, and also includes the language code for these if applicable.
    /// Summary text must be presented as-is and can not be modified or altered
    /// </summary>
    public virtual LocalizedText EditorialSummary { get; set; }

    /// <summary>
    /// Payment options the place accepts. If a payment option data is not available, the payment option field will be unset.
    /// </summary>
    public virtual PaymentOptions PaymentOptions { get; set; }

    /// <summary>
    /// Options of parking provided by the place.
    /// </summary>
    public virtual ParkingOptions ParkingOptions { get; set; }

    /// <summary>
    /// A list of sub destinations related to the place.
    /// </summary>
    public virtual IEnumerable<SubDestination> SubDestinations { get; set; } = new List<SubDestination>();

    /// <summary>
    /// The most recent information about fuel options in a gas station. This information is updated regularly.
    /// </summary>
    public virtual FuelOptions FuelOptions { get; set; }

    /// <summary>
    /// Information of ev charging options.
    /// </summary>
    public virtual EvChargeOptions EvChargeOptions { get; set; }

    /// <summary>
    /// AI-generated summary of the place
    /// Experimental: See https://developers.google.com/maps/documentation/places/web-service/experimental/places-generative for more details.
    /// </summary>
    public virtual GenerativeSummary GenerativeSummary { get; set; }

    /// <summary>
    /// AI-generated summary of the area that the place is in.
    /// Experimental: See https://developers.google.com/maps/documentation/places/web-service/experimental/places-generative for more details.
    /// </summary>
    public virtual AreaSummary AreaSummary { get; set; }

    /// <summary>
    /// List of places in which the current place is located.
    /// </summary>
    public virtual IEnumerable<ContainingPlace> ContainingPlaces { get; set; } = new List<ContainingPlace>();

    /// <summary>
    /// The address descriptor of the place. Address descriptors include additional information that help describe a location using landmarks and areas.
    /// See address descriptor regional coverage in https://developers.google.com/maps/documentation/geocoding/address-descriptors/coverage.
    /// </summary>
    public virtual AddressDescriptor AddressDescriptor { get; set; }

    /// <summary>
    /// Links to trigger different Google Maps actions.
    /// </summary>
    public virtual GoogleMapsLinks GoogleMapsLinks { get; set; }

    /// <summary>
    /// The price range associated with a Place.
    /// </summary>
    public virtual PriceRange PriceRange { get; set; }

    /// <summary>
    /// Number of minutes this place's timezone is currently offset from UTC.
    /// This is expressed in minutes to support timezones that are offset by fractions of an hour, e.g. X hours and 15 minutes.
    /// </summary>
    public virtual int? UtcOffsetMinutes { get; set; }

    /// <summary>
    /// The total number of reviews (with or without text) for this place.
    /// </summary>
    public virtual int UserRatingCount { get; set; }

    /// <summary>
    /// Specifies if the business supports takeout.
    /// </summary>
    public virtual bool Takeout { get; set; }

    /// <summary>
    /// Specifies if the business supports delivery.
    /// </summary>
    public virtual bool Delivery { get; set; }

    /// <summary>
    /// Specifies if the business supports indoor or outdoor seating options
    /// </summary>
    public virtual bool DineIn { get; set; }

    /// <summary>
    /// Specifies if the business supports curbside pickup
    /// </summary>
    public virtual bool CurbsidePickup { get; set; }

    /// <summary>
    /// Specifies if the place supports reservations.
    /// </summary>
    public virtual bool Reservable { get; set; }

    /// <summary>
    /// Specifies if the place serves breakfast.
    /// </summary>
    public virtual bool ServesBreakfast { get; set; }

    /// <summary>
    /// Specifies if the place serves lunch.
    /// </summary>
    public virtual bool ServesLunch { get; set; }

    /// <summary>
    /// Specifies if the place serves dinner.
    /// </summary>
    public virtual bool ServesDinner { get; set; }

    /// <summary>
    /// Specifies if the place serves beer.
    /// </summary>
    public virtual bool ServesBeer { get; set; }

    /// <summary>
    /// Specifies if the place serves wine.
    /// </summary>
    public virtual bool ServesWine { get; set; }

    /// <summary>
    /// Specifies if the place serves brunch.
    /// </summary>
    public virtual bool ServesBrunch { get; set; }

    /// <summary>
    /// Specifies if the place serves vegetarian food.
    /// </summary>
    public virtual bool ServesVegetarianFood { get; set; }

    /// <summary>
    /// Place provides outdoor seating.
    /// </summary>
    public virtual bool OutdoorSeating { get; set; }

    /// <summary>
    /// Place provides live music.
    /// </summary>
    public virtual bool LiveMusic { get; set; }

    /// <summary>
    /// Place has a children's menu.
    /// </summary>
    public virtual bool MenuForChildren { get; set; }

    /// <summary>
    /// Place serves cocktails.
    /// </summary>
    public virtual bool ServesCocktails { get; set; }

    /// <summary>
    /// Place serves dessert.
    /// </summary>
    public virtual bool ServesDessert { get; set; }

    /// <summary>
    /// Place serves coffee.
    /// </summary>
    public virtual bool ServesCoffee { get; set; }

    /// <summary>
    /// Place is good for children.
    /// </summary>
    public virtual bool GoodForChildren { get; set; }

    /// <summary>
    /// Place allows dogs.
    /// </summary>
    public virtual bool AllowsDogs { get; set; }

    /// <summary>
    /// Place has restroom.
    /// </summary>
    public virtual bool Restroom { get; set; }

    /// <summary>
    /// Place accommodates groups.
    /// </summary>
    public virtual bool GoodForGroups { get; set; }

    /// <summary>
    /// Place is suitable for watching sports.
    /// </summary>
    public virtual bool GoodForWatchingSports { get; set; }

    /// <summary>
    /// Information about the accessibility options a place offers.
    /// </summary>
    public virtual AccessibilityOptions AccessibilityOptions { get; set; }

    /// <summary>
    /// Indicates whether the place is a pure service area business.
    /// Pure service area business is a business that visits or delivers to customers directly but does not serve customers at their business address.
    /// For example, businesses like cleaning services or plumbers. Those businesses may not have a physical address or location on Google Maps.
    /// </summary>
    public virtual bool PureServiceAreaBusiness { get; set; }
}