namespace GoogleApi.Entities.Search.Common.Enums.Extensions
{
    /// <summary>
    /// Date Restrict Type Extension.
    /// </summary>
    public static class DateRestrictTypeExtension
    {
        /// <summary>
        /// Converts enum value to string.
        /// </summary>
        /// <param name="dateRestrictType">The enum to convert.</param>
        /// <returns>The string representation of the enum value for the search request.</returns>
        public static string ToTypeString(this DateRestrictType dateRestrictType)
        {
            switch (dateRestrictType)
            {
                case DateRestrictType.Days:
                    return "d";

                case DateRestrictType.Weeks:
                    return "w";

                case DateRestrictType.Months:
                    return "m";

                case DateRestrictType.Years:
                    return "y";

                default:
                    return "d";
            }
        }
    }
}