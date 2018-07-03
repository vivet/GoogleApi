namespace GoogleApi.Entities.Maps.Geocoding.PlusCode.Response
{
    /// <summary>
    /// Plus Code Response.
    /// </summary>
    public class PlusCodeGeocodeResponse : BaseResponse
    {
        /// <summary>
        /// Plus Code.
        /// </summary>
        public virtual PlusCode PlusCode { get; set; }
    }
}