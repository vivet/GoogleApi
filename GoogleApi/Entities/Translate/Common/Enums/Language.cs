using System.Runtime.Serialization;

namespace GoogleApi.Entities.Translate.Common.Enums;

/// <summary>
/// The Translation API's recognition engine supports a wide variety of languages for the Phrase-Based Machine Translation (PBMT) and
/// Neural Machine Translation (NMT) models.
/// These languages are specified within a recognition request using language code parameters as noted on this page.
/// Most language code parameters conform to ISO-639-1 identifiers, except where noted.
/// </summary>
public enum Language
{
    /// <summary>
    /// Afrikaans.
    /// </summary>
    [EnumMember(Value = "af")]
    Afrikaans,

    /// <summary>
    /// Albanian.
    /// </summary>
    [EnumMember(Value = "sq")]
    Albanian,

    /// <summary>
    /// Amharic.
    /// </summary>
    [EnumMember(Value = "am")]
    Amharic,

    /// <summary>
    /// Arabic.
    /// </summary>
    [EnumMember(Value = "ar")]
    Arabic,

    /// <summary>
    /// Armenian.
    /// </summary>
    [EnumMember(Value = "hy")]
    Armenian,

    /// <summary>
    /// Azeerbaijani.
    /// </summary>
    [EnumMember(Value = "az")]
    Azeerbaijani,

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
    /// Catalan.
    /// </summary>
    [EnumMember(Value = "ca")]
    Catalan,

    /// <summary>
    /// Cebuano. (ISO-639-2)
    /// </summary>
    [EnumMember(Value = "ceb")]
    Cebuano,

    /// <summary>
    /// Chichewa.
    /// </summary>
    [EnumMember(Value = "ny")]
    Chichewa,

    /// <summary>
    /// Chinese.
    /// </summary>
    [EnumMember(Value = "zh")]
    Chinese,

    /// <summary>
    /// Chinese simplified. (BCP-47)
    /// </summary>
    [EnumMember(Value = "zh-CN")]
    Chinese_Simplified,

    /// <summary>
    /// Chinese traditional. (BCP-47)
    /// </summary>
    [EnumMember(Value = "zh-TW")]
    Chinese_Traditional,

    /// <summary>
    /// Corsican.
    /// </summary>
    [EnumMember(Value = "co")]
    Corsican,

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
    /// Esperanto.
    /// </summary>
    [EnumMember(Value = "eo")]
    Esperanto,

    /// <summary>
    /// Estonian.
    /// </summary>
    [EnumMember(Value = "et")]
    Estonian,

    /// <summary>
    /// Filipino.
    /// </summary>
    [EnumMember(Value = "tl")]
    Filipino,

    /// <summary>
    /// Finnish.
    /// </summary>
    [EnumMember(Value = "fi")]
    Finnish,

    /// <summary>
    /// French.
    /// </summary>
    [EnumMember(Value = "fr")]
    French,

    /// <summary>
    /// Frisian.
    /// </summary>
    [EnumMember(Value = "fy")]
    Frisian,

    /// <summary>
    /// Galician.
    /// </summary>
    [EnumMember(Value = "gl")]
    Galician,

    /// <summary>
    /// Georgian.
    /// </summary>
    [EnumMember(Value = "ka")]
    Georgian,

    /// <summary>
    /// German.
    /// </summary>
    [EnumMember(Value = "de")]
    German,

    /// <summary>
    /// Greek.
    /// </summary>
    [EnumMember(Value = "el")]
    Greek,

    /// <summary>
    /// Gujarati.
    /// </summary>
    [EnumMember(Value = "gu")]
    Gujarati,

    /// <summary>
    /// Haitian_Creole.
    /// </summary>
    [EnumMember(Value = "ht")]
    Haitian_Creole,

    /// <summary>
    /// Hausa.
    /// </summary>
    [EnumMember(Value = "ha")]
    Hausa,

    /// <summary>
    /// Hawaiian. (ISO-639-2)
    /// </summary>
    [EnumMember(Value = "haw")]
    Hawaiian,

    /// <summary>
    /// Hebrew. (2nd ISO-631-1 code)
    /// </summary>
    [EnumMember(Value = "he")]
    Hebrew,

