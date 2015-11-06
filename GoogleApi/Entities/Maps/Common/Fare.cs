using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Common
{
	/// <summary>
	/// Fare.
	/// </summary>
	[DataContract(Name = "fare")]
	public class Fare
	{
        /// <summary>
        ///  An ISO 4217 currency code indicating the currency that the amount is expressed in.
        /// </summary>
		[DataMember(Name = "currency")]
        internal virtual string Currency { get; set; }

		/// <summary>
        /// The total fare amount, in the currency.
		/// </summary>
        [DataMember(Name = "value")]
        public double? Value { get; set; }

		/// <summary>
        /// The total fare amount, formatted in the requested language.
		/// </summary>
		[DataMember(Name = "text")]
        public virtual string Text { get; set; }
	}
}
