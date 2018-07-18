using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Common.Enums.Extensions;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Translate.Common.Extensions
{
    [TestFixture]
    public class StringExtensionTests
    {
        [Test] public void FromCodeWhenAfrikaansTest() { Assert.AreEqual(Language.Afrikaans, "af".FromCode()); }
        [Test] public void FromCodeWhenAlbanianTest() { Assert.AreEqual(Language.Albanian, "sq".FromCode()); }
        [Test] public void FromCodeWhenAmharicTest() { Assert.AreEqual(Language.Amharic, "am".FromCode()); }
        [Test] public void FromCodeWhenArabicTest() { Assert.AreEqual(Language.Arabic, "ar".FromCode()); }
        [Test] public void FromCodeWhenArmenianTest() { Assert.AreEqual(Language.Armenian, "hy".FromCode()); }
        [Test] public void FromCodeWhenAzeerbaijaniTest() { Assert.AreEqual(Language.Azeerbaijani, "az".FromCode()); }
        [Test] public void FromCodeWhenBasqueTest() { Assert.AreEqual(Language.Basque, "eu".FromCode()); }
        [Test] public void FromCodeWhenBelarusianTest() { Assert.AreEqual(Language.Belarusian, "be".FromCode()); }
        [Test] public void FromCodeWhenBengaliTest() { Assert.AreEqual(Language.Bengali, "bn".FromCode()); }
        [Test] public void FromCodeWhenBosnianTest() { Assert.AreEqual(Language.Bosnian, "bs".FromCode()); }
        [Test] public void FromCodeWhenBulgarianTest() { Assert.AreEqual(Language.Bulgarian, "bg".FromCode()); }
        [Test] public void FromCodeWhenCatalanTest() { Assert.AreEqual(Language.Catalan, "ca".FromCode()); }
        [Test] public void FromCodeWhenCebuanoTest() { Assert.AreEqual(Language.Cebuano, "ceb".FromCode()); }
        [Test] public void FromCodeWhenChichewaTest() { Assert.AreEqual(Language.Chichewa, "ny".FromCode()); }
        [Test] public void FromCodeWhenChinese_SimplifiedTest() { Assert.AreEqual(Language.Chinese_Simplified, "zh-CN".FromCode()); }
        [Test] public void FromCodeWhenChinese_TraditionalTest() { Assert.AreEqual(Language.Chinese_Traditional, "zh-TW".FromCode()); }
        [Test] public void FromCodeWhenCorsicanTest() { Assert.AreEqual(Language.Corsican, "co".FromCode()); }
        [Test] public void FromCodeWhenCroatianTest() { Assert.AreEqual(Language.Croatian, "hr".FromCode()); }
        [Test] public void FromCodeWhenCzechTest() { Assert.AreEqual(Language.Czech, "cs".FromCode()); }
        [Test] public void FromCodeWhenDanishTest() { Assert.AreEqual(Language.Danish, "da".FromCode()); }
        [Test] public void FromCodeWhenDutchTest() { Assert.AreEqual(Language.Dutch, "nl".FromCode()); }
        [Test] public void FromCodeWhenEnglishTest() { Assert.AreEqual(Language.English, "en".FromCode()); }
        [Test] public void FromCodeWhenEsperantoTest() { Assert.AreEqual(Language.Esperanto, "eo".FromCode()); }
        [Test] public void FromCodeWhenEstonianTest() { Assert.AreEqual(Language.Estonian, "et".FromCode()); }
        [Test] public void FromCodeWhenFilipinoTest() { Assert.AreEqual(Language.Filipino, "tl".FromCode()); }
        [Test] public void FromCodeWhenFinnishTest() { Assert.AreEqual(Language.Finnish, "fi".FromCode()); }
        [Test] public void FromCodeWhenFrenchTest() { Assert.AreEqual(Language.French, "fr".FromCode()); }
        [Test] public void FromCodeWhenFrisianTest() { Assert.AreEqual(Language.Frisian, "fy".FromCode()); }
        [Test] public void FromCodeWhenGalicianTest() { Assert.AreEqual(Language.Galician, "gl".FromCode()); }
        [Test] public void FromCodeWhenGeorgianTest() { Assert.AreEqual(Language.Georgian, "ka".FromCode()); }
        [Test] public void FromCodeWhenGermanTest() { Assert.AreEqual(Language.German, "de".FromCode()); }
        [Test] public void FromCodeWhenGreekTest() { Assert.AreEqual(Language.Greek, "el".FromCode()); }
        [Test] public void FromCodeWhenGujaratiTest() { Assert.AreEqual(Language.Gujarati, "gu".FromCode()); }
        [Test] public void FromCodeWhenHaitian_CreoleTest() { Assert.AreEqual(Language.Haitian_Creole, "ht".FromCode()); }
        [Test] public void FromCodeWhenHausaTest() { Assert.AreEqual(Language.Hausa, "ha".FromCode()); }
        [Test] public void FromCodeWhenHawaiianTest() { Assert.AreEqual(Language.Hawaiian, "haw".FromCode()); }
        [Test] public void FromCodeWhenHebrewTest() { Assert.AreEqual(Language.Hebrew, "iw".FromCode()); }
        [Test] public void FromCodeWhenHindiTest() { Assert.AreEqual(Language.Hindi, "hi".FromCode()); }
        [Test] public void FromCodeWhenHmongTest() { Assert.AreEqual(Language.Hmong, "hmn".FromCode()); }
        [Test] public void FromCodeWhenHungarianTest() { Assert.AreEqual(Language.Hungarian, "hu".FromCode()); }
        [Test] public void FromCodeWhenIcelandicTest() { Assert.AreEqual(Language.Icelandic, "is".FromCode()); }
        [Test] public void FromCodeWhenIgboTest() { Assert.AreEqual(Language.Igbo, "ig".FromCode()); }
        [Test] public void FromCodeWhenIndonesianTest() { Assert.AreEqual(Language.Indonesian, "id".FromCode()); }
        [Test] public void FromCodeWhenIrishTest() { Assert.AreEqual(Language.Irish, "ga".FromCode()); }
        [Test] public void FromCodeWhenItalianTest() { Assert.AreEqual(Language.Italian, "it".FromCode()); }
        [Test] public void FromCodeWhenJapaneseTest() { Assert.AreEqual(Language.Japanese, "ja".FromCode()); }
        [Test] public void FromCodeWhenJavaneseTest() { Assert.AreEqual(Language.Javanese, "jw".FromCode()); }
        [Test] public void FromCodeWhenKannadaTest() { Assert.AreEqual(Language.Kannada, "kn".FromCode()); }
        [Test] public void FromCodeWhenKazakhTest() { Assert.AreEqual(Language.Kazakh, "kk".FromCode()); }
        [Test] public void FromCodeWhenKhmerTest() { Assert.AreEqual(Language.Khmer, "km".FromCode()); }
        [Test] public void FromCodeWhenKoreanTest() { Assert.AreEqual(Language.Korean, "ko".FromCode()); }
        [Test] public void FromCodeWhenKurdishTest() { Assert.AreEqual(Language.Kurdish, "ku".FromCode()); }
        [Test] public void FromCodeWhenKyrgyzTest() { Assert.AreEqual(Language.Kyrgyz, "ky".FromCode()); }
        [Test] public void FromCodeWhenLaoTest() { Assert.AreEqual(Language.Lao, "lo".FromCode()); }
        [Test] public void FromCodeWhenLatinTest() { Assert.AreEqual(Language.Latin, "la".FromCode()); }
        [Test] public void FromCodeWhenLatvianTest() { Assert.AreEqual(Language.Latvian, "lv".FromCode()); }
        [Test] public void FromCodeWhenLithuanianTest() { Assert.AreEqual(Language.Lithuanian, "lt".FromCode()); }
        [Test] public void FromCodeWhenLuxembourgishTest() { Assert.AreEqual(Language.Luxembourgish, "lb".FromCode()); }
        [Test] public void FromCodeWhenMacedonianTest() { Assert.AreEqual(Language.Macedonian, "mk".FromCode()); }
        [Test] public void FromCodeWhenMalagasyTest() { Assert.AreEqual(Language.Malagasy, "mg".FromCode()); }
        [Test] public void FromCodeWhenMalayTest() { Assert.AreEqual(Language.Malay, "ms".FromCode()); }
        [Test] public void FromCodeWhenMalayalamTest() { Assert.AreEqual(Language.Malayalam, "ml".FromCode()); }
        [Test] public void FromCodeWhenMalteseTest() { Assert.AreEqual(Language.Maltese, "mt".FromCode()); }
        [Test] public void FromCodeWhenMaoriTest() { Assert.AreEqual(Language.Maori, "mi".FromCode()); }
        [Test] public void FromCodeWhenMarathiTest() { Assert.AreEqual(Language.Marathi, "mr".FromCode()); }
        [Test] public void FromCodeWhenMongolianTest() { Assert.AreEqual(Language.Mongolian, "mn".FromCode()); }
        [Test] public void FromCodeWhenBurmeseTest() { Assert.AreEqual(Language.Burmese, "my".FromCode()); }
        [Test] public void FromCodeWhenNepaliTest() { Assert.AreEqual(Language.Nepali, "ne".FromCode()); }
        [Test] public void FromCodeWhenNorwegianTest() { Assert.AreEqual(Language.Norwegian, "no".FromCode()); }
        [Test] public void FromCodeWhenPashtoTest() { Assert.AreEqual(Language.Pashto, "ps".FromCode()); }
        [Test] public void FromCodeWhenPersianTest() { Assert.AreEqual(Language.Persian, "fa".FromCode()); }
        [Test] public void FromCodeWhenPolishTest() { Assert.AreEqual(Language.Polish, "pl".FromCode()); }
        [Test] public void FromCodeWhenPortugueseTest() { Assert.AreEqual(Language.Portuguese, "pt".FromCode()); }
        [Test] public void FromCodeWhenPunjabiTest() { Assert.AreEqual(Language.Punjabi, "ma".FromCode()); }
        [Test] public void FromCodeWhenRomanianTest() { Assert.AreEqual(Language.Romanian, "ro".FromCode()); }
        [Test] public void FromCodeWhenRussianTest() { Assert.AreEqual(Language.Russian, "ru".FromCode()); }
        [Test] public void FromCodeWhenSamoanTest() { Assert.AreEqual(Language.Samoan, "sm".FromCode()); }
        [Test] public void FromCodeWhenScots_GaelicTest() { Assert.AreEqual(Language.Scots_Gaelic, "gd".FromCode()); }
        [Test] public void FromCodeWhenSerbianTest() { Assert.AreEqual(Language.Serbian, "sr".FromCode()); }
        [Test] public void FromCodeWhenSesothoTest() { Assert.AreEqual(Language.Sesotho, "st".FromCode()); }
        [Test] public void FromCodeWhenShonaTest() { Assert.AreEqual(Language.Shona, "sn".FromCode()); }
        [Test] public void FromCodeWhenSindhiTest() { Assert.AreEqual(Language.Sindhi, "sd".FromCode()); }
        [Test] public void FromCodeWhenSinhalaTest() { Assert.AreEqual(Language.Sinhala, "si".FromCode()); }
        [Test] public void FromCodeWhenSlovakTest() { Assert.AreEqual(Language.Slovak, "sk".FromCode()); }
        [Test] public void FromCodeWhenSlovenianTest() { Assert.AreEqual(Language.Slovenian, "sl".FromCode()); }
        [Test] public void FromCodeWhenSomaliTest() { Assert.AreEqual(Language.Somali, "so".FromCode()); }
        [Test] public void FromCodeWhenSpanishTest() { Assert.AreEqual(Language.Spanish, "es".FromCode()); }
        [Test] public void FromCodeWhenSundaneseTest() { Assert.AreEqual(Language.Sundanese, "su".FromCode()); }
        [Test] public void FromCodeWhenSwahiliTest() { Assert.AreEqual(Language.Swahili, "sw".FromCode()); }
        [Test] public void FromCodeWhenSwedishTest() { Assert.AreEqual(Language.Swedish, "sv".FromCode()); }
        [Test] public void FromCodeWhenTajikTest() { Assert.AreEqual(Language.Tajik, "tg".FromCode()); }
        [Test] public void FromCodeWhenTamilTest() { Assert.AreEqual(Language.Tamil, "ta".FromCode()); }
        [Test] public void FromCodeWhenTeluguTest() { Assert.AreEqual(Language.Telugu, "te".FromCode()); }
        [Test] public void FromCodeWhenThaiTest() { Assert.AreEqual(Language.Thai, "th".FromCode()); }
        [Test] public void FromCodeWhenTurkishTest() { Assert.AreEqual(Language.Turkish, "tr".FromCode()); }
        [Test] public void FromCodeWhenUkrainianTest() { Assert.AreEqual(Language.Ukrainian, "uk".FromCode()); }
        [Test] public void FromCodeWhenUrduTest() { Assert.AreEqual(Language.Urdu, "ur".FromCode()); }
        [Test] public void FromCodeWhenUzbekTest() { Assert.AreEqual(Language.Uzbek, "uz".FromCode()); }
        [Test] public void FromCodeWhenVietnameseTest() { Assert.AreEqual(Language.Vietnamese, "vi".FromCode()); }
        [Test] public void FromCodeWhenWelshTest() { Assert.AreEqual(Language.Welsh, "cy".FromCode()); }
        [Test] public void FromCodeWhenXhosaTest() { Assert.AreEqual(Language.Xhosa, "xh".FromCode()); }
        [Test] public void FromCodeWhenYiddishTest() { Assert.AreEqual(Language.Yiddish, "yi".FromCode()); }
        [Test] public void FromCodeWhenYorubaTest() { Assert.AreEqual(Language.Yoruba, "yo".FromCode()); }
        [Test] public void FromCodeWhenZuluTest() { Assert.AreEqual(Language.Zulu, "zu".FromCode()); }
    }
}