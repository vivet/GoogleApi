using GoogleApi.Entities.Translate.Common.Enums;
using GoogleApi.Entities.Translate.Common.Enums.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoogleApi.UnitTests.Translate.Common.Extensions;

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
    public void ToCodeWhenAzeerbaijaniTest()
    {
        Assert.AreEqual("az", Language.Azeerbaijani.ToCode());
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
    public void ToCodeWhenCatalanTest()
    {
        Assert.AreEqual("ca", Language.Catalan.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenCebuanoTest()
    {
        Assert.AreEqual("ceb", Language.Cebuano.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenChichewaTest()
    {
        Assert.AreEqual("ny", Language.Chichewa.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenChinese_SimplifiedTest()
    {
        Assert.AreEqual("zh-CN", Language.Chinese_Simplified.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenChinese_TraditionalTest()
    {
        Assert.AreEqual("zh-TW", Language.Chinese_Traditional.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenCorsicanTest()
    {
        Assert.AreEqual("co", Language.Corsican.ToCode());
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
    public void ToCodeWhenEsperantoTest()
    {
        Assert.AreEqual("eo", Language.Esperanto.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenEstonianTest()
    {
        Assert.AreEqual("et", Language.Estonian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenFilipinoTest()
    {
        Assert.AreEqual("tl", Language.Filipino.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenFinnishTest()
    {
        Assert.AreEqual("fi", Language.Finnish.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenFrenchTest()
    {
        Assert.AreEqual("fr", Language.French.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenFrisianTest()
    {
        Assert.AreEqual("fy", Language.Frisian.ToCode());
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
    public void ToCodeWhenHaitian_CreoleTest()
    {
        Assert.AreEqual("ht", Language.Haitian_Creole.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenHausaTest()
    {
        Assert.AreEqual("ha", Language.Hausa.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenHawaiianTest()
    {
        Assert.AreEqual("haw", Language.Hawaiian.ToCode());
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
    public void ToCodeWhenHmongTest()
    {
        Assert.AreEqual("hmn", Language.Hmong.ToCode());
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
    public void ToCodeWhenIgboTest()
    {
        Assert.AreEqual("ig", Language.Igbo.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenIndonesianTest()
    {
        Assert.AreEqual("id", Language.Indonesian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenIrishTest()
    {
        Assert.AreEqual("ga", Language.Irish.ToCode());
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
    public void ToCodeWhenJavaneseTest()
    {
        Assert.AreEqual("jw", Language.Javanese.ToCode());
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
    public void ToCodeWhenKurdishTest()
    {
        Assert.AreEqual("ku", Language.Kurdish.ToCode());
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
    public void ToCodeWhenLatinTest()
    {
        Assert.AreEqual("la", Language.Latin.ToCode());
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
    public void ToCodeWhenLuxembourgishTest()
    {
        Assert.AreEqual("lb", Language.Luxembourgish.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenMacedonianTest()
    {
        Assert.AreEqual("mk", Language.Macedonian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenMalagasyTest()
    {
        Assert.AreEqual("mg", Language.Malagasy.ToCode());
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
    public void ToCodeWhenMalteseTest()
    {
        Assert.AreEqual("mt", Language.Maltese.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenMaoriTest()
    {
        Assert.AreEqual("mi", Language.Maori.ToCode());
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
    public void ToCodeWhenBurmeseTest()
    {
        Assert.AreEqual("my", Language.Burmese.ToCode());
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
    public void ToCodeWhenPashtoTest()
    {
        Assert.AreEqual("ps", Language.Pashto.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenPersianTest()
    {
        Assert.AreEqual("fa", Language.Persian.ToCode());
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
    public void ToCodeWhenPunjabiTest()
    {
        Assert.AreEqual("ma", Language.Punjabi.ToCode());
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
    public void ToCodeWhenSamoanTest()
    {
        Assert.AreEqual("sm", Language.Samoan.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenScots_GaelicTest()
    {
        Assert.AreEqual("gd", Language.Scots_Gaelic.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenSerbianTest()
    {
        Assert.AreEqual("sr", Language.Serbian.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenSesothoTest()
    {
        Assert.AreEqual("st", Language.Sesotho.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenShonaTest()
    {
        Assert.AreEqual("sn", Language.Shona.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenSindhiTest()
    {
        Assert.AreEqual("sd", Language.Sindhi.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenSinhalaTest()
    {
        Assert.AreEqual("si", Language.Sinhala.ToCode());
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
    public void ToCodeWhenSomaliTest()
    {
        Assert.AreEqual("so", Language.Somali.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenSpanishTest()
    {
        Assert.AreEqual("es", Language.Spanish.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenSundaneseTest()
    {
        Assert.AreEqual("su", Language.Sundanese.ToCode());
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
    public void ToCodeWhenTajikTest()
    {
        Assert.AreEqual("tg", Language.Tajik.ToCode());
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
    public void ToCodeWhenWelshTest()
    {
        Assert.AreEqual("cy", Language.Welsh.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenXhosaTest()
    {
        Assert.AreEqual("xh", Language.Xhosa.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenYiddishTest()
    {
        Assert.AreEqual("yi", Language.Yiddish.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenYorubaTest()
    {
        Assert.AreEqual("yo", Language.Yoruba.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenZuluTest()
    {
        Assert.AreEqual("zu", Language.Zulu.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenHebrewOldTest()
    {
        Assert.AreEqual("iw", Language.HebrewOld.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenKinyarwandaTest()
    {
        Assert.AreEqual("rw", Language.Kinyarwanda.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenOdiaTest()
    {
        Assert.AreEqual("or", Language.Odia.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenTatarTest()
    {
        Assert.AreEqual("tt", Language.Tatar.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenTurkmenTest()
    {
        Assert.AreEqual("tk", Language.Turkmen.ToCode());
    }

    [TestMethod]
    public void ToCodeWhenUyghurTest()
    {
        Assert.AreEqual("ug", Language.Uyghur.ToCode());
    }

    [TestMethod]
    public void IsValidNmtWhenAfrikaansTest()
    {
        Assert.IsTrue(Language.Afrikaans.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenAlbanianTest()
    {
        Assert.IsTrue(Language.Albanian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenAmharicTest()
    {
        Assert.IsTrue(Language.Amharic.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenArabicTest()
    {
        Assert.IsTrue(Language.Arabic.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenArmenianTest()
    {
        Assert.IsTrue(Language.Armenian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenAzeerbaijaniTest()
    {
        Assert.IsTrue(Language.Azeerbaijani.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenBasqueTest()
    {
        Assert.IsTrue(Language.Basque.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenBelarusianTest()
    {
        Assert.IsTrue(Language.Belarusian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenBengaliTest()
    {
        Assert.IsTrue(Language.Bengali.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenBosnianTest()
    {
        Assert.IsTrue(Language.Bosnian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenBulgarianTest()
    {
        Assert.IsTrue(Language.Bulgarian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenCatalanTest()
    {
        Assert.IsTrue(Language.Catalan.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenCebuanoTest()
    {
        Assert.IsTrue(Language.Cebuano.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenChichewaTest()
    {
        Assert.IsFalse(Language.Chichewa.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenChinese_SimplifiedTest()
    {
        Assert.IsTrue(Language.Chinese_Simplified.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenChinese_TraditionalTest()
    {
        Assert.IsTrue(Language.Chinese_Traditional.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenCorsicanTest()
    {
        Assert.IsTrue(Language.Corsican.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenCroatianTest()
    {
        Assert.IsTrue(Language.Croatian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenCzechTest()
    {
        Assert.IsTrue(Language.Czech.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenDanishTest()
    {
        Assert.IsTrue(Language.Danish.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenDutchTest()
    {
        Assert.IsTrue(Language.Dutch.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenEnglishTest()
    {
        Assert.IsTrue(Language.English.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenEsperantoTest()
    {
        Assert.IsTrue(Language.Esperanto.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenEstonianTest()
    {
        Assert.IsTrue(Language.Estonian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenFilipinoTest()
    {
        Assert.IsFalse(Language.Filipino.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenFinnishTest()
    {
        Assert.IsTrue(Language.Finnish.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenFrenchTest()
    {
        Assert.IsTrue(Language.French.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenFrisianTest()
    {
        Assert.IsTrue(Language.Frisian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenGalicianTest()
    {
        Assert.IsTrue(Language.Galician.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenGeorgianTest()
    {
        Assert.IsTrue(Language.Georgian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenGermanTest()
    {
        Assert.IsTrue(Language.German.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenGreekTest()
    {
        Assert.IsTrue(Language.Greek.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenGujaratiTest()
    {
        Assert.IsTrue(Language.Gujarati.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenHaitian_CreoleTest()
    {
        Assert.IsTrue(Language.Haitian_Creole.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenHausaTest()
    {
        Assert.IsTrue(Language.Hausa.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenHawaiianTest()
    {
        Assert.IsTrue(Language.Hawaiian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenHebrewTest()
    {
        Assert.IsTrue(Language.Hebrew.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenHebrewOldTest()
    {
        Assert.IsFalse(Language.HebrewOld.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenHindiTest()
    {
        Assert.IsTrue(Language.Hindi.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenHmongTest()
    {
        Assert.IsTrue(Language.Hmong.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenHungarianTest()
    {
        Assert.IsTrue(Language.Hungarian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenIcelandicTest()
    {
        Assert.IsTrue(Language.Icelandic.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenIgboTest()
    {
        Assert.IsTrue(Language.Igbo.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenIndonesianTest()
    {
        Assert.IsTrue(Language.Indonesian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenIrishTest()
    {
        Assert.IsTrue(Language.Irish.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenItalianTest()
    {
        Assert.IsTrue(Language.Italian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenJapaneseTest()
    {
        Assert.IsTrue(Language.Japanese.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenJavaneseTest()
    {
        Assert.IsTrue(Language.Javanese.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenKannadaTest()
    {
        Assert.IsTrue(Language.Kannada.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenKazakhTest()
    {
        Assert.IsTrue(Language.Kazakh.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenKhmerTest()
    {
        Assert.IsTrue(Language.Khmer.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenKoreanTest()
    {
        Assert.IsTrue(Language.Korean.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenKurdishTest()
    {
        Assert.IsTrue(Language.Kurdish.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenKyrgyzTest()
    {
        Assert.IsTrue(Language.Kyrgyz.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenLaoTest()
    {
        Assert.IsTrue(Language.Lao.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenLatinTest()
    {
        Assert.IsTrue(Language.Latin.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenLatvianTest()
    {
        Assert.IsTrue(Language.Latvian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenLithuanianTest()
    {
        Assert.IsTrue(Language.Lithuanian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenLuxembourgishTest()
    {
        Assert.IsTrue(Language.Luxembourgish.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenMacedonianTest()
    {
        Assert.IsTrue(Language.Macedonian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenMalagasyTest()
    {
        Assert.IsTrue(Language.Malagasy.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenMalayTest()
    {
        Assert.IsTrue(Language.Malay.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenMalayalamTest()
    {
        Assert.IsTrue(Language.Malayalam.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenMalteseTest()
    {
        Assert.IsTrue(Language.Maltese.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenMaoriTest()
    {
        Assert.IsTrue(Language.Maori.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenMarathiTest()
    {
        Assert.IsTrue(Language.Marathi.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenMongolianTest()
    {
        Assert.IsTrue(Language.Mongolian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenBurmeseTest()
    {
        Assert.IsTrue(Language.Burmese.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenNepaliTest()
    {
        Assert.IsTrue(Language.Nepali.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenNorwegianTest()
    {
        Assert.IsTrue(Language.Norwegian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenPashtoTest()
    {
        Assert.IsTrue(Language.Pashto.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenPersianTest()
    {
        Assert.IsTrue(Language.Persian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenPolishTest()
    {
        Assert.IsTrue(Language.Polish.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenPortugueseTest()
    {
        Assert.IsTrue(Language.Portuguese.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenPunjabiTest()
    {
        Assert.IsTrue(Language.Punjabi.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenRomanianTest()
    {
        Assert.IsTrue(Language.Romanian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenRussianTest()
    {
        Assert.IsTrue(Language.Russian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenSamoanTest()
    {
        Assert.IsTrue(Language.Samoan.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenScots_GaelicTest()
    {
        Assert.IsTrue(Language.Scots_Gaelic.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenSerbianTest()
    {
        Assert.IsTrue(Language.Serbian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenSesothoTest()
    {
        Assert.IsTrue(Language.Sesotho.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenShonaTest()
    {
        Assert.IsTrue(Language.Shona.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenSindhiTest()
    {
        Assert.IsTrue(Language.Sindhi.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenSinhalaTest()
    {
        Assert.IsTrue(Language.Sinhala.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenSlovakTest()
    {
        Assert.IsTrue(Language.Slovak.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenSlovenianTest()
    {
        Assert.IsTrue(Language.Slovenian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenSomaliTest()
    {
        Assert.IsTrue(Language.Somali.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenSpanishTest()
    {
        Assert.IsTrue(Language.Spanish.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenSundaneseTest()
    {
        Assert.IsTrue(Language.Sundanese.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenSwahiliTest()
    {
        Assert.IsTrue(Language.Swahili.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenSwedishTest()
    {
        Assert.IsTrue(Language.Swedish.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenTajikTest()
    {
        Assert.IsTrue(Language.Tajik.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenTamilTest()
    {
        Assert.IsTrue(Language.Tamil.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenTeluguTest()
    {
        Assert.IsTrue(Language.Telugu.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenThaiTest()
    {
        Assert.IsTrue(Language.Thai.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenTurkishTest()
    {
        Assert.IsTrue(Language.Turkish.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenUkrainianTest()
    {
        Assert.IsTrue(Language.Ukrainian.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenUrduTest()
    {
        Assert.IsTrue(Language.Urdu.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenUzbekTest()
    {
        Assert.IsTrue(Language.Uzbek.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenVietnameseTest()
    {
        Assert.IsTrue(Language.Vietnamese.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenWelshTest()
    {
        Assert.IsTrue(Language.Welsh.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenXhosaTest()
    {
        Assert.IsTrue(Language.Xhosa.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenYiddishTest()
    {
        Assert.IsTrue(Language.Yiddish.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenYorubaTest()
    {
        Assert.IsTrue(Language.Yoruba.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenZuluTest()
    {
        Assert.IsTrue(Language.Zulu.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenKinyarwandaTest()
    {
        Assert.IsTrue(Language.Kinyarwanda.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenOdiaTest()
    {
        Assert.IsTrue(Language.Odia.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenTatarTest()
    {
        Assert.IsTrue(Language.Tatar.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenTurkmenTest()
    {
        Assert.IsTrue(Language.Turkmen.IsValidNmt());
    }

    [TestMethod]
    public void IsValidNmtWhenUyghurTest()
    {
        Assert.IsTrue(Language.Uyghur.IsValidNmt());
    }
}