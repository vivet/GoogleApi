using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.Routes.Directions.Response.Converters;

/// <summary>
/// Coordinate Tuples Converter.
/// </summary>
public class CoordinateTuplesJsonConverter : JsonConverter<IEnumerable<LatLng>>
{
    /// <inheritdoc />
    public override IEnumerable<LatLng> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == null)
            throw new ArgumentNullException(nameof(typeToConvert));

        if (options == null)
            throw new ArgumentNullException(nameof(options));

        using var document = JsonDocument.ParseValue(ref reader);

        var jsonString = document.RootElement.GetRawText();
        var coordinates = JsonSerializer.Deserialize<IEnumerable<double[]>>(jsonString, options);

        return coordinates?
            .Select(x =>
            {
                var latitude = x[0];
                var longitide = x[1];

                return new LatLng
                {
                    Latitude = latitude,
                    Longitude = longitide
                };
            });
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, IEnumerable<LatLng> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}