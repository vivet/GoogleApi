using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Search.Common.Converters;

/// <summary>
/// Date Restrict Json Converter.
/// Converter for <see cref="DateRestrict"/>.
/// </summary>
public class DateRestrictJsonConverter : JsonConverter<DateRestrict>
{
    /// <inheritdoc />
    public override bool CanConvert(Type objectType)
    {
        if (objectType == null) 
            throw new ArgumentNullException(nameof(objectType));
        
        return objectType == typeof(DateRestrict);
    }

    /// <inheritdoc />
    public override DateRestrict Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == null)
            throw new ArgumentNullException(nameof(typeToConvert));

        if (options == null)
            throw new ArgumentNullException(nameof(options));

        return DateRestrict.FromString(reader.GetString());
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, DateRestrict value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}