    /// <summary>
    /// Hebrew.
    /// </summary>
    [EnumMember(Value = "iw")]
    HebrewOld,

    /// <summary>
    /// Hindi.
    /// </summary>
    [EnumMember(Value = "hi")]
    Hindi,

    /// <summary>
    /// Hmong. (ISO-639-2)
    /// </summary>
    [EnumMember(Value = "hmn")]
    Hmong,

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
    /// Igbo.
    /// </summary>
    [EnumMember(Value = "ig")]
    Igbo,

    /// <summary>
    /// Indonesian.
    /// </summary>
    [EnumMember(Value = "id")]
    Indonesian,

    /// <summary>
    /// Irish.
    /// </summary>
    [EnumMember(Value = "ga")]
    Irish,

    /// <summary>
    /// Italian.
    /// </summary>
    [EnumMember(Value = "it")]
    Italian,

    /// <summary>
    /// Japanese.
    /// </summary>
    [EnumMember(Value = "ja")]
    Japanese,

    /// <summary>
    /// Javanese.
    /// </summary>
    [EnumMember(Value = "jw")]
    Javanese,

    /// <summary>
    /// Kannada.
    /// </summary>
    [EnumMember(Value = "kn")]
    Kannada,

    /// <summary>
    /// Kazakh.
    /// </summary>
    [EnumMember(Value = "kk")]
    Kazakh,

    /// <summary>
    /// Khmer.
    /// </summary>
    [EnumMember(Value = "km")]
    Khmer,

    /// <summary>
    /// Kinyarwanda.
    /// </summary>
    [EnumMember(Value = "rw")]
    Kinyarwanda,

    /// <summary>
    /// Korean.
    /// </summary>
    [EnumMember(Value = "ko")]
    Korean,

    /// <summary>
    /// Kurdish.
    /// </summary>
    [EnumMember(Value = "ku")]
    Kurdish,

    /// <summary>
    /// Kyrgyz.
    /// </summary>
    [EnumMember(Value = "ky")]
    Kyrgyz,

    /// <summary>
    /// Lao.
    /// </summary>
    [EnumMember(Value = "lo")]
    Lao,

    /// <summary>
    /// Latin.
    /// </summary>
    [EnumMember(Value = "la")]
    Latin,

    /// <summary>
    /// Latvian.
    /// </summary>
    [EnumMember(Value = "lv")]
    Latvian,

    /// <summary>
    /// Lithuanian.
    /// </summary>
    [EnumMember(Value = "lt")]
    Lithuanian,

    /// <summary>
    /// Luxembourgish.
    /// </summary>
    [EnumMember(Value = "lb")]
    Luxembourgish,

    /// <summary>
    /// Macedonian.
    /// </summary>
    [EnumMember(Value = "mk")]
    Macedonian,

    /// <summary>
    /// Malagasy.
    /// </summary>
    [EnumMember(Value = "mg")]
    Malagasy,

    /// <summary>
    /// Malay.
    /// </summary>
    [EnumMember(Value = "ms")]
    Malay,

    /// <summary>
    /// Malayalam.
    /// </summary>
    [EnumMember(Value = "ml")]
    Malayalam,

    /// <summary>
    /// Maltese.
    /// </summary>
    [EnumMember(Value = "mt")]
    Maltese,

    /// <summary>
    /// Maori.
    /// </summary>
    [EnumMember(Value = "mi")]
    Maori,

    /// <summary>
    /// Marathi.
    /// </summary>
    [EnumMember(Value = "mr")]
    Marathi,

    /// <summary>
    /// Mongolian.
    /// </summary>
    [EnumMember(Value = "mn")]
    Mongolian,

    /// <summary>
    /// Burmese.
    /// </summary>
    [EnumMember(Value = "my")]
    Burmese,

    /// <summary>
    /// Nepali.
    /// </summary>
    [EnumMember(Value = "ne")]
    Nepali,

    /// <summary>
    /// Norwegian.
    /// </summary>
    [EnumMember(Value = "no")]
    Norwegian,

    /// <summary>
    /// Odia.
    /// </summary>
    [EnumMember(Value = "or")]
    Odia,

