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
            switch (language)
            {
                case Language.Afrikaans: return "af";
                case Language.Albanian: return "sq";
                case Language.Amharic: return "sm";
                case Language.Arabic: return "ar";
                case Language.Azerbaijani: return "az";
                case Language.Basque: return "eu";
                case Language.Belarusian: return "be";
                case Language.Bengali: return "bn";
                case Language.Bihari: return "bh";
                case Language.Bosnian: return "bs";
                case Language.Bulgarian: return "bg";
                case Language.Catalan: return "ca";
                case Language.Chinese: return "zh";
                case Language.ChineseSimplified: return "zh-CN";
                case Language.ChineseTraditional: return "zh-TW";
                case Language.Croatian: return "hr";
                case Language.Czech: return "cs";
                case Language.Danish: return "da";
                case Language.Dutch: return "nl";
                case Language.English: return "en";
                case Language.Esperanto: return "eo";
                case Language.Estonian: return "et";
                case Language.Faroese: return "fo";
                case Language.Finnish: return "fi";
                case Language.French: return "fr";
                case Language.Frisian: return "fy";
                case Language.Galician: return "gl";
                case Language.Georgian: return "ka";
                case Language.German: return "de";
                case Language.Greek: return "el";
                case Language.Gujarati: return "gu";
                case Language.Hebrew: return "iw";
                case Language.Hindi: return "hi";
                case Language.Hungarian: return "hu";
                case Language.Icelandic: return "is";
                case Language.Indonesian: return "id";
                case Language.Interlingua: return "ia";
                case Language.Irish: return "ga";
                case Language.Italian: return "it";
                case Language.Japanese: return "ja";
                case Language.Javanese: return "jw";
                case Language.Kannada: return "kn";
                case Language.Korean: return "ko";
                case Language.Latin: return "la";
                case Language.Latvian: return "lv";
                case Language.Lithuanian: return "lt";
                case Language.Macedonian: return "mk";
                case Language.Malay: return "ms";
                case Language.Malayam: return "ml";
                case Language.Maltese: return "mt";
                case Language.Marathi: return "mr";
                case Language.Nepali: return "ne";
                case Language.Norwegian: return "no";
                case Language.NorwegianNynorsk: return "nn";
                case Language.Occitan: return "oc";
                case Language.Persian: return "fa";
                case Language.Polish: return "pl";
                case Language.Portuguese: return "pt";
                case Language.PortugueseBrazil: return "pt-BR";
                case Language.PortuguesePortugal: return "pt-PT";
                case Language.Punjabi: return "pa";
                case Language.Romanian: return "ro";
                case Language.Russian: return "ru";
                case Language.ScotsGaelic: return "gd";
                case Language.Serbian: return "sr";
                case Language.Sinhalese: return "si";
                case Language.Slovak: return "sk";
                case Language.Slovenian: return "sl";
                case Language.Spanish: return "es";
                case Language.Sudanese: return "su";
                case Language.Swahili: return "sw";
                case Language.Swedish: return "sv";
                case Language.Tagalog: return "tl";
                case Language.Tamil: return "ta";
                case Language.Telugu: return "te";
                case Language.Thai: return "th";
                case Language.Tigrinya: return "ti";
                case Language.Turkish: return "tr";
                case Language.Ukrainian: return "uk";
                case Language.Urdu: return "ur";
                case Language.Uzbek: return "uz";
                case Language.Vietnamese: return "vi";
                case Language.Welsh: return "cy";
                case Language.Xhosa: return "xh";
                case Language.Zulu: return "zu";

                default:
                    return string.Empty;
            }
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

                default:
                    return false;
            }
        }
    }
}