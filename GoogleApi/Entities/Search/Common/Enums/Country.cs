using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Common.Converters;

namespace GoogleApi.Entities.Search.Common.Enums;

/// <summary>
/// Country.
/// </summary>
[JsonConverter(typeof(EnumConverter<Country>))]
public enum Country
{
    /// <summary>
    /// Afghanistan
    /// </summary>
    [EnumMember(Value = "countryAF")]
    Afghanistan,

    /// <summary>
    /// Albania
    /// </summary>
    [EnumMember(Value = "countryAL")]
    Albania,

    /// <summary>
    /// Algeria
    /// </summary>
    [EnumMember(Value = "countryDZ")]
    Algeria,

    /// <summary>
    /// American Samoa
    /// </summary>
    [EnumMember(Value = "countryAS")]
    AmericanSamoa,

    /// <summary>
    /// Andorra
    /// </summary>
    [EnumMember(Value = "countryAD")]
    Andorra,

    /// <summary>
    /// Angola
    /// </summary>
    [EnumMember(Value = "countryAO")]
    Angola,

    /// <summary>
    /// Anguilla
    /// </summary>
    [EnumMember(Value = "countryAI")]
    Anguilla,

    /// <summary>
    /// Antarctica
    /// </summary>
    [EnumMember(Value = "countryAQ")]
    Antarctica,

    /// <summary>
    /// Antigua and Barbuda
    /// </summary>
    [EnumMember(Value = "countryAG")]
    AntiguaAndBarbuda,

    /// <summary>
    /// Argentina
    /// </summary>
    [EnumMember(Value = "countryAR")]
    Argentina,

    /// <summary>
    /// Armenia
    /// </summary>
    [EnumMember(Value = "countryAM")]
    Armenia,

    /// <summary>
    /// Aruba
    /// </summary>
    [EnumMember(Value = "countryAW")]
    Aruba,

    /// <summary>
    /// Australia
    /// </summary>
    [EnumMember(Value = "countryAU")]
    Australia,

    /// <summary>
    /// Austria
    /// </summary>
    [EnumMember(Value = "countryAT")]
    Austria,

    /// <summary>
    /// Azerbaijan
    /// </summary>
    [EnumMember(Value = "countryAZ")]
    Azerbaijan,

    /// <summary>
    /// Bahamas
    /// </summary>
    [EnumMember(Value = "countryBS")]
    Bahamas,

    /// <summary>
    /// Bahrain
    /// </summary>
    [EnumMember(Value = "countryBH")]
    Bahrain,

    /// <summary>
    /// Bangladesh
    /// </summary>
    [EnumMember(Value = "countryBD")]
    Bangladesh,

    /// <summary>
    /// Barbados
    /// </summary>
    [EnumMember(Value = "countryBB")]
    Barbados,

    /// <summary>
    /// Belarus
    /// </summary>
    [EnumMember(Value = "countryBY")]
    Belarus,

    /// <summary>
    /// Belgium
    /// </summary>
    [EnumMember(Value = "countryBE")]
    Belgium,

    /// <summary>
    /// Belize
    /// </summary>
    [EnumMember(Value = "countryBZ")]
    Belize,

    /// <summary>
    /// Benin
    /// </summary>
    [EnumMember(Value = "countryBJ")]
    Benin,

    /// <summary>
    /// Bermuda
    /// </summary>
    [EnumMember(Value = "countryBM")]
    Bermuda,

    /// <summary>
    /// Bhutan
    /// </summary>
    [EnumMember(Value = "countryBT")]
    Bhutan,

    /// <summary>
    /// Bolivia
    /// </summary>
    [EnumMember(Value = "countryBO")]
    Bolivia,

    /// <summary>
    /// Bosnia and Herzegovina
    /// </summary>
    [EnumMember(Value = "countryBA")]
    BosniaAndHerzegovina,

    /// <summary>
    /// Botswana
    /// </summary>
    [EnumMember(Value = "countryBW")]
    Botswana,

    /// <summary>
    /// Bouvet Island
    /// </summary>
    [EnumMember(Value = "countryBV")]
    BouvetIsland,

