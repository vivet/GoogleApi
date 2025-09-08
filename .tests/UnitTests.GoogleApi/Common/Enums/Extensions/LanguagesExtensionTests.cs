using GoogleApi.Entities.Common.Enums.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GoogleApi.Entities.Common.Enums;

namespace GoogleApi.UnitTests.Common.Enums.Extensions;

[TestClass]
public class LanguagesExtensionTests
{
    [TestMethod]
    public void ToCodeWhenAfrikaansTest()
    {
        Assert.AreEqual("af", Language.Afrikaans.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenAlbanianTest()
    {
        Assert.AreEqual("sq", Language.Albanian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenAmharicTest()
    {
        Assert.AreEqual("am", Language.Amharic.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenArabicTest()
    {
        Assert.AreEqual("ar", Language.Arabic.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenArmenianTest()
    {
        Assert.AreEqual("hy", Language.Armenian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenAzerbaijaniTest()
    {
        Assert.AreEqual("az", Language.Azerbaijani.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenBasqueTest()
    {
        Assert.AreEqual("eu", Language.Basque.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenBelarusianTest()
    {
        Assert.AreEqual("be", Language.Belarusian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenBengaliTest()
    {
        Assert.AreEqual("bn", Language.Bengali.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenBosnianTest()
    {
        Assert.AreEqual("bs", Language.Bosnian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenBulgarianTest()
    {
        Assert.AreEqual("bg", Language.Bulgarian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenBurmeseTest()
    {
        Assert.AreEqual("my", Language.Burmese.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenCatalanTest()
    {
        Assert.AreEqual("ca", Language.Catalan.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenChineseTest()
    {
        Assert.AreEqual("zh", Language.Chinese.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenChineseSimplifiedTest()
    {
        Assert.AreEqual("zh-CN", Language.ChineseSimplified.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenChineseHongKongTest()
    {
        Assert.AreEqual("zh-HK", Language.ChineseHongKong.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenChineseTraditionalTest()
    {
        Assert.AreEqual("zh-TW", Language.ChineseTraditional.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenCroatianTest()
    {
        Assert.AreEqual("hr", Language.Croatian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenCzechTest()
    {
        Assert.AreEqual("cs", Language.Czech.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenDanishTest()
    {
        Assert.AreEqual("da", Language.Danish.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenDutchTest()
    {
        Assert.AreEqual("nl", Language.Dutch.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenEnglishTest()
    {
        Assert.AreEqual("en", Language.English.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenEnglishAustralianTest()
    {
        Assert.AreEqual("en-AU", Language.EnglishAustralian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenEnglishGreatBritainTest()
    {
        Assert.AreEqual("en-GB", Language.EnglishGreatBritain.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenEstonianTest()
    {
        Assert.AreEqual("et", Language.Estonian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenFarsiTest()
    {
        Assert.AreEqual("fa", Language.Farsi.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenFinnishTest()
    {
        Assert.AreEqual("fi", Language.Finnish.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenFilipinoTest()
    {
        Assert.AreEqual("fil", Language.Filipino.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenFrenchTest()
    {
        Assert.AreEqual("fr", Language.French.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenFrenchCanadaTest()
    {
        Assert.AreEqual("fr-CA", Language.FrenchCanada.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenGalicianTest()
    {
        Assert.AreEqual("gl", Language.Galician.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenGeorgianTest()
    {
        Assert.AreEqual("ka", Language.Georgian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenGermanTest()
    {
        Assert.AreEqual("de", Language.German.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenGreekTest()
    {
        Assert.AreEqual("el", Language.Greek.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenGujaratiTest()
    {
        Assert.AreEqual("gu", Language.Gujarati.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenHebrewTest()
    {
        Assert.AreEqual("iw", Language.Hebrew.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenHindiTest()
    {
        Assert.AreEqual("hi", Language.Hindi.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenHungarianTest()
    {
        Assert.AreEqual("hu", Language.Hungarian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenIcelandicTest()
    {
        Assert.AreEqual("is", Language.Icelandic.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenIndonesianTest()
    {
        Assert.AreEqual("id", Language.Indonesian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenItalianTest()
    {
        Assert.AreEqual("it", Language.Italian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenJapaneseTest()
    {
        Assert.AreEqual("ja", Language.Japanese.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenKannadaTest()
    {
        Assert.AreEqual("kn", Language.Kannada.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenKazakhTest()
    {
        Assert.AreEqual("kk", Language.Kazakh.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenKhmerTest()
    {
        Assert.AreEqual("km", Language.Khmer.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenKoreanTest()
    {
        Assert.AreEqual("ko", Language.Korean.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenKyrgyzTest()
    {
        Assert.AreEqual("ky", Language.Kyrgyz.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenLaoTest()
    {
        Assert.AreEqual("lo", Language.Lao.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenLatvianTest()
    {
        Assert.AreEqual("lv", Language.Latvian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenLithuanianTest()
    {
        Assert.AreEqual("lt", Language.Lithuanian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenMacedonianTest()
    {
        Assert.AreEqual("mk", Language.Macedonian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenMalayTest()
    {
        Assert.AreEqual("ms", Language.Malay.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenMalayalamTest()
    {
        Assert.AreEqual("ml", Language.Malayalam.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenMarathiTest()
    {
        Assert.AreEqual("mr", Language.Marathi.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenMongolianTest()
    {
        Assert.AreEqual("mn", Language.Mongolian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenNepaliTest()
    {
        Assert.AreEqual("ne", Language.Nepali.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenNorwegianTest()
    {
        Assert.AreEqual("no", Language.Norwegian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenPolishTest()
    {
        Assert.AreEqual("pl", Language.Polish.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenPortugueseTest()
    {
        Assert.AreEqual("pt", Language.Portuguese.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenPortugueseBrazilTest()
    {
        Assert.AreEqual("pt-BR", Language.PortugueseBrazil.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenPortuguesePortugalTest()
    {
        Assert.AreEqual("pt-PT", Language.PortuguesePortugal.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenPunjabiTest()
    {
        Assert.AreEqual("pa", Language.Punjabi.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenRomanianTest()
    {
        Assert.AreEqual("ro", Language.Romanian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenRussianTest()
    {
        Assert.AreEqual("ru", Language.Russian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenSerbianTest()
    {
        Assert.AreEqual("sr", Language.Serbian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenSinhaleseTest()
    {
        Assert.AreEqual("si", Language.Sinhalese.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenSlovakTest()
    {
        Assert.AreEqual("sk", Language.Slovak.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenSlovenianTest()
    {
        Assert.AreEqual("sl", Language.Slovenian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenSpanishTest()
    {
        Assert.AreEqual("es", Language.Spanish.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenSpanishLatinAmericaTest()
    {
        Assert.AreEqual("es-419", Language.SpanishLatinAmerica.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenSwahiliTest()
    {
        Assert.AreEqual("sw", Language.Swahili.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenSwedishTest()
    {
        Assert.AreEqual("sv", Language.Swedish.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenTamilTest()
    {
        Assert.AreEqual("ta", Language.Tamil.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenTeluguTest()
    {
        Assert.AreEqual("te", Language.Telugu.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenThaiTest()
    {
        Assert.AreEqual("th", Language.Thai.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenTurkishTest()
    {
        Assert.AreEqual("tr", Language.Turkish.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenUkrainianTest()
    {
        Assert.AreEqual("uk", Language.Ukrainian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenUrduTest()
    {
        Assert.AreEqual("ur", Language.Urdu.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenUzbekTest()
    {
        Assert.AreEqual("uz", Language.Uzbek.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenVietnameseTest()
    {
        Assert.AreEqual("vi", Language.Vietnamese.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenZuluTest()
    {
        Assert.AreEqual("zu", Language.Zulu.ToCode());
    }
}