using System;
using System.Text.Json;

namespace GoogleApi.Entities.Common.Converters;

/// <summary>
/// Json String Enum Or Default Converter.
/// </summary>
/// <typeparam name="T">The enum type.</typeparam>
public class JsonStringEnumOrDefaultConverter<T> : JsonStringEnumMemberConverter<T> 
    where T : struct, Enum
{
    private readonly T defaultValue;

    /// <summary>
    /// Constructor.
    /// </summary>
    public JsonStringEnumOrDefaultConverter() 
        : this(default)
    {
    }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="defaultValue">The dafault value.</param>
    public JsonStringEnumOrDefaultConverter(T defaultValue)
    {
        this.defaultValue = defaultValue;
    }

    /// <inheritdoc />
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (typeToConvert == null) 
            throw new ArgumentNullException(nameof(typeToConvert));
        
        if (options == null) 
            throw new ArgumentNullException(nameof(options));

        try
        {
            return base.Read(ref reader, typeToConvert, options);
        }
        catch
        {
            return this.defaultValue;
        }
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        if (writer == null)
            throw new ArgumentNullException(nameof(writer));

        if (options == null)
            throw new ArgumentNullException(nameof(options));

        base.Write(writer, value, options);
    }
}