    /// <summary>
    /// Brazil
    /// </summary>
    [EnumMember(Value = "countryBR")]
    Brazil,

    /// <summary>
    /// British Indian Ocean Territory
    /// </summary>
    [EnumMember(Value = "countryIO")]
    BritishIndianOceanTerritory,

    /// <summary>
    /// Brunei Darussalam
    /// </summary>
    [EnumMember(Value = "countryBN")]
    BruneiDarussalam,

    /// <summary>
    /// Bulgaria
    /// </summary>
    [EnumMember(Value = "countryBG")]
    Bulgaria,

    /// <summary>
    /// Burkina Faso
    /// </summary>
    [EnumMember(Value = "countryBF")]
    BurkinaFaso,

    /// <summary>
    /// Burundi
    /// </summary>
    [EnumMember(Value = "countryBI")]
    Burundi,

    /// <summary>
    /// Cambodia
    /// </summary>
    [EnumMember(Value = "countryKH")]
    Cambodia,

    /// <summary>
    /// Cameroon
    /// </summary>
    [EnumMember(Value = "countryCM")]
    Cameroon,

    /// <summary>
    /// Canada
    /// </summary>
    [EnumMember(Value = "countryCA")]
    Canada,

    /// <summary>
    /// Cape Verde
    /// </summary>
    [EnumMember(Value = "countryCV")]
    CapeVerde,

    /// <summary>
    /// Cayman Islands
    /// </summary>
    [EnumMember(Value = "countryKY")]
    CaymanIslands,

    /// <summary>
    /// Central African Republic
    /// </summary>
    [EnumMember(Value = "countryCF")]
    CentralAfricanRepublic,

    /// <summary>
    /// Chad
    /// </summary>
    [EnumMember(Value = "countryTD")]
    Chad,

    /// <summary>
    /// Chile
    /// </summary>
    [EnumMember(Value = "countryCL")]
    Chile,

    /// <summary>
    /// China
    /// </summary>
    [EnumMember(Value = "countryCN")]
    China,

    /// <summary>
    /// Christmas Island
    /// </summary>
    [EnumMember(Value = "countryCX")]
    ChristmasIsland,

    /// <summary>
    /// Cocos (Keeling) Islands
    /// </summary>
    [EnumMember(Value = "countryCC")]
    CocosIslands,

    /// <summary>
    /// Colombia
    /// </summary>
    [EnumMember(Value = "countryCO")]
    Colombia,

    /// <summary>
    /// Comoros
    /// </summary>
    [EnumMember(Value = "countryKM")]
    Comoros,

    /// <summary>
    /// Congo
    /// </summary>
    [EnumMember(Value = "countryCG")]
    Congo,

    /// <summary>
    /// Congo, the Democratic Republic of the
    /// </summary>
    [EnumMember(Value = "countryCD")]
    TheDemocraticRepublicOfCongo,

    /// <summary>
    /// Cook Islands
    /// </summary>
    [EnumMember(Value = "countryCK")]
    CookIslands,

    /// <summary>
    /// Costa Rica
    /// </summary>
    [EnumMember(Value = "countryCR")]
    CostaRica,

    /// <summary>
    /// Cote D'ivoire
    /// </summary>
    [EnumMember(Value = "countryCI")]
    CoteDivoire,

    /// <summary>
    /// Croatia (Hrvatska)
    /// </summary>
    [EnumMember(Value = "countryHR")]
    Croatia,

    /// <summary>
    /// Cuba
    /// </summary>
    [EnumMember(Value = "countryCU")]
    Cuba,

    /// <summary>
    /// Cyprus
    /// </summary>
    [EnumMember(Value = "countryCY")]
    Cyprus,

    /// <summary>
    /// Czech Republic
    /// </summary>
    [EnumMember(Value = "countryCZ")]
    CzechRepublic,

    /// <summary>
    /// Denmark
    /// </summary>
    [EnumMember(Value = "countryDK")]
    Denmark,

    /// <summary>
    /// Djibouti
    /// </summary>
    [EnumMember(Value = "countryDJ")]
    Djibouti,

    /// <summary>
    /// Dominica
    /// </summary>
    [EnumMember(Value = "countryDM")]
    Dominica,

