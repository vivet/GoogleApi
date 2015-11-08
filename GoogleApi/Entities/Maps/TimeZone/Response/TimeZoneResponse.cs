using System.Runtime.Serialization;
using GoogleApi.Entities.Common;
using GoogleApi.Entities.Common.Interfaces;

namespace GoogleApi.Entities.Maps.TimeZone.Response
{
    /// <summary>
    /// TimeZone Response.
    /// </summary>
    [DataContract]
    public class TimeZoneResponse : BaseResponse, IResponseFor
    {        
        /// <summary>
        /// DstOffset: the offset for daylight-savings time in seconds. This will be zero if the time zone is not in Daylight Savings Time during the specified timestamp.
        /// </summary>
        [DataMember(Name = "dstOffset")]
        public virtual double OffSet { get; set; }
        
        /// <summary>
        /// RawOffset: the offset from UTC (in seconds) for the given location. This does not take into effect daylight savings.
        /// </summary>
        [DataMember(Name = "rawOffset")]
        public virtual double RawOffSet { get; set; }
        
        /// <summary>
        /// TimeZoneId: a string containing the ID of the time zone, such as "America/Los_Angeles" or "Australia/Sydney".
        /// </summary>
        [DataMember(Name = "timeZoneId")]
        public virtual string TimeZoneId { get; set; }        

        /// <summary>
        /// TimeZoneName: a string containing the long form name of the time zone. This field will be localized if the language parameter is set. eg. "Pacific Daylight Time" or "Australian.
        /// </summary>
        [DataMember(Name = "timeZoneName")]
        public virtual string TimeZoneName { get; set; }
    }
}