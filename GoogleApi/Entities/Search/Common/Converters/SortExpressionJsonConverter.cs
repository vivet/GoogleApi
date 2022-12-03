using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Search.Common.Converters;

/// <summary>
/// Sort Expression Json Converter.
/// Converter for <see cref="SortExpression"/>.
/// </summary>
public class SortExpressionJsonConverter : JsonConverter<SortExpression>
{
    /// <inheritdoc />
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(SortExpression);
    }

    /// <inheritdoc />
    public override SortExpression Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == null)
            throw new ArgumentNullException(nameof(typeToConvert));

        if (options == null)
            throw new ArgumentNullException(nameof(options));

        return SortExpression.FromString(reader.GetString());
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, SortExpression value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}