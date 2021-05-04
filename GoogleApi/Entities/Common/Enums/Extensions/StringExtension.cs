using System;

namespace GoogleApi.Entities.Common.Enums.Extensions
{
    /// <summary>
    /// String Extensions.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Gets the <see cref="Language"/> for the specified ISO-639-1 code.
        /// </summary>
        /// <param name="language">The ISO-639-1 code.</param>
        /// <returns>The <see cref="Language"/>.</returns>
        public static Language? FromCode(this string language)
        {
            if (language == null) 
                throw new ArgumentNullException(nameof(language));
            
            switch (language)
            {
                case "af": return Language.Afrikaans;
                case "sq": return Language.Albanian;
                case "am": return Language.Amharic;
                case "ar": return Language.Arabic;
                case "hy": return Language.Armenian;
                case "az": return Language.Azerbaijani;
                case "eu": return Language.Basque;
                case "be": return Language.Belarusian;
                case "bn": return Language.Bengali;
                case "bs": return Language.Bosnian;
                case "bg": return Language.Bulgarian;
                case "my": return Language.Burmese;
                case "ca": return Language.Catalan;
                case "zh": return Language.Chinese;
                case "zh-CN": return Language.ChineseSimplified;
                case "zh-HK": return Language.ChineseHongKong;
                case "zh-TW": return Language.ChineseTraditional;
                case "hr": return Language.Croatian;
                case "cs": return Language.Czech;
                case "da": return Language.Danish;
                case "nl": return Language.Dutch;
                case "en": return Language.English;
                case "en-AU": return Language.EnglishAustralian;
                case "en-GB": return Language.EnglishGreatBritain;
                case "et": return Language.Estonian;
                case "fa": return Language.Farsi;
                case "fi": return Language.Finnish;
                case "fil": return Language.Filipino;
                case "fr": return Language.French;
                case "fr-CA": return Language.FrenchCanada;
                case "gl": return Language.Galician;
                case "ka": return Language.Georgian;
                case "de": return Language.German;
                case "el": return Language.Greek;
                case "gu": return Language.Gujarati;
                case "iw": return Language.Hebrew;
                case "hi": return Language.Hindi;
                case "hu": return Language.Hungarian;
                case "is": return Language.Icelandic;
                case "id": return Language.Indonesian;
                case "it": return Language.Italian;
                case "ja": return Language.Japanese;
                case "kn": return Language.Kannada;
                case "kk": return Language.Kazakh;
                case "km": return Language.Khmer;
                case "ko": return Language.Korean;
                case "ky": return Language.Kyrgyz;
                case "lo": return Language.Lao;
                case "lv": return Language.Latvian;
                case "lt": return Language.Lithuanian;
                case "mk": return Language.Macedonian;
                case "ms": return Language.Malay;
                case "ml": return Language.Malayalam;
                case "mr": return Language.Marathi;
                case "mn": return Language.Mongolian;
                case "ne": return Language.Nepali;
                case "no": return Language.Norwegian;
                case "pl": return Language.Polish;
                case "pt": return Language.Portuguese;
                case "pt-BR": return Language.PortugueseBrazil;
                case "pt-PT": return Language.PortuguesePortugal;
                case "pa": return Language.Punjabi;
                case "ro": return Language.Romanian;
                case "ru": return Language.Russian;
                case "sr": return Language.Serbian;
                case "si": return Language.Sinhalese;
                case "sk": return Language.Slovak;
                case "sl": return Language.Slovenian;
                case "es": return Language.Spanish;
                case "es-419": return Language.SpanishLatinAmerica;
                case "sw": return Language.Swahili;
                case "sv": return Language.Swedish;
                case "ta": return Language.Tamil;
                case "te": return Language.Telugu;
                case "th": return Language.Thai;
                case "tr": return Language.Turkish;
                case "uk": return Language.Ukrainian;
                case "ur": return Language.Urdu;
                case "uz": return Language.Uzbek;
                case "vi": return Language.Vietnamese;
                case "zu": return Language.Zulu;

                default:
                    return null;
            }
        }
    }
}