    /// <summary>
    /// Dominican Republic
    /// </summary>
    [EnumMember(Value = "countryDO")]
    DominicanRepublic,

    /// <summary>
    /// East Timor
    /// </summary>
    [EnumMember(Value = "countryTP")]
    EastTimor,

    /// <summary>
    /// Ecuador
    /// </summary>
    [EnumMember(Value = "countryEC")]
    Ecuador,

    /// <summary>
    /// Egypt
    /// </summary>
    [EnumMember(Value = "countryEG")]
    Egypt,

    /// <summary>
    /// El Salvador
    /// </summary>
    [EnumMember(Value = "countrySV")]
    ElSalvador,

    /// <summary>
    /// Equatorial Guinea
    /// </summary>
    [EnumMember(Value = "countryGQ")]
    EquatorialGuinea,

    /// <summary>
    /// Eritrea
    /// </summary>
    [EnumMember(Value = "countryER")]
    Eritrea,

    /// <summary>
    /// Estonia
    /// </summary>
    [EnumMember(Value = "countryEE")]
    Estonia,

    /// <summary>
    /// Ethiopia
    /// </summary>
    [EnumMember(Value = "countryET")]
    Ethiopia,

    /// <summary>
    /// European Union
    /// </summary>
    [EnumMember(Value = "countryEU")]
    EuropeanUnion,

    /// <summary>
    /// Falkland Islands (Malvinas)
    /// </summary>
    [EnumMember(Value = "countryFK")]
    FalklandIslAndsMalvinas,

    /// <summary>
    /// Faroe Islands
    /// </summary>
    [EnumMember(Value = "countryFO")]
    FaroeIslands,

    /// <summary>
    /// Fiji
    /// </summary>
    [EnumMember(Value = "countryFJ")]
    Fiji,

    /// <summary>
    /// Finland
    /// </summary>
    [EnumMember(Value = "countryFI")]
    Finland,

    /// <summary>
    /// France
    /// </summary>
    [EnumMember(Value = "countryFR")]
    France,

    /// <summary>
    /// France, Metropolitan
    /// </summary>
    [EnumMember(Value = "countryFX")]
    FranceMetropolitan,

    /// <summary>
    /// French Guiana
    /// </summary>
    [EnumMember(Value = "countryGF")]
    FrenchGuiana,

    /// <summary>
    /// French Polynesia
    /// </summary>
    [EnumMember(Value = "countryPF")]
    FrenchPolynesia,

    /// <summary>
    /// French Southern Territories
    /// </summary>
    [EnumMember(Value = "countryTF")]
    FrenchSouthernTerritories,

    /// <summary>
    /// Gabon
    /// </summary>
    [EnumMember(Value = "countryGA")]
    Gabon,

    /// <summary>
    /// Gambia
    /// </summary>
    [EnumMember(Value = "countryGM")]
    Gambia,

    /// <summary>
    /// Georgia
    /// </summary>
    [EnumMember(Value = "countryGE")]
    Georgia,

    /// <summary>
    /// Germany
    /// </summary>
    [EnumMember(Value = "countryDE")]
    Germany,

    /// <summary>
    /// Ghana
    /// </summary>
    [EnumMember(Value = "countryGH")]
    Ghana,

    /// <summary>
    /// Gibraltar
    /// </summary>
    [EnumMember(Value = "countryGI")]
    Gibraltar,

    /// <summary>
    /// Greece
    /// </summary>
    [EnumMember(Value = "countryGR")]
    Greece,

    /// <summary>
    /// Greenland
    /// </summary>
    [EnumMember(Value = "countryGL")]
    Greenland,

    /// <summary>
    /// Grenada
    /// </summary>
    [EnumMember(Value = "countryGD")]
    Grenada,

    /// <summary>
    /// Guadeloupe
    /// </summary>
    [EnumMember(Value = "countryGP")]
    Guadeloupe,

    /// <summary>
    /// Guam
    /// </summary>
    [EnumMember(Value = "countryGU")]
    Guam,

    /// <summary>
    /// Guatemala
    /// </summary>
    [EnumMember(Value = "countryGT")]
    Guatemala,

