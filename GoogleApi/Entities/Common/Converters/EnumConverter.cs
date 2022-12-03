using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters.Enums;

namespace GoogleApi.Entities.Common.Converters;

/// <summary>
/// Enum Converter.
/// </summary>
/// <typeparam name="T">The enum type.</typeparam>
public class EnumConverter<T> : JsonConverter<T>
    where T : struct, Enum
{
    private const int NAME_CACHE_SIZE_SOFT_LIMIT = 64;
    private const string VALUE_SEPARATOR = ", ";

    private static readonly string sNegativeSign = (int)sEnumTypeCode % 2 == 0 ? null : NumberFormatInfo.CurrentInfo.NegativeSign;
    private static readonly TypeCode sEnumTypeCode = Type.GetTypeCode(typeof(T));

    private Type TypeToConvert => typeof(T);
    private readonly EnumConverterOptions converterOptions;
    private readonly JsonNamingPolicy namingPolicy;
    private readonly ConcurrentDictionary<ulong, JsonEncodedText> nameCache;

    /// <inheritdoc />
    public EnumConverter(EnumConverterOptions converterOptions, JsonSerializerOptions serializerOptions)
        : this(converterOptions, namingPolicy: null, serializerOptions)
    {

    }

    /// <inheritdoc />
    public EnumConverter(EnumConverterOptions converterOptions, JsonNamingPolicy namingPolicy, JsonSerializerOptions serializerOptions)
    {
        this.converterOptions = converterOptions;
        this.namingPolicy = namingPolicy;
        nameCache = new ConcurrentDictionary<ulong, JsonEncodedText>();

        var names = Enum.GetNames(TypeToConvert);
        var values = Enum.GetValues(TypeToConvert);

        var encoder = serializerOptions.Encoder;

        for (var i = 0; i < names.Length; i++)
        {
            if (nameCache.Count >= NAME_CACHE_SIZE_SOFT_LIMIT)
            {
                break;
            }

            var value = (T)values.GetValue(i)!;
            var key = EnumConverter<T>.ConvertToUInt64(value);
            var name = names[i];

            nameCache.TryAdd(
                key,
                namingPolicy == null
                    ? JsonEncodedText.Encode(name, encoder)
                    : this.FormatEnumValue(name, encoder));
        }
    }

    /// <inheritdoc />
    public override bool CanConvert(Type type)
    {
        if (type == null)
            throw new ArgumentNullException(nameof(type));

        return type.IsEnum;
    }

    /// <inheritdoc />
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        JsonTokenType token = reader.TokenType;

        if (token == JsonTokenType.String)
        {
            if (!converterOptions.HasFlag(EnumConverterOptions.AllowStrings))
            {
                ThrowJsonException();
                return default;
            }

            return ReadAsPropertyNameCore(ref reader, typeToConvert, options);
        }

        if (token != JsonTokenType.Number || !converterOptions.HasFlag(EnumConverterOptions.AllowNumbers))
        {
            ThrowJsonException();
            return default;
        }

        switch (sEnumTypeCode)
        {
            // Switch cases ordered by expected frequency

            case TypeCode.Int32:
                if (reader.TryGetInt32(out int int32))
                {
                    return Unsafe.As<int, T>(ref int32);
                }
                break;
            case TypeCode.UInt32:
                if (reader.TryGetUInt32(out uint uint32))
                {
                    return Unsafe.As<uint, T>(ref uint32);
                }
                break;
            case TypeCode.UInt64:
                if (reader.TryGetUInt64(out ulong uint64))
                {
                    return Unsafe.As<ulong, T>(ref uint64);
                }
                break;
            case TypeCode.Int64:
                if (reader.TryGetInt64(out long int64))
                {
                    return Unsafe.As<long, T>(ref int64);
                }
                break;
            case TypeCode.SByte:
                if (reader.TryGetSByte(out sbyte byte8))
                {
                    return Unsafe.As<sbyte, T>(ref byte8);
                }
                break;
            case TypeCode.Byte:
                if (reader.TryGetByte(out byte ubyte8))
                {
                    return Unsafe.As<byte, T>(ref ubyte8);
                }
                break;
            case TypeCode.Int16:
                if (reader.TryGetInt16(out short int16))
                {
                    return Unsafe.As<short, T>(ref int16);
                }
                break;
            case TypeCode.UInt16:
                if (reader.TryGetUInt16(out ushort uint16))
                {
                    return Unsafe.As<ushort, T>(ref uint16);
                }
                break;
        }

        ThrowJsonException();
        return default;
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        // If strings are allowed, attempt to write it out as a string value
        if (converterOptions.HasFlag(EnumConverterOptions.AllowStrings))
        {
            ulong key = ConvertToUInt64(value);

            if (nameCache.TryGetValue(key, out JsonEncodedText formatted))
            {
                writer.WriteStringValue(formatted);
                return;
            }

            string original = value.ToString();
            if (IsValidIdentifier(original))
            {
                // We are dealing with a combination of flag constants since
                // all constant values were cached during warm-up.
                JavaScriptEncoder encoder = options.Encoder;

                if (nameCache.Count < NAME_CACHE_SIZE_SOFT_LIMIT)
                {
                    formatted = namingPolicy == null
                        ? JsonEncodedText.Encode(original, encoder)
                        : FormatEnumValue(original, encoder);

                    writer.WriteStringValue(formatted);

                    nameCache.TryAdd(key, formatted);
                }
                else
                {
                    // We also do not create a JsonEncodedText instance here because passing the string
                    // directly to the writer is cheaper than creating one and not caching it for reuse.
                    writer.WriteStringValue(
                        namingPolicy == null
                            ? original
                            : FormatEnumValueToString(original));
                }

                return;
            }
        }

        if (!converterOptions.HasFlag(EnumConverterOptions.AllowNumbers))
        {
            ThrowJsonException();
        }

        switch (sEnumTypeCode)
        {
            case TypeCode.Int32:
                writer.WriteNumberValue(Unsafe.As<T, int>(ref value));
                break;
            case TypeCode.UInt32:
                writer.WriteNumberValue(Unsafe.As<T, uint>(ref value));
                break;
            case TypeCode.UInt64:
                writer.WriteNumberValue(Unsafe.As<T, ulong>(ref value));
                break;
            case TypeCode.Int64:
                writer.WriteNumberValue(Unsafe.As<T, long>(ref value));
                break;
            case TypeCode.Int16:
                writer.WriteNumberValue(Unsafe.As<T, short>(ref value));
                break;
            case TypeCode.UInt16:
                writer.WriteNumberValue(Unsafe.As<T, ushort>(ref value));
                break;
            case TypeCode.Byte:
                writer.WriteNumberValue(Unsafe.As<T, byte>(ref value));
                break;
            case TypeCode.SByte:
                writer.WriteNumberValue(Unsafe.As<T, sbyte>(ref value));
                break;
            default:
                ThrowJsonException();
                break;
        }
    }

    internal T ReadAsPropertyNameCore(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string enumString = reader.GetString();
        enumString = namingPolicy?.ConvertName(enumString!);

        // Try parsing case sensitive first
        if (!Enum.TryParse(enumString, out T value)
            && !Enum.TryParse(enumString, ignoreCase: true, out value))
        {
            ThrowJsonException($"Could not parse {enumString}");
            //NOTE: in Release, maybe return default(T) ?
            //#if DEBUG
            //#else
            //return default(T);
            //#endif
        }

        return value;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void ThrowJsonException(string message = null)
    {
        throw new JsonException(message);
    }
    private static ulong ConvertToUInt64(object value)
    {
        Debug.Assert(value is T);
        var result = sEnumTypeCode switch
        {
            TypeCode.Int32 => (ulong)(int)value,
            TypeCode.UInt32 => (uint)value,
            TypeCode.UInt64 => (ulong)value,
            TypeCode.Int64 => (ulong)(long)value,
            TypeCode.SByte => (ulong)(sbyte)value,
            TypeCode.Byte => (byte)value,
            TypeCode.Int16 => (ulong)(short)value,
            TypeCode.UInt16 => (ushort)value,
            _ => throw new InvalidOperationException(),
        };
        return result;
    }
    private static bool IsValidIdentifier(string value)
    {
        // Trying to do this check efficiently. When an enum is converted to
        // string the underlying value is given if it can't find a matching
        // identifier (or identifiers in the case of flags).
        //
        // The underlying value will be given back with a digit (e.g. 0-9) possibly
        // preceded by a negative sign. Identifiers have to start with a letter
        // so we'll just pick the first valid one and check for a negative sign
        // if needed.
        return (value[0] >= 'A' &&
                (sNegativeSign == null || !value.StartsWith(sNegativeSign)));
    }
    private JsonEncodedText FormatEnumValue(string value, JavaScriptEncoder encoder)
    {
        Debug.Assert(namingPolicy != null);
        var formatted = FormatEnumValueToString(value);
        return JsonEncodedText.Encode(formatted, encoder);
    }
    private string FormatEnumValueToString(string value)
    {
        Debug.Assert(namingPolicy != null);

        string converted;
        if (!value.Contains(VALUE_SEPARATOR))
        {
            converted = namingPolicy.ConvertName(value);
        }
        else
        {
            // todo: optimize implementation here by leveraging https://github.com/dotnet/runtime/issues/934.
            var enumValues = value.Split(new[] { VALUE_SEPARATOR }, StringSplitOptions.None);

            for (var i = 0; i < enumValues.Length; i++)
            {
                enumValues[i] = namingPolicy.ConvertName(enumValues[i]);
            }

            converted = string.Join(VALUE_SEPARATOR, enumValues);
        }

        return converted;
    }
}