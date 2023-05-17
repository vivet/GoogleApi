using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Maps.Routes.Matrix.Response.Converters;

/// <summary>
/// Routes Matrix Response Converter.
/// </summary>
public class RoutesMatrixResponseConverter : JsonConverter<RoutesMatrixResponse>
{
    /// <inheritdoc />
    public override RoutesMatrixResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == null)
            throw new ArgumentNullException(nameof(typeToConvert));

        if (options == null)
            throw new ArgumentNullException(nameof(options));

        using var document = JsonDocument.ParseValue(ref reader);
        var jsonString = document.RootElement.GetRawText();

        var elements = JsonSerializer.Deserialize<IEnumerable<MatrixElement>>(jsonString);

        return new RoutesMatrixResponse
        {
            Elements = elements
        };
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, RoutesMatrixResponse value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}