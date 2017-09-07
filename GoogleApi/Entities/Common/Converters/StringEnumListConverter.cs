using System;
using System.Collections.Generic;
using System.Linq;
using GoogleApi.Entities.Common.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoogleApi.Entities.Common.Converters
{
    /// <summary>
    /// String Enum List Json Converter.
    /// Converter for a comma separated <see cref="string"/> of items, to a <see cref="List{T}"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StringEnumListConverter<T> : JsonConverter
        where T: struct 
    {
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            if (objectType == null)
                throw new ArgumentNullException(nameof(objectType));

            return objectType == typeof(T);
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
            var @string = token.ToString();

            return @string.Split(',').Select(x =>
            {
                var success = Enum.TryParse(x, true, out T type);

                return success ? type : default(T);
            });
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