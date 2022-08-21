using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GoogleApi.Entities.Common.Converters;

/// <summary>
/// Converts a <see cref="string"/> to an <see cref="Enum"/> of type <typeparamref name="T"/>.
/// If no enum member is found, default(T) it returned.
/// </summary>
/// <typeparam name="T"><see cref="Enum"/> type.</typeparam>
public class StringEnumOrDefaultConverter<T> : StringEnumConverter
    where T : struct
{
    /// <inheritdoc />
    public override bool CanConvert(Type type)
    {
        if (type == null)
            throw new ArgumentNullException(nameof(type));

        return base.CanConvert(typeof(T));
    }

    /// <inheritdoc />
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader == null)
            throw new ArgumentNullException(nameof(reader));

        if (objectType == null)
            throw new ArgumentNullException(nameof(objectType));

        if (serializer == null)
            throw new ArgumentNullException(nameof(serializer));

        try
        {
            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
        catch
        {
            return default(T);
        }
    }

    /// <inheritdoc />
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (writer == null)
            throw new ArgumentNullException(nameof(writer));

        if (value == null)
            throw new ArgumentNullException(nameof(value));

        if (serializer == null)
            throw new ArgumentNullException(nameof(serializer));

        base.WriteJson(writer, value, serializer);
    }
}