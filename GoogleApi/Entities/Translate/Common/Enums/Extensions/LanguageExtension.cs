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
            case Language.Afrikaans: return true;
            case Language.Arabic: return true;
            case Language.Bulgarian: return true;
            case Language.Chinese_Simplified: return true;
            case Language.Chinese_Traditional: return true;
            case Language.Croatian: return true;
            case Language.Czech: return true;
            case Language.Danish: return true;
            case Language.Dutch: return true;
            case Language.English: return true;
            case Language.French: return true;
            case Language.German: return true;
            case Language.Greek: return true;
            case Language.Hebrew: return true;
            case Language.Hindi: return true;
            case Language.Icelandic: return true;
            case Language.Indonesian: return true;
            case Language.Italian: return true;
            case Language.Japanese: return true;
            case Language.Korean: return true;
            case Language.Norwegian: return true;
            case Language.Polish: return true;
            case Language.Portuguese: return true;
            case Language.Romanian: return true;
            case Language.Russian: return true;
            case Language.Slovak: return true;
            case Language.Spanish: return true;
            case Language.Swedish: return true;
            case Language.Thai: return true;
            case Language.Turkish: return true;
            case Language.Vietnamese: return true;

            case Language.Albanian:
            case Language.Amharic:
            case Language.Armenian:
            case Language.Azeerbaijani:
            case Language.Basque:
            case Language.Belarusian:
            case Language.Bengali:
            case Language.Bosnian:
            case Language.Catalan:
            case Language.Cebuano:
            case Language.Chichewa:
            case Language.Chinese:
            case Language.Corsican:
            case Language.Esperanto:
            case Language.Estonian:
            case Language.Filipino:
            case Language.Finnish:
            case Language.Frisian:
            case Language.Galician:
            case Language.Georgian:
            case Language.Gujarati:
            case Language.Haitian_Creole:
            case Language.Hausa:
            case Language.Hawaiian:
            case Language.Hmong:
            case Language.Hungarian:
            case Language.Igbo:
            case Language.Irish:
            case Language.Javanese:
            case Language.Kannada:
            case Language.Kazakh:
            case Language.Khmer:
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
            case Language.Burmese:
            case Language.Nepali:
            case Language.Pashto:
            case Language.Persian:
            case Language.Punjabi:
            case Language.Samoan:
            case Language.Scots_Gaelic:
            case Language.Serbian:
            case Language.Sesotho:
            case Language.Shona:
            case Language.Sindhi:
            case Language.Sinhala:
            case Language.Slovenian:
            case Language.Somali:
            case Language.Sundanese:
            case Language.Swahili:
            case Language.Tajik:
            case Language.Tamil:
            case Language.Telugu:
            case Language.Ukrainian:
            case Language.Urdu:
            case Language.Uzbek:
            case Language.Welsh:
            case Language.Xhosa:
            case Language.Yiddish:
            case Language.Yoruba:
            case Language.Zulu:
            case Language.HebrewOld:
            case Language.Kinyarwanda:
            case Language.Odia:
            case Language.Tatar:
            case Language.Turkmen:
            case Language.Uyghur:
            case Language.Bihari:
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
            case Language.Abc7:
            case Language.Maithili:
            case Language.Manipuri:
                return false;

            default:
                return false;
        }
    }
}