    /// <summary>
    /// Guinea
    /// </summary>
    [EnumMember(Value = "countryGN")]
    Guinea,

    /// <summary>
    /// Guinea-Bissau
    /// </summary>
    [EnumMember(Value = "countryGW")]
    GuineaBissau,

    /// <summary>
    /// Guyana
    /// </summary>
    [EnumMember(Value = "countryGY")]
    Guyana,

    /// <summary>
    /// Haiti
    /// </summary>
    [EnumMember(Value = "countryHT")]
    Haiti,

    /// <summary>
    /// Heard Island and Mcdonald Islands
    /// </summary>
    [EnumMember(Value = "countryHM")]
    HeardIslandAndMcdonaldIslands,

    /// <summary>
    /// Holy See (Vatican City State)
    /// </summary>
    [EnumMember(Value = "countryVA")]
    VaticanCityState,

    /// <summary>
    /// Honduras
    /// </summary>
    [EnumMember(Value = "countryHN")]
    Honduras,

    /// <summary>
    /// Hong Kong
    /// </summary>
    [EnumMember(Value = "countryHK")]
    HongKong,

    /// <summary>
    /// Hungary
    /// </summary>
    [EnumMember(Value = "countryHU")]
    Hungary,

    /// <summary>
    /// Iceland
    /// </summary>
    [EnumMember(Value = "countryIS")]
    Iceland,

    /// <summary>
    /// India
    /// </summary>
    [EnumMember(Value = "countryIN")]
    India,

    /// <summary>
    /// Indonesia
    /// </summary>
    [EnumMember(Value = "countryID")]
    Indonesia,

    /// <summary>
    /// Iran, Islamic Republic of
    /// </summary>
    [EnumMember(Value = "countryIR")]
    Iran,

    /// <summary>
    /// Iraq
    /// </summary>
    [EnumMember(Value = "countryIQ")]
    Iraq,

    /// <summary>
    /// Ireland
    /// </summary>
    [EnumMember(Value = "countryIE")]
    Ireland,

    /// <summary>
    /// Israel
    /// </summary>
    [EnumMember(Value = "countryIL")]
    Israel,

    /// <summary>
    /// Italy
    /// </summary>
    [EnumMember(Value = "countryIT")]
    Italy,

    /// <summary>
    /// Jamaica
    /// </summary>
    [EnumMember(Value = "countryJM")]
    Jamaica,

    /// <summary>
    /// Japan
    /// </summary>
    [EnumMember(Value = "countryJP")]
    Japan,

    /// <summary>
    /// Jordan
    /// </summary>
    [EnumMember(Value = "countryJO")]
    Jordan,

    /// <summary>
    /// Kazakhstan
    /// </summary>
    [EnumMember(Value = "countryKZ")]
    Kazakhstan,

    /// <summary>
    /// Kenya
    /// </summary>
    [EnumMember(Value = "countryKE")]
    Kenya,

    /// <summary>
    /// Kiribati
    /// </summary>
    [EnumMember(Value = "countryKI")]
    Kiribati,

    /// <summary>
    /// Korea, Democratic People's Republic of
    /// </summary>
    [EnumMember(Value = "countryKP")]
    DemocraticPeoplesRepublicOfKorea,

    /// <summary>
    /// Korea, Republic of
    /// </summary>
    [EnumMember(Value = "countryKR")]
    RepublicOfKorea,

    /// <summary>
    /// Kuwait
    /// </summary>
    [EnumMember(Value = "countryKW")]
    Kuwait,

    /// <summary>
    /// Kyrgyzstan
    /// </summary>
    [EnumMember(Value = "countryKG")]
    Kyrgyzstan,

    /// <summary>
    /// Lao People's Democratic Republic
    /// </summary>
    [EnumMember(Value = "countryLA")]
    LaoPeoplesDemocraticRepublic,

    /// <summary>
    /// Latvia
    /// </summary>
    [EnumMember(Value = "countryLV")]
    Latvia,

    /// <summary>
    /// Lebanon
    /// </summary>
    [EnumMember(Value = "countryLB")]
    Lebanon,

