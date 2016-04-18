using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GoogleApi.Helpers
{
    /// <summary>
    /// Helper methods to convert enums to strings for query string parameters.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Convert enum to string.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_type"></param>
        /// <returns></returns>
        public static string ToEnumString<T>(T _type)
        {
            var _enumType = typeof(T);
            var _name = Enum.GetName(_enumType, _type);
            var _enumMemberAttribute = ((EnumMemberAttribute[])_enumType.GetField(_name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();

            return _enumMemberAttribute.Value;
        }
      
        /// <summary>
        /// convert string to enum.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="_str"></param>
        /// <returns></returns>
        public static T ToEnum<T>(string _str)
        {
            var _enumType = typeof(T);
            foreach (var _name in Enum.GetNames(_enumType))
            {
                var _enumMemberAttribute = ((EnumMemberAttribute[])_enumType.GetField(_name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
                if (_enumMemberAttribute.Value == _str) 
                    return (T)Enum.Parse(_enumType, _name);
            }

            return default(T);
        }

        /// <summary>
        /// Converts a enum value to string. 
        /// If Flags enum then the delimeter will separate the values.
        /// </summary>
        /// <param name="_enum"></param>
        /// <param name="_delimeter"></param>
        /// <returns></returns>
        public static string ToString(this Enum _enum, char _delimeter)
        {
            if (_enum.GetType().GetCustomAttributes(typeof(FlagsAttribute), true).FirstOrDefault() == null)
                return Convert.ToString(_enum).ToLower();

            var _stringBuilder = new StringBuilder();
            var _binaryCharArray = Convert.ToString(_enum).Reverse().ToArray();

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