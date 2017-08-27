using System;
using GoogleApi.Entities.Search.Common.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoogleApi.Entities.Search.Common.Converters
{
    /// <summary>
    /// Site Search Json Converter.
    /// Converter for <see cref="SiteSearch"/>.
    /// </summary>
    public class SiteSearchJsonConverter : JsonConverter
    {
        /// <inheritdoc />
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SiteSearch);
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
            var parent = token.Parent;

            Enum.TryParse(parent.SelectToken("siteSearchFilter").ToString(), true, out SiteSearchFilter filter);

            return new SiteSearch
            {
                Site = token.ToString(),
                Filter = filter
            };
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