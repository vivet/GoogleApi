namespace GoogleApi.Entities.Search.Common.Enums.Extensions
{
    /// <summary>
    /// Operator extensions.
    /// </summary>
    public static class OperatorExtension
    {
        /// <summary>
        /// Converts an <see cref="Operator"/> to a <see cref="string"/> for a country restriction expression.
        /// </summary>
        /// <param name="operator">The <see cref="Operator"/> to convert.</param>
        /// <returns>The <see cref="string"/> representation of the <see cref="Operator"/>.</returns>
        public static string ToStringOperator(this Operator @operator)
        {
            switch (@operator)
            {
                case Operator.And:
                    return ".";

                case Operator.Or:
                    return "|";

                default:
                    return string.Empty;
            }
        }
    }
}