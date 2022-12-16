using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Common.Converters;

/// <summary>
/// String Boolean Json Converter.
/// Converter for a <see cref="string"/> to a <see cref="string"/>.
/// If the string value is "1" then true, otherwise false.
/// </summary>
public class BooleanJsonConverter : JsonConverter<bool>
{
    /// <inheritdoc />
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == null)
            throw new ArgumentNullException(nameof(typeToConvert));
        
        if (options == null)
            throw new ArgumentNullException(nameof(options));

        try
        {
            return reader.GetBoolean();
        }
        catch (InvalidOperationException)
        {
            var boolString = reader
                .GetString();

            var value = boolString == "0"
                ? bool.FalseString
                : bool.TrueString;

            bool.TryParse(value, out var result);

            return result;
        }
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        if (writer == null)
            throw new ArgumentNullException(nameof(writer));
        
        if (options == null)
            throw new ArgumentNullException(nameof(options));
        
        var result = value
            ? "1"
            : "0";
        
        writer
            .WriteStringValue(result);
    }
}