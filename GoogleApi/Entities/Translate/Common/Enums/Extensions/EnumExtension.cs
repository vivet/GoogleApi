using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Translate.Common.Enums.Extensions;

/// <summary>
/// Enum Extensions.
/// </summary>
public static class EnumExtension
{
    /// <summary>
    /// Gets the value of the [EnumMember(Value = "...")] tags
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string GetEnumMemberValue<T>(this T value)
        where T : Enum
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value));

        return typeof(T)
            .GetTypeInfo()
            .DeclaredMembers
            .SingleOrDefault(x => x.Name == value.ToString())?
            .GetCustomAttribute<EnumMemberAttribute>(false)?
            .Value;
    }
}