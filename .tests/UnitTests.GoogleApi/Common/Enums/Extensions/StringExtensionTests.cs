using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Common.Enums.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.GoogleApi.Common.Enums.Extensions;

[TestClass]
public class StringExtensionTests
{
    [TestMethod]
    public void FromCodeWhenAfrikaansTest()
    {
        Assert.AreEqual(Language.Afrikaans, "af".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenAlbanianTest()
    {
        Assert.AreEqual(Language.Albanian, "sq".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenAmharicTest()
    {
        Assert.AreEqual(Language.Amharic, "am".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenArabicTest()
    {
        Assert.AreEqual(Language.Arabic, "ar".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenArmenianTest()
    {
        Assert.AreEqual(Language.Armenian, "hy".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenAzerbaijaniTest()
    {
        Assert.AreEqual(Language.Azerbaijani, "az".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenBasqueTest()
    {
        Assert.AreEqual(Language.Basque, "eu".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenBelarusianTest()
    {
        Assert.AreEqual(Language.Belarusian, "be".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenBengaliTest()
    {
        Assert.AreEqual(Language.Bengali, "bn".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenBosnianTest()
    {
        Assert.AreEqual(Language.Bosnian, "bs".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenBulgarianTest()
    {
        Assert.AreEqual(Language.Bulgarian, "bg".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenBurmeseTest()
    {
        Assert.AreEqual(Language.Burmese, "my".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenCatalanTest()
    {
        Assert.AreEqual(Language.Catalan, "ca".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenChineseTest()
    {
        Assert.AreEqual(Language.Chinese, "zh".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenChineseSimplifiedTest()
    {
        Assert.AreEqual(Language.ChineseSimplified, "zh-CN".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenChineseHongKongTest()
    {
        Assert.AreEqual(Language.ChineseHongKong, "zh-HK".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenChineseTraditionalTest()
    {
        Assert.AreEqual(Language.ChineseTraditional, "zh-TW".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenCroatianTest()
    {
        Assert.AreEqual(Language.Croatian, "hr".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenCzechTest()
    {
        Assert.AreEqual(Language.Czech, "cs".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenDanishTest()
    {
        Assert.AreEqual(Language.Danish, "da".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenDutchTest()
    {
        Assert.AreEqual(Language.Dutch, "nl".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenEnglishTest()
    {
        Assert.AreEqual(Language.English, "en".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenEnglishAustralianTest()
    {
        Assert.AreEqual(Language.EnglishAustralian, "en-AU".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenEnglishGreatBritainTest()
    {
        Assert.AreEqual(Language.EnglishGreatBritain, "en-GB".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenEstonianTest()
    {
        Assert.AreEqual(Language.Estonian, "et".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenFarsiTest()
    {
        Assert.AreEqual(Language.Farsi, "fa".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenFinnishTest()
    {
        Assert.AreEqual(Language.Finnish, "fi".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenFilipinoTest()
    {
        Assert.AreEqual(Language.Filipino, "fil".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenFrenchTest()
    {
        Assert.AreEqual(Language.French, "fr".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenFrenchCanadaTest()
    {
        Assert.AreEqual(Language.FrenchCanada, "fr-CA".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenGalicianTest()
    {
        Assert.AreEqual(Language.Galician, "gl".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenGeorgianTest()
    {
        Assert.AreEqual(Language.Georgian, "ka".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenGermanTest()
    {
        Assert.AreEqual(Language.German, "de".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenGreekTest()
    {
        Assert.AreEqual(Language.Greek, "el".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenGujaratiTest()
    {
        Assert.AreEqual(Language.Gujarati, "gu".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenHebrewTest()
    {
        Assert.AreEqual(Language.Hebrew, "iw".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenHindiTest()
    {
        Assert.AreEqual(Language.Hindi, "hi".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenHungarianTest()
    {
        Assert.AreEqual(Language.Hungarian, "hu".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenIcelandicTest()
    {
        Assert.AreEqual(Language.Icelandic, "is".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenIndonesianTest()
    {
        Assert.AreEqual(Language.Indonesian, "id".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenItalianTest()
    {
        Assert.AreEqual(Language.Italian, "it".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenJapaneseTest()
    {
        Assert.AreEqual(Language.Japanese, "ja".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenKannadaTest()
    {
        Assert.AreEqual(Language.Kannada, "kn".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenKazakhTest()
    {
        Assert.AreEqual(Language.Kazakh, "kk".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenKhmerTest()
    {
        Assert.AreEqual(Language.Khmer, "km".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenKoreanTest()
    {
        Assert.AreEqual(Language.Korean, "ko".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenKyrgyzTest()
    {
        Assert.AreEqual(Language.Kyrgyz, "ky".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenLaoTest()
    {
        Assert.AreEqual(Language.Lao, "lo".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenLatvianTest()
    {
        Assert.AreEqual(Language.Latvian, "lv".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenLithuanianTest()
    {
        Assert.AreEqual(Language.Lithuanian, "lt".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenMacedonianTest()
    {
        Assert.AreEqual(Language.Macedonian, "mk".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenMalayTest()
    {
        Assert.AreEqual(Language.Malay, "ms".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenMalayalamTest()
    {
        Assert.AreEqual(Language.Malayalam, "ml".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenMarathiTest()
    {
        Assert.AreEqual(Language.Marathi, "mr".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenMongolianTest()
    {
        Assert.AreEqual(Language.Mongolian, "mn".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenNepaliTest()
    {
        Assert.AreEqual(Language.Nepali, "ne".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenNorwegianTest()
    {
        Assert.AreEqual(Language.Norwegian, "no".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenPolishTest()
    {
        Assert.AreEqual(Language.Polish, "pl".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenPortugueseTest()
    {
        Assert.AreEqual(Language.Portuguese, "pt".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenPortugueseBrazilTest()
    {
        Assert.AreEqual(Language.PortugueseBrazil, "pt-BR".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenPortuguesePortugalTest()
    {
        Assert.AreEqual(Language.PortuguesePortugal, "pt-PT".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenPunjabiTest()
    {
        Assert.AreEqual(Language.Punjabi, "pa".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenRomanianTest()
    {
        Assert.AreEqual(Language.Romanian, "ro".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenRussianTest()
    {
        Assert.AreEqual(Language.Russian, "ru".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenSerbianTest()
    {
        Assert.AreEqual(Language.Serbian, "sr".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenSinhaleseTest()
    {
        Assert.AreEqual(Language.Sinhalese, "si".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenSlovakTest()
    {
        Assert.AreEqual(Language.Slovak, "sk".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenSlovenianTest()
    {
        Assert.AreEqual(Language.Slovenian, "sl".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenSpanishTest()
    {
        Assert.AreEqual(Language.Spanish, "es".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenSpanishLatinAmericaTest()
    {
        Assert.AreEqual(Language.SpanishLatinAmerica, "es-419".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenSwahiliTest()
    {
        Assert.AreEqual(Language.Swahili, "sw".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenSwedishTest()
    {
        Assert.AreEqual(Language.Swedish, "sv".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenTamilTest()
    {
        Assert.AreEqual(Language.Tamil, "ta".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenTeluguTest()
    {
        Assert.AreEqual(Language.Telugu, "te".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenThaiTest()
    {
        Assert.AreEqual(Language.Thai, "th".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenTurkishTest()
    {
        Assert.AreEqual(Language.Turkish, "tr".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenUkrainianTest()
    {
        Assert.AreEqual(Language.Ukrainian, "uk".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenUrduTest()
    {
        Assert.AreEqual(Language.Urdu, "ur".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenUzbekTest()
    {
        Assert.AreEqual(Language.Uzbek, "uz".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenVietnameseTest()
    {
        Assert.AreEqual(Language.Vietnamese, "vi".FromCode());
    }

    [TestMethod]
    public void FromCodeWhenZuluTest()
    {
        Assert.AreEqual(Language.Zulu, "zu".FromCode());
    }
}