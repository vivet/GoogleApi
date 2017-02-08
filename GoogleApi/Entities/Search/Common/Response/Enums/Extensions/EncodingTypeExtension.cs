namespace GoogleApi.Entities.Search.Common.Response.Enums.Extensions
{
    /// <summary>
    /// Encoding type Extension methods.
    /// </summary>
    public static class EncodingTypeExtension
    {
        /// <summary>
        /// Returns the encoding type code.
        /// </summary>
        /// <param name="encodingType"></param>
        /// <returns></returns>
        public static string ToCode(this EncodingType encodingType)
        {
            switch (encodingType)
            {
                case EncodingType.UnicodeUtf8: return "UTF-8";
                case EncodingType.ArabicWindows1256: return "windows-1256";
                case EncodingType.CentralEuropeanLatin2Iso88592: return "ISO-8859-2";
                case EncodingType.CentralEuropeanWindows1250: return "windows-1250";
                case EncodingType.CentralEuropeanCp852: return "cp852";
                case EncodingType.ChineseSimplifiedGb2312: return "GB2312";
                case EncodingType.ChineseSimplifiedGb18030: return "GB18030";
                case EncodingType.ChineseTraditionalBig5: return "big5";
                case EncodingType.CyrillicIso88595: return "ISO-8859-5";
                case EncodingType.CyrillicKoi8R: return "KOI8-R";
                case EncodingType.CyrillicWindows1251: return "windows-1251";
                case EncodingType.CyrillicRussianCp866: return "cp-866";
                case EncodingType.GreekIso88597: return "ISO-8859-7";
                case EncodingType.HebrewIso88598I: return "ISO-8859-8-I";
                case EncodingType.HebrewWindows1255: return "windows-1255";
                case EncodingType.JapaneseShift_Jis: return "Shift_JIS";
                case EncodingType.JapaneseEucjp: return "EUC-JP";
                case EncodingType.JapaneseIso2022Jp: return "ISO-2022-JP";
                case EncodingType.KoreanEuckr: return "EUC-KR";
                case EncodingType.NordicLatin6Iso885910: return "ISO-8859-10";
                case EncodingType.SouthEuropeanLatin3Iso88593: return "ISO-8859-3";
                case EncodingType.TurkishLatin5Iso88599: return "ISO-8859-9";
                case EncodingType.TurkishWindows1254: return "windows-1254";
                case EncodingType.VietnameseWindows1258: return "windows-1258";
                case EncodingType.WestEuropeanLatin1Iso88591: return "ISO-8859-1";
                case EncodingType.WestEuropeanLatin9Iso885915: return "ISO-8859-15";
            }

            return string.Empty;
        }
    }
}