using System.Text.RegularExpressions;
using GoogleApi.Entities.Places.Search.Common.Enums;

namespace GoogleApi.Entities.Search.Common.Enums.Extensions
{
    /// <summary>
    /// SearchPlaceType extensions
    /// </summary>
    public static class SearchPlaceTypeExtension
    {
        /// <summary>
        /// Converts a <see cref="SearchPlaceType"/> value string into an lower case underscore string.
        /// </summary>
        /// <example>
        /// MealDelivery >> Meal_Delivery
        /// LocalGovernmentOffice >> Local_Government_Office
        /// </example>
        /// <param name="placeType"></param>
        /// <returns></returns>
        public static string ToUnderscoreString(this SearchPlaceType placeType)
        {
            string titleValue = placeType.ToString();

            string underscoreValue = Regex.Replace(titleValue, @"(\p{Ll})(\p{Lu})", "$1_$2").ToLower();

            return underscoreValue;
        }
    }
}