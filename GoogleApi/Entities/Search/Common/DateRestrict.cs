using GoogleApi.Entities.Search.Common.Enums;

namespace GoogleApi.Entities.Search.Common
{
    /// <summary>
    /// Date Restrict.
    /// </summary>
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
        /// <param name="str">The <see cref="string"/> formatted as a valid <see cref="DateRestrict"/>.</param>
        /// <returns>The converted <see cref="DateRestrict"/></returns>
        public virtual DateRestrict FromString(string str)
        {
            var indexOf = str.LastIndexOf('[');
            int.TryParse(str.Substring(indexOf + 1, str.Length - indexOf - 2), out var number);

            DateRestrictType type;
            switch (str.Substring(0, indexOf))
            {
                case "d":
                    type = DateRestrictType.Days;
                    break;
                case "w":
                    type = DateRestrictType.Weeks;
                    break;
                case "m":
                    type = DateRestrictType.Months;
                    break;
                case "y":
                    type = DateRestrictType.Years;
                    break;

                default:
                    type = DateRestrictType.Days;
                    break;
            }

            return new DateRestrict
            {
                Type = type,
                Number = number
            };
        }
    }
}