using System.Runtime.Serialization;
using GoogleApi.Entities.Common;

namespace GoogleApi.Entities.Maps.Geolocation.Response
{
    /// <summary>
    /// Geocoding Response.
    /// </summary>
    [DataContract]
    public class GeolocationResponse : BaseResponse
    {
        /// <summary>
        /// The user’s estimated latitude and longitude, in degrees. Contains one lat and one lng subfield.
        /// </summary>
        [DataMember(Name = "location")]
        public virtual Location Location { get; set; }

        /// <summary>
        /// The accuracy of the estimated location, in meters. This represents the radius of a circle around the given location.
        /// </summary>
        [DataMember(Name = "accuracy")]
        public virtual double Accuracy { get; set; }
    }
}