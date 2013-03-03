using System;
using System.Runtime.Serialization;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Places.PlacesDetails.Response
{
    [DataContract]
    public class Review
    {
        /// <summary>
        /// aspects contains a collection of AspectRating objects, each of which provides a rating of a single attribute of the establishment. The first object in the collection is considered the primary aspect.
        /// </summary>
        [DataMember(Name = "aspect")]
        public Aspect Aspect { get; set; }

        /// <summary>
        /// author_name the name of the user who submitted the review. Anonymous reviews are attributed to "A Google user".
        /// </summary>
        [DataMember(Name = "author_name")]
        public string AuthorName { get; set; }

        /// <summary>
        /// author_url the URL to the users Google+ profile, if available.
        /// </summary>
        [DataMember(Name = "author_url")]
        public string AuthorUrl { get; set; }

        /// <summary>
        /// text contains the user's review. When reviewing a location with Google Places, text reviews are considered optional; therefore, this field may by empty.
        /// </summary>
        [DataMember(Name = "text")]
        public string Text { get; set; }

        /// <summary>
        /// time the time that the review was submitted, measured in the number of seconds since since midnight, January 1, 1970 UTC.
        /// </summary>
        public DateTime _time;

        [DataMember(Name = "time")]
        internal int IntStartTime
        {
            get
            {
                return UnixTimeConverter.DateTimeToUnixTimestamp(this._time);
            }
            set
            {
                var _epoch = new DateTime(1970, 1, 1);
                this._time = _epoch.AddSeconds(value);
            }
        }
    }
}
