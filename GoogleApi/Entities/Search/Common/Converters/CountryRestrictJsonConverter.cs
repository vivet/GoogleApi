using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoogleApi.Entities.Search.Common.Converters
{
    /// <summary>
    /// Country Restrict Json Converter.
    /// Converter for <see cref="CountryRestrict"/>.
    /// </summary>
    public class CountryRestrictJsonConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(CountryRestrict);
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

            var token = JToken.Load(reader);

            return new CountryRestrict().FromString(token.ToString());
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

            throw new NotImplementedException();
        }
    }
}