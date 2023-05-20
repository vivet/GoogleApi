using System;
using System.Text.Json.Serialization;
using GoogleApi.Entities.Search.Common.Converters;
using GoogleApi.Entities.Search.Common.Enums;

namespace GoogleApi.Entities.Search.Common;

/// <summary>
/// The sort expression to apply to the results.
/// </summary>
[JsonConverter(typeof(SortExpressionJsonConverter))]
public class SortExpression
{
    /// <summary>
    /// The sort expression to apply to the results.
    /// </summary>
    public virtual SortBy By { get; set; } = SortBy.Rank;

    /// <summary>
    /// The direction to sort the search results, either Ascending or Descending.
    /// </summary>
    public virtual SortOrder Order { get; set; } = SortOrder.Ascending;

    /// <summary>
    /// The default value of the expression, if no field is present and cannot be calculated for a document.
    /// A text value must be specified for text sorts. A numeric value must be specified for numeric sorts.
    /// </summary>
    public virtual int? DefaultValue { get; set; }

    /// <summary>
    /// Returns the <see cref="SortExpression"/> to <see cref="string"/>.
    /// </summary>
    /// <returns>The <see cref="SortExpression"/> object as <see cref="string"/>.</returns>
    public override string ToString()
    {
        return $"{this.By.ToString().ToLower()}, {this.Order.ToString().ToLower()}, {this.DefaultValue}";
    }

    /// <summary>
    /// Converts a <see cref="string"/> into a <see cref="SortExpression"/>.
    /// </summary>
    /// <param name="string">The <see cref="string"/> formatted as a valid <see cref="SortExpression"/>.</param>
    /// <returns>The converted <see cref="SortExpression"/></returns>
    public static SortExpression FromString(string @string)
    {
        if (@string == null)
            return new SortExpression();

        var strings = @string.Split(',');

        Enum.TryParse(strings[0], true, out SortBy sortBy);
        Enum.TryParse(strings[1], true, out SortOrder sortOrder);
        int.TryParse(strings[2], out var defualtValue);

        return new SortExpression
        {
            By = sortBy,
            Order = sortOrder,
            DefaultValue = defualtValue
        };
    }
}