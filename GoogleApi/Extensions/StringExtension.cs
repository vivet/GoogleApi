using System;
using System.Linq;
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
        /// <param name="_str"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string _str) 
            where T : struct, IConvertible
        {
            if (_str == null) 
                throw new ArgumentNullException("_str");
            
            var _enumType = typeof(T);

            foreach (var _name in Enum.GetNames(_enumType))
            {
                var _enumMemberAttribute = ((EnumMemberAttribute[])_enumType.GetField(_name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
      
                if (_enumMemberAttribute.Value == _str) 
                    return (T)Enum.Parse(_enumType, _name);
            }

            return default(T);
        }
    }
}