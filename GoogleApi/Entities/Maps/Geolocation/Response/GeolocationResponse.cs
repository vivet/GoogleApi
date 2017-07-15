using GoogleApi.Entities.Common;
using Newtonsoft.Json;

namespace GoogleApi.Entities.Maps.Geolocation.Response
{
    /// <summary>
    /// Geocoding Response.
    /// </summary>
    public class GeolocationResponse : BaseResponse
    {
        /// <summary>
        /// The user’s estimated latitude and longitude, in degrees. Contains one lat and one lng subfield.
        /// </summary>
        [JsonProperty("location")]
        public virtual Location Location { get; set; }

        /// <summary>
        /// The accuracy of the estimated location, in meters. This represents the radius of a circle around the given location.
        /// </summary>
        [JsonProperty("accuracy")]
        public virtual double Accuracy { get; set; }
    }
}