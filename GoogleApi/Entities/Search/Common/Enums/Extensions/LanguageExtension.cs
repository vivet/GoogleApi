namespace GoogleApi.Entities.Search.Common.Enums.Extensions
{
    /// <summary>
    /// Language Extension methods.
    /// </summary>
    public static class LanguageExtension
    {
        /// <summary>
        /// Return the Language code.
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public static string ToHl(this Language language)
        {
            return language switch
            {
                Language.Afrikaans => "af",
                Language.Albanian => "sq",
                Language.Amharic => "sm",
                Language.Arabic => "ar",
                Language.Azerbaijani => "az",
                Language.Basque => "eu",
                Language.Belarusian => "be",
                Language.Bengali => "bn",
                Language.Bihari => "bh",
                Language.Bosnian => "bs",
                Language.Bulgarian => "bg",
                Language.Catalan => "ca",
                Language.Chinese => "zh",
                Language.ChineseSimplified => "zh-CN",
                Language.ChineseTraditional => "zh-TW",
                Language.Croatian => "hr",
                Language.Czech => "cs",
                Language.Danish => "da",
                Language.Dutch => "nl",
                Language.English => "en",
                Language.Esperanto => "eo",
                Language.Estonian => "et",
                Language.Faroese => "fo",
                Language.Finnish => "fi",
                Language.French => "fr",
                Language.Frisian => "fy",
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
                Language.Interlingua => "ia",
                Language.Irish => "ga",
                Language.Italian => "it",
                Language.Japanese => "ja",
                Language.Javanese => "jw",
                Language.Kannada => "kn",
                Language.Korean => "ko",
                Language.Latin => "la",
                Language.Latvian => "lv",
                Language.Lithuanian => "lt",
                Language.Macedonian => "mk",
                Language.Malay => "ms",
                Language.Malayam => "ml",
                Language.Maltese => "mt",
                Language.Marathi => "mr",
                Language.Nepali => "ne",
                Language.Norwegian => "no",
                Language.NorwegianNynorsk => "nn",
                Language.Occitan => "oc",
                Language.Persian => "fa",
                Language.Polish => "pl",
                Language.Portuguese => "pt",
                Language.PortugueseBrazil => "pt-BR",
                Language.PortuguesePortugal => "pt-PT",
                Language.Punjabi => "pa",
                Language.Romanian => "ro",
                Language.Russian => "ru",
                Language.ScotsGaelic => "gd",
                Language.Serbian => "sr",
                Language.Sinhalese => "si",
                Language.Slovak => "sk",
                Language.Slovenian => "sl",
                Language.Spanish => "es",
                Language.Sudanese => "su",
                Language.Swahili => "sw",
                Language.Swedish => "sv",
                Language.Tagalog => "tl",
                Language.Tamil => "ta",
                Language.Telugu => "te",
                Language.Thai => "th",
                Language.Tigrinya => "ti",
                Language.Turkish => "tr",
                Language.Ukrainian => "uk",
                Language.Urdu => "ur",
                Language.Uzbek => "uz",
                Language.Vietnamese => "vi",
                Language.Welsh => "cy",
                Language.Xhosa => "xh",
                Language.Zulu => "zu",
                _ => string.Empty
            };
        }

        /// <summary>
        /// Determines whether the <see cref="Language"/> supports safe search filter.
        /// </summary>
        /// <param name="language">The <see cref="Language"/>.</param>
        /// <returns>Boolean, indicating if the passed <see cref="Language"/> supports safe search filter.</returns>
        public static bool AllowSafeSearch(this Language language)
        {
            switch (language)
            {
                case Language.Dutch:
                case Language.English:
                case Language.French:
                case Language.German:
                case Language.Italian:
                case Language.Portuguese:
                case Language.PortugueseBrazil:
                case Language.Spanish:
                case Language.Chinese:
                case Language.ChineseTraditional:
                    return true;

                case Language.Afrikaans:
                case Language.Albanian:
                case Language.Amharic:
                case Language.Arabic:
                case Language.Azerbaijani:
                case Language.Basque:
                case Language.Belarusian:
                case Language.Bengali:
                case Language.Bihari:
                case Language.Bosnian:
                case Language.Bulgarian:
                case Language.Catalan:
                case Language.ChineseSimplified:
                case Language.Croatian:
                case Language.Czech:
                case Language.Danish:
                case Language.Esperanto:
                case Language.Estonian:
                case Language.Faroese:
                case Language.Finnish:
                case Language.Frisian:
                case Language.Galician:
                case Language.Georgian:
                case Language.Greek:
                case Language.Gujarati:
                case Language.Hebrew:
                case Language.Hindi:
                case Language.Hungarian:
                case Language.Icelandic:
                case Language.Indonesian:
                case Language.Interlingua:
                case Language.Irish:
                case Language.Japanese:
                case Language.Javanese:
                case Language.Kannada:
                case Language.Korean:
                case Language.Latin:
                case Language.Latvian:
                case Language.Lithuanian:
                case Language.Macedonian:
                case Language.Malay:
                case Language.Malayam:
                case Language.Maltese:
                case Language.Marathi:
                case Language.Nepali:
                case Language.Norwegian:
                case Language.NorwegianNynorsk:
                case Language.Occitan:
                case Language.Persian:
                case Language.Polish:
                case Language.PortuguesePortugal:
                case Language.Punjabi:
                case Language.Romanian:
                case Language.Russian:
                case Language.ScotsGaelic:
                case Language.Serbian:
                case Language.Sinhalese:
                case Language.Slovak:
                case Language.Slovenian:
                case Language.Sudanese:
                case Language.Swahili:
                case Language.Swedish:
                case Language.Tagalog:
                case Language.Tamil:
                case Language.Telugu:
                case Language.Thai:
                case Language.Tigrinya:
                case Language.Turkish:
                case Language.Ukrainian:
                case Language.Urdu:
                case Language.Uzbek:
                case Language.Vietnamese:
                case Language.Welsh:
                case Language.Xhosa:
                case Language.Zulu:
                    return false;

                default:
                    return false;
            }
        }
    }
}