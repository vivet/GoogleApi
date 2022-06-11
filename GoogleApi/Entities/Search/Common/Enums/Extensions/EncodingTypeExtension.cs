namespace GoogleApi.Entities.Search.Common.Enums.Extensions
{
    /// <summary>
    /// Encoding type Extension methods.
    /// </summary>
    public static class EncodingTypeExtension
    {
        /// <summary>
        /// Returns the encoding type code.
        /// </summary>
        /// <param name="encodingType">The <see cref="EncodingType"/>.</param>
        /// <returns>Encoded name as string.</returns>
        public static string ToCode(this EncodingType encodingType)
        {
            return encodingType switch
            {
                EncodingType.Utf8 => "UTF-8",
                EncodingType.ArabicWindows1256 => "windows-1256",
                EncodingType.CentralEuropeanLatin2Iso88592 => "ISO-8859-2",
                EncodingType.CentralEuropeanWindows1250 => "windows-1250",
                EncodingType.CentralEuropeanCp852 => "cp852",
                EncodingType.ChineseSimplifiedGb2312 => "GB2312",
                EncodingType.ChineseSimplifiedGb18030 => "GB18030",
                EncodingType.ChineseTraditionalBig5 => "big5",
                EncodingType.CyrillicIso88595 => "ISO-8859-5",
                EncodingType.CyrillicKoi8R => "KOI8-R",
                EncodingType.CyrillicWindows1251 => "windows-1251",
                EncodingType.CyrillicRussianCp866 => "cp-866",
                EncodingType.GreekIso88597 => "ISO-8859-7",
                EncodingType.HebrewIso88598I => "ISO-8859-8-I",
                EncodingType.HebrewWindows1255 => "windows-1255",
                EncodingType.JapaneseShift_Jis => "Shift_JIS",
                EncodingType.JapaneseEucjp => "EUC-JP",
                EncodingType.JapaneseIso2022Jp => "ISO-2022-JP",
                EncodingType.KoreanEuckr => "EUC-KR",
                EncodingType.NordicLatin6Iso885910 => "ISO-8859-10",
                EncodingType.SouthEuropeanLatin3Iso88593 => "ISO-8859-3",
                EncodingType.TurkishLatin5Iso88599 => "ISO-8859-9",
                EncodingType.TurkishWindows1254 => "windows-1254",
                EncodingType.VietnameseWindows1258 => "windows-1258",
                EncodingType.WestEuropeanLatin1Iso88591 => "ISO-8859-1",
                EncodingType.WestEuropeanLatin9Iso885915 => "ISO-8859-15",
                _ => string.Empty
            };
        }
    }
}