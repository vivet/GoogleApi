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

            return language switch
            {
                "af" => Language.Afrikaans,
                "sq" => Language.Albanian,
                "am" => Language.Amharic,
                "ar" => Language.Arabic,
                "hy" => Language.Armenian,
                "az" => Language.Azerbaijani,
                "eu" => Language.Basque,
                "be" => Language.Belarusian,
                "bn" => Language.Bengali,
                "bs" => Language.Bosnian,
                "bg" => Language.Bulgarian,
                "my" => Language.Burmese,
                "ca" => Language.Catalan,
                "zh" => Language.Chinese,
                "zh-CN" => Language.ChineseSimplified,
                "zh-HK" => Language.ChineseHongKong,
                "zh-TW" => Language.ChineseTraditional,
                "hr" => Language.Croatian,
                "cs" => Language.Czech,
                "da" => Language.Danish,
                "nl" => Language.Dutch,
                "en" => Language.English,
                "en-AU" => Language.EnglishAustralian,
                "en-GB" => Language.EnglishGreatBritain,
                "et" => Language.Estonian,
                "fa" => Language.Farsi,
                "fi" => Language.Finnish,
                "fil" => Language.Filipino,
                "fr" => Language.French,
                "fr-CA" => Language.FrenchCanada,
                "gl" => Language.Galician,
                "ka" => Language.Georgian,
                "de" => Language.German,
                "el" => Language.Greek,
                "gu" => Language.Gujarati,
                "iw" => Language.Hebrew,
                "hi" => Language.Hindi,
                "hu" => Language.Hungarian,
                "is" => Language.Icelandic,
                "id" => Language.Indonesian,
                "it" => Language.Italian,
                "ja" => Language.Japanese,
                "kn" => Language.Kannada,
                "kk" => Language.Kazakh,
                "km" => Language.Khmer,
                "ko" => Language.Korean,
                "ky" => Language.Kyrgyz,
                "lo" => Language.Lao,
                "lv" => Language.Latvian,
                "lt" => Language.Lithuanian,
                "mk" => Language.Macedonian,
                "ms" => Language.Malay,
                "ml" => Language.Malayalam,
                "mr" => Language.Marathi,
                "mn" => Language.Mongolian,
                "ne" => Language.Nepali,
                "no" => Language.Norwegian,
                "pl" => Language.Polish,
                "pt" => Language.Portuguese,
                "pt-BR" => Language.PortugueseBrazil,
                "pt-PT" => Language.PortuguesePortugal,
                "pa" => Language.Punjabi,
                "ro" => Language.Romanian,
                "ru" => Language.Russian,
                "sr" => Language.Serbian,
                "si" => Language.Sinhalese,
                "sk" => Language.Slovak,
                "sl" => Language.Slovenian,
                "es" => Language.Spanish,
                "es-419" => Language.SpanishLatinAmerica,
                "sw" => Language.Swahili,
                "sv" => Language.Swedish,
                "ta" => Language.Tamil,
                "te" => Language.Telugu,
                "th" => Language.Thai,
                "tr" => Language.Turkish,
                "uk" => Language.Ukrainian,
                "ur" => Language.Urdu,
                "uz" => Language.Uzbek,
                "vi" => Language.Vietnamese,
                "zu" => Language.Zulu,
                _ => null
            };
        }
    }
}