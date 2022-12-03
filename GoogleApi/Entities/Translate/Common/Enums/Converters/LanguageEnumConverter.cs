using System;
using System.Text.Json;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.Common.Converters.Enums;

namespace GoogleApi.Entities.Translate.Common.Enums.Converters;

/// <summary>
/// Custom Language Enum converter to avoid breaking changes when Google adds a new language to the list.
/// </summary>
public class LanguageEnumConverter : EnumConverter<Language>
{
    /// <inheritdoc />
    public LanguageEnumConverter(EnumConverterOptions converterOptions, JsonSerializerOptions serializerOptions) 
        : base(converterOptions, serializerOptions)
    {

    }

    /// <inheritdoc />
    public LanguageEnumConverter(EnumConverterOptions converterOptions, JsonNamingPolicy namingPolicy, JsonSerializerOptions serializerOptions) 
        : base(converterOptions, namingPolicy, serializerOptions)
    {

    }

    /// <inheritdoc />
    public override Language Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == null) 
            throw new ArgumentNullException(nameof(typeToConvert));
        
        if (options == null) 
            throw new ArgumentNullException(nameof(options));
        
        try
        {
            return base.Read(ref reader, typeToConvert, options);
        }
        catch (JsonException ex)
        {
            if (ex.Message.Contains($"Could not parse {nameof(Language)}"))
            {
                return Language.Unsupported;
            }

            throw;
        }
    }
}