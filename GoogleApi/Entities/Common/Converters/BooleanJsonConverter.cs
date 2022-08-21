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
    /// <summary>
    ///
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        try
        {
            return reader.GetBoolean();
        }
        catch (InvalidOperationException)
        {
        }
        bool.TryParse(reader.GetString() == "0" ? bool.FalseString : bool.TrueString, out var result);

        return result;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options)
    {
        var result = value ? "1" : "0";
        writer.WriteStringValue(result);
    }

}