using System;

namespace GoogleApi.Entities.Common.Converters.Enums;

/// <summary>
/// Enum Converter Options.
/// </summary>
[Flags]
public enum EnumConverterOptions
{
    /// <summary>
    /// Allow Strings.
    /// </summary>
    AllowStrings = 1,

    /// <summary>
    /// Allow Numbers.
    /// </summary>
    AllowNumbers = 2
}