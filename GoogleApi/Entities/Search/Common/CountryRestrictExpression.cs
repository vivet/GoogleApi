using System;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Search.Common.Enums;
using GoogleApi.Entities.Search.Common.Enums.Extensions;

namespace GoogleApi.Entities.Search.Common
{
    /// <summary>
    /// An expression that is part of a <see cref="CountryRestrict"/> 
    /// or nested expression associated with another <see cref="CountryRestrictExpression"/> object.
    /// </summary>
    public class CountryRestrictExpression
    {
        /// <summary>
        /// The NOT operator (.) removes all results that are in the collection immediately following the minus("-") operator.
        /// This example removes all results that are originating from France:
        /// Example: cr= -countryFR
        /// </summary>
        public virtual bool Not { get; set; }

        /// <summary>
        /// The <see cref="Country"/> to restrict in the search.
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// The <see cref="Operator"/> to apply after this expression and before the next.
        /// If this expression is the last of nested expressions, the operator will be placed outside the ending perenthese.
        /// if this is the last expression the <see cref="Enums.Operator"/> will be ignored.
        /// Default is <see cref="Enums.Operator.And"/>.
        /// </summary>
        public virtual Operator Operator { get; set; } = Operator.And;

        /// <summary>
        /// Nested <see cref="CountryRestrict"/>,
        /// that expressions will be appended inside parantheses after this <see cref="CountryRestrictExpression"/>.
        /// </summary>
        public virtual CountryRestrict NestedCountryRestrict { get; set; }

        /// <summary>
        /// Converts the <see cref="CountryRestrictExpression"/> to a <see cref="string"/>,
        /// compatible with the format used by Google search country restriction request.
        /// </summary>
        /// <returns>A <see cref="string"/>.</returns>
        public override string ToString()
        {
            var not = this.Not ? "-" : string.Empty;
            var cr = this.Country.ToCr();
            var op = this.Operator.ToStringOperator();
            var nested = this.NestedCountryRestrict?.ToString();

            return $"{not}{cr}{op}{nested}";
        }

        /// <summary>
        /// Converts a <see cref="string"/> country restrict expression into a <see cref="CountryRestrictExpression"/> object.
        /// </summary>
        /// <param name="string">The <see cref="string"/> to convert.</param>
        /// <returns>A <see cref="CountryRestrictExpression"/> object.</returns>
        public virtual CountryRestrictExpression FromString(string @string)
        {
            if (string.IsNullOrEmpty(@string))
                return null;

            // TODO: Implement CountryRestrict.FromString(string) (NestedCountryRestrict)

            this.Not = @string.StartsWith("-");
            this.Operator = @string.Substring(@string.Length - 1) == "." ? Operator.And : Operator.Or;
            this.Country = @string.Substring(@string.IndexOf("country", StringComparison.Ordinal), 9).ToEnum<Country>();

            return this;
        }

    }
}