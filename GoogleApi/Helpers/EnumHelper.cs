using System;
using System.Linq;
using System.Runtime.Serialization;

namespace GoogleApi.Helpers
{
    public static class EnumHelper
    {
        public static string ToEnumString<T>(T type) where T : struct, IConvertible
        {
            var enumType = typeof(T);
            var name = Enum.GetName(enumType, type);
            var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();

            if (string.IsNullOrEmpty(enumMemberAttribute.Value))
            {
                var enumInt = (int) (object) type;
                return enumInt.ToString();
            }

            return enumMemberAttribute.Value;
        }

        public static T ToEnum<T>(string str) where T : struct, IConvertible
        {
            var enumType = typeof(T);
            foreach (var name in Enum.GetNames(enumType))
            {
                var enumMemberAttribute = ((EnumMemberAttribute[])enumType.GetField(name).GetCustomAttributes(typeof(EnumMemberAttribute), true)).Single();
                if (enumMemberAttribute.Value == str) return (T)Enum.Parse(enumType, name);
            }
            return (T)Enum.Parse(typeof (T), str);
        }
    }
}
