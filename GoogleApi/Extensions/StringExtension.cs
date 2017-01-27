using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace GoogleApi.Extensions
{
    /// <summary>
    /// Helper methods to convert enums to strings for query string parameters.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Convert a string to enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string str)
            where T : struct, IConvertible
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