namespace GoogleApi.Entities.Translate.Common.Enums.Extensions
{
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
            switch (language)
            {
                case Language.Afrikaans: return "af";
                case Language.Albanian: return "sq";
                case Language.Amharic: return "am";
                case Language.Arabic: return "ar";
                case Language.Armenian: return "hy";
                case Language.Azeerbaijani: return "az";
                case Language.Basque: return "eu";
                case Language.Belarusian: return "be";
                case Language.Bengali: return "bn";
                case Language.Bosnian: return "bs";
                case Language.Bulgarian: return "bg";
                case Language.Catalan: return "ca";
                case Language.Cebuano: return "ceb";
                case Language.Chichewa: return "ny";
                case Language.Chinese_Simplified: return "zh-CN";
                case Language.Chinese_Traditional: return "zh-TW";
                case Language.Corsican: return "co";
                case Language.Croatian: return "hr";
                case Language.Czech: return "cs";
                case Language.Danish: return "da";
                case Language.Dutch: return "nl";
                case Language.English: return "en";
                case Language.Esperanto: return "eo";
                case Language.Estonian: return "et";
                case Language.Filipino: return "tl";
                case Language.Finnish: return "fi";
                case Language.French: return "fr";
                case Language.Frisian: return "fy";
                case Language.Galician: return "gl";
                case Language.Georgian: return "ka";
                case Language.German: return "de";
                case Language.Greek: return "el";
                case Language.Gujarati: return "gu";
                case Language.Haitian_Creole: return "ht";
                case Language.Hausa: return "ha";
                case Language.Hawaiian: return "haw";
                case Language.Hebrew: return "iw";
                case Language.Hindi: return "hi";
                case Language.Hmong: return "hmn";
                case Language.Hungarian: return "hu";
                case Language.Icelandic: return "is";
                case Language.Igbo: return "ig";
                case Language.Indonesian: return "id";
                case Language.Irish: return "ga";
                case Language.Italian: return "it";
                case Language.Japanese: return "ja";
                case Language.Javanese: return "jw";
                case Language.Kannada: return "kn";
                case Language.Kazakh: return "kk";
                case Language.Khmer: return "km";
                case Language.Korean: return "ko";
                case Language.Kurdish: return "ku";
                case Language.Kyrgyz: return "ky";
                case Language.Lao: return "lo";
                case Language.Latin: return "la";
                case Language.Latvian: return "lv";
                case Language.Lithuanian: return "lt";
                case Language.Luxembourgish: return "lb";
                case Language.Macedonian: return "mk";
                case Language.Malagasy: return "mg";
                case Language.Malay: return "ms";
                case Language.Malayalam: return "ml";
                case Language.Maltese: return "mt";
                case Language.Maori: return "mi";
                case Language.Marathi: return "mr";
                case Language.Mongolian: return "mn";
                case Language.Burmese: return "my";
                case Language.Nepali: return "ne";
                case Language.Norwegian: return "no";
                case Language.Pashto: return "ps";
                case Language.Persian: return "fa";
                case Language.Polish: return "pl";
                case Language.Portuguese: return "pt";
                case Language.Punjabi: return "ma";
                case Language.Romanian: return "ro";
                case Language.Russian: return "ru";
                case Language.Samoan: return "sm";
                case Language.Scots_Gaelic: return "gd";
                case Language.Serbian: return "sr";
                case Language.Sesotho: return "st";
                case Language.Shona: return "sn";
                case Language.Sindhi: return "sd";
                case Language.Sinhala: return "si";
                case Language.Slovak: return "sk";
                case Language.Slovenian: return "sl";
                case Language.Somali: return "so";
                case Language.Spanish: return "es";
                case Language.Sundanese: return "su";
                case Language.Swahili: return "sw";
                case Language.Swedish: return "sv";
                case Language.Tajik: return "tg";
                case Language.Tamil: return "ta";
                case Language.Telugu: return "te";
                case Language.Thai: return "th";
                case Language.Turkish: return "tr";
                case Language.Ukrainian: return "uk";
                case Language.Urdu: return "ur";
                case Language.Uzbek: return "uz";
                case Language.Vietnamese: return "vi";
                case Language.Welsh: return "cy";
                case Language.Xhosa: return "xh";
                case Language.Yiddish: return "yi";
                case Language.Yoruba: return "yo";
                case Language.Zulu: return "zu";

                default:
                    return string.Empty;
            }
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

                default:
                    return false;
            }
        }
    }
}