    /// <summary>
    /// Lesotho
    /// </summary>
    [EnumMember(Value = "countryLS")]
    Lesotho,

    /// <summary>
    /// Liberia
    /// </summary>
    [EnumMember(Value = "countryLR")]
    Liberia,

    /// <summary>
    /// Libyan Arab Jamahiriya
    /// </summary>
    [EnumMember(Value = "countryLY")]
    LibyanArabJamahiriya,

    /// <summary>
    /// Liechtenstein
    /// </summary>
    [EnumMember(Value = "countryLI")]
    Liechtenstein,

    /// <summary>
    /// Lithuania
    /// </summary>
    [EnumMember(Value = "countryLT")]
    Lithuania,

    /// <summary>
    /// Luxembourg
    /// </summary>
    [EnumMember(Value = "countryLU")]
    Luxembourg,

    /// <summary>
    /// Macao
    /// </summary>
    [EnumMember(Value = "countryMO")]
    Macao,

    /// <summary>
    /// Macedonia, the Former Yugosalv Republic of
    /// </summary>
    [EnumMember(Value = "countryMK")]
    Macedonia,

    /// <summary>
    /// Madagascar
    /// </summary>
    [EnumMember(Value = "countryMG")]
    Madagascar,

    /// <summary>
    /// Malawi
    /// </summary>
    [EnumMember(Value = "countryMW")]
    Malawi,

    /// <summary>
    /// Malaysia
    /// </summary>
    [EnumMember(Value = "countryMY")]
    Malaysia,

    /// <summary>
    /// Maldives
    /// </summary>
    [EnumMember(Value = "countryMV")]
    Maldives,

    /// <summary>
    /// Mali
    /// </summary>
    [EnumMember(Value = "countryML")]
    Mali,

    /// <summary>
    /// Malta
    /// </summary>
    [EnumMember(Value = "countryMT")]
    Malta,

    /// <summary>
    /// Marshall Islands
    /// </summary>
    [EnumMember(Value = "countryMH")]
    MarshallIslands,

    /// <summary>
    /// Martinique
    /// </summary>
    [EnumMember(Value = "countryMQ")]
    Martinique,

    /// <summary>
    /// Mauritania
    /// </summary>
    [EnumMember(Value = "countryMR")]
    Mauritania,

    /// <summary>
    /// Mauritius
    /// </summary>
    [EnumMember(Value = "countryMU")]
    Mauritius,

    /// <summary>
    /// Mayotte
    /// </summary>
    [EnumMember(Value = "countryYT")]
    Mayotte,

    /// <summary>
    /// Mexico
    /// </summary>
    [EnumMember(Value = "countryMX")]
    Mexico,

    /// <summary>
    /// Micronesia, Federated States of
    /// </summary>
    [EnumMember(Value = "countryFM")]
    Micronesia,

    /// <summary>
    /// Moldova, Republic of
    /// </summary>
    [EnumMember(Value = "countryMD")]
    Moldova,

    /// <summary>
    /// Monaco
    /// </summary>
    [EnumMember(Value = "countryMC")]
    Monaco,

    /// <summary>
    /// Mongolia
    /// </summary>
    [EnumMember(Value = "countryMN")]
    Mongolia,

    /// <summary>
    /// Montserrat
    /// </summary>
    [EnumMember(Value = "countryMS")]
    Montserrat,

    /// <summary>
    /// Morocco
    /// </summary>
    [EnumMember(Value = "countryMA")]
    Morocco,

    /// <summary>
    /// Mozambique
    /// </summary>
    [EnumMember(Value = "countryMZ")]
    Mozambique,

    /// <summary>
    /// Myanmar
    /// </summary>
    [EnumMember(Value = "countryMM")]
    Myanmar,

    /// <summary>
    /// Namibia
    /// </summary>
    [EnumMember(Value = "countryNA")]
    Namibia,

    /// <summary>
    /// Nauru
    /// </summary>
    [EnumMember(Value = "countryNR")]
    Nauru,

    /// <summary>
    /// Nepal
    /// </summary>
    [EnumMember(Value = "countryNP")]
    Nepal,

