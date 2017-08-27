using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleApi.Entities.Common.Extensions
{
    /// <summary>
    /// String extensions.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Converts a comma-separated items of a <see cref="string"/> to an <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Enum"/> type.</typeparam>
        /// <param name="string">The <see cref="string"/> to convert.</param>
        /// <returns>An <see cref="IEnumerable{T}"/>.</returns>
        public static IEnumerable<T> ToStringEnum<T>(this string @string)
            where T : struct
        {
            if (@string == null)
                return new List<T>();

            var strings = @string.Split(',');

            return strings.Select(x =>
            {
                Enum.TryParse(x, true, out T type);
                return type;
            });
        }
    }
}