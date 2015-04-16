using System.Runtime.Serialization;
using GoogleApi.Entities.Maps.Common.Enums;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Maps.Common
{
    [DataContract]
    public abstract class MapsBaseResponse
    {
        /// <summary>
        /// "status" contains metadata on the request.
        /// </summary>
        public Status Status { get; set; }

        [DataMember(Name = "status")]
        internal virtual string StatusStr
        {
            get { return EnumHelper.ToEnumString(Status); }
            set { Status = EnumHelper.ToEnum<Status>(value); }
        }
    }
}