namespace GoogleApi.Entities.Translate.Common.Enums.Extensions;

/// <summary>
/// Language Extensions.
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
            Language.Azeerbaijani => "az",
            Language.Basque => "eu",
            Language.Belarusian => "be",
            Language.Bengali => "bn",
            Language.Bosnian => "bs",
            Language.Bulgarian => "bg",
            Language.Catalan => "ca",
            Language.Cebuano => "ceb",
            Language.Chichewa => "ny",
            Language.Chinese => "zh-CN",
            Language.Chinese_Simplified => "zh-CN",
            Language.Chinese_Traditional => "zh-TW",
            Language.Corsican => "co",
            Language.Croatian => "hr",
            Language.Czech => "cs",
            Language.Danish => "da",
            Language.Dutch => "nl",
            Language.English => "en",
            Language.Esperanto => "eo",
            Language.Estonian => "et",
            Language.Filipino => "tl",
            Language.Finnish => "fi",
            Language.French => "fr",
            Language.Frisian => "fy",
            Language.Galician => "gl",
            Language.Georgian => "ka",
            Language.German => "de",
            Language.Greek => "el",
            Language.Gujarati => "gu",
            Language.Haitian_Creole => "ht",
            Language.Hausa => "ha",
            Language.Hawaiian => "haw",
            Language.Hebrew => "iw",
            Language.Hindi => "hi",
            Language.Hmong => "hmn",
            Language.Hungarian => "hu",
            Language.Icelandic => "is",
            Language.Igbo => "ig",
            Language.Indonesian => "id",
            Language.Irish => "ga",
            Language.Italian => "it",
            Language.Japanese => "ja",
            Language.Javanese => "jw",
            Language.Kannada => "kn",
            Language.Kazakh => "kk",
            Language.Khmer => "km",
            Language.Korean => "ko",
            Language.Kurdish => "ku",
            Language.Kyrgyz => "ky",
            Language.Lao => "lo",
            Language.Latin => "la",
            Language.Latvian => "lv",
            Language.Lithuanian => "lt",
            Language.Luxembourgish => "lb",
            Language.Macedonian => "mk",
            Language.Malagasy => "mg",
            Language.Malay => "ms",
            Language.Malayalam => "ml",
            Language.Maltese => "mt",
            Language.Maori => "mi",
            Language.Marathi => "mr",
            Language.Mizo => "lus",
            Language.Mongolian => "mn",
            Language.Burmese => "my",
            Language.Nepali => "ne",
            Language.Norwegian => "no",
            Language.Pashto => "ps",
            Language.Persian => "fa",
            Language.Polish => "pl",
            Language.Portuguese => "pt",
            Language.Punjabi => "ma",
            Language.Romanian => "ro",
            Language.Russian => "ru",
            Language.Samoan => "sm",
            Language.Scots_Gaelic => "gd",
            Language.Serbian => "sr",
            Language.Sesotho => "st",
            Language.Shona => "sn",
            Language.Sindhi => "sd",
            Language.Sinhala => "si",
            Language.Slovak => "sk",
            Language.Slovenian => "sl",
            Language.Somali => "so",
            Language.Spanish => "es",
            Language.Sundanese => "su",
            Language.Swahili => "sw",
            Language.Swedish => "sv",
            Language.Tajik => "tg",
            Language.Tamil => "ta",
            Language.Telugu => "te",
            Language.Thai => "th",
            Language.Turkish => "tr",
            Language.Ukrainian => "uk",
            Language.Urdu => "ur",
            Language.Uzbek => "uz",
            Language.Vietnamese => "vi",
            Language.Welsh => "cy",
            Language.Xhosa => "xh",
            Language.Yiddish => "yi",
            Language.Yoruba => "yo",
            Language.Zulu => "zu",
            Language.HebrewOld => "iw",
            Language.Kinyarwanda => "rw",
            Language.Odia => "or",
            Language.Tatar => "tt",
            Language.Turkmen => "tk",
            Language.Uyghur => "ug",
            _ => string.Empty
        };
    }

    /// <summary>
    /// Determines whether the <see cref="Language"/> passed is comptabile with <see cref="Model.Nmt"/>.
    /// https://cloud.google.com/translate/docs/languages
    /// </summary>
    /// <param name="language">The <see cref="Language"/> to evaluate.</param>
    /// <returns>True, if compatable with <see cref="Model.Nmt"/>, otherwise false.</returns>
    public static bool IsValidNmt(this Language language)
    {
        switch (language)
        {
            case Language.Afrikaans:
            case Language.Albanian:
            case Language.Amharic:
            case Language.Arabic:
            case Language.Armenian:
            case Language.Azeerbaijani:
            case Language.Basque:
            case Language.Belarusian:
            case Language.Bengali:
            case Language.Bosnian:
            case Language.Bulgarian:
            case Language.Burmese:
            case Language.Catalan:
            case Language.Cebuano:
            case Language.Chinese:
            case Language.Chinese_Simplified:
            case Language.Chinese_Traditional:
            case Language.Corsican:
            case Language.Croatian:
            case Language.Czech:
            case Language.Danish:
            case Language.Dutch:
            case Language.English:
            case Language.Esperanto:
            case Language.Estonian:
            case Language.Finnish:
            case Language.French:
            case Language.Frisian:
            case Language.Galician:
            case Language.Georgian:
            case Language.German:
            case Language.Greek:
            case Language.Gujarati:
            case Language.Haitian_Creole:
            case Language.Hausa:
            case Language.Hawaiian:
            case Language.Hebrew:
            case Language.Hindi:
            case Language.Hmong:
            case Language.Hungarian:
            case Language.Icelandic:
            case Language.Igbo:
            case Language.Indonesian:
            case Language.Irish:
            case Language.Italian:
            case Language.Japanese:
            case Language.Javanese:
            case Language.Kannada:
            case Language.Kazakh:
            case Language.Khmer:
            case Language.Kinyarwanda:
            case Language.Korean:
            case Language.Kurdish:
            case Language.Kyrgyz:
            case Language.Lao:
            case Language.Latin:
            case Language.Latvian:
            case Language.Lithuanian:
            case Language.Luxembourgish:
            case Language.Macedonian:
            case Language.Malagasy:
            case Language.Malay:
            case Language.Malayalam:
            case Language.Maltese:
            case Language.Maori:
            case Language.Marathi:
            case Language.Mongolian:
            case Language.Nepali:
            case Language.Norwegian:
            case Language.Odia:
            case Language.Pashto:
            case Language.Persian:
            case Language.Polish:
            case Language.Portuguese:
            case Language.Punjabi:
            case Language.Romanian:
            case Language.Russian:
            case Language.Samoan:
            case Language.Scots_Gaelic:
            case Language.Serbian:
            case Language.Sesotho:
            case Language.Shona:
            case Language.Sindhi:
            case Language.Sinhala:
            case Language.Slovak:
            case Language.Slovenian:
            case Language.Somali:
            case Language.Spanish:
            case Language.Sundanese:
            case Language.Swahili:
            case Language.Swedish:
            case Language.Tajik:
            case Language.Tamil:
            case Language.Tatar:
            case Language.Telugu:
            case Language.Thai:
            case Language.Turkish:
            case Language.Turkmen:
            case Language.Ukrainian:
            case Language.Urdu:
            case Language.Uyghur:
            case Language.Uzbek:
            case Language.Vietnamese:
            case Language.Welsh:
            case Language.Xhosa:
            case Language.Yiddish:
            case Language.Yoruba:
            case Language.Zulu:
                return true;
            case Language.Chichewa:
            case Language.Filipino:
            case Language.HebrewOld:
            case Language.Akan:
            case Language.Assamese:
            case Language.Aymara:
            case Language.DivehiDhivehiMaldivian:
            case Language.DutchMiddleAge:
            case Language.Ganda:
            case Language.Guarani:
            case Language.Krio:
            case Language.Lingala:
            case Language.Sepedi:
            case Language.Oromo:
            case Language.Quechua:
            case Language.Sanskrit:
            case Language.Tigrinya:
            case Language.Tsonga:
            case Language.Bambara:
            case Language.Bhojpuri:
            case Language.CentralKurdish:
            case Language.Dogri:
            case Language.GoanKonkani:
            case Language.Iloko:
            case Language.Maithili:
            case Language.Manipuri:
            case Language.Mizo:
                return false;

            default:
                return false;
        }
    }
}