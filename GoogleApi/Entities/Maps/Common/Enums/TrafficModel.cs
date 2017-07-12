namespace GoogleApi.Entities.Maps.Common.Enums
{
    /// <summary>
    /// Traffic Model
    /// </summary>
    public enum TrafficModel
    {
        /// <summary>
        /// Best guess (default), indicates that the returned duration_in_traffic should be the best estimate of travel time 
        /// given what is known about both historical traffic conditions and live traffic.
        /// Live traffic becomes more important the closer the departure_time is to now.
        /// </summary>
        Best_Guess,

        /// <summary>
        /// Pessimistic, indicates that the returned duration_in_traffic should be longer than the actual travel time on most days,
        /// though occasional days with particularly bad traffic conditions may exceed this value.
        /// </summary>
        Pessimistic,

        /// <summary>
        /// Optimistic, indicates that the returned duration_in_traffic should be shorter than the actual travel time on most days, 
        /// though occasional days with particularly good traffic conditions may be faster than this value.
        /// </summary>
        Optimistic
    }
}
