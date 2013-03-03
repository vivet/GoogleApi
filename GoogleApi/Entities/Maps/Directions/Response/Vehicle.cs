using System;
using System.Runtime.Serialization;
using GoogleApi.Entities.Maps.Directions.Response.Enums;

namespace GoogleApi.Entities.Maps.Directions.Response
{
	[DataContract(Name = "vehicle")]
	public class Vehicle
	{
		/// <summary>
		/// Contains the name of the vehicle on this line. eg. "Subway."
		/// </summary>
		[DataMember(Name = "name")]
		public string Name { get; set; }

		/// <summary>
		/// Contains the type of vehicle that runs on this line.
		/// </summary>
		[DataMember(Name = "type")]
		public string VehicleTypeString
		{
			get { return VehicleType.ToString(); }
			set { VehicleType = (VehicleType)Enum.Parse(typeof(VehicleType), value); }
		}

		/// <summary>
		/// Contains the type of vehicle that runs on this line.
		/// </summary>
		public VehicleType VehicleType { get; set; }

		/// <summary>
		/// Contains the URL for an icon associated with this vehicle type.
		/// </summary>
		[DataMember(Name = "icon")]
		public string Icon { get; set; }
	}
}