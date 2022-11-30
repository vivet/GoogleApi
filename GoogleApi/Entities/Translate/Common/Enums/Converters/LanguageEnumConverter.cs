using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

using GoogleApi.Entities.Common.Converters;

namespace GoogleApi.Entities.Translate.Common.Enums.Converters;

/// <summary>
///
/// </summary>
public class CustomLanguageJsonStringEnumConverter : JsonConverterFactory
{
    private readonly JsonNamingPolicy namingPolicy;
    private readonly bool allowIntegerValues;

    /// <summary>
    ///
    /// </summary>
    public CustomLanguageJsonStringEnumConverter() : this(null, true) { }

    /// <summary>
    ///
    /// </summary>
    public CustomLanguageJsonStringEnumConverter(JsonNamingPolicy namingPolicy, bool allowIntegerValues)
    {
        this.namingPolicy = namingPolicy;
        this.allowIntegerValues = allowIntegerValues;
    }

    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert) => typeToConvert.IsEnum && typeToConvert == typeof(Language);

    /// <inheritdoc />
     public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
     {
         var _namingPolicy = this.namingPolicy;

         var query = from field in typeToConvert.GetFields(BindingFlags.Public | BindingFlags.Static)
                     let attr = field.GetCustomAttribute<EnumMemberAttribute>()
                     where attr != null
                     select (field.Name, attr.Value);
         var dictionary = query.ToDictionary(p => p.Item1, p => p.Item2);
         if (dictionary.Count > 0)
         {
             _namingPolicy = new DictionaryLookupNamingPolicy(dictionary, namingPolicy);
         }

         return Create(
             typeToConvert,
             this.allowIntegerValues
                 ? EnumConverterOptions.AllowStrings | EnumConverterOptions.AllowNumbers
                 : EnumConverterOptions.AllowStrings,
             _namingPolicy,
             options);
     }

    /// <summary>
    ///
    /// </summary>
    private static JsonConverter Create(Type enumType, EnumConverterOptions converterOptions, JsonNamingPolicy namingPolicy, JsonSerializerOptions serializerOptions)
    {
        return (JsonConverter)Activator.CreateInstance(typeof(EnumConverter<Language>),
            converterOptions, namingPolicy, serializerOptions)!;
    }
}

/// <summary>
/// Custom Language Enum converter to avoid breaking changes when Google adds a new language to the list.
/// </summary>
public class LanguageEnumConverter : EnumConverter<Language>
{
    /// <summary>
    ///
    /// </summary>
    public LanguageEnumConverter(EnumConverterOptions converterOptions, JsonSerializerOptions serializerOptions) : base(converterOptions, serializerOptions)
    {
    }

    /// <summary>
    ///
    /// </summary>
    public LanguageEnumConverter(EnumConverterOptions converterOptions, JsonNamingPolicy namingPolicy, JsonSerializerOptions serializerOptions) : base(converterOptions, namingPolicy, serializerOptions)
    {
    }

    #region Overrides of JsonConverter<Language>

    /// <summary>
    ///
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public override Language Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            return base.Read(ref reader, typeToConvert, options);
        }
        catch (JsonException e)
        {
            if(e.Message.Contains($"Could not parse {nameof(Language)}"))
            {
                return Language.Unsupported;
            }

            throw;
        }

    }


    #endregion



}