    /// <summary>
    /// Netherlands
    /// </summary>
    [EnumMember(Value = "countryNL")]
    Netherlands,

    /// <summary>
    /// Netherlands Antilles
    /// </summary>
    [EnumMember(Value = "countryAN")]
    NetherlandsAntilles,

    /// <summary>
    /// New Caledonia
    /// </summary>
    [EnumMember(Value = "countryNC")]
    NewCaledonia,

    /// <summary>
    /// New Zealand
    /// </summary>
    [EnumMember(Value = "countryNZ")]
    NewZealand,

    /// <summary>
    /// Nicaragua
    /// </summary>
    [EnumMember(Value = "countryNI")]
    Nicaragua,

    /// <summary>
    /// Niger
    /// </summary>
    [EnumMember(Value = "countryNE")]
    Niger,

    /// <summary>
    /// Nigeria
    /// </summary>
    [EnumMember(Value = "countryNG")]
    Nigeria,

    /// <summary>
    /// Niue
    /// </summary>
    [EnumMember(Value = "countryNU")]
    Niue,

    /// <summary>
    /// Norfolk Island
    /// </summary>
    [EnumMember(Value = "countryNF")]
    NorfolkIsland,

    /// <summary>
    /// Northern Mariana Islands
    /// </summary>
    [EnumMember(Value = "countryMP")]
    NorthernMarianaIslands,

    /// <summary>
    /// Norway
    /// </summary>
    [EnumMember(Value = "countryNO")]
    Norway,

    /// <summary>
    /// Oman
    /// </summary>
    [EnumMember(Value = "countryOM")]
    Oman,

    /// <summary>
    /// Pakistan
    /// </summary>
    [EnumMember(Value = "countryPK")]
    Pakistan,

    /// <summary>
    /// Palau
    /// </summary>
    [EnumMember(Value = "countryPW")]
    Palau,

    /// <summary>
    /// Palestinian Territory
    /// </summary>
    [EnumMember(Value = "countryPS")]
    PalestinianTerritory,

    /// <summary>
    /// Panama
    /// </summary>
    [EnumMember(Value = "countryPA")]
    Panama,

    /// <summary>
    /// Papua New Guinea
    /// </summary>
    [EnumMember(Value = "countryPG")]
    PapuaNewGuinea,

    /// <summary>
    /// Paraguay
    /// </summary>
    [EnumMember(Value = "countryPY")]
    Paraguay,

    /// <summary>
    /// Peru
    /// </summary>
    [EnumMember(Value = "countryPE")]
    Peru,

    /// <summary>
    /// Philippines
    /// </summary>
    [EnumMember(Value = "countryPH")]
    Philippines,

    /// <summary>
    /// Pitcairn
    /// </summary>
    [EnumMember(Value = "countryPN")]
    Pitcairn,

    /// <summary>
    /// Poland
    /// </summary>
    [EnumMember(Value = "countryPL")]
    Poland,

    /// <summary>
    /// Portugal
    /// </summary>
    [EnumMember(Value = "countryPT")]
    Portugal,

    /// <summary>
    /// Puerto Rico
    /// </summary>
    [EnumMember(Value = "countryPR")]
    PuertoRico,

    /// <summary>
    /// Qatar
    /// </summary>
    [EnumMember(Value = "countryQA")]
    Qatar,

    /// <summary>
    /// Reunion
    /// </summary>
    [EnumMember(Value = "countryRE")]
    Reunion,

    /// <summary>
    /// Romania
    /// </summary>
    [EnumMember(Value = "countryRO")]
    Romania,

    /// <summary>
    /// Russian Federation
    /// </summary>
    [EnumMember(Value = "countryRU")]
    RussianFederation,

    /// <summary>
    /// Rwanda
    /// </summary>
    [EnumMember(Value = "countryRW")]
    Rwanda,

    /// <summary>
    /// Saint Helena
    /// </summary>
    [EnumMember(Value = "countrySH")]
    SaintHelena,

    /// <summary>
    /// Saint Kitts and Nevis
    /// </summary>
    [EnumMember(Value = "countryKN")]
    SaintKittsAndNevis,

