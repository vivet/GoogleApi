

namespace GoogleApi.UnitTests
{
    internal static class Extensions
    {
#if NETCOREAPP3_1_OR_GREATER
        private static System.Text.Json.JsonSerializerOptions settings = new System.Text.Json.JsonSerializerOptions()
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
            Converters = { new CustomJsonStringEnumConverter(System.Text.Json.JsonNamingPolicy.CamelCase, true) },
            MaxDepth = 32,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            ReadCommentHandling = System.Text.Json.JsonCommentHandling.Skip,
            NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString | System.Text.Json.Serialization.JsonNumberHandling.AllowNamedFloatingPointLiterals,
            UnknownTypeHandling = System.Text.Json.Serialization.JsonUnknownTypeHandling.JsonElement,
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
        };

        internal static string ToJson(this object subject)
        {
            return System.Text.Json.JsonSerializer.Serialize(subject, settings);
        }
#else
        private static Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings()
        {
            Formatting = Newtonsoft.Json.Formatting.Indented,
            Converters = { new Newtonsoft.Json.Converters.StringEnumConverter() },
            ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver(),
            MaxDepth = 15,
            NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
        };

        internal static string ToJson(this object subject)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(subject, settings);
        }

#endif
    }
}

