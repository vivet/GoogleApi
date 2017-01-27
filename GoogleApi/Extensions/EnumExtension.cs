using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace GoogleApi.Extensions
{
    /// <summary>
    /// Enum Extension methods.
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// Convert enum to string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_enum"></param>
        /// <returns></returns>
        public static string ToEnumString<T>(this T _enum)
            where T : struct, IConvertible
        {
            var enumType = typeof(T);
            var name = Enum.GetName(enumType, _enum);
            var enumMemberAttribute =
            ((EnumMemberAttribute[])
                enumType.GetRuntimeField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();

            return enumMemberAttribute.Value;
        }

        /// <summary>
        /// Converts a enum value to string. 
        /// If Flags enum then the delimeter will separate the values.
        /// </summary>
        /// <param name="_enum"></param>
        /// <param name="delimeter"></param>
        /// <returns></returns>
        public static string ToEnumString<T>(this T _enum, char delimeter)
            where T : struct, IConvertible
        {
            if (_enum.GetType().GetTypeInfo().GetCustomAttributes(typeof(FlagsAttribute), true).FirstOrDefault() == null)
                return Convert.ToString(_enum, CultureInfo.InvariantCulture).ToLower();

            var stringBuilder = new StringBuilder();
            var binaryCharArray = Convert.ToString(_enum, CultureInfo.InvariantCulture).Reverse().ToArray();

            for (var i = 0; i < binaryCharArray.Length; i++)
            {
                if (binaryCharArray[i] != '1')
                    continue;

                stringBuilder.AppendFormat("{0}", 1 << i);

                if (i != binaryCharArray.Length - 1)
                    stringBuilder.Append(delimeter);
            }

            return stringBuilder.ToString().ToLower();
        }
    }
}