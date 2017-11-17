using System;
using System.Globalization;

namespace GoogleApi.Entities.Common.Extensions
{
    /// <summary>
    /// Enum extensions.
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Converts a <see cref="Enum"/> value to string. 
        /// If enum is a <see cref="FlagsAttribute"/>, values are separated by the passed <paramref name="delimeter"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Enum"/> type.</typeparam>
        /// <param name="enum">The <see cref="Enum"/> to convert of <typeparamref name="T"/>.</param>
        /// <param name="delimeter">The separator inserted between each value if the <see cref="Enum"/>.</param>
        /// <returns>A <see cref="string"/> representation of the enum value.</returns>
        public static string ToEnumString<T>(this T @enum, char delimeter)
            where T : struct 
        {
            return Convert.ToString(@enum, CultureInfo.InvariantCulture).ToLower().Replace(',', delimeter).Replace(" ", "");
        }
    }
}