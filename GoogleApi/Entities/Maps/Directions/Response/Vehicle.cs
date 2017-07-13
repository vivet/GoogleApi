using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Extensions;
using GoogleApi.Entities.Maps.Directions.Response.Enums;

namespace GoogleApi.Entities.Maps.Directions.Response
{
    /// <summary>
    /// Vehicle
    /// </summary>
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
        internal string VehicleTypeStr
        {
            get => this.VehicleType.ToEnumString();
            set => this.VehicleType = value.ToEnum<VehicleType>();
        }
    }
}