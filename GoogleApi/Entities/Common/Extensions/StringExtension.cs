using System;
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
        /// Convert a string to enum.
        /// </summary>
        /// <typeparam name="T">The <see cref="Enum"/> type of the conversion.</typeparam>
        /// <param name="str">The <see cref="string"/> to convert to an <see cref="Enum"/> value.</param>
        /// <returns>A <see cref="Enum"/> value of type <typeparamref name="T"/>.</returns>
        public static T ToEnum<T>(this string str)
            where T : struct
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            var enumType = typeof(T);

            foreach (var name in Enum.GetNames(enumType))
            {
                var enumMemberAttribute =
                ((EnumMemberAttribute[])
                    enumType.GetRuntimeField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();

                if (enumMemberAttribute.Value == str)
                    return (T) Enum.Parse(enumType, name);
            }

            return default(T);
        }
    }
}