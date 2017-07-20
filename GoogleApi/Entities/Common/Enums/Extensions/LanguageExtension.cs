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
                case Language.Arabic: return "ar";
                case Language.Basque: return "eu";
                case Language.Bengali: return "bn";
                case Language.Bulgarian: return "bg";
                case Language.Catalan: return "ca";
                case Language.ChineseSimplified: return "zh-CN";
                case Language.ChineseTraditional: return "zh-TW";
                case Language.Croatian: return "hr";
                case Language.Czech: return "cs";
                case Language.Danish: return "da";
                case Language.Dutch: return "nl";
                case Language.English: return "en";
                case Language.Finnish: return "fi";
                case Language.French: return "fr";
                case Language.Galician: return "gl";
                case Language.German: return "de";
                case Language.Greek: return "el";
                case Language.Gujarati: return "gu";
                case Language.Hebrew: return "iw";
                case Language.Hindi: return "hi";
                case Language.Hungarian: return "hu";
                case Language.Indonesian: return "id";
                case Language.Italian: return "it";
                case Language.Japanese: return "ja";
                case Language.Kannada: return "kn";
                case Language.Korean: return "ko";
                case Language.Latvian: return "lv";
                case Language.Lithuanian: return "lt";
                case Language.Marathi: return "mr";
                case Language.Norwegian: return "no";
                case Language.Polish: return "pl";
                case Language.PortugueseBrazil: return "pt-BR";
                case Language.PortuguesePortugal: return "pt-PT";
                case Language.Romanian: return "ro";
                case Language.Russian: return "ru";
                case Language.Serbian: return "sr";
                case Language.Slovak: return "sk";
                case Language.Slovenian: return "sl";
                case Language.Spanish: return "es";
                case Language.Swedish: return "sv";
                case Language.Tagalog: return "tl";
                case Language.Tamil: return "ta";
                case Language.Telugu: return "te";
                case Language.Thai: return "th";
                case Language.Turkish: return "tr";
                case Language.Ukrainian: return "uk";
                case Language.Vietnamese: return "vi";
                case Language.EnglishAustralian: return "en-AU";
                case Language.EnglishGreatBritain: return "en-GB";
                case Language.Farsi: return "fa";
                case Language.Filipino: return "fil";
                case Language.Malayalam: return "ml";
                case Language.Portuguese: return "pt";

                default:
                    return null;
            }
        }
    }
}