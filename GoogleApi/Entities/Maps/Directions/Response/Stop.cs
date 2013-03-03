using System.Runtime.Serialization;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.Directions.Response
{
	/// <summary>
	/// Contains information about the stop/station for this part of the trip
	/// </summary>
	[DataContract(Name = "stop")]
	public class Stop
	{
		/// <summary>
		/// The name of the transit station/stop. eg. "Union Square".
		/// </summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// The location of the transit station/stop, represented as lattitude and longitude.
		/// </summary>
		[DataMember(Name = "location")]
		public Location Location { get; set; }
	}
}