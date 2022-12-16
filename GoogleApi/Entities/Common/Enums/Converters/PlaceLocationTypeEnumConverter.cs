using System;
using System.Text.Json;
using GoogleApi.Entities.Common.Converters;
using GoogleApi.Entities.Common.Converters.Enums;

namespace GoogleApi.Entities.Common.Enums.Converters;

/// <summary>
/// Custom <see cref="PlaceLocationType"/> Enum converter
/// to avoid breaking changes when Google adds a new <inheritdoc cref="PlaceLocationType"/>'s to the list.
/// </summary>
public class PlaceLocationTypeEnumConverter : EnumConverter<PlaceLocationType>
{
    /// <inheritdoc />
    public PlaceLocationTypeEnumConverter(EnumConverterOptions converterOptions, JsonSerializerOptions serializerOptions)
        : base(converterOptions, serializerOptions)
    {

    }

    /// <inheritdoc />
    public PlaceLocationTypeEnumConverter(EnumConverterOptions converterOptions, JsonNamingPolicy namingPolicy, JsonSerializerOptions serializerOptions)
        : base(converterOptions, namingPolicy, serializerOptions)
    {

    }

    /// <inheritdoc />
    public override PlaceLocationType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
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
            return PlaceLocationType.Unknown;
        }
    }
}