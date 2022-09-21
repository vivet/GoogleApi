using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Linq;
using GoogleApi.Entities.Translate.Common.Enums.Extensions;

namespace GoogleApi.Entities.Translate.Common.Enums.Converters;

/// <summary>
/// Custom Language Enum converter to avoid breaking changes when Google adds a new language to the list.
/// </summary>
public class LanguageEnumConverter : StringEnumConverter
{
    /// <inheritdoc />
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        if (reader == null)
            throw new ArgumentNullException(nameof(reader));

        if (objectType == null)
            throw new ArgumentNullException(nameof(objectType));

        if (serializer == null)
            throw new ArgumentNullException(nameof(serializer));

        var enumString = (string)reader.Value;

        var values = Enum.GetValues(typeof(Language))
            .Cast<Language>()
            .Select(x => new
            {
                Name = x.ToString(),
                Language = x,
                Code = x.GetEnumMemberValue()
            });

        try
        {
            return values
                .Where(x => string.Equals(x.Code, enumString, StringComparison.InvariantCultureIgnoreCase))
                .Select(x => x.Language)
                .FirstOrDefault();
        }
        catch (InvalidOperationException)
        {
            return Language.Unsupported;
        }
    }
}