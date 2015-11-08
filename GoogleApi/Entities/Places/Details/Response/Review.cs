using System;
using System.Runtime.Serialization;
using GoogleApi.Helpers;

namespace GoogleApi.Entities.Places.Details.Response
{
    /// <summary>
    /// Review.
    /// </summary>
    [DataContract]
    public class Review
    {
        /// <summary>
        /// aspects contains a collection of AspectRating objects, each of which provides a rating of a single attribute of the establishment. The first object in the collection is considered the primary aspect.
        /// </summary>
        [DataMember(Name = "aspect")]
        public virtual Aspect Aspect { get; set; }

        /// <summary>
        /// author_name the name of the user who submitted the review. Anonymous reviews are attributed to "A Google user".
        /// </summary>
        [DataMember(Name = "author_name")]
        public virtual string AuthorName { get; set; }

        /// <summary>
        /// author_url the URL to the users Google+ profile, if available.
        /// </summary>
        [DataMember(Name = "author_url")]
        public virtual string AuthorUrl { get; set; }

        /// <summary>
        /// Language an IETF language code indicating the language used in the user's review. This field contains the main language tag only, 
        /// and not the secondary tag indicating country or region. For example, all the English reviews are tagged as 'en', and not 'en-AU' or 'en-UK' and so on.
        /// </summary>
        [DataMember(Name = "language")]
        public virtual string Language { get; set; }

        /// <summary>
        /// Rating the user's overall rating for this place. This is a whole number, ranging from 1 to 5.
        /// </summary>
        [DataMember(Name = "rating")]
        public virtual double Rating { get; set; }
        
        /// <summary>
        /// Text contains the user's review. When reviewing a location with Google Places, text reviews are considered optional; therefore, this field may by empty.
        /// </summary>
        [DataMember(Name = "text")]
        public virtual string Text { get; set; }

        /// <summary>
        /// Time the time that the review was submitted, measured in the number of seconds since since midnight, January 1, 1970 UTC.
        /// </summary>
        public virtual DateTime Time { get; set; }

        [DataMember(Name = "time")]
        protected virtual int TimeInt
        {
            get
            {
                return UnixTimeConverter.DateTimeToUnixTimestamp(this.Time);
            }
            set
            {
                var _epoch = new DateTime(1970, 1, 1);
                this.Time = _epoch.AddSeconds(value);
            }
        }
    }
}
