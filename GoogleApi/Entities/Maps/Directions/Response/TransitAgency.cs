using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.Directions.Response
{
	/// <summary>
	/// Information about the transit agency.
	/// Note: You must display the names and URLs of the transit agencies servicing the trip results.
	/// </summary>
	[DataContract(Name = "TransitAgency")]
	public class TransitAgency
	{
		/// <summary>
		/// Contains the name of the transit agency.
		/// </summary>
		[DataMember(Name = "name")]
        public virtual string Name { get; set; }

		/// <summary>
		/// Contains the URL for the transit agency.
		/// </summary>
		[DataMember(Name = "url")]
        public virtual string Url { get; set; }

		/// <summary>
		/// Contains the phone number of the transit agency.
		/// </summary>
		[DataMember(Name = "phone")]
        public virtual string Phone { get; set; }
	}
}