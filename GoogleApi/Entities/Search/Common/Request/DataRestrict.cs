using GoogleApi.Entities.Search.Common.Enums;

namespace GoogleApi.Entities.Search.Common.Request
{
    /// <summary>
    /// Data Restrict.
    /// </summary>
    public class DataRestrict
    {
        /// <summary>
        /// DateRestrict - Restricts results to URLs based on date.
        /// </summary>
        public virtual DateRestrictType Type { get; set; } = DateRestrictType.Days;

        /// <summary>
        /// DateRestrictNumber - Requests results from the specified number of past days, weeks, months or years.
        /// </summary>
        public virtual int Number { get; set; }
    }
}