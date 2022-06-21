using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Common.Enums.Extensions;

[TestFixture]
public class StringExtensionTests
{
    [Test] public void FromCodeWhenAfrikaansTest() { Assert.AreEqual(Language.Afrikaans, "af".FromCode()); }
    [Test] public void FromCodeWhenAlbanianTest() { Assert.AreEqual(Language.Albanian, "sq".FromCode()); }
    [Test] public void FromCodeWhenAmharicTest() { Assert.AreEqual(Language.Amharic, "am".FromCode()); }
    [Test] public void FromCodeWhenArabicTest() { Assert.AreEqual(Language.Arabic, "ar".FromCode()); }
    [Test] public void FromCodeWhenArmenianTest() { Assert.AreEqual(Language.Armenian, "hy".FromCode()); }
    [Test] public void FromCodeWhenAzerbaijaniTest() { Assert.AreEqual(Language.Azerbaijani, "az".FromCode()); }
    [Test] public void FromCodeWhenBasqueTest() { Assert.AreEqual(Language.Basque, "eu".FromCode()); }
    [Test] public void FromCodeWhenBelarusianTest() { Assert.AreEqual(Language.Belarusian, "be".FromCode()); }
    [Test] public void FromCodeWhenBengaliTest() { Assert.AreEqual(Language.Bengali, "bn".FromCode()); }
    [Test] public void FromCodeWhenBosnianTest() { Assert.AreEqual(Language.Bosnian, "bs".FromCode()); }
    [Test] public void FromCodeWhenBulgarianTest() { Assert.AreEqual(Language.Bulgarian, "bg".FromCode()); }
    [Test] public void FromCodeWhenBurmeseTest() { Assert.AreEqual(Language.Burmese, "my".FromCode()); }
    [Test] public void FromCodeWhenCatalanTest() { Assert.AreEqual(Language.Catalan, "ca".FromCode()); }
    [Test] public void FromCodeWhenChineseTest() { Assert.AreEqual(Language.Chinese, "zh".FromCode()); }
    [Test] public void FromCodeWhenChineseSimplifiedTest() { Assert.AreEqual(Language.ChineseSimplified, "zh-CN".FromCode()); }
    [Test] public void FromCodeWhenChineseHongKongTest() { Assert.AreEqual(Language.ChineseHongKong, "zh-HK".FromCode()); }
    [Test] public void FromCodeWhenChineseTraditionalTest() { Assert.AreEqual(Language.ChineseTraditional, "zh-TW".FromCode()); }
    [Test] public void FromCodeWhenCroatianTest() { Assert.AreEqual(Language.Croatian, "hr".FromCode()); }
    [Test] public void FromCodeWhenCzechTest() { Assert.AreEqual(Language.Czech, "cs".FromCode()); }
    [Test] public void FromCodeWhenDanishTest() { Assert.AreEqual(Language.Danish, "da".FromCode()); }
    [Test] public void FromCodeWhenDutchTest() { Assert.AreEqual(Language.Dutch, "nl".FromCode()); }
    [Test] public void FromCodeWhenEnglishTest() { Assert.AreEqual(Language.English, "en".FromCode()); }
    [Test] public void FromCodeWhenEnglishAustralianTest() { Assert.AreEqual(Language.EnglishAustralian, "en-AU".FromCode()); }
    [Test] public void FromCodeWhenEnglishGreatBritainTest() { Assert.AreEqual(Language.EnglishGreatBritain, "en-GB".FromCode()); }
    [Test] public void FromCodeWhenEstonianTest() { Assert.AreEqual(Language.Estonian, "et".FromCode()); }
    [Test] public void FromCodeWhenFarsiTest() { Assert.AreEqual(Language.Farsi, "fa".FromCode()); }
    [Test] public void FromCodeWhenFinnishTest() { Assert.AreEqual(Language.Finnish, "fi".FromCode()); }
    [Test] public void FromCodeWhenFilipinoTest() { Assert.AreEqual(Language.Filipino, "fil".FromCode()); }
    [Test] public void FromCodeWhenFrenchTest() { Assert.AreEqual(Language.French, "fr".FromCode()); }
    [Test] public void FromCodeWhenFrenchCanadaTest() { Assert.AreEqual(Language.FrenchCanada, "fr-CA".FromCode()); }
    [Test] public void FromCodeWhenGalicianTest() { Assert.AreEqual(Language.Galician, "gl".FromCode()); }
    [Test] public void FromCodeWhenGeorgianTest() { Assert.AreEqual(Language.Georgian, "ka".FromCode()); }
    [Test] public void FromCodeWhenGermanTest() { Assert.AreEqual(Language.German, "de".FromCode()); }
    [Test] public void FromCodeWhenGreekTest() { Assert.AreEqual(Language.Greek, "el".FromCode()); }
    [Test] public void FromCodeWhenGujaratiTest() { Assert.AreEqual(Language.Gujarati, "gu".FromCode()); }
    [Test] public void FromCodeWhenHebrewTest() { Assert.AreEqual(Language.Hebrew, "iw".FromCode()); }
    [Test] public void FromCodeWhenHindiTest() { Assert.AreEqual(Language.Hindi, "hi".FromCode()); }
    [Test] public void FromCodeWhenHungarianTest() { Assert.AreEqual(Language.Hungarian, "hu".FromCode()); }
    [Test] public void FromCodeWhenIcelandicTest() { Assert.AreEqual(Language.Icelandic, "is".FromCode()); }
    [Test] public void FromCodeWhenIndonesianTest() { Assert.AreEqual(Language.Indonesian, "id".FromCode()); }
    [Test] public void FromCodeWhenItalianTest() { Assert.AreEqual(Language.Italian, "it".FromCode()); }
    [Test] public void FromCodeWhenJapaneseTest() { Assert.AreEqual(Language.Japanese, "ja".FromCode()); }
    [Test] public void FromCodeWhenKannadaTest() { Assert.AreEqual(Language.Kannada, "kn".FromCode()); }
    [Test] public void FromCodeWhenKazakhTest() { Assert.AreEqual(Language.Kazakh, "kk".FromCode()); }
    [Test] public void FromCodeWhenKhmerTest() { Assert.AreEqual(Language.Khmer, "km".FromCode()); }
    [Test] public void FromCodeWhenKoreanTest() { Assert.AreEqual(Language.Korean, "ko".FromCode()); }
    [Test] public void FromCodeWhenKyrgyzTest() { Assert.AreEqual(Language.Kyrgyz, "ky".FromCode()); }
    [Test] public void FromCodeWhenLaoTest() { Assert.AreEqual(Language.Lao, "lo".FromCode()); }
    [Test] public void FromCodeWhenLatvianTest() { Assert.AreEqual(Language.Latvian, "lv".FromCode()); }
    [Test] public void FromCodeWhenLithuanianTest() { Assert.AreEqual(Language.Lithuanian, "lt".FromCode()); }
    [Test] public void FromCodeWhenMacedonianTest() { Assert.AreEqual(Language.Macedonian, "mk".FromCode()); }
    [Test] public void FromCodeWhenMalayTest() { Assert.AreEqual(Language.Malay, "ms".FromCode()); }
    [Test] public void FromCodeWhenMalayalamTest() { Assert.AreEqual(Language.Malayalam, "ml".FromCode()); }
    [Test] public void FromCodeWhenMarathiTest() { Assert.AreEqual(Language.Marathi, "mr".FromCode()); }
    [Test] public void FromCodeWhenMongolianTest() { Assert.AreEqual(Language.Mongolian, "mn".FromCode()); }
    [Test] public void FromCodeWhenNepaliTest() { Assert.AreEqual(Language.Nepali, "ne".FromCode()); }
    [Test] public void FromCodeWhenNorwegianTest() { Assert.AreEqual(Language.Norwegian, "no".FromCode()); }
    [Test] public void FromCodeWhenPolishTest() { Assert.AreEqual(Language.Polish, "pl".FromCode()); }
    [Test] public void FromCodeWhenPortugueseTest() { Assert.AreEqual(Language.Portuguese, "pt".FromCode()); }
    [Test] public void FromCodeWhenPortugueseBrazilTest() { Assert.AreEqual(Language.PortugueseBrazil, "pt-BR".FromCode()); }
    [Test] public void FromCodeWhenPortuguesePortugalTest() { Assert.AreEqual(Language.PortuguesePortugal, "pt-PT".FromCode()); }
    [Test] public void FromCodeWhenPunjabiTest() { Assert.AreEqual(Language.Punjabi, "pa".FromCode()); }
    [Test] public void FromCodeWhenRomanianTest() { Assert.AreEqual(Language.Romanian, "ro".FromCode()); }
    [Test] public void FromCodeWhenRussianTest() { Assert.AreEqual(Language.Russian, "ru".FromCode()); }
    [Test] public void FromCodeWhenSerbianTest() { Assert.AreEqual(Language.Serbian, "sr".FromCode()); }
    [Test] public void FromCodeWhenSinhaleseTest() { Assert.AreEqual(Language.Sinhalese, "si".FromCode()); }
    [Test] public void FromCodeWhenSlovakTest() { Assert.AreEqual(Language.Slovak, "sk".FromCode()); }
    [Test] public void FromCodeWhenSlovenianTest() { Assert.AreEqual(Language.Slovenian, "sl".FromCode()); }
    [Test] public void FromCodeWhenSpanishTest() { Assert.AreEqual(Language.Spanish, "es".FromCode()); }
    [Test] public void FromCodeWhenSpanishLatinAmericaTest() { Assert.AreEqual(Language.SpanishLatinAmerica, "es-419".FromCode()); }
    [Test] public void FromCodeWhenSwahiliTest() { Assert.AreEqual(Language.Swahili, "sw".FromCode()); }
    [Test] public void FromCodeWhenSwedishTest() { Assert.AreEqual(Language.Swedish, "sv".FromCode()); }
    [Test] public void FromCodeWhenTamilTest() { Assert.AreEqual(Language.Tamil, "ta".FromCode()); }
    [Test] public void FromCodeWhenTeluguTest() { Assert.AreEqual(Language.Telugu, "te".FromCode()); }
    [Test] public void FromCodeWhenThaiTest() { Assert.AreEqual(Language.Thai, "th".FromCode()); }
    [Test] public void FromCodeWhenTurkishTest() { Assert.AreEqual(Language.Turkish, "tr".FromCode()); }
    [Test] public void FromCodeWhenUkrainianTest() { Assert.AreEqual(Language.Ukrainian, "uk".FromCode()); }
    [Test] public void FromCodeWhenUrduTest() { Assert.AreEqual(Language.Urdu, "ur".FromCode()); }
    [Test] public void FromCodeWhenUzbekTest() { Assert.AreEqual(Language.Uzbek, "uz".FromCode()); }
    [Test] public void FromCodeWhenVietnameseTest() { Assert.AreEqual(Language.Vietnamese, "vi".FromCode()); }
    [Test] public void FromCodeWhenZuluTest() { Assert.AreEqual(Language.Zulu, "zu".FromCode()); }
}