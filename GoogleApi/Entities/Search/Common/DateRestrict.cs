using System.Text.Json.Serialization;
using GoogleApi.Entities.Search.Common.Converters;
using GoogleApi.Entities.Search.Common.Enums;

namespace GoogleApi.Entities.Search.Common;

/// <summary>
/// Date Restrict.
/// </summary>
[JsonConverter(typeof(DateRestrictJsonConverter))]
public class DateRestrict
{
    /// <summary>
    /// Type - Restricts results to URLs based on date.
    /// </summary>
    public virtual DateRestrictType Type { get; set; } = DateRestrictType.Days;

    /// <summary>
    /// Number - Requests results from the specified number of past days, weeks, months or years.
    /// </summary>
    public virtual int Number { get; set; }

    /// <summary>
    /// Returns the <see cref="DateRestrict"/> to <see cref="string"/>.
    /// </summary>
    /// <returns>The <see cref="DateRestrict"/> object as <see cref="string"/>.</returns>
    public override string ToString()
    {
        return $"{this.Type.ToString().ToLower()[0]}[{this.Number}]";
    }

    /// <summary>
    /// Converts a <see cref="string"/> into a <see cref="DateRestrict"/>.
    /// </summary>
    /// <param name="string">The <see cref="string"/> formatted as a valid <see cref="DateRestrict"/>.</param>
    /// <returns>The converted <see cref="DateRestrict"/></returns>
    public static DateRestrict FromString(string @string)
    {
        if (@string == null)
            return new DateRestrict();

        var indexOf = @string.LastIndexOf('[');
        int.TryParse(@string.Substring(indexOf + 1, @string.Length - indexOf - 2), out var number);

        var type = @string.Substring(0, indexOf) switch
        {
            "d" => DateRestrictType.Days,
            "w" => DateRestrictType.Weeks,
            "m" => DateRestrictType.Months,
            "y" => DateRestrictType.Years,
            _ => DateRestrictType.Days
        };

        return new DateRestrict
        {
            Type = type,
            Number = number
        };
    }
}