    /// <summary>
    /// Pashto.
    /// </summary>
    [EnumMember(Value = "ps")]
    Pashto,

    /// <summary>
    /// Persian.
    /// </summary>
    [EnumMember(Value = "fa")]
    Persian,

    /// <summary>
    /// Polish.
    /// </summary>
    [EnumMember(Value = "pl")]
    Polish,

    /// <summary>
    /// Portuguese.
    /// </summary>
    [EnumMember(Value = "pt")]
    Portuguese,

    /// <summary>
    /// Punjabi.
    /// </summary>
    [EnumMember(Value = "pa")]
    Punjabi,

    /// <summary>
    /// Romanian.
    /// </summary>
    [EnumMember(Value = "ro")]
    Romanian,

    /// <summary>
    /// Russian.
    /// </summary>
    [EnumMember(Value = "ru")]
    Russian,

    /// <summary>
    /// Samoan.
    /// </summary>
    [EnumMember(Value = "sm")]
    Samoan,

    /// <summary>
    /// Scots_Gaelic.
    /// </summary>
    [EnumMember(Value = "gd")]
    Scots_Gaelic,

    /// <summary>
    /// Serbian.
    /// </summary>
    [EnumMember(Value = "sr")]
    Serbian,

    /// <summary>
    /// Sesotho.
    /// </summary>
    [EnumMember(Value = "st")]
    Sesotho,

    /// <summary>
    /// Shona.
    /// </summary>
    [EnumMember(Value = "sn")]
    Shona,

    /// <summary>
    /// Sindhi.
    /// </summary>
    [EnumMember(Value = "sd")]
    Sindhi,

    /// <summary>
    /// Sinhala.
    /// </summary>
    [EnumMember(Value = "si")]
    Sinhala,

    /// <summary>
    /// Slovak.
    /// </summary>
    [EnumMember(Value = "sk")]
    Slovak,

    /// <summary>
    /// Slovenian.
    /// </summary>
    [EnumMember(Value = "sl")]
    Slovenian,

    /// <summary>
    /// Somali.
    /// </summary>
    [EnumMember(Value = "so")]
    Somali,

    /// <summary>
    /// Spanish.
    /// </summary>
    [EnumMember(Value = "es")]
    Spanish,

    /// <summary>
    /// Sundanese.
    /// </summary>
    [EnumMember(Value = "su")]
    Sundanese,

    /// <summary>
    /// Swahili.
    /// </summary>
    [EnumMember(Value = "sw")]
    Swahili,

    /// <summary>
    /// Swedish.
    /// </summary>
    [EnumMember(Value = "sv")]
    Swedish,

    /// <summary>
    /// Tajik.
    /// </summary>
    [EnumMember(Value = "tg")]
    Tajik,

    /// <summary>
    /// Tamil.
    /// </summary>
    [EnumMember(Value = "ta")]
    Tamil,

    /// <summary>
    /// Tatar.
    /// </summary>
    [EnumMember(Value = "tt")]
    Tatar,

    /// <summary>
    /// Telugu.
    /// </summary>
    [EnumMember(Value = "te")]
    Telugu,

    /// <summary>
    /// Thai.
    /// </summary>
    [EnumMember(Value = "th")]
    Thai,

    /// <summary>
    /// Turkish.
    /// </summary>
    [EnumMember(Value = "tr")]
    Turkish,

    /// <summary>
    /// Turkmen.
    /// </summary>
    [EnumMember(Value = "tk")]
    Turkmen,

    /// <summary>
    /// Ukrainian.
    /// </summary>
    [EnumMember(Value = "uk")]
    Ukrainian,

    /// <summary>
    /// Urdu.
    /// </summary>
    [EnumMember(Value = "ur")]
    Urdu,

    /// <summary>
    /// Uyghur.
    /// </summary>
    [EnumMember(Value = "ug")]
    Uyghur,

    /// <summary>
    /// Uzbek.
    /// </summary>
    [EnumMember(Value = "uz")]
    Uzbek,

    /// <summary>
    /// Vietnamese.
    /// </summary>
    [EnumMember(Value = "vi")]
    Vietnamese,

