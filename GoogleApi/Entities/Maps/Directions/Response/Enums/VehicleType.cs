using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Directions.Response.Enums
{
    /// <summary>
    /// VehicleType.
    /// </summary>
    public enum VehicleType
    {
        /// <summary>
        /// All other vehicles will return this type.
        /// </summary>
        Other,

        /// <summary>
        /// Rail.
        /// </summary>
        Rail,

        /// <summary>
        /// Light rail transit.
        /// </summary>
        [EnumMember(Value = "Metro_Rail")]
        MetroRail,

        /// <summary>
        /// Underground light rail.
        /// </summary>
        Subway,

        /// <summary>
        /// Above ground light rail.
        /// </summary>
        Tram,

        /// <summary>
        /// Monorail.
        /// </summary>
        Monorail,

        /// <summary>
        /// Heavy rail.
        /// </summary>
        [EnumMember(Value = "Heavy_Rail")]
        HeavyRail,

        /// <summary>
        /// Commuter rail.
        /// </summary>
        [EnumMember(Value = "Commuter_Train")]
        CommuterTrain,

        /// <summary>
        /// High speed train.
        /// </summary>
        [EnumMember(Value = "High_Speed_Train")]
        HighSpeedTrain,

        /// <summary>
        /// Bus.
        /// </summary>
        Bus,

        /// <summary>
        /// Intercity bus.
        /// </summary>
        [EnumMember(Value = "Intercity_Bus")]
        IntercityBus,

        /// <summary>
        /// Trolleybus.
        /// </summary>
        Trolleybus,

        /// <summary>
        /// Share taxi is a kind of bus with the ability to drop off and pick up passengers anywhere on its route.
        /// </summary>
        [EnumMember(Value = "Share_Taxi")]
        ShareTaxi,

        /// <summary>
        /// Ferry.
        /// </summary>
        Ferry,

        /// <summary>
        /// A vehicle that operates on a cable, usually on the ground. Aerial cable cars may be of the type GONDOLA_LIFT.
        /// </summary>
        [EnumMember(Value = "Cable_Car")]
        CableCar,

        /// <summary>
        /// An aerial cable car.
        /// </summary>
        [EnumMember(Value = "Gondola_Lift")]
        GondolaLift,

        /// <summary>
        /// A vehicle that is pulled up a steep incline by a cable. A Funicular typically consists of two cars, with each car acting as a counterweight for the other.
        /// </summary>
        Funicular
    }
}
