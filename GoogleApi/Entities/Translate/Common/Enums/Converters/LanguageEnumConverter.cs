using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Utilities;
using System.Reflection;
using System.Runtime.Serialization;
using System;
using System.Globalization;
using System.Linq;
using GoogleApi.Entities.Translate.Common.Enums.Extensions;

namespace GoogleApi.Entities.Translate.Common.Enums.Converters
{
    /// <summary>
    /// Custom Language Enum converter to avoid breaking changes when Google adds a new language to the list.
    /// </summary>
    public class LanguageEnumConverter : StringEnumConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return base.CanConvert(objectType);
        }

        /// <summary>
        /// Attempts to convert the object into a Language. If it can't find the object, it returns Language.Unsupported.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The enum object representing the language or Language.Unsupported.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var enumString = (string)reader.Value;
            
            var list = Enum.GetValues(typeof(Language)).Cast<Language>().Select(s => new LanguageDetails
            {
                Name = s.ToString(),
                Language = s,
                Code = s.GetEnumMemberValue()
            }).ToList();

            try
            {
                return list.Where(w => string.Equals(w.Code, enumString, StringComparison.InvariantCultureIgnoreCase))
                .Select(s => s.Language)
                .First();
            }
            catch(InvalidOperationException)
            {
                //if the list does not contain the language code in question.
                return Language.Unsupported;
            }
        }

        private struct LanguageDetails
        {
            public string Name { get; set; }
            public string Code { get; set; }
            public Language Language { get; set; }
        }

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            base.WriteJson(writer, value, serializer);
        }
    }
}
