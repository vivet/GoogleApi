using System;
using System.Globalization;
using System.Linq;
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
            var _enumType = typeof(T);
            var _name = Enum.GetName(_enumType, _enum);
            var _enumMemberAttribute = ((EnumMemberAttribute[])_enumType.GetField(_name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();

            return _enumMemberAttribute.Value;
        }

        /// <summary>
        /// Converts a enum value to string. 
        /// If Flags enum then the delimeter will separate the values.
        /// </summary>
        /// <param name="_enum"></param>
        /// <param name="_delimeter"></param>
        /// <returns></returns>
        public static string ToEnumString<T>(this T _enum, char _delimeter) 
            where T : struct, IConvertible
        {
            if (_enum.GetType().GetCustomAttributes(typeof(FlagsAttribute), true).FirstOrDefault() == null)
                return Convert.ToString(_enum, CultureInfo.InvariantCulture).ToLower();

            var _stringBuilder = new StringBuilder();
            var _binaryCharArray = Convert.ToString(_enum, CultureInfo.InvariantCulture).Reverse().ToArray();

            for (var _i = 0; _i < _binaryCharArray.Length; _i++)
            {
                if (_binaryCharArray[_i] != '1')
                    continue;

                _stringBuilder.AppendFormat("{0}", 1 << _i);

                if (_i != _binaryCharArray.Length - 1)
                    _stringBuilder.Append(_delimeter);
            }

            return _stringBuilder.ToString().ToLower();
        }
    }
}