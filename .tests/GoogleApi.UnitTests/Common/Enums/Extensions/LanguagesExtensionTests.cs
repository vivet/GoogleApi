using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using NUnit.Framework;

namespace GoogleApi.UnitTests.Common.Enums.Extensions
{
    [TestFixture]
    public class LanguagesExtensionTests
    {
        [Test] public void ToCodeWhenArabicTest() { Assert.AreEqual("ar", Language.Arabic.ToCode()); }
        [Test] public void ToCodeWhenBasqueTest() { Assert.AreEqual("eu", Language.Basque.ToCode()); }
        [Test] public void ToCodeWhenBengaliTest() { Assert.AreEqual("bn", Language.Bengali.ToCode()); }
        [Test] public void ToCodeWhenBulgarianTest() { Assert.AreEqual("bg", Language.Bulgarian.ToCode()); }
        [Test] public void ToCodeWhenCatalanTest() { Assert.AreEqual("ca", Language.Catalan.ToCode()); }
        [Test] public void ToCodeWhenChineseSimplifiedTest() { Assert.AreEqual("zh-CN", Language.ChineseSimplified.ToCode()); }
        [Test] public void ToCodeWhenChineseTraditionalTest() { Assert.AreEqual("zh-TW", Language.ChineseTraditional.ToCode()); }
        [Test] public void ToCodeWhenCroatianTest() { Assert.AreEqual("hr", Language.Croatian.ToCode()); }
        [Test] public void ToCodeWhenCzechTest() { Assert.AreEqual("cs", Language.Czech.ToCode()); }
        [Test] public void ToCodeWhenDanishTest() { Assert.AreEqual("da", Language.Danish.ToCode()); }
        [Test] public void ToCodeWhenDutchTest() { Assert.AreEqual("nl", Language.Dutch.ToCode()); }
        [Test] public void ToCodeWhenEnglishTest() { Assert.AreEqual("en", Language.English.ToCode()); }
        [Test] public void ToCodeWhenFilipinoTest() { Assert.AreEqual("fil", Language.Filipino.ToCode()); }
        [Test] public void ToCodeWhenFinnishTest() { Assert.AreEqual("fi", Language.Finnish.ToCode()); }
        [Test] public void ToCodeWhenFrenchTest() { Assert.AreEqual("fr", Language.French.ToCode()); }
        [Test] public void ToCodeWhenGalicianTest() { Assert.AreEqual("gl", Language.Galician.ToCode()); }
        [Test] public void ToCodeWhenGermanTest() { Assert.AreEqual("de", Language.German.ToCode()); }
        [Test] public void ToCodeWhenGreekTest() { Assert.AreEqual("el", Language.Greek.ToCode()); }
        [Test] public void ToCodeWhenGujaratiTest() { Assert.AreEqual("gu", Language.Gujarati.ToCode()); }
        [Test] public void ToCodeWhenHebrewTest() { Assert.AreEqual("iw", Language.Hebrew.ToCode()); }
        [Test] public void ToCodeWhenHindiTest() { Assert.AreEqual("hi", Language.Hindi.ToCode()); }
        [Test] public void ToCodeWhenHungarianTest() { Assert.AreEqual("hu", Language.Hungarian.ToCode()); }
        [Test] public void ToCodeWhenIndonesianTest() { Assert.AreEqual("id", Language.Indonesian.ToCode()); }
        [Test] public void ToCodeWhenItalianTest() { Assert.AreEqual("it", Language.Italian.ToCode()); }
        [Test] public void ToCodeWhenJapaneseTest() { Assert.AreEqual("ja", Language.Japanese.ToCode()); }
        [Test] public void ToCodeWhenKannadaTest() { Assert.AreEqual("kn", Language.Kannada.ToCode()); }
        [Test] public void ToCodeWhenKoreanTest() { Assert.AreEqual("ko", Language.Korean.ToCode()); }
        [Test] public void ToCodeWhenLatvianTest() { Assert.AreEqual("lv", Language.Latvian.ToCode()); }
        [Test] public void ToCodeWhenLithuanianTest() { Assert.AreEqual("lt", Language.Lithuanian.ToCode()); }
        [Test] public void ToCodeWhenMalayalamTest() { Assert.AreEqual("ml", Language.Malayalam.ToCode()); }
        [Test] public void ToCodeWhenMarathiTest() { Assert.AreEqual("mr", Language.Marathi.ToCode()); }
        [Test] public void ToCodeWhenNorwegianTest() { Assert.AreEqual("no", Language.Norwegian.ToCode()); }
        [Test] public void ToCodeWhenPolishTest() { Assert.AreEqual("pl", Language.Polish.ToCode()); }
        [Test] public void ToCodeWhenPortugueseTest() { Assert.AreEqual("pt", Language.Portuguese.ToCode()); }
        [Test] public void ToCodeWhenRomanianTest() { Assert.AreEqual("ro", Language.Romanian.ToCode()); }
        [Test] public void ToCodeWhenRussianTest() { Assert.AreEqual("ru", Language.Russian.ToCode()); }
        [Test] public void ToCodeWhenSerbianTest() { Assert.AreEqual("sr", Language.Serbian.ToCode()); }
        [Test] public void ToCodeWhenSlovakTest() { Assert.AreEqual("sk", Language.Slovak.ToCode()); }
        [Test] public void ToCodeWhenSlovenianTest() { Assert.AreEqual("sl", Language.Slovenian.ToCode()); }
        [Test] public void ToCodeWhenSpanishTest() { Assert.AreEqual("es", Language.Spanish.ToCode()); }
        [Test] public void ToCodeWhenSwedishTest() { Assert.AreEqual("sv", Language.Swedish.ToCode()); }
        [Test] public void ToCodeWhenTamilTest() { Assert.AreEqual("ta", Language.Tamil.ToCode()); }
        [Test] public void ToCodeWhenTeluguTest() { Assert.AreEqual("te", Language.Telugu.ToCode()); }
        [Test] public void ToCodeWhenThaiTest() { Assert.AreEqual("th", Language.Thai.ToCode()); }
        [Test] public void ToCodeWhenTurkishTest() { Assert.AreEqual("tr", Language.Turkish.ToCode()); }
        [Test] public void ToCodeWhenUkrainianTest() { Assert.AreEqual("uk", Language.Ukrainian.ToCode()); }
        [Test] public void ToCodeWhenVietnameseTest() { Assert.AreEqual("vi", Language.Vietnamese.ToCode()); }
    }
}