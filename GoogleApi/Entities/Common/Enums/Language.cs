using System.Runtime.Serialization;

namespace GoogleApi.Entities.Common.Enums;

/// <summary>
/// Supported Languages.
/// By default the API will attempt to load the most appropriate language based on the users location or browser settings.
/// Some APIs allow you to explicitly set a language when you make a request.
/// https://developers.google.com/maps/faq#languagesupport
/// </summary>
public enum Language
{
    /// <summary>
    /// Unsupported.
    /// </summary>
    [EnumMember(Value = "XX")]
    Unsupported,

    /// <summary>
    /// Afrikaans
    /// </summary>
    [EnumMember(Value = "af")]
    Afrikaans,

    /// <summary>
    /// Albanian
    /// </summary>
    [EnumMember(Value = "sq")]
    Albanian,

    /// <summary>
    /// Amharic
    /// </summary>
    [EnumMember(Value = "am")]
    Amharic,

    /// <summary>
    /// Arabic
    /// </summary>
    [EnumMember(Value = "ar")]
    Arabic,

    /// <summary>
    /// Armenian
    /// </summary>
    [EnumMember(Value = "hy")]
    Armenian,

    /// <summary>
    /// Azerbaijani
    /// </summary>
    [EnumMember(Value = "az")]
    Azerbaijani,

    /// <summary>
    /// Basque.
    /// </summary>
    [EnumMember(Value = "eu")]
    Basque,

    /// <summary>
    /// Belarusian.
    /// </summary>
    [EnumMember(Value = "be")]
    Belarusian,

    /// <summary>
    /// Bengali.
    /// </summary>
    [EnumMember(Value = "bn")]
    Bengali,

    /// <summary>
    /// Bosnian.
    /// </summary>
    [EnumMember(Value = "bs")]
    Bosnian,

    /// <summary>
    /// Bulgarian.
    /// </summary>
    [EnumMember(Value = "bg")]
    Bulgarian,

    /// <summary>
    /// Burmese.
    /// </summary>
    [EnumMember(Value = "my")]
    Burmese,

    /// <summary>
    /// Catalan
    /// </summary>
    [EnumMember(Value = "ca")]
    Catalan,

    /// <summary>
    /// Chinese
    /// </summary>
    [EnumMember(Value = "zh")]
    Chinese,

    /// <summary>
    /// Chinese Simplified
    /// </summary>
    [EnumMember(Value = "zh-CN")]
    ChineseSimplified,

    /// <summary>
    /// Chinese Hong Kong
    /// </summary>
    [EnumMember(Value = "zh-HK")]
    ChineseHongKong,

    /// <summary>
    /// Chinese Traditional
    /// </summary>
    [EnumMember(Value = "zh-TW")]
    ChineseTraditional,

    /// <summary>
    /// Croatian.
    /// </summary>
    [EnumMember(Value = "hr")]
    Croatian,

    /// <summary>
    /// Czech.
    /// </summary>
    [EnumMember(Value = "cs")]
    Czech,

    /// <summary>
    /// Danish.
    /// </summary>
    [EnumMember(Value = "da")]
    Danish,

    /// <summary>
    /// Dutch.
    /// </summary>
    [EnumMember(Value = "nl")]
    Dutch,

    /// <summary>
    /// English.
    /// </summary>
    [EnumMember(Value = "en")]
    English,

    /// <summary>
    /// English (Australian)
    /// </summary>
    [EnumMember(Value = "en-AU")]
    EnglishAustralian,

    /// <summary>
    /// English (Great Britain)
    /// </summary>
    [EnumMember(Value = "en-GB")]
    EnglishGreatBritain,

    /// <summary>
    /// Estonian.
    /// </summary>
    [EnumMember(Value = "et")]
    Estonian,

    /// <summary>
    /// Farsi
    /// </summary>
    [EnumMember(Value = "fa")]
    Farsi,

    /// <summary>
    /// Finnish.
    /// </summary>
    [EnumMember(Value = "fi")]
    Finnish,

    /// <summary>
    /// Filipino
    /// </summary>
    [EnumMember(Value = "tl")]
    Filipino,

    /// <summary>
    /// French
    /// </summary>
    [EnumMember(Value = "fr")]
    French,

    /// <summary>
    /// French Canada
    /// </summary>
    [EnumMember(Value = "fr-CA")]
    FrenchCanada,

    /// <summary>
    /// Galician
    /// </summary>
    [EnumMember(Value = "gl")]
    Galician,

    /// <summary>
    /// Georgian
    /// </summary>
    [EnumMember(Value = "ka")]
    Georgian,

    /// <summary>
    /// German
    /// </summary>
    [EnumMember(Value = "de")]
    German,

    /// <summary>
    /// Greek
    /// </summary>
    [EnumMember(Value = "el")]
    Greek,

    /// <summary>
    /// Gujarati
    /// </summary>
    [EnumMember(Value = "gu")]
    Gujarati,

    /// <summary>
    /// Hebrew
    /// </summary>
    [EnumMember(Value = "he")]
    Hebrew,

    /// <summary>
    /// Hindi
    /// </summary>
    [EnumMember(Value = "hi")]
    Hindi,

    /// <summary>
    /// Hungarian.
    /// </summary>
    [EnumMember(Value = "hu")]
    Hungarian,

    /// <summary>
    /// Icelandic.
    /// </summary>
    [EnumMember(Value = "is")]
    Icelandic,

