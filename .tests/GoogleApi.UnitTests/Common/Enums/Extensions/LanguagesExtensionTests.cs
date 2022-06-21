using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Common.Enums.Extensions;

[TestFixture]
public class LanguagesExtensionTests
{
    [Test] public void ToCodeWhenAfrikaansTest() { Assert.AreEqual("af", Language.Afrikaans.ToCode()); }
    [Test] public void ToCodeWhenAlbanianTest() { Assert.AreEqual("sq", Language.Albanian.ToCode()); }
    [Test] public void ToCodeWhenAmharicTest() { Assert.AreEqual("am", Language.Amharic.ToCode()); }
    [Test] public void ToCodeWhenArabicTest() { Assert.AreEqual("ar", Language.Arabic.ToCode()); }
    [Test] public void ToCodeWhenArmenianTest() { Assert.AreEqual("hy", Language.Armenian.ToCode()); }
    [Test] public void ToCodeWhenAzerbaijaniTest() { Assert.AreEqual("az", Language.Azerbaijani.ToCode()); }
    [Test] public void ToCodeWhenBasqueTest() { Assert.AreEqual("eu", Language.Basque.ToCode()); }
    [Test] public void ToCodeWhenBelarusianTest() { Assert.AreEqual("be", Language.Belarusian.ToCode()); }
    [Test] public void ToCodeWhenBengaliTest() { Assert.AreEqual("bn", Language.Bengali.ToCode()); }
    [Test] public void ToCodeWhenBosnianTest() { Assert.AreEqual("bs", Language.Bosnian.ToCode()); }
    [Test] public void ToCodeWhenBulgarianTest() { Assert.AreEqual("bg", Language.Bulgarian.ToCode()); }
    [Test] public void ToCodeWhenBurmeseTest() { Assert.AreEqual("my", Language.Burmese.ToCode()); }
    [Test] public void ToCodeWhenCatalanTest() { Assert.AreEqual("ca", Language.Catalan.ToCode()); }
    [Test] public void ToCodeWhenChineseTest() { Assert.AreEqual("zh", Language.Chinese.ToCode()); }
    [Test] public void ToCodeWhenChineseSimplifiedTest() { Assert.AreEqual("zh-CN", Language.ChineseSimplified.ToCode()); }
    [Test] public void ToCodeWhenChineseHongKongTest() { Assert.AreEqual("zh-HK", Language.ChineseHongKong.ToCode()); }
    [Test] public void ToCodeWhenChineseTraditionalTest() { Assert.AreEqual("zh-TW", Language.ChineseTraditional.ToCode()); }
    [Test] public void ToCodeWhenCroatianTest() { Assert.AreEqual("hr", Language.Croatian.ToCode()); }
    [Test] public void ToCodeWhenCzechTest() { Assert.AreEqual("cs", Language.Czech.ToCode()); }
    [Test] public void ToCodeWhenDanishTest() { Assert.AreEqual("da", Language.Danish.ToCode()); }
    [Test] public void ToCodeWhenDutchTest() { Assert.AreEqual("nl", Language.Dutch.ToCode()); }
    [Test] public void ToCodeWhenEnglishTest() { Assert.AreEqual("en", Language.English.ToCode()); }
    [Test] public void ToCodeWhenEnglishAustralianTest() { Assert.AreEqual("en-AU", Language.EnglishAustralian.ToCode()); }
    [Test] public void ToCodeWhenEnglishGreatBritainTest() { Assert.AreEqual("en-GB", Language.EnglishGreatBritain.ToCode()); }
    [Test] public void ToCodeWhenEstonianTest() { Assert.AreEqual("et", Language.Estonian.ToCode()); }
    [Test] public void ToCodeWhenFarsiTest() { Assert.AreEqual("fa", Language.Farsi.ToCode()); }
    [Test] public void ToCodeWhenFinnishTest() { Assert.AreEqual("fi", Language.Finnish.ToCode()); }
    [Test] public void ToCodeWhenFilipinoTest() { Assert.AreEqual("fil", Language.Filipino.ToCode()); }
    [Test] public void ToCodeWhenFrenchTest() { Assert.AreEqual("fr", Language.French.ToCode()); }
    [Test] public void ToCodeWhenFrenchCanadaTest() { Assert.AreEqual("fr-CA", Language.FrenchCanada.ToCode()); }
    [Test] public void ToCodeWhenGalicianTest() { Assert.AreEqual("gl", Language.Galician.ToCode()); }
    [Test] public void ToCodeWhenGeorgianTest() { Assert.AreEqual("ka", Language.Georgian.ToCode()); }
    [Test] public void ToCodeWhenGermanTest() { Assert.AreEqual("de", Language.German.ToCode()); }
    [Test] public void ToCodeWhenGreekTest() { Assert.AreEqual("el", Language.Greek.ToCode()); }
    [Test] public void ToCodeWhenGujaratiTest() { Assert.AreEqual("gu", Language.Gujarati.ToCode()); }
    [Test] public void ToCodeWhenHebrewTest() { Assert.AreEqual("iw", Language.Hebrew.ToCode()); }
    [Test] public void ToCodeWhenHindiTest() { Assert.AreEqual("hi", Language.Hindi.ToCode()); }
    [Test] public void ToCodeWhenHungarianTest() { Assert.AreEqual("hu", Language.Hungarian.ToCode()); }
    [Test] public void ToCodeWhenIcelandicTest() { Assert.AreEqual("is", Language.Icelandic.ToCode()); }
    [Test] public void ToCodeWhenIndonesianTest() { Assert.AreEqual("id", Language.Indonesian.ToCode()); }
    [Test] public void ToCodeWhenItalianTest() { Assert.AreEqual("it", Language.Italian.ToCode()); }
    [Test] public void ToCodeWhenJapaneseTest() { Assert.AreEqual("ja", Language.Japanese.ToCode()); }
    [Test] public void ToCodeWhenKannadaTest() { Assert.AreEqual("kn", Language.Kannada.ToCode()); }
    [Test] public void ToCodeWhenKazakhTest() { Assert.AreEqual("kk", Language.Kazakh.ToCode()); }
    [Test] public void ToCodeWhenKhmerTest() { Assert.AreEqual("km", Language.Khmer.ToCode()); }
    [Test] public void ToCodeWhenKoreanTest() { Assert.AreEqual("ko", Language.Korean.ToCode()); }
    [Test] public void ToCodeWhenKyrgyzTest() { Assert.AreEqual("ky", Language.Kyrgyz.ToCode()); }
    [Test] public void ToCodeWhenLaoTest() { Assert.AreEqual("lo", Language.Lao.ToCode()); }
    [Test] public void ToCodeWhenLatvianTest() { Assert.AreEqual("lv", Language.Latvian.ToCode()); }
    [Test] public void ToCodeWhenLithuanianTest() { Assert.AreEqual("lt", Language.Lithuanian.ToCode()); }
    [Test] public void ToCodeWhenMacedonianTest() { Assert.AreEqual("mk", Language.Macedonian.ToCode()); }
    [Test] public void ToCodeWhenMalayTest() { Assert.AreEqual("ms", Language.Malay.ToCode()); }
    [Test] public void ToCodeWhenMalayalamTest() { Assert.AreEqual("ml", Language.Malayalam.ToCode()); }
    [Test] public void ToCodeWhenMarathiTest() { Assert.AreEqual("mr", Language.Marathi.ToCode()); }
    [Test] public void ToCodeWhenMongolianTest() { Assert.AreEqual("mn", Language.Mongolian.ToCode()); }
    [Test] public void ToCodeWhenNepaliTest() { Assert.AreEqual("ne", Language.Nepali.ToCode()); }
    [Test] public void ToCodeWhenNorwegianTest() { Assert.AreEqual("no", Language.Norwegian.ToCode()); }
    [Test] public void ToCodeWhenPolishTest() { Assert.AreEqual("pl", Language.Polish.ToCode()); }
    [Test] public void ToCodeWhenPortugueseTest() { Assert.AreEqual("pt", Language.Portuguese.ToCode()); }
    [Test] public void ToCodeWhenPortugueseBrazilTest() { Assert.AreEqual("pt-BR", Language.PortugueseBrazil.ToCode()); }
    [Test] public void ToCodeWhenPortuguesePortugalTest() { Assert.AreEqual("pt-PT", Language.PortuguesePortugal.ToCode()); }
    [Test] public void ToCodeWhenPunjabiTest() { Assert.AreEqual("pa", Language.Punjabi.ToCode()); }
    [Test] public void ToCodeWhenRomanianTest() { Assert.AreEqual("ro", Language.Romanian.ToCode()); }
    [Test] public void ToCodeWhenRussianTest() { Assert.AreEqual("ru", Language.Russian.ToCode()); }
    [Test] public void ToCodeWhenSerbianTest() { Assert.AreEqual("sr", Language.Serbian.ToCode()); }
    [Test] public void ToCodeWhenSinhaleseTest() { Assert.AreEqual("si", Language.Sinhalese.ToCode()); }
    [Test] public void ToCodeWhenSlovakTest() { Assert.AreEqual("sk", Language.Slovak.ToCode()); }
    [Test] public void ToCodeWhenSlovenianTest() { Assert.AreEqual("sl", Language.Slovenian.ToCode()); }
    [Test] public void ToCodeWhenSpanishTest() { Assert.AreEqual("es", Language.Spanish.ToCode()); }
    [Test] public void ToCodeWhenSpanishLatinAmericaTest() { Assert.AreEqual("es-419", Language.SpanishLatinAmerica.ToCode()); }
    [Test] public void ToCodeWhenSwahiliTest() { Assert.AreEqual("sw", Language.Swahili.ToCode()); }
    [Test] public void ToCodeWhenSwedishTest() { Assert.AreEqual("sv", Language.Swedish.ToCode()); }
    [Test] public void ToCodeWhenTamilTest() { Assert.AreEqual("ta", Language.Tamil.ToCode()); }
    [Test] public void ToCodeWhenTeluguTest() { Assert.AreEqual("te", Language.Telugu.ToCode()); }
    [Test] public void ToCodeWhenThaiTest() { Assert.AreEqual("th", Language.Thai.ToCode()); }
    [Test] public void ToCodeWhenTurkishTest() { Assert.AreEqual("tr", Language.Turkish.ToCode()); }
    [Test] public void ToCodeWhenUkrainianTest() { Assert.AreEqual("uk", Language.Ukrainian.ToCode()); }
    [Test] public void ToCodeWhenUrduTest() { Assert.AreEqual("ur", Language.Urdu.ToCode()); }
    [Test] public void ToCodeWhenUzbekTest() { Assert.AreEqual("uz", Language.Uzbek.ToCode()); }
    [Test] public void ToCodeWhenVietnameseTest() { Assert.AreEqual("vi", Language.Vietnamese.ToCode()); }
    [Test] public void ToCodeWhenZuluTest() { Assert.AreEqual("zu", Language.Zulu.ToCode()); }
}