using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Common.Converters.Factories;

/// <summary>
/// Json String Enum Converter Factory.
/// </summary>
public class JsonStringEnumConverterFactory : JsonConverterFactory
{
    private readonly Dictionary<Type, JsonConverter> customConverters;

    /// <summary>
    /// Constructor.
    /// </summary>
    public JsonStringEnumConverterFactory()
    {
        this.customConverters = new Dictionary<Type, JsonConverter>
        {
            { typeof(Entities.Common.Enums.Language), new JsonStringEnumOrDefaultConverter<Entities.Common.Enums.Language>() },
            { typeof(Entities.Common.Enums.AddressComponentType), new JsonStringEnumOrDefaultConverter<Entities.Common.Enums.AddressComponentType>() },
            { typeof(Entities.Common.Enums.PlaceLocationType), new JsonStringEnumOrDefaultConverter<Entities.Common.Enums.PlaceLocationType>() },
            { typeof(Entities.Translate.Common.Enums.Language), new JsonStringEnumOrDefaultConverter<Entities.Translate.Common.Enums.Language>() }
        };
    }

    /// <inheritdoc />
    public override bool CanConvert(Type typeToConvert) => typeToConvert.IsEnum;

    /// <inheritdoc />
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == null) 
            throw new ArgumentNullException(nameof(typeToConvert));
        
        if (options == null) 
            throw new ArgumentNullException(nameof(options));
        
        if (customConverters.TryGetValue(typeToConvert, out var converter))
        {
            return converter;
        }

        var enumMemberConverterType = typeof(JsonStringEnumMemberConverter<>).MakeGenericType(typeToConvert);

        return (JsonConverter)Activator.CreateInstance(enumMemberConverterType);
    }
}