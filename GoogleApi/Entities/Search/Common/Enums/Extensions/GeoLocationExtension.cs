﻿namespace GoogleApi.Entities.Search.Common.Enums.Extensions;

/// <summary>
/// Country Extension methods.
/// </summary>
public static class GeoLocationExtension
{
    /// <summary>
    /// Return the GeoLocation code.
    /// </summary>
    /// <param name="geoLocation">The <see cref="Country"/>.</param>
    /// <returns>The <see cref="string"/> representation of the <see cref="Country"/> as 'gl' request parameter.</returns>
    public static string ToGl(this GeoLocation geoLocation)
    {
        return geoLocation switch
        {
            GeoLocation.Afghanistan => "af",
            GeoLocation.Albania => "al",
            GeoLocation.Algeria => "dz",
            GeoLocation.AmericanSamoa => "as",
            GeoLocation.Andorra => "ad",
            GeoLocation.Angola => "ao",
            GeoLocation.Anguilla => "ai",
            GeoLocation.Antarctica => "aq",
            GeoLocation.AntiguaAndBarbuda => "ag",
            GeoLocation.Argentina => "ar",
            GeoLocation.Armenia => "am",
            GeoLocation.Aruba => "aw",
            GeoLocation.Australia => "au",
            GeoLocation.Austria => "at",
            GeoLocation.Azerbaijan => "az",
            GeoLocation.Bahamas => "bs",
            GeoLocation.Bahrain => "bh",
            GeoLocation.Bangladesh => "bd",
            GeoLocation.Barbados => "bb",
            GeoLocation.Belarus => "by",
            GeoLocation.Belgium => "be",
            GeoLocation.Belize => "bz",
            GeoLocation.Benin => "bj",
            GeoLocation.Bermuda => "bm",
            GeoLocation.Bhutan => "bt",
            GeoLocation.Bolivia => "bo",
            GeoLocation.BosniaAndHerzegovina => "ba",
            GeoLocation.Botswana => "bw",
            GeoLocation.BouvetIsland => "bv",
            GeoLocation.Brazil => "br",
            GeoLocation.BritishIndianOceanTerritory => "io",
            GeoLocation.BruneiDarussalam => "bn",
            GeoLocation.Bulgaria => "bg",
            GeoLocation.BurkinaFaso => "bf",
            GeoLocation.Burundi => "bi",
            GeoLocation.Cambodia => "kh",
            GeoLocation.Cameroon => "cm",
            GeoLocation.Canada => "ca",
            GeoLocation.CapeVerde => "cv",
            GeoLocation.CaymanIslands => "ky",
            GeoLocation.CentralAfricanRepublic => "cf",
            GeoLocation.Chad => "td",
            GeoLocation.Chile => "cl",
            GeoLocation.China => "cn",
            GeoLocation.ChristmasIsland => "cx",
            GeoLocation.CocosIslands => "cc",
            GeoLocation.Colombia => "co",
            GeoLocation.Comoros => "km",
            GeoLocation.Congo => "cg",
            GeoLocation.TheDemocraticRepublicOfCongo => "cd",
            GeoLocation.CookIslands => "ck",
            GeoLocation.CostaRica => "cr",
            GeoLocation.CoteDivoire => "ci",
            GeoLocation.Croatia => "hr",
            GeoLocation.Cuba => "cu",
            GeoLocation.Cyprus => "cy",
            GeoLocation.CzechRepublic => "cz",
            GeoLocation.Denmark => "dk",
            GeoLocation.Djibouti => "dj",
            GeoLocation.Dominica => "dm",
            GeoLocation.DominicanRepublic => "do",
            GeoLocation.EastTimor => "tp",
            GeoLocation.Ecuador => "ec",
            GeoLocation.Egypt => "eg",
            GeoLocation.ElSalvador => "sv",
            GeoLocation.EquatorialGuinea => "gq",
            GeoLocation.Eritrea => "er",
            GeoLocation.Estonia => "ee",
            GeoLocation.Ethiopia => "et",
            GeoLocation.EuropeanUnion => "en",
            GeoLocation.FalklandIslAndsMalvinas => "fk",
            GeoLocation.FaroeIslands => "fo",
            GeoLocation.Fiji => "fj",
            GeoLocation.Finland => "fi",
            GeoLocation.France => "fr",
            GeoLocation.FranceMetropolitan => "fr",
            GeoLocation.FrenchGuiana => "gf",
            GeoLocation.FrenchPolynesia => "pf",
            GeoLocation.FrenchSouthernTerritories => "tf",
            GeoLocation.Gabon => "ga",
            GeoLocation.Gambia => "gm",
            GeoLocation.Georgia => "ge",
            GeoLocation.Germany => "de",
            GeoLocation.Ghana => "gh",
            GeoLocation.Gibraltar => "gi",
            GeoLocation.Greece => "gr",
            GeoLocation.Greenland => "gl",
            GeoLocation.Grenada => "gd",
            GeoLocation.Guadeloupe => "gp",
            GeoLocation.Guam => "gu",
            GeoLocation.Guatemala => "gt",
            GeoLocation.Guinea => "gn",
            GeoLocation.GuineaBissau => "gw",
            GeoLocation.Guyana => "gy",
            GeoLocation.Haiti => "ht",
            GeoLocation.HeardIslandAndMcdonaldIslands => "hm",
            GeoLocation.VaticanCityState => "va",
            GeoLocation.Honduras => "hn",
            GeoLocation.HongKong => "hk",
            GeoLocation.Hungary => "hu",
            GeoLocation.Iceland => "is",
            GeoLocation.India => "in",
            GeoLocation.Indonesia => "id",
            GeoLocation.Iran => "ir",
            GeoLocation.Iraq => "iq",
            GeoLocation.Ireland => "ie",
            GeoLocation.Israel => "il",
            GeoLocation.Italy => "it",
            GeoLocation.Jamaica => "jm",
            GeoLocation.Japan => "jp",
            GeoLocation.Jordan => "jo",
            GeoLocation.Kazakhstan => "kz",
            GeoLocation.Kenya => "ke",
            GeoLocation.Kiribati => "ki",
            GeoLocation.DemocraticPeoplesRepublicOfKorea => "kp",
            GeoLocation.RepublicOfKorea => "kr",
            GeoLocation.Kuwait => "kw",
            GeoLocation.Kyrgyzstan => "kg",
            GeoLocation.LaoPeoplesDemocraticRepublic => "la",
            GeoLocation.Latvia => "lv",
            GeoLocation.Lebanon => "lb",
            GeoLocation.Lesotho => "ls",
            GeoLocation.Liberia => "lr",
            GeoLocation.LibyanArabJamahiriya => "ly",
            GeoLocation.Liechtenstein => "li",
            GeoLocation.Lithuania => "lt",
            GeoLocation.Luxembourg => "lu",
            GeoLocation.Macao => "mo",
            GeoLocation.Macedonia => "mk",
            GeoLocation.Madagascar => "mg",
            GeoLocation.Malawi => "mw",
            GeoLocation.Malaysia => "my",
            GeoLocation.Maldives => "mv",
            GeoLocation.Mali => "ml",
            GeoLocation.Malta => "mt",
            GeoLocation.MarshallIslands => "mh",
            GeoLocation.Martinique => "mq",
            GeoLocation.Mauritania => "mr",
            GeoLocation.Mauritius => "mu",
            GeoLocation.Mayotte => "yt",
            GeoLocation.Mexico => "mx",
            GeoLocation.Micronesia => "fm",
            GeoLocation.Moldova => "md",
            GeoLocation.Monaco => "mc",
            GeoLocation.Mongolia => "mn",
            GeoLocation.Montserrat => "ms",
            GeoLocation.Morocco => "ma",
            GeoLocation.Mozambique => "mz",
            GeoLocation.Myanmar => "mm",
            GeoLocation.Namibia => "na",
            GeoLocation.Nauru => "nr",
            GeoLocation.Nepal => "np",
            GeoLocation.Netherlands => "nl",
            GeoLocation.NetherlandsAntilles => "an",
            GeoLocation.NewCaledonia => "nc",
            GeoLocation.NewZealand => "nz",
            GeoLocation.Nicaragua => "ni",
            GeoLocation.Niger => "ne",
            GeoLocation.Nigeria => "ng",
            GeoLocation.Niue => "nu",
            GeoLocation.NorfolkIsland => "nf",
            GeoLocation.NorthernMarianaIslands => "mp",
            GeoLocation.Norway => "no",
            GeoLocation.Oman => "om",
            GeoLocation.Pakistan => "pk",
            GeoLocation.Palau => "pw",
            GeoLocation.PalestinianTerritory => "ps",
            GeoLocation.Panama => "pa",
            GeoLocation.PapuaNewGuinea => "pg",
            GeoLocation.Paraguay => "py",
            GeoLocation.Peru => "pe",
            GeoLocation.Philippines => "ph",
            GeoLocation.Pitcairn => "pn",
            GeoLocation.Poland => "pl",
            GeoLocation.Portugal => "pt",
            GeoLocation.PuertoRico => "pr",
            GeoLocation.Qatar => "qa",
            GeoLocation.Reunion => "re",
            GeoLocation.Romania => "ro",
            GeoLocation.RussianFederation => "ru",
            GeoLocation.Rwanda => "rw",
            GeoLocation.SaintHelena => "sh",
            GeoLocation.SaintKittsAndNevis => "kn",
            GeoLocation.SaintLucia => "lc",
            GeoLocation.SaintPierreAndMiquelon => "pm",
            GeoLocation.SaintVincentAndtheGrenadines => "vc",
            GeoLocation.Samoa => "ws",
            GeoLocation.SanMarino => "sm",
            GeoLocation.SaoTomeAndPrincipe => "st",
            GeoLocation.SaudiArabia => "sa",
            GeoLocation.Senegal => "sn",
            GeoLocation.SerbiaAndMontenegro => "cs",
            GeoLocation.Seychelles => "sc",
            GeoLocation.SierraLeone => "sl",
            GeoLocation.Singapore => "sg",
            GeoLocation.Slovakia => "sk",
            GeoLocation.Slovenia => "si",
            GeoLocation.SolomonIslands => "sb",
            GeoLocation.Somalia => "so",
            GeoLocation.SouthAfrica => "za",
            GeoLocation.SouthGeorgiaAndTheSouthSAndwichIslands => "gs",
            GeoLocation.Spain => "es",
            GeoLocation.SriLanka => "lk",
            GeoLocation.Sudan => "sd",
            GeoLocation.Suriname => "sr",
            GeoLocation.SvalbardAndJanMayen => "sj",
            GeoLocation.Swaziland => "sz",
            GeoLocation.Sweden => "se",
            GeoLocation.Switzerland => "ch",
            GeoLocation.SyrianArabRepublic => "sy",
            GeoLocation.Taiwan => "tw",
            GeoLocation.Tajikistan => "tj",
            GeoLocation.Tanzania => "tz",
            GeoLocation.Thailand => "th",
            GeoLocation.Togo => "tg",
            GeoLocation.Tokelau => "tk",
            GeoLocation.Tonga => "to",
            GeoLocation.TrinidadAndTobago => "tt",
            GeoLocation.Tunisia => "tn",
            GeoLocation.Turkey => "tr",
            GeoLocation.Turkmenistan => "tm",
            GeoLocation.TurksAndCaicosIslands => "tc",
            GeoLocation.Tuvalu => "tv",
            GeoLocation.Uganda => "ug",
            GeoLocation.Ukraine => "ua",
            GeoLocation.UnitedArabEmirates => "ae",
            GeoLocation.UnitedKingdom => "uk",
            GeoLocation.UnitedStates => "us",
            GeoLocation.UnitedStatesMinorOutlyingIslands => "um",
            GeoLocation.Uruguay => "uy",
            GeoLocation.Uzbekistan => "uz",
            GeoLocation.Vanuatu => "vu",
            GeoLocation.Venezuela => "ve",
            GeoLocation.Vietnam => "vn",
            GeoLocation.VirginIslandsBritish => "vg",
            GeoLocation.VirginIslandsUs => "vi",
            GeoLocation.WallisandFutuna => "wf",
            GeoLocation.WesternSahara => "eh",
            GeoLocation.Yemen => "ye",
            GeoLocation.Yugoslavia => "yo",
            GeoLocation.Zambia => "zm",
            GeoLocation.Zimbabwe => "zw",
            _ => string.Empty
        };
    }
}