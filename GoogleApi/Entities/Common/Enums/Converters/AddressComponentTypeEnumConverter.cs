using System;
using System.Text.Json;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.Common.Converters.Enums;

namespace GoogleApi.Entities.Common.Enums.Converters;

/// <summary>
/// Custom <see cref="AddressComponentType"/> Enum converter
/// to avoid breaking changes when Google adds a new <inheritdoc cref="AddressComponentType"/>'s to the list.
/// </summary>
public class AddressComponentTypeEnumConverter : EnumConverter<AddressComponentType>
{
    /// <inheritdoc />
    public AddressComponentTypeEnumConverter(EnumConverterOptions converterOptions, JsonSerializerOptions serializerOptions)
        : base(converterOptions, serializerOptions)
    {

    }

    /// <inheritdoc />
    public AddressComponentTypeEnumConverter(EnumConverterOptions converterOptions, JsonNamingPolicy namingPolicy, JsonSerializerOptions serializerOptions)
        : base(converterOptions, namingPolicy, serializerOptions)
    {

    }

    /// <inheritdoc />
    public override AddressComponentType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == null)
            throw new ArgumentNullException(nameof(typeToConvert));

        if (options == null)
            throw new ArgumentNullException(nameof(options));

        try
        {
            return base.Read(ref reader, typeToConvert, options);
        }
        catch (JsonException)
        {
            return AddressComponentType.Unknown;
        }
    }
}