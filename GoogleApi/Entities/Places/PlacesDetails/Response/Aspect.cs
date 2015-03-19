using System.Runtime.Serialization;

namespace GoogleApi.Entities.Places.PlacesDetails.Response
{
    [DataContract]
    public class Aspect
    {        
        /// <summary>
        /// Type the name of the aspect that is being rated. eg. atmosphere, service, food, overall, etc.
        /// </summary>
        [DataMember(Name = "type")]
        public virtual string Type { get; set; }

        /// <summary>
        /// Rating the user's rating for this particular aspect, from 0 to 3.
        /// </summary>
        [DataMember(Name = "rating")]
        public virtual int Rating { get; set; }
    }
}
