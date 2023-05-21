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
public class EnumJsonConverterFactory : JsonConverterFactory
{
    /// <summary>
    /// Allow Integer Values.
    /// </summary>
    protected readonly bool allowIntegerValues;

    /// <summary>
    /// Json Naming Policy.
    /// </summary>
    protected readonly JsonNamingPolicy jsonNamingPolicy;

    /// <inheritdoc />
    public EnumJsonConverterFactory()
        : this(null, true)
    {

    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="namingPolicy">The <see cref="JsonNamingPolicy"/>.</param>
    /// <param name="allowIntegerValues">Whether to allow integer values.</param>
    public EnumJsonConverterFactory(JsonNamingPolicy namingPolicy, bool allowIntegerValues)
    {
        this.jsonNamingPolicy = namingPolicy ?? throw new ArgumentNullException(nameof(namingPolicy));
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

        var policy = this.jsonNamingPolicy;

        var query = from field in typeToConvert.GetFields(BindingFlags.Public | BindingFlags.Static)
                    let attr = field.GetCustomAttribute<EnumMemberAttribute>()
                    where attr != null
                    select (field.Name, attr.Value);
        var dictionary = query.ToDictionary(p => p.Item1, p => p.Item2);
        if (dictionary.Count > 0)
        {
            policy = new DictionaryLookupNamingPolicy(dictionary, jsonNamingPolicy);
        }

        var enumConverterOptions = allowIntegerValues
            ? EnumConverterOptions.AllowStrings | EnumConverterOptions.AllowNumbers
            : EnumConverterOptions.AllowStrings;

        var converterType = typeof(EnumJsonConverter<>).MakeGenericType(typeToConvert);

        return (JsonConverter)Activator.CreateInstance(converterType, enumConverterOptions, policy, options);
    }
}

/// <summary>
/// Enum Converter Factory.
/// </summary>
public class EnumJsonConverterFactory<TEnum, TConverter> : EnumJsonConverterFactory
    where TEnum : struct, Enum
    where TConverter : EnumJsonConverter<TEnum>
{
    /// <inheritdoc />
    public EnumJsonConverterFactory()
        : this(null, true)
    {

    }

    /// <inheritdoc />
    public EnumJsonConverterFactory(JsonNamingPolicy namingPolicy, bool allowIntegerValues)
        : base(namingPolicy, allowIntegerValues)
    {

    }

    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert) => base.CanConvert(typeToConvert) && typeToConvert == typeof(TEnum);

    /// <inheritdoc />
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == null)
            throw new ArgumentNullException(nameof(typeToConvert));

        if (options == null)
            throw new ArgumentNullException(nameof(options));

        var policy = this.jsonNamingPolicy;

        var query = from field in typeToConvert
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                    let attr = field.GetCustomAttribute<EnumMemberAttribute>()
                    where attr != null
                    select (field.Name, attr.Value);

        var dictionary = query
            .ToDictionary(x => x.Item1, x => x.Item2);

        if (dictionary.Count > 0)
        {
            policy = new DictionaryLookupNamingPolicy(dictionary, jsonNamingPolicy);
        }

        var enumConverterOptions = allowIntegerValues
            ? EnumConverterOptions.AllowStrings | EnumConverterOptions.AllowNumbers
            : EnumConverterOptions.AllowStrings;

        return (JsonConverter)Activator.CreateInstance(typeof(TConverter), enumConverterOptions, policy, options);
    }
}