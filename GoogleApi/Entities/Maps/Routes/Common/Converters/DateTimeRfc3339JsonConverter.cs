using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Maps.Routes.Common.Converters;

/// <summary>
/// Date Time Json Converter.
/// </summary>
public class DateTimeRfc3339JsonConverter : JsonConverter<DateTime?>
{
    /// <inheritdoc />
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (writer == null)
            throw new ArgumentNullException(nameof(writer));

        if (options == null)
            throw new ArgumentNullException(nameof(options));

        if (value == null)
        {
            return;
        }

        var rfc3339 = JsonSerializer.Serialize(value.Value);

        rfc3339 = rfc3339
            .Replace("\"", "");

        writer
            .WriteStringValue(rfc3339);
    }
}