using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.DistanceMatrix.Response
{
    /// <summary>
    /// When the Distance Matrix API returns results, it places them within a JSON rows array. Even if no results are returned (such as when the origins and/or destinations don't exist), it still returns an empty array. XML responses consist of zero or more row elements.
    /// Rows are ordered according to the values in the origin parameter of the request. Each row corresponds to an origin, and each element within that row corresponds to a pairing of the origin with a destination value.
    /// Each row array contains one or more element entries, which in turn contain the information about a single origin-destination pairing.
	/// </summary>
	[DataContract(Name = "row")]
	public class Row
	{
		/// <summary>
        /// Each row array contains one or more element entries, which in turn contain the information about a single origin-destination pairing
		/// </summary>
		[DataMember(Name = "elements")]
        public virtual IEnumerable<Element> Elements { get; set; }
	}
}
