using System.Collections.Generic;
using System.Runtime.Serialization;
using GoogleApi.Entities.Common.Interfaces;
using GoogleApi.Entities.Maps.Common;

namespace GoogleApi.Entities.Maps.DistanceMatrix.Response
{
    /// <summary>
    /// Responses to Google Maps Distance Matrix API queries are returned in the format indicated by the output flag within the URL request's path.
    /// </summary>
    [DataContract(Name = "DistanceMatrixResponse")]
	public class DistanceMatrixResponse : MapsBaseResponse, IResponseFor
	{
		/// <summary>
        /// OriginAddresses contains an array of addresses as returned by the API from your original request. These are formatted by the geocoder and localized according to the language parameter passed with the request.
		/// </summary>
        [DataMember(Name = "origin_addresses")]
        public virtual IEnumerable<string> OriginAddresses { get; set; }

        /// <summary>
        /// DestinationAddresses contains an array of addresses as returned by the API from your original request. As with origin_addresses, these are localized if appropriate.
        /// </summary>
        [DataMember(Name = "destination_addresses")]
        public virtual IEnumerable<string> DestinationAddresses { get; set; }

        /// <summary>
        /// Rows contains an array of elements, which in turn each contain a status, duration, and distance element.
        /// </summary>
        [DataMember(Name = "rows")]
        public virtual IEnumerable<Row> Rows { get; set; }
    }
}
