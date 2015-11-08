using System.Runtime.Serialization;
using GoogleApi.Entities.Maps.Directions.Response.Enums;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Maps.Directions.Response
{
	[DataContract(Name = "vehicle")]
	public class Vehicle
	{
		/// <summary>
		/// Contains the name of the vehicle on this line. eg. "Subway."
		/// </summary>
		[DataMember(Name = "name")]
        public virtual string Name { get; set; }

		/// <summary>
		/// Contains the URL for an icon associated with this vehicle type.
		/// </summary>
		[DataMember(Name = "icon")]
        public virtual string Icon { get; set; }

        /// <summary>
        /// Contains the type of vehicle that runs on this line.
        /// </summary>
        public virtual VehicleType VehicleType { get; set; }

        [DataMember(Name = "type")]
        protected virtual string VehicleTypeStr
        {
            get { return EnumHelper.ToEnumString(this.VehicleType); }
            set { this.VehicleType = EnumHelper.ToEnum<VehicleType>(value); }
        }
    }
}