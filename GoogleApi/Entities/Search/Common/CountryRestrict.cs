using System.Collections.Generic;
using System.Text;

namespace GoogleApi.Entities.Search.Common
{
    /// <summary>
    /// Restricts search results to documents originating in a particular country. 
    /// </summary>
    public class CountryRestrict
    {
        /// <summary>
        /// The expresssions of the country restriction.
        /// </summary>
        public virtual IEnumerable<CountryRestrictExpression> Expressions { get; set; }

        /// <summary>
        /// Converts the <see cref="CountryRestrictExpression"/> to a <see cref="string"/>,
        /// compatible with the format used by Google search country restriction request.
        /// </summary>
        /// <returns>A <see cref="string"/>.</returns>
        public override string ToString()
        {
            if (this.Expressions == null)
                return string.Empty;

            var stringBuilder = new StringBuilder("(");
            foreach (var expression in this.Expressions)
            {
                stringBuilder.Append(expression);
            }

            stringBuilder.Insert(stringBuilder.Length - 1, ")");

            return stringBuilder.ToString();
        }
    }
}