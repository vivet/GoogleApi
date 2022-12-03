using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters.Enums;

namespace GoogleApi.Entities.Common.Converters;

/// <summary>
///  Convert string values to Enum
/// </summary>
public class CustomJsonStringEnumConverter : JsonConverterFactory
{
    private readonly bool allowIntegerValues;
    private readonly JsonNamingPolicy namingPolicy;

    /// <inheritdoc />
    public CustomJsonStringEnumConverter()
        : this(null, true)
    {

    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="namingPolicy">The <see cref="JsonNamingPolicy"/>.</param>
    /// <param name="allowIntegerValues">Whether to allow integer values.</param>
    public CustomJsonStringEnumConverter(JsonNamingPolicy namingPolicy, bool allowIntegerValues)
    {
        this.namingPolicy = namingPolicy ?? throw new ArgumentNullException(nameof(namingPolicy));
        this.allowIntegerValues = allowIntegerValues;
    }

    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert)
    {
        if (typeToConvert == null)
            throw new ArgumentNullException(nameof(typeToConvert));

        return typeToConvert.IsEnum;
    }

    /// <inheritdoc />
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == null)
            throw new ArgumentNullException(nameof(typeToConvert));

        if (options == null)
            throw new ArgumentNullException(nameof(options));

        var policy = this.namingPolicy;

        var query = from field in typeToConvert.GetFields(BindingFlags.Public | BindingFlags.Static)
                    let attr = field.GetCustomAttribute<EnumMemberAttribute>()
                    where attr != null
                    select (field.Name, attr.Value);
        var dictionary = query.ToDictionary(p => p.Item1, p => p.Item2);
        if (dictionary.Count > 0)
        {
            policy = new DictionaryLookupNamingPolicy(dictionary, namingPolicy);
        }

        return Create(
            typeToConvert,
            this.allowIntegerValues
                ? EnumConverterOptions.AllowStrings | EnumConverterOptions.AllowNumbers
                : EnumConverterOptions.AllowStrings,
            policy,
            options);
    }

    private static Type GetEnumConverterType(Type enumType)
    {
        if (enumType == null)
            throw new ArgumentNullException(nameof(enumType));

        return typeof(EnumConverter<>).MakeGenericType(enumType);
    }
    private static JsonConverter Create(Type enumType, EnumConverterOptions converterOptions, JsonNamingPolicy namingPolicy, JsonSerializerOptions serializerOptions)
    {
        if (enumType == null)
            throw new ArgumentNullException(nameof(enumType));

        if (namingPolicy == null)
            throw new ArgumentNullException(nameof(namingPolicy));

        if (serializerOptions == null)
            throw new ArgumentNullException(nameof(serializerOptions));

        return (JsonConverter)Activator.CreateInstance(GetEnumConverterType(enumType), converterOptions, namingPolicy, serializerOptions)!;
    }
}