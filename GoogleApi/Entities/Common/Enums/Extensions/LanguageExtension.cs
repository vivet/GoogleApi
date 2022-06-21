namespace GoogleApi.Entities.Common.Enums.Extensions;

/// <summary>
/// Language Extension methods.
/// </summary>
public static class LanguageExtension
{
    /// <summary>
    /// Gets the ISO-639-1 code for the specified <see cref="Language"/>.
    /// </summary>
    /// <param name="language">The <see cref="Language"/>.</param>
    /// <returns>The ISO-639-1 code matching the passed <paramref name="language"/>.</returns>
    public static string ToCode(this Language language)
    {
        return language switch
        {
            Language.Afrikaans => "af",
            Language.Albanian => "sq",
            Language.Amharic => "am",
            Language.Arabic => "ar",
            Language.Armenian => "hy",
            Language.Azerbaijani => "az",
            Language.Basque => "eu",
            Language.Belarusian => "be",
            Language.Bengali => "bn",
            Language.Bosnian => "bs",
            Language.Bulgarian => "bg",
            Language.Burmese => "my",
            Language.Catalan => "ca",
            Language.Chinese => "zh",
            Language.ChineseSimplified => "zh-CN",
            Language.ChineseHongKong => "zh-HK",
            Language.ChineseTraditional => "zh-TW",
            Language.Croatian => "hr",
            Language.Czech => "cs",
            Language.Danish => "da",
            Language.Dutch => "nl",
            Language.English => "en",
            Language.EnglishAustralian => "en-AU",
            Language.EnglishGreatBritain => "en-GB",
            Language.Estonian => "et",
            Language.Farsi => "fa",
            Language.Finnish => "fi",
            Language.Filipino => "fil",
            Language.French => "fr",
            Language.FrenchCanada => "fr-CA",
            Language.Galician => "gl",
            Language.Georgian => "ka",
            Language.German => "de",
            Language.Greek => "el",
            Language.Gujarati => "gu",
            Language.Hebrew => "iw",
            Language.Hindi => "hi",
            Language.Hungarian => "hu",
            Language.Icelandic => "is",
            Language.Indonesian => "id",
            Language.Italian => "it",
            Language.Japanese => "ja",
            Language.Kannada => "kn",
            Language.Kazakh => "kk",
            Language.Khmer => "km",
            Language.Korean => "ko",
            Language.Kyrgyz => "ky",
            Language.Lao => "lo",
            Language.Latvian => "lv",
            Language.Lithuanian => "lt",
            Language.Macedonian => "mk",
            Language.Malay => "ms",
            Language.Malayalam => "ml",
            Language.Marathi => "mr",
            Language.Mongolian => "mn",
            Language.Nepali => "ne",
            Language.Norwegian => "no",
            Language.Polish => "pl",
            Language.Portuguese => "pt",
            Language.PortugueseBrazil => "pt-BR",
            Language.PortuguesePortugal => "pt-PT",
            Language.Punjabi => "pa",
            Language.Romanian => "ro",
            Language.Russian => "ru",
            Language.Serbian => "sr",
            Language.Sinhalese => "si",
            Language.Slovak => "sk",
            Language.Slovenian => "sl",
            Language.Spanish => "es",
            Language.SpanishLatinAmerica => "es-419",
            Language.Swahili => "sw",
            Language.Swedish => "sv",
            Language.Tamil => "ta",
            Language.Telugu => "te",
            Language.Thai => "th",
            Language.Turkish => "tr",
            Language.Ukrainian => "uk",
            Language.Urdu => "ur",
            Language.Uzbek => "uz",
            Language.Vietnamese => "vi",
            Language.Zulu => "zu",
            _ => null
        };
    }
}