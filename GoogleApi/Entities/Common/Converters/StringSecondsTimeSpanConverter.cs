using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Common.Converters;

/// <summary>
/// String Seconds TimeSpan Converter.
/// </summary>
public class StringSecondsTimeSpanConverter : JsonConverter<TimeSpan>
{
    /// <inheritdoc />
    public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == null)
            throw new ArgumentNullException(nameof(typeToConvert));

        if (options == null)
            throw new ArgumentNullException(nameof(options));

        var rawvalue = reader
            .GetString();

        var durationString = rawvalue?
            .Remove(rawvalue.Length - 1);

        var success = decimal.TryParse(durationString, out var duration);

        return success
            ? TimeSpan.FromSeconds((int)duration)
            : TimeSpan.Zero;
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}