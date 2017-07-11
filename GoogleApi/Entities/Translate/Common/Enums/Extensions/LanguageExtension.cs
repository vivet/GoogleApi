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
                case Language.Hawaiian: return "haw (ISO-639-2)";
                case Language.Hebrew: return "iw";
                case Language.Hindi: return "hi";
                case Language.Hmong: return "hmn (ISO-639-2)";
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
        /// Gets the <see cref="Language"/> for the specified ISO-639-1/(2) code.
        /// </summary>
        /// <param name="code">The ISO-639-1 code.</param>
        /// <returns>the <see cref="Language"/> matching the passed <paramref name="code"/>.</returns>
        public static Language? FromCode(this string code)
        {
            switch (code)
            {
                case "af": return Language.Afrikaans;
                case "sq": return Language.Albanian;
                case "am": return Language.Amharic;
                case "ar": return Language.Arabic;
                case "hy": return Language.Armenian;
                case "az": return Language.Azeerbaijani;
                case "eu": return Language.Basque;
                case "be": return Language.Belarusian;
                case "bn": return Language.Bengali;
                case "bs": return Language.Bosnian;
                case "bg": return Language.Bulgarian;
                case "ca": return Language.Catalan;
                case "ceb": return Language.Cebuano;
                case "ny": return Language.Chichewa;
                case "zh": return Language.Chinese_Simplified;
                case "zh-CN": return Language.Chinese_Simplified;
                case "zh-TW": return Language.Chinese_Traditional;
                case "co": return Language.Corsican;
                case "hr": return Language.Croatian;
                case "cs": return Language.Czech;
                case "da": return Language.Danish;
                case "nl": return Language.Dutch;
                case "en": return Language.English;
                case "eo": return Language.Esperanto;
                case "et": return Language.Estonian;
                case "tl": return Language.Filipino;
                case "fi": return Language.Finnish;
                case "fr": return Language.French;
                case "fy": return Language.Frisian;
                case "gl": return Language.Galician;
                case "ka": return Language.Georgian;
                case "de": return Language.German;
                case "el": return Language.Greek;
                case "gu": return Language.Gujarati;
                case "ht": return Language.Haitian_Creole;
                case "ha": return Language.Hausa;
                case "haw": return Language.Hawaiian;
                case "iw": return Language.Hebrew;
                case "hi": return Language.Hindi;
                case "hmn": return Language.Hmong;
                case "hu": return Language.Hungarian;
                case "is": return Language.Icelandic;
                case "ig": return Language.Igbo;
                case "id": return Language.Indonesian;
                case "ga": return Language.Irish;
                case "it": return Language.Italian;
                case "ja": return Language.Japanese;
                case "jw": return Language.Javanese;
                case "kn": return Language.Kannada;
                case "kk": return Language.Kazakh;
                case "km": return Language.Khmer;
                case "ko": return Language.Korean;
                case "ku": return Language.Kurdish;
                case "ky": return Language.Kyrgyz;
                case "lo": return Language.Lao;
                case "la": return Language.Latin;
                case "lv": return Language.Latvian;
                case "lt": return Language.Lithuanian;
                case "lb": return Language.Luxembourgish;
                case "mk": return Language.Macedonian;
                case "mg": return Language.Malagasy;
                case "ms": return Language.Malay;
                case "ml": return Language.Malayalam;
                case "mt": return Language.Maltese;
                case "mi": return Language.Maori;
                case "mr": return Language.Marathi;
                case "mn": return Language.Mongolian;
                case "my": return Language.Burmese;
                case "ne": return Language.Nepali;
                case "no": return Language.Norwegian;
                case "ps": return Language.Pashto;
                case "fa": return Language.Persian;
                case "pl": return Language.Polish;
                case "pt": return Language.Portuguese;
                case "ma": return Language.Punjabi;
                case "ro": return Language.Romanian;
                case "ru": return Language.Russian;
                case "sm": return Language.Samoan;
                case "gd": return Language.Scots_Gaelic;
                case "sr": return Language.Serbian;
                case "st": return Language.Sesotho;
                case "sn": return Language.Shona;
                case "sd": return Language.Sindhi;
                case "si": return Language.Sinhala;
                case "sk": return Language.Slovak;
                case "sl": return Language.Slovenian;
                case "so": return Language.Somali;
                case "es": return Language.Spanish;
                case "su": return Language.Sundanese;
                case "sw": return Language.Swahili;
                case "sv": return Language.Swedish;
                case "tg": return Language.Tajik;
                case "ta": return Language.Tamil;
                case "te": return Language.Telugu;
                case "th": return Language.Thai;
                case "tr": return Language.Turkish;
                case "uk": return Language.Ukrainian;
                case "ur": return Language.Urdu;
                case "uz": return Language.Uzbek;
                case "vi": return Language.Vietnamese;
                case "cy": return Language.Welsh;
                case "xh": return Language.Xhosa;
                case "yi": return Language.Yiddish;
                case "yo": return Language.Yoruba;
                case "zu": return Language.Zulu;
            }

            return Language.English;
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