namespace GoogleApi.Entities.Common.Enums.Extensions
{
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
            switch (language)
            {
                case Language.Afrikaans: return "af";
                case Language.Albanian: return "sq";
                case Language.Amharic: return "am";
                case Language.Arabic: return "ar";
                case Language.Armenian: return "hy";
                case Language.Azerbaijani: return "az";
                case Language.Basque: return "eu";
                case Language.Belarusian: return "be";
                case Language.Bengali: return "bn";
                case Language.Bosnian: return "bs";
                case Language.Bulgarian: return "bg";
                case Language.Burmese: return "my";
                case Language.Catalan: return "ca";
                case Language.Chinese: return "zh";
                case Language.ChineseSimplified: return "zh-CN";
                case Language.ChineseHongKong: return "zh-HK";
                case Language.ChineseTraditional: return "zh-TW";
                case Language.Croatian: return "hr";
                case Language.Czech: return "cs";
                case Language.Danish: return "da";
                case Language.Dutch: return "nl";
                case Language.English: return "en";
                case Language.EnglishAustralian: return "en-AU";
                case Language.EnglishGreatBritain: return "en-GB";
                case Language.Estonian: return "et";
                case Language.Farsi: return "fa";
                case Language.Finnish: return "fi";
                case Language.Filipino: return "fil";
                case Language.French: return "fr";
                case Language.FrenchCanada: return "fr-CA";
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
                case Language.Italian: return "it";
                case Language.Japanese: return "ja";
                case Language.Kannada: return "kn";
                case Language.Kazakh: return "kk";
                case Language.Khmer: return "km";
                case Language.Korean: return "ko";
                case Language.Kyrgyz: return "ky";
                case Language.Lao: return "lo";
                case Language.Latvian: return "lv";
                case Language.Lithuanian: return "lt";
                case Language.Macedonian: return "mk";
                case Language.Malay: return "ms";
                case Language.Malayalam: return "ml";
                case Language.Marathi: return "mr";
                case Language.Mongolian: return "mn";
                case Language.Nepali: return "ne";
                case Language.Norwegian: return "no";
                case Language.Polish: return "pl";
                case Language.Portuguese: return "pt";
                case Language.PortugueseBrazil: return "pt-BR";
                case Language.PortuguesePortugal: return "pt-PT";
                case Language.Punjabi: return "pa";
                case Language.Romanian: return "ro";
                case Language.Russian: return "ru";
                case Language.Serbian: return "sr";
                case Language.Sinhalese: return "si";
                case Language.Slovak: return "sk";
                case Language.Slovenian: return "sl";
                case Language.Spanish: return "es";
                case Language.SpanishLatinAmerica: return "es-419";
                case Language.Swahili: return "sw";
                case Language.Swedish: return "sv";
                case Language.Tamil: return "ta";
                case Language.Telugu: return "te";
                case Language.Thai: return "th";
                case Language.Turkish: return "tr";
                case Language.Ukrainian: return "uk";
                case Language.Urdu: return "ur";
                case Language.Uzbek: return "uz";
                case Language.Vietnamese: return "vi";
                case Language.Zulu: return "zu";

                default:
                    return null;
            }
        }
    }
}