    /// <summary>
    /// Saint Lucia
    /// </summary>
    [EnumMember(Value = "countryLC")]
    SaintLucia,

    /// <summary>
    /// Saint Pierre and Miquelon
    /// </summary>
    [EnumMember(Value = "countryPM")]
    SaintPierreAndMiquelon,

    /// <summary>
    /// Saint Vincent and the Grenadines
    /// </summary>
    [EnumMember(Value = "countryVC")]
    SaintVincentAndtheGrenadines,

    /// <summary>
    /// Samoa
    /// </summary>
    [EnumMember(Value = "countryWS")]
    Samoa,

    /// <summary>
    /// San Marino
    /// </summary>
    [EnumMember(Value = "countrySM")]
    SanMarino,

    /// <summary>
    /// Sao Tome and Principe
    /// </summary>
    [EnumMember(Value = "countryST")]
    SaoTomeAndPrincipe,

    /// <summary>
    /// Saudi Arabia
    /// </summary>
    [EnumMember(Value = "countrySA")]
    SaudiArabia,

    /// <summary>
    /// Senegal
    /// </summary>
    [EnumMember(Value = "countrySN")]
    Senegal,

    /// <summary>
    /// Serbia and Montenegro
    /// </summary>
    [EnumMember(Value = "countryCS")]
    SerbiaAndMontenegro,

    /// <summary>
    /// Seychelles
    /// </summary>
    [EnumMember(Value = "countrySC")]
    Seychelles,

    /// <summary>
    /// Sierra Leone
    /// </summary>
    [EnumMember(Value = "countrySL")]
    SierraLeone,

    /// <summary>
    /// Singapore
    /// </summary>
    [EnumMember(Value = "countrySG")]
    Singapore,

    /// <summary>
    /// Slovakia
    /// </summary>
    [EnumMember(Value = "countrySK")]
    Slovakia,

    /// <summary>
    /// Slovenia
    /// </summary>
    [EnumMember(Value = "countrySI")]
    Slovenia,

    /// <summary>
    /// Solomon Islands
    /// </summary>
    [EnumMember(Value = "countrySB")]
    SolomonIslands,

    /// <summary>
    /// Somalia
    /// </summary>
    [EnumMember(Value = "countrySO")]
    Somalia,

    /// <summary>
    /// South Africa
    /// </summary>
    [EnumMember(Value = "countryZA")]
    SouthAfrica,

    /// <summary>
    /// South Georgia and the South Sandwich Islands
    /// </summary>
    [EnumMember(Value = "countryGS")]
    SouthGeorgiaAndTheSouthSAndwichIslands,

    /// <summary>
    /// Spain
    /// </summary>
    [EnumMember(Value = "countryES")]
    Spain,

    /// <summary>
    /// Sri Lanka
    /// </summary>
    [EnumMember(Value = "countryLK")]
    SriLanka,

    /// <summary>
    /// Sudan
    /// </summary>
    [EnumMember(Value = "countrySD")]
    Sudan,

    /// <summary>
    /// Suriname
    /// </summary>
    [EnumMember(Value = "countrySR")]
    Suriname,

    /// <summary>
    /// Svalbard and Jan Mayen
    /// </summary>
    [EnumMember(Value = "countrySJ")]
    SvalbardAndJanMayen,

    /// <summary>
    /// Swaziland
    /// </summary>
    [EnumMember(Value = "countrySZ")]
    Swaziland,

    /// <summary>
    /// Sweden
    /// </summary>
    [EnumMember(Value = "countrySE")]
    Sweden,

    /// <summary>
    /// Switzerland
    /// </summary>
    [EnumMember(Value = "countryCH")]
    Switzerland,

    /// <summary>
    /// Syrian Arab Republic
    /// </summary>
    [EnumMember(Value = "countrySY")]
    SyrianArabRepublic,

    /// <summary>
    /// Taiwan, Province of China
    /// </summary>
    [EnumMember(Value = "countryTW")]
    Taiwan,

    /// <summary>
    /// Tajikistan
    /// </summary>
    [EnumMember(Value = "countryTJ")]
    Tajikistan,

