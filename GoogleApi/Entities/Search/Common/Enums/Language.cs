using System.Runtime.Serialization;

namespace GoogleApi.Entities.Search.Common.Enums
{
    /// <summary>
    /// Supported Interface Languages.
    /// Google supports more than 80 languages.
    /// The default interface language is English. 
    /// The following list identifies all of the interface languages that Google supports.
    /// https://developers.google.com/custom-search/docs/xml_results_appendices#interfaceLanguages
    /// </summary>
    public enum Language
    {
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
        /// Azerbaijani
        /// </summary>
        [EnumMember(Value = "az")]
        Azerbaijani,

        /// <summary>
        /// Basque
        /// </summary>
        [EnumMember(Value = "eu")]
        Basque,

        /// <summary>
        /// Belarusian
        /// </summary>
        [EnumMember(Value = "be")]
        Belarusian,

        /// <summary>
        /// Bengali
        /// </summary>
        [EnumMember(Value = "bn")]
        Bengali,

        /// <summary>
        /// Bihari
        /// </summary>
        [EnumMember(Value = "bh")]
        Bihari,

        /// <summary>
        /// Bosnian
        /// </summary>
        [EnumMember(Value = "bs")]
        Bosnian,

        /// <summary>
        /// Bulgarian
        /// </summary>
        [EnumMember(Value = "bg")]
        Bulgarian,

        /// <summary>
        /// Catalan
        /// </summary>
        [EnumMember(Value = "ca")]
        Catalan,

        /// <summary>
        /// Chinese.
        /// </summary>
        [EnumMember(Value = "zh")]
        Chinese,

        /// <summary>
        /// Chinese (Simplified)
        /// </summary>
        [EnumMember(Value = "zh-CN")]
        ChineseSimplified,

        /// <summary>
        /// Chinese (Traditional)
        /// </summary>
        [EnumMember(Value = "zh-TW")]
        ChineseTraditional,

        /// <summary>
        /// Croatian
        /// </summary>
        [EnumMember(Value = "hr")]
        Croatian,

        /// <summary>
        /// Czech
        /// </summary>
        [EnumMember(Value = "cs")]
        Czech,

        /// <summary>
        /// Danish
        /// </summary>
        [EnumMember(Value = "da")]
        Danish,

        /// <summary>
        /// Dutch
        /// </summary>
        [EnumMember(Value = "nl")]
        Dutch,

        /// <summary>
        /// English
        /// </summary>
        [EnumMember(Value = "en")]
        English,

        /// <summary>
        /// Esperanto
        /// </summary>
        [EnumMember(Value = "eo")]
        Esperanto,

        /// <summary>
        /// Estonian
        /// </summary>
        [EnumMember(Value = "et")]
        Estonian,

        /// <summary>
        /// Faroese
        /// </summary>
        [EnumMember(Value = "fo")]
        Faroese,

        /// <summary>
        /// Finnish
        /// </summary>
        [EnumMember(Value = "fi")]
        Finnish,

        /// <summary>
        /// French
        /// </summary>
        [EnumMember(Value = "fr")]
        French,

        /// <summary>
        /// Frisian
        /// </summary>
        [EnumMember(Value = "fy")]
        Frisian,

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
        [EnumMember(Value = "iw")]
        Hebrew,

        /// <summary>
        /// Hindi
        /// </summary>
        [EnumMember(Value = "hi")]
        Hindi,

        /// <summary>
        /// Hungarian
        /// </summary>
        [EnumMember(Value = "hu")]
        Hungarian,

        /// <summary>
        /// Icelandic
        /// </summary>
        [EnumMember(Value = "is")]
        Icelandic,

        /// <summary>
        /// Indonesian
        /// </summary>
        [EnumMember(Value = "id")]
        Indonesian,

        /// <summary>
        /// Interlingua
        /// </summary>
        [EnumMember(Value = "ia")]
        Interlingua,

        /// <summary>
        /// Irish
        /// </summary>
        [EnumMember(Value = "ga")]
        Irish,

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
        /// Javanese
        /// </summary>
        [EnumMember(Value = "jw")]
        Javanese,

        /// <summary>
        /// Kannada
        /// </summary>
        [EnumMember(Value = "kn")]
        Kannada,

        /// <summary>
        /// Korean
        /// </summary>
        [EnumMember(Value = "ko")]
        Korean,

        /// <summary>
        /// Latin
        /// </summary>
        [EnumMember(Value = "la")]
        Latin,

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
        /// Malayam
        /// </summary>
        [EnumMember(Value = "ml")]
        Malayam,

        /// <summary>
        /// Maltese
        /// </summary>
        [EnumMember(Value = "mt")]
        Maltese,

        /// <summary>
        /// Marathi
        /// </summary>
        [EnumMember(Value = "mr")]
        Marathi,

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
        /// Norwegian (Nynorsk)
        /// </summary>
        [EnumMember(Value = "nn")]
        NorwegianNynorsk,

        /// <summary>
        /// Occitan
        /// </summary>
        [EnumMember(Value = "oc")]
        Occitan,

        /// <summary>
        /// Persian
        /// </summary>
        [EnumMember(Value = "fa")]
        Persian,

        /// <summary>
        /// Polish
        /// </summary>
        [EnumMember(Value = "pl")]
        Polish,

        /// <summary>
        /// Portuguese (Brazil)
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
        /// Scots Gaelic
        /// </summary>
        [EnumMember(Value = "gd")]
        ScotsGaelic,

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
        /// Sudanese
        /// </summary>
        [EnumMember(Value = "su")]
        Sudanese,

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
        /// Tagalog
        /// </summary>
        [EnumMember(Value = "tl")]
        Tagalog,

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
        /// Tigrinya
        /// </summary>
        [EnumMember(Value = "ti")]
        Tigrinya,

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
        /// Welsh
        /// </summary>
        [EnumMember(Value = "cy")]
        Welsh,

        /// <summary>
        /// Xhosa
        /// </summary>
        [EnumMember(Value = "xh")]
        Xhosa,

        /// <summary>
        /// Zulu
        /// </summary>
        [EnumMember(Value = "zu")]
        Zulu
    }
}