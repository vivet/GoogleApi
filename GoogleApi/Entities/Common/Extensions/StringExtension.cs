using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Common.Extensions
{
    /// <summary>
    /// String extensions.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Converts a <see cref="string"/> to an <see cref="Enum"/> of type <typeparamref name="T"/>.
        /// The conversion will use <see cref="EnumMemberAttribute.Value"/> if specified, otherwise by member name as fallback if no attribute is defined.
        /// </summary>
        /// <typeparam name="T">The <see cref="Enum"/> type.</typeparam>
        /// <param name="string">The <see cref="string"/> to convert.</param>
        /// <returns>An enum value of <typeparamref name="T"/>.</returns>
        public static T ToEnum<T>(this string @string)
            where T : struct
        {
            if (@string == null)
                return default(T);

            var enumType = typeof(T);
            foreach (var name in Enum.GetNames(enumType))
            {
                var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetRuntimeField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
                if (enumMemberAttribute.Value == @string)
                    return (T)Enum.Parse(enumType, name);
            }

            Enum.TryParse(@string, true, out T type);

            return type;
        }

        /// <summary>
        /// Converts a comma-separated items of a <see cref="string"/> to an <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <typeparam name="T">The <see cref="Enum"/> type.</typeparam>
        /// <param name="string">The <see cref="string"/> to convert.</param>
        /// <returns>An <see cref="IEnumerable{T}"/>.</returns>
        public static IEnumerable<T> ToEnumList<T>(this string @string)
            where T : struct
        {
            if (@string == null)
                return new List<T>();

            var values = @string.Split(',');

            return values.Select(x => x.ToEnum<T>());
        }
    }
}