    /// <summary>
    /// Indonesian
    /// </summary>
    [EnumMember(Value = "id")]
    Indonesian,

    /// <summary>
    /// Italian
    /// </summary>
    [EnumMember(Value = "it")]
    Italian,

    /// <summary>
    /// Japanese
    /// </summary>
    [EnumMember(Value = "ja")]
    Japanese,

    /// <summary>
    /// Kannada
    /// </summary>
    [EnumMember(Value = "kn")]
    Kannada,

    /// <summary>
    /// Kazakh
    /// </summary>
    [EnumMember(Value = "kk")]
    Kazakh,

    /// <summary>
    /// Khmer
    /// </summary>
    [EnumMember(Value = "km")]
    Khmer,

    /// <summary>
    /// Korean
    /// </summary>
    [EnumMember(Value = "ko")]
    Korean,

    /// <summary>
    /// Kyrgyz
    /// </summary>
    [EnumMember(Value = "ky")]
    Kyrgyz,

    /// <summary>
    /// Lao
    /// </summary>
    [EnumMember(Value = "lo")]
    Lao,

    /// <summary>
    /// Latvian
    /// </summary>
    [EnumMember(Value = "lv")]
    Latvian,

    /// <summary>
    /// Lithuanian
    /// </summary>
    [EnumMember(Value = "lt")]
    Lithuanian,

    /// <summary>
    /// Macedonian
    /// </summary>
    [EnumMember(Value = "mk")]
    Macedonian,

    /// <summary>
    /// Malay
    /// </summary>
    [EnumMember(Value = "ms")]
    Malay,

    /// <summary>
    /// Malayalam
    /// </summary>
    [EnumMember(Value = "ml")]
    Malayalam,

    /// <summary>
    /// Marathi
    /// </summary>
    [EnumMember(Value = "mr")]
    Marathi,

    /// <summary>
    /// Mizo
    /// </summary>
    [EnumMember(Value = "lus")]
    Mizo,

    /// <summary>
    /// Mongolian
    /// </summary>
    [EnumMember(Value = "mn")]
    Mongolian,

    /// <summary>
    /// Nepali
    /// </summary>
    [EnumMember(Value = "ne")]
    Nepali,

    /// <summary>
    /// Norwegian
    /// </summary>
    [EnumMember(Value = "no")]
    Norwegian,

    /// <summary>
    /// Polish
    /// </summary>
    [EnumMember(Value = "pl")]
    Polish,

    /// <summary>
    /// Portuguese
    /// </summary>
    [EnumMember(Value = "pt")]
    Portuguese,

    /// <summary>
    /// Portuguese (Brazil)
    /// </summary>
    [EnumMember(Value = "pt-BR")]
    PortugueseBrazil,

    /// <summary>
    /// Portuguese (Portugal)
    /// </summary>
    [EnumMember(Value = "pt-PT")]
    PortuguesePortugal,

    /// <summary>
    /// Punjabi
    /// </summary>
    [EnumMember(Value = "pa")]
    Punjabi,

    /// <summary>
    /// Romanian
    /// </summary>
    [EnumMember(Value = "ro")]
    Romanian,

    /// <summary>
    /// Russian
    /// </summary>
    [EnumMember(Value = "ru")]
    Russian,

    /// <summary>
    /// Serbian
    /// </summary>
    [EnumMember(Value = "sr")]
    Serbian,

    /// <summary>
    /// Sinhalese
    /// </summary>
    [EnumMember(Value = "si")]
    Sinhalese,

    /// <summary>
    /// Slovak
    /// </summary>
    [EnumMember(Value = "sk")]
    Slovak,

    /// <summary>
    /// Slovenian
    /// </summary>
    [EnumMember(Value = "sl")]
    Slovenian,

    /// <summary>
    /// Spanish
    /// </summary>
    [EnumMember(Value = "es")]
    Spanish,

    /// <summary>
    /// Spanish Latin America
    /// </summary>
    [EnumMember(Value = "es-419")]
    SpanishLatinAmerica,

    /// <summary>
    /// Swahili
    /// </summary>
    [EnumMember(Value = "sw")]
    Swahili,

    /// <summary>
    /// Swedish
    /// </summary>
    [EnumMember(Value = "sv")]
    Swedish,

    /// <summary>
    /// Tamil
    /// </summary>
    [EnumMember(Value = "ta")]
    Tamil,

    /// <summary>
    /// Telugu
    /// </summary>
    [EnumMember(Value = "te")]
    Telugu,

    /// <summary>
    /// Thai
    /// </summary>
    [EnumMember(Value = "th")]
    Thai,

    /// <summary>
    /// Turkish
    /// </summary>
    [EnumMember(Value = "tr")]
    Turkish,

    /// <summary>
    /// Ukrainian
    /// </summary>
    [EnumMember(Value = "uk")]
    Ukrainian,

    /// <summary>
    /// Urdu
    /// </summary>
    [EnumMember(Value = "ur")]
    Urdu,

    /// <summary>
    /// Uzbek
    /// </summary>
    [EnumMember(Value = "uz")]
    Uzbek,

    /// <summary>
    /// Vietnamese
    /// </summary>
    [EnumMember(Value = "vi")]
    Vietnamese,

    /// <summary>
    /// Zulu
    /// </summary>
    [EnumMember(Value = "zu")]
    Zulu,

    /// <summary>
    /// Bulgarian Latn
    /// </summary>
    [EnumMember(Value = "bg-Latn")]
    BulgarianLatn
}