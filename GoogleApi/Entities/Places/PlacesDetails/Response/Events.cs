using System;
using System.Runtime.Serialization;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Places.PlacesDetails.Response
{
    [DataContract]
    public class Event
    {
        /// <summary>
        /// start_time: The event's start time, expressed in Unix time.
        /// </summary>
        public DateTime _startTime;
        [DataMember(Name = "start_time")]
        internal virtual int IntStartTime
        {
            get
            {
                return UnixTimeConverter.DateTimeToUnixTimestamp(_startTime);
            }
            set
            {
                var _epoch = new DateTime(1970, 1, 1);
                _startTime = _epoch.AddSeconds(value);
            }
        }

        /// <summary>
        /// event_id: The unique ID of this event.
        /// </summary>
        [DataMember(Name = "event_id")]
        public virtual string EventId { get; set; }

        /// <summary>
        /// summary: A textual description of the event. This property contains a string, the contents of which are not sanitized by the server. Your application should be prepared to prevent or deal with attempted exploits, if necessary.
        /// </summary>
        [DataMember(Name = "summary")]
        public virtual string Summary { get; set; }

        /// <summary>
        /// url: A URL pointing to details about the event. This property will not be returned if no URL was specified for the event.
        /// </summary>
        [DataMember(Name = "url")]
        public virtual string Url { get; set; }
    }
}