    /// <summary>
    /// Welsh.
    /// </summary>
    [EnumMember(Value = "cy")]
    Welsh,

    /// <summary>
    /// Xhosa.
    /// </summary>
    [EnumMember(Value = "xh")]
    Xhosa,

    /// <summary>
    /// Yiddish.
    /// </summary>
    [EnumMember(Value = "yi")]
    Yiddish,

    /// <summary>
    /// Yoruba.
    /// </summary>
    [EnumMember(Value = "yo")]
    Yoruba,

    /// <summary>
    /// Zulu.
    /// </summary>
    [EnumMember(Value = "zu")]
    Zulu,

    /// <summary>
    /// Bihari.
    /// </summary>
    [EnumMember(Value = "bh")]
    Bihari,

    /// <summary>
    /// Akan.
    /// </summary>
    [EnumMember(Value = "ak")]
    Akan,

    /// <summary>
    /// Assamese.
    /// </summary>
    [EnumMember(Value = "as")]
    Assamese,

    /// <summary>
    /// Aymara.
    /// </summary>
    [EnumMember(Value = "ay")]
    Aymara,

    /// <summary>
    /// Divehi, Dhivehi, Maldivian.
    /// </summary>
    [EnumMember(Value = "dv")]
    DivehiDhivehiMaldivian,

    /// <summary>
    /// Dutch Middle Age.
    /// </summary>
    [EnumMember(Value = "ee")]
    DutchMiddleAge,

    /// <summary>
    /// Ganda.
    /// </summary>
    [EnumMember(Value = "lg")]
    Ganda,

    /// <summary>
    /// Guarani.
    /// </summary>
    [EnumMember(Value = "gn")]
    Guarani,

    /// <summary>
    /// Krio.
    /// </summary>
    [EnumMember(Value = "kri")]
    Krio,

    /// <summary>
    /// Lingala.
    /// </summary>
    [EnumMember(Value = "ln")]
    Lingala,

    /// <summary>
    /// Sepedi.
    /// </summary>
    [EnumMember(Value = "nso")]
    Sepedi,

    /// <summary>
    /// Oromo.
    /// </summary>
    [EnumMember(Value = "om")]
    Oromo,

    /// <summary>
    /// Quechua.
    /// </summary>
    [EnumMember(Value = "qu")]
    Quechua,

    /// <summary>
    /// Sanskrit.
    /// </summary>
    [EnumMember(Value = "sa")]
    Sanskrit,

    /// <summary>
    /// Tigrinya.
    /// </summary>
    [EnumMember(Value = "ti")]
    Tigrinya,

    /// <summary>
    /// Zulu.
    /// </summary>
    [EnumMember(Value = "ts")]
    Tsonga,

    /// <summary>
    /// Bambara.
    /// </summary>
    [EnumMember(Value = "bm")]
    Bambara,

    /// <summary>
    /// Bhojpuri.
    /// </summary>
    [EnumMember(Value = "bho")]
    Bhojpuri,

    /// <summary>
    /// Central Kurdish.
    /// </summary>
    [EnumMember(Value = "ckb")]
    CentralKurdish,

    /// <summary>
    /// Dogri .
    /// </summary>
    [EnumMember(Value = "doi")]
    Dogri,

    /// <summary>
    /// Goan Konkani.
    /// </summary>
    [EnumMember(Value = "gom")]
    GoanKonkani,

    /// <summary>
    /// Iloko.
    /// </summary>
    [EnumMember(Value = "ilo")]
    Iloko,

    /// <summary>
    /// Zulu.
    /// </summary>
    [EnumMember(Value = "Lushai")]
    Abc7,

    /// <summary>
    /// Maithili.
    /// </summary>
    [EnumMember(Value = "mai")]
    Maithili,

    /// <summary>
    /// Manipuri.
    /// </summary>
    [EnumMember(Value = "mni-Mtei")]
    Manipuri,

    /// <summary>
    /// Mizo.
    /// </summary>
    [EnumMember(Value = "lus")]
    Mizo,

    /// <summary>
    /// Unsupported.
    /// </summary>
    [EnumMember(Value = "XX")]
    Unsupported,
}