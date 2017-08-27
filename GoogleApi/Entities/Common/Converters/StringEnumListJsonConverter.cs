using System;
using System.Collections.Generic;
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
    public class StringEnumListJsonConverter<T> : JsonConverter
        where T: struct 
    {
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
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

            return token.ToString().ToStringEnum<T>();
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