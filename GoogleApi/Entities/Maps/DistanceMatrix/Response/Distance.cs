using System.Runtime.Serialization;

namespace GoogleApi.Entities.Maps.DistanceMatrix.Response
{
	[DataContract(Name = "distance")]
	public class Distance
	{
		/// <summary>
		/// value indicates the distance in meters
		/// </summary>
		[DataMember(Name = "value")]
		public int Value { get; set; }

		/// <summary>
		/// text contains a human-readable representation of the distance, displayed in units as used at the origin, in the language specified in the request. (For example, miles and feet will be used for any origin within the United States.) Note that regardless of what unit system is displayed as text, the distance.value field always contains a value expressed in meters.
		/// </summary>
		[DataMember(Name = "text")]
		public string Text { get; set; }
	}
}
