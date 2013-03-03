using System;
using System.Runtime.Serialization;
using GoogleApi.Entities.Maps.Common.Enums;

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
        internal string StatusStr
        {
            get
            {
                return this.Status.ToString();
            }
            set
            {
                this.Status = (Status)Enum.Parse(typeof(Status), value);
            }
        }
    }
}