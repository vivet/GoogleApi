namespace GoogleApi.Entities.Translate.Common.Enums.Extensions
{
    /// <summary>
    /// String Extensions.
    /// </summary>
    public static class StringExtension
    {
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

                default:
                    return Language.English;
            }
        }
    }
}