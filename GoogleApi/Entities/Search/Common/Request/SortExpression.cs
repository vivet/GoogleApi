using System;
using GoogleApi.Entities.Search.Common.Enums;

namespace GoogleApi.Entities.Search.Common.Request
{
    /// <summary>
    /// The sort expression to apply to the results.
    /// </summary>
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
        /// Returns the sort expression as string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", this.By.ToString().ToLower(), this.Order.ToString().ToLower(), this.DefaultValue?.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sortStr"></param>
        /// <returns></returns>
        public virtual SortExpression FromString(string sortStr)
        {
            var strings = sortStr.Split(',');

            return new SortExpression
            {
                By = (SortBy)Enum.Parse(typeof(SortBy), strings[0]),
                Order = (SortOrder)Enum.Parse(typeof(SortOrder), strings[1]),
                DefaultValue = int.Parse(strings[2])
            };
        }
    }
}