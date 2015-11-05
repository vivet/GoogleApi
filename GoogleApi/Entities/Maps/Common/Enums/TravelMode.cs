namespace GoogleApi.Entities.Maps.Common.Enums
{
    /// <summary>
    /// Travel mode
    /// </summary>
	public enum TravelMode
	{
        /// <summary>
        /// Indicates distance calculation using the road network.
        /// </summary>
		DRIVING,
        /// <summary>
        /// Requests distance calculation for walking via pedestrian paths and sidewalks (where available).
        /// </summary>
		WALKING,
        /// <summary>
        /// Requests distance calculation for bicycling via bicycle paths and preferred streets (where available).
        /// </summary>
        BICYCLING,
        /// <summary>
        /// transit requests distance calculation via public transit routes (where available). 
        /// This value may only be specified if the request includes an API key or a Google Maps API for Work client ID. 
        /// If you set the mode to transit you can optionally specify either a departure_time or an arrival_time. 
        /// If neither time is specified, the departure_time defaults to now (that is, the departure time defaults to the current time). 
        /// You can also optionally include a transit_mode and/or a transit_routing_preference.
        /// </summary>
		TRANSIT
	}
}