    /// <summary>
    /// Tanzania, United Republic of
    /// </summary>
    [EnumMember(Value = "countryTZ")]
    Tanzania,

    /// <summary>
    /// Thailand
    /// </summary>
    [EnumMember(Value = "countryTH")]
    Thailand,

    /// <summary>
    /// Togo
    /// </summary>
    [EnumMember(Value = "countryTG")]
    Togo,

    /// <summary>
    /// Tokelau
    /// </summary>
    [EnumMember(Value = "countryTK")]
    Tokelau,

    /// <summary>
    /// Tonga
    /// </summary>
    [EnumMember(Value = "countryTO")]
    Tonga,

    /// <summary>
    /// Trinidad and Tobago
    /// </summary>
    [EnumMember(Value = "countryTT")]
    TrinidadAndTobago,

    /// <summary>
    /// Tunisia
    /// </summary>
    [EnumMember(Value = "countryTN")]
    Tunisia,

    /// <summary>
    /// Turkey
    /// </summary>
    [EnumMember(Value = "countryTR")]
    Turkey,

    /// <summary>
    /// Turkmenistan
    /// </summary>
    [EnumMember(Value = "countryTM")]
    Turkmenistan,

    /// <summary>
    /// Turks and Caicos Islands
    /// </summary>
    [EnumMember(Value = "countryTC")]
    TurksAndCaicosIslands,

    /// <summary>
    /// Tuvalu
    /// </summary>
    [EnumMember(Value = "countryTV")]
    Tuvalu,

    /// <summary>
    /// Uganda
    /// </summary>
    [EnumMember(Value = "countryUG")]
    Uganda,

    /// <summary>
    /// Ukraine
    /// </summary>
    [EnumMember(Value = "countryUA")]
    Ukraine,

    /// <summary>
    /// United Arab Emirates
    /// </summary>
    [EnumMember(Value = "countryAE")]
    UnitedArabEmirates,

    /// <summary>
    /// United Kingdom
    /// </summary>
    [EnumMember(Value = "countryUK")]
    UnitedKingdom,

    /// <summary>
    /// United States
    /// </summary>
    [EnumMember(Value = "countryUS")]
    UnitedStates,

    /// <summary>
    /// United States Minor Outlying Islands
    /// </summary>
    [EnumMember(Value = "countryUM")]
    UnitedStatesMinorOutlyingIslands,

    /// <summary>
    /// Uruguay
    /// </summary>
    [EnumMember(Value = "countryUY")]
    Uruguay,

    /// <summary>
    /// Uzbekistan
    /// </summary>
    [EnumMember(Value = "countryUZ")]
    Uzbekistan,

    /// <summary>
    /// Vanuatu
    /// </summary>
    [EnumMember(Value = "countryVU")]
    Vanuatu,

    /// <summary>
    /// Venezuela
    /// </summary>
    [EnumMember(Value = "countryVE")]
    Venezuela,

    /// <summary>
    /// Vietnam
    /// </summary>
    [EnumMember(Value = "countryVN")]
    Vietnam,

    /// <summary>
    /// Virgin Islands, British
    /// </summary>
    [EnumMember(Value = "countryVG")]
    VirginIslandsBritish,

    /// <summary>
    /// Virgin Islands, U.S.
    /// </summary>
    [EnumMember(Value = "countryVI")]
    VirginIslandsUs,

    /// <summary>
    /// Wallis and Futuna
    /// </summary>
    [EnumMember(Value = "countryWF")]
    WallisandFutuna,

    /// <summary>
    /// Western Sahara
    /// </summary>
    [EnumMember(Value = "countryEH")]
    WesternSahara,

    /// <summary>
    /// Yemen
    /// </summary>
    [EnumMember(Value = "countryYE")]
    Yemen,

    /// <summary>
    /// Yugoslavia
    /// </summary>
    [EnumMember(Value = "countryYU")]
    Yugoslavia,

    /// <summary>
    /// Zambia
    /// </summary>
    [EnumMember(Value = "countryZM")]
    Zambia,

    /// <summary>
    /// Zimbabwe
    /// </summary>
    [EnumMember(Value = "countryZW")]
    Zimbabwe
}