using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GoogleApi.Entities.Common.Converters;

/// <summary>
/// Json String Enum Member Converter.
/// </summary>
/// <typeparam name="T">The enum type.</typeparam>
public class JsonStringEnumMemberConverter<T> : JsonConverter<T> 
    where T : struct, Enum
{
    private readonly Dictionary<string, T> fromString;
    private readonly Dictionary<T, string> toString;

    /// <summary>
    /// Constructor.
    /// </summary>
    public JsonStringEnumMemberConverter()
    {
        this.fromString = new Dictionary<string, T>(StringComparer.OrdinalIgnoreCase);
        this.toString = new Dictionary<T, string>();

        foreach (var field in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var name = field.Name;
            var enumValue = (T)field.GetValue(null);

            var enumMemberAttribute = field
                .GetCustomAttribute<EnumMemberAttribute>();
            
            var value = enumMemberAttribute?.Value ?? name;

            this.fromString[value] = enumValue;
            this.toString[enumValue] = value;
        }
    }

    /// <inheritdoc />
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == null)
            throw new ArgumentNullException(nameof(typeToConvert));

        if (options == null)
            throw new ArgumentNullException(nameof(options));

        if (reader.TokenType == JsonTokenType.String)
        {
            var enumText = reader
                .GetString();

            if (enumText == null)
            {
                throw new NullReferenceException(nameof(enumText));
            }

            if (fromString.TryGetValue(enumText, out var enumValue))
            {
                return enumValue;
            }
        }
        else
        {
            var enumNumber = reader
                .GetInt32();

            return (T)Enum.ToObject(typeof(T), enumNumber);
        }

        throw new JsonException($"Unable to convert \"{reader.GetString()}\" to enum \"{typeof(T)}\"");
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        if (writer == null) 
            throw new ArgumentNullException(nameof(writer));

        if (options == null) 
            throw new ArgumentNullException(nameof(options));

        var stringValue = toString.TryGetValue(value, out var enumString) 
            ? enumString 
            : value.ToString();

        writer
            .WriteStringValue(stringValue);
    }
}